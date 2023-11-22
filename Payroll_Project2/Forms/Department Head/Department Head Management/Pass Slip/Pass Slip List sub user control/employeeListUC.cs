using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Pass_Slip.Pass_Slip_List_sub_user_control
{
    public partial class employeeListUC : UserControl
    {
        private static int _userId;
        private slipListUC _parent;

        public string EmployeeImage { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int TotalNumber { get; set; }

        public employeeListUC(int userId, slipListUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            employeeID.DataBindings.Add("Text", this, "EmployeeID");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            employeePicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            totalNumber.DataBindings.Add("Text", this, "TotalNumber");
        }

        private void employeeListUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void leaveListBtn_Click(object sender, EventArgs e)
        {
            await _parent.DisplaySlipList(EmployeeID);
        }
    }
}
