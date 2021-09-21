using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks.Tasks_v3._0._0.v3._0._0_References;

namespace Tasks.Tasks_v3._0._0 {
    public partial class frmNewCleanup : Form {
        public frmNewCleanup() { InitializeComponent(); }

        private void frmNewCleanup_Load(object sender, EventArgs e) {
            // I want to still keep the feature of logging, but it needs to save somewhere, maybe in a settings?
        }
        //also will be removed and replaced, only for debugging
        private bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                    listBox1.Items.Add("Deleted " + file.FullName);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("Exception Thrown: " + ex.Message);

                }

            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    listBox1.Items.Add("Deleted Folder " + dir.FullName);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("Exception Thrown: " + ex.Message);
                }

            }

            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
            var usertemp = new DirectoryInfo(Path.GetTempPath());
            var downloads = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");

    // The code below will be replaced soon, this is only for testing / debugging
            try
            {
               
                if (DeleteAllFiles(windowstemp)) listBox1.Items.Add("System Temp Folder Cleaned.");
                if (DeleteAllFiles(usertemp)) listBox1.Items.Add("User Temp Folder Cleaned.");
                cleanupSummary();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error while deleting temp folders. " + ex);
            }
        }



        public void cleanupSummary()
        {

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;

             string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
           string folderTasks = Path.Combine(folder, "Tasks");
            Directory.CreateDirectory(folderTasks);
            System.IO.File.WriteAllLines(folderTasks + "\\cleanupSummary" + secondsSinceEpoch + ".txt", listBox1.Items.Cast<string>().ToArray());
        }
    }
}
