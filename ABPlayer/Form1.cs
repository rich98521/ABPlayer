using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass.AddOn.Mix;
using System.IO;

namespace ABPlayer
{
    public partial class Form1 : Form
    {
        List<AudioFile> audioFiles = new List<AudioFile>();
        int UID = 0, playingId;
        AudioFile playing;
        const int SC_MAXIMIZE = 0xF030, SC_RESTORE = 0xF120, SC_MINIMIZE = 0XF020;
        int lastWindowState = SC_RESTORE;
        //add bookmode to listview, show one entry per books(albums), playing a different book will start from your last position in that book - so you can play other files/books and come back
        //playing a file directly always plays from the start assuming its not loaded/prescrubbed
        //make it a whole other mode, book scrubber by default (also make book scrubber only for current book not for entire library)
        //should be default mode actually, leave multifiles and junk to the program to handle
        //controls should affect book mode when in book mode (prev/next book instead of file)  
        public Form1()
        {
            InitializeComponent();
            chkArtPlaying.Parent = pBoxArt;
            scrubber.Scrubbed += Scrubber1_Scrubbed;
            fileList.OrderChanged += fileList_OrderChanged;
            AudioPlayer.AudioPlaying += AudioPlayer_AudioPlaying;
            AudioPlayer.AudioCompleted += AudioPlayer_AudioCompleted;

            try
            {
                BassNet.Registration("richie98521@gmail.com", "2X3729121152222");
                Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                //Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_FLOATDSP, true);
                Dictionary<int, string> loadedPlugIns = Bass.BASS_PluginLoadDirectory(System.IO.Directory.GetCurrentDirectory());
                BassFx.LoadMe();
                BassMix.LoadMe();
            }
            catch(Exception e)
            {
                BASSError er = Bass.BASS_ErrorGetCode();
            }


            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ABPlayer");
            if (Directory.Exists(folder))
            {
                string file = Path.Combine(folder, "lastOpen.txt");
                if (File.Exists(file))
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        int index = Convert.ToInt32(sr.ReadLine());
                        long ticks = Convert.ToInt64(sr.ReadLine());
                        List<string> files = new List<string>();
                        string f = "";
                        while ((f = sr.ReadLine()) != null)
                            files.Add(f);
                        AddFiles(files.ToArray());
                        if (files.Count > 0)
                        {
                            playingId = index;
                            playing = audioFiles[index];
                            PlayFile(index, new TimeSpan(ticks) - audioFiles[index].StartTime, true);
                        }
                    }
                }
                file = Path.Combine(folder, "settings.txt");
                if (File.Exists(file))
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        AudioPlayer.Volume = Convert.ToSingle(sr.ReadLine());
                        UpdateMono(Convert.ToBoolean(sr.ReadLine()));
                        AudioPlayer.Speed = Convert.ToSingle(sr.ReadLine());
                    }
                }
                tBarVol.Value = (int)(AudioPlayer.Volume * 100);
                lblVol.Text = tBarVol.Value + "%";
                speedToolStripMenuItem.Text = "Speed (" + AudioPlayer.Speed + ")";
            }
        }

        private void AudioPlayer_AudioCompleted()
        {
            int index = audioFiles.IndexOf(playing);
            if (index < audioFiles.Count - 1)
                PlayFile(index + 1);
            else
            {
                AudioPlayer.Stop();
                scrubber.Reset();
            }
        }

        private void AudioPlayer_AudioPlaying(TimeSpan currentTime)
        {
            scrubber.SetCurrentTotal(scrubber.FileStartTime + currentTime);
            scrubber.Refresh();
        }

        private void fileList_OrderChanged(object sender)
        {
            audioFiles = (from ListViewItem i in fileList.Items
                          join o in audioFiles
                          on (int)i.Tag equals o.UID
                          select o).ToList();
            bool removedPlaying = playing != null && !audioFiles.Contains(playing);
            if (audioFiles.Count > 0)
            {
                audioFiles[0].StartTime = new TimeSpan();
                for (int i = 1; i < audioFiles.Count; i++)
                {
                    audioFiles[i].StartTime = audioFiles[i - 1].StartTime + audioFiles[i - 1].Duration;
                }
                if (playing != null)
                    scrubber.FileStartTime = playing.StartTime;
                scrubber.TotalTime = audioFiles.Last().EndTime;
            }
            else
            {
                scrubber.TotalTime = new TimeSpan();
            }
            if(removedPlaying)
            {
                playing = null;
                playingId = -1;
                AudioPlayer.Stop();
                scrubber.Reset();
                pBoxArt.Image = null;
            }
            scrubber.Refresh();
        }

        private void Scrubber1_Scrubbed(object sender, TimeSpan newTime)
        {
            if (newTime > playing.EndTime)
            {
                int index = audioFiles.IndexOf(playing);
                for (int i = index; i < audioFiles.Count; i++)
                {
                    if (newTime <= audioFiles[i].EndTime)
                    {
                        PlayFile(i, newTime - audioFiles[i].StartTime);
                        break;
                    }
                }
            }
            else if (newTime < playing.StartTime)
            {
                int index = audioFiles.IndexOf(playing);
                for (int i = index; i >= 0; i--)
                {
                    if (newTime > audioFiles[i].StartTime)
                    {
                        PlayFile(i, newTime - audioFiles[i].StartTime);
                        break;
                    }
                }
            }
            else
                AudioPlayer.JumpTo(scrubber.CurrentTime);
        }

        private void UpdateScrubber(int index, TimeSpan current, TimeSpan startTime)
        {
            scrubber.FileTime = audioFiles[index].Duration;
            scrubber.CurrentTime = current;
            scrubber.FileStartTime = startTime;
        }

        private void AddFiles(string[] files)
        {
            TimeSpan startTime = new TimeSpan();
            foreach(string f in files)
            {
                try
                {
                    TagLib.Tag tags = TagLib.File.Create(f).Tag;
                    int playingChannel = Bass.BASS_StreamCreateFile(f, 0, 0, 0);
                    TimeSpan playingLength = new TimeSpan(0, 0, 0, 0, (int)(Bass.BASS_ChannelBytes2Seconds(playingChannel, Bass.BASS_ChannelGetLength(playingChannel, BASSMode.BASS_POS_BYTE)) * 1000));
                    
                    int uid = UID++;
                    audioFiles.Add(new AudioFile() { UID = uid, Tags = tags, Duration = playingLength, Location = f, StartTime = startTime });
                    startTime += audioFiles.Last().Duration;

                    scrubber.TotalTime += playingLength;

                    fileList.Items.Add(new ListViewItem(new string[] { tags.Track + "", tags.Title == null ? System.IO.Path.GetFileName(f) : tags.Title, playingLength.ToString(@"hh\:mm\:ss"), tags.Album, f }) { Name = ""+(uid), Tag = uid });
                }
                catch { }
            }
        }

        private void tBarVol_Scroll(object sender, EventArgs e)
        {
            lblVol.Text = tBarVol.Value + "%";
            AudioPlayer.Volume = tBarVol.Value / 100f;
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddFiles(files);
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateArtBox();
        }

        private void UpdateArtBox()
        {
            string artFile = "";
            if (!chkArtPlaying.Checked)
            {
                if (fileList.SelectedItems.Count == 0)
                {
                    pBoxArt.Image = null;
                    return;
                }
                artFile = fileList.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                if (playing == null)
                {
                    pBoxArt.Image = null;
                    return;
                }
                artFile = playing.Location;
            }
            TagLib.IPicture[] pics = TagLib.File.Create(artFile).Tag.Pictures;
            if (pics.Length > 0)
                pBoxArt.Image = Image.FromStream(new System.IO.MemoryStream(pics[0].Data.Data));
        }

        private void showArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVisible();
        }

        private void showFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVisible();
        }

        private void showToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVisible();
        }

        private void UpdateVisible()
        {
            Size newMax = MaximumSize;
            Size newMin = MinimumSize;
            if (!splitContainer1.Visible)
            {
                newMax = new Size();
                newMin = new Size();
                splitContainer1.Visible = true;
                this.Height += (int)splitContainer1.Tag;
            }
            pnlPlayerControls.Visible = showControlsToolStripMenuItem.Checked;
            menuStrip1.Visible = showToolbarToolStripMenuItem.Checked;
            if (showArtToolStripMenuItem.Checked && showFilesToolStripMenuItem.Checked)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Visible = true;
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Visible = true;
            }
            else if (showArtToolStripMenuItem.Checked)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Visible = false;
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Visible = true;
            }
            else if (showFilesToolStripMenuItem.Checked)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Visible = true;
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Visible = false;
            }
            else
            {
                splitContainer1.Tag = splitContainer1.Height;
                splitContainer1.Visible = false;
                newMax = new Size(5000, pnlScrubControl.Height + (menuStrip1.Visible ? menuStrip1.Height : 0) + (this.Height - ClientSize.Height));
                newMin = new Size(0, pnlScrubControl.Height + (menuStrip1.Visible ? menuStrip1.Height : 0) + (this.Height - ClientSize.Height));
            }
            MaximumSize = newMax;
            //MinimumSize = newMin;
        }

        private void showControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVisible();
        }

        private void hideAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllVisible(false);
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllVisible(true);
        }

        private void SetAllVisible(bool b)
        {
            showArtToolStripMenuItem.Checked = b;
            showFilesToolStripMenuItem.Checked = b;
            showControlsToolStripMenuItem.Checked = b;
            //showToolbarToolStripMenuItem.Checked = true;
            UpdateVisible();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
                Jump(new TimeSpan(0, 0, 10), true);
            else if (keyData == (Keys.Right | Keys.Shift))
                Jump(new TimeSpan(0, 1, 0), true);
            else if (keyData == Keys.Left)
                Jump(new TimeSpan(0, 0, -10), true);
            else if (keyData == (Keys.Left | Keys.Shift))
                Jump(new TimeSpan(0, -1, 0), true);
            else if (keyData == (Keys.Control | Keys.T))
            { 
                showToolbarToolStripMenuItem.Checked = !showToolbarToolStripMenuItem.Checked;
                UpdateVisible();
            }
            else if (keyData == Keys.Space)
                PlayPause();
            else
                return base.ProcessCmdKey(ref msg, keyData);


            return true;
        }

        protected override void WndProc(ref Message m)
        {
            int wParam = (m.WParam.ToInt32() & 0xFFF0);
            if (wParam == SC_MAXIMIZE)
            {
                if (lastWindowState == SC_RESTORE &&
                    showArtToolStripMenuItem.Checked == false &&
                    showFilesToolStripMenuItem.Checked == false &&
                    showControlsToolStripMenuItem.Checked == false &&
                    showToolbarToolStripMenuItem.Checked == false)
                {
                    FormBorderStyle = FormBorderStyle.None;
                    UpdateVisible();
                }
                lastWindowState = wParam;
            }
            else if (wParam == SC_RESTORE)
            {
                lastWindowState = wParam;
            }
            else if (wParam == SC_MINIMIZE)
            {
                lastWindowState = wParam;
            }
            base.WndProc(ref m);
        }

        private void Jump(TimeSpan t, bool offset)
        {
            scrubber.Jump(t, offset);
            AudioPlayer.JumpTo(scrubber.CurrentTime);
        }

        private void secondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, 0, 10), true);
        }

        private void secondsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, 0, 30), true);
        }

        private void minuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, 1, 0), true);
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, 5, 0), true);
        }

        private void secondsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, 0, -10), true);
        }

        private void secondsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, 0, -30), true);
        }

        private void minuteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, -1, 0), true);
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jump(new TimeSpan(0, -5, 0), true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            //if (ModifierKeys == Keys.Shift && e.KeyCode == Keys.Right)
            //  minuteToolStripMenuItem.PerformClick();
        }

        private void splitContainer1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                splitContainer1.IsSplitterFixed = true;
        }

        private void splitContainer1_MouseDown(object sender, MouseEventArgs e)
        {
            splitContainer1.IsSplitterFixed = false;
        }

        private void splitContainer1_MouseMove(object sender, MouseEventArgs e)
        {
            splitContainer1.IsSplitterFixed = false;
        }

        private void pBoxArt_MouseEnter(object sender, EventArgs e)
        {
            chkArtPlaying.Show();
        }

        private void pBoxArt_MouseLeave(object sender, EventArgs e)
        {
            if (!pBoxArt.ClientRectangle.Contains(pBoxArt.PointToClient( MousePosition)))
                chkArtPlaying.Hide();
        }

        private void chkArtPlaying_CheckedChanged(object sender, EventArgs e)
        {
            UpdateArtBox();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Multiselect = true };
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                AddFiles(dialog.FileNames);
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog() { };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddFiles(System.IO.Directory.GetFiles(dialog.SelectedPath));
            }
        }

        private void scrubber1_MouseDown(object sender, MouseEventArgs e)
        {
            //AudioPlayer.Pause();
        }

        private void scrubber1_MouseUp(object sender, MouseEventArgs e)
        {
            //AudioPlayer.JumpTo(scrubber1.CurrentTime);
            //AudioPlayer.Continue();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed = 1;
            speedToolStripMenuItem.Text = "Speed (" + AudioPlayer.Speed + ")";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed += 0.05f;
            speedToolStripMenuItem.Text = "Speed (" + AudioPlayer.Speed + ")";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed += 0.2f;
            speedToolStripMenuItem.Text = "Speed (" + AudioPlayer.Speed + ")";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed -= 0.05f;
            speedToolStripMenuItem.Text = "Speed (" + AudioPlayer.Speed + ")";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed -= 0.2f;
            speedToolStripMenuItem.Text = "Speed (" + AudioPlayer.Speed + ")";
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void PlayPause()
        {
            if (AudioPlayer.Playing)
            {
                AudioPlayer.Pause();
            }
            else
            {
                if (AudioPlayer.FileLoaded)
                    AudioPlayer.Continue();
                else
                {
                    int index = 0;
                    if (fileList.SelectedItems.Count != 0)
                        index = (int)fileList.SelectedIndices[0];
                    PlayFile(index);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ABPlayer");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            using (FileStream fs = new FileStream(Path.Combine(folder, "lastOpen.txt"), FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(audioFiles.IndexOf(playing));
                sw.WriteLine(scrubber.CurrentTotalTime.Ticks);
                foreach (AudioFile af in audioFiles)
                    sw.WriteLine(af.Location);
            }
            using (FileStream fs = new FileStream(Path.Combine(folder, "settings.txt"), FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(AudioPlayer.Volume);
                sw.WriteLine(AudioPlayer.Mono);
                sw.WriteLine(AudioPlayer.Speed);
            }
        }

        private void fileList_DoubleClick(object sender, EventArgs e)
        {
            PlayFile(Convert.ToInt32(fileList.SelectedIndices[0]));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int index = audioFiles.IndexOf(playing);
            if (index < audioFiles.Count - 1)
                PlayFile(index + 1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int index = audioFiles.IndexOf(playing);
            if (index > 0)
                PlayFile(index - 1);
        }

        private void PlayFile(int index)
        {
            PlayFile(index, new TimeSpan(), false);
        }

        private void PlayFile(int index, TimeSpan start)
        {
            PlayFile(index, start, false);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateMono(!toolStripMenuItem1.Checked);
        }

        private void monoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMono(monoToolStripMenuItem.Checked);
        }

        public void UpdateMono(bool m)
        {
            toolStripMenuItem1.Checked = !m;
            monoToolStripMenuItem.Checked = m;
            AudioPlayer.Mono = m;
        }

        private void jumpToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToForm jtf = new JumpToForm();
            if(jtf.ShowDialog() == DialogResult.OK)
            {
                scrubber.Jump(playing.StartTime + jtf.Time, false);
                AudioPlayer.JumpTo(jtf.Time);
                //scrubber1.Refresh();
            }
        }

        private void scrubber_Load(object sender, EventArgs e)
        {

        }

        private void scrubber_DoubleClick(object sender, EventArgs e)
        {
            if (lastWindowState == SC_MAXIMIZE)
            {
                WindowState = FormWindowState.Normal;
                lastWindowState = SC_RESTORE;
                showToolbarToolStripMenuItem.Checked = true;
            }
            ToggleBorder();
            UpdateVisible();
        }

        private void ToggleBorder()
        {
            if (FormBorderStyle == FormBorderStyle.Sizable)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
            UpdateVisible();
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void dockAtTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showToolbarToolStripMenuItem.Checked = false;
            FormBorderStyle = FormBorderStyle.None;
            SetAllVisible(false);
            WindowState = FormWindowState.Maximized;
            lastWindowState = SC_MAXIMIZE;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void PlayFile(int index, TimeSpan start, bool loadOnly)
        {
            playingId = audioFiles[index].UID;
            playing = audioFiles[index];
            scrubber.CurrentTime = start;
            scrubber.FileStartTime = audioFiles[index].StartTime;
            scrubber.FileTime = audioFiles[index].Duration;
            scrubber.Refresh();
            fileList.PlayingID = playingId;
            this.Text = fileList.Items["" + playing.UID].SubItems[1].Text;
            UpdateArtBox();
            fileList.Invalidate();
            if (start.TotalSeconds != 0)
            {
                AudioPlayer.Play(playing.Location, true);
                AudioPlayer.JumpTo(start);
                if (!loadOnly)
                    AudioPlayer.Continue();
            }
            else
                AudioPlayer.Play(playing.Location, loadOnly);
        }
    }

    class AudioFile
    {
        public int UID { get; set; }
        public string Location { get; set; }
        public TagLib.Tag Tags { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get { return StartTime + Duration; } }
    }
}
