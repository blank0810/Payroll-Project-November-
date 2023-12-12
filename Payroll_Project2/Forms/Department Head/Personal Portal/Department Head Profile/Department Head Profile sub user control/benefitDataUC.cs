using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control
{
    public partial class benefitDataUC : UserControl
    {
        private static int _userId;
        private static personalProfileUC _parent;

        public int DetailsID { get; set; }
        public string BenefitName { get; set; }
        public string BenefitValue { get; set; }
        public string BenefitStatus { get; set; }
        public string RateDescriptions { get; set; }

        public benefitDataUC(int userId, personalProfileUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
        private void DataBinding()
        {
            benefitName.DataBindings.Add("Text", this, "BenefitName");
            benefitValue.DataBindings.Add("Text", this, "BenefitValue");
            rateDescriptions.DataBindings.Add("Text", this, "RateDescriptions");

            Binding statusBinding = new Binding("Text", this, "BenefitStatus");
            statusBinding.Format += new ConvertEventHandler(StatusBinding_Format);
            benefitsStatus.DataBindings.Add(statusBinding);
        }

        // Custom function responsible for formatting the benefit status
        private void StatusBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Active")
            {
                benefitsStatus.ForeColor = Color.ForestGreen;
                benefitName.ForeColor = Color.Black;
                rateDescriptions.ForeColor = Color.Black;
                benefitValue.ForeColor = Color.Black;
            }
            else if (e.Value.ToString() == "Inactive")
            {
                benefitsStatus.ForeColor = Color.Red;
                benefitName.ForeColor = Color.DimGray;
                rateDescriptions.ForeColor = Color.DimGray;
                benefitValue.ForeColor = Color.DimGray;
            }
            else
            {
                benefitsStatus.ForeColor = Color.DimGray;
            }
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await _parent.ContributionsBehaviour(DetailsID);
        }

        private void benefitDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
