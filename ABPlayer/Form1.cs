using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;

namespace ABPlayer
{
    public partial class Form1 : Form
    {
        List<AudioFile> audioFiles = new List<AudioFile>();
        int UID = 0, playingId;
        AudioFile playing;

        public Form1()
        {
            InitializeComponent();
            //scrubber1.CurrentTime = new TimeSpan(0, 2, 10);
            //scrubber1.FileTime = new TimeSpan(0, 5, 31);
            //scrubber1.FileStartTime = new TimeSpan(0, 32, 40);
            //scrubber1.TotalTime = new TimeSpan(1, 13, 58);
            chkArtPlaying.Parent = pBoxArt;
            scrubber1.Scrubbed += Scrubber1_Scrubbed;
            fileList.OrderChanged += fileList_OrderChanged;
            AudioPlayer.AudioPlaying += AudioPlayer_AudioPlaying;
            AudioPlayer.AudioCompleted += AudioPlayer_AudioCompleted;

            try
            {
                BassNet.Registration("richie98521@gmail.com", "2X3729121152222");
                Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                //AddFiles(new string[] { @"D:\Audiobooks\Brian McClellan\Powder Mage 01 - Promise of Blood\Promise of Blood01-19.mp3" });
                //playingFile = @"D:\Audiobooks\Brian McClellan\Powder Mage 01 - Promise of Blood\Promise of Blood01-19.mp3";
            }
            catch
            {
                BASSError er = Bass.BASS_ErrorGetCode();
            }
        }

        private void AudioPlayer_AudioCompleted()
        {
            int index = audioFiles.IndexOf(playing);
            if (index < audioFiles.Count)
                PlayFile(audioFiles[index + 1].UID);
        }

        private void AudioPlayer_AudioPlaying(TimeSpan currentTime)
        {
            scrubber1.CurrentTotalTime = scrubber1.FileStartTime + currentTime;
            scrubber1.Refresh();
        }

        private void fileList_OrderChanged(object sender)
        {
            audioFiles = (from ListViewItem i in fileList.Items
                          join o in audioFiles
                          on (int)i.Tag equals o.UID
                          select o).ToList();

            TimeSpan fileStartTime = new TimeSpan();
            for (int i = 0; i < audioFiles.Count; i++)
            {
                if (audioFiles[i].UID == playingId)
                    break;
                fileStartTime += audioFiles[i].Duration;
            }
            scrubber1.FileStartTime = fileStartTime;
            scrubber1.Refresh();
        }

        private void Scrubber1_Scrubbed(object sender, TimeSpan newTime)
        {
            TimeSpan time = newTime;
            if (newTime > playing.Duration)
            {
                int index = audioFiles.IndexOf(playing);
                for (int i = index; i < audioFiles.Count; i++)
                {
                    if (time > audioFiles[i].Duration)
                        time -= audioFiles[i].Duration;
                    else
                    {
                        UpdateScrubber(i, time, scrubber1.FileStartTime + (newTime - time));
                        fileList.PlayingID = playingId;
                        fileList.Invalidate();
                        break;
                    }
                }
            }
            else if (newTime.TotalSeconds < 0)
            {
                int index = audioFiles.IndexOf(playing);
                for (int i = index; i >= 0; i--)
                {
                    if (time.TotalSeconds < 0)
                        time += audioFiles[i].Duration;
                    else
                    {
                        UpdateScrubber(i, time, scrubber1.FileStartTime + (newTime - time));
                        fileList.PlayingID = playingId;
                        break;
                    }
                }
            }
        }

        private void UpdateScrubber(int index, TimeSpan current, TimeSpan startTime)
        {
            playing = audioFiles[index];
            playingId = audioFiles[index].UID;
            scrubber1.FileTime = audioFiles[index].Duration;
            scrubber1.CurrentTime = current;
            scrubber1.FileStartTime = startTime;
        }

        private void AddFiles(string[] files)
        {
            foreach(string f in files)
            {
                try
                {
                    TagLib.Tag tags = TagLib.File.Create(f).Tag;
                    int playingChannel = Bass.BASS_StreamCreateFile(f, 0, 0, 0);
                    TimeSpan playingLength = new TimeSpan(0, 0, 0, 0, (int)(Bass.BASS_ChannelBytes2Seconds(playingChannel, Bass.BASS_ChannelGetLength(playingChannel, BASSMode.BASS_POS_BYTE)) * 1000));
                    
                    int uid = UID++;
                    audioFiles.Add(new AudioFile() { UID = uid, Tags = tags, Duration = playingLength, Location = f });

                    scrubber1.TotalTime += playingLength;

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

        private void UpdateVisible()
        {
            if (!splitContainer1.Visible)
            {
                MaximumSize = new Size(0, 0);
                splitContainer1.Visible = true;
                this.Height += (int)splitContainer1.Tag;
            }
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
                MaximumSize = new Size(5000, 111);
            }
            pnlPlayerControls.Visible = showControlsToolStripMenuItem.Checked;
        }

        private void showControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVisible();
        }

        private void hideAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showArtToolStripMenuItem.Checked = false;
            showFilesToolStripMenuItem.Checked = false;
            showControlsToolStripMenuItem.Checked = false;
            UpdateVisible();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showArtToolStripMenuItem.Checked = true;
            showFilesToolStripMenuItem.Checked = true;
            showControlsToolStripMenuItem.Checked = true;
            UpdateVisible();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
                secondsToolStripMenuItem.PerformClick();
            else if (keyData == (Keys.Right | Keys.Shift))
                minuteToolStripMenuItem.PerformClick();
            else if (keyData == Keys.Left)
                secondsToolStripMenuItem2.PerformClick();
            else if (keyData == (Keys.Left | Keys.Shift))
                minuteToolStripMenuItem1.PerformClick();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void secondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, 0, 10), true);
        }

        private void secondsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, 0, 30), true);
        }

        private void minuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, 1, 0), true);
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, 5, 0), true);
        }

        private void secondsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, 0, -10), true);
        }

        private void secondsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, 0, -30), true);
        }

        private void minuteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, -1, 0), true);
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrubber1.Jump(new TimeSpan(0, -5, 0), true);
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
            AudioPlayer.Pause();
        }

        private void scrubber1_MouseUp(object sender, MouseEventArgs e)
        {
            AudioPlayer.SetPlayed(scrubber1.CurrentTime);
            AudioPlayer.Continue();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed += 0.05f;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed += 0.2f;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed -= 0.05f;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            AudioPlayer.Speed -= 0.2f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedItems.Count == 0)
                playingId = audioFiles[0].UID;
            else
                playingId = (int)fileList.SelectedItems[0].Tag;
            PlayFile(playingId);
        }

        private void PlayFile(int id)
        {
            playingId = id;
            TimeSpan fileStartTime = new TimeSpan();
            for (int i = 0; i < audioFiles.Count; i++)
            {
                if (audioFiles[i].UID == playingId)
                {
                    scrubber1.FileTime = audioFiles[i].Duration;
                    playing = audioFiles[i];
                    break;
                }
                fileStartTime += audioFiles[i].Duration;
            }
            scrubber1.CurrentTime = new TimeSpan();
            scrubber1.FileStartTime = fileStartTime;
            scrubber1.Refresh();
            fileList.PlayingID = playingId;
            fileList.Invalidate();
            AudioPlayer.PlayFile(playing.Location);
        }
    }

    class AudioFile
    {
        public int UID { get; set; }
        public string Location { get; set; }
        public TagLib.Tag Tags { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
