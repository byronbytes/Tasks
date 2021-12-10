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
                radioButton1.Checked = true;
            }

            if (Properties.Settings.Default.Theme == "light")
            {
                radioButton2.Checked = true;
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
            if (comboBox1.SelectedText == "English")
            {
                // Do nothing right now.
            }

            if (comboBox1.SelectedText == "Spanish")
            {
                // Do nothing right now.
            }


        }
        frmMain Main = new frmMain();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Properties.Settings.Default.Theme = "dark";
                Main.CheckTheme();
            }

            if (radioButton2.Checked)
            {
                Properties.Settings.Default.Theme = "light";
                Main.CheckTheme();
            }

            Properties.Settings.Default.Save();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            CheckTheme();
            
            try
            {
            FileInfo[] files = new DirectoryInfo(@Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary").GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                listBox2.Items.Add(file.Name);
            }
                }
           catch
            {
                listBox2.Items.Add("Unable to add file.");
            }

        }

        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "dark")
            {
                this.BackColor = Color.FromArgb(18, 18, 18);
                label1.ForeColor = Color.White;
            }

            if (Properties.Settings.Default.Theme == "light")
            {
                this.BackColor = Color.FromArgb(250, 250, 250);
                tabPage1.BackColor = Color.White;
                tabPage2.BackColor = Color.White;
                tabPage3.BackColor = Color.White;
                tabPage4.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                label11.ForeColor = Color.Black;
                label12.ForeColor = Color.Black;
                label13.ForeColor = Color.Black;
                label16.ForeColor = Color.Black;
                label17.ForeColor = Color.Black;
                label18.ForeColor = Color.Black;
                label19.ForeColor = Color.Black;
                label20.ForeColor = Color.Black;
                tabControl1.BackColor = Color.White;
                checkBox1.ForeColor = Color.Black;
                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                comboBox1.BackColor = Color.Gray;
                listBox1.BackColor = Color.FromArgb(240, 240, 240);
                listBox1.ForeColor = Color.Black;
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(@Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary\\" + listBox2.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo[] files = new DirectoryInfo(@Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary\\").GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                File.Delete(file.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Tasks\\Cleanup Summary\\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateCheck.CheckForUpdates();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://litetools.net", UseShellExecute = true });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks/issues/new", UseShellExecute = true });
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
    }
}
