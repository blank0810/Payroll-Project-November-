namespace Payroll_Project2.Forms.Personnel.Payroll
{
    partial class payroll
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.profileContentPanel = new System.Windows.Forms.Panel();
            this.completeInfoPanel = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.generalInfoPanel = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.salaryType = new System.Windows.Forms.ComboBox();
            this.submitBtn = new Payroll_Project2.Custom.buttonDesign();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.employmentType = new System.Windows.Forms.ComboBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.monthList = new System.Windows.Forms.ComboBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.profileContentPanel.SuspendLayout();
            this.completeInfoPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.generalInfoPanel.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1461, 10);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 848);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1451, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 848);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 848);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1441, 10);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.titleLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1441, 39);
            this.panel5.TabIndex = 9;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(10, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(169, 24);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Payslip Generation";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(10, 49);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1441, 5);
            this.panel6.TabIndex = 10;
            // 
            // profileContentPanel
            // 
            this.profileContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.profileContentPanel.Controls.Add(this.completeInfoPanel);
            this.profileContentPanel.Controls.Add(this.panel9);
            this.profileContentPanel.Controls.Add(this.panel7);
            this.profileContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profileContentPanel.Location = new System.Drawing.Point(10, 54);
            this.profileContentPanel.Name = "profileContentPanel";
            this.profileContentPanel.Size = new System.Drawing.Size(1441, 794);
            this.profileContentPanel.TabIndex = 12;
            // 
            // completeInfoPanel
            // 
            this.completeInfoPanel.BackColor = System.Drawing.Color.White;
            this.completeInfoPanel.Controls.Add(this.panel8);
            this.completeInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeInfoPanel.Location = new System.Drawing.Point(418, 0);
            this.completeInfoPanel.Name = "completeInfoPanel";
            this.completeInfoPanel.Size = new System.Drawing.Size(1023, 794);
            this.completeInfoPanel.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1023, 34);
            this.panel8.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(408, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 794);
            this.panel9.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.generalInfoPanel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(408, 794);
            this.panel7.TabIndex = 0;
            // 
            // generalInfoPanel
            // 
            this.generalInfoPanel.BackColor = System.Drawing.Color.White;
            this.generalInfoPanel.Controls.Add(this.panel22);
            this.generalInfoPanel.Controls.Add(this.panel21);
            this.generalInfoPanel.Controls.Add(this.panel20);
            this.generalInfoPanel.Controls.Add(this.panel19);
            this.generalInfoPanel.Controls.Add(this.panel18);
            this.generalInfoPanel.Controls.Add(this.panel17);
            this.generalInfoPanel.Controls.Add(this.panel16);
            this.generalInfoPanel.Controls.Add(this.panel14);
            this.generalInfoPanel.Controls.Add(this.panel12);
            this.generalInfoPanel.Controls.Add(this.panel10);
            this.generalInfoPanel.Controls.Add(this.panel15);
            this.generalInfoPanel.Controls.Add(this.submitBtn);
            this.generalInfoPanel.Controls.Add(this.panel11);
            this.generalInfoPanel.Controls.Add(this.panel13);
            this.generalInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.generalInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.generalInfoPanel.Name = "generalInfoPanel";
            this.generalInfoPanel.Size = new System.Drawing.Size(408, 426);
            this.generalInfoPanel.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.label2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 78);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(408, 36);
            this.panel12.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Employment type";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 75);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(408, 3);
            this.panel10.TabIndex = 22;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.Controls.Add(this.salaryType);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 39);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(408, 36);
            this.panel15.TabIndex = 21;
            // 
            // salaryType
            // 
            this.salaryType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.salaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.salaryType.Font = new System.Drawing.Font("Calibri", 11F);
            this.salaryType.FormattingEnabled = true;
            this.salaryType.Location = new System.Drawing.Point(10, 5);
            this.salaryType.Name = "salaryType";
            this.salaryType.Size = new System.Drawing.Size(229, 26);
            this.salaryType.TabIndex = 6;
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.AutoSize = true;
            this.submitBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.submitBtn.BorderRadius = 5;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(318, 393);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(85, 29);
            this.submitBtn.TabIndex = 16;
            this.submitBtn.Text = "+Add Leave";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gainsboro;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 36);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(408, 3);
            this.panel11.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.label1);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(408, 36);
            this.panel13.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Payslip type";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Gainsboro;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 114);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(408, 3);
            this.panel14.TabIndex = 24;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.Controls.Add(this.employmentType);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 117);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(408, 36);
            this.panel16.TabIndex = 25;
            // 
            // employmentType
            // 
            this.employmentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.employmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employmentType.Font = new System.Drawing.Font("Calibri", 11F);
            this.employmentType.FormattingEnabled = true;
            this.employmentType.Location = new System.Drawing.Point(10, 5);
            this.employmentType.Name = "employmentType";
            this.employmentType.Size = new System.Drawing.Size(229, 26);
            this.employmentType.TabIndex = 6;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Gainsboro;
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 153);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(408, 3);
            this.panel17.TabIndex = 26;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.White;
            this.panel18.Controls.Add(this.label3);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 156);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(408, 36);
            this.panel18.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Month";
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.Gainsboro;
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 192);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(408, 3);
            this.panel19.TabIndex = 28;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.White;
            this.panel20.Controls.Add(this.monthList);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 195);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(408, 36);
            this.panel20.TabIndex = 29;
            // 
            // monthList
            // 
            this.monthList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.monthList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthList.Font = new System.Drawing.Font("Calibri", 11F);
            this.monthList.FormattingEnabled = true;
            this.monthList.Location = new System.Drawing.Point(10, 5);
            this.monthList.Name = "monthList";
            this.monthList.Size = new System.Drawing.Size(229, 26);
            this.monthList.TabIndex = 6;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.Gainsboro;
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 231);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(408, 3);
            this.panel21.TabIndex = 30;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.White;
            this.panel22.Controls.Add(this.label4);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 234);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(408, 36);
            this.panel22.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Payslip period";
            // 
            // payroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.profileContentPanel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "payroll";
            this.Size = new System.Drawing.Size(1461, 858);
            this.Load += new System.EventHandler(this.payroll_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.profileContentPanel.ResumeLayout(false);
            this.completeInfoPanel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.generalInfoPanel.ResumeLayout(false);
            this.generalInfoPanel.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel profileContentPanel;
        private System.Windows.Forms.Panel completeInfoPanel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel generalInfoPanel;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.ComboBox salaryType;
        private Custom.buttonDesign submitBtn;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.ComboBox employmentType;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.ComboBox monthList;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel21;
    }
}
