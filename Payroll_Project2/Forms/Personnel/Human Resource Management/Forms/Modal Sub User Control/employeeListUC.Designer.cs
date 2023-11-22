namespace Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents
{
    partial class employeeListUC
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
            this.empid = new System.Windows.Forms.Label();
            this.empFirstName = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.selectBtn = new Payroll_Project2.Custom.buttonDesign();
            this.empPicture = new Payroll_Project2.Custom.customPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // empid
            // 
            this.empid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empid.ForeColor = System.Drawing.Color.DimGray;
            this.empid.Location = new System.Drawing.Point(45, 19);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 17);
            this.empid.TabIndex = 3;
            this.empid.Text = "1001";
            // 
            // empFirstName
            // 
            this.empFirstName.AutoSize = true;
            this.empFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.empFirstName.Location = new System.Drawing.Point(45, 1);
            this.empFirstName.Name = "empFirstName";
            this.empFirstName.Size = new System.Drawing.Size(98, 19);
            this.empFirstName.TabIndex = 2;
            this.empFirstName.Text = "Killua Zoldyck";
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.BackColor = System.Drawing.Color.Transparent;
            this.departmentLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.departmentLabel.ForeColor = System.Drawing.Color.Black;
            this.departmentLabel.Location = new System.Drawing.Point(274, 10);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(101, 19);
            this.departmentLabel.TabIndex = 4;
            this.departmentLabel.Text = "Mayor\'s Office";
            // 
            // selectBtn
            // 
            this.selectBtn.AutoSize = true;
            this.selectBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.selectBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.selectBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.selectBtn.BorderRadius = 5;
            this.selectBtn.BorderSize = 0;
            this.selectBtn.FlatAppearance.BorderSize = 0;
            this.selectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBtn.ForeColor = System.Drawing.Color.White;
            this.selectBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectBtn.Location = new System.Drawing.Point(681, 8);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(109, 25);
            this.selectBtn.TabIndex = 5;
            this.selectBtn.Text = "Select Employee";
            this.selectBtn.TextColor = System.Drawing.Color.White;
            this.selectBtn.UseVisualStyleBackColor = false;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
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
            this.empPicture.Location = new System.Drawing.Point(2, 0);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(40, 40);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 6;
            this.empPicture.TabStop = false;
            // 
            // employeeListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.empPicture);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.empFirstName);
            this.Name = "employeeListUC";
            this.Size = new System.Drawing.Size(792, 41);
            this.Load += new System.EventHandler(this.employeeListUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empFirstName;
        private System.Windows.Forms.Label departmentLabel;
        private Custom.buttonDesign selectBtn;
        private Custom.customPictureBox empPicture;
    }
}
