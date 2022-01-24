using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Core
{
    class SystemInfo
    {
        public static string bit = "undefined";
        
        // Gets the computer's bit (64 or 32)
        public static void ComputerBit()
        {
            if(Environment.Is64BitOperatingSystem)
            {
                bit = "64-bit";
            } else
            {
                bit = "32-bit";
            }

        }


        public static void WindowsUpdate()
        {

        }

        public static void OSVersion()
        {

        }


    }
}
