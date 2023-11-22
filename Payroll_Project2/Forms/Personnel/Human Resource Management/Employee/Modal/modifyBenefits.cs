using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal
{
    public partial class modifyBenefits : Form
    {
        private static int _id;
        public string DefaultBenefitName;
        public string DefaultBenefitValue;
        public string DefaultBenefitStatus;

        public modifyBenefits(int detailsId)
        {
            InitializeComponent();
            _id = detailsId;
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modifyBenefits_Load(object sender, EventArgs e)
        {
            benefitName.Text = DefaultBenefitName;
            benefitValue.Texts = DefaultBenefitValue.ToString();
            statusBox.Text = DefaultBenefitStatus;
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
