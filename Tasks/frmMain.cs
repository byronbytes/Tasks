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
            Process.Start("https://twitter.com/Lite_Tools");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/nCBD9ZJjng");
        }
    }
}
