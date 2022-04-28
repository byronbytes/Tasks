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
using Tasks.Forms;

namespace Tasks
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            if (Properties.Settings.Default.CleanupMessageBox == true)
            {
                checkBox1.Checked = true;
            }

            if (Properties.Settings.Default.CleanupMessageBox == false)
            {
                checkBox1.Checked = false;
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

            if (Properties.Settings.Default.SidebarColor == "dark")
            {
                comboBox3.SelectedItem = "Dark";
            }

            if (Properties.Settings.Default.SidebarColor == "light")
            {
                comboBox3.SelectedItem = "Light";
            }

            if (Properties.Settings.Default.Language == "English")
            {
                comboBox1.SelectedItem = "English";
            }

            if (Properties.Settings.Default.Language == "Spanish")
            {
                comboBox1.SelectedItem = "Spanish";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.CleanupMessageBox = true;
            }
            if (checkBox1.Checked == false)
            {
                Properties.Settings.Default.CleanupMessageBox = false;
            }
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "English")
            {
                Properties.Settings.Default.Language = "English";
                Properties.Settings.Default.Save();
            }

            if (comboBox1.SelectedItem == "Spanish")
            {
                Properties.Settings.Default.Language = "Spanish";
                Properties.Settings.Default.Save();
            }


        }
        
        frmMain Main = new frmMain();
 

        private void frmSettings_Load(object sender, EventArgs e)
        {
            CheckTheme();
        }

        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "light")
            {
                this.BackColor = Color.FromArgb(250, 250, 250);
              
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                label11.ForeColor = Color.Black;
                label12.ForeColor = Color.Black;
                label13.ForeColor = Color.Black;
                label14.ForeColor = Color.Black;
                label18.ForeColor = Color.Black;
                label19.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
                comboBox1.BackColor = Color.GhostWhite;
                comboBox1.ForeColor = Color.Black;
                comboBox2.BackColor = Color.GhostWhite;
                comboBox2.ForeColor = Color.Black;
                comboBox3.BackColor = Color.GhostWhite;
                comboBox3.ForeColor = Color.Black;

            }
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Dark")
            {
                Properties.Settings.Default.SidebarColor = "dark";
                Main.CheckTheme();
                Properties.Settings.Default.Save();
            }

            if (comboBox3.SelectedItem == "Light")
            {
                Properties.Settings.Default.SidebarColor = "light";
                Main.CheckTheme();
                Properties.Settings.Default.Save();
            }
        }
    }
}
