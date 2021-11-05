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
    public partial class frmTaskManager : Form
    {
        public frmTaskManager()
        {
            InitializeComponent();

            Task<List<ProcessInfoEx>> ProcessInfoList = Task.Run(async () => await GetProcessAsync());

            ProcessInfoList.GetAwaiter().OnCompleted(() => ListProcess(ProcessInfoList.Result));
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
            response.Username = "System";
            response.Description = "";

            foreach (ManagementObject obj in processList)
            {
                // Retrieve username 
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));

                // You can return the domain too like (PCDesktop-123123\Username using instead
                //response.Username = argList[1] + "\\" + argList[0];
                if (returnVal == 0)
                    response.Username = argList[0];

                // Retrieve process description if exists
                if (obj["ExecutablePath"] != null)
                    try { response.Description = FileVersionInfo.GetVersionInfo(obj["ExecutablePath"].ToString()).FileDescription; } catch { }
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
                if (temp == 0) return (number / (long)Math.Pow(1024, i)) + suffixes[i];
            }

            return number.ToString();
        }

        public void clearProcesses() { listView1.Clear(); }

        public void renderProcessesOnListView()
        {
            Process[] processList = Process.GetProcesses();
            ImageList imgList = new ImageList();

            foreach (Process process in processList)
            {
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

                imgList.Images.Add(Properties.Resources.InfoWhite);
                // !!! This is the code that is suspected to be causing the 60 second freeze bug.
                try
                {
                    String PathToProcess = process.MainModule.FileName;
                    Icon ico = Icon.ExtractAssociatedIcon(PathToProcess);
                    imgList.Images.Add(process.Id.ToString(), ico.ToBitmap());
                }
                catch (Exception e)
                {
                    imgList.Images.Add(process.Id.ToString(), SystemIcons.WinLogo.ToBitmap());
                }

                listView1.Items.Add(new ListViewItem(row) { ImageIndex = imgList.Images.IndexOfKey(process.Id.ToString()) });
            }

            // Set the imagelist of your list view the previous created list :)
            listView1.LargeImageList = imgList;
            listView1.SmallImageList = imgList;
        }

        private void frmTaskManager_Load(object sender, System.EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {

            string selectedProcess = listView1.SelectedItems[0].SubItems[1].Text; // it was this easy. -.-

            try
            {
                Process.Start("taskkill", "/f /im " + selectedProcess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) { new frmCreateNewProcess().Show(); }

        private void timer1_Tick(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            clearProcesses();
            renderProcessesOnListView();
        }




        // NEWER TASK MANAGER CODE
        public void ListProcess(List<ProcessInfoEx> ProcessInfoList)
        {

            this.listView1.Items.Clear();
            this.listView1.SmallImageList.Images.Clear();

            int ID = 0;
            foreach (ProcessInfoEx ProcessInfo in ProcessInfoList)
            {

                try
                {
                    Bitmap IconImg = Icon.ExtractAssociatedIcon(ProcessInfo.Path).ToBitmap();
                    this.listView1.SmallImageList.Images.Add(IconImg);

                    ListViewItem lvi = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem lvsisi = new ListViewItem.ListViewSubItem();

                    lvi.Text = ProcessInfo.TargetProcess.ProcessName;
                    lvi.Tag = ProcessInfo.ComandLine; // Commandline in Item Tag
                    lvi.ImageIndex = ID;

                    lvi.ToolTipText = "Process ID:" + ProcessInfo.TargetProcess.Id.ToString() + Environment.NewLine + "Command Line: " + ProcessInfo.ComandLine;

                    lvsi.Text = ProcessInfo.Path.ToString(); // Process Path

                    lvi.SubItems.Add(lvsi);

                    lvsisi.Text = ProcessInfo.TargetProcess.Id.ToString(); // Process PID
                    lvi.SubItems.Add(lvsisi);

                    this.listView1.Items.Add(lvi);

                    ID += 1;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Application.DoEvents();
            }
        }


        public async Task<List<ProcessInfoEx>> GetProcessAsync()
        {

            List<ProcessInfoEx> TempList = new List<ProcessInfoEx>();

            try
            {

                var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQueryString);

                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject QueryObject in results)
                {

                    try
                    {

                        ProcessInfoEx InfoProc = new ProcessInfoEx();
                        int ProcessPid = System.Convert.ToInt32(QueryObject["ProcessId"]);

                        InfoProc.TargetProcess = Process.GetProcessById(ProcessPid);
                        InfoProc.Path = QueryObject["ExecutablePath"].ToString();
                        InfoProc.ComandLine = QueryObject["CommandLine"].ToString();

                        TempList.Add(InfoProc);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return TempList;

        }

        public class ProcessInfoEx
        {
            public Process TargetProcess;
            public string Path;
            public string ComandLine;
        }
    }
    }
