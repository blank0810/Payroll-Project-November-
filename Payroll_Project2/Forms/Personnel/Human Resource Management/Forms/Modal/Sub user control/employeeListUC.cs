using Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents
{
    public partial class employeeListUC : UserControl
    {
        private static employeeList _parent;
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeImage { get; set; }
        public string DepartmentName { get; set; }

        public employeeListUC(employeeList parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        // This function is the responsible for giving value to the controls in user interface
        // such as Labels, button, and Image dynamically
        private void DataBinding()
        {
            empFirstName.DataBindings.Add("Text", this, "EmployeeName");
            empid.DataBindings.Add("Text", this, "EmployeeID");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            departmentLabel.DataBindings.Add("Text", this, "DepartmentName");
        }

        // This event handler is the who handles the click event of the select employee button
        // where depending on what employee the user chosen it wil retrieve that employee's Id 
        // and send it to the employeeList form in the function ChosenName
        // In relation to "_parent" it is a variable name where i declare for the employeeList form
        private void selectBtn_Click(object sender, EventArgs e)
        {
            _parent.ChosenName(Convert.ToInt32(empid.Text));
        }

        // This event is the one handles on what to display or not when it is being called
        private void employeeListUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
