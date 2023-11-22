using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Payroll_Project2.Custom
{
    public class customPanel: Panel // This is the design of a custom panel where this class is a child class that inherits the parent class called Panel
    {
        //Fields
        private int borderRadius = 30;
        private float gradientAngle = 90F;
        private Color gradientTopColor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.CadetBlue;

        //Constructor just like the OOP
        public customPanel()
        {
            
            this.BackColor= Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(350, 200);
        }

        //Properties
        public int BorderRadius 
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); } 
        }

        public float GradientAngle 
        {
            get => gradientAngle;
            set { gradientAngle = value; this.Invalidate(); } 
        }

        public Color GradientTopColor 
        { 
            get => gradientTopColor;
            set { gradientTopColor = value; this.Invalidate(); } 
        }
        public Color GradientBottomColor 
        { 
            get => gradientBottomColor; 
            set { gradientBottomColor = value; this.Invalidate(); }
        }

        //Methods
        
        private GraphicsPath getPath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicsPath= new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        //Overriden  Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Gradient
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle, this.GradientTopColor, this.gradientBottomColor, this.gradientAngle);
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(linearGradientBrush, ClientRectangle);


            // Border Radius
            RectangleF rectF = new RectangleF(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath graphicsPath = getPath(rectF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else
            {
                this.Region = new Region(rectF);
            }
        }
    }
}
