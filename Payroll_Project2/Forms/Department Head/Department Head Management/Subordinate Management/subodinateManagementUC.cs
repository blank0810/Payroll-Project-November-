using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Subordinate_Management.User_Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Subordinate_Management
{
    public partial class subodinateManagementUC : UserControl
    {
        private static int _userId;
        private static string _department;
        private departmentHeadDashboard _parent;
        private static readonly string defaultImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static dashboardClass dashboardClass = new dashboardClass();
        private static subordinateManagementClass subordinateManagementClass = new subordinateManagementClass();

        public subodinateManagementUC(int userId, departmentHeadDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetEmployeeList(string department)
        {
            try
            {
                DataTable list = await subordinateManagementClass.GetDepartmentEmployeeList(department);

                if(list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void ErrorMessages(string messsage, string caption)
        {
            MessageBox.Show(messsage, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task DisplayList(string department)
        {
            try
            {
                listPanel.Controls.Clear();
                DataTable list = await GetEmployeeList(department);
                
                if(list != null)
                {
                    employeeDataUC[] employeeData = new employeeDataUC[list.Rows.Count];    

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        employeeData[i] = new employeeDataUC();
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            employeeData[i].EmployeePicture = $"{EmployeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            employeeData[i].EmployeePicture = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            employeeData[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employeeData[i].EmployeeName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {
                            employeeData[i].JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            employeeData[i].JobDescription = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeEmailAddress"].ToString()))
                        {
                            employeeData[i].EmailAddress = $"{row["employeeEmailAddress"]}";
                        }
                        else
                        {
                            employeeData[i].EmailAddress = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeContactNumber"].ToString()))
                        {
                            employeeData[i].MobileNumber = $"{row["employeeContactNumber"]}";
                        }
                        else
                        {
                            employeeData[i].MobileNumber = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            employeeData[i].DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            employeeData[i].DepartmentName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employmentStatus"].ToString()))
                        {
                            employeeData[i].EmploymentStatus = $"{row["employmentStatus"]}";
                        }
                        else
                        {
                            employeeData[i].EmploymentStatus = "--------";
                        }

                        listPanel.Controls.Add(employeeData[i]);
                    }
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
 
        private async void subodinateManagementUC_Load(object sender, EventArgs e)
        {
            await DisplayList(_department);
        }
    }
}
