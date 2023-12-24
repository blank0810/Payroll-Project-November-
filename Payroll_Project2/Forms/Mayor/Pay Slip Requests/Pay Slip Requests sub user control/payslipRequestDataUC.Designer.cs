namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control
{
    partial class payslipRequestDataUC
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
            this.departmentName = new System.Windows.Forms.Label();
            this.requestCount = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.departmentLogo = new Payroll_Project2.Custom.customPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.departmentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentName
            // 
            this.departmentName.AutoSize = true;
            this.departmentName.BackColor = System.Drawing.Color.White;
            this.departmentName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.departmentName.ForeColor = System.Drawing.Color.Black;
            this.departmentName.Location = new System.Drawing.Point(50, 13);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(380, 18);
            this.departmentName.TabIndex = 5;
            this.departmentName.Text = "Department of Human Settlements and Urban Development";
            // 
            // requestCount
            // 
            this.requestCount.AutoSize = true;
            this.requestCount.BackColor = System.Drawing.Color.White;
            this.requestCount.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.requestCount.ForeColor = System.Drawing.Color.Black;
            this.requestCount.Location = new System.Drawing.Point(584, 13);
            this.requestCount.Name = "requestCount";
            this.requestCount.Size = new System.Drawing.Size(15, 18);
            this.requestCount.TabIndex = 5;
            this.requestCount.Text = "1";
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderColor = System.Drawing.Color.Navy;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(818, 7);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(156, 29);
            this.viewBtn.TabIndex = 7;
            this.viewBtn.Text = "View Employee Lists";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
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
            this.departmentLogo.Location = new System.Drawing.Point(3, 2);
            this.departmentLogo.Name = "departmentLogo";
            this.departmentLogo.Size = new System.Drawing.Size(40, 40);
            this.departmentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.departmentLogo.TabIndex = 6;
            this.departmentLogo.TabStop = false;
            // 
            // payslipRequestDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.departmentLogo);
            this.Controls.Add(this.requestCount);
            this.Controls.Add(this.departmentName);
            this.Name = "payslipRequestDataUC";
            this.Size = new System.Drawing.Size(983, 46);
            this.Load += new System.EventHandler(this.payslipRequestDataUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.customPictureBox departmentLogo;
        private System.Windows.Forms.Label departmentName;
        private System.Windows.Forms.Label requestCount;
        private Custom.buttonDesign viewBtn;
    }
}
