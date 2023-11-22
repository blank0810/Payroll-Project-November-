using Payroll_Project2.Forms.Employee.Leave_Logs.Leave_logs_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Leave_Logs.Modals
{
    public partial class personalLeaveDetailedView : Form
    {
        private static int _userId;
        private static leaveLogsDataUC _parent;

        public int ApplicationNumber { get; set; }
        public string RecommendedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateLeave { get; set; }
        public string CertifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Extension { get; set; }
        public string DepartmentName { get; set; }
        public string JobDescription { get; set; }
        public string SalaryRate { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDetails { get; set; }
        public string WithPay { get; set; }
        public string Reason { get; set; }

        public personalLeaveDetailedView()
        {
            InitializeComponent();
        }

        private void personalLeaveDetailedView_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
