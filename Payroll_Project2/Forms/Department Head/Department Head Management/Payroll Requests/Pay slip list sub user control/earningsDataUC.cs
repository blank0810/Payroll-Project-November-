using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    public partial class earningsDataUC : UserControl
    {
        private static int _userId;
        private static paySlipRequestDetailedView _parent;

        public string EarningsDescription { get; set; }
        public string EarningsNumber { get; set; }
        public string EarningsAmount { get; set; }

        public earningsDataUC(int userId, paySlipRequestDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
    }
}
