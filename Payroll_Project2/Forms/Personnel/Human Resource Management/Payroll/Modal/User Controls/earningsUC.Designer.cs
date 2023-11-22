namespace Payroll_Project2.Forms.Personnel.Payroll.Modal.User_Controls
{
    partial class earningsUC
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.earningsAmount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.earningsNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.earningsType = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.earningsAmount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(411, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(79, 33);
            this.panel3.TabIndex = 5;
            // 
            // earningsAmount
            // 
            this.earningsAmount.AutoSize = true;
            this.earningsAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.earningsAmount.ForeColor = System.Drawing.Color.Black;
            this.earningsAmount.Location = new System.Drawing.Point(3, 6);
            this.earningsAmount.Name = "earningsAmount";
            this.earningsAmount.Size = new System.Drawing.Size(39, 19);
            this.earningsAmount.TabIndex = 8;
            this.earningsAmount.Text = "1000";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.earningsNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(305, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(106, 33);
            this.panel2.TabIndex = 4;
            // 
            // earningsNumber
            // 
            this.earningsNumber.AutoSize = true;
            this.earningsNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.earningsNumber.ForeColor = System.Drawing.Color.Black;
            this.earningsNumber.Location = new System.Drawing.Point(4, 6);
            this.earningsNumber.Name = "earningsNumber";
            this.earningsNumber.Size = new System.Drawing.Size(23, 19);
            this.earningsNumber.TabIndex = 7;
            this.earningsNumber.Text = "10";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.earningsType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 33);
            this.panel1.TabIndex = 3;
            // 
            // earningsType
            // 
            this.earningsType.AutoSize = true;
            this.earningsType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.earningsType.ForeColor = System.Drawing.Color.Black;
            this.earningsType.Location = new System.Drawing.Point(6, 6);
            this.earningsType.Name = "earningsType";
            this.earningsType.Size = new System.Drawing.Size(149, 19);
            this.earningsType.TabIndex = 6;
            this.earningsType.Text = "Number of Days Work";
            // 
            // earningsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "earningsUC";
            this.Size = new System.Drawing.Size(490, 33);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label earningsAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label earningsNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label earningsType;
    }
}
