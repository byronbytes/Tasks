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
        /* 
              !!!
        THIS FLAGS ANTIVIRUSES!
        NEEDS TO BE FIXED A S A P
             !!!    
        */
        
        public static string UpdateString(string address)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString(address);

            return reply;
        }

        // note for later: it's now possible to make a beta branch.
        // should also add an option for remind me later.
        public static void CheckForUpdates()
        {
            isUpToDate();

            if(isUpToDate() == false)
            {
                MessageBox.Show("There is a new update for Tasks! You can download it at: https://github.com/LiteTools/tag/" + UpdateString("https://pastebin.com/raw/02qyhKX7"));
            }
            else
            {
                MessageBox.Show("There are no updates available.", "Tasks");
            }
        }



        // I have to hard-code this, although I really don't want to, I'll eventually find a way to put it as a Setting string or something.
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
