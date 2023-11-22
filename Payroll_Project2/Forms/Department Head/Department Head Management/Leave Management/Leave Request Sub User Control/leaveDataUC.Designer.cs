namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_Request_Sub_User_Control
{
    partial class leaveDataUC
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
            this.employeeName = new System.Windows.Forms.Label();
            this.employeeId = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
            this.leaveType = new System.Windows.Forms.Label();
            this.dateCoverage = new System.Windows.Forms.Label();
            this.applicationNumber = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.endorseBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.employeeName.ForeColor = System.Drawing.Color.Black;
            this.employeeName.Location = new System.Drawing.Point(6, 4);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(130, 19);
            this.employeeName.TabIndex = 5;
            this.employeeName.Text = "{Employee name}";
            this.employeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeId
            // 
            this.employeeId.AutoSize = true;
            this.employeeId.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.employeeId.ForeColor = System.Drawing.Color.DimGray;
            this.employeeId.Location = new System.Drawing.Point(6, 26);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(91, 17);
            this.employeeId.TabIndex = 5;
            this.employeeId.Text = "{Employee Id}";
            this.employeeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateFiled
            // 
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.dateFiled.ForeColor = System.Drawing.Color.Black;
            this.dateFiled.Location = new System.Drawing.Point(614, 15);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(89, 19);
            this.dateFiled.TabIndex = 5;
            this.dateFiled.Text = "{Date Filed}";
            this.dateFiled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leaveType
            // 
            this.leaveType.AutoSize = true;
            this.leaveType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.leaveType.ForeColor = System.Drawing.Color.Black;
            this.leaveType.Location = new System.Drawing.Point(810, 15);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(95, 19);
            this.leaveType.TabIndex = 5;
            this.leaveType.Text = "{Leave type}";
            this.leaveType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateCoverage
            // 
            this.dateCoverage.AutoSize = true;
            this.dateCoverage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.dateCoverage.ForeColor = System.Drawing.Color.Black;
            this.dateCoverage.Location = new System.Drawing.Point(1012, 15);
            this.dateCoverage.Name = "dateCoverage";
            this.dateCoverage.Size = new System.Drawing.Size(119, 19);
            this.dateCoverage.TabIndex = 5;
            this.dateCoverage.Text = "{Date coverage}";
            this.dateCoverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // applicationNumber
            // 
            this.applicationNumber.AutoSize = true;
            this.applicationNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.applicationNumber.ForeColor = System.Drawing.Color.Black;
            this.applicationNumber.Location = new System.Drawing.Point(377, 15);
            this.applicationNumber.Name = "applicationNumber";
            this.applicationNumber.Size = new System.Drawing.Size(121, 19);
            this.applicationNumber.TabIndex = 5;
            this.applicationNumber.Text = "{Application no}";
            this.applicationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.Transparent;
            this.viewBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.viewBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 2;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.Black;
            this.viewBtn.Location = new System.Drawing.Point(1297, 11);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(84, 29);
            this.viewBtn.TabIndex = 6;
            this.viewBtn.Text = "View";
            this.viewBtn.TextColor = System.Drawing.Color.Black;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // endorseBtn
            // 
            this.endorseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.endorseBtn.AutoSize = true;
            this.endorseBtn.BackColor = System.Drawing.Color.Transparent;
            this.endorseBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.endorseBtn.BorderColor = System.Drawing.Color.ForestGreen;
            this.endorseBtn.BorderRadius = 5;
            this.endorseBtn.BorderSize = 2;
            this.endorseBtn.FlatAppearance.BorderSize = 0;
            this.endorseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endorseBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.endorseBtn.ForeColor = System.Drawing.Color.Black;
            this.endorseBtn.Location = new System.Drawing.Point(1207, 11);
            this.endorseBtn.Name = "endorseBtn";
            this.endorseBtn.Size = new System.Drawing.Size(84, 29);
            this.endorseBtn.TabIndex = 6;
            this.endorseBtn.Text = "Endorse";
            this.endorseBtn.TextColor = System.Drawing.Color.Black;
            this.endorseBtn.UseVisualStyleBackColor = false;
            this.endorseBtn.Click += new System.EventHandler(this.endorseBtn_Click);
            // 
            // leaveDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.endorseBtn);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.employeeId);
            this.Controls.Add(this.dateCoverage);
            this.Controls.Add(this.leaveType);
            this.Controls.Add(this.applicationNumber);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.employeeName);
            this.Name = "leaveDataUC";
            this.Size = new System.Drawing.Size(1385, 48);
            this.Load += new System.EventHandler(this.leaveDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.Label employeeId;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label leaveType;
        private System.Windows.Forms.Label dateCoverage;
        private System.Windows.Forms.Label applicationNumber;
        private Custom.buttonDesign viewBtn;
        private Custom.buttonDesign endorseBtn;
    }
}
