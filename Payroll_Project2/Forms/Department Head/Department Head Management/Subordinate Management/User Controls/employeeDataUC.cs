using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Subordinate_Management.User_Controls
{
    public partial class employeeDataUC : UserControl
    {
        public string EmployeePicture { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string DepartmentName { get; set; }
        public string EmploymentStatus { get; set; }

        public employeeDataUC()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            employeeImage.DataBindings.Add("ImageLocation", this, "EmployeePicture");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            employeeEmail.DataBindings.Add("Text", this, "EmailAddress");
            employeeMobile.DataBindings.Add("Text", this, "MobileNumber");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            employmentStatus.DataBindings.Add("Text", this, "EmploymentStatus");
        }

        private void employeeDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
