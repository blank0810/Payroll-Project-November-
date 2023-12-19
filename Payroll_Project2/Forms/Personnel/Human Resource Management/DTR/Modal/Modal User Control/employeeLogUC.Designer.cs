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
            this.specialPrivilege = new System.Windows.Forms.LinkLabel();
            this.day = new System.Windows.Forms.Label();
            this.undertimeCountNumberOfMinutes = new System.Windows.Forms.Label();
            this.overtimeCountNumberOfMinutes = new System.Windows.Forms.Label();
            this.lateCountNumberOfMinutes = new System.Windows.Forms.Label();
            this.afternoonOut = new System.Windows.Forms.Label();
            this.afternoonIn = new System.Windows.Forms.Label();
            this.afternoonStatus = new System.Windows.Forms.Label();
            this.morningStatus = new System.Windows.Forms.Label();
            this.morningOut = new System.Windows.Forms.Label();
            this.morningIn = new System.Windows.Forms.Label();
            this.dateLog = new System.Windows.Forms.Label();
            this.morningInUpdate = new System.Windows.Forms.DateTimePicker();
            this.morningOutUpdate = new System.Windows.Forms.DateTimePicker();
            this.afternoonInUpdate = new System.Windows.Forms.DateTimePicker();
            this.afternoonOutUpdate = new System.Windows.Forms.DateTimePicker();
            this.cancelBtn = new Payroll_Project2.Custom.buttonDesign();
            this.submitBtn = new Payroll_Project2.Custom.buttonDesign();
            this.changeBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // specialPrivilege
            // 
            this.specialPrivilege.AutoSize = true;
            this.specialPrivilege.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialPrivilege.Location = new System.Drawing.Point(894, 16);
            this.specialPrivilege.Name = "specialPrivilege";
            this.specialPrivilege.Size = new System.Drawing.Size(64, 18);
            this.specialPrivilege.TabIndex = 16;
            this.specialPrivilege.TabStop = true;
            this.specialPrivilege.Text = "On Leave";
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.day.ForeColor = System.Drawing.Color.DimGray;
            this.day.Location = new System.Drawing.Point(4, 28);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(38, 17);
            this.day.TabIndex = 15;
            this.day.Text = "MON";
            // 
            // undertimeCountNumberOfMinutes
            // 
            this.undertimeCountNumberOfMinutes.AutoSize = true;
            this.undertimeCountNumberOfMinutes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undertimeCountNumberOfMinutes.Location = new System.Drawing.Point(798, 16);
            this.undertimeCountNumberOfMinutes.Name = "undertimeCountNumberOfMinutes";
            this.undertimeCountNumberOfMinutes.Size = new System.Drawing.Size(40, 18);
            this.undertimeCountNumberOfMinutes.TabIndex = 5;
            this.undertimeCountNumberOfMinutes.Text = "00:00";
            // 
            // overtimeCountNumberOfMinutes
            // 
            this.overtimeCountNumberOfMinutes.AutoSize = true;
            this.overtimeCountNumberOfMinutes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overtimeCountNumberOfMinutes.Location = new System.Drawing.Point(729, 16);
            this.overtimeCountNumberOfMinutes.Name = "overtimeCountNumberOfMinutes";
            this.overtimeCountNumberOfMinutes.Size = new System.Drawing.Size(40, 18);
            this.overtimeCountNumberOfMinutes.TabIndex = 6;
            this.overtimeCountNumberOfMinutes.Text = "00:00";
            // 
            // lateCountNumberOfMinutes
            // 
            this.lateCountNumberOfMinutes.AutoSize = true;
            this.lateCountNumberOfMinutes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lateCountNumberOfMinutes.Location = new System.Drawing.Point(661, 16);
            this.lateCountNumberOfMinutes.Name = "lateCountNumberOfMinutes";
            this.lateCountNumberOfMinutes.Size = new System.Drawing.Size(40, 18);
            this.lateCountNumberOfMinutes.TabIndex = 7;
            this.lateCountNumberOfMinutes.Text = "00:00";
            // 
            // afternoonOut
            // 
            this.afternoonOut.AutoSize = true;
            this.afternoonOut.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afternoonOut.Location = new System.Drawing.Point(477, 16);
            this.afternoonOut.Name = "afternoonOut";
            this.afternoonOut.Size = new System.Drawing.Size(64, 18);
            this.afternoonOut.TabIndex = 8;
            this.afternoonOut.Text = "00:00 PM";
            // 
            // afternoonIn
            // 
            this.afternoonIn.AutoSize = true;
            this.afternoonIn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afternoonIn.Location = new System.Drawing.Point(389, 16);
            this.afternoonIn.Name = "afternoonIn";
            this.afternoonIn.Size = new System.Drawing.Size(64, 18);
            this.afternoonIn.TabIndex = 9;
            this.afternoonIn.Text = "00:00 PM";
            // 
            // afternoonStatus
            // 
            this.afternoonStatus.AutoSize = true;
            this.afternoonStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afternoonStatus.Location = new System.Drawing.Point(573, 16);
            this.afternoonStatus.Name = "afternoonStatus";
            this.afternoonStatus.Size = new System.Drawing.Size(60, 18);
            this.afternoonStatus.TabIndex = 10;
            this.afternoonStatus.Text = "On Time";
            // 
            // morningStatus
            // 
            this.morningStatus.AutoSize = true;
            this.morningStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningStatus.Location = new System.Drawing.Point(304, 16);
            this.morningStatus.Name = "morningStatus";
            this.morningStatus.Size = new System.Drawing.Size(60, 18);
            this.morningStatus.TabIndex = 11;
            this.morningStatus.Text = "On Time";
            // 
            // morningOut
            // 
            this.morningOut.AutoSize = true;
            this.morningOut.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningOut.Location = new System.Drawing.Point(198, 16);
            this.morningOut.Name = "morningOut";
            this.morningOut.Size = new System.Drawing.Size(65, 18);
            this.morningOut.TabIndex = 12;
            this.morningOut.Text = "00:00 AM";
            // 
            // morningIn
            // 
            this.morningIn.AutoSize = true;
            this.morningIn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningIn.Location = new System.Drawing.Point(102, 16);
            this.morningIn.Name = "morningIn";
            this.morningIn.Size = new System.Drawing.Size(65, 18);
            this.morningIn.TabIndex = 13;
            this.morningIn.Text = "00:00 AM";
            // 
            // dateLog
            // 
            this.dateLog.AutoSize = true;
            this.dateLog.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLog.Location = new System.Drawing.Point(4, 5);
            this.dateLog.Name = "dateLog";
            this.dateLog.Size = new System.Drawing.Size(76, 18);
            this.dateLog.TabIndex = 14;
            this.dateLog.Text = "Dec 1, 2023";
            // 
            // morningInUpdate
            // 
            this.morningInUpdate.CustomFormat = "hh:mm tt";
            this.morningInUpdate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.morningInUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.morningInUpdate.Location = new System.Drawing.Point(99, 14);
            this.morningInUpdate.Name = "morningInUpdate";
            this.morningInUpdate.ShowUpDown = true;
            this.morningInUpdate.Size = new System.Drawing.Size(85, 26);
            this.morningInUpdate.TabIndex = 20;
            this.morningInUpdate.Visible = false;
            // 
            // morningOutUpdate
            // 
            this.morningOutUpdate.CustomFormat = "hh:mm tt";
            this.morningOutUpdate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.morningOutUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.morningOutUpdate.Location = new System.Drawing.Point(201, 14);
            this.morningOutUpdate.Name = "morningOutUpdate";
            this.morningOutUpdate.ShowUpDown = true;
            this.morningOutUpdate.Size = new System.Drawing.Size(85, 26);
            this.morningOutUpdate.TabIndex = 21;
            this.morningOutUpdate.Visible = false;
            // 
            // afternoonInUpdate
            // 
            this.afternoonInUpdate.CustomFormat = "hh:mm tt";
            this.afternoonInUpdate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.afternoonInUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.afternoonInUpdate.Location = new System.Drawing.Point(386, 14);
            this.afternoonInUpdate.Name = "afternoonInUpdate";
            this.afternoonInUpdate.ShowUpDown = true;
            this.afternoonInUpdate.Size = new System.Drawing.Size(85, 26);
            this.afternoonInUpdate.TabIndex = 21;
            this.afternoonInUpdate.Visible = false;
            // 
            // afternoonOutUpdate
            // 
            this.afternoonOutUpdate.CustomFormat = "hh:mm tt";
            this.afternoonOutUpdate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.afternoonOutUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.afternoonOutUpdate.Location = new System.Drawing.Point(478, 14);
            this.afternoonOutUpdate.Name = "afternoonOutUpdate";
            this.afternoonOutUpdate.ShowUpDown = true;
            this.afternoonOutUpdate.Size = new System.Drawing.Size(85, 26);
            this.afternoonOutUpdate.TabIndex = 21;
            this.afternoonOutUpdate.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.BackColor = System.Drawing.Color.Maroon;
            this.cancelBtn.BackgroundColor = System.Drawing.Color.Maroon;
            this.cancelBtn.BorderColor = System.Drawing.Color.Green;
            this.cancelBtn.BorderRadius = 3;
            this.cancelBtn.BorderSize = 0;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(1103, 9);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(79, 28);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextColor = System.Drawing.Color.White;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSize = true;
            this.submitBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.submitBtn.BorderColor = System.Drawing.Color.Green;
            this.submitBtn.BorderRadius = 3;
            this.submitBtn.BorderSize = 0;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(1018, 10);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(79, 28);
            this.submitBtn.TabIndex = 18;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.White;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Visible = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // changeBtn
            // 
            this.changeBtn.AutoSize = true;
            this.changeBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.changeBtn.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.changeBtn.BorderColor = System.Drawing.Color.Green;
            this.changeBtn.BorderRadius = 3;
            this.changeBtn.BorderSize = 0;
            this.changeBtn.FlatAppearance.BorderSize = 0;
            this.changeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.changeBtn.ForeColor = System.Drawing.Color.White;
            this.changeBtn.Location = new System.Drawing.Point(1018, 10);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(79, 28);
            this.changeBtn.TabIndex = 17;
            this.changeBtn.Text = "Update";
            this.changeBtn.TextColor = System.Drawing.Color.White;
            this.changeBtn.UseVisualStyleBackColor = false;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // employeeLogUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.specialPrivilege);
            this.Controls.Add(this.day);
            this.Controls.Add(this.undertimeCountNumberOfMinutes);
            this.Controls.Add(this.overtimeCountNumberOfMinutes);
            this.Controls.Add(this.lateCountNumberOfMinutes);
            this.Controls.Add(this.afternoonOut);
            this.Controls.Add(this.afternoonIn);
            this.Controls.Add(this.afternoonStatus);
            this.Controls.Add(this.morningStatus);
            this.Controls.Add(this.morningOut);
            this.Controls.Add(this.dateLog);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.morningIn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.morningOutUpdate);
            this.Controls.Add(this.morningInUpdate);
            this.Controls.Add(this.afternoonInUpdate);
            this.Controls.Add(this.afternoonOutUpdate);
            this.Controls.Add(this.changeBtn);
            this.Name = "employeeLogUC";
            this.Size = new System.Drawing.Size(1196, 49);
            this.Load += new System.EventHandler(this.employeeDTRUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel specialPrivilege;
        private System.Windows.Forms.Label day;
        private System.Windows.Forms.Label undertimeCountNumberOfMinutes;
        private System.Windows.Forms.Label overtimeCountNumberOfMinutes;
        private System.Windows.Forms.Label lateCountNumberOfMinutes;
        private System.Windows.Forms.Label afternoonOut;
        private System.Windows.Forms.Label afternoonIn;
        private System.Windows.Forms.Label afternoonStatus;
        private System.Windows.Forms.Label morningStatus;
        private System.Windows.Forms.Label morningOut;
        private System.Windows.Forms.Label morningIn;
        private System.Windows.Forms.Label dateLog;
        private Custom.buttonDesign changeBtn;
        private Custom.buttonDesign submitBtn;
        private Custom.buttonDesign cancelBtn;
        private System.Windows.Forms.DateTimePicker morningInUpdate;
        private System.Windows.Forms.DateTimePicker morningOutUpdate;
        private System.Windows.Forms.DateTimePicker afternoonInUpdate;
        private System.Windows.Forms.DateTimePicker afternoonOutUpdate;
    }
}
