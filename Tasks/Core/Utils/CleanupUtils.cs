using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Core.Utils
{
    public class CleanupUtils
    {
        // Deletes all files in a directory.
        // Will also add a string list for all of the file names, that's pretty easy.
         public static bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles()) // could optimize?
            {
                try
                {
                    file.Delete();
                 //   Debug.Log(LogSuccess + file.FullName);
                }
                catch (Exception ex)
                {
                 //   Debug.Log(LogError + ex.Message);
                }

            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    // Debug.Log(LogSuccess + dir.FullName);
                }
                catch (Exception ex)
                {
                    //   Debug.Log(LogError + ex.Message);
                }

            }

            return true; // why does it return true, could this be expanded on? 
        }
    }
    // Really only used for modifying certain things that may need a restart.
    // Might concider making a library for classes like this so it's easier to use these.
    public static void RestartExplorer()
    {
        Process.Start("taskkill", "/f /im explorer.exe"); // Since Tasks runs as admin it's auto elevated.
        Process.Start("explorer.exe");
    }
    
    public static bool CanLogCleanup() // probably won't work lol
    {
        if(Directory.Exists(Dirs.TasksDir)) //half pseudo-code
        {
            return true; // Can be used for Settings
        }
        else
        {
            return false;
        }
    }
    
}
