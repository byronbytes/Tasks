using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Convert
    {
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f / 1024f);
        }  
    }
}
