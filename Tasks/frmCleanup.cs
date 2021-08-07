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

namespace Tasks
{
    public partial class frmCleanup : Form
    {
        public frmCleanup()
        {
            InitializeComponent();
        }

        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        enum RecycleFlag : int
        {
            SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying
            SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete
        }



        private bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {
            var success = true;
            
            foreach(var file in directoryInfo.GetFiles()) {
                try { file.Delete(); }
                catch(Exception ex) { CleanupLogsLBox.Items.Add("Exception Caught: " + ex.Message); success = false; }
            }
            
            foreach(var dir in directoryInfo.GetDirectories()) {
                try { dir.Delete(true); }
                catch(Exception ex) { CleanupLogsLBox.Items.Add("Exception Caught: " + ex.Message); success = false; }
            }
            
            return success;
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked && !checkBox6.Checked && !checkBox7.Checked && !checkBox8.Checked)
            {
                CleanupLogsLBox.Items.Add("Please select something to clean!");
                return;
            }

            if (checkBox1.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Downloads Folder Cleaned.");
            }

            if (checkBox2.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                CleanupLogsLBox.Items.Add("Recycle Bin Cleaned.");
            }

            if (checkBox3.Checked)
            {
                var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
                var usertemp = new DirectoryInfo(Path.GetTempPath());

                if (DeleteAllFiles(windowstemp)) CleanupLogsLBox.Items.Add("System Temp Folder Cleaned.");
                if (DeleteAllFiles(usertemp)) CleanupLogsLBox.Items.Add("User Temp Folder Cleaned.");
            }

            if (checkBox4.Checked)
            {
                var directory = new DirectoryInfo("C:\\Windows\\Prefetch");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Prefetch Cleaned.");
            }

            if (checkBox5.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Cache Cleaned.");
            }

            if (checkBox6.Checked)
            {
           
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Sessions");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Session Storage");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Session Cleaned.");
                if (DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Chrome Session Storage Cleaned.");
            }

            if (checkBox7.Checked)
            {
             
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies-journal");
                CleanupLogsLBox.Items.Add("Chrome Cookies Cleaned.");
       }


            if (checkBox8.Checked)
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History Provider Cache");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History-journal");
                CleanupLogsLBox.Items.Add("Chrome Search History Cleaned.");
            }

            if (CleanupLogsLBox.Items.Count > 2) btnCopyLogs.Enabled = true;
        }

        private void btnCopyLogs_Click(object sender, EventArgs e)
        {
            CleanupLogsLBox.Items.Add("Cleanup logs copied to clipboard.");
            Clipboard.SetText(string.Join("\n", CleanupLogsLBox.Items.Cast<string>()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks/wiki/Cleanup:-What-do-these-mean%3F", UseShellExecute = true });
        }

        private void frmCleanup_Load(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            taskDialog1.Show();
        }
    }
}
    

