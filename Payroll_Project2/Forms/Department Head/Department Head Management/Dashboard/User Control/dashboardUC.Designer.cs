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
            this.morningIn = new System.Windows.Forms.Label();
            this.morningOut = new System.Windows.Forms.Label();
            this.morningStatus = new System.Windows.Forms.Label();
            this.empPicture = new Payroll_Project2.Custom.customPictureBox();
            this.afternoonIn = new System.Windows.Forms.Label();
            this.afternoonOut = new System.Windows.Forms.Label();
            this.afternoonStatus = new System.Windows.Forms.Label();
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
            // morningIn
            // 
            this.morningIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morningIn.AutoSize = true;
            this.morningIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.morningIn.ForeColor = System.Drawing.Color.Black;
            this.morningIn.Location = new System.Drawing.Point(265, 16);
            this.morningIn.Name = "morningIn";
            this.morningIn.Size = new System.Drawing.Size(53, 15);
            this.morningIn.TabIndex = 5;
            this.morningIn.Text = "8:00 AM";
            // 
            // morningOut
            // 
            this.morningOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morningOut.AutoSize = true;
            this.morningOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.morningOut.ForeColor = System.Drawing.Color.Black;
            this.morningOut.Location = new System.Drawing.Point(373, 16);
            this.morningOut.Name = "morningOut";
            this.morningOut.Size = new System.Drawing.Size(57, 15);
            this.morningOut.TabIndex = 5;
            this.morningOut.Text = "12:00 PM";
            // 
            // morningStatus
            // 
            this.morningStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morningStatus.AutoSize = true;
            this.morningStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.morningStatus.ForeColor = System.Drawing.Color.Black;
            this.morningStatus.Location = new System.Drawing.Point(485, 16);
            this.morningStatus.Name = "morningStatus";
            this.morningStatus.Size = new System.Drawing.Size(53, 15);
            this.morningStatus.TabIndex = 5;
            this.morningStatus.Text = "On Time";
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
            // afternoonIn
            // 
            this.afternoonIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afternoonIn.AutoSize = true;
            this.afternoonIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.afternoonIn.ForeColor = System.Drawing.Color.Black;
            this.afternoonIn.Location = new System.Drawing.Point(618, 16);
            this.afternoonIn.Name = "afternoonIn";
            this.afternoonIn.Size = new System.Drawing.Size(50, 15);
            this.afternoonIn.TabIndex = 5;
            this.afternoonIn.Text = "1:00 PM";
            // 
            // afternoonOut
            // 
            this.afternoonOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afternoonOut.AutoSize = true;
            this.afternoonOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.afternoonOut.ForeColor = System.Drawing.Color.Black;
            this.afternoonOut.Location = new System.Drawing.Point(732, 16);
            this.afternoonOut.Name = "afternoonOut";
            this.afternoonOut.Size = new System.Drawing.Size(52, 15);
            this.afternoonOut.TabIndex = 5;
            this.afternoonOut.Text = "5:00 PM";
            // 
            // afternoonStatus
            // 
            this.afternoonStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afternoonStatus.AutoSize = true;
            this.afternoonStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.afternoonStatus.ForeColor = System.Drawing.Color.Black;
            this.afternoonStatus.Location = new System.Drawing.Point(854, 16);
            this.afternoonStatus.Name = "afternoonStatus";
            this.afternoonStatus.Size = new System.Drawing.Size(53, 15);
            this.afternoonStatus.TabIndex = 5;
            this.afternoonStatus.Text = "On Time";
            // 
            // dashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.afternoonStatus);
            this.Controls.Add(this.afternoonOut);
            this.Controls.Add(this.morningStatus);
            this.Controls.Add(this.afternoonIn);
            this.Controls.Add(this.morningOut);
            this.Controls.Add(this.morningIn);
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
        private System.Windows.Forms.Label morningIn;
        private System.Windows.Forms.Label morningOut;
        private System.Windows.Forms.Label morningStatus;
        private System.Windows.Forms.Label afternoonIn;
        private System.Windows.Forms.Label afternoonOut;
        private System.Windows.Forms.Label afternoonStatus;
    }
}
