namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Travel_Order_Logs.Travel_order_log_sub_user_control
{
    partial class travelOrderLogDataUC
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
            this.status = new System.Windows.Forms.Label();
            this.dateDeparture = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
            this.controlNumber = new System.Windows.Forms.Label();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(869, 10);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(64, 19);
            this.status.TabIndex = 15;
            this.status.Text = "{Status}";
            // 
            // dateDeparture
            // 
            this.dateDeparture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateDeparture.AutoSize = true;
            this.dateDeparture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDeparture.Location = new System.Drawing.Point(597, 10);
            this.dateDeparture.Name = "dateDeparture";
            this.dateDeparture.Size = new System.Drawing.Size(126, 19);
            this.dateDeparture.TabIndex = 16;
            this.dateDeparture.Text = "{Date departure}";
            // 
            // dateFiled
            // 
            this.dateFiled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFiled.Location = new System.Drawing.Point(364, 10);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(87, 19);
            this.dateFiled.TabIndex = 17;
            this.dateFiled.Text = "{Date filed}";
            // 
            // controlNumber
            // 
            this.controlNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlNumber.Location = new System.Drawing.Point(4, 10);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(130, 19);
            this.controlNumber.TabIndex = 18;
            this.controlNumber.Text = "{Control number}";
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderColor = System.Drawing.Color.ForestGreen;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.Location = new System.Drawing.Point(1104, 5);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(116, 29);
            this.viewBtn.TabIndex = 19;
            this.viewBtn.Text = "View Details";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // travelOrderLogDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.dateDeparture);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.controlNumber);
            this.Name = "travelOrderLogDataUC";
            this.Size = new System.Drawing.Size(1227, 39);
            this.Load += new System.EventHandler(this.travelOrderLogDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.buttonDesign viewBtn;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label dateDeparture;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label controlNumber;
    }
}
