using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Payroll_Project2.Custom
{
    [DefaultEvent ("_TextChanged")]

    public partial class customTextBox2 : UserControl
    {
        // Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.Pink;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DimGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        //internal bool ReadOnly;

        // Constructor
        public customTextBox2()
        {
            InitializeComponent();
        }

        public event EventHandler _TextChanged;

        // Properties
        [Category("Custom Properties")]
        public Color BorderColor 
        { 
            get => borderColor;

            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Custom Properties")]
        public int BorderSize 
        { 
            get => borderSize;

            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Custom Properties")]
        public bool UnderlinedStyle 
        { 
            get => underlinedStyle;

            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Custom Properties")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            
            set 
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value; 
            }
        }

        [Category("Custom Properties")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Custom Properties")]
        public override Color BackColor
        {
            get { return base.BackColor; }

            set 
            { 
                base.BackColor = value; 
                textBox1.BackColor = value; 
            }
        }

        [Category("Custom Properties")]
        public override Font Font 
        {
            get { return base.Font; }
            set 
            { 
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Category ("Custom Properties")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        [Category("Custom Properties")]
        public Color BorderFocusColor 
        { 
            get => borderFocusColor; 
            set => borderFocusColor = value; 
        }

        [Category("Custom Properties")]
        public int BorderRadius 
        {
            get
            {
                return borderRadius;
            }

            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Custom Properties")]
        public Color PlaceholderColor 
        {
            get
            {
                return placeholderColor;
            }

            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }

        [Category("Custom Properties")]
        public string PlaceholderText 
        {
            get
            {
                return placeholderText;
            }

            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        public int SelectionStart { get; internal set; }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if(isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        // Overriden Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1) // Rounded Text Box
            {
                // Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    // Drawing
                    this.Region = new Region(pathBorderSmooth); // Set the rounded region of the user control
                    if (borderRadius > 15) SetTextBoxRoudedRegion(); // Set the rounded region of the Text Box component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = PenAlignment.Center;

                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle) // Underlined Style
                    {
                        // Draw border Smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        // Draw Border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else // Normal Style
                    {
                        // Draw border Smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        // Draw Border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }    
            }
            else // Normal Text Box
            {
                // Draw Border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);

                    penBorder.Alignment = PenAlignment.Inset;

                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle) // Underlined Style
                    {
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else // Normal Style
                    {
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
            }
        }

        private void SetTextBoxRoudedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }    
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        // Private methods
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }


        // Events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged!= null) 
            { 
                _TextChanged(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
    }
}
