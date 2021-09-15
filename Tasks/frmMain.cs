using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void label1_Click(object sender, EventArgs e)
        {
            Tasks_v3._0._0.frmNewMenu NewMenu = new Tasks_v3._0._0.frmNewMenu();
            NewMenu.Show();
        }
    }
}
