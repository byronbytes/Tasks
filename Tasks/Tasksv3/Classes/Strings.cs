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

        // This class is for strings, any types of strings will be listed here. This will have cross compatibility with v2.1.0 -> 3.0.0

        public void AnalyzeStrings()
        {
            string batterypower = "Your computer is currently running on battery power. It is suggested to put it on a charger.";
            string limitedpower = "Your computer is currently running on a limited power mode.";
            string filecompression = "Your computer does not have file compression turned on.";
            string drives = "Your computer currently has" + "drive(s) currently plugged in.";
            string tempsize = "Your temp folders are taking up " + tempfolder + " of space.";

            // Analyze No Issues
            string perfect = "Your computer has no performance issues!";
            string finish = "Your computer has finished analyzing.";
            string completed = "Tasks has optimized your computer.";
        }


        //stupid vs errors if i put a public string in a class, so i guess no class.
            public static long tempfolder = 1;
    

        public void DetectApplications()
        {

        }
    }


}



    








