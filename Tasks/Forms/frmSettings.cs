/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Tasks
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            if (Properties.Settings.Default.AutoCheckUpdates == true)
            {
                checkBox3.Checked = true;
            }

            if (Properties.Settings.Default.AutoCheckUpdates == false)
            {
                checkBox3.Checked = false;
            }

            if (Properties.Settings.Default.EnableCleanupLogs == true)
            {
                checkBox2.Checked = true;
            }

            if (Properties.Settings.Default.EnableCleanupLogs == false)
            {
                checkBox2.Checked = false;
            }

            if (Properties.Settings.Default.Theme == "dark")
            {
                comboBox2.SelectedItem = "Dark";
            }

            if (Properties.Settings.Default.Theme == "light")
            {
                comboBox2.SelectedItem = "Light";
            }

            if (Properties.Settings.Default.Language == "English")
            {
                comboBox1.SelectedItem = "English";
            }

            if (Properties.Settings.Default.Language == "Spanish")
            {
                comboBox1.SelectedItem = "Spanish";
            }

            if (Properties.Settings.Default.UpdateBranch == "stable")
            {
                comboBox3.SelectedItem = "Stable";
            }

            if (Properties.Settings.Default.UpdateBranch == "beta")
            {
                comboBox3.SelectedItem = "Beta";
            }

            if (Properties.Settings.Default.UpdateBranch == "nightly")
            {
                comboBox3.SelectedItem = "Nightly";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "English")
            {
                Properties.Settings.Default.Language = "English";
                Properties.Settings.Default.Save();
            }

            if (comboBox1.SelectedItem.ToString() == "Spanish")
            {
                Properties.Settings.Default.Language = "Spanish";
                Properties.Settings.Default.Save();
                MessageBox.Show("Language changing is still a work in progress.");
            }


        }

        frmMain Main = new frmMain();


        private void frmSettings_Load(object sender, EventArgs e)
        {
            CheckTheme();
        }

        public void CheckTheme()
        {
            /*
            if (Properties.Settings.Default.Theme == "light")
            {
                this.BackColor = Color.FromArgb(250, 250, 250);
                label3.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                label12.ForeColor = Color.Black;
                label13.ForeColor = Color.Black;
                label14.ForeColor = Color.Black;
                label18.ForeColor = Color.Black;
                label19.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                checkBox3.ForeColor = Color.Black;
                comboBox1.BackColor = Color.GhostWhite;
                comboBox1.ForeColor = Color.Black;
                comboBox2.BackColor = Color.GhostWhite;
                comboBox2.ForeColor = Color.Black;
                comboBox3.BackColor = Color.GhostWhite;
                comboBox3.ForeColor = Color.Black;

            }
            */
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Properties.Settings.Default.EnableCleanupLogs = true;
            }
            if (checkBox2.Checked == false)
            {
                Properties.Settings.Default.EnableCleanupLogs = false;
            }
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Dark")
            {
                Properties.Settings.Default.Theme = "dark";
                Main.CheckTheme();
                CheckTheme();
                Properties.Settings.Default.Save();
            }

            if (comboBox2.SelectedItem == "Light")
            {
                Properties.Settings.Default.Theme = "light";
                Main.CheckTheme();
                CheckTheme();
                Properties.Settings.Default.Save();
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                Properties.Settings.Default.AutoCheckUpdates = true;
                Properties.Settings.Default.Save();
            }
            if (checkBox3.Checked == false)
            {
                Properties.Settings.Default.AutoCheckUpdates = false;
                Properties.Settings.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Stable")
            {
                Properties.Settings.Default.UpdateBranch = "stable";
                Properties.Settings.Default.Save();
            }

            if (comboBox3.SelectedItem == "Beta")
            {
                Properties.Settings.Default.UpdateBranch = "beta";
                Properties.Settings.Default.Save();
            }

            if (comboBox3.SelectedItem == "Nightly")
            {
                Properties.Settings.Default.UpdateBranch = "nightly";
                Properties.Settings.Default.Save();
            }
        }
    }
}
