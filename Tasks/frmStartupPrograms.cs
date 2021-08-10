using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Management;

namespace Tasks
{
    public partial class frmStartupPrograms : Form
    {
        public frmStartupPrograms()
        {
            InitializeComponent();
            RenderStartupsOnListWiew();
        }

        private void RenderStartupsOnListWiew()
        {
            ListViewItem path = new ListViewItem("ProcessPath");
            ManagementClass mangnmt = new ManagementClass("Win32_StartupCommand");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            foreach (ManagementObject strt in mcol)
            {
                StartupProcesses.Items.Add(strt["Name"].ToString(), 0).SubItems.Add(strt["Location"].ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //todo later
        }

        private void frmStartupPrograms_Load(object sender, EventArgs e)
        {

        }
    }
}
