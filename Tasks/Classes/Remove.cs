// (c) LiteTools
// All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tasks
{
    class Remove
    {
    
        public static void DeleteExtension(string path, int Browser)
        {
            // Case 1: File based extensions (Firefox)
            // Case 2: Directory based extensions (Chrome + Edge)
            switch (Browser)
            {
                case 1:
                    
                    try
                    {
                     File.Delete(path);
                    }
                    catch
                    { }
                    break;
                    
                case 2:
                    
                    try 
                    {
                     Directory.Delete(path, true);
                    }
                    catch
                    { }
                    break;
            }
        }
        
    }
}
