using Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control
{
    public partial class deductionsUC : UserControl
    {
        private static int _userId;
        private static payslipDetailedView _parent;

        public string DeductionDescription { get; set; }
        public string DeductionAmount { get; set; }

        public deductionsUC(int userId, payslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            deductionsDescription.DataBindings.Add("Text", this, "DeductionDescription");
            deductionAmount.DataBindings.Add("Text", this, "DeductionAmount");
        }

        private void deductionsUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
