using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    public partial class employeeDataUC : UserControl
    {
        private static int _userId;
        private static payslipUC _parent;

        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public int PayrollID { get; set; }
        public string DateCreated { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalSalary { get; set; }

        public employeeDataUC(int userId, payslipUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            paySlipRequestDetailedView paySlip = new paySlipRequestDetailedView(_userId, this);
            paySlip.ShowDialog();
        }
    }
}
