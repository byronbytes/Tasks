using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Modules
{
    class GetMemoryUsage
    {
        public static float getMemoryUsage()
        {
            try
            {
                PerformanceCounter memCounter =
                    new PerformanceCounter("Memory", "Available MBytes");
                return memCounter.NextValue();
            }
            catch
            {
                return 0f;
            }
        }
    }
}
