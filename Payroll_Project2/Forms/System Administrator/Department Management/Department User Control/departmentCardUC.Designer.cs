namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Department_User_Control
{
    partial class departmentCardUC
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
            this.informationBtn = new Payroll_Project2.Custom.buttonDesign();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jobOrderNumber = new System.Windows.Forms.Label();
            this.regularNumber = new System.Windows.Forms.Label();
            this.employeeNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentName = new System.Windows.Forms.Label();
            this.modifyBtn = new Payroll_Project2.Custom.buttonDesign();
            this.departmentPicture = new Payroll_Project2.Custom.customPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.departmentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // informationBtn
            // 
            this.informationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.informationBtn.AutoSize = true;
            this.informationBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.informationBtn.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.informationBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.informationBtn.BorderRadius = 5;
            this.informationBtn.BorderSize = 0;
            this.informationBtn.FlatAppearance.BorderSize = 0;
            this.informationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.informationBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informationBtn.ForeColor = System.Drawing.Color.White;
            this.informationBtn.Location = new System.Drawing.Point(10, 179);
            this.informationBtn.Name = "informationBtn";
            this.informationBtn.Size = new System.Drawing.Size(134, 25);
            this.informationBtn.TabIndex = 12;
            this.informationBtn.Text = "Detailed Information";
            this.informationBtn.TextColor = System.Drawing.Color.White;
            this.informationBtn.UseVisualStyleBackColor = false;
            this.informationBtn.Click += new System.EventHandler(this.informationBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(2, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Job Order Employee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(2, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of Regular Employee";
            // 
            // jobOrderNumber
            // 
            this.jobOrderNumber.AutoSize = true;
            this.jobOrderNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobOrderNumber.ForeColor = System.Drawing.Color.Black;
            this.jobOrderNumber.Location = new System.Drawing.Point(278, 155);
            this.jobOrderNumber.Name = "jobOrderNumber";
            this.jobOrderNumber.Size = new System.Drawing.Size(27, 17);
            this.jobOrderNumber.TabIndex = 7;
            this.jobOrderNumber.Text = "100";
            // 
            // regularNumber
            // 
            this.regularNumber.AutoSize = true;
            this.regularNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regularNumber.ForeColor = System.Drawing.Color.Black;
            this.regularNumber.Location = new System.Drawing.Point(278, 134);
            this.regularNumber.Name = "regularNumber";
            this.regularNumber.Size = new System.Drawing.Size(27, 17);
            this.regularNumber.TabIndex = 8;
            this.regularNumber.Text = "100";
            // 
            // employeeNumber
            // 
            this.employeeNumber.AutoSize = true;
            this.employeeNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeNumber.ForeColor = System.Drawing.Color.Black;
            this.employeeNumber.Location = new System.Drawing.Point(278, 113);
            this.employeeNumber.Name = "employeeNumber";
            this.employeeNumber.Size = new System.Drawing.Size(27, 17);
            this.employeeNumber.TabIndex = 9;
            this.employeeNumber.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(2, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Number of Personnel";
            // 
            // departmentName
            // 
            this.departmentName.AutoEllipsis = true;
            this.departmentName.AutoSize = true;
            this.departmentName.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.departmentName.ForeColor = System.Drawing.Color.Black;
            this.departmentName.Location = new System.Drawing.Point(104, 37);
            this.departmentName.MaximumSize = new System.Drawing.Size(195, 0);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(193, 22);
            this.departmentName.TabIndex = 11;
            this.departmentName.Text = "Human Resources Office";
            // 
            // modifyBtn
            // 
            this.modifyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyBtn.AutoSize = true;
            this.modifyBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.modifyBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.modifyBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.modifyBtn.BorderRadius = 5;
            this.modifyBtn.BorderSize = 0;
            this.modifyBtn.FlatAppearance.BorderSize = 0;
            this.modifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.Color.White;
            this.modifyBtn.Location = new System.Drawing.Point(164, 179);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(134, 25);
            this.modifyBtn.TabIndex = 12;
            this.modifyBtn.Text = "Modify Department";
            this.modifyBtn.TextColor = System.Drawing.Color.White;
            this.modifyBtn.UseVisualStyleBackColor = false;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // departmentPicture
            // 
            this.departmentPicture.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.departmentPicture.BorderColor = System.Drawing.Color.Black;
            this.departmentPicture.BorderColor2 = System.Drawing.Color.Black;
            this.departmentPicture.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.departmentPicture.BorderSize = 0;
            this.departmentPicture.GradientAngle = 50F;
            this.departmentPicture.Image = global::Payroll_Project2.Properties.Resources.initao_logo;
            this.departmentPicture.Location = new System.Drawing.Point(2, 7);
            this.departmentPicture.Name = "departmentPicture";
            this.departmentPicture.Size = new System.Drawing.Size(100, 100);
            this.departmentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.departmentPicture.TabIndex = 4;
            this.departmentPicture.TabStop = false;
            // 
            // departmentCardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.informationBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jobOrderNumber);
            this.Controls.Add(this.regularNumber);
            this.Controls.Add(this.employeeNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.departmentName);
            this.Controls.Add(this.departmentPicture);
            this.Name = "departmentCardUC";
            this.Size = new System.Drawing.Size(317, 211);
            this.Load += new System.EventHandler(this.departmentCardUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign informationBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label jobOrderNumber;
        private System.Windows.Forms.Label regularNumber;
        private System.Windows.Forms.Label employeeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label departmentName;
        private Custom.customPictureBox departmentPicture;
        private Custom.buttonDesign modifyBtn;
    }
}
