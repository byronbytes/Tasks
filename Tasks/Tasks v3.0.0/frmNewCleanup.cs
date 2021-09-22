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

        private void frmNewCleanup_Load(object sender, EventArgs e) {}


        // Credit to @averagelolol for the idea of listing what files and directories got deleted.
        int deletedFile = 0;
        int deletedDir = 0;
        // DeleteAllFiles is prone to change and be replaced with a new and more efficient method.
        private bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {
         
            foreach (var file in directoryInfo.GetFiles())
            {
             
               
                try
                {
                    file.Delete();
                  
                    listBox1.Items.Add("Deleted " + file.FullName);
                    ++deletedFile;

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
                    ++deletedDir;
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
            var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
            var usertemp = new DirectoryInfo(Path.GetTempPath());


            // The deleting / checkbox method is also prone to change soon.
            if (cbTempFiles.Checked)
            {
                try
                {

                    if (DeleteAllFiles(windowstemp) & DeleteAllFiles(usertemp))
                    {
                        listBox1.Items.Add("Temp Files Deleted.");
                        cleanupSummary();
                        label9.Text = "Deleted Files: " + deletedFile + "\n" + "Deleted Directories: " + deletedDir;

                    }
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("Error while deleting temp folders. " + ex);
                }
            }

            if(cbTasksCleanupLogs.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Tasks");
                    if (DeleteAllFiles(directory))
                        {
                        listBox1.Items.Add("Tasks Cleanup Logs Deleted.");
                        cleanupSummary();
                        label9.Text = "Deleted Files: " + deletedFile + "\n" + "Deleted Directories: " + deletedDir;
                    }
                }
                catch
                {

                }
            }
        }



        public void cleanupSummary()
        {

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
             string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderTasks = Path.Combine(folder, "Tasks");
            Directory.CreateDirectory(folderTasks);
            File.WriteAllLines(folderTasks + "\\cleanupSummary" + secondsSinceEpoch + ".txt", listBox1.Items.Cast<string>().ToArray());
        }
    }
}
