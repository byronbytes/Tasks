using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            taskDialog1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMain Main = new frmMain(); // Initialize form.
            Main.panel1.BackColor = Color.FromArgb(240, 240, 245);
            Main.label1.BackColor = Color.Black;

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
