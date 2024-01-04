using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_Sub_user_control
{
    public partial class mandateDeductionsUC : UserControl
    {
        public int BenefitId { get; set; }
        public string BenefitName { get; set; }
        public string EmployeeShare { get; set; }
        public string EmployerShare { get; set; }
        public string TotalValue { get; set; }

        public mandateDeductionsUC()
        {
            InitializeComponent();
        }
        private void DataBinding()
        {
            benefitName.DataBindings.Add("Text", this, "BenefitName");
            personalShareValue.DataBindings.Add("Text", this, "EmployeeShare");
            employerShareValue.DataBindings.Add("Text", this, "EmployerShare");
            totalValue.DataBindings.Add("Text", this, "TotalValue");
        }

        private void mandateDeductionsUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
