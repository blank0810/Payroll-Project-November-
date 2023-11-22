using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Dashboard.Dashboard_User_Control
{
    public partial class employeeDataUC : UserControl
    {
        public string EmployeeName { get; set; }
        public string EmploymentStatus { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeePicture { get; set; }
        public string DateHired { get; set; }
        public string JobDescription { get; set; }

        public employeeDataUC()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            empid.DataBindings.Add("Text", this, "EmployeeID");
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeePicture");
            empStatus.DataBindings.Add("Text", this, "EmploymentStatus");
            dateHired.DataBindings.Add("Text", this, "DateHired");
            jobDesc.DataBindings.Add("Text", this, "JobDescription");
        }

        private void employeeDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
