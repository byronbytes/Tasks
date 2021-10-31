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

// TODO: Cleanup and change the code style
namespace Tasks {
    public partial class frmStartupPrograms : Form {
        public frmStartupPrograms() {
            InitializeComponent();
            RenderStartupsOnListWiew();
        }

        private void RefreshList() {
            StartupProcesses.Items.Clear();
            RenderStartupsOnListWiew();
        }

        private void RenderStartupsOnListWiew() {
            foreach (ManagementObject strt in (new ManagementClass("Win32_StartupCommand").GetInstances())) { 
                StartupProcesses.Items.Add(strt["Name"].ToString(), 0).SubItems.Add(strt["Location"].ToString()); 
            }
        }

        private void frmStartupPrograms_Load(object sender, EventArgs e) {
            txtTargetPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";
        }

        private void StartupProcesses_SelectedIndexChanged(object sender, EventArgs e) {}

        private void button1_Click(object sender, EventArgs e) {
      
            //if(StartupProcesses)
        }
        
        private void button2_Click(object sender, EventArgs e) {
            // Opens the file dialog for selecting a program
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All|*.*" }) {
                // If statement because if you closed it would throw an exception
                if (ofd.ShowDialog() == DialogResult.OK)  {
                    try
                    {
                        string program = ofd.FileName.ToString();

                        txtFileName.Text = ofd.FileName;
                        FileInfo fileInfo = new FileInfo(txtFileName.Text);
                        txtTargetPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup", fileInfo.Name);
                        File.Copy(txtFileName.Text, txtTargetPath.Text, true);
                        RefreshList();
                    }
                    catch
                    {
                        MessageBox.Show("There was an unexpected error.");
                    }
                  
                } else RefreshList();
            }
        }
        
        private void button3_Click(object sender, EventArgs e) {
            try {
                // will add a method to auto update the list when the window closes
                Process.Start("explorer.exe", @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
            } catch(Exception ex) { MessageBox.Show(ex.GetType().FullName + " caught: " + ex.Message); }

        }

        private void button4_Click(object sender, EventArgs e) {}
        
        public class StartUpProgram {
            public string Name { get; set; }
            public string Path { get; set; }            
            //show name in checkboxitem
            public override string ToString() { return Name; }
        }
        private void button4_Click_1(object sender, EventArgs e) { RefreshList(); }
    }
}
