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
    public partial class frmCleanup : Form {
        public frmCleanup() { InitializeComponent(); }

        private void frmNewCleanup_Load(object sender, EventArgs e) {}
  
        // @experimental: Expect changes to the method
        private (int, int, int, int) DeleteAllFiles(DirectoryInfo directoryInfo) {
            int deletedFile = 0;
            int deletedDir = 0;
            int fileCount = directoryInfo.GetFiles().Length;
            int dirCount = directoryInfo.GetDirectories().Length;
            
            foreach (var file in directoryInfo.GetFiles()) {
                try {
                    file.Delete();
                    listBox1.Items.Add("Deleted file '" + file.FullName + "'");
                    ++deletedFile;
                } catch (Exception ex) { listBox1.Items.Add("Exception Thrown: " + ex.Message); }
            }
            
            foreach (var dir in directoryInfo.GetDirectories()) {
                try {
                    dir.Delete(true);
                    listBox1.Items.Add("Deleted folder '" + dir.FullName + "'");
                    ++deletedDir;
                } catch (Exception ex) { listBox1.Items.Add("Exception Thrown: " + ex.Message); }
            }
            
            return (deletedFile, fileCount, deletedDir, dirCount);
        }
        
        private void button3_Click(object sender, EventArgs e) {
            // The deleting / checkbox method is also prone to change soon.
            if (cbTempFiles.Checked) {
                var (wtdf, wtfc, wtdd, wtdc) = DeleteAllFiles(new DirectoryInfo("C:\\Windows\\Temp")); 
                var (utdf, utfc, utdd, utdc) = DeleteAllFiles(new DirectoryInfo(Path.GetTempPath()));

                listBox1.Items.Add("Temp Files Deleted.");
                CleanupLog((wtdf+utdf), (wtfc+utfc), (wtdd+utdd), (wtdc+utdc));
            }
        }


        // This method will deprecate the need for listboxes, even invisible ones.
        // as a good coder once said "NEVER NEVER NEVER use a UI object for a non-UI method.
        public void CleanupLog(int df, int fc, int dd, int dc) {
            CleanupSummary();
            label9.Text = "Deleted " + df + "/" + fc + "files and " + dd + "/" + dc + " directories.";
        }
            
            
        public void CleanupSummary() {
            int t = (int) ((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            File.WriteAllLines(
              Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", 
              listBox1.Items.Cast<string>().ToArray()
            );
        }
    }
}
