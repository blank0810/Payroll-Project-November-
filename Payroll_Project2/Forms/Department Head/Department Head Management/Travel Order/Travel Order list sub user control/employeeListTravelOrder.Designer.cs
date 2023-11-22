namespace Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_Order_list_sub_user_control
{
    partial class employeeListTravelOrder
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
            this.leaveListBtn = new Payroll_Project2.Custom.buttonDesign();
            this.totalNumber = new System.Windows.Forms.Label();
            this.employeePicture = new Payroll_Project2.Custom.customPictureBox();
            this.employeeID = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeePicture)).BeginInit();
            this.SuspendLayout();
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
            this.leaveListBtn.Location = new System.Drawing.Point(610, 7);
            this.leaveListBtn.Name = "leaveListBtn";
            this.leaveListBtn.Size = new System.Drawing.Size(116, 29);
            this.leaveListBtn.TabIndex = 13;
            this.leaveListBtn.Text = "Show Records";
            this.leaveListBtn.TextColor = System.Drawing.Color.Black;
            this.leaveListBtn.UseVisualStyleBackColor = false;
            this.leaveListBtn.Click += new System.EventHandler(this.leaveListBtn_Click);
            // 
            // totalNumber
            // 
            this.totalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.totalNumber.AutoSize = true;
            this.totalNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNumber.Location = new System.Drawing.Point(370, 12);
            this.totalNumber.Name = "totalNumber";
            this.totalNumber.Size = new System.Drawing.Size(113, 19);
            this.totalNumber.TabIndex = 12;
            this.totalNumber.Text = "{Total number}";
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
            this.employeePicture.Location = new System.Drawing.Point(1, 0);
            this.employeePicture.Name = "employeePicture";
            this.employeePicture.Size = new System.Drawing.Size(40, 40);
            this.employeePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.employeePicture.TabIndex = 10;
            this.employeePicture.TabStop = false;
            // 
            // employeeID
            // 
            this.employeeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.employeeID.AutoSize = true;
            this.employeeID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeID.ForeColor = System.Drawing.Color.DimGray;
            this.employeeID.Location = new System.Drawing.Point(41, 24);
            this.employeeID.Name = "employeeID";
            this.employeeID.Size = new System.Drawing.Size(35, 15);
            this.employeeID.TabIndex = 9;
            this.employeeID.Text = "1001";
            // 
            // employeeName
            // 
            this.employeeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeName.Location = new System.Drawing.Point(41, 1);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(104, 19);
            this.employeeName.TabIndex = 8;
            this.employeeName.Text = "Killua Zoldyck";
            // 
            // employeeListTravelOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.leaveListBtn);
            this.Controls.Add(this.totalNumber);
            this.Controls.Add(this.employeePicture);
            this.Controls.Add(this.employeeID);
            this.Controls.Add(this.employeeName);
            this.Name = "employeeListTravelOrder";
            this.Size = new System.Drawing.Size(742, 43);
            this.Load += new System.EventHandler(this.employeeListTravelOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign leaveListBtn;
        private System.Windows.Forms.Label totalNumber;
        private Custom.customPictureBox employeePicture;
        private System.Windows.Forms.Label employeeID;
        private System.Windows.Forms.Label employeeName;
    }
}
