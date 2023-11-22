using Payroll_Project2.Forms.System_Administrator.Department_Management.Modal.Modal_User_Control;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal
{
    public partial class departmentInformationModal : Form
    {
        public departmentInformationModal()
        {
            InitializeComponent();
        }

        private void departmentInformationModal_Load(object sender, EventArgs e)
        {
            personnelDataUC personnelData = new personnelDataUC();
            empList.Controls.Clear();
            empList.Controls.Add(personnelData);
        }
    }
}
