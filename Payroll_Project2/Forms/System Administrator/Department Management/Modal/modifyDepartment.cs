using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using System.Configuration;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal
{
    public partial class modifyDepartment : Form
    {
        private static int _userId;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly departmentManagementClass departmentManagementClass = new departmentManagementClass();
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string departmentLogoPath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentInitials { get; set; }
        public string DepartmentImage { get; set; }

        public modifyDepartment(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void DataBinding()
        {
            departmentName.Texts = DepartmentName;
            departmentInitials.Texts = DepartmentInitials;
            departmentLogo.ImageLocation = DepartmentImage;
            departmentImageBox.Texts = DepartmentImage;
        }

        private void modifyDepartment_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
