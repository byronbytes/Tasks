// planned removal.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace Tasks
{
    class Remove
    {
        //TODO: Merge this within the cleanup function, and remove this, it's unnessesary.
        public static void DeleteExtension(string path, bool isFile)
        {
            if (isFile == true)
            {
                try
                {
                    Thread.Sleep(75);
                    File.Delete(path);
                }
                catch
                {
                    Debug.Print("Error deleting file.");
                }
            }

            if (isFile == false)
            {
                try
                {
                    Thread.Sleep(75);
                    Directory.Delete(path, true);
                }
                catch
                {
                    Debug.Print("Error deleting directory.");
                }
            }
        }
    }
}
