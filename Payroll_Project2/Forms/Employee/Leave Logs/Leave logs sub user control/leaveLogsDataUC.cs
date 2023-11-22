using Payroll_Project2.Forms.Employee.Leave_Logs.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Leave_Logs.Leave_logs_sub_user_control
{
    public partial class leaveLogsDataUC : UserControl
    {
        private static int _userId;
        private static leaveLogsUC _parent;

        public int ApplicationNumber { get; set; }
        public string LeaveType { get; set; }
        public string DateFiled { get; set; }
        public string DateCoverage { get; set; }
        public string Status { get; set; }

        public leaveLogsDataUC()
        {
            InitializeComponent();
        }

        private void leaveLogsDataUC_Load(object sender, EventArgs e)
        {

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            personalLeaveDetailedView leave = new personalLeaveDetailedView();
            leave.ShowDialog();
        }
    }
}
