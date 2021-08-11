
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartupPrograms));
            this.StartupProcesses = new System.Windows.Forms.ListView();
            this.ProcessName = new System.Windows.Forms.ColumnHeader();
            this.ProcessPath = new System.Windows.Forms.ColumnHeader();
            this.ProcessStatus = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartupProcesses
            // 
            this.StartupProcesses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.StartupProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcessName,
            this.ProcessPath,
            this.ProcessStatus});
            this.StartupProcesses.ForeColor = System.Drawing.Color.White;
            this.StartupProcesses.FullRowSelect = true;
            this.StartupProcesses.HideSelection = false;
            this.StartupProcesses.Location = new System.Drawing.Point(12, 12);
            this.StartupProcesses.Name = "StartupProcesses";
            this.StartupProcesses.Size = new System.Drawing.Size(916, 531);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(655, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Disable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.SeaGreen;
            this.button2.Location = new System.Drawing.Point(798, 549);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add New";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmStartupPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(940, 598);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartupProcesses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStartupPrograms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Startup Programs";
            this.Load += new System.EventHandler(this.frmStartupPrograms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView StartupProcesses;
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader ProcessPath;
        private System.Windows.Forms.ColumnHeader ProcessStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}