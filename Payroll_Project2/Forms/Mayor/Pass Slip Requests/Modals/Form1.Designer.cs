namespace Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Modals
{
    partial class Form1
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
            this.panel13 = new System.Windows.Forms.Panel();
            this.mayorJobDescription = new System.Windows.Forms.Label();
            this.mayor = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel13.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.mayorJobDescription);
            this.panel13.Controls.Add(this.mayor);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 27);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(800, 82);
            this.panel13.TabIndex = 55;
            // 
            // mayorJobDescription
            // 
            this.mayorJobDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mayorJobDescription.AutoSize = true;
            this.mayorJobDescription.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.mayorJobDescription.ForeColor = System.Drawing.Color.DimGray;
            this.mayorJobDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mayorJobDescription.Location = new System.Drawing.Point(344, 34);
            this.mayorJobDescription.Name = "mayorJobDescription";
            this.mayorJobDescription.Size = new System.Drawing.Size(113, 18);
            this.mayorJobDescription.TabIndex = 50;
            this.mayorJobDescription.Text = "Municipal Mayor";
            this.mayorJobDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mayor
            // 
            this.mayor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mayor.AutoSize = true;
            this.mayor.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.mayor.ForeColor = System.Drawing.Color.Black;
            this.mayor.Location = new System.Drawing.Point(321, 10);
            this.mayor.Name = "mayor";
            this.mayor.Size = new System.Drawing.Size(158, 22);
            this.mayor.TabIndex = 49;
            this.mayor.Text = "Leonides B. Baluran";
            this.mayor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.label11);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(800, 27);
            this.panel9.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(10, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 22);
            this.label11.TabIndex = 1;
            this.label11.Text = "Approval Information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel9);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label mayorJobDescription;
        private System.Windows.Forms.Label mayor;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label11;
    }
}