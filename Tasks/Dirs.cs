// (c) LiteTools 2021
// All rights reserved under the Apache-2.0 license.﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    // soon to be deprecated.
    class Dirs
    {
            // Normal Directories:
        public static string firefoxDir;
        public static string chromeDir;
        public static string edgeDir;
        public static string discordDir;
            // Directories that point to the extensions folder:
        public static string firefoxExtDir;
        public static string chromeExtDir;
        public static string edgeExtDir;
        // Tasks Directories:
        public static string tasksDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Tasks\\";
        public static string tasksCleanup = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Tasks\\Cleanup Summary\\";
    }

    // Going to be merging most of the stuff into a new directory method.
    class Directories
    {
        public static string RoamingAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\";
        public static string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Local\\";
        public static string UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string DownloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
        public static string UserTemp = new DirectoryInfo(Environment.GetFolderPath(Path.GetTempPath()));
        public static string WindowsTemp = new DirectoryInfo("C:\\Windows\\Temp");


        public static string TasksDirectory = "";
        public static string TasksLogsDirectory = "";
        public static string TasksLogSuccessful = "Tasks has created the directory successfully.";


        public static void CreateDirectories()
        {
            if(Directory.Exists(tasksDir))
            {
                Debug.Print("No need to create a new directory since it already exists.")
            }
            else
            {
             Directory.CreateDirectory(tasksDir)

            }
    


        }



    }
}
