using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Forms.Rewrite
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an early feature of Update Checking. A new method will be added soon.", "Tasks");
            Core.Utils.UpdateUtils.CheckForUpdates();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

        }
    }

    /*
           Process.Start(new ProcessStartInfo { FileName = "https://github.com/LiteTools/Tasks/issues/new", UseShellExecute = true });
            Process.Start(new ProcessStartInfo { FileName = "https://litetools.net", UseShellExecute = true });
    */
}
