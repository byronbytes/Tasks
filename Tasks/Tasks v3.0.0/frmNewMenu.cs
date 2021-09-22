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
    public partial class frmNewMenu : Form
    {
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
                panel7.Visible = true;
            }
            if (PanelClicked == "TaskManager")
            {
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = true;
            }
            if (PanelClicked == "Settings")
            {
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = true;
                panel7.Visible = true;
            }
        }

        private void DashboardSendToBack(bool isUpdated)
        {

            if (isUpdated == true)
            {
                label2.SendToBack();
                groupBox1.SendToBack();
                label3.SendToBack();
                button1.SendToBack();

            }

            if (isUpdated == false)
            {
                label2.BringToFront();
                groupBox1.BringToFront();
                label3.BringToFront();
                button1.BringToFront();
            }
        }

        private Form _currentForm;
        private void ShowForm(Form newForm)
        {
            // credit to Anu6is
            if (_currentForm != null) _currentForm.Hide();

            newForm.TopLevel = false;
            newForm.AutoScroll = true;
            newForm.FormBorderStyle = FormBorderStyle.None;
            panel7.Controls.Add(newForm);
            newForm.Show();

            _currentForm = newForm;
        }
    
    

        private void pictureBox1_Click(object sender, EventArgs e) 
        {
            SelectedButton("Cleanup");
            DashboardSendToBack(true);
            ShowForm(new frmNewCleanup());

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectedButton("Startup");
            DashboardSendToBack(true);
            ShowForm(new frmNewStartupPrograms());

        }

        private void frmNewMenu_Load(object sender, EventArgs e)
        {
            TasksLibCore.TestDebug.Debug();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DashboardSendToBack(true);
            SelectedButton("Settings");
            ShowForm(new frmSettings());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
