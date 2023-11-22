using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal_Sub_User_Controls;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Modal
{
    public partial class benefitsContribution : Form
    {
        private static int _userId;
        private static benefitsDetailsUC _parent;
        employeeClass employeeClass = new employeeClass();

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string BenefitName { get; set; }
        public string BenefitStatus { get; set; }

        public benefitsContribution(int userId, benefitsDetailsUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void benefitsContribution_Load(object sender, EventArgs e)
        {
            benefitContributionsUC  benefitContribution = new benefitContributionsUC(_userId, this);
            recordList.Controls.Clear();
            recordList.Controls.Add(benefitContribution);
        }
    }
}
