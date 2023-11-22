namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal_Sub_User_Controls
{
    partial class benefitsDetailsUC
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
            this.benefitName = new System.Windows.Forms.Label();
            this.benefitValue = new System.Windows.Forms.Label();
            this.benefitsStatus = new System.Windows.Forms.Label();
            this.inactiveBtn = new Payroll_Project2.Custom.buttonDesign();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.activeBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // benefitName
            // 
            this.benefitName.AutoSize = true;
            this.benefitName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.benefitName.ForeColor = System.Drawing.Color.Black;
            this.benefitName.Location = new System.Drawing.Point(6, 6);
            this.benefitName.Name = "benefitName";
            this.benefitName.Size = new System.Drawing.Size(33, 19);
            this.benefitName.TabIndex = 6;
            this.benefitName.Text = "SSS";
            // 
            // benefitValue
            // 
            this.benefitValue.AutoSize = true;
            this.benefitValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.benefitValue.ForeColor = System.Drawing.Color.Black;
            this.benefitValue.Location = new System.Drawing.Point(268, 6);
            this.benefitValue.Name = "benefitValue";
            this.benefitValue.Size = new System.Drawing.Size(33, 19);
            this.benefitValue.TabIndex = 6;
            this.benefitValue.Text = "700";
            // 
            // benefitsStatus
            // 
            this.benefitsStatus.AutoSize = true;
            this.benefitsStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.benefitsStatus.ForeColor = System.Drawing.Color.Black;
            this.benefitsStatus.Location = new System.Drawing.Point(559, 6);
            this.benefitsStatus.Name = "benefitsStatus";
            this.benefitsStatus.Size = new System.Drawing.Size(48, 19);
            this.benefitsStatus.TabIndex = 6;
            this.benefitsStatus.Text = "Active";
            // 
            // inactiveBtn
            // 
            this.inactiveBtn.AutoSize = true;
            this.inactiveBtn.BackColor = System.Drawing.Color.Red;
            this.inactiveBtn.BackgroundColor = System.Drawing.Color.Red;
            this.inactiveBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.inactiveBtn.BorderRadius = 5;
            this.inactiveBtn.BorderSize = 0;
            this.inactiveBtn.FlatAppearance.BorderSize = 0;
            this.inactiveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inactiveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.inactiveBtn.ForeColor = System.Drawing.Color.White;
            this.inactiveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inactiveBtn.Location = new System.Drawing.Point(918, 3);
            this.inactiveBtn.Name = "inactiveBtn";
            this.inactiveBtn.Size = new System.Drawing.Size(82, 25);
            this.inactiveBtn.TabIndex = 7;
            this.inactiveBtn.Text = "Inactive";
            this.inactiveBtn.TextColor = System.Drawing.Color.White;
            this.inactiveBtn.UseVisualStyleBackColor = false;
            this.inactiveBtn.Click += new System.EventHandler(this.inactiveBtn_Click);
            // 
            // viewBtn
            // 
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.viewBtn.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.viewBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewBtn.Location = new System.Drawing.Point(799, 3);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(118, 25);
            this.viewBtn.TabIndex = 7;
            this.viewBtn.Text = "View Contributions";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // activeBtn
            // 
            this.activeBtn.AutoSize = true;
            this.activeBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.activeBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.activeBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.activeBtn.BorderRadius = 5;
            this.activeBtn.BorderSize = 0;
            this.activeBtn.FlatAppearance.BorderSize = 0;
            this.activeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activeBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.activeBtn.ForeColor = System.Drawing.Color.White;
            this.activeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.activeBtn.Location = new System.Drawing.Point(918, 3);
            this.activeBtn.Name = "activeBtn";
            this.activeBtn.Size = new System.Drawing.Size(82, 25);
            this.activeBtn.TabIndex = 8;
            this.activeBtn.Text = "Active";
            this.activeBtn.TextColor = System.Drawing.Color.White;
            this.activeBtn.UseVisualStyleBackColor = false;
            this.activeBtn.Click += new System.EventHandler(this.activeBtn_Click);
            // 
            // benefitsDetailsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.benefitsStatus);
            this.Controls.Add(this.benefitValue);
            this.Controls.Add(this.benefitName);
            this.Controls.Add(this.inactiveBtn);
            this.Controls.Add(this.activeBtn);
            this.Name = "benefitsDetailsUC";
            this.Size = new System.Drawing.Size(1017, 33);
            this.Load += new System.EventHandler(this.benefitsDetailsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label benefitName;
        private System.Windows.Forms.Label benefitValue;
        private System.Windows.Forms.Label benefitsStatus;
        private Custom.buttonDesign viewBtn;
        private Custom.buttonDesign inactiveBtn;
        private Custom.buttonDesign activeBtn;
    }
}
