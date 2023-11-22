namespace Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_order_request_sub_user_control
{
    partial class requestDataUC
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
            this.employeeId = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.controlNumber = new System.Windows.Forms.Label();
            this.dateFiled = new System.Windows.Forms.Label();
            this.dateDeparture = new System.Windows.Forms.Label();
            this.notedBtn = new Payroll_Project2.Custom.buttonDesign();
            this.viewBtn = new Payroll_Project2.Custom.buttonDesign();
            this.SuspendLayout();
            // 
            // employeeId
            // 
            this.employeeId.AutoSize = true;
            this.employeeId.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.employeeId.ForeColor = System.Drawing.Color.DimGray;
            this.employeeId.Location = new System.Drawing.Point(0, 24);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(91, 17);
            this.employeeId.TabIndex = 6;
            this.employeeId.Text = "{Employee Id}";
            this.employeeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.employeeName.ForeColor = System.Drawing.Color.Black;
            this.employeeName.Location = new System.Drawing.Point(0, 2);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(130, 19);
            this.employeeName.TabIndex = 7;
            this.employeeName.Text = "{Employee name}";
            this.employeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // controlNumber
            // 
            this.controlNumber.AutoSize = true;
            this.controlNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.controlNumber.ForeColor = System.Drawing.Color.Black;
            this.controlNumber.Location = new System.Drawing.Point(370, 13);
            this.controlNumber.Name = "controlNumber";
            this.controlNumber.Size = new System.Drawing.Size(94, 19);
            this.controlNumber.TabIndex = 8;
            this.controlNumber.Text = "{Control no}";
            this.controlNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateFiled
            // 
            this.dateFiled.AutoSize = true;
            this.dateFiled.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.dateFiled.ForeColor = System.Drawing.Color.Black;
            this.dateFiled.Location = new System.Drawing.Point(604, 13);
            this.dateFiled.Name = "dateFiled";
            this.dateFiled.Size = new System.Drawing.Size(89, 19);
            this.dateFiled.TabIndex = 9;
            this.dateFiled.Text = "{Date Filed}";
            this.dateFiled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateDeparture
            // 
            this.dateDeparture.AutoSize = true;
            this.dateDeparture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.dateDeparture.ForeColor = System.Drawing.Color.Black;
            this.dateDeparture.Location = new System.Drawing.Point(800, 13);
            this.dateDeparture.Name = "dateDeparture";
            this.dateDeparture.Size = new System.Drawing.Size(126, 19);
            this.dateDeparture.TabIndex = 10;
            this.dateDeparture.Text = "{Date departure}";
            this.dateDeparture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notedBtn
            // 
            this.notedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.notedBtn.AutoSize = true;
            this.notedBtn.BackColor = System.Drawing.Color.Transparent;
            this.notedBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.notedBtn.BorderColor = System.Drawing.Color.ForestGreen;
            this.notedBtn.BorderRadius = 5;
            this.notedBtn.BorderSize = 2;
            this.notedBtn.FlatAppearance.BorderSize = 0;
            this.notedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notedBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.notedBtn.ForeColor = System.Drawing.Color.Black;
            this.notedBtn.Location = new System.Drawing.Point(1069, 8);
            this.notedBtn.Name = "notedBtn";
            this.notedBtn.Size = new System.Drawing.Size(84, 29);
            this.notedBtn.TabIndex = 11;
            this.notedBtn.Text = "Endorse";
            this.notedBtn.TextColor = System.Drawing.Color.Black;
            this.notedBtn.UseVisualStyleBackColor = false;
            this.notedBtn.Click += new System.EventHandler(this.notedBtn_Click);
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewBtn.AutoSize = true;
            this.viewBtn.BackColor = System.Drawing.Color.Transparent;
            this.viewBtn.BackgroundColor = System.Drawing.Color.Transparent;
            this.viewBtn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.viewBtn.BorderRadius = 5;
            this.viewBtn.BorderSize = 2;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.viewBtn.ForeColor = System.Drawing.Color.Black;
            this.viewBtn.Location = new System.Drawing.Point(1159, 8);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(84, 29);
            this.viewBtn.TabIndex = 12;
            this.viewBtn.Text = "View";
            this.viewBtn.TextColor = System.Drawing.Color.Black;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // requestDataUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.notedBtn);
            this.Controls.Add(this.dateDeparture);
            this.Controls.Add(this.dateFiled);
            this.Controls.Add(this.controlNumber);
            this.Controls.Add(this.employeeId);
            this.Controls.Add(this.employeeName);
            this.Name = "requestDataUC";
            this.Size = new System.Drawing.Size(1248, 45);
            this.Load += new System.EventHandler(this.requestDataUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employeeId;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.Label controlNumber;
        private System.Windows.Forms.Label dateFiled;
        private System.Windows.Forms.Label dateDeparture;
        private Custom.buttonDesign notedBtn;
        private Custom.buttonDesign viewBtn;
    }
}
