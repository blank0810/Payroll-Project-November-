namespace Payroll_Project2.Forms.Personnel.Payroll.Modal.User_Controls
{
    partial class deductionsUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.deductionType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deductionNumber = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.deductionAmount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deductionType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 33);
            this.panel1.TabIndex = 0;
            // 
            // deductionType
            // 
            this.deductionType.AutoSize = true;
            this.deductionType.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.deductionType.ForeColor = System.Drawing.Color.Black;
            this.deductionType.Location = new System.Drawing.Point(6, 6);
            this.deductionType.Name = "deductionType";
            this.deductionType.Size = new System.Drawing.Size(52, 19);
            this.deductionType.TabIndex = 6;
            this.deductionType.Text = "Absent";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deductionNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(305, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(106, 33);
            this.panel2.TabIndex = 1;
            // 
            // deductionNumber
            // 
            this.deductionNumber.AutoSize = true;
            this.deductionNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.deductionNumber.ForeColor = System.Drawing.Color.Black;
            this.deductionNumber.Location = new System.Drawing.Point(4, 6);
            this.deductionNumber.Name = "deductionNumber";
            this.deductionNumber.Size = new System.Drawing.Size(23, 19);
            this.deductionNumber.TabIndex = 7;
            this.deductionNumber.Text = "10";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.deductionAmount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(411, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(79, 33);
            this.panel3.TabIndex = 2;
            // 
            // deductionAmount
            // 
            this.deductionAmount.AutoSize = true;
            this.deductionAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.deductionAmount.ForeColor = System.Drawing.Color.Black;
            this.deductionAmount.Location = new System.Drawing.Point(3, 6);
            this.deductionAmount.Name = "deductionAmount";
            this.deductionAmount.Size = new System.Drawing.Size(39, 19);
            this.deductionAmount.TabIndex = 8;
            this.deductionAmount.Text = "1000";
            // 
            // deductionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "deductionsUC";
            this.Size = new System.Drawing.Size(490, 33);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label deductionType;
        private System.Windows.Forms.Label deductionNumber;
        private System.Windows.Forms.Label deductionAmount;
    }
}
