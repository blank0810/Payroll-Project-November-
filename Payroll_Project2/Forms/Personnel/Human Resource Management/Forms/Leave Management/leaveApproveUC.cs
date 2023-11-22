using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms
{
    public partial class leaveApproveUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static readonly string _personnelDepartment;
        private static readonly formClass formClass = new formClass();
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public leaveApproveUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // This function responsible for retrieving personnel department
        private async Task<string> GetPersonnelDepartment(int employeeId)
        {
            try
            {
                string departmentName = await generalFunctions.GetPersonnelDepartment(employeeId);

                return departmentName;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving the Leave list
        private async Task<DataTable> GetLeaveList(string departmentName)
        {
            try
            {
                DataTable leaveList = await formClass.GetLeaveList(departmentName);

                if (leaveList != null && leaveList.Rows.Count > 0)
                {
                    return leaveList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the searched leave list
        private async Task<DataTable> GetSearchLeaveList(string search, string department)
        {
            try
            {
                DataTable leaveList = await formClass.GetSearchLeaveList(search, department);

                if (leaveList != null && leaveList.Rows.Count > 0)
                {
                    return leaveList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for displaying and forwarding the data into the leave user control
        public async Task LeaveList()
        {
            try
            {
                approveList.Controls.Clear();
                string department = await GetPersonnelDepartment(_userId);
                DataTable leaveList = await GetLeaveList(department);

                if (leaveList != null && leaveList.Rows.Count > 0)
                {
                    applicationForLeaveData[] applicationForLeaveData = new applicationForLeaveData[leaveList.Rows.Count];

                    for(int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in leaveList.Rows)
                        {
                            applicationForLeaveData[i] = new applicationForLeaveData(_userId, this);

                            applicationForLeaveData[i].EmployeeImage = row["employeePicture"].ToString();
                            applicationForLeaveData[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            
                            if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                                out int newEmployeeId))
                            {
                                applicationForLeaveData[i].EmployeeID = newEmployeeId;
                            }
                            else
                            {
                                applicationForLeaveData[i].EmployeeID = 0;
                            }

                            if (int.TryParse(row["applicationNumber"].ToString(), out int id))
                            {
                                applicationForLeaveData[i].ApplicationNumber = id;
                            }
                            else
                            {
                                applicationForLeaveData[i].ApplicationNumber = 0;
                            }

                            if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                            {
                                applicationForLeaveData[i].Department = $"{row["departmentName"]}";
                            }
                            else
                            {
                                applicationForLeaveData[i].Department = "------";
                            }

                            if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                            {
                                applicationForLeaveData[i].LeaveType = $"{row["leaveType"]}";
                            }
                            else
                            {
                                applicationForLeaveData[i].LeaveType = "---------";
                            }

                            if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), 
                                out DateTime datefile))
                            {
                                applicationForLeaveData[i].DateFiled = datefile.ToString("MMM dd, yyyy");
                            }
                            else
                            {
                                applicationForLeaveData[i].DateFiled = "---------";
                            }

                            if ($"{row["departmentName"]}" == department)
                            {
                                applicationForLeaveData[i].IsSameDepartment = true;
                            }
                            else
                            {
                                applicationForLeaveData[i].IsSameDepartment = false;
                            }

                            approveList.Controls.Add(applicationForLeaveData[i]);
                        }
                    }
                }
                else
                {
                    ErrorMessage("There is no records of Leave can be found in the database", "No Records");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Sql Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // This function is responsible for displaying and forwarding the data into the leave user control but this is a search data
        public async Task SearchLeaveList(string search)
        {
            try
            {
                approveList.Controls.Clear();
                string department = await GetPersonnelDepartment(_userId);
                DataTable leaveList = await GetSearchLeaveList(search, department);

                if (leaveList != null && leaveList.Rows.Count > 0)
                {
                    applicationForLeaveData[] applicationForLeaveData = new applicationForLeaveData[leaveList.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in leaveList.Rows)
                        {
                            applicationForLeaveData[i] = new applicationForLeaveData(_userId, this);

                            applicationForLeaveData[i].EmployeeImage = row["employeePicture"].ToString();
                            applicationForLeaveData[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();

                            if (int.TryParse(row["applicationNumber"].ToString(), out int id))
                            {
                                applicationForLeaveData[i].ApplicationNumber = id;
                            }
                            else
                            {
                                applicationForLeaveData[i].ApplicationNumber = 0;
                            }

                            if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                            {
                                applicationForLeaveData[i].Department = $"{row["departmentName"]}";
                            }
                            else
                            {
                                applicationForLeaveData[i].Department = "------";
                            }

                            if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                            {
                                applicationForLeaveData[i].LeaveType = $"{row["leaveType"]}";
                            }
                            else
                            {
                                applicationForLeaveData[i].LeaveType = "---------";
                            }

                            if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(),
                                out DateTime datefile))
                            {
                                applicationForLeaveData[i].DateFiled = datefile.ToString("MMM dd, yyyy");
                            }
                            else
                            {
                                applicationForLeaveData[i].DateFiled = "---------";
                            }

                            if ($"{row["departmentName"]}" == department)
                            {
                                applicationForLeaveData[i].IsSameDepartment = true;
                            }
                            else
                            {
                                applicationForLeaveData[i].IsSameDepartment = false;
                            }

                            approveList.Controls.Add(applicationForLeaveData[i]);
                        }
                    }
                }
                else
                {
                    ErrorMessage("There is no records of Leave can be found in the database", "No Records");
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom Function that will be shown if there is an error encountered
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Event Handler that handles if this user control is loaded into the system
        private async void approveUC_Load(object sender, EventArgs e)
        {
            await LeaveList();
        }

        // Event Handler that handles if the search is being clicked
        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(searchEmployee.Texts))
            {
                await SearchLeaveList(searchEmployee.Texts);
            }
            else
            {
                ErrorMessage("Please input any of the following: Employee ID, Employee first name, Employee Last name, or Employee Full name",
                    "User Input Needed");
            }
        }
    }
}
