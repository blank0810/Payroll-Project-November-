namespace Payroll_Project2.Forms.Personnel.Municipal_Calendar
{
    partial class calendarUC
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
            this.calendarContent = new System.Windows.Forms.FlowLayoutPanel();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.monthChanger = new System.Windows.Forms.ComboBox();
            this.goToMonth = new Payroll_Project2.Custom.buttonDesign();
            this.yearLabel = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.previousBtn = new Payroll_Project2.Custom.buttonDesign();
            this.panel10 = new System.Windows.Forms.Panel();
            this.nextBtn = new Payroll_Project2.Custom.buttonDesign();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarContent
            // 
            this.calendarContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calendarContent.AutoScroll = true;
            this.calendarContent.BackColor = System.Drawing.SystemColors.Control;
            this.calendarContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarContent.Location = new System.Drawing.Point(0, 85);
            this.calendarContent.Name = "calendarContent";
            this.calendarContent.Size = new System.Drawing.Size(1162, 613);
            this.calendarContent.TabIndex = 10;
            // 
            // yearBox
            // 
            this.yearBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearBox.ForeColor = System.Drawing.Color.DimGray;
            this.yearBox.Location = new System.Drawing.Point(1024, 7);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(72, 20);
            this.yearBox.TabIndex = 10;
            this.yearBox.Text = "e.g 2021";
            this.yearBox.Click += new System.EventHandler(this.yearBox_Click);
            // 
            // monthChanger
            // 
            this.monthChanger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthChanger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthChanger.FormattingEnabled = true;
            this.monthChanger.Items.AddRange(new object[] {
            "Select Month",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthChanger.Location = new System.Drawing.Point(867, 6);
            this.monthChanger.Name = "monthChanger";
            this.monthChanger.Size = new System.Drawing.Size(155, 21);
            this.monthChanger.TabIndex = 9;
            // 
            // goToMonth
            // 
            this.goToMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goToMonth.BackColor = System.Drawing.Color.ForestGreen;
            this.goToMonth.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.goToMonth.BorderColor = System.Drawing.Color.DodgerBlue;
            this.goToMonth.BorderRadius = 10;
            this.goToMonth.BorderSize = 0;
            this.goToMonth.FlatAppearance.BorderSize = 0;
            this.goToMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goToMonth.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToMonth.ForeColor = System.Drawing.Color.White;
            this.goToMonth.Location = new System.Drawing.Point(1096, 5);
            this.goToMonth.Name = "goToMonth";
            this.goToMonth.Size = new System.Drawing.Size(61, 23);
            this.goToMonth.TabIndex = 8;
            this.goToMonth.Text = "Go";
            this.goToMonth.TextColor = System.Drawing.Color.White;
            this.goToMonth.UseVisualStyleBackColor = false;
            this.goToMonth.Click += new System.EventHandler(this.goToMonth_Click);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.yearLabel.ForeColor = System.Drawing.Color.Black;
            this.yearLabel.Location = new System.Drawing.Point(7, 33);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(60, 25);
            this.yearLabel.TabIndex = 5;
            this.yearLabel.Text = "2023";
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.monthLabel.ForeColor = System.Drawing.Color.Black;
            this.monthLabel.Location = new System.Drawing.Point(7, -2);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(111, 31);
            this.monthLabel.TabIndex = 6;
            this.monthLabel.Text = "January";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1031, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Saturday";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(872, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Friday";
            // 
            // previousBtn
            // 
            this.previousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previousBtn.BackColor = System.Drawing.Color.DarkRed;
            this.previousBtn.BackgroundColor = System.Drawing.Color.DarkRed;
            this.previousBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.previousBtn.BorderRadius = 10;
            this.previousBtn.BorderSize = 0;
            this.previousBtn.FlatAppearance.BorderSize = 0;
            this.previousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousBtn.ForeColor = System.Drawing.Color.White;
            this.previousBtn.Location = new System.Drawing.Point(1002, 2);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(77, 25);
            this.previousBtn.TabIndex = 10;
            this.previousBtn.Text = "Previous";
            this.previousBtn.TextColor = System.Drawing.Color.White;
            this.previousBtn.UseVisualStyleBackColor = false;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel10.Controls.Add(this.previousBtn);
            this.panel10.Controls.Add(this.nextBtn);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 697);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1160, 30);
            this.panel10.TabIndex = 9;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.nextBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.nextBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.nextBtn.BorderRadius = 10;
            this.nextBtn.BorderSize = 0;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.Color.White;
            this.nextBtn.Location = new System.Drawing.Point(1081, 2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(77, 25);
            this.nextBtn.TabIndex = 9;
            this.nextBtn.Text = "Next";
            this.nextBtn.TextColor = System.Drawing.Color.White;
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(703, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thursday";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(527, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Wednesday";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(205, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monday";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(46, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sunday";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(368, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tuesday";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.yearBox);
            this.panel2.Controls.Add(this.monthChanger);
            this.panel2.Controls.Add(this.goToMonth);
            this.panel2.Controls.Add(this.yearLabel);
            this.panel2.Controls.Add(this.monthLabel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1162, 88);
            this.panel2.TabIndex = 8;
            // 
            // calendarUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.calendarContent);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel2);
            this.Name = "calendarUC";
            this.Size = new System.Drawing.Size(1160, 727);
            this.Load += new System.EventHandler(this.calendarUC_Load);
            this.panel10.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel calendarContent;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.ComboBox monthChanger;
        private Custom.buttonDesign goToMonth;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Custom.buttonDesign previousBtn;
        private System.Windows.Forms.Panel panel10;
        private Custom.buttonDesign nextBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
    }
}
