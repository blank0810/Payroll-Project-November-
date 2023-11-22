using Payroll_Project2.Forms.System_Administrator.Department_Management.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Department_User_Control
{
    public partial class departmentCardUC : UserControl
    {
        public departmentCardUC()
        {
            InitializeComponent();
        }

        private void informationBtn_Click(object sender, EventArgs e)
        {
            departmentInformationModal departmentInformation = new departmentInformationModal();
            departmentInformation.ShowDialog();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            modifyDepartment modify = new modifyDepartment();
            modify.ShowDialog();
        }
    }
}
