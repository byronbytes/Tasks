/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks/issues/new", UseShellExecute = true });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://litetools.net", UseShellExecute = true });
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            CheckTheme();
        }

        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "light")
            {
                this.BackColor = Color.FromArgb(250, 250, 250);
                listBox1.ForeColor = Color.Black;
                listBox1.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                linkLabel1.ForeColor = Color.Blue;
                linkLabel2.ForeColor = Color.Blue;
            }
        }
    }
}
