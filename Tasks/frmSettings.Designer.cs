
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.taskDialog1 = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
            this.taskDialogButton1 = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
            this.taskDialogButton2 = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(6, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clean Tasks Temp Files";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 429);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Storage Options";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(6, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset Settings to Default";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // taskDialog1
            // 
            this.taskDialog1.AllowDialogCancellation = true;
            this.taskDialog1.Buttons.Add(this.taskDialogButton1);
            this.taskDialog1.Buttons.Add(this.taskDialogButton2);
            this.taskDialog1.Content = "This will clear all settings and this action is irreversible, so choose wisely.";
            this.taskDialog1.CustomFooterIcon = ((System.Drawing.Icon)(resources.GetObject("taskDialog1.CustomFooterIcon")));
            this.taskDialog1.CustomMainIcon = ((System.Drawing.Icon)(resources.GetObject("taskDialog1.CustomMainIcon")));
            this.taskDialog1.ExpandedInformation = "Settings that will be affected: Themes, Languages, Preferences for Discord RP.";
            this.taskDialog1.MainInstruction = "Are you sure you would like to reset all settings?";
            this.taskDialog1.WindowIcon = ((System.Drawing.Icon)(resources.GetObject("taskDialog1.WindowIcon")));
            this.taskDialog1.WindowTitle = "Tasks";
            // 
            // taskDialogButton1
            // 
            this.taskDialogButton1.ButtonType = Ookii.Dialogs.WinForms.ButtonType.Yes;
            this.taskDialogButton1.Text = "Yes";
            // 
            // taskDialogButton2
            // 
            this.taskDialogButton2.ButtonType = Ookii.Dialogs.WinForms.ButtonType.No;
            this.taskDialogButton2.Text = "No";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(859, 594);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private Ookii.Dialogs.WinForms.TaskDialog taskDialog1;
        private Ookii.Dialogs.WinForms.TaskDialogButton taskDialogButton1;
        private Ookii.Dialogs.WinForms.TaskDialogButton taskDialogButton2;
    }
}