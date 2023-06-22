
namespace Tasks
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            label2 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button1.Image = Properties.Resources.Cleanup_White;
            button1.Location = new System.Drawing.Point(-6, 159);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(146, 75);
            button1.TabIndex = 14;
            button1.Text = "Cleanup";
            button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(button1, "Cleanup");
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button2.Image = Properties.Resources.StartupPrograms_White;
            button2.Location = new System.Drawing.Point(-6, 355);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(146, 75);
            button2.TabIndex = 15;
            button2.Text = "Startup";
            button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(button2, "Startup Programs");
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button4.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button4.Image = Properties.Resources.SettingsWhite;
            button4.Location = new System.Drawing.Point(0, 697);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(140, 53);
            button4.TabIndex = 17;
            button4.Text = "Settings";
            button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(button4, "Settings");
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel2.BackColor = System.Drawing.Color.FromArgb(13, 12, 14);
            panel2.Location = new System.Drawing.Point(138, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1056, 773);
            panel2.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notifyIcon1.Text = "Tasks";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label2.Location = new System.Drawing.Point(94, 753);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 20);
            label2.TabIndex = 0;
            label2.Text = "64 bit";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Tasks_Logo_Small;
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(120, 107);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label4.Location = new System.Drawing.Point(3, 753);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(88, 20);
            label4.TabIndex = 2;
            label4.Text = "Windows 10";
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.BackColor = System.Drawing.Color.FromArgb(18, 26, 45);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.ForeColor = System.Drawing.Color.Black;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(143, 779);
            panel1.TabIndex = 0;
            // 
            // frmMain
            // 
            AccessibleName = "b";
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(1194, 773);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tasks";
            Load += frmMain_Load;
            Shown += frmMain_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel panel1;
    }
}

