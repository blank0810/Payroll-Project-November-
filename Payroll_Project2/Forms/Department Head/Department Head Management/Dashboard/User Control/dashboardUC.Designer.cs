namespace Payroll_Project2.Forms.Department_Head.Dashboard.User_Control
{
    partial class dashboardUC
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
            this.empName = new System.Windows.Forms.Label();
            this.jobDescription = new System.Windows.Forms.Label();
            this.empPicture = new Payroll_Project2.Custom.customPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // empName
            // 
            this.empName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.empName.Location = new System.Drawing.Point(42, 2);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(98, 19);
            this.empName.TabIndex = 3;
            this.empName.Text = "Killua Zoldyck";
            // 
            // jobDescription
            // 
            this.jobDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.jobDescription.AutoSize = true;
            this.jobDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.jobDescription.ForeColor = System.Drawing.Color.DimGray;
            this.jobDescription.Location = new System.Drawing.Point(42, 22);
            this.jobDescription.Name = "jobDescription";
            this.jobDescription.Size = new System.Drawing.Size(136, 19);
            this.jobDescription.TabIndex = 5;
            this.jobDescription.Text = "Front End Developer";
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
            this.empPicture.Location = new System.Drawing.Point(1, 1);
            this.empPicture.Name = "empPicture";
            this.empPicture.Size = new System.Drawing.Size(40, 40);
            this.empPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.empPicture.TabIndex = 4;
            this.empPicture.TabStop = false;
            // 
            // dashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jobDescription);
            this.Controls.Add(this.empPicture);
            this.Controls.Add(this.empName);
            this.Name = "dashboardUC";
            this.Size = new System.Drawing.Size(923, 44);
            this.Load += new System.EventHandler(this.dashboardUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.customPictureBox empPicture;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Label jobDescription;
    }
}
