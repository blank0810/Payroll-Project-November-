using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll
{
    public partial class payroll : UserControl
    {

        // Function so that I can call this User Control to the Main Form
        private static payroll _instance;

        public static payroll Instance
        {
            get { return _instance ?? (_instance = new payroll()); }
        }

        public payroll()
        {
            InitializeComponent();
        }

        private void payroll_Load(object sender, EventArgs e)
        {

        }
    }
}
