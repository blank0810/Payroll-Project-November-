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
    public partial class deductionsUC : UserControl
    {
        private static int _userId;
        private static payslipDetailedView _parent;

        public string DeductionDescription { get; set; }
        public int DeductionNumber { get; set; }
        public decimal deductionAmount { get; set; }

        public deductionsUC(int userId, payslipDetailedView parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
    }
}
