using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Cleanup and change the code style
namespace Tasks {
    public partial class frmTaskManager : Form {
        public frmTaskManager() { InitializeComponent(); }
        
        /// <summary>
        /// Returns an Expando object with the description and username of a process from the process ID.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public ExpandoObject GetProcessExtraInformation(int processId) {
            // Query the Win32_Process
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            // Create a dynamic object to store some properties on it
            dynamic response = new ExpandoObject();
            response.Username = "System";
            response.Description = "";

            foreach(ManagementObject obj in processList) {
                // Retrieve username 
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                
                // You can return the domain too like (PCDesktop-123123\Username using instead
                //response.Username = argList[1] + "\\" + argList[0];
                if (returnVal == 0) 
                    response.Username = argList[0];

                // Retrieve process description if exists
                if (obj["ExecutablePath"] != null) 
                    try { response.Description = FileVersionInfo.GetVersionInfo(obj["ExecutablePath"].ToString()).FileDescription; } catch {}
            }

            return response;
        }
        /// <summary>
        /// Method that converts bytes to its human readable value
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string BytesToReadableValue(long number) {
            List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };

            for(int i = 0; i < suffixes.Count; i++) {
                long temp = number / (long) Math.Pow(1024, i + 1);
                if(temp == 0) return (number / (long) Math.Pow(1024, i)) + suffixes[i];
            }

            return number.ToString();
        }

        public void clearProcesses() { listView1.Clear(); }
        
        public void renderProcessesOnListView() {
            Process[] processList = Process.GetProcesses();
            ImageList imgList = new ImageList();

            foreach (Process process in processList) {
                string status = (process.Responding == true ? "Responding" : "Not Responding");
                dynamic extraProcessInfo = GetProcessExtraInformation(process.Id);

                // Create an array of string that will store the information to display in our 
                string[] row = {
                    // 1 Process name
                    process.ProcessName,
                    // 2 Process ID
                    process.Id.ToString(),
                    // 3 Process status
                    status,
                    // 4 Username that started the process
                    extraProcessInfo.Username,
                    // 5 Memory usage
                    BytesToReadableValue(process.PrivateMemorySize64),
                    // 6 Description of the process
                    extraProcessInfo.Description
                };
                
                // Not all apps have an icon!
                // The try statement below will add the process ID alongside the icon.
                // !!! This is the code that is suspected to be causing the 60 second freeze bug, also some icons do not exist.
                try { imgList.Images.Add(process.Id.ToString(),  Icon.ExtractAssociatedIcon(process.MainModule.FileName).ToBitmap()); } catch {}
                
                listView1.Items.Add(new ListViewItem(row) { ImageIndex = imgList.Images.IndexOfKey(process.Id.ToString()) });
            }

            // Set the imagelist of your list view the previous created list :)
            listView1.LargeImageList = imgList;
            listView1.SmallImageList = imgList;
        }

        private void frmTaskManager_Load(object sender, System.EventArgs e) { renderProcessesOnListView(); }

        private void button1_Click(object sender, EventArgs e) {
            try {
               // Process[] processList = Process.GetProcesses();
              //  processList[].Kill();
               // clearProcesses();
               // renderProcessesOnListView();
            } catch(Exception ex) { MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void button2_Click(object sender, EventArgs e) { new frmCreateNewProcess().Show(); }
        
        private void timer1_Tick(object sender, EventArgs e) {}
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {}
    }
}
