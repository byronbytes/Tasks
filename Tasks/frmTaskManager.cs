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

        private void frmTaskManager_Load(object sender, System.EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {

            string selectedProcess = listView1.SelectedItems[0].SubItems[2].Text; // it was this easy. -.-

            try
            {
                Process.Start("taskkill", "/f /im " + selectedProcess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        string OldItemSelected = string.Empty;


        private void CPUMon_Check() //Laggin
        {
            try
            {


                foreach (ListViewItem LvItem in this.listView1.Items)
                {

                    try
                    {

                        int ProID = System.Convert.ToInt32(LvItem.SubItems[2].Text);

                        Process TargetProcess = Process.GetProcessById(ProID);

                        string CPUPercentUsage = GetProcessCPUPercentUsage(TargetProcess).ToString();

                        LvItem.SubItems[3].Text = CPUPercentUsage + "%";

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
        }

        public void ListProcess(List<ProcessInfoEx> ProcessInfoList)
        {

            this.listView1.Items.Clear();
            if (this.imageList1.Images.Count != 0)
            {
                this.imageList1.Images.Clear();
            }

            int ID = 0;
            foreach (ProcessInfoEx ProcessInfo in ProcessInfoList)
            {

                try
                {
                    Bitmap IconImg = Icon.ExtractAssociatedIcon(ProcessInfo.Path).ToBitmap();
                    this.imageList1.Images.Add(IconImg);

                    ListViewItem lvi = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem lvsisi = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem lvsisi2 = new ListViewItem.ListViewSubItem();

                    lvi.Text = ProcessInfo.TargetProcess.ProcessName;
                    lvi.Tag = ProcessInfo.ComandLine; // Commandline in Item Tag
                    lvi.ImageIndex = ID;

                    lvi.ToolTipText = "Process ID:" + ProcessInfo.TargetProcess.Id.ToString() + Environment.NewLine + "Command Line: " + ProcessInfo.ComandLine;

                    lvsi.Text = ProcessInfo.Path.ToString(); // Process Path

                    lvi.SubItems.Add(lvsi);

                    lvsisi.Text = ProcessInfo.TargetProcess.Id.ToString(); // Process PID
                    lvi.SubItems.Add(lvsisi);

                    Task<double> ProcessCPUTask = Task.Run(async () => await GetProcessCPUPercentUsage(ProcessInfo.TargetProcess));

                    ProcessCPUTask.GetAwaiter().OnCompleted(() => SetProcessCPU(lvsisi2, ProcessCPUTask.Result.ToString()));

                    lvi.SubItems.Add(lvsisi2);

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

        public void SetProcessCPU(ListViewItem.ListViewSubItem SubItem, string CPUPercentUsage)
        {
            SubItem.Text = CPUPercentUsage + "%"; // Process CPU Percent
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

                        if (QueryObject["ExecutablePath"] != null)
                        {
                            InfoProc.Path = QueryObject["ExecutablePath"].ToString();
                        }

                        if (QueryObject["CommandLine"] != null)
                        {
                            InfoProc.ComandLine = QueryObject["CommandLine"].ToString();
                        }

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


        /// XylonV2.Antivir.API Code Extracted and converted to C#
        /// ----------------------------------------------------------------------------------------------------

        ///     ''' <summary>

        ///     ''' Gets the CPU percentage usage for the specified <see cref="Process"/>.

        ///     ''' </summary>

        ///     ''' ----------------------------------------------------------------------------------------------------

        ///     ''' <returns>

        ///     ''' The resulting CPU percentage usage for the specified <see cref="Process"/>.

        ///     ''' </returns>

        ///     ''' ----------------------------------------------------------------------------------------------------
        [DebuggerStepThrough]
        public async Task<double> GetProcessCPUPercentUsage(Process p)
        {
            using (PerformanceCounter perf = new PerformanceCounter("Process", "% Processor Time", p.ProcessName, true))
            {
                perf.NextValue();
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250)); // Recommended value: 1 second
                return (Math.Round(perf.NextValue() / (double)Environment.ProcessorCount, 1));
            }
        }

        public class ProcessInfoEx
        {

            public Process TargetProcess = null;
            public string Path = string.Empty;
            public string ComandLine = string.Empty;

        }


        private void button2_Click(object sender, EventArgs e) { new frmCreateNewProcess().Show(); }

        private void timer1_Tick(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {

        }

    }

 

    }
