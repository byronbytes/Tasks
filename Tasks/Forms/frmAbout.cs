/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tasks.Utils;

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
            Utils.Update.CheckForUpdates();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            label5.Text = "Name: " + Utils.Update.UpdateString();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks", UseShellExecute = true });
        }
    }
}
