using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks {
    public partial class frmCleanup : Form {
        public frmCleanup() { InitializeComponent(); }

        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        enum RecycleFlag : int {
            SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying
            SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete
        }



        private bool DeleteAllFiles(DirectoryInfo directoryInfo) {
            try {
                foreach (var file in directoryInfo.GetFiles()) {
                    file.Delete();
                    CleanupLogsLBox.Items.Add("Deleted File " + file.FullName);
                }

                foreach (var dir in directoryInfo.GetDirectories()) {
                    dir.Delete(true);
                    CleanupLogsLBox.Items.Add("Deleted Folder " + dir.FullName);
                }

                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is DirectoryNotFoundException || ex is UnauthorizedAccessException || ex is SecurityException) {
                CleanupLogsLBox.Items.Add("Exception Error: " + ex.Message);
            }

            return false;
        }

        private void btnCleanup_Click(object sender, EventArgs e) {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked) {
                CleanupLogsLBox.Items.Add("Please select something to clean!");
                return;
            }
            
            if (checkBox1.Checked) {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Downloads Folder Cleaned.");
            }

            if (checkBox2.Checked) {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                CleanupLogsLBox.Items.Add("Recycle Bin Cleaned.");
            }

            if (checkBox3.Checked) {
                var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
                var usertemp = new DirectoryInfo(Path.GetTempPath());
                
                if (DeleteAllFiles(windowstemp)) CleanupLogsLBox.Items.Add("System Temp Folder Cleaned.");
                if (DeleteAllFiles(usertemp)) CleanupLogsLBox.Items.Add("User Temp Folder Cleaned.");
            }

            if (checkBox4.Checked) {
                var directory = new DirectoryInfo("C:\\Windows\\Prefetch");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Prefetch Cleaned.");
            }

            if (CleanupLogsLBox.Items.Count > 1) btnCopyLogs.Enabled = true;
        }

        private void btnCopyLogs_Click(object sender, EventArgs e) {
            CleanupLogsLBox.Items.Add("Debug log copied to clipboard.");
            Clipboard.SetText(string.Join("\n", CleanupLogsLBox.Items.Cast<string>()));
        }

        private void button1_Click(object sender, EventArgs e) {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks/wiki/Cleanup:-What-do-these-mean%3F", UseShellExecute = true });
        }
    }
}
    

