/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/

// No clue what to put here yet, probably just some starter details that will help for future updates.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Core
{
    class StartupPrograms
    {
     
        public static bool Disabled;
        public static string StartupFolder =  Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";
        public static string HKLMStartup = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        
    
    }
}
