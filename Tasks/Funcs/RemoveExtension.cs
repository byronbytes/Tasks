using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Tasks
{
    class RemoveExtension
    {
        public static int RemoveExtFirefox(string extpath)
        {

            try
            {

                string aa = extpath;
                File.Delete(aa);
                return 0;
            }
            catch
            {
                return 1;
            }

        }
    }
}
