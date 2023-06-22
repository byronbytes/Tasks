namespace Tasks.Forms
{
    partial class frmSettingsHolder
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
            panel1 = new System.Windows.Forms.Panel();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(18, 26, 35);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(201, 689);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button2.Dock = System.Windows.Forms.DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button2.Location = new System.Drawing.Point(0, 59);
            button2.Name = "button2";
            button2.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            button2.Size = new System.Drawing.Size(201, 59);
            button2.TabIndex = 5;
            button2.Text = "About";
            button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(14, 18, 26);
            button1.Dock = System.Windows.Forms.DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.FromArgb(224, 228, 255);
            button1.Location = new System.Drawing.Point(0, 0);
            button1.Name = "button1";
            button1.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            button1.Size = new System.Drawing.Size(201, 59);
            button1.TabIndex = 3;
            button1.Text = "Settings";
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(13, 12, 14);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(201, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(849, 689);
            panel2.TabIndex = 1;
            // 
            // frmSettingsHolder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(1050, 689);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "frmSettingsHolder";
            RightToLeft = System.Windows.Forms.RightToLeft.No;
            Text = "Settings";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
    }
}