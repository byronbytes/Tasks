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

// TODO: Cleanup and change the code style
namespace Tasks
{
    public partial class frmAnalyze : Form
    {
        public frmAnalyze() { InitializeComponent(); }
        private void panel1_Paint(object sender, PaintEventArgs e) {}
        private void frmAnalyze_Load(object sender, EventArgs e) 
        { 
            RunAnalytics(false); 
        }
     
        public void RunAnalytics(bool completed)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            // will look for setttings, etc, drive space, if the drive is compressed / indexed, settings for windows and more.
            PowerLineStatus status = System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus;

        if(status == PowerLineStatus.Offline) 
        {
                Debug.Print("Currently not on battery.");
        }
     }
    }
}
