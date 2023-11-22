namespace Payroll_Project2.Forms.System_Administrator.Employee_Management
{
    partial class employeeListUC
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchBarPanel = new System.Windows.Forms.Panel();
            this.departmentName = new System.Windows.Forms.ComboBox();
            this.employmentStatus = new System.Windows.Forms.ComboBox();
            this.searchBtn = new Payroll_Project2.Custom.buttonDesign();
            this.searchEmployee = new Payroll_Project2.Custom.customTextBox2();
            this.returnBtn = new Payroll_Project2.Custom.buttonDesign();
            this.filterBtn = new Payroll_Project2.Custom.buttonDesign();
            this.content = new System.Windows.Forms.Panel();
            this.employeeList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.previousBtn = new Payroll_Project2.Custom.buttonDesign();
            this.nextBtn = new Payroll_Project2.Custom.buttonDesign();
            this.pageLabel = new System.Windows.Forms.Label();
            this.boundary = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recordNumber = new Payroll_Project2.Custom.customTextBox2();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBarPanel.SuspendLayout();
            this.content.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.description.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 765);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 765);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1130, 10);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1130, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 775);
            this.panel2.TabIndex = 4;
            // 
            // searchBarPanel
            // 
            this.searchBarPanel.Controls.Add(this.departmentName);
            this.searchBarPanel.Controls.Add(this.employmentStatus);
            this.searchBarPanel.Controls.Add(this.searchBtn);
            this.searchBarPanel.Controls.Add(this.searchEmployee);
            this.searchBarPanel.Controls.Add(this.returnBtn);
            this.searchBarPanel.Controls.Add(this.filterBtn);
            this.searchBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarPanel.Location = new System.Drawing.Point(10, 0);
            this.searchBarPanel.Name = "searchBarPanel";
            this.searchBarPanel.Size = new System.Drawing.Size(1120, 45);
            this.searchBarPanel.TabIndex = 7;
            // 
            // departmentName
            // 
            this.departmentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentName.FormattingEnabled = true;
            this.departmentName.Location = new System.Drawing.Point(517, 12);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(220, 25);
            this.departmentName.TabIndex = 4;
            // 
            // employmentStatus
            // 
            this.employmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employmentStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employmentStatus.FormattingEnabled = true;
            this.employmentStatus.Location = new System.Drawing.Point(328, 12);
            this.employmentStatus.Name = "employmentStatus";
            this.employmentStatus.Size = new System.Drawing.Size(181, 25);
            this.employmentStatus.TabIndex = 3;
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.searchBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.searchBtn.BorderColor = System.Drawing.Color.Navy;
            this.searchBtn.BorderRadius = 10;
            this.searchBtn.BorderSize = 0;
            this.searchBtn.FlatAppearance.BorderSize = 0;
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.searchBtn.ForeColor = System.Drawing.Color.White;
            this.searchBtn.Location = new System.Drawing.Point(250, 7);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(73, 30);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.TextColor = System.Drawing.Color.White;
            this.searchBtn.UseVisualStyleBackColor = false;
            // 
            // searchEmployee
            // 
            this.searchEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchEmployee.BackColor = System.Drawing.Color.White;
            this.searchEmployee.BorderColor = System.Drawing.Color.Gray;
            this.searchEmployee.BorderFocusColor = System.Drawing.Color.Black;
            this.searchEmployee.BorderRadius = 10;
            this.searchEmployee.BorderSize = 1;
            this.searchEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.searchEmployee.ForeColor = System.Drawing.Color.Black;
            this.searchEmployee.Location = new System.Drawing.Point(1, 7);
            this.searchEmployee.Multiline = false;
            this.searchEmployee.Name = "searchEmployee";
            this.searchEmployee.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.searchEmployee.PasswordChar = false;
            this.searchEmployee.PlaceholderColor = System.Drawing.Color.DimGray;
            this.searchEmployee.PlaceholderText = "Search employee name or id";
            this.searchEmployee.Size = new System.Drawing.Size(248, 30);
            this.searchEmployee.TabIndex = 0;
            this.searchEmployee.Texts = "";
            this.searchEmployee.UnderlinedStyle = false;
            // 
            // returnBtn
            // 
            this.returnBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.returnBtn.AutoSize = true;
            this.returnBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.returnBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.returnBtn.BorderColor = System.Drawing.Color.Navy;
            this.returnBtn.BorderRadius = 10;
            this.returnBtn.BorderSize = 0;
            this.returnBtn.FlatAppearance.BorderSize = 0;
            this.returnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBtn.ForeColor = System.Drawing.Color.White;
            this.returnBtn.Location = new System.Drawing.Point(1011, 11);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(107, 27);
            this.returnBtn.TabIndex = 2;
            this.returnBtn.Text = "Return to List";
            this.returnBtn.TextColor = System.Drawing.Color.White;
            this.returnBtn.UseVisualStyleBackColor = false;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // filterBtn
            // 
            this.filterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterBtn.AutoSize = true;
            this.filterBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.filterBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.filterBtn.BorderColor = System.Drawing.Color.Navy;
            this.filterBtn.BorderRadius = 5;
            this.filterBtn.BorderSize = 0;
            this.filterBtn.FlatAppearance.BorderSize = 0;
            this.filterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.filterBtn.ForeColor = System.Drawing.Color.White;
            this.filterBtn.Location = new System.Drawing.Point(740, 13);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(85, 23);
            this.filterBtn.TabIndex = 5;
            this.filterBtn.Text = "+Apply Filter";
            this.filterBtn.TextColor = System.Drawing.Color.White;
            this.filterBtn.UseVisualStyleBackColor = false;
            // 
            // content
            // 
            this.content.Controls.Add(this.employeeList);
            this.content.Controls.Add(this.panel9);
            this.content.Controls.Add(this.boundary);
            this.content.Controls.Add(this.panel1);
            this.content.Controls.Add(this.description);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(10, 45);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1120, 720);
            this.content.TabIndex = 8;
            // 
            // employeeList
            // 
            this.employeeList.AutoScroll = true;
            this.employeeList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeList.Location = new System.Drawing.Point(0, 85);
            this.employeeList.Name = "employeeList";
            this.employeeList.Size = new System.Drawing.Size(1120, 603);
            this.employeeList.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.previousBtn);
            this.panel9.Controls.Add(this.nextBtn);
            this.panel9.Controls.Add(this.pageLabel);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 688);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1120, 32);
            this.panel9.TabIndex = 16;
            // 
            // previousBtn
            // 
            this.previousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previousBtn.AutoSize = true;
            this.previousBtn.BackColor = System.Drawing.Color.White;
            this.previousBtn.BackgroundColor = System.Drawing.Color.White;
            this.previousBtn.BorderColor = System.Drawing.Color.Red;
            this.previousBtn.BorderRadius = 5;
            this.previousBtn.BorderSize = 1;
            this.previousBtn.FlatAppearance.BorderSize = 0;
            this.previousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.previousBtn.ForeColor = System.Drawing.Color.Black;
            this.previousBtn.Location = new System.Drawing.Point(922, 5);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(62, 23);
            this.previousBtn.TabIndex = 6;
            this.previousBtn.Text = "Previous";
            this.previousBtn.TextColor = System.Drawing.Color.Black;
            this.previousBtn.UseVisualStyleBackColor = false;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.AutoSize = true;
            this.nextBtn.BackColor = System.Drawing.Color.White;
            this.nextBtn.BackgroundColor = System.Drawing.Color.White;
            this.nextBtn.BorderColor = System.Drawing.Color.Green;
            this.nextBtn.BorderRadius = 5;
            this.nextBtn.BorderSize = 1;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.Color.Black;
            this.nextBtn.Location = new System.Drawing.Point(985, 5);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(59, 23);
            this.nextBtn.TabIndex = 6;
            this.nextBtn.Text = "Next";
            this.nextBtn.TextColor = System.Drawing.Color.Black;
            this.nextBtn.UseVisualStyleBackColor = false;
            // 
            // pageLabel
            // 
            this.pageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageLabel.ForeColor = System.Drawing.Color.Blue;
            this.pageLabel.Location = new System.Drawing.Point(1050, 11);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(64, 15);
            this.pageLabel.TabIndex = 1;
            this.pageLabel.Text = "Page 1 of 1";
            // 
            // boundary
            // 
            this.boundary.BackColor = System.Drawing.Color.Gainsboro;
            this.boundary.Dock = System.Windows.Forms.DockStyle.Top;
            this.boundary.Location = new System.Drawing.Point(0, 83);
            this.boundary.Name = "boundary";
            this.boundary.Size = new System.Drawing.Size(1120, 2);
            this.boundary.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.recordNumber);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 41);
            this.panel1.TabIndex = 13;
            // 
            // recordNumber
            // 
            this.recordNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.recordNumber.AutoSize = true;
            this.recordNumber.BackColor = System.Drawing.Color.White;
            this.recordNumber.BorderColor = System.Drawing.Color.Gray;
            this.recordNumber.BorderFocusColor = System.Drawing.Color.Black;
            this.recordNumber.BorderRadius = 5;
            this.recordNumber.BorderSize = 1;
            this.recordNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.recordNumber.ForeColor = System.Drawing.Color.Black;
            this.recordNumber.Location = new System.Drawing.Point(69, 8);
            this.recordNumber.Multiline = false;
            this.recordNumber.Name = "recordNumber";
            this.recordNumber.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.recordNumber.PasswordChar = false;
            this.recordNumber.PlaceholderColor = System.Drawing.Color.DimGray;
            this.recordNumber.PlaceholderText = "";
            this.recordNumber.Size = new System.Drawing.Size(40, 29);
            this.recordNumber.TabIndex = 2;
            this.recordNumber.Texts = "";
            this.recordNumber.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Showing";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(115, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "records per page";
            // 
            // description
            // 
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.description.Controls.Add(this.panel14);
            this.description.Controls.Add(this.panel7);
            this.description.Controls.Add(this.panel8);
            this.description.Controls.Add(this.panel6);
            this.description.Controls.Add(this.panel5);
            this.description.Dock = System.Windows.Forms.DockStyle.Top;
            this.description.Location = new System.Drawing.Point(0, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(1120, 42);
            this.description.TabIndex = 12;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label3);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(1007, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(112, 40);
            this.panel14.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(2, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Actions";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(762, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(245, 40);
            this.panel7.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Job Description";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(508, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(254, 40);
            this.panel8.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(2, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Department";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(327, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(181, 40);
            this.panel6.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Employment Status";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(-222, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Employment Status";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(327, 40);
            this.panel5.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee";
            // 
            // employeeListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.content);
            this.Controls.Add(this.searchBarPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "employeeListUC";
            this.Size = new System.Drawing.Size(1140, 775);
            this.Load += new System.EventHandler(this.employeeListUC_Load);
            this.searchBarPanel.ResumeLayout(false);
            this.searchBarPanel.PerformLayout();
            this.content.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.description.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel searchBarPanel;
        private System.Windows.Forms.ComboBox departmentName;
        private System.Windows.Forms.ComboBox employmentStatus;
        private Custom.buttonDesign searchBtn;
        private Custom.customTextBox2 searchEmployee;
        private Custom.buttonDesign returnBtn;
        private Custom.buttonDesign filterBtn;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Panel panel9;
        private Custom.buttonDesign previousBtn;
        private Custom.buttonDesign nextBtn;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Panel boundary;
        private System.Windows.Forms.Panel panel1;
        private Custom.customTextBox2 recordNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel description;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel employeeList;
    }
}
