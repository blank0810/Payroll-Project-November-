namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_list_sub_user_control
{
    partial class leaveListDataUC
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
            this.applicationNumber = new System.Windows.Forms.Label();
            this.leaveType = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
            this.dateCoverage = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // applicationNumber
            // 
            this.applicationNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.applicationNumber.AutoSize = true;
            this.applicationNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationNumber.Location = new System.Drawing.Point(3, 9);
            this.applicationNumber.Name = "applicationNumber";
            this.applicationNumber.Size = new System.Drawing.Size(157, 19);
            this.applicationNumber.TabIndex = 7;
            this.applicationNumber.Text = "{Application number}";
            // 
            // leaveType
            // 
            this.leaveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leaveType.AutoSize = true;
            this.leaveType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveType.Location = new System.Drawing.Point(339, 9);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(95, 19);
            this.leaveType.TabIndex = 7;
            this.leaveType.Text = "{Leave type}";
            // 
            // dateFiled
            // 
            this.dateFiled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFiled.Location = new System.Drawing.Point(585, 9);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(87, 19);
            this.dateFiled.TabIndex = 7;
            this.dateFiled.Text = "{Date filed}";
            // 
            // dateCoverage
            // 
            this.dateCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateCoverage.AutoSize = true;
            this.dateCoverage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCoverage.Location = new System.Drawing.Point(824, 9);
            this.dateCoverage.Name = "dateCoverage";
            this.dateCoverage.Size = new System.Drawing.Size(119, 19);
            this.dateCoverage.TabIndex = 7;
            this.dateCoverage.Text = "{Date coverage}";
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
            this.viewBtn.Location = new System.Drawing.Point(1215, 4);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(116, 29);
            this.viewBtn.TabIndex = 8;
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
            this.status.Location = new System.Drawing.Point(1053, 9);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(64, 19);
            this.status.TabIndex = 7;
            this.status.Text = "{Status}";
            // 
            // leaveListDataUC
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
            this.Name = "leaveListDataUC";
            this.Size = new System.Drawing.Size(1343, 39);
            this.Load += new System.EventHandler(this.leaveListDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label applicationNumber;
        private System.Windows.Forms.Label leaveType;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label dateCoverage;
        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label status;
    }
}
