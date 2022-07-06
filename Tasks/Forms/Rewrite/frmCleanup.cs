using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Forms.Rewrite
{
    public partial class frmCleanup : Form
    {
        public frmCleanup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            var windowstemp = new DirectoryInfo("C:\\temp\\"); // placeholder for now
            
            button2.Hide();
            button1.Hide();
            // hide the buttons so it doesnt overlap with the analyze menu

            // Currently analyzing:
            foreach (var file in windowstemp.GetFiles())
            {
                AnalyzeClean.Items.Add(file.Name);
            }

        }

    }
}
