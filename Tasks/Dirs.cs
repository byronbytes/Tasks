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
        public static string tasksDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\";
        public static string tasksCleanup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary\\";
    }
}
