using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests
{
    public partial class payslipUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;

        public payslipUC(int userId, departmentHeadDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DisplayPaySlip()
        {
            payrollRequestPanel.Controls.Clear();

            for (int i = 0; i < 10; i++)
            {
                employeeDataUC employee = new employeeDataUC(_userId, this);
                payrollRequestPanel.Controls.Add(employee);
            }
        }

        private void payslipUC_Load(object sender, EventArgs e)
        {
            DisplayPaySlip();
        }
    }
}
