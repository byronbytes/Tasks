using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tasks
{
    class RemoveExt
    {

        public static int RemoveExtFirefox(string extpath) 
        {
            try 
            {
                File.Delete(extpath);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
            public static int RemoveExtChrome(string extpath)
            {
                try
                {
                    File.Delete(extpath);
                    return 0;
                }
                catch
                {
                    return 1;
                }
            }
    }
}
