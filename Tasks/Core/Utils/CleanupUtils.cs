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
         public static bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles())
            {
                try
                {
                // Deletes all files in directory.
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
                // Deletes all directories in a directory.
                    dir.Delete(true);
                //    Debug.Log(LogSuccess + dir.FullName);
                }
                catch (Exception ex)
                {
               //   Debug.Log(LogError + ex.Message);
                }

            }

            return true; // why does it return true, could this be expanded on?
        }



    }
}
