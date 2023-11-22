using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Modal
{
    public partial class mandateDeductionsUC : UserControl
    {
        private static addEmployeeModal _parent;
        
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
