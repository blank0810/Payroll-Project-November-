using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Dashboard.User_Control
{
    public partial class dashboardUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;

        public string EmployeeImage { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string MorningIn { get; set; }
        public string MorningOut { get; set; }
        public string MorningStatus { get; set; }
        public string AfternoonIn { get; set; }
        public string AfternoonOut { get; set; }
        public string AfternoonStatus { get; set; }

        public dashboardUC()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
        }

        private void dashboardUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
