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
      // note for tomorrow, add a file system for tasks temp files and more, reg keys etc
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

        private void button6_Click(object sender, EventArgs e)
        {
            frmUtilityScripts UtilityScripts = new frmUtilityScripts(); // Initialize cleanup form.
            UtilityScripts.Show(); // Show Form
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSettings Settings = new frmSettings(); // Initialize cleanup form.
            Settings.Show(); // Show Form
        }
    }
}
