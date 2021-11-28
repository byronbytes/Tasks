using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if(Properties.Settings.Default.CleanupMessageBox == false)
            {
                checkBox1.Checked = false;
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
          if(checkBox1.Checked == false)
            {
                Properties.Settings.Default.CleanupMessageBox = false;
            }
   
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                // Change Setting WIP.
            }
            if (checkBox2.Checked == false)
            {
                // Change Setting WIP.
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedText == "English")
            {
                // Do nothing right now.
            }

            if(comboBox1.SelectedText == "Spanish")
            {
                // Do nothing right now.
            }


        }
        frmMain Main = new frmMain();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                Properties.Settings.Default.Theme = "dark";
                Main.CheckTheme();
            }

            if(radioButton2.Checked)
            {
                Properties.Settings.Default.Theme = "light";
                Main.CheckTheme();
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
