// (c) LiteTools 2021
// All rights reserved under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Tasks
{
    class Remove
    {
        public static void DeleteExtension(string path, int browser)
        {
            // This class is meant for deleting extensions.
            
            // Case 1: File based extensions (Firefox)
            // Case 2: Directory based extensions (Chrome + Edge)
            switch (browser)
            {
                case 1:
                    
                    try
                    {
                     File.Delete(path);
                    }
                    catch
                    {
                        Debug.Print("Error deleting file.");
                    }
                    break;
                    
                case 2:
                 
                    try 
                    {
                     Directory.Delete(path, true);
                    }
                    catch
                    {
                        Debug.Print("Error deleting directory.");
                    }
                    break;
            }
        }
        
        
      public static void DeleteCleanupLogs()
      {
          //This class deletes the cleanup logs.
          
      }
      
        public static void KillBrowser(int browser)
        {

            // Case 1: Kills Chrome
            // Case 2: Kills Firefox
            // Case 3: Kills MS Edge

            switch (browser)
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
