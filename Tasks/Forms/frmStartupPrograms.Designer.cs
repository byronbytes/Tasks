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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartupPrograms));
            StartupProcesses = new System.Windows.Forms.ListView();
            ProcessName = new System.Windows.Forms.ColumnHeader();
            ProcessDescription = new System.Windows.Forms.ColumnHeader();
            ProcessPath = new System.Windows.Forms.ColumnHeader();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            txtFileName = new System.Windows.Forms.Label();
            txtTargetPath = new System.Windows.Forms.Label();
            button4 = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabPage2 = new System.Windows.Forms.TabPage();
            listView1 = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            panel1 = new System.Windows.Forms.Panel();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // StartupProcesses
            // 
            StartupProcesses.BackColor = System.Drawing.Color.FromArgb(18, 26, 35);
            StartupProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            StartupProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ProcessName, ProcessDescription, ProcessPath });
            StartupProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            StartupProcesses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StartupProcesses.ForeColor = System.Drawing.Color.White;
            StartupProcesses.FullRowSelect = true;
            StartupProcesses.HideSelection = false;
            StartupProcesses.Location = new System.Drawing.Point(3, 3);
            StartupProcesses.Name = "StartupProcesses";
            StartupProcesses.Size = new System.Drawing.Size(1042, 649);
            StartupProcesses.TabIndex = 0;
            StartupProcesses.UseCompatibleStateImageBehavior = false;
            StartupProcesses.View = System.Windows.Forms.View.Details;
            // 
            // ProcessName
            // 
            ProcessName.Text = "Name";
            ProcessName.Width = 250;
            // 
            // ProcessDescription
            // 
            ProcessDescription.Text = "Description";
            ProcessDescription.Width = 240;
            // 
            // ProcessPath
            // 
            ProcessPath.Text = "Path";
            ProcessPath.Width = 290;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button1.Location = new System.Drawing.Point(681, 27);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(181, 44);
            button1.TabIndex = 1;
            button1.Text = "Disable";
            toolTip1.SetToolTip(button1, "Disable Program");
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button2.Location = new System.Drawing.Point(868, 27);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(181, 44);
            button2.TabIndex = 2;
            button2.Text = "Add New";
            toolTip1.SetToolTip(button2, "New Program");
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFileName
            // 
            txtFileName.AutoSize = true;
            txtFileName.ForeColor = System.Drawing.Color.Transparent;
            txtFileName.Location = new System.Drawing.Point(171, 34);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new System.Drawing.Size(119, 15);
            txtFileName.TabIndex = 4;
            txtFileName.Text = "PlaceholderFileName";
            txtFileName.Visible = false;
            // 
            // txtTargetPath
            // 
            txtTargetPath.AutoSize = true;
            txtTargetPath.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            txtTargetPath.Location = new System.Drawing.Point(171, 49);
            txtTargetPath.Name = "txtTargetPath";
            txtTargetPath.Size = new System.Drawing.Size(125, 15);
            txtTargetPath.TabIndex = 5;
            txtTargetPath.Text = "PlaceholderTargetPath";
            txtTargetPath.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button4.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button4.Location = new System.Drawing.Point(4, 34);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(161, 37);
            button4.TabIndex = 6;
            button4.Text = "Refresh List";
            toolTip1.SetToolTip(button4, "Refresh List");
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1056, 689);
            tabControl1.TabIndex = 7;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            tabPage1.Controls.Add(StartupProcesses);
            tabPage1.Location = new System.Drawing.Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1048, 655);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Startup Programs";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            tabPage2.Controls.Add(listView1);
            tabPage2.Location = new System.Drawing.Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1058, 610);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Startup Services";
            // 
            // listView1
            // 
            listView1.BackColor = System.Drawing.Color.FromArgb(18, 26, 35);
            listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listView1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listView1.ForeColor = System.Drawing.Color.White;
            listView1.FullRowSelect = true;
            listView1.HideSelection = false;
            listView1.Location = new System.Drawing.Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(1052, 604);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Service Type";
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status";
            columnHeader3.Width = 120;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(18, 26, 45);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(txtFileName);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(txtTargetPath);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 697);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1056, 76);
            panel1.TabIndex = 8;
            // 
            // frmStartupPrograms
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(1056, 773);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "frmStartupPrograms";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Startup Programs";
            Load += frmStartupPrograms_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader ProcessPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label txtFileName;
        private System.Windows.Forms.Label txtTargetPath;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView StartupProcesses;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader ProcessDescription;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView listView1;
    }
}