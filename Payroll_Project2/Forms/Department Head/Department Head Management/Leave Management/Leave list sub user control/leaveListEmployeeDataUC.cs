using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_list_sub_user_control
{
    public partial class leaveListEmployeeDataUC : UserControl
    {
        private static int _userId;
        private leaveListsUC _parent;

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeImage { get; set; }
        public decimal VacationLeaveCreditsBalance { get; set; }
        public decimal SickLeaveCreditsBalance { get; set; }

        public leaveListEmployeeDataUC(int userId, leaveListsUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            employeeID.DataBindings.Add("Text", this, "EmployeeID");
            employeePicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            vacationLeaveCreditsBalance.DataBindings.Add("Text", this, "VacationLeaveCreditsBalance");
            sickLeaveCreditsBalance.DataBindings.Add("Text", this, "SickLeaveCreditsBalance");
        }

        private async void leaveListBtn_Click(object sender, EventArgs e)
        {
            await _parent.LeaveListBehaviour(EmployeeID);
        }

        private void leaveListEmployeeDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
