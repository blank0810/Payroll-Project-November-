using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents
{
    public partial class orderList : UserControl
    {
        private static int _userId;
        private static listUC _parent;

        public string EmployeeImage { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string DepartmentName { get; set; }

        public orderList(int userId, listUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Custom function for binding values into the UI
        private void DataBinding()
        {
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empid.DataBindings.Add("Text", this, "EmployeeID");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
        }

        // Event handler that handles if this user control is loaded into the system
        private void orderList_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler that handles if the view button is clicked
        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await _parent.ListButtonBehaviour(EmployeeID);
        }
    }
}
