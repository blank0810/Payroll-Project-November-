using Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Modals;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control
{
    public partial class earningsUC : UserControl
    {
        private static int _userId;
        private static payslipDetailedView _parent;

        public string EarningsDescription { get; set; }
        public int EarningsNumber {  get; set; }
        public decimal EarningsAmount {  get; set; }

        public earningsUC(int userId, payslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            earningsDescription.DataBindings.Add("Text", this, "EarningsDescription");
            earningsNumber.DataBindings.Add("Text", this, "EarningsNumber");
            earningsAmount.DataBindings.Add("Text", this, "EarningsAmount", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");
        }

        private void earningsUC_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }
    }
}
