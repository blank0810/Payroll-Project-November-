namespace Payroll_Project2.Forms.Personnel.Personal_Portal.My_Profile.Personal_Profile_sub_user_control
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
            this.deductionNumber = new System.Windows.Forms.Label();
            this.deductionDescription = new System.Windows.Forms.Label();
            this.deductionsAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deductionNumber
            // 
            this.deductionNumber.AutoSize = true;
            this.deductionNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionNumber.ForeColor = System.Drawing.Color.Black;
            this.deductionNumber.Location = new System.Drawing.Point(255, 7);
            this.deductionNumber.Name = "deductionNumber";
            this.deductionNumber.Size = new System.Drawing.Size(59, 18);
            this.deductionNumber.TabIndex = 9;
            this.deductionNumber.Text = "Number";
            // 
            // deductionDescription
            // 
            this.deductionDescription.AutoSize = true;
            this.deductionDescription.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionDescription.ForeColor = System.Drawing.Color.Black;
            this.deductionDescription.Location = new System.Drawing.Point(5, 7);
            this.deductionDescription.Name = "deductionDescription";
            this.deductionDescription.Size = new System.Drawing.Size(78, 18);
            this.deductionDescription.TabIndex = 11;
            this.deductionDescription.Text = "Deductions";
            // 
            // deductionsAmount
            // 
            this.deductionsAmount.AutoSize = true;
            this.deductionsAmount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.deductionsAmount.ForeColor = System.Drawing.Color.Black;
            this.deductionsAmount.Location = new System.Drawing.Point(360, 7);
            this.deductionsAmount.Name = "deductionsAmount";
            this.deductionsAmount.Size = new System.Drawing.Size(58, 18);
            this.deductionsAmount.TabIndex = 12;
            this.deductionsAmount.Text = "Amount";
            // 
            // deductionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.deductionsAmount);
            this.Controls.Add(this.deductionNumber);
            this.Controls.Add(this.deductionDescription);
            this.Name = "deductionsUC";
            this.Size = new System.Drawing.Size(427, 33);
            this.Load += new System.EventHandler(this.deductionsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deductionNumber;
        private System.Windows.Forms.Label deductionDescription;
        private System.Windows.Forms.Label deductionsAmount;
    }
}
