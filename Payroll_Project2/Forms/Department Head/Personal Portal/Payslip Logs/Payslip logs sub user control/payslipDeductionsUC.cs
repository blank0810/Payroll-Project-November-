using Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Modal;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control
{
    public partial class payslipDeductionsUC : UserControl
    {
        private static int _userId;
        private static personalPayslipDetailedView _parent;

        public string DeductionDescription { get; set; }
        public int DeductionNumber { get; set; }
        public string DeductionAmount { get; set; }

        public payslipDeductionsUC(int userId, personalPayslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
        private void DataBinding()
        {
            deductionDescription.DataBindings.Add("Text", this, "DeductionDescription");
            deductionsAmount.DataBindings.Add("Text", this, "DeductionAmount");
        }

        private void payslipDeductionsUC_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }
    }
}
