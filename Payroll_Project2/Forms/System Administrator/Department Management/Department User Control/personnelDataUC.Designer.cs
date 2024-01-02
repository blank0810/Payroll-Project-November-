namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal.Modal_User_Control
{
    partial class personnelDataUC
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
            this.dateHired = new System.Windows.Forms.Label();
            this.jobDesc = new System.Windows.Forms.Label();
            this.empStatus = new System.Windows.Forms.Label();
            this.empid = new System.Windows.Forms.Label();
            this.empName = new System.Windows.Forms.Label();
            this.empPicture = new Payroll_Project2.Custom.customPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dateHired
            // 
            this.dateHired.AutoSize = true;
            this.dateHired.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHired.Location = new System.Drawing.Point(639, 10);
            this.dateHired.Name = "dateHired";
            this.dateHired.Size = new System.Drawing.Size(75, 17);
            this.dateHired.TabIndex = 11;
            this.dateHired.Text = "Date Hired";
            // 
            // jobDesc
            // 
            this.jobDesc.AutoSize = true;
            this.jobDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobDesc.Location = new System.Drawing.Point(433, 10);
            this.jobDesc.Name = "jobDesc";
            this.jobDesc.Size = new System.Drawing.Size(127, 17);
            this.jobDesc.TabIndex = 10;
            this.jobDesc.Text = "Computer Engineer";
            // 
            // empStatus
            // 
            this.empStatus.AutoSize = true;
            this.empStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empStatus.Location = new System.Drawing.Point(245, 10);
            this.empStatus.Name = "empStatus";
            this.empStatus.Size = new System.Drawing.Size(55, 17);
            this.empStatus.TabIndex = 9;
            this.empStatus.Text = "Regular";
            // 
            // empid
            // 
            this.empid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empid.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.empid.Location = new System.Drawing.Point(41, 21);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 17);
            this.empid.TabIndex = 8;
            this.empid.Text = "1001";
            // 
            // empName
            // 
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empName.Location = new System.Drawing.Point(41, 2);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(95, 17);
            this.empName.TabIndex = 7;
            this.empName.Text = "Killua Zoldyck";
            // 
            // empPicture
            // 
            this.empPicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.empPicture.BorderColor = System.Drawing.Color.RoyalBlue;
            this.empPicture.BorderColor2 = System.Drawing.Color.HotPink;
            this.empPicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.empPicture.BorderSize = 1;
            this.empPicture.GradientAngle = 50F;
            this.empPicture.Location = new System.Drawing.Point(2, 2);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(36, 36);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 6;
            this.empPicture.TabStop = false;
            // 
            // personnelDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateHired);
            this.Controls.Add(this.jobDesc);
            this.Controls.Add(this.empStatus);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.empName);
            this.Controls.Add(this.empPicture);
            this.Name = "personnelDataUC";
            this.Size = new System.Drawing.Size(724, 40);
            this.Load += new System.EventHandler(this.personnelDataUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateHired;
        private System.Windows.Forms.Label jobDesc;
        private System.Windows.Forms.Label empStatus;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empName;
        private Custom.customPictureBox empPicture;
    }
}
