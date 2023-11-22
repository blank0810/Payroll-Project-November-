namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data
{
    partial class applicationForLeaveData
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
            this.empPicture = new Payroll_Project2.Custom.customPictureBox();
            this.empid = new System.Windows.Forms.Label();
            this.empName = new System.Windows.Forms.Label();
            this.applicationNumber = new System.Windows.Forms.Label();
            this.leaveType = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.proceedBtn = new Payroll_Project2.Custom.buttonDesign();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // empPicture
            // 
            this.empPicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.empPicture.BorderColor = System.Drawing.Color.RoyalBlue;
            this.empPicture.BorderColor2 = System.Drawing.Color.GreenYellow;
            this.empPicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.empPicture.BorderSize = 1;
            this.empPicture.GradientAngle = 50F;
            this.empPicture.Image = global::Payroll_Project2.Properties.Resources.Screenshot_112;
            this.empPicture.Location = new System.Drawing.Point(2, 2);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(40, 40);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 8;
            this.empPicture.TabStop = false;
            // 
            // empid
            // 
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.empid.ForeColor = System.Drawing.Color.DimGray;
            this.empid.Location = new System.Drawing.Point(47, 24);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 17);
            this.empid.TabIndex = 7;
            this.empid.Text = "1001";
            // 
            // empName
            // 
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.empName.Location = new System.Drawing.Point(47, 4);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(93, 18);
            this.empName.TabIndex = 6;
            this.empName.Text = "Killua Zoldyck";
            // 
            // applicationNumber
            // 
            this.applicationNumber.AutoSize = true;
            this.applicationNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.applicationNumber.Location = new System.Drawing.Point(327, 12);
            this.applicationNumber.Name = "applicationNumber";
            this.applicationNumber.Size = new System.Drawing.Size(15, 18);
            this.applicationNumber.TabIndex = 9;
            this.applicationNumber.Text = "1";
            this.applicationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leaveType
            // 
            this.leaveType.AutoSize = true;
            this.leaveType.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.leaveType.Location = new System.Drawing.Point(500, 12);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(85, 18);
            this.leaveType.TabIndex = 9;
            this.leaveType.Text = "{Leave type}";
            this.leaveType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFiled
            // 
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.dateFiled.Location = new System.Drawing.Point(650, 12);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(78, 18);
            this.dateFiled.TabIndex = 9;
            this.dateFiled.Text = "{Date filed}";
            this.dateFiled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.departmentLabel.Location = new System.Drawing.Point(794, 12);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(131, 18);
            this.departmentLabel.TabIndex = 10;
            this.departmentLabel.Text = "{Department name}";
            // 
            // viewBtn
            // 
            this.viewBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderColor = System.Drawing.Color.Navy;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(1110, 7);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(64, 29);
            this.viewBtn.TabIndex = 11;
            this.viewBtn.Text = "View";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // proceedBtn
            // 
            this.proceedBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.proceedBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.proceedBtn.BorderColor = System.Drawing.Color.Navy;
            this.proceedBtn.BorderRadius = 5;
            this.proceedBtn.BorderSize = 0;
            this.proceedBtn.FlatAppearance.BorderSize = 0;
            this.proceedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proceedBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.proceedBtn.ForeColor = System.Drawing.Color.White;
            this.proceedBtn.Location = new System.Drawing.Point(1040, 7);
            this.proceedBtn.Name = "proceedBtn";
            this.proceedBtn.Size = new System.Drawing.Size(64, 29);
            this.proceedBtn.TabIndex = 12;
            this.proceedBtn.Text = "Certify";
            this.proceedBtn.TextColor = System.Drawing.Color.White;
            this.proceedBtn.UseVisualStyleBackColor = false;
            this.proceedBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // applicationForLeaveData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.proceedBtn);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.leaveType);
            this.Controls.Add(this.applicationNumber);
            this.Controls.Add(this.empPicture);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.empName);
            this.Name = "applicationForLeaveData";
            this.Size = new System.Drawing.Size(1183, 42);
            this.Load += new System.EventHandler(this.applicationForLeaveData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.customPictureBox empPicture;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Label applicationNumber;
        private System.Windows.Forms.Label leaveType;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label departmentLabel;
        private Custom.buttonDesign viewBtn;
        private Custom.buttonDesign proceedBtn;
    }
}
