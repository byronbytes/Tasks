namespace Tasks.Forms
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            label2 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            listBox1 = new System.Windows.Forms.ListBox();
            linkLabel3 = new System.Windows.Forms.LinkLabel();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label2.Location = new System.Drawing.Point(157, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 20);
            label2.TabIndex = 54;
            label2.Text = "Version: 5.0.0";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            pictureBox1.Image = Properties.Resources.Tasks_Logo_Small;
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(135, 128);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 53;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            label4.Location = new System.Drawing.Point(12, 195);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(127, 30);
            label4.TabIndex = 60;
            label4.Text = "Version Info";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label5.Location = new System.Drawing.Point(12, 225);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 20);
            label5.TabIndex = 61;
            label5.Text = "Name: ";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(12, 248);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(122, 31);
            button1.TabIndex = 65;
            button1.Text = "Check for Updates";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            label13.Location = new System.Drawing.Point(264, 195);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(135, 30);
            label13.TabIndex = 66;
            label13.Text = "Contributors";
            // 
            // listBox1
            // 
            listBox1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listBox1.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Items.AddRange(new object[] { "Byron (@byronbytes)", "Solirs (@Solirs)", "@GermanAizek" });
            listBox1.Location = new System.Drawing.Point(264, 228);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(188, 80);
            listBox1.TabIndex = 72;
            // 
            // linkLabel3
            // 
            linkLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabel3.AutoSize = true;
            linkLabel3.Cursor = System.Windows.Forms.Cursors.Hand;
            linkLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            linkLabel3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            linkLabel3.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            linkLabel3.Location = new System.Drawing.Point(431, 9);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new System.Drawing.Size(59, 21);
            linkLabel3.TabIndex = 73;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "GitHub";
            linkLabel3.VisitedLinkColor = System.Drawing.Color.DarkCyan;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            label1.Location = new System.Drawing.Point(153, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 30);
            label1.TabIndex = 52;
            label1.Text = "Tasks";
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(13, 12, 14);
            ClientSize = new System.Drawing.Size(502, 329);
            Controls.Add(linkLabel3);
            Controls.Add(listBox1);
            Controls.Add(label13);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "frmAbout";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tasks";
            Load += frmAbout_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label1;
    }
}