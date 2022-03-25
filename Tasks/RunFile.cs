/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/
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
        // Developer Note: This feature will be deprecated in the future, I'm not on my main computer but once I fix most of the bugs
        // with just running it, i'll remove this feature.
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

    }
}
