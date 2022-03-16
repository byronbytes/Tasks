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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAbout());
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
