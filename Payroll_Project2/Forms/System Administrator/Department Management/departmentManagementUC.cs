using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.System_Administrator.Department_Management.Department_User_Control;
using Payroll_Project2.Forms.System_Administrator.Department_Management.Modal;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management
{
    public partial class departmentManagementUC : UserControl
    {
        private static int _userId;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string DepartmentImagePath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");
        private static readonly string DefaultLogo = ConfigurationManager.AppSettings.Get("DefaultLogo");

        public departmentManagementUC(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        // Specifically it retrieves the complete list of Departments and validate if its null or not
        private async Task<DataTable> GetDepartmentDetails()
        {
            try
            {
                DataTable details = await generalFunctions.GetDepartmentListDetails();

                if (details != null && details.Rows.Count > 0)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This is to display the departments below
        public async Task displayDepartment()
        {
            try
            {
                DataTable DepartmentList = await GetDepartmentDetails();
                departmentList.Controls.Clear();

                if (DepartmentList != null & DepartmentList.Rows.Count > 0)
                {
                    departmentCardUC[] departmentCardUC = new departmentCardUC[DepartmentList.Rows.Count];
                    for (int i = 0; i < DepartmentList.Rows.Count; i++)
                    {
                        departmentCardUC[i] = new departmentCardUC(_userId, this);
                        DataRow row = DepartmentList.Rows[i];

                        if (!string.IsNullOrEmpty(row["departmentId"].ToString()) && int.TryParse(row["departmentId"].ToString(),
                            out int departmentId))
                        {
                            departmentCardUC[i].DepartmentId = departmentId;
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            departmentCardUC[i].DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentInitial"]?.ToString()))
                        {
                            departmentCardUC[i].DepartmentInitials = $"{row["departmentInitial"]}";
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentInitials = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentLogo"].ToString()))
                        {
                            departmentCardUC[i].DepartmentLogo = $"{DepartmentImagePath}{row["departmentLogo"]}";
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentLogo = DefaultLogo;
                        }

                        if (!string.IsNullOrEmpty(row["regularCount"].ToString()) && int.TryParse(row["regularCount"].ToString(),
                            out int regularCount))
                        {
                            departmentCardUC[i].RegularNumber = regularCount;
                        }
                        else
                        {
                            departmentCardUC[i].RegularNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["jobOrderCount"].ToString()) && int.TryParse(row["jobOrderCount"].ToString(),
                             out int jobOrderCount))
                        {
                            departmentCardUC[i].JobOrderNumber = jobOrderCount;
                        }
                        else
                        {
                            departmentCardUC[i].JobOrderNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["totalEmployees"].ToString()) && int.TryParse(row["totalEmployees"].ToString(),
                            out int totalEmployee))
                        {
                            departmentCardUC[i].EmployeeNumber = totalEmployee;
                        }
                        else
                        {
                            departmentCardUC[i].EmployeeNumber = 0;
                        }

                        departmentList.Controls.Add(departmentCardUC[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void departmentManagementUC_Load(object sender, EventArgs e)
        {
            await displayDepartment();
        }

        private void addDepartmentBtn_Click(object sender, EventArgs e)
        {
            addDepartment addDepartment = new addDepartment();

            addDepartment.ShowDialog();
        }
    }
}
