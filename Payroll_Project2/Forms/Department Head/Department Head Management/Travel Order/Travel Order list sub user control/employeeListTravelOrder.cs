using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_Order_list_sub_user_control
{
    public partial class employeeListTravelOrder : UserControl
    {
        private static int _userId;
        private static travelOrderListsUC _parent;

        public string EmployeeImage { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int TotalNumber { get; set; }

        public employeeListTravelOrder(int userId, travelOrderListsUC parent)
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

        private void employeeListTravelOrder_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void leaveListBtn_Click(object sender, EventArgs e)
        {
            await _parent.DisplayTravelLogs(EmployeeID);
        }
    }
}
