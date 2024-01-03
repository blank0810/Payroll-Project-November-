using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using Payroll_Project2.Forms.System_Administrator.Department_Management.Modal;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Department_User_Control
{
    public partial class departmentCardUC : UserControl
    {
        private static int _userId;
        private static departmentManagementUC _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string departmentLogoPath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");
        private static string userRoleParameter = "Employee";

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentInitials { get; set; }
        public string DepartmentLogo { get; set; }
        public int EmployeeNumber { get; set; }
        public int RegularNumber { get; set; }
        public int JobOrderNumber { get; set; }

        public departmentCardUC(int userId, departmentManagementUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;   
        }

        private async Task<string> GetUserRole(int departmentId, string userRole)
        {
            try
            {
                string role = await generalFunctions.GetHeadRoleDescription(departmentId, userRole);
                return role;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task GetDepartmentDetails(int departmentId, string role, int userId)
        {
            #region Function for retrieving the details of the department
            try
            {
                string userRole = await GetUserRole(departmentId, role);
                departmentInformationModal analytics = new departmentInformationModal(userId);

                if(!string.IsNullOrEmpty(userRole))
                {
                    DataTable DepartmentDetails = await generalFunctions.GetDepartmentDetails(departmentId, userRole);
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
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: @"Department Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: @"Department Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        private void ModifyDepartment(int userId, string departmentName, int departmentId, string departmentLogo, 
            string departmentInitials)
        {
            modifyDepartment modifyDepartment = new modifyDepartment(userId);
            modifyDepartment.DepartmentId = departmentId;
            modifyDepartment.DepartmentName = departmentName;
            modifyDepartment.DepartmentInitials = departmentInitials;
            modifyDepartment.DepartmentImage = departmentLogo;

            modifyDepartment.ShowDialog();
        }

        private void ClearBinding()
        {
            #region Clears the data bindings in the user control

            departmentName.DataBindings.Clear();
            regularNumber.DataBindings.Clear();
            employeeNumber.DataBindings.Clear();
            jobOrderNumber.DataBindings.Clear();
            departmentPicture.DataBindings.Clear();

            #endregion
        }

        private void DepartmentDataBinding()
        {
            #region Binds the data into the label to be displayed in the user control

            ClearBinding();
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            regularNumber.DataBindings.Add("Text", this, "RegularNumber");
            employeeNumber.DataBindings.Add("Text", this, "EmployeeNumber");
            jobOrderNumber.DataBindings.Add("Text", this, "JobOrderNumber");
            departmentPicture.DataBindings.Add("ImageLocation", this, "DepartmentLogo");

            #endregion
        }

        private async void informationBtn_Click(object sender, EventArgs e)
        {
            await GetDepartmentDetails(DepartmentId, userRoleParameter, _userId);
            await _parent.displayDepartment();
        }

        private async void modifyBtn_Click(object sender, EventArgs e)
        {
            ModifyDepartment(_userId, DepartmentName, DepartmentId, DepartmentLogo, DepartmentInitials);
            await _parent.displayDepartment();
        }

        private void departmentCardUC_Load(object sender, EventArgs e)
        {
            DepartmentDataBinding();
        }
    }
}
