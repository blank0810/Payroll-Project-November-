namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.File_leave
{
    partial class fileLeaveModal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cancelBtn = new Payroll_Project2.Custom.buttonDesign();
            this.submitBtn = new Payroll_Project2.Custom.buttonDesign();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.leaveDetails = new Payroll_Project2.Custom.customTextBox2();
            this.endingDate = new Payroll_Project2.Custom.customDateTime();
            this.startingDate = new Payroll_Project2.Custom.customDateTime();
            this.leaveType = new System.Windows.Forms.ComboBox();
            this.leaveCreditsBalance = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 10);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 10);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(590, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 357);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 347);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.titleLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(580, 36);
            this.panel5.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(6, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(89, 21);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "New Leave";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.cancelBtn);
            this.panel6.Controls.Add(this.submitBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(10, 316);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(580, 41);
            this.panel6.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.BackColor = System.Drawing.Color.DarkRed;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.DarkRed;
            this.cancelBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cancelBtn.BorderRadius = 5;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(405, 6);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(85, 29);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Discard";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.AutoSize = true;
            this.submitBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.submitBtn.BorderRadius = 5;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(492, 5);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(85, 29);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "+Add Leave";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(10, 313);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(580, 3);
            this.panel7.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(10, 46);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(580, 3);
            this.panel8.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.leaveDetails);
            this.panel9.Controls.Add(this.endingDate);
            this.panel9.Controls.Add(this.startingDate);
            this.panel9.Controls.Add(this.leaveType);
            this.panel9.Controls.Add(this.leaveCreditsBalance);
            this.panel9.Controls.Add(this.employeeName);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(10, 49);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(580, 264);
            this.panel9.TabIndex = 5;
            // 
            // leaveDetails
            // 
            this.leaveDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leaveDetails.AutoSize = true;
            this.leaveDetails.BackColor = System.Drawing.SystemColors.Window;
            this.leaveDetails.BorderColor = System.Drawing.Color.DimGray;
            this.leaveDetails.BorderFocusColor = System.Drawing.Color.Pink;
            this.leaveDetails.BorderRadius = 0;
            this.leaveDetails.BorderSize = 1;
            this.leaveDetails.Font = new System.Drawing.Font("Calibri", 11F);
            this.leaveDetails.ForeColor = System.Drawing.Color.DimGray;
            this.leaveDetails.Location = new System.Drawing.Point(253, 188);
            this.leaveDetails.Multiline = true;
            this.leaveDetails.Name = "leaveDetails";
            this.leaveDetails.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.leaveDetails.PasswordChar = false;
            this.leaveDetails.PlaceholderColor = System.Drawing.Color.DimGray;
            this.leaveDetails.PlaceholderText = "";
            this.leaveDetails.Size = new System.Drawing.Size(229, 34);
            this.leaveDetails.TabIndex = 7;
            this.leaveDetails.Texts = "";
            this.leaveDetails.UnderlinedStyle = false;
            // 
            // endingDate
            // 
            this.endingDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endingDate.BorderColor = System.Drawing.Color.Black;
            this.endingDate.BorderSize = 1;
            this.endingDate.CustomFormat = "MMMM dd, yyyy";
            this.endingDate.Font = new System.Drawing.Font("Calibri", 11F);
            this.endingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endingDate.Location = new System.Drawing.Point(253, 146);
            this.endingDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.endingDate.Name = "endingDate";
            this.endingDate.Size = new System.Drawing.Size(229, 35);
            this.endingDate.SkinColor = System.Drawing.Color.White;
            this.endingDate.TabIndex = 6;
            this.endingDate.TextColor = System.Drawing.Color.Black;
            // 
            // startingDate
            // 
            this.startingDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startingDate.BorderColor = System.Drawing.Color.Black;
            this.startingDate.BorderSize = 1;
            this.startingDate.CustomFormat = "MMMM dd, yyyy";
            this.startingDate.Font = new System.Drawing.Font("Calibri", 11F);
            this.startingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startingDate.Location = new System.Drawing.Point(253, 104);
            this.startingDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.startingDate.Name = "startingDate";
            this.startingDate.Size = new System.Drawing.Size(229, 35);
            this.startingDate.SkinColor = System.Drawing.Color.White;
            this.startingDate.TabIndex = 6;
            this.startingDate.TextColor = System.Drawing.Color.Black;
            // 
            // leaveType
            // 
            this.leaveType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leaveType.Font = new System.Drawing.Font("Calibri", 11F);
            this.leaveType.FormattingEnabled = true;
            this.leaveType.Location = new System.Drawing.Point(253, 40);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(229, 26);
            this.leaveType.TabIndex = 5;
            // 
            // leaveCreditsBalance
            // 
            this.leaveCreditsBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leaveCreditsBalance.AutoSize = true;
            this.leaveCreditsBalance.Font = new System.Drawing.Font("Calibri", 11F);
            this.leaveCreditsBalance.ForeColor = System.Drawing.Color.Black;
            this.leaveCreditsBalance.Location = new System.Drawing.Point(253, 76);
            this.leaveCreditsBalance.Name = "leaveCreditsBalance";
            this.leaveCreditsBalance.Size = new System.Drawing.Size(33, 18);
            this.leaveCreditsBalance.TabIndex = 4;
            this.leaveCreditsBalance.Text = "-----";
            // 
            // employeeName
            // 
            this.employeeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 11F);
            this.employeeName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.employeeName.Location = new System.Drawing.Point(253, 12);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(118, 18);
            this.employeeName.TabIndex = 4;
            this.employeeName.Text = "{Employee name}";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(144, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Leave details:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(150, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ending date:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(143, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Starting date:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(78, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Leave credits available:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(158, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Leave type:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(165, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Employee:";
            // 
            // fileLeaveModal
            // 
            this.AcceptButton = this.submitBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(600, 367);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "fileLeaveModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filing a leave request";
            this.Load += new System.EventHandler(this.fileLeaveModal_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private Custom.buttonDesign submitBtn;
        private Custom.buttonDesign cancelBtn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.ComboBox leaveType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label leaveCreditsBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Custom.customDateTime startingDate;
        private System.Windows.Forms.Label label7;
        private Custom.customDateTime endingDate;
        private System.Windows.Forms.Label label8;
        private Custom.customTextBox2 leaveDetails;
    }
}