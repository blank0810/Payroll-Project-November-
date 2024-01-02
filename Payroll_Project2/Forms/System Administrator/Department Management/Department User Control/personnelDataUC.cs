using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal.Modal_User_Control
{
    public partial class personnelDataUC : UserControl
    {
        private static int _userId;

        public string EmployeeName { get; set; }
        public string EmploymentStatus { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeePicture { get; set; }
        public string DateHired { get; set; }
        public string JobDescription { get; set; }

        public personnelDataUC(int userId)
        {
            InitializeComponent();
            _userId = userId;
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

        private void personnelDataUC_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }
    }
}
