namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control
{
    partial class payslipEarningsUC
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
            this.earningsAmount = new System.Windows.Forms.Label();
            this.earningsDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // earningsAmount
            // 
            this.earningsAmount.AutoSize = true;
            this.earningsAmount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.earningsAmount.ForeColor = System.Drawing.Color.Black;
            this.earningsAmount.Location = new System.Drawing.Point(358, 8);
            this.earningsAmount.Name = "earningsAmount";
            this.earningsAmount.Size = new System.Drawing.Size(58, 18);
            this.earningsAmount.TabIndex = 10;
            this.earningsAmount.Text = "Amount";
            // 
            // earningsDescription
            // 
            this.earningsDescription.AutoSize = true;
            this.earningsDescription.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.earningsDescription.ForeColor = System.Drawing.Color.Black;
            this.earningsDescription.Location = new System.Drawing.Point(5, 8);
            this.earningsDescription.Name = "earningsDescription";
            this.earningsDescription.Size = new System.Drawing.Size(60, 18);
            this.earningsDescription.TabIndex = 11;
            this.earningsDescription.Text = "Earnings";
            // 
            // payslipEarningsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.earningsAmount);
            this.Controls.Add(this.earningsDescription);
            this.Name = "payslipEarningsUC";
            this.Size = new System.Drawing.Size(423, 33);
            this.Load += new System.EventHandler(this.payslipEarningsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label earningsAmount;
        private System.Windows.Forms.Label earningsDescription;
    }
}
