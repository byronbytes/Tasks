using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class CleanRecentFiles
    {
        public static class CleanRecents
        {
            public enum ShellAddToRecentDocsFlags
            {
                Pidl = 0x001,
                Path = 0x002,
                PathW = 0x003
            }

            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            private static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, string path);

            public static void ClearAll()
            {
                SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, null);
            }
        }
    }
}
