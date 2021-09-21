using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Tasks_v3._0._0.v3._0._0_Classes
{
    class createTasksFiles
    {
        public void createDirectories()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderTasks = Path.Combine(folder, "Tasks");
            Directory.CreateDirectory(folderTasks);

        }

    }
}
