namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls
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
            this.benefitDescription = new System.Windows.Forms.Label();
            this.benefitName = new System.Windows.Forms.Label();
            this.benefitId = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // benefitDescription
            // 
            this.benefitDescription.AutoSize = true;
            this.benefitDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benefitDescription.ForeColor = System.Drawing.Color.Black;
            this.benefitDescription.Location = new System.Drawing.Point(317, 9);
            this.benefitDescription.MaximumSize = new System.Drawing.Size(718, 0);
            this.benefitDescription.Name = "benefitDescription";
            this.benefitDescription.Size = new System.Drawing.Size(86, 19);
            this.benefitDescription.TabIndex = 4;
            this.benefitDescription.Text = "Description";
            // 
            // benefitName
            // 
            this.benefitName.AutoSize = true;
            this.benefitName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benefitName.ForeColor = System.Drawing.Color.Black;
            this.benefitName.Location = new System.Drawing.Point(50, 9);
            this.benefitName.Name = "benefitName";
            this.benefitName.Size = new System.Drawing.Size(49, 19);
            this.benefitName.TabIndex = 5;
            this.benefitName.Text = "Name";
            // 
            // benefitId
            // 
            this.benefitId.AutoSize = true;
            this.benefitId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benefitId.ForeColor = System.Drawing.Color.Black;
            this.benefitId.Location = new System.Drawing.Point(10, 9);
            this.benefitId.Name = "benefitId";
            this.benefitId.Size = new System.Drawing.Size(23, 19);
            this.benefitId.TabIndex = 6;
            this.benefitId.Text = "ID";
            // 
            // viewBtn
            // 
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(1072, 5);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(78, 27);
            this.viewBtn.TabIndex = 58;
            this.viewBtn.Text = "View Rate";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // benefitDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.benefitDescription);
            this.Controls.Add(this.benefitName);
            this.Controls.Add(this.benefitId);
            this.Name = "benefitDataUC";
            this.Size = new System.Drawing.Size(1157, 38);
            this.Load += new System.EventHandler(this.benefitDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label benefitDescription;
        private System.Windows.Forms.Label benefitName;
        private System.Windows.Forms.Label benefitId;
        private Custom.buttonDesign viewBtn;
    }
}
