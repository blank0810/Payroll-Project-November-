namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_list_sub_user_control
{
    partial class leaveListEmployeeDataUC
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
            this.employeeID = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.vacationLeaveCreditsBalance = new System.Windows.Forms.Label();
            this.sickLeaveCreditsBalance = new System.Windows.Forms.Label();
            this.employeePicture = new Payroll_Project2.Custom.customPictureBox();
            this.leaveListBtn = new Payroll_Project2.Custom.buttonDesign();
            ((System.ComponentModel.ISupportInitialize)(this.employeePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeID
            // 
            this.employeeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.employeeID.AutoSize = true;
            this.employeeID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeID.ForeColor = System.Drawing.Color.DimGray;
            this.employeeID.Location = new System.Drawing.Point(41, 27);
            this.employeeID.Name = "employeeID";
            this.employeeID.Size = new System.Drawing.Size(35, 15);
            this.employeeID.TabIndex = 4;
            this.employeeID.Text = "1001";
            // 
            // employeeName
            // 
            this.employeeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeName.Location = new System.Drawing.Point(41, 4);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(104, 19);
            this.employeeName.TabIndex = 3;
            this.employeeName.Text = "Killua Zoldyck";
            // 
            // vacationLeaveCreditsBalance
            // 
            this.vacationLeaveCreditsBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vacationLeaveCreditsBalance.AutoSize = true;
            this.vacationLeaveCreditsBalance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vacationLeaveCreditsBalance.Location = new System.Drawing.Point(381, 15);
            this.vacationLeaveCreditsBalance.Name = "vacationLeaveCreditsBalance";
            this.vacationLeaveCreditsBalance.Size = new System.Drawing.Size(226, 19);
            this.vacationLeaveCreditsBalance.TabIndex = 6;
            this.vacationLeaveCreditsBalance.Text = "{Vacation leave credits balance}";
            // 
            // sickLeaveCreditsBalance
            // 
            this.sickLeaveCreditsBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sickLeaveCreditsBalance.AutoSize = true;
            this.sickLeaveCreditsBalance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sickLeaveCreditsBalance.Location = new System.Drawing.Point(713, 15);
            this.sickLeaveCreditsBalance.Name = "sickLeaveCreditsBalance";
            this.sickLeaveCreditsBalance.Size = new System.Drawing.Size(195, 19);
            this.sickLeaveCreditsBalance.TabIndex = 6;
            this.sickLeaveCreditsBalance.Text = "{Sick leave credits balance}";
            // 
            // employeePicture
            // 
            this.employeePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.employeePicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.employeePicture.BorderColor = System.Drawing.Color.RoyalBlue;
            this.employeePicture.BorderColor2 = System.Drawing.Color.GreenYellow;
            this.employeePicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.employeePicture.BorderSize = 1;
            this.employeePicture.GradientAngle = 50F;
            this.employeePicture.Image = global::Payroll_Project2.Properties.Resources.Screenshot_112;
            this.employeePicture.Location = new System.Drawing.Point(1, 3);
            this.employeePicture.Name = "employeePicture";
            this.employeePicture.Size = new System.Drawing.Size(40, 40);
            this.employeePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.employeePicture.TabIndex = 5;
            this.employeePicture.TabStop = false;
            // 
            // leaveListBtn
            // 
            this.leaveListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leaveListBtn.AutoSize = true;
            this.leaveListBtn.BackColor = System.Drawing.Color.Transparent;
            this.leaveListBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.leaveListBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.leaveListBtn.BorderRadius = 5;
            this.leaveListBtn.BorderSize = 2;
            this.leaveListBtn.FlatAppearance.BorderSize = 0;
            this.leaveListBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveListBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.leaveListBtn.ForeColor = System.Drawing.Color.Black;
            this.leaveListBtn.Location = new System.Drawing.Point(1056, 10);
            this.leaveListBtn.Name = "leaveListBtn";
            this.leaveListBtn.Size = new System.Drawing.Size(116, 29);
            this.leaveListBtn.TabIndex = 7;
            this.leaveListBtn.Text = "Leave Records";
            this.leaveListBtn.TextColor = System.Drawing.Color.Black;
            this.leaveListBtn.UseVisualStyleBackColor = false;
            this.leaveListBtn.Click += new System.EventHandler(this.leaveListBtn_Click);
            // 
            // leaveListEmployeeDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.leaveListBtn);
            this.Controls.Add(this.sickLeaveCreditsBalance);
            this.Controls.Add(this.vacationLeaveCreditsBalance);
            this.Controls.Add(this.employeePicture);
            this.Controls.Add(this.employeeID);
            this.Controls.Add(this.employeeName);
            this.Name = "leaveListEmployeeDataUC";
            this.Size = new System.Drawing.Size(1194, 48);
            this.Load += new System.EventHandler(this.leaveListEmployeeDataUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.customPictureBox employeePicture;
        private System.Windows.Forms.Label employeeID;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.Label vacationLeaveCreditsBalance;
        private System.Windows.Forms.Label sickLeaveCreditsBalance;
        private Custom.buttonDesign leaveListBtn;
    }
}
