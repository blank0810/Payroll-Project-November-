using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control
{
    public partial class passSlipUC : UserControl
    {
        private static int _userId;
        private personalProfileUC _parent;

        public int ControlNumber { get; set; }
        public string DateSubmitted { get; set; }
        public string FormStatus { get; set; }

        public passSlipUC(int userId, personalProfileUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
    }
}
