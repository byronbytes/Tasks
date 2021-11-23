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
    }
}
