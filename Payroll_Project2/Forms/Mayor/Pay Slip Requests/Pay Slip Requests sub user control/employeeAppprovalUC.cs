using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Modals;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control
{
    public partial class employeeAppprovalUC : UserControl
    {
        private static int _userId;
        private static string _department;
        private static payrollApprovalModal _parent;
        private static readonly payslipRequestClass payslipRequestClass = new payslipRequestClass();

        public int PayrollFormId { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string BasicSalary { get; set; }
        public string Earnings { get; set; }
        public string Deductions { get; set; }
        public string NetAmount { get; set; }

        public employeeAppprovalUC(int userId, string department, payrollApprovalModal parent)
        {
            InitializeComponent();
            _userId = userId;
            _department = department;
            _parent = parent;
        }

        private void DataBinding()
        {
            employeeId.DataBindings.Add("Text", this, "EmployeeID");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            basicSalary.DataBindings.Add("Text", this, "BasicSalary");
            earnings.DataBindings.Add("Text", this, "Earnings");
            deductions.DataBindings.Add("Text", this, "Deductions");
            netAmount.DataBindings.Add("Text", this, "NetAmount");
        }

        private void employeeAppprovalUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
