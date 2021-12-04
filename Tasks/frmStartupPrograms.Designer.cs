// TODO: Cleanup and change the code style
namespace Tasks
{
    partial class frmStartupPrograms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartupPrograms));
            this.StartupProcesses = new System.Windows.Forms.ListView();
            this.ProcessName = new System.Windows.Forms.ColumnHeader();
            this.ProcessPath = new System.Windows.Forms.ColumnHeader();
            this.ProcessStatus = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFileName = new System.Windows.Forms.Label();
            this.txtTargetPath = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartupProcesses
            // 
            this.StartupProcesses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.StartupProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartupProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcessName,
            this.ProcessPath,
            this.ProcessStatus});
            this.StartupProcesses.ContextMenuStrip = this.contextMenuStrip1;
            this.StartupProcesses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartupProcesses.ForeColor = System.Drawing.Color.White;
            this.StartupProcesses.FullRowSelect = true;
            this.StartupProcesses.HideSelection = false;
            this.StartupProcesses.Location = new System.Drawing.Point(6, 3);
            this.StartupProcesses.Name = "StartupProcesses";
            this.StartupProcesses.Size = new System.Drawing.Size(974, 565);
            this.StartupProcesses.TabIndex = 0;
            this.StartupProcesses.UseCompatibleStateImageBehavior = false;
            this.StartupProcesses.View = System.Windows.Forms.View.Details;
            this.StartupProcesses.SelectedIndexChanged += new System.EventHandler(this.StartupProcesses_SelectedIndexChanged);
            // 
            // ProcessName
            // 
            this.ProcessName.Text = "Name";
            this.ProcessName.Width = 250;
            // 
            // ProcessPath
            // 
            this.ProcessPath.Text = "Path";
            this.ProcessPath.Width = 300;
            // 
            // ProcessStatus
            // 
            this.ProcessStatus.Text = "Status";
            this.ProcessStatus.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.moreInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moreInfoToolStripMenuItem
            // 
            this.moreInfoToolStripMenuItem.Name = "moreInfoToolStripMenuItem";
            this.moreInfoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.moreInfoToolStripMenuItem.Text = "More Info";
            this.moreInfoToolStripMenuItem.Click += new System.EventHandler(this.moreInfoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(706, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Remove";
            this.toolTip1.SetToolTip(this.button1, "Disable Program");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.SeaGreen;
            this.button2.Location = new System.Drawing.Point(859, 634);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add New";
            this.toolTip1.SetToolTip(this.button2, "New Program");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(12, 634);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "View Startup Folder";
            this.toolTip1.SetToolTip(this.button3, "View Startup Folder");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoSize = true;
            this.txtFileName.ForeColor = System.Drawing.Color.Transparent;
            this.txtFileName.Location = new System.Drawing.Point(371, 646);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(119, 15);
            this.txtFileName.TabIndex = 4;
            this.txtFileName.Text = "PlaceholderFileName";
            this.txtFileName.Visible = false;
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.AutoSize = true;
            this.txtTargetPath.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTargetPath.Location = new System.Drawing.Point(365, 661);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(125, 15);
            this.txtTargetPath.TabIndex = 5;
            this.txtTargetPath.Text = "PlaceholderTargetPath";
            this.txtTargetPath.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(179, 634);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "Refresh List";
            this.toolTip1.SetToolTip(this.button4, "Refresh List");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(995, 605);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.tabPage1.Controls.Add(this.StartupProcesses);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(987, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Startup Programs";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(987, 565);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Startup Services";
            // 
            // frmStartupPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1008, 683);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtTargetPath);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStartupPrograms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Startup Programs";
            this.Load += new System.EventHandler(this.frmStartupPrograms_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader ProcessPath;
        private System.Windows.Forms.ColumnHeader ProcessStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label txtFileName;
        private System.Windows.Forms.Label txtTargetPath;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreInfoToolStripMenuItem;
        private System.Windows.Forms.ListView StartupProcesses;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}