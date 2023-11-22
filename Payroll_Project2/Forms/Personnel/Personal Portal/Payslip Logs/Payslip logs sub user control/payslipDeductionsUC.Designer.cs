namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control
{
    partial class payslipDeductionsUC
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
            this.deductionsAmount = new System.Windows.Forms.Label();
            this.deductionNumber = new System.Windows.Forms.Label();
            this.deductionDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deductionsAmount
            // 
            this.deductionsAmount.AutoSize = true;
            this.deductionsAmount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionsAmount.ForeColor = System.Drawing.Color.Black;
            this.deductionsAmount.Location = new System.Drawing.Point(370, 8);
            this.deductionsAmount.Name = "deductionsAmount";
            this.deductionsAmount.Size = new System.Drawing.Size(58, 18);
            this.deductionsAmount.TabIndex = 15;
            this.deductionsAmount.Text = "Amount";
            // 
            // deductionNumber
            // 
            this.deductionNumber.AutoSize = true;
            this.deductionNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionNumber.ForeColor = System.Drawing.Color.Black;
            this.deductionNumber.Location = new System.Drawing.Point(265, 8);
            this.deductionNumber.Name = "deductionNumber";
            this.deductionNumber.Size = new System.Drawing.Size(59, 18);
            this.deductionNumber.TabIndex = 13;
            this.deductionNumber.Text = "Number";
            // 
            // deductionDescription
            // 
            this.deductionDescription.AutoSize = true;
            this.deductionDescription.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionDescription.ForeColor = System.Drawing.Color.Black;
            this.deductionDescription.Location = new System.Drawing.Point(4, 8);
            this.deductionDescription.Name = "deductionDescription";
            this.deductionDescription.Size = new System.Drawing.Size(78, 18);
            this.deductionDescription.TabIndex = 14;
            this.deductionDescription.Text = "Deductions";
            // 
            // payslipDeductionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.deductionsAmount);
            this.Controls.Add(this.deductionNumber);
            this.Controls.Add(this.deductionDescription);
            this.Name = "payslipDeductionsUC";
            this.Size = new System.Drawing.Size(431, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deductionsAmount;
        private System.Windows.Forms.Label deductionNumber;
        private System.Windows.Forms.Label deductionDescription;
    }
}
