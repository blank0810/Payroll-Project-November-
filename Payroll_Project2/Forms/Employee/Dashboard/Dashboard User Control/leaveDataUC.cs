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
    public partial class leaveDataUC : UserControl
    {
        private static int _userId;
        private static employeeDashboard _parent;

        public int ApplicationNumber { get; set; }
        public string DateSubmitted { get; set; }
        public string FormStatus { get; set; }

        public leaveDataUC(int userId, employeeDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
    }
}
