using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// everything is over-noted, don't mind it.
namespace Tasks.Core.Utils
{
    public class CleanupUtils
    {
        
        public static int filesDeleted;
        
        // Deletes all files in a directory.
        // Will also add a string list for all of the file names, that's pretty easy.
        public static bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles()) // could optimize?
            {
                try
                {
                    file.Delete();
                    filesDeleted++;
                    //   Debug.Log(file.FullName);
                }
                catch (Exception ex)
                {
                    //   Debug.Log(ex.Message);
                }

            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    filesDeleted++;
                    // Debug.Log(dir.FullName);
                }
                catch (Exception ex)
                {
                    //   Debug.Log(ex.Message);
                }

            }

            return true;
        }

        public static void AnalyzeAllFiles(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles()) // could optimize?
            {
                try
                {
                    Debug.Print("File: " + file.Name);
                }
                catch (Exception ex)
                {
                    //   Debug.Log(ex.Message);
                }
            }
        }

        // Really only used for modifying certain things that may need a restart.
        // Might consider making a library for classes like this so it's easier to use these.
        public static void RestartExplorer()
        {
            Process.Start("taskkill", "/f /im explorer.exe");
            Process.Start("explorer.exe");
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
            if (CanLogCleanup() == true)
            {
                // bad code, will fix later.
                File.WriteAllLines(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", CleanupForm.CleanupLogsLBox.Items.Cast<string>().ToArray());
            }
        }
       
       // Deletes directory and recreates it (Usually meant for debugging / settings) 
        public static void DeleteTasksFolder()
        {
            Directory.Delete(Dirs.tasksDir);
            Directory.CreateDirectory(Dirs.tasksDir);
        }
        
        
    }
    public static class CleanupDirectories
    {

        public static string[] ChromeDirectories = {"a", "ab" };

    }
}


