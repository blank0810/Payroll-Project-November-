using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Payroll_Project2.Custom
{
    public class customDateTime : DateTimePicker
    {
        // Fields
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        private bool droppedDown = false;
        private Image calendarIcon = Properties.Resources.calendar_colored_16_x_16;
        //private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        public Color SkinColor 
        {
            get
            {
                return skinColor;
            }
            set
            {
                skinColor = value;

                if (skinColor.GetBrightness() >= 0.8F)
                {
                    calendarIcon = Properties.Resources.calendar_black_16_x_16;
                }
                else
                {
                    calendarIcon = Properties.Resources.calendar_colored_16_x_16;
                }
                this.Invalidate();
            }
        }

        public Color TextColor 
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor 
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public int BorderSize 
        { 
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            } 
        }

        // Constructor
        public customDateTime()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
        }

        // Overriden Functions
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;


                // Draw Surface
                graphics.FillRectangle(skinBrush, clientArea);
                // Draw Text
                graphics.DrawString(" " + this.Text, this.Font, textBrush, clientArea, textFormat);
                // Draw open calendar icon hightlight
                if (droppedDown == true) graphics.FillRectangle(openIconBrush, iconArea);
                // Draw Border
                if (borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                // Draw Icon
                graphics.DrawImage(calendarIcon, this.Width - calendarIcon.Width - 9, (this.Height - calendarIcon.Height) / 2);
            }
        }
    }
}
