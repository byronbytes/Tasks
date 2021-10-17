using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Tasks_v3._0._0
{
    public partial class frmSettings : Form
    {

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            FileInfo[] files = new DirectoryInfo(@Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary").GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderTasks = Path.Combine(folder, "Tasks");
            string folderTasksCS = Path.Combine(folderTasks, "Cleanup Summary");
            Process.Start("explorer.exe", @folderTasksCS);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderTasks = Path.Combine(folder, "Tasks");
            string folderTasksCS = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary";

            foreach (string file in Directory.EnumerateDirectories(folderTasksCS))
            {
                try
                {
                    File.Delete(file);

                } 
                catch(Exception ex)
                {
                    MessageBox.Show(Ex.GetType().FullName + "caught: " + ex.Message);
                }

                RefreshCleanupLogs();
  
            }
        }

        public void RefreshCleanupLogs()
        {
            listBox1.Items.Clear();

            DirectoryInfo di = new DirectoryInfo(@Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tasks\\Cleanup Summary");
            FileInfo[] files = di.GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file.Name);
            }


        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
