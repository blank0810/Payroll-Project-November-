namespace Payroll_Project2.Forms.Mayor.Dashboard.Dashboard_User_Control
{
    partial class departmentDataUC
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
            this.regularCount = new System.Windows.Forms.Label();
            this.joCount = new System.Windows.Forms.Label();
            this.totalEmployeeCount = new System.Windows.Forms.Label();
            this.detailsBtn = new Payroll_Project2.Custom.buttonDesign();
            this.departmentName = new System.Windows.Forms.Label();
            this.departmentLogo = new Payroll_Project2.Custom.customPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.departmentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // regularCount
            // 
            this.regularCount.AutoSize = true;
            this.regularCount.BackColor = System.Drawing.Color.White;
            this.regularCount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.regularCount.ForeColor = System.Drawing.Color.Black;
            this.regularCount.Location = new System.Drawing.Point(323, 10);
            this.regularCount.MaximumSize = new System.Drawing.Size(220, 0);
            this.regularCount.Name = "regularCount";
            this.regularCount.Size = new System.Drawing.Size(105, 18);
            this.regularCount.TabIndex = 3;
            this.regularCount.Text = "{Regular Count}";
            // 
            // joCount
            // 
            this.joCount.AutoSize = true;
            this.joCount.BackColor = System.Drawing.Color.White;
            this.joCount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.joCount.ForeColor = System.Drawing.Color.Black;
            this.joCount.Location = new System.Drawing.Point(480, 10);
            this.joCount.MaximumSize = new System.Drawing.Size(220, 0);
            this.joCount.Name = "joCount";
            this.joCount.Size = new System.Drawing.Size(73, 18);
            this.joCount.TabIndex = 3;
            this.joCount.Text = "{JO Count}";
            // 
            // totalEmployeeCount
            // 
            this.totalEmployeeCount.AutoSize = true;
            this.totalEmployeeCount.BackColor = System.Drawing.Color.White;
            this.totalEmployeeCount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.totalEmployeeCount.ForeColor = System.Drawing.Color.Black;
            this.totalEmployeeCount.Location = new System.Drawing.Point(630, 10);
            this.totalEmployeeCount.MaximumSize = new System.Drawing.Size(220, 0);
            this.totalEmployeeCount.Name = "totalEmployeeCount";
            this.totalEmployeeCount.Size = new System.Drawing.Size(88, 18);
            this.totalEmployeeCount.TabIndex = 3;
            this.totalEmployeeCount.Text = "{Total Count}";
            // 
            // detailsBtn
            // 
            this.detailsBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.detailsBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.detailsBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.detailsBtn.BorderRadius = 5;
            this.detailsBtn.BorderSize = 0;
            this.detailsBtn.FlatAppearance.BorderSize = 0;
            this.detailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsBtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.detailsBtn.ForeColor = System.Drawing.Color.White;
            this.detailsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.detailsBtn.Location = new System.Drawing.Point(791, 4);
            this.detailsBtn.Name = "detailsBtn";
            this.detailsBtn.Size = new System.Drawing.Size(69, 29);
            this.detailsBtn.TabIndex = 5;
            this.detailsBtn.Text = "Details";
            this.detailsBtn.TextColor = System.Drawing.Color.White;
            this.detailsBtn.UseVisualStyleBackColor = false;
            this.detailsBtn.Click += new System.EventHandler(this.detailsBtn_Click);
            // 
            // departmentName
            // 
            this.departmentName.AutoSize = true;
            this.departmentName.BackColor = System.Drawing.Color.White;
            this.departmentName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.departmentName.ForeColor = System.Drawing.Color.Black;
            this.departmentName.Location = new System.Drawing.Point(49, 5);
            this.departmentName.MaximumSize = new System.Drawing.Size(250, 0);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(228, 36);
            this.departmentName.TabIndex = 3;
            this.departmentName.Text = "Department of Human Settlements and Urban Development";
            // 
            // departmentLogo
            // 
            this.departmentLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.departmentLogo.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.departmentLogo.BorderColor = System.Drawing.Color.RoyalBlue;
            this.departmentLogo.BorderColor2 = System.Drawing.Color.GreenYellow;
            this.departmentLogo.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.departmentLogo.BorderSize = 1;
            this.departmentLogo.GradientAngle = 50F;
            this.departmentLogo.Image = global::Payroll_Project2.Properties.Resources.Screenshot_112;
            this.departmentLogo.Location = new System.Drawing.Point(4, 1);
            this.departmentLogo.Name = "departmentLogo";
            this.departmentLogo.Size = new System.Drawing.Size(40, 40);
            this.departmentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.departmentLogo.TabIndex = 4;
            this.departmentLogo.TabStop = false;
            // 
            // departmentDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.detailsBtn);
            this.Controls.Add(this.departmentLogo);
            this.Controls.Add(this.totalEmployeeCount);
            this.Controls.Add(this.joCount);
            this.Controls.Add(this.regularCount);
            this.Controls.Add(this.departmentName);
            this.Name = "departmentDataUC";
            this.Size = new System.Drawing.Size(863, 46);
            this.Load += new System.EventHandler(this.departmentDataUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label regularCount;
        private System.Windows.Forms.Label joCount;
        private System.Windows.Forms.Label totalEmployeeCount;
        private Custom.buttonDesign detailsBtn;
        private System.Windows.Forms.Label departmentName;
        private Custom.customPictureBox departmentLogo;
    }
}
