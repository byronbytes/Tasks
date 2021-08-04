
namespace Tasks
{
    partial class frmUtilityScripts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUtilityScripts));
            this.groupCleanup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupCleanup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCleanup
            // 
            this.groupCleanup.Controls.Add(this.label3);
            this.groupCleanup.Controls.Add(this.button2);
            this.groupCleanup.ForeColor = System.Drawing.Color.White;
            this.groupCleanup.Location = new System.Drawing.Point(12, 12);
            this.groupCleanup.Name = "groupCleanup";
            this.groupCleanup.Size = new System.Drawing.Size(314, 119);
            this.groupCleanup.TabIndex = 2;
            this.groupCleanup.TabStop = false;
            this.groupCleanup.Text = "Take Ownership of Temp Files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 51);
            this.label3.TabIndex = 2;
            this.label3.Text = "This will take ownership for these directories\r\nC:\\Windows\\Temp\r\nC:\\Windows\\Prefe" +
    "tch";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::Tasks.Properties.Resources.Cleanup;
            this.button2.Location = new System.Drawing.Point(9, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "TakeownTempFiles.bat";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmUtilityScripts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(702, 585);
            this.Controls.Add(this.groupCleanup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUtilityScripts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utility Scripts";
            this.groupCleanup.ResumeLayout(false);
            this.groupCleanup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupCleanup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}