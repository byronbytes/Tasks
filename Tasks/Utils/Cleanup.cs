﻿/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Tasks.Utils
{
    public class Cleanup
    {
        public static int filesDeleted;


        // Will also add a string list for all of the file names, that's pretty easy.
        /// <summary>
        /// Deletes all files in a directory.
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        public static bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles()) // could optimize?
                try
                {
                    file.Delete();
                    filesDeleted++;
                }
                catch (Exception)
                {

                }
            foreach (var dir in directoryInfo.GetDirectories())
                try
                {
                    dir.Delete(true);
                    filesDeleted++;
                }
                catch (Exception)
                {

                }

            return true;
        }

        public static void AnalyzeAllFiles(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
                try
                {
                    Debug.Print("File: " + file.Name);
                }
                catch (Exception)
                {

                }
        }

        public static bool CanLogCleanup()
        {
            if (Directory.Exists(Dirs.tasksDir) && Properties.Settings.Default.EnableCleanupLogs == true)
            {
                return true;
            }

            return false;
        }

        [DllImport("Shell32.dll")]
        public static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);

        [Flags]
        public enum RecycleFlag : int
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, string path);

        public enum ShellAddToRecentDocsFlags
        {
            Pidl = 0x001,
            Path = 0x002,
            PathW = 0x003
        }

    }
}