using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tasks
{
    class Taskkill
    {
        // Class for taskkilling certain things.
        public static void Browser(int Browser)
        {

            // Case 1: Kills Chrome
            // Case 2: Kills Firefox
            // Case 3: Kills MS Edge

            switch (Browser)
            {

                case 1:
                    try
                    {
                        Process.Start("taskkill", "/f /im chrome.exe");
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Could not kill Chrome.");
                    }

                    break;

                case 2:
                    try
                    {
                        Process.Start("taskkill", "/f /im firefox.exe");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could not kill Firefox.");
                    }

                    break;

                case 3:
                    try
                    {
                        Process.Start("taskkill", "/f /im msedge.exe");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could not kill Edge.");
                    }
                    break;


            }
        }

    }


        
}
