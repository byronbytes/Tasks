using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Tasksv3
{
    public partial class frmTaskManager : Form
    {
        public frmTaskManager()
        {
            InitializeComponent();
            GetTaskManagerStuff();
        }

        private void frmTaskManager_Load(object sender, EventArgs e)
        {

        }

        public void GetTaskManagerStuff()
        {
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQueryString);

            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject QueryObject in results)
            {

                try
                {

                    int ProcessPid = System.Convert.ToInt32(QueryObject["ProcessId"]);

                    Process TargetProcess = Process.GetProcessById(ProcessPid);
                    string ProcessPath = QueryObject["ExecutablePath"].ToString();
                    string ComandLine = QueryObject["CommandLine"].ToString();
                    Bitmap IconImg = Icon.ExtractAssociatedIcon(ProcessPath).ToBitmap();

           
                    listView1.Items.Add(new ListViewItem() { });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
