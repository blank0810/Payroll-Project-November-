using Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Modal;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control
{
    public partial class payslipEarningsUC : UserControl
    {
        private static int _userId;
        private static personalPayslipDetailedView _parent;

        public string EarningsDescription { get; set; }
        public int EarningsNumber { get; set; }
        public string EarningsAmount { get; set; }

        public payslipEarningsUC(int userId, personalPayslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            earningsDescription.DataBindings.Add("Text", this, "EarningsDescription");
            earningsAmount.DataBindings.Add("Text", this, "EarningsAmount");
        }

        private void payslipEarningsUC_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }
    }
}
