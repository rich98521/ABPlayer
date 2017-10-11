using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABPlayer
{
    public partial class JumpToForm : Form
    {
        public TimeSpan Time { get; private set; }
        public JumpToForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Time = new TimeSpan(0, Convert.ToInt32(nmHour.Value), Convert.ToInt32(nmMin.Value), 0, (int)(Convert.ToSingle(nmSec.Value) * 1000));
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
