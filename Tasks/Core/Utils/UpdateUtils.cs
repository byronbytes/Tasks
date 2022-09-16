using System.Net;
using System.Windows.Forms;

namespace Tasks.Core.Utils
{
    public class UpdateUtils
    {
        
        public static string UpdateString(string address)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString(address);

            return reply;
        }

        // should also add an option for remind me later.
        public static void CheckForUpdates()
        {
           try
           {
            if(isUpToDate() == false)
            {
                MessageBox.Show("There is a new update for Tasks! You can download it at: https://github.com/LiteTools/tag/" + UpdateString(Properties.Settings.Default.VersionString));
            }
            else
            {
                MessageBox.Show("There are no updates available.", "Tasks");
            }
           }
           catch
           {
                MessageBox.Show("Unable to check for updates.", "Tasks");
           }
        }

        public static bool isUpToDate()
        {
            if (UpdateString(Properties.Settings.Default.VersionString) == "v5.0.0-pre1-r1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
