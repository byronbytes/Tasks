using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Cleanup and change the code style
namespace Tasks.Tasks_v3._0._0
{
    public partial class frmAnalyzePopup : Form
    {
        public frmAnalyzePopup()
        {
            InitializeComponent();
        }

        private void frmAnalyzePopup_Load(object sender, EventArgs e)
        {
            CleanupModules.Cleanup.GetFolderSize(new DirectoryInfo(Path.GetTempPath()));
            label2.Text = Strings.tempfolder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Will improve the settings and change them
        }
    }
}
