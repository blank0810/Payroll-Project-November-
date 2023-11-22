using Payroll_Project2.Forms.Personnel.Employee.Modal;
using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control
{
    public partial class benefitContributionsUC : UserControl
    {
        private static int _userId;
        private static benefitsContribution _parent;

        public string Month { get; set; }
        public int PayrollID { get; set; }
        public int TotalValue { get; set; }

        public benefitContributionsUC(int userId, benefitsContribution parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void viewBtn_Click(object sender, System.EventArgs e)
        {
            payslipDetailedView payslip = new payslipDetailedView();
            payslip.ShowDialog();
        }
    }
}
