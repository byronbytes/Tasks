using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tasks
{
    class RemoveExt
    {

        public static int RemoveExtFirefox(string extpath) // Firefox uses a removal method with files and not directories.
        {
            try
            {
                File.Delete(extpath);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
            public static int RemoveExtChrome(string extpath)
            {
                    Directory.Delete(extpath, true);
                    return 0;
             
            }

        public static void RemoveExtension(string path, int Browser)
        {
            // Case 1: Firefox
            // Case 2: Chrome + Edge
    
            switch (Browser)
            {
                case 1:
                    try
                    {
                     File.Delete(path);
                    }
                    catch
                    {
                        // ex
                    }
                    break;

                case 2: // Chrome will say that the extension is corrupted, and will try to repair it, we will try to mitigate this by clearing the extension history.
                    try 
                    {
                    Directory.Delete(path, true);
                    }
                    catch
                    {
                        // ex
                    }
                    break;
            

            }
        }
    }
}
