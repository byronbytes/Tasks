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

        private void HidePanel(string PanelClicked)
        {

            if (PanelClicked == "Cleanup")
            {
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
            }
            if (PanelClicked == "Startup")
            {
                panel2.Visible = false;
                panel3.Visible = true;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
            }

            if (PanelClicked == "TaskManager")
            {
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
                panel5.Visible = false;
                panel6.Visible = false;
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            HidePanel("Cleanup");
                
            frmNewCleanup Cleanup = new frmNewCleanup();
            Cleanup.TopLevel = false;
            Cleanup.AutoScroll = true;
            panel7.Controls.Add(Cleanup);
            Cleanup.FormBorderStyle = FormBorderStyle.None;
            Cleanup.Show();

            panel2.Visible = true;
            panel2.Visible = true;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HidePanel("Startup");
        }

        private void frmNewMenu_Load(object sender, EventArgs e)
        {
            lblLastRegistryBackup.Text = "Last Registry Backup: " + "Unknown.";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
