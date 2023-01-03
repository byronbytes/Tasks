/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Core.Utils.UpdateUtils.CheckForUpdates();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            label5.Text = "Name: " + Core.Utils.UpdateUtils.UpdateString();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks", UseShellExecute = true });
        }
    }
}
