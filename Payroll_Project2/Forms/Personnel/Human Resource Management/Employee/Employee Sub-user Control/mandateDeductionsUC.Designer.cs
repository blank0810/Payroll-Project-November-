namespace Payroll_Project2.Forms.Personnel.Employee.Modal
{
    partial class mandateDeductionsUC
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
            this.totalValue = new System.Windows.Forms.Label();
            this.employerShareValue = new System.Windows.Forms.Label();
            this.personalShareValue = new System.Windows.Forms.Label();
            this.benefitName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // totalValue
            // 
            this.totalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalValue.AutoSize = true;
            this.totalValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValue.Location = new System.Drawing.Point(685, 8);
            this.totalValue.Name = "totalValue";
            this.totalValue.Size = new System.Drawing.Size(138, 17);
            this.totalValue.TabIndex = 4;
            this.totalValue.Text = "Total value deduction";
            this.totalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // employerShareValue
            // 
            this.employerShareValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.employerShareValue.AutoSize = true;
            this.employerShareValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employerShareValue.Location = new System.Drawing.Point(453, 8);
            this.employerShareValue.Name = "employerShareValue";
            this.employerShareValue.Size = new System.Drawing.Size(139, 17);
            this.employerShareValue.TabIndex = 5;
            this.employerShareValue.Text = "Employer Share Value";
            this.employerShareValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // personalShareValue
            // 
            this.personalShareValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.personalShareValue.AutoSize = true;
            this.personalShareValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalShareValue.Location = new System.Drawing.Point(218, 8);
            this.personalShareValue.Name = "personalShareValue";
            this.personalShareValue.Size = new System.Drawing.Size(141, 17);
            this.personalShareValue.TabIndex = 6;
            this.personalShareValue.Text = "Employee Share Value";
            this.personalShareValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // benefitName
            // 
            this.benefitName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.benefitName.AutoSize = true;
            this.benefitName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benefitName.Location = new System.Drawing.Point(7, 8);
            this.benefitName.Name = "benefitName";
            this.benefitName.Size = new System.Drawing.Size(108, 17);
            this.benefitName.TabIndex = 7;
            this.benefitName.Text = "Deduction name";
            this.benefitName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mandateDeductionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.totalValue);
            this.Controls.Add(this.employerShareValue);
            this.Controls.Add(this.personalShareValue);
            this.Controls.Add(this.benefitName);
            this.Name = "mandateDeductionsUC";
            this.Size = new System.Drawing.Size(833, 33);
            this.Load += new System.EventHandler(this.mandateDeductionsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalValue;
        private System.Windows.Forms.Label employerShareValue;
        private System.Windows.Forms.Label personalShareValue;
        private System.Windows.Forms.Label benefitName;
    }
}
