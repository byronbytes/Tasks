using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Cleanup_Modules
{
    public class Strings
    {
        
         // This class is for strings, any types of strings will be listed here. This will have cross compatibility with v2.1.0 -> 3.0.0
  
        public void AnalyzeStrings()
        {
          // Analyze Issues Found
          public string 1 = "Your computer is currently running on battery power. It is suggested to put it on a charger."; 
          public string 2 = "Your computer is currently running on a limited power mode.";
          public string 3 = "Your computer does not have file compression turned on.";
          public string 4 = "Your computer currently has" + numdrives + "drive(s) currently plugged in.";
          public string 5 = "Your temp folders are taking up " + addfolders +  " of space.";
          public string 6 = "You are currently running " + winver;
        
            
          // Analyze No Issues
          public string perfect = "Your computer has no performance issues!";
          public string finish = "Your computer has finished analyzing.";
          public string completed = "Tasks has optimized your computer.";
            
            
           
        }
        
        
        public void AppTypes() 
        {
            public string Chrome = "Chrome";
            public string ChromeCanary = "Chrome Canary";
            
             
            public string SpotifyApp = "Spotify";
            public string SpotifyWindows = "Spotify (Windows Store Edition)";
            
            
           
            
        }
        
        public void AppExists()
        {
         //if(dir exists Chrome thingy)
            // {
            
            // }
            
            
        }
        
        
           
         
        
        
    }
 }

