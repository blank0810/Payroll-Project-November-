namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Travel_Order.File_Travel_Order_sub_user_control
{
    partial class travelOrderDataUC
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
            this.controlNumber = new System.Windows.Forms.Label();
            this.departureDate = new System.Windows.Forms.Label();
            this.purpose = new System.Windows.Forms.Label();
            this.destination = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlNumber
            // 
            this.controlNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlNumber.Location = new System.Drawing.Point(4, 8);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(130, 19);
            this.controlNumber.TabIndex = 19;
            this.controlNumber.Text = "{Control number}";
            // 
            // departureDate
            // 
            this.departureDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.departureDate.AutoSize = true;
            this.departureDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDate.Location = new System.Drawing.Point(190, 8);
            this.departureDate.Name = "departureDate";
            this.departureDate.Size = new System.Drawing.Size(126, 19);
            this.departureDate.TabIndex = 19;
            this.departureDate.Text = "{Departure date}";
            // 
            // purpose
            // 
            this.purpose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.purpose.AutoSize = true;
            this.purpose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purpose.Location = new System.Drawing.Point(390, 8);
            this.purpose.Name = "purpose";
            this.purpose.Size = new System.Drawing.Size(77, 19);
            this.purpose.TabIndex = 19;
            this.purpose.Text = "{Purpose}";
            // 
            // destination
            // 
            this.destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.destination.AutoSize = true;
            this.destination.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destination.Location = new System.Drawing.Point(560, 8);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(98, 19);
            this.destination.TabIndex = 19;
            this.destination.Text = "{Destination}";
            // 
            // travelOrderDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.destination);
            this.Controls.Add(this.purpose);
            this.Controls.Add(this.departureDate);
            this.Controls.Add(this.controlNumber);
            this.Name = "travelOrderDataUC";
            this.Size = new System.Drawing.Size(766, 36);
            this.Load += new System.EventHandler(this.travelOrderDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label controlNumber;
        private System.Windows.Forms.Label departureDate;
        private System.Windows.Forms.Label purpose;
        private System.Windows.Forms.Label destination;
    }
}
