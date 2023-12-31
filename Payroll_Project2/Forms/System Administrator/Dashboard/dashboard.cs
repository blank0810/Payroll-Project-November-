using Payroll_Project2.Forms.System_Administrator.Dashboard.Modal;
using Payroll_Project2.Forms.System_Administrator.Department_Management;
using Payroll_Project2.Forms.System_Administrator.Employee_Management;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Dashboard
{
    public partial class systemAdminDashboard : Form
    {
        public systemAdminDashboard()
        {
            InitializeComponent();
        }

        private void systemAdminDashboard_Load(object sender, EventArgs e)
        {
            employeeManagementSubPanel.Hide();
            logSubPanel.Hide();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {

        }

        private void departmentBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            titleLabel.Text = departmentBtn.Text;
            employeeManagementSubPanel.Hide();
            departmentManagementUC departmentManagementUC = new departmentManagementUC();

            if (!contentPanel.Controls.Contains(departmentManagementUC))
            {
                contentPanel.Controls.Add(departmentManagementUC);
                departmentManagementUC.Dock = DockStyle.Fill;
                departmentManagementUC.BringToFront();
            }
            else
            {
                departmentManagementUC.BringToFront();
            }
        }

        private void employeeManagementBtn_Click(object sender, EventArgs e)
        {
            logSubPanel.Hide();
            if (employeeManagementSubPanel.Visible == true)
            {
                employeeManagementSubPanel.Hide();
            }
            else
            {
                employeeManagementSubPanel.Show();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            modifyForm modify = new modifyForm();
            modify.ShowDialog();
        }

        private void employeeListBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            titleLabel.Text = employeeManagementBtn.Text;
            employeeListUC employeeListUC = new employeeListUC();

            if (!contentPanel.Controls.Contains(employeeListUC))
            {
                contentPanel.Controls.Add(employeeListUC);
                employeeListUC.Dock = DockStyle.Fill;
                employeeListUC.BringToFront();
            }
            else
            {
                employeeListUC.BringToFront();
            }
        }

        private void appointmentBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            titleLabel.Text = employeeManagementBtn.Text;
            appointmentUC appointmentUC = new appointmentUC();

            if (!contentPanel.Controls.Contains(appointmentUC))
            {
                contentPanel.Controls.Add(appointmentUC);
                appointmentUC.Dock = DockStyle.Fill;
                appointmentUC.BringToFront();
            }
            else
            {
                appointmentUC.BringToFront();
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
