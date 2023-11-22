using Payroll_Project2.Forms.Employee.Dashboard.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control
{
    public partial class earningsUC : UserControl
    {
        private static int _userId;
        private static payslipDetailedView _parent;

        public string EarningsDescription { get; set; }
        public int EarningsNumber { get; set; }
        public decimal EarningsAmount { get; set; }

        public earningsUC(int userId, payslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
    }
}
