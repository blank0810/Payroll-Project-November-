using Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_User_Controls;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management
{
    public partial class employeeListUC : UserControl
    {
        public employeeListUC()
        {
            InitializeComponent();
        }

        // Custom Function that handles what control to hide and shows for the UI behaviour
        public void UserControlBehaviour()
        {
            description.Visible = false;
            searchEmployee.Visible = false;
            searchBtn.Visible = false;
            employmentStatus.Visible = false;
            departmentName.Visible = false;
            filterBtn.Visible = false;
            returnBtn.Visible = true;
            returnBtn.BringToFront();
        }

        private void DisplayEmployee()
        {
            employeeDataUC employee = new employeeDataUC(this);
            employeeList.Controls.Clear();
            employeeList.Controls.Add(employee);
        }

        private void employeeListUC_Load(object sender, EventArgs e)
        {
            DisplayEmployee();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            // Event Handler that handles if the Return to list button is clicked
            content.Controls.Clear();
            searchEmployee.Visible = true;
            searchBtn.Visible = true;
            employmentStatus.Visible = true;
            departmentName.Visible = true;
            filterBtn.Visible = true;
            returnBtn.Visible = false;

            employeeList.Visible = true;
            description.Visible = true;
            content.Controls.Add(description);
            description.Dock = DockStyle.Top;

            content.Controls.Add(employeeList);
            employeeList.Dock = DockStyle.Fill;
            employeeList.Focus();

            employeeList.BringToFront();
            DisplayEmployee();
        }
    }
}
