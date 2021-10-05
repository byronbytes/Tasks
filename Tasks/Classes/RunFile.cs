using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

// TODO: Cleanup and change the code style
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
            }
            catch
            {
                return 1;
            }
        }

        public static void RunProcess(string processname, bool shellexec)
        {
            // this will replace the use for Process.Start
            Process.Start(new ProcessStartInfo { FileName = processname, UseShellExecute = true });
            if (shellexec == false)
            {

            }

        }
    }
}
