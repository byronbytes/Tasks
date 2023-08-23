/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
using System.ServiceProcess;


// TODO: DISABLE, NOT DELETE.

namespace Tasks
{
    public partial class frmStartupPrograms : Form
    {
        public frmStartupPrograms()
        {
            InitializeComponent();
            RenderStartupsOnListWiew();
            CheckTheme();
            GetAllServices();
        }

        private void RefreshList()
        {
            StartupProcesses.Items.Clear();
            listView1.Items.Clear();
            RenderStartupsOnListWiew();
            GetAllServices();
        }

        public string AddedProgram;
        public string AddedProgramTitle;

        private void RenderStartupsOnListWiew()
        {
            try
            {
                foreach (ManagementObject strt in (new ManagementClass("Win32_StartupCommand").GetInstances()))
                {

                    string ProcessName = strt["Name"].ToString();
                    string ProcessDescription = strt["Description"].ToString();
                    string Command = strt["Command"].ToString();
                    string ProcessLocation = strt["Location"].ToString();

                    var StartupProcessList = new ListViewItem(ProcessName + "");
                    StartupProcessList.SubItems.Add(ProcessDescription + "");
                    StartupProcessList.SubItems.Add(ProcessLocation + "");
                    StartupProcessList.SubItems.Add(Command + "");

                    StartupProcesses.Items.Add(StartupProcessList);
                }
            }
            catch
            {
                MessageBox.Show("There was an error loading Startup Programs. Please try again later.", "Tasks");
            }
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("Test", AddedProgram);
        }


        private void frmStartupPrograms_Load(object sender, EventArgs e)
        {
            txtTargetPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";
            CheckTheme();
        }

        private void button1_Click(object sender, EventArgs e) // delete
        {
            /*   string fileStartup = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + StartupProcesses.SelectedItems[0].SubItems[0].Text + ".exe";
                   try
                   {
                       if(StartupProcesses.SelectedItems[0].SubItems[2].Text == "Startup")
                       {
                       SetStartup(StartupProcesses.SelectedItems[0].SubItems[0].Text, false);
                       RefreshList();
                   }
                       else
                   {
                       SetStartup(StartupProcesses.SelectedItems[0].SubItems[0].Text, false);
                       RefreshList();
                   }    
                   }
                   catch(Exception ex)
                   {
                       MessageBox.Show("Unable to delete the selected startup program. " + ex.Message);
            }
                 */
        }

        class StartUpProgram
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public override string ToString() { return Name; }
        }

        private void button4_Click_1(object sender, EventArgs e) { RefreshList(); }


        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "light")
            {
                StartupProcesses.BackColor = Color.White;
                StartupProcesses.ForeColor = Color.Black;
                this.BackColor = Color.White;
                tabPage1.BackColor = Color.White;
                tabPage2.BackColor = Color.White;
                listView1.BackColor = Color.White;
                listView1.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Executables|*.exe" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AddedProgram = ofd.FileName.ToString();
                    AddedProgramTitle = ofd.FileName;
                    SetStartup();
                    RefreshList();
                }
            }
        }

        public void GetAllServices()
        {
            foreach (ServiceController service in ServiceController.GetServices())
            {
                string serviceName = service.ServiceName;
                string serviceDisplayName = service.DisplayName;
                string serviceType = service.ServiceType.ToString();
                string status = service.Status.ToString();

                var listViewItem = new ListViewItem(serviceName + " " + serviceDisplayName);
                listViewItem.SubItems.Add(serviceType);
                listViewItem.SubItems.Add(status);

                listView1.Items.Add(listViewItem);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                button1.Hide();
                button2.Hide();
            }
            else
            {
                button1.Show();
                button2.Show();
            }
        }
    }
}
