using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Human_Resource_Management.Payroll.User_Controls
{
    public partial class earningsUC : UserControl
    {
        private static int _userId;
        private static payslip _parent;

        public string EarningsDescription { get; set; }
        public string EarningsAmount { get; set; }

        public earningsUC(int userId, payslip parent)
        {
            _userId = userId;
            _parent = parent;
            InitializeComponent();
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
