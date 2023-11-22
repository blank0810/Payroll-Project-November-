namespace Payroll_Project2.Forms.Personnel.Municipal_Calendar.Calendar_Sub_User_Control
{
    partial class daysUC
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
            this.day = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.eventDesc = new System.Windows.Forms.Label();
            this.addEvent = new Payroll_Project2.Custom.buttonDesign();
            this.detailsBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.day.Location = new System.Drawing.Point(3, 6);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(19, 21);
            this.day.TabIndex = 1;
            this.day.Text = "1";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.status.ForeColor = System.Drawing.Color.DimGray;
            this.status.Location = new System.Drawing.Point(-1, 40);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(71, 13);
            this.status.TabIndex = 11;
            this.status.Text = "Event name:";
            // 
            // eventDesc
            // 
            this.eventDesc.AutoSize = true;
            this.eventDesc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDesc.Location = new System.Drawing.Point(-1, 54);
            this.eventDesc.Name = "eventDesc";
            this.eventDesc.Size = new System.Drawing.Size(90, 17);
            this.eventDesc.TabIndex = 11;
            this.eventDesc.Text = "{Event Name}";
            // 
            // addEvent
            // 
            this.addEvent.BackColor = System.Drawing.Color.White;
            this.addEvent.BackgroundColor = System.Drawing.Color.White;
            this.addEvent.BorderColor = System.Drawing.Color.Red;
            this.addEvent.BorderRadius = 0;
            this.addEvent.BorderSize = 2;
            this.addEvent.FlatAppearance.BorderSize = 0;
            this.addEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEvent.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEvent.ForeColor = System.Drawing.Color.Black;
            this.addEvent.Location = new System.Drawing.Point(3, 87);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(153, 25);
            this.addEvent.TabIndex = 13;
            this.addEvent.Text = "Add Event";
            this.addEvent.TextColor = System.Drawing.Color.Black;
            this.addEvent.UseVisualStyleBackColor = false;
            this.addEvent.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // detailsBtn
            // 
            this.detailsBtn.BackColor = System.Drawing.Color.White;
            this.detailsBtn.BackgroundColor = System.Drawing.Color.White;
            this.detailsBtn.BorderColor = System.Drawing.Color.ForestGreen;
            this.detailsBtn.BorderRadius = 0;
            this.detailsBtn.BorderSize = 2;
            this.detailsBtn.FlatAppearance.BorderSize = 0;
            this.detailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsBtn.ForeColor = System.Drawing.Color.Black;
            this.detailsBtn.Location = new System.Drawing.Point(3, 87);
            this.detailsBtn.Name = "detailsBtn";
            this.detailsBtn.Size = new System.Drawing.Size(153, 25);
            this.detailsBtn.TabIndex = 12;
            this.detailsBtn.Text = "View Event";
            this.detailsBtn.TextColor = System.Drawing.Color.Black;
            this.detailsBtn.UseVisualStyleBackColor = false;
            this.detailsBtn.Click += new System.EventHandler(this.detailsBtn_Click);
            // 
            // daysUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.eventDesc);
            this.Controls.Add(this.status);
            this.Controls.Add(this.day);
            this.Controls.Add(this.detailsBtn);
            this.Controls.Add(this.addEvent);
            this.Name = "daysUC";
            this.Size = new System.Drawing.Size(158, 115);
            this.Load += new System.EventHandler(this.daysUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label day;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label eventDesc;
        private Custom.buttonDesign detailsBtn;
        private Custom.buttonDesign addEvent;
    }
}
