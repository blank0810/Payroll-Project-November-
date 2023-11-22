using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Leave_Logs.Leave_logs_sub_user_control;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Leave_Logs
{
    public partial class leaveLogsUC : UserControl
    {
        private static int _userId;
        private departmentHeadDashboard _parent;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static int _year = DateTime.Now.Year;

        public leaveLogsUC(int userId, departmentHeadDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetLeaveList(int employeeId, int year)
        {
            try
            {
                DataTable leaveList = await generalFunctions.GetLeaveList(employeeId, year);

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

        private async Task DisplayLeave(int employeeId, int year)
        {
            try
            {
                listContentPanel.Controls.Clear();
                DataTable list = await GetLeaveList(employeeId, year);

                if (list != null && list.Rows.Count > 0)
                {
                    leaveLogsDataUC[] leaveLogs = new leaveLogsDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        leaveLogs[i] = new leaveLogsDataUC(_userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["applicationNumber"].ToString()) && int.TryParse(row["applicationNumber"].ToString(),
                            out int applicationNumber))
                        {
                            leaveLogs[i].ApplicationNumber = applicationNumber;
                        }
                        else
                        {
                            leaveLogs[i].ApplicationNumber = -1;
                        }

                        if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                        {
                            leaveLogs[i].LeaveType = $"{row["leaveType"]}";
                        }
                        else
                        {
                            leaveLogs[i].LeaveType = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(),
                            out DateTime dateFile))
                        {
                            leaveLogs[i].DateFiled = dateFile.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            leaveLogs[i].DateFiled = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveStartDate"].ToString()) && !string.IsNullOrEmpty(row["leaveEndDate"].ToString()))
                        {
                            DateTime startDate = DateTime.Parse(row["leaveStartDate"].ToString());
                            DateTime endDate = DateTime.Parse(row["leaveEndDate"].ToString());

                            leaveLogs[i].DateCoverage = $"{startDate: MMM dd yyyy} - {endDate: MMM dd yyyy}";
                        }
                        else
                        {
                            leaveLogs[i].DateCoverage = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            leaveLogs[i].Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            leaveLogs[i].Status = "---------";
                        }

                        listContentPanel.Controls.Add(leaveLogs[i]);
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

        private async void leaveLogsUC_Load(object sender, EventArgs e)
        {
            await DisplayLeave(_userId, _year);
        }

        private void yearInput__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(yearInput.Texts) && int.TryParse(yearInput.Texts, out int year))
            {
                _year = year;
            }
            else
            {
                MessageBox.Show("Please input proper year", "Year Input Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void applyBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeave(_userId, _year);
        }
    }
}
