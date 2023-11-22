namespace Payroll_Project2.Forms.Employee.File_leave.File_leave_sub_user_control
{
    partial class leaveCreditsDataUC
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
            this.leaveType = new System.Windows.Forms.Label();
            this.totalCredits = new System.Windows.Forms.Label();
            this.usedCredits = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // leaveType
            // 
            this.leaveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leaveType.AutoSize = true;
            this.leaveType.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.leaveType.ForeColor = System.Drawing.Color.Black;
            this.leaveType.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.leaveType.Location = new System.Drawing.Point(6, 9);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(85, 18);
            this.leaveType.TabIndex = 92;
            this.leaveType.Text = "{Leave type}";
            this.leaveType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalCredits
            // 
            this.totalCredits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.totalCredits.AutoSize = true;
            this.totalCredits.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.totalCredits.ForeColor = System.Drawing.Color.Black;
            this.totalCredits.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalCredits.Location = new System.Drawing.Point(265, 9);
            this.totalCredits.Name = "totalCredits";
            this.totalCredits.Size = new System.Drawing.Size(93, 18);
            this.totalCredits.TabIndex = 92;
            this.totalCredits.Text = "{Total credits}";
            this.totalCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usedCredits
            // 
            this.usedCredits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.usedCredits.AutoSize = true;
            this.usedCredits.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.usedCredits.ForeColor = System.Drawing.Color.Black;
            this.usedCredits.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usedCredits.Location = new System.Drawing.Point(407, 9);
            this.usedCredits.Name = "usedCredits";
            this.usedCredits.Size = new System.Drawing.Size(95, 18);
            this.usedCredits.TabIndex = 92;
            this.usedCredits.Text = "{Used credits}";
            this.usedCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // balance
            // 
            this.balance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.balance.AutoSize = true;
            this.balance.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.balance.ForeColor = System.Drawing.Color.Black;
            this.balance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.balance.Location = new System.Drawing.Point(551, 9);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(66, 18);
            this.balance.TabIndex = 92;
            this.balance.Text = "{Balance}";
            this.balance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year
            // 
            this.year.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.year.AutoSize = true;
            this.year.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.year.ForeColor = System.Drawing.Color.Black;
            this.year.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.year.Location = new System.Drawing.Point(666, 9);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(45, 18);
            this.year.TabIndex = 92;
            this.year.Text = "{Year}";
            this.year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leaveCreditsDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.year);
            this.Controls.Add(this.balance);
            this.Controls.Add(this.usedCredits);
            this.Controls.Add(this.totalCredits);
            this.Controls.Add(this.leaveType);
            this.Name = "leaveCreditsDataUC";
            this.Size = new System.Drawing.Size(737, 36);
            this.Load += new System.EventHandler(this.leaveCreditsDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label leaveType;
        private System.Windows.Forms.Label totalCredits;
        private System.Windows.Forms.Label usedCredits;
        private System.Windows.Forms.Label balance;
        private System.Windows.Forms.Label year;
    }
}
