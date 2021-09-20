using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Tasks_v3._0._0
{
    public partial class frmNewStartupPrograms : Form
    {
        public frmNewStartupPrograms()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frmNewStartupPrograms_Load(object sender, EventArgs e)
        {
            getStartupPrograms();
        }

        private void refreshStartupList()
        {
            // this should only be used alongside getStartupPrograms()
            StartupProcesses.Items.Clear();
        }
        private void getStartupPrograms()
        {
            // This method is currently used in 2.0.0, I might change the method soon.
            ManagementClass mangnmt = new ManagementClass("Win32_StartupCommand");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            foreach (ManagementObject strt in mcol)
            {
                ListViewItem oo = StartupProcesses.Items.Add(strt["Name"].ToString(), 0);  //Changed the way the items work so we can add more than one subitem.
                oo.SubItems.Add(strt["Location"].ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshStartupList();
            getStartupPrograms();
        }

        private void StartupProcesses_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(!StartupProcesses.Focused)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
         
        }
    }
}
