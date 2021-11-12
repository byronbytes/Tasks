using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks {
    public partial class frmMain : Form {
        public frmMain() { Directory.CreateDirectory(Classes.TasksDirectories.TasksCleanup); InitializeComponent(); }
        private void frmMain_Load(object sender, EventArgs e) {}
        private void button1_Click(object sender, EventArgs e) { new frmCleanup().Show(); }
        private void button3_Click(object sender, EventArgs e) { new frmStartupPrograms().Show(); }
        private void button4_Click(object sender, EventArgs e) { new frmTaskManager().Show(); }
        private void button6_Click(object sender, EventArgs e) { new frmAbout().Show(); }
        private void label1_Click(object sender, EventArgs e) {}
        private void label5_Click(object sender, EventArgs e) {}
    }
}
