using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Funcs
{
    class DeleteFiles
    {
        private bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                
                }
                catch (Exception ex)
                {
                

                }

            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                 
                }
                catch (Exception ex)
                {
  
                }

            }

            return true;
        }
    }
}
