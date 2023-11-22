using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls
{
    public partial class employeeUC : UserControl
    {
        private static int _userId;
        private static analyticsButtonModal _parent;

        public string EmployeeName { get; set; }
        public string EmploymentStatus { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeePicture { get; set; }
        public string DateHired {  get; set; }


        public employeeUC(int userId, analyticsButtonModal parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            empid.DataBindings.Add("Text", this, "EmployeeID");
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeePicture");
            empStatus.DataBindings.Add("Text", this, "EmploymentStatus");
            dateHired.DataBindings.Add("Text", this, "DateHired");
        }

        private void employeeUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
