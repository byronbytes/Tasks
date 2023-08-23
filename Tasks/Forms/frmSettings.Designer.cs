
namespace Tasks
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            label14 = new System.Windows.Forms.Label();
            checkBox2 = new System.Windows.Forms.CheckBox();
            label19 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            checkBox3 = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            comboBox3 = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label14.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label14.Location = new System.Drawing.Point(12, 112);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(402, 30);
            label14.TabIndex = 16;
            label14.Text = "This enables or disables the ability to log your cleanup sessions to a text file.\r\nThe directory is located at C:/Program Files (x86)/Tasks";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBox2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            checkBox2.Location = new System.Drawing.Point(12, 88);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(215, 21);
            checkBox2.TabIndex = 15;
            checkBox2.Text = "Enable Cleanup Logging To File";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label19.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label19.Location = new System.Drawing.Point(12, 339);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(295, 15);
            label19.TabIndex = 14;
            label19.Text = "Changes the theme that Tasks uses. (Currently Broken)";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label18.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label18.Location = new System.Drawing.Point(12, 318);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(60, 21);
            label18.TabIndex = 13;
            label18.Text = "Theme";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label13.Location = new System.Drawing.Point(12, 233);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(81, 21);
            label13.TabIndex = 8;
            label13.Text = "Language";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label12.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label12.Location = new System.Drawing.Point(14, 254);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(176, 15);
            label12.TabIndex = 7;
            label12.Text = "Changes the language of Tasks.";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox1.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "English", "Spanish" });
            comboBox1.Location = new System.Drawing.Point(12, 272);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(225, 25);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            label10.Location = new System.Drawing.Point(12, 159);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(195, 37);
            label10.TabIndex = 2;
            label10.Text = "Customization";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            label7.Location = new System.Drawing.Point(12, 9);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(111, 37);
            label7.TabIndex = 0;
            label7.Text = "General";
            label7.Click += label7_Click;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Dark", "Light" });
            comboBox2.Location = new System.Drawing.Point(12, 357);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(225, 25);
            comboBox2.TabIndex = 17;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label3.Location = new System.Drawing.Point(12, 511);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(360, 15);
            label3.TabIndex = 22;
            label3.Text = "This checks for updates automatically on the start of opening Tasks.";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBox3.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            checkBox3.Location = new System.Drawing.Point(12, 487);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(228, 21);
            checkBox3.TabIndex = 21;
            checkBox3.Text = "Automatically Check For Updates";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // button1
            // 
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            button1.Location = new System.Drawing.Point(233, 77);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(139, 32);
            button1.TabIndex = 23;
            button1.Text = "Open Log Folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(161, 183, 255);
            label1.Location = new System.Drawing.Point(12, 422);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(106, 37);
            label1.TabIndex = 24;
            label1.Text = "Update";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label2.Location = new System.Drawing.Point(12, 46);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(297, 15);
            label2.TabIndex = 25;
            label2.Text = "__________________________________________________________";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label4.Location = new System.Drawing.Point(12, 196);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(297, 15);
            label4.TabIndex = 26;
            label4.Text = "__________________________________________________________";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label5.Location = new System.Drawing.Point(12, 459);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(297, 15);
            label5.TabIndex = 27;
            label5.Text = "__________________________________________________________";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label6.Location = new System.Drawing.Point(12, 594);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(60, 21);
            label6.TabIndex = 30;
            label6.Text = "Branch";
            // 
            // comboBox3
            // 
            comboBox3.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox3.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Stable", "Beta", "Nightly" });
            comboBox3.Location = new System.Drawing.Point(14, 618);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(225, 25);
            comboBox3.TabIndex = 28;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label8.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            label8.Location = new System.Drawing.Point(12, 569);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(388, 15);
            label8.TabIndex = 32;
            label8.Text = "Whenever there is an update, Tasks will try to download it automatically.";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            checkBox1.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            checkBox1.Location = new System.Drawing.Point(12, 545);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(287, 21);
            checkBox1.TabIndex = 31;
            checkBox1.Text = "[Experimental] Download Builds on Update";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(849, 689);
            Controls.Add(label8);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(checkBox3);
            Controls.Add(comboBox2);
            Controls.Add(label14);
            Controls.Add(label7);
            Controls.Add(checkBox2);
            Controls.Add(label19);
            Controls.Add(label10);
            Controls.Add(label18);
            Controls.Add(label13);
            Controls.Add(comboBox1);
            Controls.Add(label12);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "frmSettings";
            Text = "Settings";
            Load += frmSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}