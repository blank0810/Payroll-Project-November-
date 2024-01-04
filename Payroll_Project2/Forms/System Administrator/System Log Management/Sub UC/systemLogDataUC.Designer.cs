namespace Payroll_Project2.Forms.System_Administrator.System_Log_Management.Sub_UC
{
    partial class systemLogDataUC
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
            this.logDate = new System.Windows.Forms.Label();
            this.logId = new System.Windows.Forms.Label();
            this.logCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(918, 6);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(124, 28);
            this.viewBtn.TabIndex = 62;
            this.viewBtn.Text = "View Description";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // logDate
            // 
            this.logDate.AutoSize = true;
            this.logDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logDate.ForeColor = System.Drawing.Color.Black;
            this.logDate.Location = new System.Drawing.Point(107, 10);
            this.logDate.Name = "logDate";
            this.logDate.Size = new System.Drawing.Size(49, 19);
            this.logDate.TabIndex = 60;
            this.logDate.Text = "Name";
            // 
            // logId
            // 
            this.logId.AutoSize = true;
            this.logId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logId.ForeColor = System.Drawing.Color.Black;
            this.logId.Location = new System.Drawing.Point(6, 9);
            this.logId.Name = "logId";
            this.logId.Size = new System.Drawing.Size(23, 19);
            this.logId.TabIndex = 61;
            this.logId.Text = "ID";
            // 
            // logCaption
            // 
            this.logCaption.AutoSize = true;
            this.logCaption.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logCaption.ForeColor = System.Drawing.Color.Black;
            this.logCaption.Location = new System.Drawing.Point(279, 10);
            this.logCaption.Name = "logCaption";
            this.logCaption.Size = new System.Drawing.Size(49, 19);
            this.logCaption.TabIndex = 60;
            this.logCaption.Text = "Name";
            // 
            // systemLogDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.logCaption);
            this.Controls.Add(this.logDate);
            this.Controls.Add(this.logId);
            this.Name = "systemLogDataUC";
            this.Size = new System.Drawing.Size(1050, 38);
            this.Load += new System.EventHandler(this.systemLogDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label logDate;
        private System.Windows.Forms.Label logId;
        private System.Windows.Forms.Label logCaption;
    }
}
