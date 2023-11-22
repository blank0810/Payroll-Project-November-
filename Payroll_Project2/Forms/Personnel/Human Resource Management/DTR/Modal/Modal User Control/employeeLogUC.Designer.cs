namespace Payroll_Project2.Forms.Personnel.DTR.Modal.Modal_User_Control
{
    partial class employeeLogUC
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
            this.dayPanel = new System.Windows.Forms.Panel();
            this.day = new System.Windows.Forms.Label();
            this.datePanel = new System.Windows.Forms.Panel();
            this.dateLog = new System.Windows.Forms.Label();
            this.morningInPanel = new System.Windows.Forms.Panel();
            this.morningIn = new System.Windows.Forms.Label();
            this.morningInUpdate = new System.Windows.Forms.DateTimePicker();
            this.morningOutPanel = new System.Windows.Forms.Panel();
            this.morningOutUpdate = new System.Windows.Forms.DateTimePicker();
            this.morningOut = new System.Windows.Forms.Label();
            this.afternoonInPanel = new System.Windows.Forms.Panel();
            this.afternoonIn = new System.Windows.Forms.Label();
            this.afternoonInUpdate = new System.Windows.Forms.DateTimePicker();
            this.afternoonOutPanel = new System.Windows.Forms.Panel();
            this.afternoonOutUpdate = new System.Windows.Forms.DateTimePicker();
            this.afternoonOut = new System.Windows.Forms.Label();
            this.afternoonStatusPanel = new System.Windows.Forms.Panel();
            this.afternoonStatus = new System.Windows.Forms.Label();
            this.totalPanel = new System.Windows.Forms.Panel();
            this.total = new System.Windows.Forms.Label();
            this.morningStatusPanel = new System.Windows.Forms.Panel();
            this.morningStatus = new System.Windows.Forms.Label();
            this.cancelBtn = new Payroll_Project2.Custom.buttonDesign();
            this.absentBtn = new Payroll_Project2.Custom.buttonDesign();
            this.submitBtn = new Payroll_Project2.Custom.buttonDesign();
            this.changeBtn = new Payroll_Project2.Custom.buttonDesign();
            this.dayPanel.SuspendLayout();
            this.datePanel.SuspendLayout();
            this.morningInPanel.SuspendLayout();
            this.morningOutPanel.SuspendLayout();
            this.afternoonInPanel.SuspendLayout();
            this.afternoonOutPanel.SuspendLayout();
            this.afternoonStatusPanel.SuspendLayout();
            this.totalPanel.SuspendLayout();
            this.morningStatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dayPanel
            // 
            this.dayPanel.Controls.Add(this.day);
            this.dayPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.dayPanel.Location = new System.Drawing.Point(0, 0);
            this.dayPanel.Name = "dayPanel";
            this.dayPanel.Size = new System.Drawing.Size(42, 35);
            this.dayPanel.TabIndex = 1;
            // 
            // day
            // 
            this.day.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.day.AutoSize = true;
            this.day.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.day.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.day.Location = new System.Drawing.Point(5, 10);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(31, 15);
            this.day.TabIndex = 1;
            this.day.Text = "SUN";
            // 
            // datePanel
            // 
            this.datePanel.Controls.Add(this.dateLog);
            this.datePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.datePanel.Location = new System.Drawing.Point(42, 0);
            this.datePanel.Name = "datePanel";
            this.datePanel.Size = new System.Drawing.Size(83, 35);
            this.datePanel.TabIndex = 2;
            // 
            // dateLog
            // 
            this.dateLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateLog.AutoSize = true;
            this.dateLog.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dateLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateLog.Location = new System.Drawing.Point(14, 10);
            this.dateLog.Name = "dateLog";
            this.dateLog.Size = new System.Drawing.Size(53, 15);
            this.dateLog.TabIndex = 2;
            this.dateLog.Text = "--:--:----";
            // 
            // morningInPanel
            // 
            this.morningInPanel.Controls.Add(this.morningIn);
            this.morningInPanel.Controls.Add(this.morningInUpdate);
            this.morningInPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.morningInPanel.Location = new System.Drawing.Point(125, 0);
            this.morningInPanel.Name = "morningInPanel";
            this.morningInPanel.Size = new System.Drawing.Size(113, 35);
            this.morningInPanel.TabIndex = 3;
            // 
            // morningIn
            // 
            this.morningIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morningIn.AutoSize = true;
            this.morningIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.morningIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.morningIn.Location = new System.Drawing.Point(30, 10);
            this.morningIn.Name = "morningIn";
            this.morningIn.Size = new System.Drawing.Size(53, 15);
            this.morningIn.TabIndex = 3;
            this.morningIn.Text = "--:--:----";
            // 
            // morningInUpdate
            // 
            this.morningInUpdate.Checked = false;
            this.morningInUpdate.CustomFormat = "h:mm tt";
            this.morningInUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningInUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.morningInUpdate.Location = new System.Drawing.Point(8, 6);
            this.morningInUpdate.Name = "morningInUpdate";
            this.morningInUpdate.ShowUpDown = true;
            this.morningInUpdate.Size = new System.Drawing.Size(86, 23);
            this.morningInUpdate.TabIndex = 4;
            this.morningInUpdate.ValueChanged += new System.EventHandler(this.morningInUpdate_ValueChanged);
            // 
            // morningOutPanel
            // 
            this.morningOutPanel.Controls.Add(this.morningOutUpdate);
            this.morningOutPanel.Controls.Add(this.morningOut);
            this.morningOutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.morningOutPanel.Location = new System.Drawing.Point(238, 0);
            this.morningOutPanel.Name = "morningOutPanel";
            this.morningOutPanel.Size = new System.Drawing.Size(113, 35);
            this.morningOutPanel.TabIndex = 4;
            // 
            // morningOutUpdate
            // 
            this.morningOutUpdate.Checked = false;
            this.morningOutUpdate.CustomFormat = "h:mm tt";
            this.morningOutUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningOutUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.morningOutUpdate.Location = new System.Drawing.Point(13, 6);
            this.morningOutUpdate.Name = "morningOutUpdate";
            this.morningOutUpdate.ShowUpDown = true;
            this.morningOutUpdate.Size = new System.Drawing.Size(86, 23);
            this.morningOutUpdate.TabIndex = 5;
            this.morningOutUpdate.ValueChanged += new System.EventHandler(this.morningOutUpdate_ValueChanged);
            // 
            // morningOut
            // 
            this.morningOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morningOut.AutoSize = true;
            this.morningOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.morningOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.morningOut.Location = new System.Drawing.Point(30, 10);
            this.morningOut.Name = "morningOut";
            this.morningOut.Size = new System.Drawing.Size(53, 15);
            this.morningOut.TabIndex = 4;
            this.morningOut.Text = "--:--:----";
            // 
            // afternoonInPanel
            // 
            this.afternoonInPanel.Controls.Add(this.afternoonIn);
            this.afternoonInPanel.Controls.Add(this.afternoonInUpdate);
            this.afternoonInPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.afternoonInPanel.Location = new System.Drawing.Point(457, 0);
            this.afternoonInPanel.Name = "afternoonInPanel";
            this.afternoonInPanel.Size = new System.Drawing.Size(106, 35);
            this.afternoonInPanel.TabIndex = 6;
            // 
            // afternoonIn
            // 
            this.afternoonIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afternoonIn.AutoSize = true;
            this.afternoonIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.afternoonIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.afternoonIn.Location = new System.Drawing.Point(27, 10);
            this.afternoonIn.Name = "afternoonIn";
            this.afternoonIn.Size = new System.Drawing.Size(53, 15);
            this.afternoonIn.TabIndex = 5;
            this.afternoonIn.Text = "--:--:----";
            // 
            // afternoonInUpdate
            // 
            this.afternoonInUpdate.Checked = false;
            this.afternoonInUpdate.CustomFormat = "h:mm tt";
            this.afternoonInUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afternoonInUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.afternoonInUpdate.Location = new System.Drawing.Point(10, 6);
            this.afternoonInUpdate.Name = "afternoonInUpdate";
            this.afternoonInUpdate.ShowUpDown = true;
            this.afternoonInUpdate.Size = new System.Drawing.Size(86, 23);
            this.afternoonInUpdate.TabIndex = 6;
            this.afternoonInUpdate.ValueChanged += new System.EventHandler(this.afternoonInUpdate_ValueChanged);
            // 
            // afternoonOutPanel
            // 
            this.afternoonOutPanel.Controls.Add(this.afternoonOutUpdate);
            this.afternoonOutPanel.Controls.Add(this.afternoonOut);
            this.afternoonOutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.afternoonOutPanel.Location = new System.Drawing.Point(563, 0);
            this.afternoonOutPanel.Name = "afternoonOutPanel";
            this.afternoonOutPanel.Size = new System.Drawing.Size(106, 35);
            this.afternoonOutPanel.TabIndex = 7;
            // 
            // afternoonOutUpdate
            // 
            this.afternoonOutUpdate.Checked = false;
            this.afternoonOutUpdate.CustomFormat = "h:mm tt";
            this.afternoonOutUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afternoonOutUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.afternoonOutUpdate.Location = new System.Drawing.Point(10, 6);
            this.afternoonOutUpdate.Name = "afternoonOutUpdate";
            this.afternoonOutUpdate.ShowUpDown = true;
            this.afternoonOutUpdate.Size = new System.Drawing.Size(86, 23);
            this.afternoonOutUpdate.TabIndex = 7;
            this.afternoonOutUpdate.ValueChanged += new System.EventHandler(this.afternoonOutUpdate_ValueChanged);
            // 
            // afternoonOut
            // 
            this.afternoonOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afternoonOut.AutoSize = true;
            this.afternoonOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.afternoonOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.afternoonOut.Location = new System.Drawing.Point(27, 10);
            this.afternoonOut.Name = "afternoonOut";
            this.afternoonOut.Size = new System.Drawing.Size(53, 15);
            this.afternoonOut.TabIndex = 6;
            this.afternoonOut.Text = "--:--:----";
            // 
            // afternoonStatusPanel
            // 
            this.afternoonStatusPanel.Controls.Add(this.afternoonStatus);
            this.afternoonStatusPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.afternoonStatusPanel.Location = new System.Drawing.Point(669, 0);
            this.afternoonStatusPanel.Name = "afternoonStatusPanel";
            this.afternoonStatusPanel.Size = new System.Drawing.Size(106, 35);
            this.afternoonStatusPanel.TabIndex = 9;
            // 
            // afternoonStatus
            // 
            this.afternoonStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.afternoonStatus.AutoSize = true;
            this.afternoonStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.afternoonStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.afternoonStatus.Location = new System.Drawing.Point(0, 10);
            this.afternoonStatus.Name = "afternoonStatus";
            this.afternoonStatus.Size = new System.Drawing.Size(105, 15);
            this.afternoonStatus.TabIndex = 6;
            this.afternoonStatus.Text = "{Afternoon Status}";
            this.afternoonStatus.TextChanged += new System.EventHandler(this.afternoonStatus_TextChanged);
            // 
            // totalPanel
            // 
            this.totalPanel.Controls.Add(this.total);
            this.totalPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.totalPanel.Location = new System.Drawing.Point(775, 0);
            this.totalPanel.Name = "totalPanel";
            this.totalPanel.Size = new System.Drawing.Size(135, 35);
            this.totalPanel.TabIndex = 10;
            // 
            // total
            // 
            this.total.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.total.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.total.Location = new System.Drawing.Point(15, 10);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(103, 15);
            this.total.TabIndex = 7;
            this.total.Text = "Total Work Hours ";
            this.total.TextChanged += new System.EventHandler(this.total_TextChanged);
            // 
            // morningStatusPanel
            // 
            this.morningStatusPanel.Controls.Add(this.morningStatus);
            this.morningStatusPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.morningStatusPanel.Location = new System.Drawing.Point(351, 0);
            this.morningStatusPanel.Name = "morningStatusPanel";
            this.morningStatusPanel.Size = new System.Drawing.Size(106, 35);
            this.morningStatusPanel.TabIndex = 5;
            // 
            // morningStatus
            // 
            this.morningStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morningStatus.AutoSize = true;
            this.morningStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.morningStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.morningStatus.Location = new System.Drawing.Point(4, 10);
            this.morningStatus.Name = "morningStatus";
            this.morningStatus.Size = new System.Drawing.Size(97, 15);
            this.morningStatus.TabIndex = 5;
            this.morningStatus.Text = "{Morning Status}";
            this.morningStatus.TextChanged += new System.EventHandler(this.morningStatus_TextChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.Red;
            this.cancelBtn.BorderColor = System.Drawing.Color.Green;
            this.cancelBtn.BorderRadius = 5;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(1011, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(89, 25);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // absentBtn
            // 
            this.absentBtn.AutoSize = true;
            this.absentBtn.BackColor = System.Drawing.Color.Red;
            this.absentBtn.BackgroundColor = System.Drawing.Color.Red;
            this.absentBtn.BorderColor = System.Drawing.Color.Green;
            this.absentBtn.BorderRadius = 5;
            this.absentBtn.BorderSize = 0;
            this.absentBtn.FlatAppearance.BorderSize = 0;
            this.absentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.absentBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.absentBtn.ForeColor = System.Drawing.Color.White;
            this.absentBtn.Location = new System.Drawing.Point(1011, 4);
            this.absentBtn.Name = "absentBtn";
            this.absentBtn.Size = new System.Drawing.Size(89, 25);
            this.absentBtn.TabIndex = 12;
            this.absentBtn.Text = "Mark Absent";
            this.absentBtn.TextColor = System.Drawing.Color.White;
            this.absentBtn.UseVisualStyleBackColor = false;
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSize = true;
            this.submitBtn.BackColor = System.Drawing.Color.Green;
            this.submitBtn.BackgroundColor = System.Drawing.Color.Green;
            this.submitBtn.BorderColor = System.Drawing.Color.Green;
            this.submitBtn.BorderRadius = 5;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(916, 5);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(89, 25);
            this.submitBtn.TabIndex = 13;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // changeBtn
            // 
            this.changeBtn.AutoSize = true;
            this.changeBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.changeBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.changeBtn.BorderColor = System.Drawing.Color.Green;
            this.changeBtn.BorderRadius = 5;
            this.changeBtn.BorderSize = 0;
            this.changeBtn.FlatAppearance.BorderSize = 0;
            this.changeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.changeBtn.ForeColor = System.Drawing.Color.White;
            this.changeBtn.Location = new System.Drawing.Point(916, 5);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(89, 25);
            this.changeBtn.TabIndex = 11;
            this.changeBtn.Text = "Modify DTR";
            this.changeBtn.TextColor = System.Drawing.Color.White;
            this.changeBtn.UseVisualStyleBackColor = false;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // employeeLogUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.absentBtn);
            this.Controls.Add(this.totalPanel);
            this.Controls.Add(this.afternoonStatusPanel);
            this.Controls.Add(this.afternoonOutPanel);
            this.Controls.Add(this.afternoonInPanel);
            this.Controls.Add(this.morningStatusPanel);
            this.Controls.Add(this.morningOutPanel);
            this.Controls.Add(this.morningInPanel);
            this.Controls.Add(this.datePanel);
            this.Controls.Add(this.dayPanel);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.changeBtn);
            this.Name = "employeeLogUC";
            this.Size = new System.Drawing.Size(1106, 35);
            this.Load += new System.EventHandler(this.employeeDTRUC_Load);
            this.dayPanel.ResumeLayout(false);
            this.dayPanel.PerformLayout();
            this.datePanel.ResumeLayout(false);
            this.datePanel.PerformLayout();
            this.morningInPanel.ResumeLayout(false);
            this.morningInPanel.PerformLayout();
            this.morningOutPanel.ResumeLayout(false);
            this.morningOutPanel.PerformLayout();
            this.afternoonInPanel.ResumeLayout(false);
            this.afternoonInPanel.PerformLayout();
            this.afternoonOutPanel.ResumeLayout(false);
            this.afternoonOutPanel.PerformLayout();
            this.afternoonStatusPanel.ResumeLayout(false);
            this.afternoonStatusPanel.PerformLayout();
            this.totalPanel.ResumeLayout(false);
            this.totalPanel.PerformLayout();
            this.morningStatusPanel.ResumeLayout(false);
            this.morningStatusPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dayPanel;
        private System.Windows.Forms.Label day;
        private System.Windows.Forms.Panel datePanel;
        private System.Windows.Forms.Label dateLog;
        private System.Windows.Forms.Panel morningInPanel;
        private System.Windows.Forms.Label morningIn;
        private System.Windows.Forms.Panel morningOutPanel;
        private System.Windows.Forms.Label morningOut;
        private System.Windows.Forms.Panel afternoonInPanel;
        private System.Windows.Forms.Label afternoonIn;
        private System.Windows.Forms.Panel afternoonOutPanel;
        private System.Windows.Forms.Label afternoonOut;
        private System.Windows.Forms.Panel afternoonStatusPanel;
        private System.Windows.Forms.Label afternoonStatus;
        private System.Windows.Forms.Panel totalPanel;
        private System.Windows.Forms.Label total;
        private Custom.buttonDesign changeBtn;
        private System.Windows.Forms.DateTimePicker morningInUpdate;
        private System.Windows.Forms.DateTimePicker morningOutUpdate;
        private System.Windows.Forms.DateTimePicker afternoonInUpdate;
        private System.Windows.Forms.DateTimePicker afternoonOutUpdate;
        private Custom.buttonDesign absentBtn;
        private Custom.buttonDesign submitBtn;
        private Custom.buttonDesign cancelBtn;
        private System.Windows.Forms.Panel morningStatusPanel;
        private System.Windows.Forms.Label morningStatus;
    }
}
