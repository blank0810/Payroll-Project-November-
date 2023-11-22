using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.User_Controls
{
    public partial class employeeList : UserControl
    {
        public employeeList()
        {
            InitializeComponent();
        }

        private void buttonDesign1_Click(object sender, EventArgs e)
        {
            payslip slip = new payslip();
            slip.ShowDialog();
        }
    }
}
