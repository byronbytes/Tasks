using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Core
{
    class MathUtils
    {
        public static long DirSize(DirectoryInfo d)
        {

            long size = 0;
            // Add file sizes.
            try
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
                return size;
            }
            catch
            {
                // Needs a more advanced catch method.
                return size;
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            double ConvertedByte = Math.Round(bytes / 1024f / 1024f, 2);
            return (ConvertedByte);
        }



    }
}
