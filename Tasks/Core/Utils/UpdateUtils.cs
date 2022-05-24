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
            // Calls the update check
             if(isUpToDate == true)
            {
                Update();
            }
            else
            {
                MessageBox.Show("You are currently up to date.")
            }
            
        }

        public static void Update()
        {
            bool Updated;
            // Calls the update function
            
            if(isUpToDate == true)
            {
                // download, then update
            }
            
        }
        
        public static bool isUpToDate()
        {
            // Basic code, will update later.
           if(CurrentVer == "v4.2.0")
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
