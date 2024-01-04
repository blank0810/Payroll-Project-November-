namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls
{
    partial class benefitSubUC
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
            this.year = new System.Windows.Forms.Label();
            this.rateStatus = new System.Windows.Forms.Label();
            this.employerShare = new System.Windows.Forms.Label();
            this.personalShare = new System.Windows.Forms.Label();
            this.modifyBtn = new Payroll_Project2.Custom.buttonDesign();
            this.personalShareBox = new Payroll_Project2.Custom.customTextBox2();
            this.employerShareBox = new Payroll_Project2.Custom.customTextBox2();
            this.rateStatusChoices = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new Payroll_Project2.Custom.buttonDesign();
            this.submitBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.year.ForeColor = System.Drawing.Color.Black;
            this.year.Location = new System.Drawing.Point(639, 5);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(92, 18);
            this.year.TabIndex = 8;
            this.year.Text = "Year Effective";
            this.year.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rateStatus
            // 
            this.rateStatus.AutoSize = true;
            this.rateStatus.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.rateStatus.ForeColor = System.Drawing.Color.Black;
            this.rateStatus.Location = new System.Drawing.Point(445, 5);
            this.rateStatus.Name = "rateStatus";
            this.rateStatus.Size = new System.Drawing.Size(77, 18);
            this.rateStatus.TabIndex = 9;
            this.rateStatus.Text = "Rate Status";
            this.rateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employerShare
            // 
            this.employerShare.AutoSize = true;
            this.employerShare.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.employerShare.ForeColor = System.Drawing.Color.Black;
            this.employerShare.Location = new System.Drawing.Point(254, 5);
            this.employerShare.Name = "employerShare";
            this.employerShare.Size = new System.Drawing.Size(143, 18);
            this.employerShare.TabIndex = 10;
            this.employerShare.Text = "Employer Share Value";
            this.employerShare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // personalShare
            // 
            this.personalShare.AutoSize = true;
            this.personalShare.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.personalShare.ForeColor = System.Drawing.Color.Black;
            this.personalShare.Location = new System.Drawing.Point(4, 5);
            this.personalShare.Name = "personalShare";
            this.personalShare.Size = new System.Drawing.Size(138, 18);
            this.personalShare.TabIndex = 11;
            this.personalShare.Text = "Personal Share Value";
            this.personalShare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // modifyBtn
            // 
            this.modifyBtn.AutoSize = true;
            this.modifyBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.modifyBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.modifyBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.modifyBtn.BorderRadius = 5;
            this.modifyBtn.BorderSize = 0;
            this.modifyBtn.FlatAppearance.BorderSize = 0;
            this.modifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyBtn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.modifyBtn.ForeColor = System.Drawing.Color.White;
            this.modifyBtn.Location = new System.Drawing.Point(798, 5);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(81, 24);
            this.modifyBtn.TabIndex = 59;
            this.modifyBtn.Text = "Modify Rate";
            this.modifyBtn.TextColor = System.Drawing.Color.White;
            this.modifyBtn.UseVisualStyleBackColor = false;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // personalShareBox
            // 
            this.personalShareBox.BackColor = System.Drawing.SystemColors.Window;
            this.personalShareBox.BorderColor = System.Drawing.Color.DimGray;
            this.personalShareBox.BorderFocusColor = System.Drawing.Color.Black;
            this.personalShareBox.BorderRadius = 0;
            this.personalShareBox.BorderSize = 2;
            this.personalShareBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalShareBox.ForeColor = System.Drawing.Color.Black;
            this.personalShareBox.Location = new System.Drawing.Point(4, 2);
            this.personalShareBox.Multiline = false;
            this.personalShareBox.Name = "personalShareBox";
            this.personalShareBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.personalShareBox.PasswordChar = false;
            this.personalShareBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.personalShareBox.PlaceholderText = "";
            this.personalShareBox.Size = new System.Drawing.Size(138, 30);
            this.personalShareBox.TabIndex = 60;
            this.personalShareBox.Texts = "";
            this.personalShareBox.UnderlinedStyle = false;
            this.personalShareBox.Visible = false;
            // 
            // employerShareBox
            // 
            this.employerShareBox.BackColor = System.Drawing.SystemColors.Window;
            this.employerShareBox.BorderColor = System.Drawing.Color.DimGray;
            this.employerShareBox.BorderFocusColor = System.Drawing.Color.Black;
            this.employerShareBox.BorderRadius = 0;
            this.employerShareBox.BorderSize = 2;
            this.employerShareBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employerShareBox.ForeColor = System.Drawing.Color.Black;
            this.employerShareBox.Location = new System.Drawing.Point(254, 2);
            this.employerShareBox.Multiline = false;
            this.employerShareBox.Name = "employerShareBox";
            this.employerShareBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.employerShareBox.PasswordChar = false;
            this.employerShareBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.employerShareBox.PlaceholderText = "";
            this.employerShareBox.Size = new System.Drawing.Size(138, 30);
            this.employerShareBox.TabIndex = 60;
            this.employerShareBox.Texts = "";
            this.employerShareBox.UnderlinedStyle = false;
            this.employerShareBox.Visible = false;
            // 
            // rateStatusChoices
            // 
            this.rateStatusChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rateStatusChoices.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.rateStatusChoices.FormattingEnabled = true;
            this.rateStatusChoices.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.rateStatusChoices.Location = new System.Drawing.Point(445, 4);
            this.rateStatusChoices.Name = "rateStatusChoices";
            this.rateStatusChoices.Size = new System.Drawing.Size(138, 23);
            this.rateStatusChoices.TabIndex = 61;
            this.rateStatusChoices.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.BackColor = System.Drawing.Color.Maroon;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.Maroon;
            this.cancelBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cancelBtn.BorderRadius = 5;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(885, 5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(81, 24);
            this.cancelBtn.TabIndex = 59;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSize = true;
            this.submitBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.submitBtn.BorderRadius = 5;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(798, 5);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(81, 24);
            this.submitBtn.TabIndex = 62;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Visible = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // benefitSubUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.year);
            this.Controls.Add(this.personalShare);
            this.Controls.Add(this.employerShare);
            this.Controls.Add(this.rateStatus);
            this.Controls.Add(this.personalShareBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.employerShareBox);
            this.Controls.Add(this.rateStatusChoices);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.modifyBtn);
            this.Name = "benefitSubUC";
            this.Size = new System.Drawing.Size(969, 34);
            this.Load += new System.EventHandler(this.benefitSubUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label rateStatus;
        private System.Windows.Forms.Label employerShare;
        private System.Windows.Forms.Label personalShare;
        private Custom.buttonDesign modifyBtn;
        private Custom.customTextBox2 personalShareBox;
        private Custom.customTextBox2 employerShareBox;
        private System.Windows.Forms.ComboBox rateStatusChoices;
        private Custom.buttonDesign cancelBtn;
        private Custom.buttonDesign submitBtn;
    }
}
