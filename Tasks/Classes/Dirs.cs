using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string tasksDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Tasks\\";
        public static string tasksCleanup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Tasks\\Cleanup Summary\\";
    }
}
