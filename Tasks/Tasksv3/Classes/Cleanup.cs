using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Cleanup_Modules
{
    public class Cleanup
    {
        // TODO: I have no idea

        
     public string chromeSubDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
         public string[] chromeCacheDir = { "Default\\Cache", "Default\\Code Cache\\", "Default\\GPUCache", "ShaderCache", "Default\\Service Worker\\CacheStorage", "Default\\Service Worker\\ScriptCache", "GrShaderCache\\GPUCache", "\\Default\\File System\\" };
    
        
        
        
        public Dictionary<string, string> Folders
        {
            get; set;
        }

        public void Clean(string subdir, cacheDir) 
        {
             
       // Strings for the subdir and cachedirs will be listed on top, and the clean will be able to select the directories, so if chromeSubDir = subdir in the main code,
         // it should clean the chrome cache. This will be more efficient since you wouldn't need to repeat the code 10000 times. Although, after a cleanup it will need
            // to clear the strings so it doesn't mess up and delete other files.
            // This could be fixed by saying if(checkbox is checked then string = appsubdir, appcachedir)
            List<DirectoryInfo> directoryInfos = new List<DirectoryInfo>();

                    foreach (string subdir in cacheDir)
                    {
                        // Make a new DirectoryInfo with the info of that subdirectory and then add it into the directoryInfos array
                        directoryInfos.Add(new DirectoryInfo(mainSubdirectory + subdir + "\\"));
                    }

                    bool isDeleted = true;
                    // For each DirectoryInfo inside of the directoryInfos array
                    foreach (DirectoryInfo d in directoryInfos)
                    {
                        try
                        {
                            DeleteAllFiles(d);
                        }
                        catch (Exception ex)
                        {
                          
                        }

                        // If DeleteAllFiles returns false, set the isDeleted value to false
                        if (!DeleteAllFiles(d))
                            isDeleted = false;
                    }

                    if (isDeleted)
                     
                }
                catch (Exception)
                {

                }
            }

}
      



    }
    }

