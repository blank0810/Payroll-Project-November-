namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    partial class deductionDataUC
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
            this.deductionNumber = new System.Windows.Forms.Label();
            this.deductionDescription = new System.Windows.Forms.Label();
            this.deductionAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deductionNumber
            // 
            this.deductionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deductionNumber.AutoSize = true;
            this.deductionNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.deductionNumber.ForeColor = System.Drawing.Color.Black;
            this.deductionNumber.Location = new System.Drawing.Point(295, 8);
            this.deductionNumber.Name = "deductionNumber";
            this.deductionNumber.Size = new System.Drawing.Size(136, 19);
            this.deductionNumber.TabIndex = 9;
            this.deductionNumber.Text = "{No. of deduction}";
            this.deductionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deductionDescription
            // 
            this.deductionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deductionDescription.AutoSize = true;
            this.deductionDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.deductionDescription.ForeColor = System.Drawing.Color.Black;
            this.deductionDescription.Location = new System.Drawing.Point(3, 8);
            this.deductionDescription.Name = "deductionDescription";
            this.deductionDescription.Size = new System.Drawing.Size(159, 19);
            this.deductionDescription.TabIndex = 10;
            this.deductionDescription.Text = "Deduction description";
            this.deductionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deductionAmount
            // 
            this.deductionAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deductionAmount.AutoSize = true;
            this.deductionAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.deductionAmount.ForeColor = System.Drawing.Color.Black;
            this.deductionAmount.Location = new System.Drawing.Point(512, 8);
            this.deductionAmount.Name = "deductionAmount";
            this.deductionAmount.Size = new System.Drawing.Size(113, 19);
            this.deductionAmount.TabIndex = 9;
            this.deductionAmount.Text = "{Total amount}";
            this.deductionAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deductionDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.deductionAmount);
            this.Controls.Add(this.deductionNumber);
            this.Controls.Add(this.deductionDescription);
            this.Name = "deductionDataUC";
            this.Size = new System.Drawing.Size(651, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deductionNumber;
        private System.Windows.Forms.Label deductionDescription;
        private System.Windows.Forms.Label deductionAmount;
    }
}
