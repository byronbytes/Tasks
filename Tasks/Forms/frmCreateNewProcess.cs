/*
   Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/


using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Tasks
{
    public partial class frmCreateNewProcess : Form
    {
        public frmCreateNewProcess() { InitializeComponent(); CheckTheme(); }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Executables|*.exe" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string task = ofd.FileName.ToString();
                        Process.Start(task);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred. " + ex.Message);
                    }
                }
                else { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                if (!Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
                {
                    throw new Exception("Special characters are not allowed for input.");
                }
                Process.Start(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred. " + ex.Message);
            }
        }

        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "light")
            {
                this.BackColor = Color.White;
                panel1.BackColor = Color.WhiteSmoke;
                textBox1.BackColor = Color.WhiteSmoke;
                textBox1.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
        }
    }
}
