/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Core.Utils
{
    public static class BackgroundUtils
    {


        /*
         Plans
        - If more than a set amount of storage takes up temp, send a notification.
        - Alert when there's a new update
        - Ability to hide Tasks to tray
        - 
        */
       

        public static void UpdateAlert()
        {
            frmMain Main = new frmMain();
            Main.notifyIcon1.BalloonTipTitle = "Tasks";
            Main.notifyIcon1.BalloonTipText = "Tasks has an update!";
        }

        // should have a variable that automatically quick clean in the background after TBD time.
        public static void StorageAlert()
        {
              frmMain Main = new frmMain();
            // will add multiple notifyicons
        }
       

    }
}
