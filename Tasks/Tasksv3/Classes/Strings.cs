using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Strings
    {

        // This class is for strings, any types of strings will be listed here. 


        // Core Variables / preload
        public static long tempfolder = 1;

        // Analyze Strings
        public static string batterypower = "Your computer is currently running on battery power. It is suggested to put it on a charger.";
        public static string limitedpower = "Your computer is currently running on a limited power mode.";
        public static string filecompression = "Your computer does not have file compression turned on.";
        public static string drives = "Your computer currently has" + "drive(s) currently plugged in.";

        public static string tempsize = "Your temp folders are taking up " + Strings.tempfolder.ToString() + "B of space.";

        // Analyze No Issues
        public static string perfect = "Your computer has no performance issues!";
        public static string finish = "Your computer has finished analyzing.";
        public static string completed = "Tasks has optimized your computer.";

     


        //stupid vs errors if i put a public string in a class, so i guess no class.
           
    

        public void DetectApplications()
        {

        }
    }


}



    








