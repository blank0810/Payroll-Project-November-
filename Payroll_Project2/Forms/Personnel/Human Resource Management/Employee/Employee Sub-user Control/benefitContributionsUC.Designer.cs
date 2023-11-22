namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control
{
    partial class benefitContributionsUC
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
            this.payrollId = new System.Windows.Forms.Label();
            this.month = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // totalValue
            // 
            this.totalValue.AutoSize = true;
            this.totalValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.totalValue.ForeColor = System.Drawing.Color.Black;
            this.totalValue.Location = new System.Drawing.Point(454, 9);
            this.totalValue.Name = "totalValue";
            this.totalValue.Size = new System.Drawing.Size(107, 19);
            this.totalValue.TabIndex = 10;
            this.totalValue.Text = "Total deduction";
            // 
            // payrollId
            // 
            this.payrollId.AutoSize = true;
            this.payrollId.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.payrollId.ForeColor = System.Drawing.Color.Black;
            this.payrollId.Location = new System.Drawing.Point(217, 9);
            this.payrollId.Name = "payrollId";
            this.payrollId.Size = new System.Drawing.Size(70, 19);
            this.payrollId.TabIndex = 11;
            this.payrollId.Text = "Payroll ID";
            // 
            // month
            // 
            this.month.AutoSize = true;
            this.month.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.month.ForeColor = System.Drawing.Color.Black;
            this.month.Location = new System.Drawing.Point(2, 9);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(51, 19);
            this.month.TabIndex = 12;
            this.month.Text = "Month";
            // 
            // viewBtn
            // 
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewBtn.Location = new System.Drawing.Point(716, 6);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(83, 25);
            this.viewBtn.TabIndex = 13;
            this.viewBtn.Text = "View Payslip";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // benefitContributionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.totalValue);
            this.Controls.Add(this.payrollId);
            this.Controls.Add(this.month);
            this.Name = "benefitContributionsUC";
            this.Size = new System.Drawing.Size(804, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalValue;
        private System.Windows.Forms.Label payrollId;
        private System.Windows.Forms.Label month;
        private Custom.buttonDesign viewBtn;
    }
}
