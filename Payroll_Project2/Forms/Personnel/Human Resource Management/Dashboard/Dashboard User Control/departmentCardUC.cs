using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control
{
    public partial class departmentCardUC : UserControl
    {
        #region The public getters and setters

        private static int userId;
        private static newDashboard _parent;
        private static readonly personnelDashboard personnelClass = new personnelDashboard();
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static string userRoleParameter = "Department Head";

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLogo { get; set; }
        public int EmployeeNumber { get; set; }
        public int RegularNumber { get; set; }
        public int JobOrderNumber { get; set; }

        #endregion

        public departmentCardUC(int id, newDashboard parent)
        {
            InitializeComponent();
            userId = id;
            _parent = parent;
        }

        #region Starts the functions to be use for the functionality of the user interface

        private void DepartmentDataBinding()
        {
            #region Binds the data into the label to be displayed in the user control

            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            regularNumber.DataBindings.Add("Text", this, "RegularNumber");
            employeeNumber.DataBindings.Add("Text", this, "EmployeeNumber");
            jobOrderNumber.DataBindings.Add("Text", this, "JobOrderNumber");
            departmentPicture.DataBindings.Add("ImageLocation", this, "DepartmentLogo");

            #endregion
        }

        private async Task GetDepartmentDetails(int departmentId, string userRole)
        {
            #region Function for retrieving the details of the department

            DataTable DepartmentDetails = await generalFunctions.GetDepartmentDetails(departmentId, userRole);
            analyticsButtonModal analytics = new analyticsButtonModal(userId, this);

            try
            {
                if (DepartmentDetails != null && DepartmentDetails.Rows.Count > 0)
                {
                    foreach (DataRow row in DepartmentDetails.Rows)
                    {
                        analytics.DepartmentID = departmentId;
                        analytics.DepartmentName = DepartmentName;
                        analytics.DepartmentLogo = DepartmentLogo;
                        analytics.DepartmentHead = row["employeefname"].ToString() + " " + row["employeelname"].ToString();
                        analytics.SchoolName = row["nameofschool"].ToString();
                        analytics.DateHired = row["datehired"].ToString();
                        analytics.ContactNumber = row["employeecontactnumber"].ToString();
                        analytics.JobDescription = row["employeejobdesc"].ToString();
                    }
                    analytics.ShowDialog();
                }
                else
                {
                    analytics.DepartmentID = departmentId;
                    analytics.DepartmentName = DepartmentName;
                    analytics.DepartmentLogo = DepartmentLogo;
                    analytics.DepartmentHead = "------";
                    analytics.SchoolName = "----";
                    analytics.DateHired = "----";
                    analytics.ContactNumber = "----";
                    analytics.JobDescription = "----";

                    analytics.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption:@"Department Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        #endregion 

        #region All function below is the event handler in every control in the user interface

        private async void infoBtn_Click(object sender, EventArgs e)
        {
            await GetDepartmentDetails(DepartmentId, userRoleParameter);
        }

        private void departmentCardUC_Load(object sender, EventArgs e)
        {
            DepartmentDataBinding();
        }

        #endregion
    }
}
