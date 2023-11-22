namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control
{
    partial class passSlipUC
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
            this.controlNumber = new System.Windows.Forms.Label();
            this.viewFormBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // formStatus
            // 
            this.formStatus.AutoSize = true;
            this.formStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formStatus.ForeColor = System.Drawing.Color.Black;
            this.formStatus.Location = new System.Drawing.Point(516, 7);
            this.formStatus.Name = "formStatus";
            this.formStatus.Size = new System.Drawing.Size(138, 17);
            this.formStatus.TabIndex = 14;
            this.formStatus.Text = "Application For Leave";
            // 
            // dateSubmitted
            // 
            this.dateSubmitted.AutoSize = true;
            this.dateSubmitted.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateSubmitted.ForeColor = System.Drawing.Color.Black;
            this.dateSubmitted.Location = new System.Drawing.Point(230, 7);
            this.dateSubmitted.Name = "dateSubmitted";
            this.dateSubmitted.Size = new System.Drawing.Size(112, 17);
            this.dateSubmitted.TabIndex = 15;
            this.dateSubmitted.Text = "December 5 2023";
            // 
            // controlNumber
            // 
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlNumber.ForeColor = System.Drawing.Color.Black;
            this.controlNumber.Location = new System.Drawing.Point(0, 7);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(55, 17);
            this.controlNumber.TabIndex = 16;
            this.controlNumber.Text = "1000000";
            // 
            // viewFormBtn
            // 
            this.viewFormBtn.AutoSize = true;
            this.viewFormBtn.BackColor = System.Drawing.Color.Green;
            this.viewFormBtn.BackgroundColor = System.Drawing.Color.Green;
            this.viewFormBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.viewFormBtn.BorderRadius = 5;
            this.viewFormBtn.BorderSize = 0;
            this.viewFormBtn.FlatAppearance.BorderSize = 0;
            this.viewFormBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewFormBtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewFormBtn.ForeColor = System.Drawing.Color.White;
            this.viewFormBtn.Location = new System.Drawing.Point(832, 4);
            this.viewFormBtn.Name = "viewFormBtn";
            this.viewFormBtn.Size = new System.Drawing.Size(86, 23);
            this.viewFormBtn.TabIndex = 17;
            this.viewFormBtn.Text = "View";
            this.viewFormBtn.TextColor = System.Drawing.Color.White;
            this.viewFormBtn.UseVisualStyleBackColor = false;
            this.viewFormBtn.Click += new System.EventHandler(this.viewFormBtn_Click);
            // 
            // passSlipUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formStatus);
            this.Controls.Add(this.dateSubmitted);
            this.Controls.Add(this.controlNumber);
            this.Controls.Add(this.viewFormBtn);
            this.Name = "passSlipUC";
            this.Size = new System.Drawing.Size(928, 31);
            this.Load += new System.EventHandler(this.passSlipUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formStatus;
        private System.Windows.Forms.Label dateSubmitted;
        private System.Windows.Forms.Label controlNumber;
        private Custom.buttonDesign viewFormBtn;
    }
}
