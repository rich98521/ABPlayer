using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ABPlayer
{
    public delegate void OrderChangedEventHandler(object sender);
    class ListView2 : ListView
    {
        public event OrderChangedEventHandler OrderChanged;
        bool mLDown, draggingItems, drag, sortAsc;
        Point mPos, mOffsetPos;
        int dragIndex, sortColumn = -1;
        public int playingID;
        const int WM_PAINT = 0x0F;
        public ListView2()
        {
            DoubleBuffered = true;
        }

        public int PlayingID
        {
            get { return playingID; }
            set
            {
                if(playingID != value)
                {
                    if(Items.Count > 0)
                    {
                        ListViewItem[] res;
                        if ((res = Items.Find("" + playingID, false)).Length > 0)
                            res[0].BackColor = Color.White;
                        if ((res = Items.Find("" + value, false)).Length > 0)
                            res[0].BackColor = Color.LightBlue;
                    }
                    playingID = value;
                }
            }
        }

        protected virtual void OnScrubbed()
        {
            if (OrderChanged != null)
                OrderChanged(this);
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            if (sortColumn == e.Column)
            {
                sortAsc = !sortAsc;
            }
            else
                sortAsc = false;
            sortColumn = e.Column;
            this.ListViewItemSorter = Comparer<ListViewItem>.Create((x, y) => { return (x.SubItems[e.Column].Text[0] > y.SubItems[e.Column].Text[0]) == sortAsc ? -1 : 1; });
            OnScrubbed();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mPos = e.Location;
            mOffsetPos = new Point(mPos.X + AutoScrollOffset.X, mPos.Y + AutoScrollOffset.Y);
            if (mLDown && SelectedItems.Count > 0)
            {
                draggingItems = true;
                Refresh();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                mLDown = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                mLDown = false;
            if (draggingItems)
            {
                draggingItems = false;
                if (drag)
                {
                    this.ListViewItemSorter = null;
                    SelectedListViewItemCollection selecteds = SelectedItems;
                    if (dragIndex > selecteds[0].Index)
                        dragIndex--;
                    foreach (ListViewItem item in selecteds)
                    {
                        Items.Remove(item);
                        Items.Insert(dragIndex, item);
                    }
                    OnScrubbed();
                }
                else
                    this.Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(this.Handle);
                if (draggingItems)
                {
                    ListViewItem it = GetItemAt(mPos.X, mPos.Y + 8);
                    if (it != null)
                    {
                        dragIndex = it.Index;
                        drag = !(dragIndex > SelectedItems[0].Index - 1 && dragIndex < SelectedItems[SelectedItems.Count - 1].Index + 2) && dragIndex >= 0;

                        if (drag)
                        {
                            Rectangle pos = it.Bounds;
                            g.DrawLine(new Pen(Color.Black), new Point(pos.X, pos.Y), new Point(pos.Width, pos.Y));
                        }
                    }
                }
                //if(PlayingID >= 0 && Items.Count > 0)
                //{
                //    ListViewItem it = Items.Find("" + PlayingID, false)?[0];
                //    if(it != null)
                //    {
                //        Rectangle pos = it.Bounds;
                //        g.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 100, 100)), pos);
                //    }
                //}
            }
        }
    }
}





