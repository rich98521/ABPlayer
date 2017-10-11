using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABPlayer
{


    public delegate void ScrubbedEventHandler(object sender, TimeSpan newTime);
    //public delegate void ScrubbedAheadEventHandler(object sender, float percent);
    //public delegate void ScrubbedBehindEventHandler(object sender, float percent);
    public partial class Scrubber : UserControl
    {//scrubbehind, scrubahead, scrubbed events
        public event ScrubbedEventHandler Scrubbed;
        //public event ScrubbedAheadEventHandler ScrubbedAhead;
        //public event ScrubbedBehindEventHandler ScrubbedBehind;
        bool mLDown, scrubMode;
        public TimeSpan TotalTime { get; set; }
        public TimeSpan FileTime { get; set; }
        public TimeSpan CurrentTime { get; set; }
        TimeSpan fileStartTime { get; set; }
        TimeSpan currentTotalTime;
        Rectangle scrubRec;
        int downX;

        public Scrubber()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UpdateScrubRec();
        }

        public void Reset()
        {
            CurrentTime = new TimeSpan();
            currentTotalTime = new TimeSpan();
            FileTime = new TimeSpan();
        }

        protected virtual void OnScrubbed(TimeSpan t)
        {
            if (Scrubbed != null)
                Scrubbed(this, t);
        }

        //protected virtual void OnScrubbedAhead(EventArgs e)
        //{
        //    if (ScrubbedAhead != null)
        //        ScrubbedAhead(this, e);
        //}

        //protected virtual void OnScrubbedBehind(EventArgs e)
        //{
        //    if (ScrubbedBehind != null)
        //        ScrubbedBehind(this, e);
        //}

        public TimeSpan FileStartTime
        {
            get
            { return fileStartTime; }
            set
            {
                fileStartTime = value;
                currentTotalTime = CurrentTime + fileStartTime;
            }
        }

        public TimeSpan CurrentTotalTime
        {
            get
            {
                return currentTotalTime;
            }
            set
            {
                TimeSpan newCurrentTime = CurrentTime + (value - currentTotalTime);
                if (newCurrentTime > FileTime)
                {
                    CurrentTime = FileTime;
                }
                else if (newCurrentTime.TotalSeconds < 0)
                {
                    CurrentTime = new TimeSpan();
                }
                else
                { 
                    CurrentTime = newCurrentTime;
                }


                currentTotalTime = value;
                currentTotalTime = new TimeSpan(Math.Max(Math.Min(currentTotalTime.Ticks, fileStartTime.Ticks + FileTime.Ticks), fileStartTime.Ticks));
                OnScrubbed(value);
            }
        }

        public void SetCurrentTotal(TimeSpan t)
        {
            TimeSpan newCurrentTime = CurrentTime + (t - currentTotalTime);
            if (newCurrentTime > FileTime)
            {
                CurrentTime = FileTime;
            }
            else if (newCurrentTime.TotalSeconds < 0)
            {
                CurrentTime = new TimeSpan();
            }
            else
            {
                CurrentTime = newCurrentTime;
            }
            currentTotalTime = t;
        }

        private void UpdateScrubRec()
        {
            scrubRec = new Rectangle(new Point(4, (this.Height - 10) / 2 - 2), new Size(this.Width - 8, 12));
        }

        private void Scrub(Point p)
        {
            //float mult = Math.Max(Math.Abs(p.Y - (scrubRec.Y+5)) / 5.0f, 1);
            //float percStart = (downX - 4) / (float)scrubRec.Width;
            //float percOffset = (downX - p.X) / (float)scrubRec.Width;
            float perc = ((p.X - 4) / (float)scrubRec.Width);
            //float perc = percStart - percOffset / mult;
            perc = Math.Min(Math.Max(perc, 0), 1);
            if (scrubMode)
                CurrentTotalTime = new TimeSpan((long)(TotalTime.Ticks * perc));
            else
                CurrentTotalTime = FileStartTime + new TimeSpan((long)(FileTime.Ticks * perc));

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (mLDown)
            {
                Scrub(e.Location);
                this.Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                mLDown = true;
                Scrub(e.Location);
                downX = e.X;
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                mLDown = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateScrubRec();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), scrubRec);
            if (FileTime.TotalSeconds > 0)
                g.FillRectangle(new SolidBrush(Color.FromArgb(60, 100, 180)), new RectangleF(new Point(scrubRec.X, scrubRec.Y + 2 + (scrubMode ? 8 : 0)), new SizeF((float)((scrubRec.Width) * (CurrentTime.TotalSeconds / FileTime.TotalSeconds)), scrubRec.Height - 2 - (scrubMode ? 8 : 0))));
            if (TotalTime.TotalSeconds > 0)
                g.FillRectangle(new SolidBrush(Color.FromArgb(180, 100, 60)), new RectangleF(new Point(scrubRec.X, scrubRec.Y), new SizeF((float)((scrubRec.Width) * (CurrentTotalTime.TotalSeconds / TotalTime.TotalSeconds)), 2+ (scrubMode ? 8 : 0))));
            g.DrawString((scrubMode ? CurrentTotalTime : CurrentTime).ToString(@"hh\:mm\:ss"), new Font("Consolas", 10), new SolidBrush(Color.Black), new PointF(4, scrubRec.Bottom));
            g.DrawString((scrubMode ? TotalTime : FileTime).ToString(@"hh\:mm\:ss"), new Font("Consolas", 10), new SolidBrush(Color.Black), new PointF(this.Width - 68, scrubRec.Bottom));
        }

        public void Jump(TimeSpan t, bool offset)
        {
            if(offset)
            {
                CurrentTotalTime += t;
            }
            else
            {
                if (!scrubMode)
                    CurrentTotalTime = t;
                else
                    currentTotalTime = FileStartTime + t;
            }
            this.Invalidate();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            scrubMode = !scrubMode;
            this.Invalidate();
        }
    }
}







