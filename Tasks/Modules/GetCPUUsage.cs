using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Modules
{
    class GetCPUUsage
    {
        public static async Task<float> getCPUUsage()
        {
            try
            {
                PerformanceCounter cpuCounter =
                    new PerformanceCounter("Processor", "% Processor Time", "_Total");
                _ = cpuCounter.NextValue();
                await Task.Delay(1000);
                return cpuCounter.NextValue();
            }
            catch
            {
                return 0f;
            }
        }
    }
}
