using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class frmCreateNewProcess : Form
    {
        public frmCreateNewProcess()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(textBox1.Text);
        }
    }
}
