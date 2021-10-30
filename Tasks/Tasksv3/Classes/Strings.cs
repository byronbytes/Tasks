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


        // Other Variables
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
        public static string issues = "Your computer has a few performance issues.";

     
       // Application Detection
       public static string spotify = "Tasks has detected Spotify on your computer.";
       public static string spotifywinstore = "Tasks has detected Spotify (Windows Store Edition) on your computer.";
       public static string discord = "Tasks has detected Discord on your computer.";
       
        // Language (Coming Soon.)
        public static string English = "English";
        public static string French = "Français";
        public static string Polish = "Polskie";
        public static string Korean = "한국인";
        
    }
}



    








