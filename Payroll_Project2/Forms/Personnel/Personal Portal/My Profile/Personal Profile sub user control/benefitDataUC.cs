using Payroll_Project2.Forms.Personnel.Personal_Portal.My_Profile.Personnel_Profile;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.My_Profile.Personal_Profile_sub_user_control
{
    public partial class benefitDataUC : UserControl
    {
        private static int _userId;
        private static personalProfileUC _parent;

        public int BenefitID { get; set; }
        public string BenefitName { get; set; }
        public decimal BenefitValue { get; set; }
        public string BenefitStatus { get; set; }

        public benefitDataUC(int userId, personalProfileUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            benefitName.DataBindings.Add("Text", this, "BenefitName");
            benefitValue.DataBindings.Add("Text", this, "BenefitValue", true, DataSourceUpdateMode.OnPropertyChanged, "", "₱0.00");
            benefitsStatus.DataBindings.Add("Text", this, "BenefitStatus");
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await _parent.ContributionsBehaviour(BenefitID, BenefitValue);
        }

        private void benefitDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
