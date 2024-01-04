using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_Sub_user_control;
using Payroll_Project2.Forms.System_Administrator.Employee_Management.Modal;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management
{
    public partial class appointmentListUC : UserControl
    {
        private static int _userId;
        private static bool messageBoxShow = false;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly employeeClass employeeClass = new employeeClass();
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        private static int currentPage = 1;
        private static int recordPerPage = 10;
        private static int offset;
        private static int totalRecord;
        private static int totalPages;

        public string DefaultRole { get; set; }

        public appointmentListUC(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        // Function Responsible for Retrieving Employee List
        private async Task<DataTable> GetEmployeeList(string roleName)
        {
            try
            {
                DataTable employeeData = await employeeClass.GetEmployeeList(roleName);

                if (employeeData != null && employeeData.Rows.Count > 0)
                {
                    return employeeData;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function Responsible for retrieving the automated employee id from the database when adding a new employee
        private async Task<int> GetEmployeeId()
        {
            try
            {
                int employeeId = await employeeClass.GetEmployeeId();

                if (employeeId != 1)
                {
                    if (int.TryParse(employeeId.ToString(), out int id))
                    {
                        return ++id;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid employee ID value retrieved. Contact the System Administrator for quick resolution");
                    }
                }
                else
                {
                    return employeeId;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task DisplayEmployeeList(string roleName)
        {
            try
            {
                employeeListPanel.Controls.Clear();
                DataTable employeeList = await GetEmployeeList(roleName);

                if (employeeList != null)
                {
                    personnelDataUC[] personnelData = new personnelDataUC[employeeList.Rows.Count];

                    for (int i = 0; i < employeeList.Rows.Count; i++)
                    {
                        personnelData[i] = new personnelDataUC();
                        DataRow row = employeeList.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"]?.ToString()))
                        {
                            personnelData[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            personnelData[i].EmployeeName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employmentStatus"]?.ToString()))
                        {
                            personnelData[i].EmploymentStatus = $"{row["employmentStatus"]}";
                        }
                        else
                        {
                            personnelData[i].EmploymentStatus = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"]?.ToString()))
                        {
                            personnelData[i].DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            personnelData[i].DepartmentName = "-----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"]?.ToString()))
                        {
                            personnelData[i].JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            personnelData[i].JobDescription = "----------";
                        }

                        employeeListPanel.Controls.Add(personnelData[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void employeeListUC_Load(object sender, EventArgs e)
        {
            await DisplayEmployeeList(DefaultRole);
        }

        private async void returnBtn_Click(object sender, EventArgs e)
        {
            DataTable employeeList = await GetEmployeeList(DefaultRole);

            if(employeeList != null)
            {
                MessageBox.Show($"Cannot appoint new for {DefaultRole} as there is already an employee appointed for the postion.",
                    "Appointment Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                appointmentForm appointmentForm = new appointmentForm(_userId, this);
                appointmentForm.EmployeeID = await GetEmployeeId();
                appointmentForm.UserRole = DefaultRole;
                appointmentForm.EmploymentStatus = "Regular";
                appointmentForm.ShowDialog();
            }

            await DisplayEmployeeList(DefaultRole);
        }
    }
}
