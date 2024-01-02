using Payroll_Project2.Custom;

namespace Payroll_Project2
{
    partial class loginForm
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDesign1 = new Payroll_Project2.Custom.buttonDesign();
            this.troubleLink = new System.Windows.Forms.LinkLabel();
            this.idBox = new Payroll_Project2.Custom.customTextBox2();
            this.passBox = new Payroll_Project2.Custom.customTextBox2();
            this.customPictureBox1 = new Payroll_Project2.Custom.customPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sign in to start your session";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(86, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(86, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // buttonDesign1
            // 
            this.buttonDesign1.BackColor = System.Drawing.Color.Navy;
            this.buttonDesign1.BackgroundColor = System.Drawing.Color.Navy;
            this.buttonDesign1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonDesign1.BorderRadius = 5;
            this.buttonDesign1.BorderSize = 0;
            this.buttonDesign1.FlatAppearance.BorderSize = 0;
            this.buttonDesign1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesign1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDesign1.ForeColor = System.Drawing.Color.White;
            this.buttonDesign1.Location = new System.Drawing.Point(86, 342);
            this.buttonDesign1.Name = "buttonDesign1";
            this.buttonDesign1.Size = new System.Drawing.Size(227, 32);
            this.buttonDesign1.TabIndex = 9;
            this.buttonDesign1.Text = "Login";
            this.buttonDesign1.TextColor = System.Drawing.Color.White;
            this.buttonDesign1.UseVisualStyleBackColor = false;
            this.buttonDesign1.Click += new System.EventHandler(this.buttonDesign1_Click_1);
            // 
            // troubleLink
            // 
            this.troubleLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.troubleLink.AutoSize = true;
            this.troubleLink.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.troubleLink.LinkColor = System.Drawing.Color.DimGray;
            this.troubleLink.Location = new System.Drawing.Point(138, 386);
            this.troubleLink.Name = "troubleLink";
            this.troubleLink.Size = new System.Drawing.Size(123, 20);
            this.troubleLink.TabIndex = 10;
            this.troubleLink.TabStop = true;
            this.troubleLink.Text = "Forgot password";
            // 
            // idBox
            // 
            this.idBox.BackColor = System.Drawing.SystemColors.Window;
            this.idBox.BorderColor = System.Drawing.Color.DimGray;
            this.idBox.BorderFocusColor = System.Drawing.Color.Black;
            this.idBox.BorderRadius = 0;
            this.idBox.BorderSize = 2;
            this.idBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idBox.ForeColor = System.Drawing.Color.Black;
            this.idBox.Location = new System.Drawing.Point(86, 221);
            this.idBox.Multiline = false;
            this.idBox.Name = "idBox";
            this.idBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.idBox.PasswordChar = false;
            this.idBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.idBox.PlaceholderText = "Enter your ID number";
            this.idBox.Size = new System.Drawing.Size(227, 30);
            this.idBox.TabIndex = 11;
            this.idBox.Texts = "";
            this.idBox.UnderlinedStyle = true;
            this.idBox._TextChanged += new System.EventHandler(this.idBox__TextChanged);
            this.idBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idBox_KeyPress);
            // 
            // passBox
            // 
            this.passBox.BackColor = System.Drawing.SystemColors.Window;
            this.passBox.BorderColor = System.Drawing.Color.Gray;
            this.passBox.BorderFocusColor = System.Drawing.Color.Black;
            this.passBox.BorderRadius = 0;
            this.passBox.BorderSize = 2;
            this.passBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passBox.ForeColor = System.Drawing.Color.Black;
            this.passBox.Location = new System.Drawing.Point(86, 293);
            this.passBox.Multiline = false;
            this.passBox.Name = "passBox";
            this.passBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.passBox.PasswordChar = true;
            this.passBox.PlaceholderColor = System.Drawing.Color.DimGray;
            this.passBox.PlaceholderText = "Enter your password";
            this.passBox.Size = new System.Drawing.Size(227, 30);
            this.passBox.TabIndex = 12;
            this.passBox.Texts = "";
            this.passBox.UnderlinedStyle = true;
            this.passBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passBox_KeyPress);
            // 
            // customPictureBox1
            // 
            this.customPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.customPictureBox1.BorderColor = System.Drawing.Color.Black;
            this.customPictureBox1.BorderColor2 = System.Drawing.Color.Black;
            this.customPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.customPictureBox1.BorderSize = 2;
            this.customPictureBox1.GradientAngle = 50F;
            this.customPictureBox1.Image = global::Payroll_Project2.Properties.Resources.initao_logo;
            this.customPictureBox1.Location = new System.Drawing.Point(143, 23);
            this.customPictureBox1.Name = "customPictureBox1";
            this.customPictureBox1.Size = new System.Drawing.Size(112, 112);
            this.customPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customPictureBox1.TabIndex = 0;
            this.customPictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.customPictureBox1);
            this.panel1.Controls.Add(this.troubleLink);
            this.panel1.Controls.Add(this.passBox);
            this.panel1.Controls.Add(this.buttonDesign1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.idBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(412, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 474);
            this.panel1.TabIndex = 13;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1168, 710);
            this.Controls.Add(this.panel1);
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customPictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private customTextBox2 passBox;
        private customTextBox2 idBox;
        private System.Windows.Forms.LinkLabel troubleLink;
        private buttonDesign buttonDesign1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private customPictureBox customPictureBox1;
    }
}

