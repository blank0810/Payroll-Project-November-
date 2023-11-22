using Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Modals
{
    public partial class payslipDetailedView : Form
    {
        private static int _userId;
        private static benefitInformationUC _parent;

        public int TransactionNumber { get; set; }
        public string PayrollPeriod { get; set; }
        public int EmployeeID {  get; set; }
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

        private void DataBinding()
        {
            transactionNumber.DataBindings.Add("Text", this, "TransactionNumber");
            payslipPeriod.DataBindings.Add("Text", this, "PayrollPeriod");
            employeeId.DataBindings.Add("Text", this, "EmployeeID");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            status.DataBindings.Add("Text", this, "EmploymentStatus");
            createdBy.DataBindings.Add("Text", this, "CreatedBy");
            dateCreated.DataBindings.Add("Text", this, "DateFiled");
            certifiedDetails.DataBindings.Add("Text", this, "CertifiedDetails");
            approvedDetails.DataBindings.Add("Text", this, "ApproveDetails");
            paymentDetails.DataBindings.Add("Text", this, "PaymentDetails");
            totalEarnings.DataBindings.Add("Text", this, "TotalEarnings", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");
            totalDeduction.DataBindings.Add("Text", this, "TotalDeductions", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");
            totalAmount.DataBindings.Add("Text", this, "TotalSalary", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");

            DisplayEarnings();
            DisplayDeductions();
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
            DataBinding();
        }
    }
}
