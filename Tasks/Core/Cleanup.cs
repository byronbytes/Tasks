using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Core
{
    class Cleanup
    {
        public static void WriteCleanupSummary()
        {
            frmCleanup Cleanup = new frmCleanup();

            int t = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            if (Properties.Settings.Default.EnableCleanupLogs == true)
            {
                try
                {
                    File.WriteAllLines(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", Cleanup.CleanupLogsLBox.Items.Cast<string>().ToArray());
                }
                catch
                {
                    MessageBox.Show("There was an error logging your cleanup session.");
                }
            }

            if (Properties.Settings.Default.CleanupMessageBox == true)
            {
                MessageBox.Show("Cleanup has been logged to: " + Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "Tasks") + "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", "Tasks");
            }
            else
            {

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


    }

  

    public class CleanRecentFiles
    {
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
