namespace Payroll_Project2.Forms.Department_Head.Electronic_DTR
{
    partial class dtrUC
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
            this.panel14 = new System.Windows.Forms.Panel();
            this.recordNumber = new Payroll_Project2.Custom.customTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.previousBtn = new Payroll_Project2.Custom.buttonDesign();
            this.nextBtn = new Payroll_Project2.Custom.buttonDesign();
            this.pageLabel = new System.Windows.Forms.Label();
            this.dtrContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.recordNumber);
            this.panel14.Controls.Add(this.label1);
            this.panel14.Controls.Add(this.label14);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 45);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1538, 41);
            this.panel14.TabIndex = 15;
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
            this.recordNumber._TextChanged += new System.EventHandler(this.recordNumber__TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Showing";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(115, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 19);
            this.label14.TabIndex = 3;
            this.label14.Text = "records per page";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.previousBtn);
            this.panel15.Controls.Add(this.nextBtn);
            this.panel15.Controls.Add(this.pageLabel);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(0, 822);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1538, 32);
            this.panel15.TabIndex = 18;
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
            this.previousBtn.Location = new System.Drawing.Point(1340, 5);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(62, 23);
            this.previousBtn.TabIndex = 6;
            this.previousBtn.Text = "Previous";
            this.previousBtn.TextColor = System.Drawing.Color.Black;
            this.previousBtn.UseVisualStyleBackColor = false;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
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
            this.nextBtn.Location = new System.Drawing.Point(1403, 5);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(59, 23);
            this.nextBtn.TabIndex = 6;
            this.nextBtn.Text = "Next";
            this.nextBtn.TextColor = System.Drawing.Color.Black;
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageLabel.ForeColor = System.Drawing.Color.Blue;
            this.pageLabel.Location = new System.Drawing.Point(1468, 11);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(64, 15);
            this.pageLabel.TabIndex = 1;
            this.pageLabel.Text = "Page 1 of 1";
            // 
            // dtrContent
            // 
            this.dtrContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtrContent.Location = new System.Drawing.Point(0, 86);
            this.dtrContent.Name = "dtrContent";
            this.dtrContent.Size = new System.Drawing.Size(1538, 736);
            this.dtrContent.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1538, 33);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(899, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Action";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(655, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Shift";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(293, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Department";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Employee";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 12);
            this.panel1.TabIndex = 1;
            // 
            // dtrUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dtrContent);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "dtrUC";
            this.Size = new System.Drawing.Size(1538, 854);
            this.Load += new System.EventHandler(this.dtrUC_Load);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel14;
        private Custom.customTextBox2 recordNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel15;
        private Custom.buttonDesign previousBtn;
        private Custom.buttonDesign nextBtn;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.FlowLayoutPanel dtrContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}
