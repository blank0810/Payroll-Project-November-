namespace Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Pass_Slip_Request_sub_user_control
{
    partial class slipRequestDataUC
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
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.approveBtn = new Payroll_Project2.Custom.buttonDesign();
            this.dateFiled = new System.Windows.Forms.Label();
            this.controlNumber = new System.Windows.Forms.Label();
            this.employeeId = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.Transparent;
            this.viewBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.viewBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderRadius = 0;
            this.viewBtn.BorderSize = 1;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.Black;
            this.viewBtn.Location = new System.Drawing.Point(934, 9);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(84, 29);
            this.viewBtn.TabIndex = 25;
            this.viewBtn.Text = "Review";
            this.viewBtn.TextColor = System.Drawing.Color.Black;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // approveBtn
            // 
            this.approveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.approveBtn.AutoSize = true;
            this.approveBtn.BackColor = System.Drawing.Color.Transparent;
            this.approveBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.approveBtn.BorderColor = System.Drawing.Color.ForestGreen;
            this.approveBtn.BorderRadius = 0;
            this.approveBtn.BorderSize = 1;
            this.approveBtn.FlatAppearance.BorderSize = 0;
            this.approveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approveBtn.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.approveBtn.ForeColor = System.Drawing.Color.Black;
            this.approveBtn.Location = new System.Drawing.Point(840, 9);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(84, 29);
            this.approveBtn.TabIndex = 24;
            this.approveBtn.Text = "Approve";
            this.approveBtn.TextColor = System.Drawing.Color.Black;
            this.approveBtn.UseVisualStyleBackColor = false;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // dateFiled
            // 
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.dateFiled.ForeColor = System.Drawing.Color.Black;
            this.dateFiled.Location = new System.Drawing.Point(641, 14);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(89, 19);
            this.dateFiled.TabIndex = 23;
            this.dateFiled.Text = "{Date Filed}";
            this.dateFiled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // controlNumber
            // 
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.controlNumber.ForeColor = System.Drawing.Color.Black;
            this.controlNumber.Location = new System.Drawing.Point(431, 14);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(94, 19);
            this.controlNumber.TabIndex = 22;
            this.controlNumber.Text = "{Control no}";
            this.controlNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeId
            // 
            this.employeeId.AutoSize = true;
            this.employeeId.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.employeeId.ForeColor = System.Drawing.Color.DimGray;
            this.employeeId.Location = new System.Drawing.Point(5, 25);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(91, 17);
            this.employeeId.TabIndex = 20;
            this.employeeId.Text = "{Employee Id}";
            this.employeeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.employeeName.ForeColor = System.Drawing.Color.Black;
            this.employeeName.Location = new System.Drawing.Point(5, 3);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(130, 19);
            this.employeeName.TabIndex = 21;
            this.employeeName.Text = "{Employee name}";
            this.employeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slipRequestDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.approveBtn);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.controlNumber);
            this.Controls.Add(this.employeeId);
            this.Controls.Add(this.employeeName);
            this.Name = "slipRequestDataUC";
            this.Size = new System.Drawing.Size(1037, 45);
            this.Load += new System.EventHandler(this.slipRequestDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign viewBtn;
        private Custom.buttonDesign approveBtn;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label controlNumber;
        private System.Windows.Forms.Label employeeId;
        private System.Windows.Forms.Label employeeName;
    }
}
