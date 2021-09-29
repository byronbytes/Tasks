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

namespace Tasks.Tasks_v3._0._0 {
    public partial class frmNewCleanup : Form {
        public frmNewCleanup() { InitializeComponent(); }

        private void frmNewCleanup_Load(object sender, EventArgs e) {}


        // Credit to @averagelolol for the idea of listing what files and directories got deleted.
        int deletedFile = 0;
        int deletedDir = 0;

   
        // DeleteAllFiles is prone to change and be replaced with a new and more efficient method.
        private void DeleteAllFiles(DirectoryInfo directoryInfo)
        {
            // reinitialize variables
            deletedFile = 0;
            deletedDir = 0;
            
            foreach (var file in directoryInfo.GetFiles())
            {

                try
                {
                    file.Delete();
                  
                    listBox1.Items.Add("Deleted file '" + file.FullName + "'");
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
                    listBox1.Items.Add("Deleted folder '" + dir.FullName + "'");
                    ++deletedDir;
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("Exception Thrown: " + ex.Message);
                }

            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            // The deleting / checkbox method is also prone to change soon.
            if (cbTempFiles.Checked)
            {
                DeleteAllFiles(new DirectoryInfo("C:\\Windows\\Temp")); 
                DeleteAllFiles(new DirectoryInfo(Path.GetTempPath()));

                listBox1.Items.Add("Temp Files Deleted.");
                cleanupSummary();
                label9.Text = "Deleted " + deletedFile  + " files and " + deletedDir + " directories.";
            }

        }



        public void cleanupSummary()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderTasks = Path.Combine(folder, "Tasks");
            string folderTasksCleanup = Path.Combine(folderTasks, "Cleanup Summary");
            File.WriteAllLines(folderTasksCleanup + "\\cleanupSummary" + secondsSinceEpoch + ".txt", listBox1.Items.Cast<string>().ToArray());
        }
    }
}
