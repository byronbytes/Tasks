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
