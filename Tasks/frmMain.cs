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

namespace Tasks {
    public partial class frmMain : Form {
        public frmMain() { Directory.CreateDirectory(Classes.TasksDirectories.TasksCleanup); InitializeComponent(); CheckTheme(); }

        private Form _currentForm;
        private void ShowForm(Form newForm)
        {
            // credit to Anu6is
            if (_currentForm != null) _currentForm.Hide();

            newForm.TopLevel = false;
            newForm.AutoScroll = true;
            newForm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(newForm);
            newForm.Show();

            _currentForm = newForm;
        }


        public void CheckTheme()
        {
            if(Properties.Settings.Default.Theme == "dark")
            {
                panel1.BackColor = Color.FromArgb(20, 20, 20);

                label1.ForeColor = Color.White;

                pictureBox1.Image = Properties.Resources.CleanupWhite;
                pictureBox2.Image = Properties.Resources.StartupProgramsWhite;
                pictureBox3.Image = Properties.Resources.TaskManagerWhite;
                pictureBox4.Image = Properties.Resources.SettingsWhite;
            }

            if (Properties.Settings.Default.Theme == "light")
            {
                panel1.BackColor = Color.FromArgb(250, 250, 250);
                panel2.BackColor = Color.FromArgb(250, 250, 250);
                pictureBox1.Image = Properties.Resources.Cleanup;
                pictureBox2.Image = Properties.Resources.Startup_Program;
                pictureBox3.Image = Properties.Resources.Task_Manager;
                pictureBox4.Image = Properties.Resources.Settings;
               
                label1.ForeColor = Color.Black;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) { CheckTheme(); }
        private void button1_Click(object sender, EventArgs e) { new frmCleanup().Show(); }
        private void button3_Click(object sender, EventArgs e) { new frmStartupPrograms().Show(); }
        private void button4_Click(object sender, EventArgs e) { new frmTaskManager().Show(); }
        private void label1_Click(object sender, EventArgs e) {}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowForm(new frmCleanup());
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowForm(new frmStartupPrograms());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowForm(new frmTaskManager());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShowForm(new frmSettings());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckTheme();
        }
    }
}
