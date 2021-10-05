using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

// TODO: Cleanup and change the code style
namespace Tasks
{
    class Kill
    {

        public static void Browser(int Browser)
        {

            // Case 1: Kills Chrome
            // Case 2: Kills Firefox
            // Case 3: Kills MS Edge

            // If bool wait = true, it will freeze for 85ms so it has time to taskkill.

            switch (Browser)
            {

                case 1:
                    try
                    {
                        Process.Start("taskkill", "/F /IM chrome.exe");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error.");
                    }

                    break;

                case 2:
                    try
                    {
                        Process.Start("taskkill", "/F /IM firefox.exe");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error.");
                    }

                    break;

                case 3:
                    try
                    {
                        Process.Start("taskkill", "/F /IM msedge.exe");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error.");
                    }
                    break;


            }
        }
    }
}
