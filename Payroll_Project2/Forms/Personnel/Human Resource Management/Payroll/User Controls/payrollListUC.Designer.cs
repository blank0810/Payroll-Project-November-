namespace Payroll_Project2.Forms.Personnel.Payroll.User_Controls
{
    partial class payrollListUC
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.empid = new System.Windows.Forms.Label();
            this.empName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.totalNumber = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.viewPaySlip = new Payroll_Project2.Custom.buttonDesign();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.empid);
            this.panel6.Controls.Add(this.empName);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(333, 42);
            this.panel6.TabIndex = 2;
            // 
            // empid
            // 
            this.empid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.empid.AutoSize = true;
            this.empid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empid.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.empid.Location = new System.Drawing.Point(11, 21);
            this.empid.Name = "empid";
            this.empid.Size = new System.Drawing.Size(36, 17);
            this.empid.TabIndex = 3;
            this.empid.Text = "1001";
            // 
            // empName
            // 
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empName.Location = new System.Drawing.Point(10, 0);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(105, 20);
            this.empName.TabIndex = 2;
            this.empName.Text = "Killua Zoldyck";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.totalNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(333, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(227, 42);
            this.panel5.TabIndex = 3;
            // 
            // totalNumber
            // 
            this.totalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalNumber.AutoSize = true;
            this.totalNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNumber.Location = new System.Drawing.Point(6, 10);
            this.totalNumber.Name = "totalNumber";
            this.totalNumber.Size = new System.Drawing.Size(25, 20);
            this.totalNumber.TabIndex = 2;
            this.totalNumber.Text = "30";
            // 
            // panel7
            // 
            this.panel7.AutoScroll = true;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(560, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(214, 42);
            this.panel7.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Human Resources Office";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.viewPaySlip);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(773, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(197, 42);
            this.panel8.TabIndex = 5;
            // 
            // viewPaySlip
            // 
            this.viewPaySlip.BackColor = System.Drawing.Color.LimeGreen;
            this.viewPaySlip.BackgroundColor = System.Drawing.Color.LimeGreen;
            this.viewPaySlip.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.viewPaySlip.BorderRadius = 10;
            this.viewPaySlip.BorderSize = 0;
            this.viewPaySlip.FlatAppearance.BorderSize = 0;
            this.viewPaySlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewPaySlip.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewPaySlip.ForeColor = System.Drawing.Color.White;
            this.viewPaySlip.Location = new System.Drawing.Point(24, 3);
            this.viewPaySlip.Name = "viewPaySlip";
            this.viewPaySlip.Size = new System.Drawing.Size(150, 36);
            this.viewPaySlip.TabIndex = 0;
            this.viewPaySlip.Text = "View Pay Slip List";
            this.viewPaySlip.TextColor = System.Drawing.Color.White;
            this.viewPaySlip.UseVisualStyleBackColor = false;
            this.viewPaySlip.Click += new System.EventHandler(this.viewPaySlip_Click);
            // 
            // payrollListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Name = "payrollListUC";
            this.Size = new System.Drawing.Size(970, 42);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label empid;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label totalNumber;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private Custom.buttonDesign viewPaySlip;
    }
}
