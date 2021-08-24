using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks.WIP;

namespace Tasks
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmCleanup Cleanup = new frmCleanup(); // Initialize cleanup form.
            Cleanup.Show(); // Show Form
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTaskManager TaskManager = new frmTaskManager(); // Initialize cleanup form.
            TaskManager.Show(); // Show Form
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://twitter.com/Lite_Tools", UseShellExecute = true });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo{FileName = "https://discord.gg/nCBD9ZJjng", UseShellExecute = true});

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks/issues/new", UseShellExecute = true });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmStartupPrograms Startups = new frmStartupPrograms();
            Startups.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRemoveBloat RemoveBloat = new frmRemoveBloat();
            RemoveBloat.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmAbout About = new frmAbout();
            About.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
