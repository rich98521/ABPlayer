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
    class ABListView : ListView
    {
        public event OrderChangedEventHandler OrderChanged;
        bool mLDown, draggingItems, drag, sortAsc;
        Point mPos, mOffsetPos;
        int dragIndex, sortColumn = -1;
        public int playingID;
        const int WM_PAINT = 0x0F;
        public ABListView()
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

        protected virtual void OnOrderChanged()
        {
            if (OrderChanged != null)
                OrderChanged(this);
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            if (sortColumn == e.Column)
                sortAsc = !sortAsc;
            else
                sortAsc = false;
            sortColumn = e.Column;
            this.ListViewItemSorter = Comparer<ListViewItem>.Create((x, y) => { return sortAsc ? -1 : 1; });
            OnOrderChanged();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if(e.KeyCode == Keys.Delete)
            {
                while (SelectedItems.Count > 0)
                    Items.Remove(SelectedItems[0]);
                
                OnOrderChanged();
            }
            else if (e.KeyCode == Keys.A)
            {
                if (ModifierKeys == Keys.Control)
                    foreach (ListViewItem it in Items)
                        it.Selected = true;
            }
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
                    OnOrderChanged();
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
                if (draggingItems)
                {
                    ListViewItem it = GetItemAt(mPos.X, mPos.Y + 8);
                    bool after = false;
                    if ((after = mPos.Y + 8 > Items[Items.Count - 1].Bounds.Bottom))
                        it = Items[Items.Count - 1];
                    if (it != null)
                    {
                        dragIndex = it.Index + (after ? 1 : 0);
                        drag = !(dragIndex > SelectedItems[0].Index - 1 && dragIndex < SelectedItems[SelectedItems.Count - 1].Index + 2) && dragIndex >= 0;

                        if (drag)
                        {
                            Graphics g = Graphics.FromHwnd(this.Handle);
                            Rectangle pos = it.Bounds;
                            g.DrawLine(new Pen(Color.Black), new Point(pos.X, pos.Y + (after ? it.Bounds.Height : 0)), new Point(pos.Width, pos.Y + (after ? it.Bounds.Height : 0)));
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





