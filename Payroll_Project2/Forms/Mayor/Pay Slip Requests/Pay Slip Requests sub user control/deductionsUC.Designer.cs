namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control
{
    partial class deductionsUC
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
            this.deductionAmount = new System.Windows.Forms.Label();
            this.deductionsDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deductionAmount
            // 
            this.deductionAmount.AutoSize = true;
            this.deductionAmount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionAmount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.deductionAmount.Location = new System.Drawing.Point(414, 10);
            this.deductionAmount.Name = "deductionAmount";
            this.deductionAmount.Size = new System.Drawing.Size(68, 18);
            this.deductionAmount.TabIndex = 13;
            this.deductionAmount.Text = "{Amount}";
            this.deductionAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deductionsDescription
            // 
            this.deductionsDescription.AutoSize = true;
            this.deductionsDescription.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionsDescription.ForeColor = System.Drawing.Color.DodgerBlue;
            this.deductionsDescription.Location = new System.Drawing.Point(20, 10);
            this.deductionsDescription.Name = "deductionsDescription";
            this.deductionsDescription.Size = new System.Drawing.Size(145, 18);
            this.deductionsDescription.TabIndex = 14;
            this.deductionsDescription.Text = "Deduction description";
            this.deductionsDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deductionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.deductionAmount);
            this.Controls.Add(this.deductionsDescription);
            this.Name = "deductionsUC";
            this.Size = new System.Drawing.Size(511, 38);
            this.Load += new System.EventHandler(this.deductionsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deductionAmount;
        private System.Windows.Forms.Label deductionsDescription;
    }
}
