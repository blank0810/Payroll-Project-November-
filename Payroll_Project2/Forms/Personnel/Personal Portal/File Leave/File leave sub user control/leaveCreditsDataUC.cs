using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Leave.File_leave_sub_user_control
{
    public partial class leaveCreditsDataUC : UserControl
    {
        private static int _userId;
        private static fileLeaveUC _parent;

        public string LeaveType { get; set; }
        public float TotalCredits { get; set; }
        public float UsedCredits { get; set; }
        public float Balance { get; set; }
        public int Year { get; set; }

        public leaveCreditsDataUC(int userId, fileLeaveUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            totalCredits.DataBindings.Add("Text", this, "TotalCredits");
            usedCredits.DataBindings.Add("Text", this, "UsedCredits");
            balance.DataBindings.Add("Text", this, "Balance");
            year.DataBindings.Add("Text", this, "Year");
        }

        private void leaveCreditsDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
