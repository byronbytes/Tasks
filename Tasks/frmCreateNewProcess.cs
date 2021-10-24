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
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All|*.*" })
            {
                // If statement because if you closed it would throw an exception
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string task = ofd.FileName.ToString();
                        Process.Start(task);
                    }
                    catch
                    {
                        // An Error.
                    }
                   
                }
                else
                {
                    // Do Nothing.
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(textBox1.Text);
        }
    }
}
