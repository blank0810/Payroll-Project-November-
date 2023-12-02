namespace Payroll_Project2.Forms.Personnel.DTR.Modal
{
    partial class dtrDetails
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
            this.yearBox = new Payroll_Project2.Custom.customTextBox2();
            this.monthBox = new System.Windows.Forms.ComboBox();
            this.goBtn = new Payroll_Project2.Custom.buttonDesign();
            this.label2 = new System.Windows.Forms.Label();
            this.monthName = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.afternoonShift = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.morningShift = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dtrContent = new System.Windows.Forms.Panel();
            this.logContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.totalWorkedHours = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.previousBtn = new Payroll_Project2.Custom.buttonDesign();
            this.nextBtn = new Payroll_Project2.Custom.buttonDesign();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.dtrContent.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.yearBox);
            this.panel1.Controls.Add(this.monthBox);
            this.panel1.Controls.Add(this.goBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.monthName);
            this.panel1.Controls.Add(this.employeeName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 65);
            this.panel1.TabIndex = 0;
            // 
            // yearBox
            // 
            this.yearBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearBox.BackColor = System.Drawing.SystemColors.Window;
            this.yearBox.BorderColor = System.Drawing.Color.DimGray;
            this.yearBox.BorderFocusColor = System.Drawing.Color.Pink;
            this.yearBox.BorderRadius = 0;
            this.yearBox.BorderSize = 2;
            this.yearBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearBox.ForeColor = System.Drawing.Color.DimGray;
            this.yearBox.Location = new System.Drawing.Point(1035, 3);
            this.yearBox.Multiline = false;
            this.yearBox.Name = "yearBox";
            this.yearBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.yearBox.PasswordChar = false;
            this.yearBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.yearBox.PlaceholderText = "Enter year";
            this.yearBox.Size = new System.Drawing.Size(86, 29);
            this.yearBox.TabIndex = 13;
            this.yearBox.Texts = "";
            this.yearBox.UnderlinedStyle = false;
            this.yearBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yearBox_KeyPress);
            // 
            // monthBox
            // 
            this.monthBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthBox.FormattingEnabled = true;
            this.monthBox.Items.AddRange(new object[] {
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
            this.monthBox.Location = new System.Drawing.Point(888, 3);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(141, 28);
            this.monthBox.TabIndex = 12;
            // 
            // goBtn
            // 
            this.goBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goBtn.AutoSize = true;
            this.goBtn.BackColor = System.Drawing.Color.White;
            this.goBtn.BackgroundColor = System.Drawing.Color.White;
            this.goBtn.BorderColor = System.Drawing.Color.Green;
            this.goBtn.BorderRadius = 0;
            this.goBtn.BorderSize = 2;
            this.goBtn.FlatAppearance.BorderSize = 0;
            this.goBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.goBtn.ForeColor = System.Drawing.Color.Black;
            this.goBtn.Location = new System.Drawing.Point(1127, 5);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(79, 25);
            this.goBtn.TabIndex = 11;
            this.goBtn.Text = "Go";
            this.goBtn.TextColor = System.Drawing.Color.Black;
            this.goBtn.UseVisualStyleBackColor = false;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(753, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Month/Year:";
            // 
            // monthName
            // 
            this.monthName.AutoSize = true;
            this.monthName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.monthName.Location = new System.Drawing.Point(535, 27);
            this.monthName.Name = "monthName";
            this.monthName.Size = new System.Drawing.Size(103, 32);
            this.monthName.TabIndex = 8;
            this.monthName.Text = "{Month}";
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.employeeName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.employeeName.Location = new System.Drawing.Point(84, 7);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(134, 21);
            this.employeeName.TabIndex = 1;
            this.employeeName.Text = "{Employee Name}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "DTR Logs:";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.afternoonShift);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.morningShift);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1211, 26);
            this.panel5.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(957, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "|";
            // 
            // afternoonShift
            // 
            this.afternoonShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.afternoonShift.AutoSize = true;
            this.afternoonShift.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afternoonShift.Location = new System.Drawing.Point(969, 6);
            this.afternoonShift.Name = "afternoonShift";
            this.afternoonShift.Size = new System.Drawing.Size(132, 15);
            this.afternoonShift.TabIndex = 8;
            this.afternoonShift.Text = "Afternoon: 1 PM - 5 PM";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(756, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Shift:";
            // 
            // morningShift
            // 
            this.morningShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.morningShift.AutoSize = true;
            this.morningShift.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningShift.Location = new System.Drawing.Point(793, 6);
            this.morningShift.Name = "morningShift";
            this.morningShift.Size = new System.Drawing.Size(166, 15);
            this.morningShift.TabIndex = 7;
            this.morningShift.Text = "Morning: 8:00 AM - 12:00 PM";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel16);
            this.panel6.Controls.Add(this.panel15);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Controls.Add(this.panel12);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 91);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1211, 62);
            this.panel6.TabIndex = 2;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label20);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(775, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(135, 60);
            this.panel16.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(18, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 30);
            this.label20.TabIndex = 1;
            this.label20.Text = "Special Privilege \r\nStatus";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label19);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(669, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(106, 60);
            this.panel15.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(19, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 38);
            this.label19.TabIndex = 1;
            this.label19.Text = "Afternoon\r\nStatus\r\n";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label17);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(563, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(106, 60);
            this.panel13.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(2, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 19);
            this.label17.TabIndex = 1;
            this.label17.Text = "Afternoon Out";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label16);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(457, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(106, 60);
            this.panel12.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(9, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 19);
            this.label16.TabIndex = 1;
            this.label16.Text = "Afternoon In";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label15);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(351, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(106, 60);
            this.panel11.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(20, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 38);
            this.label15.TabIndex = 1;
            this.label15.Text = "Morning \r\nStatus";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label14);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(238, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(113, 60);
            this.panel10.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(11, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 19);
            this.label14.TabIndex = 1;
            this.label14.Text = "Morning Out";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(125, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(113, 60);
            this.panel9.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(16, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 19);
            this.label13.TabIndex = 1;
            this.label13.Text = "Morning In";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(42, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(83, 60);
            this.panel8.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(18, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 19);
            this.label12.TabIndex = 1;
            this.label12.Text = "Date";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label11);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(42, 60);
            this.panel7.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(4, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Day";
            // 
            // dtrContent
            // 
            this.dtrContent.AutoScroll = true;
            this.dtrContent.Controls.Add(this.logContent);
            this.dtrContent.Controls.Add(this.panel17);
            this.dtrContent.Controls.Add(this.panel14);
            this.dtrContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtrContent.Location = new System.Drawing.Point(0, 153);
            this.dtrContent.Name = "dtrContent";
            this.dtrContent.Size = new System.Drawing.Size(1211, 627);
            this.dtrContent.TabIndex = 3;
            // 
            // logContent
            // 
            this.logContent.AutoScroll = true;
            this.logContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logContent.Location = new System.Drawing.Point(0, 0);
            this.logContent.Name = "logContent";
            this.logContent.Size = new System.Drawing.Size(1211, 557);
            this.logContent.TabIndex = 2;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.SlateGray;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.totalWorkedHours);
            this.panel17.Controls.Add(this.label18);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel17.Location = new System.Drawing.Point(0, 557);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1211, 34);
            this.panel17.TabIndex = 1;
            // 
            // totalWorkedHours
            // 
            this.totalWorkedHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalWorkedHours.AutoSize = true;
            this.totalWorkedHours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalWorkedHours.ForeColor = System.Drawing.Color.White;
            this.totalWorkedHours.Location = new System.Drawing.Point(1045, 5);
            this.totalWorkedHours.Name = "totalWorkedHours";
            this.totalWorkedHours.Size = new System.Drawing.Size(154, 21);
            this.totalWorkedHours.TabIndex = 2;
            this.totalWorkedHours.Text = "{Number of Hours}";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(856, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(192, 21);
            this.label18.TabIndex = 1;
            this.label18.Text = "TOTAL HOURS WORKED:";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.previousBtn);
            this.panel14.Controls.Add(this.nextBtn);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 591);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1211, 36);
            this.panel14.TabIndex = 0;
            // 
            // previousBtn
            // 
            this.previousBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previousBtn.AutoSize = true;
            this.previousBtn.BackColor = System.Drawing.Color.Red;
            this.previousBtn.BackgroundColor = System.Drawing.Color.Red;
            this.previousBtn.BorderColor = System.Drawing.Color.Green;
            this.previousBtn.BorderRadius = 5;
            this.previousBtn.BorderSize = 0;
            this.previousBtn.FlatAppearance.BorderSize = 0;
            this.previousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.previousBtn.ForeColor = System.Drawing.Color.White;
            this.previousBtn.Location = new System.Drawing.Point(1060, 6);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(69, 25);
            this.previousBtn.TabIndex = 13;
            this.previousBtn.Text = "Previous";
            this.previousBtn.TextColor = System.Drawing.Color.White;
            this.previousBtn.UseVisualStyleBackColor = false;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.AutoSize = true;
            this.nextBtn.BackColor = System.Drawing.Color.Green;
            this.nextBtn.BackgroundColor = System.Drawing.Color.Green;
            this.nextBtn.BorderColor = System.Drawing.Color.Green;
            this.nextBtn.BorderRadius = 5;
            this.nextBtn.BorderSize = 2;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.nextBtn.ForeColor = System.Drawing.Color.White;
            this.nextBtn.Location = new System.Drawing.Point(1131, 6);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(69, 25);
            this.nextBtn.TabIndex = 12;
            this.nextBtn.Text = "Next";
            this.nextBtn.TextColor = System.Drawing.Color.White;
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(910, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 60);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Work Hours \r\nfor the day";
            // 
            // dtrDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 780);
            this.Controls.Add(this.dtrContent);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "dtrDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Time Logs";
            this.Load += new System.EventHandler(this.dtrDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.dtrContent.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label afternoonShift;
        private System.Windows.Forms.Label morningShift;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel dtrContent;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label monthName;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label totalWorkedHours;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.FlowLayoutPanel logContent;
        private System.Windows.Forms.Label label2;
        private Custom.buttonDesign goBtn;
        private System.Windows.Forms.ComboBox monthBox;
        private Custom.customTextBox2 yearBox;
        private Custom.buttonDesign nextBtn;
        private Custom.buttonDesign previousBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
    }
}