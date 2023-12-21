using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    public partial class deductionDataUC : UserControl
    {
        private static int _userId;
        private static paySlipRequestDetailedView _parent;

        public string DeductionDescription { get; set; }
        public string DeductionAmount { get; set; }

        public deductionDataUC(int userId, paySlipRequestDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            deductionsDescription.DataBindings.Add("Text", this, "DeductionDescription");
            deductionAmount.DataBindings.Add("Text", this, "DeductionAmount");
        }

        private void deductionDataUC_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }
    }
}
