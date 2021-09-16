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

// TODO: Cleanup and change the code style
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
                RunFile.RunBat("Scripts/Debloater/UninstallOneDrive.ps1", true);
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
                RunFile.RunBat("Scripts/Debloater/DisableCortana.ps1", true);
            }
            catch (Exception ex)
            {
                dialogError.Content = "An error has occurred. Error: " + ex;
                dialogError.Show();
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                RunFile.RunBat("Scripts/BatFiles/byesolitaire.bat", true);

            }catch (Exception ex)
            {
                dialogError.Content = "An error has occurred. Error: " + ex;
                dialogError.Show();
            }
        

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dialogEdgeNotif.ShowDialog();
                Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/removeedge.bat";
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


