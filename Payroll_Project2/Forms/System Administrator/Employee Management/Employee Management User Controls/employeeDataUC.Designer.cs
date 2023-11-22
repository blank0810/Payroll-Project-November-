namespace Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_User_Controls
{
    partial class employeeDataUC
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.empPicture = new Payroll_Project2.Custom.customPictureBox();
            this.empid = new System.Windows.Forms.Label();
            this.empName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.empStatus = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jobDesc = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.modifyBtn = new Payroll_Project2.Custom.buttonDesign();
            this.detailsBtn = new Payroll_Project2.Custom.buttonDesign();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.empPicture);
            this.panel2.Controls.Add(this.empid);
            this.panel2.Controls.Add(this.empName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 42);
            this.panel2.TabIndex = 3;
            // 
            // empPicture
            // 
            this.empPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.empPicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.empPicture.BorderColor = System.Drawing.Color.RoyalBlue;
            this.empPicture.BorderColor2 = System.Drawing.Color.GreenYellow;
            this.empPicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.empPicture.BorderSize = 1;
            this.empPicture.GradientAngle = 50F;
            this.empPicture.Image = global::Payroll_Project2.Properties.Resources.Screenshot_112;
            this.empPicture.Location = new System.Drawing.Point(4, 0);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(40, 40);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 2;
            this.empPicture.TabStop = false;
            // 
            // empid
            // 
            this.empid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empid.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.empid.Location = new System.Drawing.Point(46, 23);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 17);
            this.empid.TabIndex = 1;
            this.empid.Text = "1001";
            // 
            // empName
            // 
            this.empName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empName.Location = new System.Drawing.Point(46, 4);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(110, 21);
            this.empName.TabIndex = 0;
            this.empName.Text = "Killua Zoldyck";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.empStatus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(327, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 42);
            this.panel3.TabIndex = 4;
            // 
            // empStatus
            // 
            this.empStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.empStatus.AutoSize = true;
            this.empStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.empStatus.Location = new System.Drawing.Point(1, 10);
            this.empStatus.Name = "empStatus";
            this.empStatus.Size = new System.Drawing.Size(62, 20);
            this.empStatus.TabIndex = 1;
            this.empStatus.Text = "Regular";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.departmentLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(508, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 42);
            this.panel4.TabIndex = 5;
            // 
            // departmentLabel
            // 
            this.departmentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.departmentLabel.Location = new System.Drawing.Point(-1, 10);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(142, 20);
            this.departmentLabel.TabIndex = 2;
            this.departmentLabel.Text = "Computer Engineer";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.jobDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(762, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 42);
            this.panel1.TabIndex = 8;
            // 
            // jobDesc
            // 
            this.jobDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.jobDesc.AutoSize = true;
            this.jobDesc.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.jobDesc.Location = new System.Drawing.Point(-2, 10);
            this.jobDesc.Name = "jobDesc";
            this.jobDesc.Size = new System.Drawing.Size(142, 20);
            this.jobDesc.TabIndex = 2;
            this.jobDesc.Text = "Computer Engineer";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.modifyBtn);
            this.panel6.Controls.Add(this.detailsBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(975, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(145, 42);
            this.panel6.TabIndex = 9;
            // 
            // modifyBtn
            // 
            this.modifyBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.modifyBtn.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.modifyBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.modifyBtn.BorderRadius = 10;
            this.modifyBtn.BorderSize = 0;
            this.modifyBtn.FlatAppearance.BorderSize = 0;
            this.modifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.Color.White;
            this.modifyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modifyBtn.Location = new System.Drawing.Point(3, 7);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(69, 29);
            this.modifyBtn.TabIndex = 1;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.TextColor = System.Drawing.Color.White;
            this.modifyBtn.UseVisualStyleBackColor = false;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // detailsBtn
            // 
            this.detailsBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.detailsBtn.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.detailsBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.detailsBtn.BorderRadius = 10;
            this.detailsBtn.BorderSize = 0;
            this.detailsBtn.FlatAppearance.BorderSize = 0;
            this.detailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsBtn.ForeColor = System.Drawing.Color.White;
            this.detailsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.detailsBtn.Location = new System.Drawing.Point(72, 7);
            this.detailsBtn.Name = "detailsBtn";
            this.detailsBtn.Size = new System.Drawing.Size(69, 29);
            this.detailsBtn.TabIndex = 1;
            this.detailsBtn.Text = "Details";
            this.detailsBtn.TextColor = System.Drawing.Color.White;
            this.detailsBtn.UseVisualStyleBackColor = false;
            this.detailsBtn.Click += new System.EventHandler(this.detailsBtn_Click);
            // 
            // employeeDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "employeeDataUC";
            this.Size = new System.Drawing.Size(1120, 42);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Custom.customPictureBox empPicture;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label empStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label jobDesc;
        private System.Windows.Forms.Panel panel6;
        private Custom.buttonDesign modifyBtn;
        private Custom.buttonDesign detailsBtn;
    }
}
