namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal.User_Controls_For_Modal
{
    partial class leaveListDataUC
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
            this.applicationNumber = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.dateApproved = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.BackColor = System.Drawing.Color.White;
            this.viewBtn.BackgroundColor = System.Drawing.Color.White;
            this.viewBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderRadius = 0;
            this.viewBtn.BorderSize = 2;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.Black;
            this.viewBtn.Location = new System.Drawing.Point(676, 4);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(109, 32);
            this.viewBtn.TabIndex = 13;
            this.viewBtn.Text = "Detailed View";
            this.viewBtn.TextColor = System.Drawing.Color.Black;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // applicationNumber
            // 
            this.applicationNumber.AutoSize = true;
            this.applicationNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationNumber.Location = new System.Drawing.Point(-2, 10);
            this.applicationNumber.Name = "applicationNumber";
            this.applicationNumber.Size = new System.Drawing.Size(158, 20);
            this.applicationNumber.TabIndex = 14;
            this.applicationNumber.Text = "{Application Number}";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(185, 10);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(142, 20);
            this.status.TabIndex = 15;
            this.status.Text = "{Application Status}";
            // 
            // dateApproved
            // 
            this.dateApproved.AutoSize = true;
            this.dateApproved.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateApproved.Location = new System.Drawing.Point(416, 10);
            this.dateApproved.Name = "dateApproved";
            this.dateApproved.Size = new System.Drawing.Size(123, 20);
            this.dateApproved.TabIndex = 16;
            this.dateApproved.Text = "{Date Approved}";
            // 
            // leaveListDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dateApproved);
            this.Controls.Add(this.status);
            this.Controls.Add(this.applicationNumber);
            this.Controls.Add(this.viewBtn);
            this.Name = "leaveListDataUC";
            this.Size = new System.Drawing.Size(788, 40);
            this.Load += new System.EventHandler(this.leaveList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label applicationNumber;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label dateApproved;
    }
}
