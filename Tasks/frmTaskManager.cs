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

namespace Tasks
{
    public partial class frmTaskManager : Form
    {
        public frmTaskManager()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Returns an Expando object with the description and username of a process from the process ID.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public ExpandoObject GetProcessExtraInformation(int processId)
        {
            // Query the Win32_Process
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            // Create a dynamic object to store some properties on it
            dynamic response = new ExpandoObject();
            response.Description = "";
            response.Username = "System";

            foreach (ManagementObject obj in processList)
            {
                // Retrieve username 
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return Username
                    response.Username = argList[0];

                    // You can return the domain too like (PCDesktop-123123\Username using instead
                    //response.Username = argList[1] + "\\" + argList[0];
                }

                // Retrieve process description if exists
                if (obj["ExecutablePath"] != null)
                {
                    try
                    {
                        FileVersionInfo info = FileVersionInfo.GetVersionInfo(obj["ExecutablePath"].ToString());
                        response.Description = info.FileDescription;
                    }
                    catch { }
                }
            }

            return response;
        }
        /// <summary>
        /// Method that converts bytes to its human readable value
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string BytesToReadableValue(long number)
        {
            List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };

            for (int i = 0; i < suffixes.Count; i++)
            {
                long temp = number / (long)Math.Pow(1024, i + 1);

                if (temp == 0)
                {
                    return (number / (long)Math.Pow(1024, i)) + suffixes[i];
                }
            }

            return number.ToString();
        }

        public void renderProcessesOnListView()
        {
            // Create an array to store the processes
            Process[] processList = Process.GetProcesses();

            // Create an Imagelist that will store the icons of every process
            ImageList Imagelist = new ImageList();

            // Loop through the array of processes to show information of every process in your console
            foreach (Process process in processList)
            {
                // Define the status from a boolean to a simple string
                string status = (process.Responding == true ? "Responding" : "Not Responding");

                // Retrieve the object of extra information of the process (to retrieve Username and Description)
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

                //
                // As not every process has an icon then, prevent the app from crash
                try
                {
                    Imagelist.Images.Add(
                        // Add an unique Key as identifier for the icon (same as the ID of the process)
                        process.Id.ToString(),
                        // Add Icon to the List 
                        System.Drawing.Icon.ExtractAssociatedIcon(process.MainModule.FileName).ToBitmap()
                    );
                }
                catch
                {

           
                }

                // Create a new Item to add into the list view that expects the row of information as first argument
                ListViewItem item = new ListViewItem(row)
                {
                    // Set the ImageIndex of the item as the same defined in the previous try-catch
                    ImageIndex = Imagelist.Images.IndexOfKey(process.Id.ToString())
                };

                // Add the Item
                listView1.Items.Add(item);
            }

            // Set the imagelist of your list view the previous created list :)
            listView1.LargeImageList = Imagelist;
            listView1.SmallImageList = Imagelist;
        }

        private void frmTaskManager_Load(object sender, System.EventArgs e)
        {
            renderProcessesOnListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Taskkill WIP");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            renderProcessesOnListView();
        }

    }
}
