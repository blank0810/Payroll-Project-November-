namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.File_Pass_Slip.File_Pass_Slip_sub_user_control
{
    partial class passSlipDataUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthYear = new System.Windows.Forms.Label();
            this.numberOfHours = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthYear
            // 
            this.monthYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.monthYear.AutoSize = true;
            this.monthYear.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.monthYear.ForeColor = System.Drawing.Color.Black;
            this.monthYear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.monthYear.Location = new System.Drawing.Point(5, 8);
            this.monthYear.Name = "monthYear";
            this.monthYear.Size = new System.Drawing.Size(99, 18);
            this.monthYear.TabIndex = 93;
            this.monthYear.Text = "{Month / Year}";
            this.monthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberOfHours
            // 
            this.numberOfHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfHours.AutoSize = true;
            this.numberOfHours.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.numberOfHours.ForeColor = System.Drawing.Color.Black;
            this.numberOfHours.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.numberOfHours.Location = new System.Drawing.Point(450, 8);
            this.numberOfHours.Name = "numberOfHours";
            this.numberOfHours.Size = new System.Drawing.Size(113, 18);
            this.numberOfHours.TabIndex = 93;
            this.numberOfHours.Text = "{Hours available}";
            this.numberOfHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passSlipDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numberOfHours);
            this.Controls.Add(this.monthYear);
            this.Name = "passSlipDataUC";
            this.Size = new System.Drawing.Size(573, 36);
            this.Load += new System.EventHandler(this.passSlipDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label monthYear;
        private System.Windows.Forms.Label numberOfHours;
    }
}
