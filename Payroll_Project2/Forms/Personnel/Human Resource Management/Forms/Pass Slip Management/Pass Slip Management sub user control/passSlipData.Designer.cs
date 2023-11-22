namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data
{
    partial class passSlipData
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
            this.controlNumber = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
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
            this.empPicture.Location = new System.Drawing.Point(3, 1);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(40, 40);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 11;
            this.empPicture.TabStop = false;
            // 
            // empid
            // 
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.empid.ForeColor = System.Drawing.Color.DimGray;
            this.empid.Location = new System.Drawing.Point(48, 23);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 17);
            this.empid.TabIndex = 10;
            this.empid.Text = "1001";
            // 
            // empName
            // 
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.empName.Location = new System.Drawing.Point(48, 3);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(93, 18);
            this.empName.TabIndex = 9;
            this.empName.Text = "Killua Zoldyck";
            // 
            // controlNumber
            // 
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.controlNumber.Location = new System.Drawing.Point(365, 13);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(15, 18);
            this.controlNumber.TabIndex = 12;
            this.controlNumber.Text = "1";
            this.controlNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFiled
            // 
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.dateFiled.Location = new System.Drawing.Point(610, 13);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(78, 18);
            this.dateFiled.TabIndex = 13;
            this.dateFiled.Text = "{Date filed}";
            this.dateFiled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.viewBtn.Location = new System.Drawing.Point(937, 8);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(64, 29);
            this.viewBtn.TabIndex = 14;
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
            this.proceedBtn.Location = new System.Drawing.Point(873, 8);
            this.proceedBtn.Name = "proceedBtn";
            this.proceedBtn.Size = new System.Drawing.Size(64, 29);
            this.proceedBtn.TabIndex = 15;
            this.proceedBtn.Text = "Certify";
            this.proceedBtn.TextColor = System.Drawing.Color.White;
            this.proceedBtn.UseVisualStyleBackColor = false;
            this.proceedBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // passSlipData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.proceedBtn);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.controlNumber);
            this.Controls.Add(this.empPicture);
            this.Controls.Add(this.empid);
            this.Controls.Add(this.empName);
            this.Name = "passSlipData";
            this.Size = new System.Drawing.Size(1014, 44);
            this.Load += new System.EventHandler(this.passSlipData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.customPictureBox empPicture;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Label controlNumber;
        private System.Windows.Forms.Label dateFiled;
        private Custom.buttonDesign viewBtn;
        private Custom.buttonDesign proceedBtn;
    }
}
