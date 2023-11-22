using Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Dashboard.Modals
{
    public partial class payslipDetailedView : Form
    {
        private static int _userId;
        private static benefitInformationUC _parent;

        public int TransactionNumber { get; set; }
        public string PayrollPeriod { get; set; }
        public int EmployeeID { get; set; }
        public string DepartmentName { get; set; }
        public decimal SalaryRate { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string EmploymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public string DateFiled { get; set; }
        public string CertifiedDetails { get; set; }
        public string ApproveDetails { get; set; }
        public string PaymentDetails { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal TotalSalary { get; set; }

        public payslipDetailedView(int userId, benefitInformationUC parent)
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
                earningsUC earningsUC = new earningsUC(_userId, this);
                earningsContent.Controls.Add(earningsUC);
            }
        }

        private void DisplayDeductions()
        {
            deductionsContent.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                deductionsUC deductionsUC = new deductionsUC(_userId, this);
                deductionsContent.Controls.Add(deductionsUC);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payslipDetailedView_Load(object sender, EventArgs e)
        {
            DisplayEarnings();
            DisplayDeductions();
        }
    }
}
