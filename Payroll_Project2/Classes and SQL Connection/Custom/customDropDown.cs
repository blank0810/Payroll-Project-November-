using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Custom
{
    public class customDropDown : ContextMenuStrip
    {
        // Fields
        private bool isMainMenu;
        private int menuItemHeight = 25;
        private Color menuItemTextColor = Color.DimGray;
        private Color primaryColor = Color.MediumSlateBlue;

        private Bitmap menuItemHeaderSize;

        public customDropDown(IContainer container)
            : base(container)
        {

        }

        [Browsable (false)]
        public bool IsMainMenu
        {
            get
            {
                return isMainMenu;
            }

            set
            {
                isMainMenu = value;
            }
        }

        [Browsable(false)]
        public int MenuItemHeight
        {
            get
            {
                return menuItemHeight;
            }

            set
            {
                menuItemHeight = value;
            }
        }

        [Browsable(false)]
        public Color MenuItemColor
        {
            get
            {
                return menuItemTextColor;
            }

            set
            {
                menuItemTextColor = value;
            }
        }

        [Browsable(false)]
        public Color PrimaryColor
        {
            get
            {
                return primaryColor;
            }

            set
            {
                primaryColor = value;
            }
        }

        // Private Methods
        private void LoadMenuItemAppearance()
        {
            if (isMainMenu) 
            {
                menuItemHeaderSize = new Bitmap(25, 45);
                menuItemTextColor = Color.Gainsboro;
            }
            else
            {
                menuItemHeaderSize = new Bitmap(15, menuItemHeight);
            }

            foreach (ToolStripMenuItem menuItemL1 in this.Items)
            {
                menuItemL1.ForeColor = menuItemTextColor;
                menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItemL1.Image == null) menuItemL1.Image = menuItemHeaderSize;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode == false)
            {
                LoadMenuItemAppearance();
                this.Renderer = new customMenuRenderer(isMainMenu, primaryColor, menuItemTextColor); 
            }
        }
    }
}
