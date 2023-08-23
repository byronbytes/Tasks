/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;


namespace Tasks.Utils
{

    public static class SystemUtils
    {
        public static string bit = "?"; // current bit is undefined, so it's set to a ?

        /// <summary>
        /// Gets the current computer bit. (64 or 32)
        /// </summary>
        public static void ComputerBit()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                bit = "64-bit";
            }
            else
            {
                bit = "32-bit";
            }
        }

        /// <summary>
        /// Gets the operating system it's being run on. Supports XP to 10.
        /// </summary>
        /// <returns></returns>
        public static string getOSInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 5:
                        if (vs.Minor != 0)
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            if (operatingSystem != "")
            {
                operatingSystem = "Windows " + operatingSystem;
            }
            return operatingSystem;
        }


        // This doesn't work, for whatever reason.
        /*
        public static void CreateFiles()
        {
            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + ".url"))
            {
                string app = "";
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
            }
        }
        */
    }



}

