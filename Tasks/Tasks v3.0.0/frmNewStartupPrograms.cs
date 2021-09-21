using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error opening the folder: " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtFileName.Text = ofd.FileName;
                FileInfo fileInfo = new FileInfo(txtFileName.Text);
                txtTargetPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup", fileInfo.Name);
                File.Copy(txtFileName.Text, txtTargetPath.Text, true);
                Thread.Sleep(30);
                refreshStartupList();
                getStartupPrograms();

            }
        }
    }
}
