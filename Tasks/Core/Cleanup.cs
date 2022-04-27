/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tasks.Core
{
    class Cleanup
    {

        public static void WriteCleanupSummary()
        {
            frmCleanup CleanupForm = new frmCleanup();

            int t = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            if (Properties.Settings.Default.EnableCleanupLogs == true)
            {
                try
                {
                    File.WriteAllLines(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", CleanupForm.CleanupLogsLBox.Items.Cast<string>().ToArray());
                }
                catch
                {
                    MessageBox.Show("There was an error creating the log files for your cleanup session.");
                }
            }

            if (Properties.Settings.Default.CleanupMessageBox == true && Properties.Settings.Default.EnableCleanupLogs == false)
            {
                MessageBox.Show("Cleanup successful.");
            }
            else if (Properties.Settings.Default.CleanupMessageBox == true && Properties.Settings.Default.EnableCleanupLogs == true)
            {
                MessageBox.Show("Cleanup session has been logged to: " + Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "Tasks") + "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", "Tasks");
            }
        }



        [DllImport("Shell32.dll")]
        public static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        public enum RecycleFlag : int
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }
        public enum ShellAddToRecentDocsFlags
        {
            Pidl = 0x001,
            Path = 0x002,
            PathW = 0x003
        }


        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, string path);

        public static void ClearAll()
        {
            SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, null);
        }
    }


}

