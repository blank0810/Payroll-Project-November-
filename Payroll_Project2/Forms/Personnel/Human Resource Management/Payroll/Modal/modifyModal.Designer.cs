namespace Payroll_Project2.Forms.Personnel.Payroll.Modal
{
    partial class modifyModal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.modifyContent = new System.Windows.Forms.Panel();
            this.innerContent = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.payslipPeriod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.subPanel = new System.Windows.Forms.Panel();
            this.deductionBtn = new Payroll_Project2.Custom.buttonDesign();
            this.earningsBtn = new Payroll_Project2.Custom.buttonDesign();
            this.modifyContent.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.subPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 10);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 317);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 10);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(483, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 307);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 307);
            this.panel4.TabIndex = 3;
            // 
            // modifyContent
            // 
            this.modifyContent.Controls.Add(this.innerContent);
            this.modifyContent.Controls.Add(this.panel5);
            this.modifyContent.Controls.Add(this.subPanel);
            this.modifyContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modifyContent.Location = new System.Drawing.Point(10, 10);
            this.modifyContent.Name = "modifyContent";
            this.modifyContent.Size = new System.Drawing.Size(473, 307);
            this.modifyContent.TabIndex = 4;
            // 
            // innerContent
            // 
            this.innerContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.innerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerContent.Location = new System.Drawing.Point(140, 60);
            this.innerContent.Name = "innerContent";
            this.innerContent.Size = new System.Drawing.Size(333, 247);
            this.innerContent.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.payslipPeriod);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(140, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(333, 60);
            this.panel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Payroll_Project2.Properties.Resources.initao_logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // payslipPeriod
            // 
            this.payslipPeriod.AutoSize = true;
            this.payslipPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payslipPeriod.ForeColor = System.Drawing.Color.Black;
            this.payslipPeriod.Location = new System.Drawing.Point(144, 23);
            this.payslipPeriod.Name = "payslipPeriod";
            this.payslipPeriod.Size = new System.Drawing.Size(101, 17);
            this.payslipPeriod.TabIndex = 4;
            this.payslipPeriod.Text = "Modify Pay Slip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(93, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Government Unit of Initao";
            // 
            // subPanel
            // 
            this.subPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subPanel.Controls.Add(this.deductionBtn);
            this.subPanel.Controls.Add(this.earningsBtn);
            this.subPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.subPanel.Location = new System.Drawing.Point(0, 0);
            this.subPanel.Name = "subPanel";
            this.subPanel.Size = new System.Drawing.Size(140, 307);
            this.subPanel.TabIndex = 0;
            // 
            // deductionBtn
            // 
            this.deductionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deductionBtn.BackColor = System.Drawing.Color.Red;
            this.deductionBtn.BackgroundColor = System.Drawing.Color.Red;
            this.deductionBtn.BorderColor = System.Drawing.Color.Navy;
            this.deductionBtn.BorderRadius = 10;
            this.deductionBtn.BorderSize = 0;
            this.deductionBtn.FlatAppearance.BorderSize = 0;
            this.deductionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deductionBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deductionBtn.ForeColor = System.Drawing.Color.White;
            this.deductionBtn.Location = new System.Drawing.Point(3, 166);
            this.deductionBtn.Name = "deductionBtn";
            this.deductionBtn.Size = new System.Drawing.Size(132, 30);
            this.deductionBtn.TabIndex = 3;
            this.deductionBtn.Text = "Add Deductions";
            this.deductionBtn.TextColor = System.Drawing.Color.White;
            this.deductionBtn.UseVisualStyleBackColor = false;
            this.deductionBtn.Click += new System.EventHandler(this.deductionBtn_Click);
            // 
            // earningsBtn
            // 
            this.earningsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.earningsBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.earningsBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.earningsBtn.BorderColor = System.Drawing.Color.Navy;
            this.earningsBtn.BorderRadius = 10;
            this.earningsBtn.BorderSize = 0;
            this.earningsBtn.FlatAppearance.BorderSize = 0;
            this.earningsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.earningsBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earningsBtn.ForeColor = System.Drawing.Color.White;
            this.earningsBtn.Location = new System.Drawing.Point(3, 130);
            this.earningsBtn.Name = "earningsBtn";
            this.earningsBtn.Size = new System.Drawing.Size(132, 30);
            this.earningsBtn.TabIndex = 3;
            this.earningsBtn.Text = "Add Earnings";
            this.earningsBtn.TextColor = System.Drawing.Color.White;
            this.earningsBtn.UseVisualStyleBackColor = false;
            this.earningsBtn.Click += new System.EventHandler(this.earningsBtn_Click);
            // 
            // modifyModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(493, 327);
            this.Controls.Add(this.modifyContent);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(509, 366);
            this.Name = "modifyModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Pay Slip";
            this.modifyContent.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.subPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel modifyContent;
        private System.Windows.Forms.Panel subPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label payslipPeriod;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel innerContent;
        private Custom.buttonDesign deductionBtn;
        private Custom.buttonDesign earningsBtn;
    }
}