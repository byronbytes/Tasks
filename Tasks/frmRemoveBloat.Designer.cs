// TODO: Cleanup and change the code style
namespace Tasks
{
    partial class frmRemoveBloat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoveBloat));
            this.dialogEdgeNotif = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
            this.taskDialogButton1 = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
            this.taskDialogButton2 = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
            this.dialogError = new Ookii.Dialogs.WinForms.TaskDialog(this.components);
            this.taskDialogButton3 = new Ookii.Dialogs.WinForms.TaskDialogButton(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dialogEdgeNotif
            // 
            this.dialogEdgeNotif.Buttons.Add(this.taskDialogButton1);
            this.dialogEdgeNotif.Buttons.Add(this.taskDialogButton2);
            this.dialogEdgeNotif.Content = "Uninstalling Edge means you will no longer be able to use the Cleanup function fo" +
    "r Edge.";
            this.dialogEdgeNotif.MainIcon = Ookii.Dialogs.WinForms.TaskDialogIcon.Information;
            this.dialogEdgeNotif.MainInstruction = "Uninstall Notice";
            this.dialogEdgeNotif.WindowIcon = ((System.Drawing.Icon)(resources.GetObject("dialogEdgeNotif.WindowIcon")));
            this.dialogEdgeNotif.WindowTitle = "Tasks";
            // 
            // taskDialogButton1
            // 
            this.taskDialogButton1.Text = "Okay";
            // 
            // taskDialogButton2
            // 
            this.taskDialogButton2.Text = "Cancel";
            // 
            // dialogError
            // 
            this.dialogError.Buttons.Add(this.taskDialogButton3);
            this.dialogError.Content = "An error has occurred. Error: Placeholder-000.";
            this.dialogError.MainInstruction = "An error occurred.";
            this.dialogError.WindowTitle = "Tasks";
            // 
            // taskDialogButton3
            // 
            this.taskDialogButton3.Text = "Ok";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 126);
            this.label1.TabIndex = 2;
            this.label1.Text = "This menu is now visible under Cleanup.\r\n\r\n\r\nCleanup -> Remove Bloat\r\n\r\nThis menu" +
    " will be removed in the next update.";
            // 
            // frmRemoveBloat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(388, 157);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemoveBloat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remove Bloatware";
            this.Load += new System.EventHandler(this.frmRemoveBloat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Ookii.Dialogs.WinForms.TaskDialog dialogEdgeNotif;
        private Ookii.Dialogs.WinForms.TaskDialogButton taskDialogButton1;
        private Ookii.Dialogs.WinForms.TaskDialogButton taskDialogButton2;
        private Ookii.Dialogs.WinForms.TaskDialog dialogError;
        private Ookii.Dialogs.WinForms.TaskDialogButton taskDialogButton3;
        private System.Windows.Forms.Label label1;
    }
}