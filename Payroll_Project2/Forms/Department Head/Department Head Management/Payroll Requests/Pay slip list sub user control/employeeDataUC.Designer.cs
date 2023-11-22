namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    partial class employeeDataUC
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
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.employeeId = new System.Windows.Forms.Label();
            this.totalDeductions = new System.Windows.Forms.Label();
            this.totalEarnings = new System.Windows.Forms.Label();
            this.payrollFormId = new System.Windows.Forms.Label();
            this.dateCreated = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.totalSalary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderColor = System.Drawing.Color.Transparent;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(1288, 10);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(107, 29);
            this.viewBtn.TabIndex = 14;
            this.viewBtn.Text = "View Pay slip";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // employeeId
            // 
            this.employeeId.AutoSize = true;
            this.employeeId.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.employeeId.ForeColor = System.Drawing.Color.DimGray;
            this.employeeId.Location = new System.Drawing.Point(3, 27);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(91, 17);
            this.employeeId.TabIndex = 7;
            this.employeeId.Text = "{Employee Id}";
            this.employeeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalDeductions
            // 
            this.totalDeductions.AutoSize = true;
            this.totalDeductions.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.totalDeductions.ForeColor = System.Drawing.Color.Black;
            this.totalDeductions.Location = new System.Drawing.Point(890, 14);
            this.totalDeductions.Name = "totalDeductions";
            this.totalDeductions.Size = new System.Drawing.Size(135, 19);
            this.totalDeductions.TabIndex = 8;
            this.totalDeductions.Text = "{Total Deductions}";
            this.totalDeductions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalEarnings
            // 
            this.totalEarnings.AutoSize = true;
            this.totalEarnings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.totalEarnings.ForeColor = System.Drawing.Color.Black;
            this.totalEarnings.Location = new System.Drawing.Point(715, 14);
            this.totalEarnings.Name = "totalEarnings";
            this.totalEarnings.Size = new System.Drawing.Size(117, 19);
            this.totalEarnings.TabIndex = 9;
            this.totalEarnings.Text = "{Total Earnings}";
            this.totalEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // payrollFormId
            // 
            this.payrollFormId.AutoSize = true;
            this.payrollFormId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.payrollFormId.ForeColor = System.Drawing.Color.Black;
            this.payrollFormId.Location = new System.Drawing.Point(360, 14);
            this.payrollFormId.Name = "payrollFormId";
            this.payrollFormId.Size = new System.Drawing.Size(87, 19);
            this.payrollFormId.TabIndex = 10;
            this.payrollFormId.Text = "{Payroll ID}";
            this.payrollFormId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateCreated
            // 
            this.dateCreated.AutoSize = true;
            this.dateCreated.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.dateCreated.ForeColor = System.Drawing.Color.Black;
            this.dateCreated.Location = new System.Drawing.Point(515, 14);
            this.dateCreated.Name = "dateCreated";
            this.dateCreated.Size = new System.Drawing.Size(110, 19);
            this.dateCreated.TabIndex = 11;
            this.dateCreated.Text = "{Date Created}";
            this.dateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.employeeName.ForeColor = System.Drawing.Color.Black;
            this.employeeName.Location = new System.Drawing.Point(3, 5);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(130, 19);
            this.employeeName.TabIndex = 12;
            this.employeeName.Text = "{Employee name}";
            this.employeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalSalary
            // 
            this.totalSalary.AutoSize = true;
            this.totalSalary.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.totalSalary.ForeColor = System.Drawing.Color.Black;
            this.totalSalary.Location = new System.Drawing.Point(1087, 14);
            this.totalSalary.Name = "totalSalary";
            this.totalSalary.Size = new System.Drawing.Size(101, 19);
            this.totalSalary.TabIndex = 8;
            this.totalSalary.Text = "{Total Salary}";
            this.totalSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.employeeId);
            this.Controls.Add(this.totalSalary);
            this.Controls.Add(this.totalDeductions);
            this.Controls.Add(this.totalEarnings);
            this.Controls.Add(this.payrollFormId);
            this.Controls.Add(this.dateCreated);
            this.Controls.Add(this.employeeName);
            this.Name = "employeeDataUC";
            this.Size = new System.Drawing.Size(1399, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label employeeId;
        private System.Windows.Forms.Label totalDeductions;
        private System.Windows.Forms.Label totalEarnings;
        private System.Windows.Forms.Label payrollFormId;
        private System.Windows.Forms.Label dateCreated;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.Label totalSalary;
    }
}
