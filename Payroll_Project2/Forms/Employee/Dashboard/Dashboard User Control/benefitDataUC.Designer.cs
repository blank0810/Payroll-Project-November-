﻿namespace Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control
{
    partial class benefitDataUC
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
            this.benefitsStatus = new System.Windows.Forms.Label();
            this.benefitValue = new System.Windows.Forms.Label();
            this.benefitName = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.viewBtn.Location = new System.Drawing.Point(595, 7);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(118, 25);
            this.viewBtn.TabIndex = 11;
            this.viewBtn.Text = "View Contributions";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // benefitsStatus
            // 
            this.benefitsStatus.AutoSize = true;
            this.benefitsStatus.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.benefitsStatus.ForeColor = System.Drawing.Color.Black;
            this.benefitsStatus.Location = new System.Drawing.Point(428, 10);
            this.benefitsStatus.Name = "benefitsStatus";
            this.benefitsStatus.Size = new System.Drawing.Size(47, 18);
            this.benefitsStatus.TabIndex = 8;
            this.benefitsStatus.Text = "Active";
            // 
            // benefitValue
            // 
            this.benefitValue.AutoSize = true;
            this.benefitValue.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.benefitValue.ForeColor = System.Drawing.Color.Black;
            this.benefitValue.Location = new System.Drawing.Point(220, 10);
            this.benefitValue.Name = "benefitValue";
            this.benefitValue.Size = new System.Drawing.Size(29, 18);
            this.benefitValue.TabIndex = 9;
            this.benefitValue.Text = "700";
            // 
            // benefitName
            // 
            this.benefitName.AutoSize = true;
            this.benefitName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.benefitName.ForeColor = System.Drawing.Color.Black;
            this.benefitName.Location = new System.Drawing.Point(6, 10);
            this.benefitName.Name = "benefitName";
            this.benefitName.Size = new System.Drawing.Size(29, 18);
            this.benefitName.TabIndex = 10;
            this.benefitName.Text = "SSS";
            // 
            // benefitDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.benefitsStatus);
            this.Controls.Add(this.benefitValue);
            this.Controls.Add(this.benefitName);
            this.Name = "benefitDataUC";
            this.Size = new System.Drawing.Size(722, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label benefitsStatus;
        private System.Windows.Forms.Label benefitValue;
        private System.Windows.Forms.Label benefitName;
    }
}
