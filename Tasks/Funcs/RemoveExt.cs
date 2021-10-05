using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// TODO: Cleanup and change the code style
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
                 string path = extpath;
                    Directory.Delete(path, true);
                    return 0;
             
            }

        public static void RemoveExtension(string path, int Browser)
        {
            // Case 1: Firefox
            // Case 2: Chrome

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

                case 2:
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
