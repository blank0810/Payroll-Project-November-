using Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control
{
    public partial class payslipLogDataUC : UserControl
    {
        private static int _userId;
        private static payslipLogsUC _parent;

        public int PayrollID { get; set; }
        public string DateCreated { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalSalary { get; set; }

        public payslipLogDataUC(int userId, payslipLogsUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            personalPayslipDetailedView payslip = new personalPayslipDetailedView(_userId, this);
            payslip.ShowDialog();
        }
    }
}
