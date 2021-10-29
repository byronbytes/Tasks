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
        public static int RunBat(string batfile, bool waitexit)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                Process process = new Process();
                process.StartInfo.FileName = path + batfile;
                process.Start();
                if (waitexit == true)
                {
                    process.WaitForExit();
                }
                return 0;
                Debug.Print("RunBat succeeded.");
            }
            catch
            {
                return 1;
                Debug.Print("RunBat failed.");
            }
        }

    }
}
