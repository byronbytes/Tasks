/*
    (c) LiteTools 2022 (https://github.com/LiteTools)
    All rights reserved under the GNU General Public License v3.0.
*/
﻿

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class frmSettingsHolder : Form
    {
        public frmSettingsHolder()
        {
            InitializeComponent();
            openChildForm(new frmSettings());
            CheckTheme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Rewrite.frmAbout());
        }
        
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSettings());
        }

        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "light")
            {

                panel1.BackColor = Color.FromArgb(250, 250, 250);
                panel2.BackColor = Color.FromArgb(250, 250, 250);
                button1.BackColor = Color.FromArgb(200, 200, 200);
                button2.BackColor = Color.FromArgb(200, 200, 200);
                button1.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
            }  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
