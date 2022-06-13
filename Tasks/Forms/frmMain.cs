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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks.Forms;

//TODO: Update theme checking method (slow)

namespace Tasks
{
    public partial class frmMain : Form
    {
        public frmMain() {
            
            Directory.CreateDirectory(Dirs.tasksDir);
            InitializeComponent(); 
            CheckTheme(); 
            Core.System.ComputerBit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void CheckTheme() // Required to be lengthy because buttons n stuff.
        {
            if (Properties.Settings.Default.Theme == "dark")
            {
                panel1.BackColor = Color.FromArgb(20, 20, 20);
                panel2.BackColor = Color.FromArgb(20, 20, 20);
                panel3.BackColor = Color.FromArgb(20, 20, 20);

                button1.Image = Properties.Resources.Cleanup_White;
                button2.Image = Properties.Resources.StartupPrograms_White;
                button3.Image = Properties.Resources.TaskManagerWhite;
                button4.Image = Properties.Resources.SettingsWhite;
                
                button1.BackColor = Color.FromArgb(25, 25, 25);
                button2.BackColor = Color.FromArgb(25, 25, 25);
                button3.BackColor = Color.FromArgb(25, 25, 25);
                button4.BackColor = Color.FromArgb(25, 25, 25);
                button1.ForeColor = Color.White;
                button2.ForeColor = Color.White;
                button3.ForeColor = Color.White;
                button4.ForeColor = Color.White;

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;
            }



            if (Properties.Settings.Default.Theme == "light")
            {
                panel1.BackColor = Color.FromArgb(250, 250, 250);
                panel2.BackColor = Color.FromArgb(250, 250, 250);
                panel3.BackColor = Color.FromArgb(250, 250, 250);
                
                button1.Image = Properties.Resources.Cleanup_Black;
                button2.Image = Properties.Resources.StartupPrograms_Black;
                button3.Image = Properties.Resources.TaskManager_Black;
                button4.Image = Properties.Resources.SettingsBlack;
                
                button1.BackColor = Color.FromArgb(240, 240, 240);
                button2.BackColor = Color.FromArgb(240, 240, 240);
                button3.BackColor = Color.FromArgb(240, 240, 240);
                button4.BackColor = Color.FromArgb(240, 240, 240);
                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;

                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }

            if (Properties.Settings.Default.SidebarColor == "light")
            {
                panel1.BackColor = Color.FromArgb(250, 250, 250);
                panel2.BackColor = Color.FromArgb(250, 250, 250);
                panel3.BackColor = Color.FromArgb(250, 250, 250);
                
                button1.Image = Properties.Resources.Cleanup_Black;
                button2.Image = Properties.Resources.StartupPrograms_Black;
                button3.Image = Properties.Resources.TaskManager_Black;
                button4.Image = Properties.Resources.SettingsBlack;
                
                button1.BackColor = Color.FromArgb(240, 240, 240);
                button2.BackColor = Color.FromArgb(240, 240, 240);
                button3.BackColor = Color.FromArgb(240, 240, 240);
                button4.BackColor = Color.FromArgb(240, 240, 240);
                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;

                label1.ForeColor= Color.Black;

                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }

            if (Properties.Settings.Default.SidebarColor == "dark")
            {
                panel1.BackColor = Color.FromArgb(20, 20, 20);
                panel2.BackColor = Color.FromArgb(20, 20, 20);
                panel3.BackColor = Color.FromArgb(20, 20, 20);

                button1.Image = Properties.Resources.Cleanup_White;
                button2.Image = Properties.Resources.StartupPrograms_White;
                button3.Image = Properties.Resources.TaskManagerWhite;
                button4.Image = Properties.Resources.SettingsWhite;
                button1.BackColor = Color.FromArgb(25, 25, 25);
                button2.BackColor = Color.FromArgb(25, 25, 25);
                button3.BackColor = Color.FromArgb(25, 25, 25);
                button4.BackColor = Color.FromArgb(25, 25, 25);
                button1.ForeColor = Color.White;
                button2.ForeColor = Color.White;
                button3.ForeColor = Color.White;
                button4.ForeColor = Color.White;

                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;

            }
        }


        private void frmMain_Load(object sender, EventArgs e) { 
            CheckTheme(); 
            label2.Text = Core.System.bit;
            label4.Text = Core.System.getOSInfo();
            pictureBox5.Visible = true;
            
            /* removed since it's automatically running as admin
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                pictureBox5.Visible = true;
            }
            */
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckTheme(); // laggy.
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCleanup());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSettingsHolder());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new frmStartupPrograms());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaskManager());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Rewrite.frmCleanup());
        }
    }
}
