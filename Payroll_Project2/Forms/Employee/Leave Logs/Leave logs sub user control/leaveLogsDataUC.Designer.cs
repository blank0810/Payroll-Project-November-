namespace Payroll_Project2.Forms.Employee.Leave_Logs.Leave_logs_sub_user_control
{
    partial class leaveLogsDataUC
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
            this.status = new System.Windows.Forms.Label();
            this.dateCoverage = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
            this.leaveType = new System.Windows.Forms.Label();
            this.applicationNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(1210, 5);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(116, 29);
            this.viewBtn.TabIndex = 14;
            this.viewBtn.Text = "View Details";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(1050, 10);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(64, 19);
            this.status.TabIndex = 9;
            this.status.Text = "{Status}";
            // 
            // dateCoverage
            // 
            this.dateCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateCoverage.AutoSize = true;
            this.dateCoverage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCoverage.Location = new System.Drawing.Point(825, 10);
            this.dateCoverage.Name = "dateCoverage";
            this.dateCoverage.Size = new System.Drawing.Size(119, 19);
            this.dateCoverage.TabIndex = 10;
            this.dateCoverage.Text = "{Date coverage}";
            // 
            // dateFiled
            // 
            this.dateFiled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFiled.Location = new System.Drawing.Point(544, 10);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(87, 19);
            this.dateFiled.TabIndex = 11;
            this.dateFiled.Text = "{Date filed}";
            // 
            // leaveType
            // 
            this.leaveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leaveType.AutoSize = true;
            this.leaveType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveType.Location = new System.Drawing.Point(340, 10);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(95, 19);
            this.leaveType.TabIndex = 12;
            this.leaveType.Text = "{Leave type}";
            // 
            // applicationNumber
            // 
            this.applicationNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.applicationNumber.AutoSize = true;
            this.applicationNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationNumber.Location = new System.Drawing.Point(4, 10);
            this.applicationNumber.Name = "applicationNumber";
            this.applicationNumber.Size = new System.Drawing.Size(157, 19);
            this.applicationNumber.TabIndex = 13;
            this.applicationNumber.Text = "{Application number}";
            // 
            // leaveLogsDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.dateCoverage);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.leaveType);
            this.Controls.Add(this.applicationNumber);
            this.Name = "leaveLogsDataUC";
            this.Size = new System.Drawing.Size(1338, 39);
            this.Load += new System.EventHandler(this.leaveLogsDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label dateCoverage;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label leaveType;
        private System.Windows.Forms.Label applicationNumber;
    }
}
