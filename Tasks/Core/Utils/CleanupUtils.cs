using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        // Really only used for modifying certain things that may need a restart.
        // Might consider making a library for classes like this so it's easier to use these.
        public static void RestartExplorer()
        {
            Process.Start("taskkill", "/f /im explorer.exe"); // Since Tasks runs as admin it's auto elevated.
            Process.Start("explorer.exe");
        }
     
        // Then again, this still might not be found handy, but it's good to keep utils like this somewhere.
        // Might also add an int to adjust the timer, but why would I need that?
        public static void RebootComputer(bool instant)
        {
            if(instant == true)
            {
               Process.Start("shutdown.exe", "-r"); 
            }
            else
            {
               Process.Start("shutdown.exe", "-r -t 15");
            }
        }
        
        
        public static bool CanLogCleanup() // didnt work maybe it'll work this time
        {
            if (Directory.Exists(Dirs.tasksDir))
            {
               return true; 
            }
                return false;
        }
        
        
        public static void SaveCleanupLog()
        {
            CanLogCleanup();
            frmCleanup CleanupForm = new frmCleanup();
            int t = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            if (CanLogCleanup == true)
            {
                // bad code, will fix later.
                File.WriteAllLines(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", CleanupForm.CleanupLogsLBox.Items.Cast<string>().ToArray());
            }
        }
        
        // Probably going to make it a re-create method, but I'm not on my PC to get the code needed.
        public static void DeleteTasksFolder()
        {
            Directory.Delete(Dirs.tasksDir); // probably wrong
        }


    }
}
