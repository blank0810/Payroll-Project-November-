using Payroll_Project2.Forms.Personnel.Personal_Portal.My_Profile.Modals;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.My_Profile.Personal_Profile_sub_user_control
{
    public partial class deductionsUC : UserControl
    {
        private static int _userId;
        private static payslipDetailedView _parent;

        public string DeductionDescription { get; set; }
        public int DeductionNumber { get; set; }
        public decimal DeductionAmount { get; set; }

        public deductionsUC(int userId, payslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            deductionDescription.DataBindings.Add("Text", this, "DeductionDescription");
            deductionNumber.DataBindings.Add("Text", this, "DeductionNumber");
            deductionsAmount.DataBindings.Add("Text", this, "DeductionAmount", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");
        }

        private void deductionsUC_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }
    }
}
