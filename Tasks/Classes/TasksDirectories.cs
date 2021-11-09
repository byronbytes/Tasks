using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Classes
{
    public class TasksDirectories
    {

       public static string TasksDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks";
        public static string TasksCleanup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary";
        public  static string TasksTempStartup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\StartupTemp";

    }
}
