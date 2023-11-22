namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal.User_Controls_For_Modal
{
    partial class slipDataUC
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
            this.dateApproved = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.controlNumber = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // dateApproved
            // 
            this.dateApproved.AutoSize = true;
            this.dateApproved.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateApproved.Location = new System.Drawing.Point(416, 10);
            this.dateApproved.Name = "dateApproved";
            this.dateApproved.Size = new System.Drawing.Size(123, 20);
            this.dateApproved.TabIndex = 20;
            this.dateApproved.Text = "{Date Approved}";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(185, 10);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(89, 20);
            this.status.TabIndex = 19;
            this.status.Text = "{Slip Status}";
            // 
            // controlNumber
            // 
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlNumber.Location = new System.Drawing.Point(-2, 10);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(131, 20);
            this.controlNumber.TabIndex = 18;
            this.controlNumber.Text = "{Control Number}";
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
            this.viewBtn.TabIndex = 17;
            this.viewBtn.Text = "Detailed View";
            this.viewBtn.TextColor = System.Drawing.Color.Black;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // slipDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dateApproved);
            this.Controls.Add(this.status);
            this.Controls.Add(this.controlNumber);
            this.Controls.Add(this.viewBtn);
            this.Name = "slipDataUC";
            this.Size = new System.Drawing.Size(788, 40);
            this.Load += new System.EventHandler(this.slipDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateApproved;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label controlNumber;
        private Custom.buttonDesign viewBtn;
    }
}
