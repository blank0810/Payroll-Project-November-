namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    partial class earningsDataUC
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
            this.earningsNumber = new System.Windows.Forms.Label();
            this.earningsDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // earningsAmount
            // 
            this.earningsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.earningsAmount.AutoSize = true;
            this.earningsAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.earningsAmount.ForeColor = System.Drawing.Color.Black;
            this.earningsAmount.Location = new System.Drawing.Point(512, 8);
            this.earningsAmount.Name = "earningsAmount";
            this.earningsAmount.Size = new System.Drawing.Size(113, 19);
            this.earningsAmount.TabIndex = 11;
            this.earningsAmount.Text = "{Total amount}";
            this.earningsAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // earningsNumber
            // 
            this.earningsNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.earningsNumber.AutoSize = true;
            this.earningsNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.earningsNumber.ForeColor = System.Drawing.Color.Black;
            this.earningsNumber.Location = new System.Drawing.Point(295, 8);
            this.earningsNumber.Name = "earningsNumber";
            this.earningsNumber.Size = new System.Drawing.Size(125, 19);
            this.earningsNumber.TabIndex = 12;
            this.earningsNumber.Text = "{No. of earnings}";
            this.earningsNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // earningsDescription
            // 
            this.earningsDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.earningsDescription.AutoSize = true;
            this.earningsDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.earningsDescription.ForeColor = System.Drawing.Color.Black;
            this.earningsDescription.Location = new System.Drawing.Point(3, 8);
            this.earningsDescription.Name = "earningsDescription";
            this.earningsDescription.Size = new System.Drawing.Size(147, 19);
            this.earningsDescription.TabIndex = 13;
            this.earningsDescription.Text = "Earnings description";
            this.earningsDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // earningsDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.earningsAmount);
            this.Controls.Add(this.earningsNumber);
            this.Controls.Add(this.earningsDescription);
            this.Name = "earningsDataUC";
            this.Size = new System.Drawing.Size(651, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label earningsAmount;
        private System.Windows.Forms.Label earningsNumber;
        private System.Windows.Forms.Label earningsDescription;
    }
}
