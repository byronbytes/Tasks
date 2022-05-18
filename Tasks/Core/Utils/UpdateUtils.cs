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

        public static bool CheckForUpdates()
        {
            // Calls the update check
            
            // Here's a basic check for updating, if it even gets added soon.
            if(CurrentVer == "4.2.0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Update()
        {
            bool Updated;
            // Calls the update function
            
        }



    }
}
