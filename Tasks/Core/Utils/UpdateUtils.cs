using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        public static void CheckForUpdates()
        {
            isUpToDate();

            if(isUpToDate() == false)
            {
                MessageBox.Show("There is a new update for Tasks! You can download it at: https://github.com/LiteTools/tag/" + UpdateString("https://pastebin.com/raw/02qyhKX7"));
            }
            else
            {
                MessageBox.Show("There are no updates available.");
            }
        }


        public static bool isUpToDate()
        {
            if (UpdateString("https://pastebin.com/raw/02qyhKX7") == "v5.0.0-pre1")
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
