using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_Sub_user_control
{
    public partial class personnelDataUC : UserControl
    {
        public string EmployeeName { get; set; }
        public string EmploymentStatus { get; set; }
        public string DepartmentName { get; set; }
        public string JobDescription { get; set; }

        public personnelDataUC()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            employmentStatus.DataBindings.Add("Text", this, "EmploymentStatus");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
        }

        private void personnelDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
