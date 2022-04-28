/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/

// Known Issue: It can only remove programs from HKLM

// This is supposed to be simple, which means there will only be one way to create, but multiple ways to delete.

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
using System.Diagnostics;
using System.Threading;
using System.ServiceProcess;

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

        private void RenderStartupsOnListWiew()
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

        private void SetStartup(string AppName, bool enabled, bool isStartupFolder)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
             string fileStartup = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + StartupProcesses.SelectedItems[0].SubItems[0].Text + ".lnk";
            RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(runKey, true);

            if (enabled == true)
            {
                startupKey.Close();
                startupKey = Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.CreateSubKey(AppName, true);
                startupKey.SetValue(AppName, Application.ExecutablePath.ToString());
                startupKey.Close();
            }
            else
            {
                if(isStartupFolder == true)
                {
                 // Remove Startup
                  File.Delete(fileStartup);
                }
                else 
                {
                    // Remove
                startupKey.Close();
                startupKey = Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue(AppName, true);
                startupKey.Close();
                }
                
            }
            
            
        }

     
        private void frmStartupPrograms_Load(object sender, EventArgs e)
        {
            txtTargetPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";
            CheckTheme();
        }


        private void button1_Click(object sender, EventArgs e) // delete
        {
            string fileStartup = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + StartupProcesses.SelectedItems[0].SubItems[0].Text + ".exe";
                try
                {
                    if(StartupProcesses.SelectedItems[0].SubItems[2].Text == "Startup")
                    {
                    SetStartup(StartupProcesses.SelectedItems[0].SubItems[0].Text, false, true);
                    RefreshList();
                }
                    else
                {
                    SetStartup(StartupProcesses.SelectedItems[0].SubItems[0].Text, false, false);
                    RefreshList();
                }
                  
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to delete the selected startup program. " + ex.Message);
                }
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
                    SetStartup(ofd.FileName.ToString(), true, false);
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
