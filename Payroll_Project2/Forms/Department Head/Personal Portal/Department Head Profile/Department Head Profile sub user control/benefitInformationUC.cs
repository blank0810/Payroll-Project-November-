using Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Modals;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control
{
    public partial class benefitInformationUC : UserControl
    {
        private static int _userId;
        private static personalProfileUC _parent;

        public string Month { get; set; }
        public int PayrollID { get; set; }
        public decimal TotalValue { get; set; }

        public benefitInformationUC(int userId, personalProfileUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            month.DataBindings.Add("Text", this, "Month");
            payrollId.DataBindings.Add("Text", this, "PayrollID");
            totalValue.DataBindings.Add("Text", this, "TotalValue");
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            payslipDetailedView details = new payslipDetailedView(_userId, this);
            details.ShowDialog();
        }

        private void benefitInformationUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
