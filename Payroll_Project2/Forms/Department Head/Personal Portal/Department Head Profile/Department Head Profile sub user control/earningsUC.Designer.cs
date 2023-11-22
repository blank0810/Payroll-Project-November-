namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control
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
            this.earningsNumber = new System.Windows.Forms.Label();
            this.earningsAmount = new System.Windows.Forms.Label();
            this.earningsDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // earningsNumber
            // 
            this.earningsNumber.AutoSize = true;
            this.earningsNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.earningsNumber.ForeColor = System.Drawing.Color.Black;
            this.earningsNumber.Location = new System.Drawing.Point(255, 8);
            this.earningsNumber.Name = "earningsNumber";
            this.earningsNumber.Size = new System.Drawing.Size(59, 18);
            this.earningsNumber.TabIndex = 6;
            this.earningsNumber.Text = "Number";
            // 
            // earningsAmount
            // 
            this.earningsAmount.AutoSize = true;
            this.earningsAmount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.earningsAmount.ForeColor = System.Drawing.Color.Black;
            this.earningsAmount.Location = new System.Drawing.Point(360, 8);
            this.earningsAmount.Name = "earningsAmount";
            this.earningsAmount.Size = new System.Drawing.Size(58, 18);
            this.earningsAmount.TabIndex = 7;
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
            this.earningsDescription.TabIndex = 8;
            this.earningsDescription.Text = "Earnings";
            // 
            // earningsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.earningsNumber);
            this.Controls.Add(this.earningsAmount);
            this.Controls.Add(this.earningsDescription);
            this.Name = "earningsUC";
            this.Size = new System.Drawing.Size(431, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label earningsNumber;
        private System.Windows.Forms.Label earningsAmount;
        private System.Windows.Forms.Label earningsDescription;
    }
}
