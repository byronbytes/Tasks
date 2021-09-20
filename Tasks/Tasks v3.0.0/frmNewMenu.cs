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

        private void SelectedButton(string PanelClicked)
        {
            if (PanelClicked == "Cleanup")
            {
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = true;
            }
            if (PanelClicked == "Startup")
            {
                panel2.Visible = false;
                panel3.Visible = true;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            if (PanelClicked == "TaskManager")
            {
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            if (PanelClicked == "Other")
            {
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = true;
                panel7.Visible = false;
            }
        }

        private void DashboardSendToBack(bool isUpdated)
        {

            if(isUpdated == true)
            {
                label2.SendToBack();
                groupBox1.SendToBack();
                lblLastRegistryBackup.SendToBack();
                label3.SendToBack();
                button1.SendToBack();
              
            }

            if(isUpdated == false)
            {
                label2.BringToFront();
                groupBox1.BringToFront();
                lblLastRegistryBackup.BringToFront();
                label3.BringToFront();
                button1.BringToFront();
            }
        }

        private void ShowForm(string FormSelected)
        {
            // Initialize what we're working with..
            frmNewCleanup Cleanup = new frmNewCleanup();
            frmNewStartupPrograms Startup = new frmNewStartupPrograms();


            if(FormSelected == "Cleanup")
            {
                // Before we show the form, we must close any other forms that could be overlapping.
                Startup.Hide();
                // Get all the form details and setup for showing.
                Cleanup.TopLevel = false;
                Cleanup.AutoScroll = true;
                panel7.Controls.Add(Cleanup);
                Cleanup.FormBorderStyle = FormBorderStyle.None;
                Cleanup.Show();
            }

            if (FormSelected == "Startup")
            {
                // Before we show the form, we must close any other forms that could be overlapping.
                Cleanup.Hide();
                // Get all the form details and setup for showing.
                Startup.TopLevel = false;
                Startup.AutoScroll = true;
                panel7.Controls.Add(Startup);
                Startup.FormBorderStyle = FormBorderStyle.None;
                Startup.Show();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e) 
        {
            SelectedButton("Cleanup");
            DashboardSendToBack(true);
            ShowForm("Cleanup");

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectedButton("Startup");
            DashboardSendToBack(true);
            ShowForm("Startup");

        }

        private void frmNewMenu_Load(object sender, EventArgs e)
        {
            lblLastRegistryBackup.Text = "Last Registry Backup: " + "Unknown.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DashboardSendToBack(false);
            SelectedButton("Other");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
