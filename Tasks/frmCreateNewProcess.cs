// (c) LiteTools 2021
// All rights reserved under the Apache-2.0 license.

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
    public partial class frmCreateNewProcess : Form { public frmCreateNewProcess(){ InitializeComponent(); CheckTheme(); }
                                                     
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
                    catch(Exception ex)
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
             Process.Start(textBox1.Text);
           } 
            catch(Exception ex)
            {
              MessageBox.Show("An error has occurred. " + ex.Message);
            }
        }
                                                     
          public void CheckTheme()
          {
              if (Properties.Settings.Default.Theme == "light")
             {
              this.BackColor = Color.White;
              panel1.BackColor = Color.Gray;
              textBox1.BackColor = Color.Gray;
              textBox1.ForeColor = Color.Black;
             }
          }
    }
}
