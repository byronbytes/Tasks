// (c) LiteTools 2021
// All rights reserved under the Apache-2.0 license.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks.Forms;

namespace Tasks
{
    public partial class frmMain : Form
    {
        public frmMain() {
            
            Directory.CreateDirectory(Dirs.tasksDir); InitializeComponent(); CheckTheme(); Core.SystemInfo.ComputerBit();
        }

        private Form _currentForm;

        public void ShowForm(Form newForm)
        {
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
            if (Properties.Settings.Default.Theme == "dark")
            {
                panel1.BackColor = Color.FromArgb(20, 20, 20);
                panel2.BackColor = Color.FromArgb(20, 20, 20);
                panel3.BackColor = Color.FromArgb(20, 20, 20);

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;

                pictureBox1.Image = Properties.Resources.CleanupWhite;
                pictureBox2.Image = Properties.Resources.StartupProgramsWhite;
                pictureBox3.Image = Properties.Resources.TaskManagerWhite;
                pictureBox4.Image = Properties.Resources.SettingsWhite;
            }

            if (Properties.Settings.Default.Theme == "light")
            {
                panel1.BackColor = Color.FromArgb(250, 250, 250);
                panel2.BackColor = Color.FromArgb(250, 250, 250);
                panel3.BackColor = Color.FromArgb(250, 250, 250);
                pictureBox1.Image = Properties.Resources.Cleanup;
                pictureBox2.Image = Properties.Resources.Startup_Programs_Black;
                pictureBox3.Image = Properties.Resources.Task_Manager;
                pictureBox4.Image = Properties.Resources.Settings;

                
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) { 
            CheckTheme(); 
            label2.Text = Core.SystemInfo.bit;
            label4.Text = Core.SystemInfo.getOSInfo();

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                pictureBox5.Visible = true;
            }
        }

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
            ShowForm(new frmSettingsHolder());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckTheme();
        }
      
    }
}
