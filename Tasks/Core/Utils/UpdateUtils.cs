using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Core.Utils
{
    public class UpdateUtils
    {
        public static string CurrentVer = "4.1.0";

        public static void CheckForUpdates()
        {
                // https://pastebin.com/02qyhKX7 Note this
                //Update();
        }
        
        public static bool isUpToDate()
        {
            // Basic code, will update later.
           if(CurrentVer == "v5.0.0-pre1")
           {
               return false;
               
           }
           else
           {
               return true;
           } 
            
        }


    }
}
