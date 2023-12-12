using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Dashboard.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Dashboard.Dashboard_User_Control
{
    public partial class departmentDataUC : UserControl
    {
        private static int _userId;
        private static MayorDashboard _parent;
        private static string _userDepartment;
        private static readonly string DefaultUserRole = "Employee";
        private static readonly string defaultImage = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly mayorDashboard mayorDashboard = new mayorDashboard();
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public int DepartmentID { get; set; }
        public string DepartmentLogo { get; set; }
        public string DepartmentName { get; set; }
        public int RegularCount { get; set; }
        public int JOCount { get; set; }
        public int TotalCount {  get; set; }

        public departmentDataUC(int userId, MayorDashboard parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }

        private async Task<DataTable> GetDepartmentDetails(int departmentId, string userRole)
        {
            try
            {
                DataTable details = await generalFunctions.GetDepartmentDetails(departmentId, userRole);

                if( details != null)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetUserRole(int departmentId, string userRole)
        {
            try
            {
                string role = await mayorDashboard.GetHeadRoleDescription(departmentId, userRole);
                return role;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataBinding()
        {
            departmentLogo.DataBindings.Clear();
            departmentName.DataBindings.Clear();
            regularCount.DataBindings.Clear();
            joCount.DataBindings.Clear();
            totalEmployeeCount.DataBindings.Clear();

            departmentLogo.DataBindings.Add("ImageLocation", this, "DepartmentLogo");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            regularCount.DataBindings.Add("Text", this, "RegularCount");
            joCount.DataBindings.Add("Text", this, "JOCount");
            totalEmployeeCount.DataBindings.Add("Text", this, "TotalCount");
        }

        private async Task DisplayDepartmentDetails(int departmentId, string department, string departmentLogo, string role)
        {
            try
            {
                string userRole = await GetUserRole(departmentId, role);
                DataTable details = await GetDepartmentDetails(departmentId, userRole);
                departmentDetailsModal departmentDetails = new departmentDetailsModal();

                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        departmentDetails.DepartmentId = departmentId;
                        departmentDetails.DepartmentName = department;
                        departmentDetails.UserRole = userRole;
                        departmentDetails.DepartmentLogo = departmentLogo;

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            departmentDetails.DepartmentHead = $"{row["employeeFname"]} {row["employeeLname"]}";
                        }
                        else
                        {
                            departmentDetails.DepartmentHead = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["nameOfSchool"].ToString()))
                        {
                            departmentDetails.SchoolName = $"{row["nameOfSchool"]}";
                        }
                        else
                        {
                            departmentDetails.SchoolName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["dateHired"].ToString()) && DateTime.TryParse(row["dateHired"].ToString(),
                            out DateTime dateHired))
                        {
                            departmentDetails.DateHired = $"{dateHired: MMM dd, yyyy}";
                        }
                        else
                        {
                            departmentDetails.DateHired = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeContactNumber"].ToString()))
                        {
                            departmentDetails.ContactNumber = $"{row["employeeContactNumber"]}";
                        }
                        else
                        {
                            departmentDetails.ContactNumber = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {
                            departmentDetails.JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            departmentDetails.JobDescription = "--------";
                        }

                        departmentDetails.ShowDialog();
                    }
                }
                else
                {
                    departmentDetails.DepartmentId = departmentId;
                    departmentDetails.DepartmentName = department;
                    departmentDetails.DepartmentLogo = departmentLogo;
                    departmentDetails.DepartmentHead = "------";
                    departmentDetails.SchoolName = "----";
                    departmentDetails.DateHired = "----";
                    departmentDetails.ContactNumber = "----";
                    departmentDetails.JobDescription = "----";

                    departmentDetails.ShowDialog();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private void departmentDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void detailsBtn_Click(object sender, EventArgs e)
        {
            await DisplayDepartmentDetails(DepartmentID, DepartmentName, DepartmentLogo, DefaultUserRole );
            await _parent.DisplayDepartment(_userId);
        }
    }
}