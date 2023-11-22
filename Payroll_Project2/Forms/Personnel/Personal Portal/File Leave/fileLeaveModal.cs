using Payroll_Project2.Forms.Personnel.Dashboard;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Leave
{
    public partial class fileLeaveModal : Form
    {
        private static int _userId;
        private static newDashboard _parent;

        public string EmployeeName { get; set; }
        private string LeaveType { get; set; }
        private float CreditsAvailable { get; set; }
        private DateTime StartingDate { get; set; }
        private DateTime EndingDate { get; set; }
        private string LeaveDetails { get; set; }

        public fileLeaveModal(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void fileLeaveModal_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
