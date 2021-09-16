using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Tasks_v3._0._0 {
    public partial class frmNewMenu : Form {
        public frmNewMenu() { InitializeComponent(); }

        private void pictureBox1_Click(object sender, EventArgs e) {
            frmNewCleanup Cleanup = new frmNewCleanup();
            Cleanup.TopLevel = false;
            Cleanup.AutoScroll = true;
            panel7.Controls.Add(Cleanup);
            Cleanup.FormBorderStyle = FormBorderStyle.None;
            Cleanup.Show();
        }
    }
}
