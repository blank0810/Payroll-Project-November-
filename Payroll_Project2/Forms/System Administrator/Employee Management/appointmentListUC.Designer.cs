namespace Payroll_Project2.Forms.System_Administrator.Employee_Management
{
    partial class appointmentListUC
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
            this.appointBtn = new Payroll_Project2.Custom.buttonDesign();
            this.content = new System.Windows.Forms.Panel();
            this.employeeListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.previousBtn = new Payroll_Project2.Custom.buttonDesign();
            this.nextBtn = new Payroll_Project2.Custom.buttonDesign();
            this.pageLabel = new System.Windows.Forms.Label();
            this.boundary = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.Panel();
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
            this.description.SuspendLayout();
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
            this.searchBarPanel.BackColor = System.Drawing.Color.White;
            this.searchBarPanel.Controls.Add(this.appointBtn);
            this.searchBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarPanel.Location = new System.Drawing.Point(10, 0);
            this.searchBarPanel.Name = "searchBarPanel";
            this.searchBarPanel.Size = new System.Drawing.Size(1120, 45);
            this.searchBarPanel.TabIndex = 7;
            // 
            // appointBtn
            // 
            this.appointBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.appointBtn.AutoSize = true;
            this.appointBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.appointBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.appointBtn.BorderColor = System.Drawing.Color.Navy;
            this.appointBtn.BorderRadius = 5;
            this.appointBtn.BorderSize = 0;
            this.appointBtn.FlatAppearance.BorderSize = 0;
            this.appointBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appointBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointBtn.ForeColor = System.Drawing.Color.White;
            this.appointBtn.Location = new System.Drawing.Point(1009, 11);
            this.appointBtn.Name = "appointBtn";
            this.appointBtn.Size = new System.Drawing.Size(107, 27);
            this.appointBtn.TabIndex = 2;
            this.appointBtn.Text = "Appoint";
            this.appointBtn.TextColor = System.Drawing.Color.White;
            this.appointBtn.UseVisualStyleBackColor = false;
            this.appointBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // content
            // 
            this.content.Controls.Add(this.employeeListPanel);
            this.content.Controls.Add(this.panel9);
            this.content.Controls.Add(this.boundary);
            this.content.Controls.Add(this.description);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(10, 45);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1120, 720);
            this.content.TabIndex = 8;
            // 
            // employeeListPanel
            // 
            this.employeeListPanel.AutoScroll = true;
            this.employeeListPanel.BackColor = System.Drawing.Color.White;
            this.employeeListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeeListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeListPanel.Location = new System.Drawing.Point(0, 44);
            this.employeeListPanel.Name = "employeeListPanel";
            this.employeeListPanel.Size = new System.Drawing.Size(1120, 644);
            this.employeeListPanel.TabIndex = 17;
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
            this.boundary.Location = new System.Drawing.Point(0, 42);
            this.boundary.Name = "boundary";
            this.boundary.Size = new System.Drawing.Size(1120, 2);
            this.boundary.TabIndex = 14;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.White;
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(857, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(262, 40);
            this.panel7.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 10);
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
            this.panel8.Size = new System.Drawing.Size(349, 40);
            this.panel8.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 10);
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
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee";
            // 
            // appointmentListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.content);
            this.Controls.Add(this.searchBarPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "appointmentListUC";
            this.Size = new System.Drawing.Size(1140, 775);
            this.Load += new System.EventHandler(this.employeeListUC_Load);
            this.searchBarPanel.ResumeLayout(false);
            this.searchBarPanel.PerformLayout();
            this.content.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.description.ResumeLayout(false);
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
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Panel panel9;
        private Custom.buttonDesign previousBtn;
        private Custom.buttonDesign nextBtn;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Panel boundary;
        private System.Windows.Forms.Panel description;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel employeeListPanel;
        private Custom.buttonDesign appointBtn;
    }
}
