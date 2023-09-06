/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tasks.Forms;
using Tasks.Utils;

namespace Tasks
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks");
            Directory.CreateDirectory(Dirs.tasksCleanup);
            CheckTheme();
            Utils.System.ComputerBit();
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

        public void CheckTheme()
        {
            
            if (Properties.Settings.Default.Theme == "light")
            {
                panel1.BackColor = Color.FromArgb(250, 250, 250);
                panel2.BackColor = Color.FromArgb(250, 250, 250);
                
                button1.Image = Properties.Resources.Cleanup_Black;
                button2.Image = Properties.Resources.StartupPrograms_Black;
                button4.Image = Properties.Resources.SettingsBlack;
                
                button1.BackColor = Color.FromArgb(240, 240, 240);
                button2.BackColor = Color.FromArgb(240, 240, 240);
                button4.BackColor = Color.FromArgb(240, 240, 240);
                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;

                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(18, 26, 45);
                panel2.BackColor = Color.FromArgb(20, 20, 20);

                button1.Image = Properties.Resources.Cleanup_White;
                button2.Image = Properties.Resources.StartupPrograms_White;
                button4.Image = Properties.Resources.SettingsWhite;

                button1.BackColor = Color.FromArgb(14, 18, 26);
                button2.BackColor = Color.FromArgb(14, 18, 26);
                button4.BackColor = Color.FromArgb(14, 18, 26);

                button1.ForeColor = Color.FromArgb(224, 228, 255);
                button2.ForeColor = Color.FromArgb(224, 228, 255);
                button4.ForeColor = Color.FromArgb(224, 228, 255);

                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;
            }

        

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            CheckTheme();
            label2.Text = Utils.System.bit;
            label4.Text = Utils.System.getOSInfo();
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

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoCheckUpdates == true)
            {
                Utils.Update.CheckForUpdates();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
