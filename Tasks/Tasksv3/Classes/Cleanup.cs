using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Cleanup_Modules
{
    public class Cleanup
    {
        // Strings for the subdir and cachedirs will be listed on top, and the clean will be able to select the directories, so if chromeSubDir = subdir in the main code,
        // it should clean the chrome cache. This will be more efficient since you wouldn't need to repeat the code 10000 times. Although, after a cleanup it will need
        // to clear the strings so it doesn't mess up and delete other files.
        // This could be fixed by saying if(checkbox is checked then string = appsubdir, appcachedir)

        public string chromeSubDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
        public string[] chromeCacheDir = { "Default\\Cache", "Default\\Code Cache\\", "Default\\GPUCache", "ShaderCache", "Default\\Service Worker\\CacheStorage", "Default\\Service Worker\\ScriptCache", "GrShaderCache\\GPUCache", "\\Default\\File System\\" };
        public string[] windowsTemp = { "C:\\Windows\\Temp", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Temp" }; // might be incorrect.

        
        // Proper Syntax: Clean(chromeSubDir, chromeCacheDir);
        
        public void Clean(string subdir, string cacheDir)
        {
            List<DirectoryInfo> directoryInfos = new List<DirectoryInfo>();

            // WARN: INVALID CODE
            foreach (char subdir1 in cacheDir) { directoryInfos.Add(new DirectoryInfo(subdir + subdir + "\\")); }

            bool isDeleted = true;

            // For each DirectoryInfo inside of the directoryInfos array
            foreach (DirectoryInfo d in directoryInfos)
            {
                try { Delete(d); }
                catch (Exception) {}

                // If DeleteAllFiles returns false, set the isDeleted value to false
                // WARN: ISDELETED IS ALWAYS TRUE
                if (!Delete(d)) isDeleted = false;
            }
        }


        public static bool Delete(DirectoryInfo dirInfo) 
        {
            foreach (var f in dirInfo.GetFiles())
            {
                try
                {
                    f.Delete();
                    Debug.Print("Deleted " + f.FullName);
                }
                catch (Exception ex)
                {
                    Debug.Print("Exception Thrown: " + ex.Message);

                }

            }
            
            foreach (var d in dirInfo.GetFiles())
            {
                try
                {
                    d.Delete();
                    Debug.Print("Deleted Folder " + d.FullName);
                }
                catch (Exception ex)
                {
                    Debug.Print("Exception Thrown: " + ex.Message);
                }
            }
            
            return true;
        }            
    }
}
