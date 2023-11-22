using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_Request_Sub_User_Control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Leave_Management
{
    public partial class leaveRequestsUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formManagementClass leaveManagement = new formManagementClass();

        public leaveRequestsUC(int userId, departmentHeadDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetRequestList(string department)
        {
            try
            {
                DataTable list = await leaveManagement.GetLeaveRequestList(department);

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

        public async Task DisplayRequest()
        {
            try
            {
                requestListPanel.Controls.Clear();
                DataTable request = await GetRequestList(_department);

                if(request != null)
                {
                    leaveDataUC[] leaveData = new leaveDataUC[request.Rows.Count];

                    for (int i = 0; i < request.Rows.Count;  i++)
                    {
                        leaveData[i] = new leaveDataUC(_userId, this, _department);
                        DataRow row = request.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            leaveData[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            leaveData[i].EmployeeName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                            out int employeeId))
                        {
                            leaveData[i].EmployeeId = employeeId;
                        }
                        else
                        {
                            leaveData[i].EmployeeId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["applicationNumber"].ToString()) && int.TryParse(row["applicationNumber"].ToString(), 
                            out int applicationNumber))
                        {
                            leaveData[i].ApplicationNumber = applicationNumber;
                        }
                        else
                        {
                            leaveData[i].ApplicationNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), 
                            out DateTime dateFile))
                        {
                            leaveData[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            leaveData[i].DateFiled = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                        {
                            leaveData[i].LeaveType = $"{row["leaveType"]}";
                        }
                        else
                        {
                            leaveData[i].LeaveType = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveStartDate"].ToString()) && !string.IsNullOrEmpty(row["leaveEndDate"].ToString()) &&
                            DateTime.TryParse(row["leaveStartDate"].ToString(), out DateTime leaveStartDate) &&
                            DateTime.TryParse(row["leaveEndDate"].ToString(), out DateTime leaveEndDate))
                        {
                            leaveData[i].DateCoverage = $"{leaveStartDate: MM/dd/yyyy} - {leaveEndDate: MM/dd/yyyy}";
                        }
                        else
                        {
                            leaveData[i].DateCoverage = "-------";
                        }

                        requestListPanel.Controls.Add(leaveData[i]);

                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void leaveRequestsUC_Load(object sender, EventArgs e)
        {
            await DisplayRequest();
        }
    }
}
