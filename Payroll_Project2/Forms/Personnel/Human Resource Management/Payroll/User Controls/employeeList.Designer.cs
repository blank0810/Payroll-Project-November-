namespace Payroll_Project2.Forms.Personnel.Payroll.User_Controls
{
    partial class employeeList
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
            this.departmentLabel = new System.Windows.Forms.Label();
            this.generateBtn = new Payroll_Project2.Custom.buttonDesign();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // empPicture
            // 
            this.empPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.empPicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.empPicture.BorderColor = System.Drawing.Color.RoyalBlue;
            this.empPicture.BorderColor2 = System.Drawing.Color.GreenYellow;
            this.empPicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.empPicture.BorderSize = 1;
            this.empPicture.GradientAngle = 50F;
            this.empPicture.Image = global::Payroll_Project2.Properties.Resources.Screenshot_112;
            this.empPicture.Location = new System.Drawing.Point(1, 1);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(40, 40);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 5;
            this.empPicture.TabStop = false;
            // 
            // empid
            // 
            this.empid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.empid.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.empid.Location = new System.Drawing.Point(43, 24);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 18);
            this.empid.TabIndex = 4;
            this.empid.Text = "1001";
            // 
            // empName
            // 
            this.empName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.empName.Location = new System.Drawing.Point(43, 5);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(104, 19);
            this.empName.TabIndex = 3;
            this.empName.Text = "Killua Zoldyck";
            // 
            // departmentLabel
            // 
            this.departmentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.departmentLabel.Location = new System.Drawing.Point(347, 13);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(141, 19);
            this.departmentLabel.TabIndex = 6;
            this.departmentLabel.Text = "Computer Engineer";
            // 
            // generateBtn
            // 
            this.generateBtn.AutoSize = true;
            this.generateBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.generateBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.generateBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.generateBtn.BorderRadius = 5;
            this.generateBtn.BorderSize = 0;
            this.generateBtn.FlatAppearance.BorderSize = 0;
            this.generateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.generateBtn.ForeColor = System.Drawing.Color.White;
            this.generateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.generateBtn.Location = new System.Drawing.Point(824, 9);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(134, 29);
            this.generateBtn.TabIndex = 7;
            this.generateBtn.Text = "Generate Payslip";
            this.generateBtn.TextColor = System.Drawing.Color.White;
            this.generateBtn.UseVisualStyleBackColor = false;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // employeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.empPicture);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.empName);
            this.Name = "employeeList";
            this.Size = new System.Drawing.Size(966, 46);
            this.Load += new System.EventHandler(this.employeeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.customPictureBox empPicture;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Label departmentLabel;
        private Custom.buttonDesign generateBtn;
    }
}
