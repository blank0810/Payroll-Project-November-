using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.User_Controls
{
    public partial class payrollListUC : UserControl
    {
        public payrollListUC()
        {
            InitializeComponent();
        }

        private void viewPaySlip_Click(object sender, EventArgs e)
        {
            payslipListModal payslipList = new payslipListModal();
            payslipList.ShowDialog();
        }
    }
}
