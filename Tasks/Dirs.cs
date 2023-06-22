/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/

using System;

namespace Tasks
{
    class Dirs
    {
        public static string firefoxDir;
        public static string chromeDir;
        public static string edgeDir;
        public static string discordDir;
        // ExtDir = Directories that lead to the extensions folder.
        public static string firefoxExtDir;
        public static string chromeExtDir;
        public static string edgeExtDir;
        // Etc folders, meant for development on Tasks.
        public static string tasksDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Tasks\\";
        public static string tasksCleanup = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Tasks\\Cleanup Summary\\";
        public static string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    }
}
