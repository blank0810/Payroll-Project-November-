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
    public partial class earningsUC : UserControl
    {
        private static int _userId;
        private static payslipDetailedView _parent;

        public string EarningsDescription { get; set; }
        public string EarningsAmount { get; set; }

        public earningsUC(int userId, payslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            earningsDescription.DataBindings.Add("Text", this, "EarningsDescription");
            earningsAmount.DataBindings.Add("Text", this, "EarningsAmount");
        }

        private void earningsUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
