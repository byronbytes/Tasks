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
using Tasks.Tasks_v3._0._0.v3._0._0_References;

namespace Tasks.Tasks_v3._0._0 {
    public partial class frmNewCleanup : Form {
        public frmNewCleanup() { InitializeComponent(); }

        private void frmNewCleanup_Load(object sender, EventArgs e) {
            // I want to still keep the feature of logging, but it needs to save somewhere, maybe in a settings?
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
            var usertemp = new DirectoryInfo(Path.GetTempPath());
            var downloads = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");


        }
    }
}
