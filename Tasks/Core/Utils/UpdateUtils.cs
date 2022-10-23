/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Tasks.Core.Utils
{
    public class UpdateUtils
    {

        public static string UpdateString()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://pastebin.com/raw/02qyhKX7");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();

            return content;
        }

        // should also add an option for remind me later.
        public static void CheckForUpdates()
        {
           try
           {
            if(isUpToDate() == false)
            {
                MessageBox.Show("There is a new update available! You can download it at: https://github.com/LiteTools/tag/" + UpdateString(), "Tasks");
            }
            else
            {
                MessageBox.Show("There are no new updates.", "Tasks");
            }
           }
           catch
           {
                MessageBox.Show("Unable to check for updates.", "Tasks");
           }
        }

        public static bool isUpToDate()
        {
            if (UpdateString() == "v5.0.0-pre2")
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
