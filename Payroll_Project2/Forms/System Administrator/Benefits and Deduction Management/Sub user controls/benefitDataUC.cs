using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls
{
    public partial class benefitDataUC : UserControl
    {
        private static int _userId;
        private static benefitAndDeductionUC _parent;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();

        public string BenefitName { get; set; }
        public int BenefitID { get; set; }
        public string BenefitDescription { get; set; }

        public benefitDataUC(int userId, benefitAndDeductionUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void ClearBinding()
        {
            benefitId.DataBindings.Clear();
            benefitName.DataBindings.Clear();
            benefitDescription.DataBindings.Clear();
        }

        private void DataBinding()
        {
            ClearBinding();
            benefitId.DataBindings.Add("Text", this, "BenefitID");
            benefitName.DataBindings.Add("Text", this, "BenefitName");
            benefitDescription.DataBindings.Add("Text", this, "BenefitDescription");
        }

        private void DisplayRate()
        {
            
            if(BenefitName != "Witholding Tax")
            {
                benefitRateModal rateModal = new benefitRateModal(_userId);
                rateModal.BenefitName = $"RATES FOR {BenefitName}";
                rateModal.BenefitID = BenefitID;
                rateModal.ShowDialog();
            }
            else
            {
                witholdingTaxRateModal rateModal = new witholdingTaxRateModal(_userId);
                rateModal.BenefitName = $"RATES FOR {BenefitName}";
                rateModal.BenefitID = BenefitID;
                rateModal.ShowDialog();
            }
        }

        private void benefitDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            DisplayRate();
            await _parent.DisplayBenefits(_userId);
        }
    }
}
