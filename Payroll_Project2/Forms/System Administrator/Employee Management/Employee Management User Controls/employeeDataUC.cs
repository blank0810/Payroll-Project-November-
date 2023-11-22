using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_User_Controls
{
    public partial class employeeDataUC : UserControl
    {
        employeeListUC _parent = new employeeListUC();

        public employeeDataUC(employeeListUC parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {

        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            employeeDetailsUserControl employeeDetails = new employeeDetailsUserControl();
            Panel parentPanel = _parent.Controls["content"] as Panel;
            parentPanel.Controls.Clear();
            parentPanel.Controls.Add(employeeDetails);
            employeeDetails.Dock = DockStyle.Fill;
            _parent.UserControlBehaviour();
        }
    }
}
