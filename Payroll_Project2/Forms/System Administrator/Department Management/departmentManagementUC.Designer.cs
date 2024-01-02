namespace Payroll_Project2.Forms.System_Administrator.Department_Management
{
    partial class departmentManagementUC
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.departmentList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.searchDepartment = new Payroll_Project2.Custom.customTextBox2();
            this.searchBtn = new Payroll_Project2.Custom.buttonDesign();
            this.addDepartmentBtn = new Payroll_Project2.Custom.buttonDesign();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 854);
            this.panel2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1114, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 854);
            this.panel1.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(8, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 8);
            this.panel3.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(8, 846);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1106, 8);
            this.panel4.TabIndex = 34;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.departmentList);
            this.contentPanel.Controls.Add(this.panel6);
            this.contentPanel.Controls.Add(this.panel16);
            this.contentPanel.Controls.Add(this.panel5);
            this.contentPanel.Controls.Add(this.panel15);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(8, 8);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1106, 838);
            this.contentPanel.TabIndex = 35;
            // 
            // departmentList
            // 
            this.departmentList.AutoScroll = true;
            this.departmentList.BackColor = System.Drawing.Color.White;
            this.departmentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.departmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentList.Location = new System.Drawing.Point(0, 101);
            this.departmentList.Name = "departmentList";
            this.departmentList.Size = new System.Drawing.Size(1106, 737);
            this.departmentList.TabIndex = 37;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 91);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1106, 10);
            this.panel6.TabIndex = 36;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.Controls.Add(this.searchDepartment);
            this.panel16.Controls.Add(this.searchBtn);
            this.panel16.Controls.Add(this.addDepartmentBtn);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 47);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1106, 44);
            this.panel16.TabIndex = 35;
            // 
            // searchDepartment
            // 
            this.searchDepartment.BackColor = System.Drawing.Color.White;
            this.searchDepartment.BorderColor = System.Drawing.Color.Gray;
            this.searchDepartment.BorderFocusColor = System.Drawing.Color.Black;
            this.searchDepartment.BorderRadius = 5;
            this.searchDepartment.BorderSize = 1;
            this.searchDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.searchDepartment.ForeColor = System.Drawing.Color.Black;
            this.searchDepartment.Location = new System.Drawing.Point(6, 6);
            this.searchDepartment.Multiline = false;
            this.searchDepartment.Name = "searchDepartment";
            this.searchDepartment.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.searchDepartment.PasswordChar = false;
            this.searchDepartment.PlaceholderColor = System.Drawing.Color.DimGray;
            this.searchDepartment.PlaceholderText = "Search Department name";
            this.searchDepartment.Size = new System.Drawing.Size(248, 30);
            this.searchDepartment.TabIndex = 2;
            this.searchDepartment.Texts = "";
            this.searchDepartment.UnderlinedStyle = false;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.White;
            this.searchBtn.BackgroundColor = System.Drawing.Color.White;
            this.searchBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.searchBtn.BorderRadius = 5;
            this.searchBtn.BorderSize = 1;
            this.searchBtn.FlatAppearance.BorderSize = 0;
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.Black;
            this.searchBtn.Location = new System.Drawing.Point(257, 6);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(63, 30);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.TextColor = System.Drawing.Color.Black;
            this.searchBtn.UseVisualStyleBackColor = false;
            // 
            // addDepartmentBtn
            // 
            this.addDepartmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addDepartmentBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.addDepartmentBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.addDepartmentBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.addDepartmentBtn.BorderRadius = 5;
            this.addDepartmentBtn.BorderSize = 0;
            this.addDepartmentBtn.FlatAppearance.BorderSize = 0;
            this.addDepartmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDepartmentBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDepartmentBtn.ForeColor = System.Drawing.Color.White;
            this.addDepartmentBtn.Location = new System.Drawing.Point(985, 5);
            this.addDepartmentBtn.Name = "addDepartmentBtn";
            this.addDepartmentBtn.Size = new System.Drawing.Size(117, 33);
            this.addDepartmentBtn.TabIndex = 1;
            this.addDepartmentBtn.Text = "Add Department";
            this.addDepartmentBtn.TextColor = System.Drawing.Color.White;
            this.addDepartmentBtn.UseVisualStyleBackColor = false;
            this.addDepartmentBtn.Click += new System.EventHandler(this.addDepartmentBtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1106, 8);
            this.panel5.TabIndex = 34;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.Control;
            this.panel15.Controls.Add(this.label5);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1106, 39);
            this.panel15.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "List of Every Department and Information";
            // 
            // departmentManagementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "departmentManagementUC";
            this.Size = new System.Drawing.Size(1122, 854);
            this.Load += new System.EventHandler(this.departmentManagementUC_Load);
            this.contentPanel.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel16;
        private Custom.customTextBox2 searchDepartment;
        private Custom.buttonDesign searchBtn;
        private Custom.buttonDesign addDepartmentBtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.FlowLayoutPanel departmentList;
    }
}
