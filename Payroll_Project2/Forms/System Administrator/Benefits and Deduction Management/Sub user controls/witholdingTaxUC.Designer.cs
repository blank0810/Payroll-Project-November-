namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls
{
    partial class witholdingTaxUC
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
            this.status = new System.Windows.Forms.Label();
            this.yearEffective = new System.Windows.Forms.Label();
            this.excessAmount = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.Label();
            this.percentage = new System.Windows.Forms.Label();
            this.annualSalaryValue = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.annualSalaryIndicator = new System.Windows.Forms.Label();
            this.rateStatusChoices = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new Payroll_Project2.Custom.buttonDesign();
            this.descriptionBox = new Payroll_Project2.Custom.customTextBox2();
            this.fromAnnualBox = new Payroll_Project2.Custom.customTextBox2();
            this.toAnnualBox = new Payroll_Project2.Custom.customTextBox2();
            this.percentageBox = new Payroll_Project2.Custom.customTextBox2();
            this.amountBox = new Payroll_Project2.Custom.customTextBox2();
            this.excessAmountBox = new Payroll_Project2.Custom.customTextBox2();
            this.modifyBtn = new Payroll_Project2.Custom.buttonDesign();
            this.submitBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.status.ForeColor = System.Drawing.Color.Black;
            this.status.Location = new System.Drawing.Point(1005, 5);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(46, 18);
            this.status.TabIndex = 8;
            this.status.Text = "Status";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yearEffective
            // 
            this.yearEffective.AutoSize = true;
            this.yearEffective.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.yearEffective.ForeColor = System.Drawing.Color.Black;
            this.yearEffective.Location = new System.Drawing.Point(894, 5);
            this.yearEffective.Name = "yearEffective";
            this.yearEffective.Size = new System.Drawing.Size(92, 18);
            this.yearEffective.TabIndex = 9;
            this.yearEffective.Text = "Year Effective";
            this.yearEffective.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // excessAmount
            // 
            this.excessAmount.AutoSize = true;
            this.excessAmount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.excessAmount.ForeColor = System.Drawing.Color.Black;
            this.excessAmount.Location = new System.Drawing.Point(734, 5);
            this.excessAmount.Name = "excessAmount";
            this.excessAmount.Size = new System.Drawing.Size(99, 18);
            this.excessAmount.TabIndex = 10;
            this.excessAmount.Text = "Excess amount";
            this.excessAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.amount.ForeColor = System.Drawing.Color.Black;
            this.amount.Location = new System.Drawing.Point(615, 5);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(58, 18);
            this.amount.TabIndex = 11;
            this.amount.Text = "Amount";
            this.amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.percentage.ForeColor = System.Drawing.Color.Black;
            this.percentage.Location = new System.Drawing.Point(476, 5);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(78, 18);
            this.percentage.TabIndex = 12;
            this.percentage.Text = "Percentage";
            this.percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // annualSalaryValue
            // 
            this.annualSalaryValue.AutoSize = true;
            this.annualSalaryValue.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.annualSalaryValue.ForeColor = System.Drawing.Color.Black;
            this.annualSalaryValue.Location = new System.Drawing.Point(285, 5);
            this.annualSalaryValue.Name = "annualSalaryValue";
            this.annualSalaryValue.Size = new System.Drawing.Size(130, 18);
            this.annualSalaryValue.TabIndex = 13;
            this.annualSalaryValue.Text = "Annual Salary Value";
            this.annualSalaryValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.description.ForeColor = System.Drawing.Color.Black;
            this.description.Location = new System.Drawing.Point(4, 5);
            this.description.MaximumSize = new System.Drawing.Size(280, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(79, 18);
            this.description.TabIndex = 14;
            this.description.Text = "Description";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // annualSalaryIndicator
            // 
            this.annualSalaryIndicator.AutoSize = true;
            this.annualSalaryIndicator.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.annualSalaryIndicator.ForeColor = System.Drawing.Color.Black;
            this.annualSalaryIndicator.Location = new System.Drawing.Point(355, 7);
            this.annualSalaryIndicator.Name = "annualSalaryIndicator";
            this.annualSalaryIndicator.Size = new System.Drawing.Size(13, 18);
            this.annualSalaryIndicator.TabIndex = 66;
            this.annualSalaryIndicator.Text = "-";
            this.annualSalaryIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.annualSalaryIndicator.Visible = false;
            // 
            // rateStatusChoices
            // 
            this.rateStatusChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rateStatusChoices.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.rateStatusChoices.FormattingEnabled = true;
            this.rateStatusChoices.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.rateStatusChoices.Location = new System.Drawing.Point(1005, 4);
            this.rateStatusChoices.Name = "rateStatusChoices";
            this.rateStatusChoices.Size = new System.Drawing.Size(102, 23);
            this.rateStatusChoices.TabIndex = 67;
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
            this.cancelBtn.Location = new System.Drawing.Point(1196, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(81, 24);
            this.cancelBtn.TabIndex = 60;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // descriptionBox
            // 
            this.descriptionBox.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionBox.BorderColor = System.Drawing.Color.DimGray;
            this.descriptionBox.BorderFocusColor = System.Drawing.Color.Black;
            this.descriptionBox.BorderRadius = 0;
            this.descriptionBox.BorderSize = 2;
            this.descriptionBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionBox.ForeColor = System.Drawing.Color.Black;
            this.descriptionBox.Location = new System.Drawing.Point(7, 2);
            this.descriptionBox.Multiline = false;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.descriptionBox.PasswordChar = false;
            this.descriptionBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.descriptionBox.PlaceholderText = "";
            this.descriptionBox.Size = new System.Drawing.Size(272, 30);
            this.descriptionBox.TabIndex = 64;
            this.descriptionBox.Texts = "";
            this.descriptionBox.UnderlinedStyle = false;
            this.descriptionBox.Visible = false;
            // 
            // fromAnnualBox
            // 
            this.fromAnnualBox.BackColor = System.Drawing.SystemColors.Window;
            this.fromAnnualBox.BorderColor = System.Drawing.Color.DimGray;
            this.fromAnnualBox.BorderFocusColor = System.Drawing.Color.Black;
            this.fromAnnualBox.BorderRadius = 0;
            this.fromAnnualBox.BorderSize = 2;
            this.fromAnnualBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromAnnualBox.ForeColor = System.Drawing.Color.Black;
            this.fromAnnualBox.Location = new System.Drawing.Point(285, 2);
            this.fromAnnualBox.Multiline = false;
            this.fromAnnualBox.Name = "fromAnnualBox";
            this.fromAnnualBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.fromAnnualBox.PasswordChar = false;
            this.fromAnnualBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.fromAnnualBox.PlaceholderText = "";
            this.fromAnnualBox.Size = new System.Drawing.Size(67, 30);
            this.fromAnnualBox.TabIndex = 65;
            this.fromAnnualBox.Texts = "";
            this.fromAnnualBox.UnderlinedStyle = false;
            this.fromAnnualBox.Visible = false;
            // 
            // toAnnualBox
            // 
            this.toAnnualBox.BackColor = System.Drawing.SystemColors.Window;
            this.toAnnualBox.BorderColor = System.Drawing.Color.DimGray;
            this.toAnnualBox.BorderFocusColor = System.Drawing.Color.Black;
            this.toAnnualBox.BorderRadius = 0;
            this.toAnnualBox.BorderSize = 2;
            this.toAnnualBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toAnnualBox.ForeColor = System.Drawing.Color.Black;
            this.toAnnualBox.Location = new System.Drawing.Point(371, 2);
            this.toAnnualBox.Multiline = false;
            this.toAnnualBox.Name = "toAnnualBox";
            this.toAnnualBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.toAnnualBox.PasswordChar = false;
            this.toAnnualBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.toAnnualBox.PlaceholderText = "";
            this.toAnnualBox.Size = new System.Drawing.Size(67, 30);
            this.toAnnualBox.TabIndex = 65;
            this.toAnnualBox.Texts = "";
            this.toAnnualBox.UnderlinedStyle = false;
            this.toAnnualBox.Visible = false;
            // 
            // percentageBox
            // 
            this.percentageBox.BackColor = System.Drawing.SystemColors.Window;
            this.percentageBox.BorderColor = System.Drawing.Color.DimGray;
            this.percentageBox.BorderFocusColor = System.Drawing.Color.Black;
            this.percentageBox.BorderRadius = 0;
            this.percentageBox.BorderSize = 2;
            this.percentageBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageBox.ForeColor = System.Drawing.Color.Black;
            this.percentageBox.Location = new System.Drawing.Point(476, 2);
            this.percentageBox.Multiline = false;
            this.percentageBox.Name = "percentageBox";
            this.percentageBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.percentageBox.PasswordChar = false;
            this.percentageBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.percentageBox.PlaceholderText = "";
            this.percentageBox.Size = new System.Drawing.Size(67, 30);
            this.percentageBox.TabIndex = 65;
            this.percentageBox.Texts = "";
            this.percentageBox.UnderlinedStyle = false;
            this.percentageBox.Visible = false;
            // 
            // amountBox
            // 
            this.amountBox.BackColor = System.Drawing.SystemColors.Window;
            this.amountBox.BorderColor = System.Drawing.Color.DimGray;
            this.amountBox.BorderFocusColor = System.Drawing.Color.Black;
            this.amountBox.BorderRadius = 0;
            this.amountBox.BorderSize = 2;
            this.amountBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountBox.ForeColor = System.Drawing.Color.Black;
            this.amountBox.Location = new System.Drawing.Point(615, 2);
            this.amountBox.Multiline = false;
            this.amountBox.Name = "amountBox";
            this.amountBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.amountBox.PasswordChar = false;
            this.amountBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.amountBox.PlaceholderText = "";
            this.amountBox.Size = new System.Drawing.Size(113, 30);
            this.amountBox.TabIndex = 65;
            this.amountBox.Texts = "";
            this.amountBox.UnderlinedStyle = false;
            this.amountBox.Visible = false;
            // 
            // excessAmountBox
            // 
            this.excessAmountBox.BackColor = System.Drawing.SystemColors.Window;
            this.excessAmountBox.BorderColor = System.Drawing.Color.DimGray;
            this.excessAmountBox.BorderFocusColor = System.Drawing.Color.Black;
            this.excessAmountBox.BorderRadius = 0;
            this.excessAmountBox.BorderSize = 2;
            this.excessAmountBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excessAmountBox.ForeColor = System.Drawing.Color.Black;
            this.excessAmountBox.Location = new System.Drawing.Point(734, 2);
            this.excessAmountBox.Multiline = false;
            this.excessAmountBox.Name = "excessAmountBox";
            this.excessAmountBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.excessAmountBox.PasswordChar = false;
            this.excessAmountBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.excessAmountBox.PlaceholderText = "";
            this.excessAmountBox.Size = new System.Drawing.Size(154, 30);
            this.excessAmountBox.TabIndex = 65;
            this.excessAmountBox.Texts = "";
            this.excessAmountBox.UnderlinedStyle = false;
            this.excessAmountBox.Visible = false;
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
            this.modifyBtn.Location = new System.Drawing.Point(1113, 2);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(81, 24);
            this.modifyBtn.TabIndex = 61;
            this.modifyBtn.Text = "Modify Rate";
            this.modifyBtn.TextColor = System.Drawing.Color.White;
            this.modifyBtn.UseVisualStyleBackColor = false;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
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
            this.submitBtn.Location = new System.Drawing.Point(1113, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(81, 24);
            this.submitBtn.TabIndex = 63;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Visible = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // witholdingTaxUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.yearEffective);
            this.Controls.Add(this.excessAmount);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.percentage);
            this.Controls.Add(this.annualSalaryValue);
            this.Controls.Add(this.description);
            this.Controls.Add(this.rateStatusChoices);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.fromAnnualBox);
            this.Controls.Add(this.toAnnualBox);
            this.Controls.Add(this.annualSalaryIndicator);
            this.Controls.Add(this.percentageBox);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.excessAmountBox);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.submitBtn);
            this.Name = "witholdingTaxUC";
            this.Size = new System.Drawing.Size(1280, 35);
            this.Load += new System.EventHandler(this.witholdingTaxUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label yearEffective;
        private System.Windows.Forms.Label excessAmount;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.Label annualSalaryValue;
        private System.Windows.Forms.Label description;
        private Custom.buttonDesign cancelBtn;
        private Custom.buttonDesign modifyBtn;
        private Custom.buttonDesign submitBtn;
        private Custom.customTextBox2 descriptionBox;
        private Custom.customTextBox2 fromAnnualBox;
        private Custom.customTextBox2 toAnnualBox;
        private System.Windows.Forms.Label annualSalaryIndicator;
        private Custom.customTextBox2 percentageBox;
        private Custom.customTextBox2 amountBox;
        private Custom.customTextBox2 excessAmountBox;
        private System.Windows.Forms.ComboBox rateStatusChoices;
    }
}
