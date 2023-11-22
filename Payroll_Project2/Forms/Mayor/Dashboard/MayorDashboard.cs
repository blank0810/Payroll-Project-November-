using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Dashboard.Dashboard_User_Control;
using Payroll_Project2.Forms.Mayor.Leave_Requests;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Dashboard
{
    public partial class MayorDashboard : Form
    {
        private static int _userId;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly mayorDashboard mayorDashboard = new mayorDashboard();
        private static readonly string defaultImage = ConfigurationManager.AppSettings.Get("DefaultLogo");

        public int LeaveRequestCount { get; set; }
        public int TravelRequestCount { get; set; }
        public int SlipRequestCount { get; set; }
        public int PayrollRequestCount { get; set; }

        public MayorDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<int> GetLeaveRequestCount(string department)
        {
            try
            {
                int count = await mayorDashboard.GetNumberOfLeaveRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetTravelRequestCount(string department)
        {
            try
            {
                int count = await mayorDashboard.GetNumberOfTravelRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetSlipRequestCount(string department)
        {
            try
            {
                int count = await mayorDashboard.GetNumberOfSlipRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetDepartment(int userId)
        {
            try
            {
                string department = await generalFunctions.GetPersonnelDepartment(userId);
                
                if(department != null)
                {
                    return department;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetDepartmentList()
        {
            try
            {
                DataTable list = await generalFunctions.GetDepartmentListDetails();
                
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

        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task DataBinding(int userId)
        {
            try
            {
                string department = await GetDepartment(userId);

                if (department != null)
                {
                    leaveRequestCount.DataBindings.Clear();
                    travelRequestCount.DataBindings.Clear();
                    slipRequestCount.DataBindings.Clear();
                    payrollRequestCount.DataBindings.Clear();

                    LeaveRequestCount = await GetLeaveRequestCount(department);
                    TravelRequestCount = await GetTravelRequestCount(department);
                    SlipRequestCount = await GetSlipRequestCount(department);

                    leaveRequestCount.DataBindings.Add("Text", this, "LeaveRequestCount");
                    travelRequestCount.DataBindings.Add("Text", this, "TravelRequestCount");
                    slipRequestCount.DataBindings.Add("Text", this, "SlipRequestCount");
                    payrollRequestCount.DataBindings.Add("Text", this, "PayrollRequestCount");
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        public async Task DisplayDepartment(int userId)
        {
            try
            {
                DataTable list = await GetDepartmentList();
                string department = await GetDepartment(userId);
                departmentListPanel.Controls.Clear();

                if(list != null && department != null)
                {
                    departmentDataUC[] departmentList = new departmentDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        departmentList[i] = new departmentDataUC(userId, this, department);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["departmentId"].ToString()) && int.TryParse(row["departmentId"].ToString(), 
                            out int departmentId))
                        {
                            departmentList[i].DepartmentID = departmentId;
                        }
                        else
                        {
                            departmentList[i].DepartmentID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            departmentList[i].DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            departmentList[i].DepartmentName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentLogo"].ToString()))
                        {
                            departmentList[i].DepartmentLogo = $"{row["departmentLogo"]}";
                        }
                        else
                        {
                            departmentList[i].DepartmentLogo = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["regularCount"].ToString()) && int.TryParse(row["regularCount"].ToString(), 
                            out int regularNumber))
                        {
                            departmentList[i].RegularCount = regularNumber;
                        }
                        else
                        {
                            departmentList[i].RegularCount = 0;
                        }

                        if (!string.IsNullOrEmpty(row["jobOrderCount"].ToString()) && int.TryParse(row["jobOrderCount"].ToString(), 
                            out int jobOrderNumber))
                        {
                            departmentList[i].JOCount = jobOrderNumber;
                        }
                        else
                        {
                            departmentList[i].JOCount = 0;
                        }

                        if (!string.IsNullOrEmpty(row["totalEmployees"].ToString()) && int.TryParse(row["totalEmployees"].ToString(), 
                            out int employeeNumber))
                        {
                            departmentList[i].TotalCount = employeeNumber;
                        }
                        else
                        {
                            departmentList[i].TotalCount = 0;
                        }

                        departmentListPanel.Controls.Add(departmentList[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        public async Task DisplayLeaveRequests(int userId)
        {
            try
            {
                string department = await GetDepartment(userId);
                content.Controls.Clear();
                leaveRequestsUC leaveRequest = new leaveRequestsUC(userId, this, department);

                if(!content.Controls.Contains(leaveRequest))
                {
                    content.Controls.Add(leaveRequest);
                    leaveRequest.Dock = DockStyle.Fill;
                    leaveRequest.BringToFront();
                }
                else
                {
                    leaveRequest.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        private async void MayorDashboard_Load(object sender, EventArgs e)
        {
            await DataBinding(_userId);
            await DisplayDepartment(_userId);
        }

        private async void dashboardBtn_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();
            titleLabel.Text = dashboardBtn.Text;

            if(!content.Controls.Contains(dashboardPanel))
            {
                content.Controls.Add(dashboardPanel);
                dashboardPanel.Dock = DockStyle.Fill;
                dashboardPanel.BringToFront();
                await DataBinding(_userId);
            }
            else
            {
                dashboardPanel.BringToFront();
                await DataBinding(_userId);
            }
        }

        private async void leaveBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = leaveBtn.Text;
            await DisplayLeaveRequests(_userId);
        }
    }
}
