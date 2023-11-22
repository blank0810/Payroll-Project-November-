using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals
{
    public partial class paySlipRequestDetailedView : Form
    {
        private static int _userId;
        private static employeeDataUC _parent;

        public string PayrollPerios { get; set; }
        public int EmployeeID { get; set; }
        public int PayslipID { get; set; }
        public string DepartmentName { get; set; }
        public decimal SalaryRate { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string EmploymentStatus { get; set; }
        public int TotalEarnings { get; set; }
        public int TotalDeductions { get; set; }
        public int TotalAmount { get; set; }

        public paySlipRequestDetailedView(int userId, employeeDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Custom function that centers the department head name
        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        private void DataBinding()
        {
            payrollContentPanel.Controls.Clear();
            earningsPanel.Visible = true;
            deductionsPanel.Visible = true;
            payrollContentPanel.Controls.Add(earningsPanel);
            payrollContentPanel.Controls.Add(deductionsPanel);

            label15.Visible = false;
            label6.Visible = true;
            returnBtn.Visible = false;
            label16.Visible = false;
            CenterDepartmentHead();
        }

        private void DisplayEarnings()
        {
            payrollContentPanel.Controls.Clear();
            earningsPanel.Visible = false;
            deductionsPanel.Visible = false;

            label15.Visible = true;
            label6.Visible = false;
            returnBtn.Visible = true;
            label16.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                earningsDataUC earnings = new earningsDataUC(_userId, this);
                payrollContentPanel.Controls.Add(earnings);
            }
        }

        private void DisplayDeductions()
        {
            payrollContentPanel.Controls.Clear();
            earningsPanel.Visible = false;
            deductionsPanel.Visible = false;

            label15.Visible = true;
            label6.Visible = false;
            returnBtn.Visible = true;
            label16.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                deductionDataUC deductions = new deductionDataUC(_userId, this);
                payrollContentPanel.Controls.Add(deductions);
            }
        }

        private void paySlipRequestDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void viewEarningsBtn_Click(object sender, EventArgs e)
        {
            DisplayEarnings();
        }

        private void viewDeductionsBtn_Click(object sender, EventArgs e)
        {
            DisplayDeductions();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
