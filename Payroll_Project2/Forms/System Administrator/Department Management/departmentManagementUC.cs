using Payroll_Project2.Forms.System_Administrator.Department_Management.Department_User_Control;
using Payroll_Project2.Forms.System_Administrator.Department_Management.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management
{
    public partial class departmentManagementUC : UserControl
    {
        public departmentManagementUC()
        {
            InitializeComponent();
        }

        private void departmentManagementUC_Load(object sender, EventArgs e)
        {
            departmentCardUC departmentCard = new departmentCardUC();
            departmentList.Controls.Clear();
            departmentList.Controls.Add(departmentCard);
        }

        private void addDepartmentBtn_Click(object sender, EventArgs e)
        {
            addDepartment addDepartment = new addDepartment();

            addDepartment.ShowDialog();
        }
    }
}
