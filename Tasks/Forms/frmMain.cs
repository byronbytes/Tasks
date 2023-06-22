/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.IO;
using System.Windows.Forms;
using Tasks.Forms;


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
            Core.SystemUtils.ComputerBit();
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
            /*
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

                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
            }

         */

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            CheckTheme();
            label2.Text = Core.SystemUtils.bit;
            label4.Text = Core.SystemUtils.getOSInfo();
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

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoCheckUpdates == true)
            {
                Core.Utils.UpdateUtils.CheckForUpdates();
            }
        }
    }
}
