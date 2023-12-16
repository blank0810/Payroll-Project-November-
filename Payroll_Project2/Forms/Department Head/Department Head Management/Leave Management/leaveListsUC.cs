using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_list_sub_user_control;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Leave_Management
{
    public partial class leaveListsUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static int _year = DateTime.Now.Year;
        private static readonly string defaultImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formManagementClass leaveManagement = new formManagementClass();

        public leaveListsUC(int userId, departmentHeadDashboard parent, string department)
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
                DataTable list = await leaveManagement.GetEmployeeList(department);

                if(list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetLeaveList(int employeeId, int year)
        {
            try
            {
                DataTable list = await generalFunctions.GetLeaveList(employeeId, year);

                if (list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetLeaveTypes()
        {
            try
            {
                DataTable leaveType = await generalFunctions.GetLeaveTypes();

                if(leaveType != null)
                {
                    return leaveType;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<decimal> GetLeaveCredits(int employeeId, string leaveType, int year)
        {
            try
            {
                decimal credits = await generalFunctions.GetLeaveCredits(employeeId, leaveType, year);
                return credits;
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        private async Task DisplayEmployeeList()
        {
            try
            {
                listContentPanel.Controls.Clear();
                DataTable list = await GetEmployeeList(_department);
                DataTable type = await GetLeaveTypes();

                if(list != null && type != null)
                {
                    leaveListEmployeeDataUC[] employeeList = new leaveListEmployeeDataUC[list.Rows.Count];
                    for(int i = 0; i < list.Rows.Count; i++)
                    {
                        employeeList[i] = new leaveListEmployeeDataUC(_userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            employeeList[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeeName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            employeeList[i].EmployeeImage = $"{row["employeePicture"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeeImage = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                            out int employeeId))
                        {
                            employeeList[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            employeeList[i].EmployeeID = 0;
                        }

                        foreach (DataRow typeRow in type.Rows)
                        {
                            if (typeRow["leaveType"].ToString() == "Sick Leave")
                            {
                                employeeList[i].SickLeaveCreditsBalance = await GetLeaveCredits(employeeList[i].EmployeeID, typeRow["leaveType"].ToString(), _year);
                            }
                            else
                            {
                                employeeList[i].VacationLeaveCreditsBalance = await GetLeaveCredits(employeeList[i].EmployeeID, typeRow["leaveType"].ToString(), _year);
                            }
                        }

                        listContentPanel.Controls.Add(employeeList[i]);
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

        private async void leaveListsUC_Load(object sender, EventArgs e)
        {
            await DisplayEmployeeList();
        }

        public async Task DisplayLeaveList(int employeeId)
        {
            try
            {
                DataTable list = await GetLeaveList(employeeId, _year);
                listContentPanel.Controls.Clear();

                if(list != null)
                {
                    leaveListDataUC[] leaveList = new leaveListDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        leaveList[i] = new leaveListDataUC(_userId, this, employeeId);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["applicationNumber"].ToString()) && int.TryParse(row["applicationNumber"].ToString(), 
                            out int applicationNumber))
                        {
                            leaveList[i].ApplicationNumber = applicationNumber;
                        }
                        else
                        {
                            leaveList[i].ApplicationNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                        {
                            leaveList[i].LeaveType = $"{row["leaveType"]}";
                        }
                        else
                        {
                            leaveList[i].LeaveType = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), 
                            out DateTime dateFile))
                        {
                            leaveList[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            leaveList[i].DateFiled = "-------";
                        }

                        if ((!string.IsNullOrEmpty(row["leaveStartDate"].ToString()) && !string.IsNullOrEmpty(row["leaveEndDate"].ToString())) &&
                            (DateTime.TryParse(row["leaveStartDate"].ToString(), out DateTime startDate) &&
                            DateTime.TryParse(row["leaveEndDate"].ToString(), out DateTime endDate)))
                        {
                            leaveList[i].DateCoverage = $"{startDate: MMM dd, yyyy} - {endDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            leaveList[i].DateCoverage = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            leaveList[i].Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            leaveList[i].Status = "--------";
                        }

                        listContentPanel.Controls.Add(leaveList[i]);
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

        public async Task LeaveListBehaviour(int employeeId)
        {
            try
            {
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                yearInput.Visible = true;
                applyBtn.Visible = true;
                returnBtn.Visible = true;

                label1.Visible = false;
                label8.Visible = false;
                label2.Visible = false;
                label10.Visible = false;

                listContentPanel.Focus();
                await DisplayLeaveList(employeeId);
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

        private async Task ReturnBtnBehaviour()
        {
            try
            {
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                yearInput.Visible = false;
                applyBtn.Visible = false;
                returnBtn.Visible = false;

                label1.Visible = true;
                label8.Visible = true;
                label2.Visible = true;
                label10.Visible = true;

                listContentPanel.Focus();
                await DisplayEmployeeList();
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

        private async void returnBtn_Click(object sender, EventArgs e)
        {
            await ReturnBtnBehaviour();
        }
    }
}
