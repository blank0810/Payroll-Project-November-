namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control
{
    partial class earningsUC
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
            this.earningsAmount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.earningsAmount.Location = new System.Drawing.Point(410, 10);
            this.earningsAmount.Name = "earningsAmount";
            this.earningsAmount.Size = new System.Drawing.Size(68, 18);
            this.earningsAmount.TabIndex = 11;
            this.earningsAmount.Text = "{Amount}";
            this.earningsAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // earningsDescription
            // 
            this.earningsDescription.AutoSize = true;
            this.earningsDescription.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.earningsDescription.ForeColor = System.Drawing.Color.DodgerBlue;
            this.earningsDescription.Location = new System.Drawing.Point(20, 10);
            this.earningsDescription.Name = "earningsDescription";
            this.earningsDescription.Size = new System.Drawing.Size(134, 18);
            this.earningsDescription.TabIndex = 12;
            this.earningsDescription.Text = "Earnings Description";
            this.earningsDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // earningsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.earningsAmount);
            this.Controls.Add(this.earningsDescription);
            this.Name = "earningsUC";
            this.Size = new System.Drawing.Size(499, 38);
            this.Load += new System.EventHandler(this.earningsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label earningsAmount;
        private System.Windows.Forms.Label earningsDescription;
    }
}
