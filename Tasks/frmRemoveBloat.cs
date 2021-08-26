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
    public partial class frmRemoveBloat : Form
    {
        public frmRemoveBloat()
        {
            InitializeComponent();
        }



        private void frmRemoveBloat_Load(object sender, EventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RunFile.RunBat("/DebloaterScripts/UninstallOneDrive.ps1", true);
                dialogError.Show();
            }
            catch (Exception ex)
            {
                dialogError.Content = "An error has occurred. Error: " + ex;
                dialogError.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RunFile.RunBat("/DebloaterScripts/DisableCortana.ps1", true);
                dialogError.Show();
            }
            catch (Exception ex)
            {
                dialogError.Content = "An error has occurred. Error: " + ex;
                dialogError.Show();
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {

            RunFile.RunBat("/BatFiles/byesolitaire.bat", true);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "BatFiles/removeedge.bat";
                process.Start();

            }
            catch (Exception ex) 
            {
                dialogError.Content = "An error has occurred. Error: " + ex; 
                dialogError.Show();
            }
            
            }




        }
    }


