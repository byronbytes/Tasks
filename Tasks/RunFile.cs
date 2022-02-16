// (c) LiteTools 2021
// All rights reserved under the Apache-2.0 license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tasks
{
    class RunFile
    {
        public static string path2;
        public static int RunBat(string batfile, bool waitexit)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path2 = path;
                Process process = new Process();
                process.StartInfo.FileName = path + batfile;
                process.Start();
                Debug.Print(process.ToString());
                if (waitexit == true)
                {
                    process.WaitForExit();
                }
                return 0;
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.Print(path2);
                return 1;
            }
        }

    }
}
