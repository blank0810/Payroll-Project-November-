using Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Modal
{
    public partial class personalPayslipDetailedView : Form
    {
        private static int _userId;
        private static payslipLogDataUC _parent;

        public int TransactionNumber { get; set; }
        public string PayslipPeriod { get; set; }
        public int EmployeeID { get; set; }
        public string DepartmentName { get; set; }
        public decimal SalaryRate { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string EmploymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string CertifyDetails { get; set; }
        public string ApproveDetails { get; set; }
        public string PaymentCertifyDetails { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalSalary { get; set; }

        public personalPayslipDetailedView(int userId, payslipLogDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DisplayEarnings()
        {
            earningsContent.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                payslipEarningsUC earnings = new payslipEarningsUC(_userId, this);
                earningsContent.Controls.Add(earnings);
            }
        }

        private void DisplayDeductions()
        {
            deductionsContent.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                payslipDeductionsUC deductions = new payslipDeductionsUC(_userId, this);
                deductionsContent.Controls.Add(deductions);
            }
        }

        private void personalPayslipDetailedView_Load(object sender, EventArgs e)
        {
            DisplayEarnings();
            DisplayDeductions();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
