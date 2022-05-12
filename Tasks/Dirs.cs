/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    class Dirs
    {
            // Normal Directories:
        public static string firefoxDir;
        public static string chromeDir;
        public static string edgeDir;
        public static string discordDir;
            // Directories that point to the extensions folder:
        public static string firefoxExtDir;
        public static string chromeExtDir;
        public static string edgeExtDir;
             // Tasks Directories:
        public static string tasksDir = "C:\\Program Files\\Tasks\\";
        public static string tasksCleanup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Tasks\\Cleanup Summary\\";
    }

    
    // Going to be merging most of the stuff into a new directory method.
    class Directories
    {
        public static string RoamingAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\";
        public static string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\";
        public static string UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string DownloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
        public static string WindowsFolderTemp = "C:\\Windows\\Temp";
        public static string ProgramFiles = "C:\\Program Files";
        public static string ProgramFiles86 = "C:\\Program Files (x86)\\";
        public static string StartupFolder = ""; //Environment exists will add soon
        public static string tasksDir = "C:\\Program Files\\Tasks\\";
        // Directories for applications
        public static string ChromeDir = "";
        public static string FirefoxDir = "";
        public static string EdgeDir = "";
        public static string DiscordDir = "";
        public static string VLCDir = "";
        public static string SpotifyDir1 = "";
        public static string ChromeExtDir = "";
        public static string FirefoxExtDir = "";
        public static string EdgeExtDir = "";
  
    }
}
