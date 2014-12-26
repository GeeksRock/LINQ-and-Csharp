using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqToObjects
{
    public partial class frmInfo : Form
    {
        public frmInfo(string displaytext)
        {
            InitializeComponent();
            this.rtbInfo.Text = displaytext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
