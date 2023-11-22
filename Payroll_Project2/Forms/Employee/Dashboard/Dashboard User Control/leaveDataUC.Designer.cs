namespace Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control
{
    partial class leaveDataUC
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
            this.formStatus = new System.Windows.Forms.Label();
            this.dateSubmitted = new System.Windows.Forms.Label();
            this.applicationNumber = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // formStatus
            // 
            this.formStatus.AutoSize = true;
            this.formStatus.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.formStatus.ForeColor = System.Drawing.Color.Black;
            this.formStatus.Location = new System.Drawing.Point(445, 9);
            this.formStatus.Name = "formStatus";
            this.formStatus.Size = new System.Drawing.Size(90, 18);
            this.formStatus.TabIndex = 14;
            this.formStatus.Text = "{Form status}";
            // 
            // dateSubmitted
            // 
            this.dateSubmitted.AutoSize = true;
            this.dateSubmitted.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.dateSubmitted.ForeColor = System.Drawing.Color.Black;
            this.dateSubmitted.Location = new System.Drawing.Point(225, 9);
            this.dateSubmitted.Name = "dateSubmitted";
            this.dateSubmitted.Size = new System.Drawing.Size(114, 18);
            this.dateSubmitted.TabIndex = 15;
            this.dateSubmitted.Text = "{Date submitted}";
            // 
            // applicationNumber
            // 
            this.applicationNumber.AutoSize = true;
            this.applicationNumber.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.applicationNumber.ForeColor = System.Drawing.Color.Black;
            this.applicationNumber.Location = new System.Drawing.Point(5, 9);
            this.applicationNumber.Name = "applicationNumber";
            this.applicationNumber.Size = new System.Drawing.Size(141, 18);
            this.applicationNumber.TabIndex = 16;
            this.applicationNumber.Text = "{Application number}";
            // 
            // viewBtn
            // 
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.Green;
            this.viewBtn.BackgroundColor = System.Drawing.Color.Green;
            this.viewBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(650, 5);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(86, 28);
            this.viewBtn.TabIndex = 18;
            this.viewBtn.Text = "View";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            // 
            // leaveDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.formStatus);
            this.Controls.Add(this.dateSubmitted);
            this.Controls.Add(this.applicationNumber);
            this.Name = "leaveDataUC";
            this.Size = new System.Drawing.Size(746, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formStatus;
        private System.Windows.Forms.Label dateSubmitted;
        private System.Windows.Forms.Label applicationNumber;
        private Custom.buttonDesign viewBtn;
    }
}
