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
    public partial class benefitDataUC : UserControl
    {
        private static int _userId;
        private static employeeDashboard _parent;

        public int BenefitID { get; set; }
        public string BenefitName { get; set; }
        public decimal BenefitValue { get; set; }
        public string BenefitStatus { get; set; }

        public benefitDataUC(int userId, employeeDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            _parent.ContributionsBehaviour(BenefitID);
        }
    }
}
