using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Dashboard;
using Payroll_Project2.Forms.Mayor.Leave_Requests.Leave_Request_Sub_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Leave_Requests
{
    public partial class leaveRequestsUC : UserControl
    {
        private static int _userId;
        private static MayorDashboard _parent;
        private static string _userDepartment;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();
        private static readonly mayorDashboard mayorDashboard = new mayorDashboard();

        private static int currentPage = 1;
        private static int recordPerPage = 10;
        private static int offset;
        private static int totalRecord;
        private static int totalPages;

        public leaveRequestsUC(int userId, MayorDashboard parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }

        // This function is responsible for retrieving the list of leave request
        private async Task<DataTable> GetLeaveRequestList(string department, int offset, int recordPerPage)
        {
            try
            {
                DataTable list = await formRequestClass.GetLeaveRequestList(department, offset, recordPerPage);

                if( list != null && list.Rows.Count > 0)
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

        private async Task<int> GetTotalRecords(string department)
        {
            try
            {
                int total = await mayorDashboard.GetNumberOfLeaveRequest(department);

                if (total > 0)
                {
                    return total;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql;  } catch (Exception ex) { throw ex; }
        }

        // Custom function for updating the pagination behaviour
        private void UpdatePagination()
        {
            try
            {
                totalPages = (int)Math.Ceiling((double)totalRecord / recordPerPage);
                offset = (currentPage - 1) * recordPerPage;

                if (totalRecord <= recordPerPage)
                {
                    nextBtn.Enabled = false;
                    previousBtn.Enabled = false;
                }
                else if (totalRecord > recordPerPage && currentPage == 1)
                {
                    nextBtn.Enabled = true;
                    previousBtn.Enabled = false;
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async Task DisplayLeaveRequest(int userId, string department)
        {
            try
            {
                totalRecord = await GetTotalRecords(department);
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                requestListPanel.Controls.Clear();
                DataTable list = await GetLeaveRequestList(department, offset, recordPerPage);

                if (list != null)
                {
                    requestDataUC[] leaveRequest = new requestDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        leaveRequest[i] = new requestDataUC(userId, this, department);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["applicationNumber"].ToString()) && int.TryParse(row["applicationNumber"].ToString(),
                            out int applicationNumber))
                        {
                            leaveRequest[i].ApplicationNumber = applicationNumber;
                        }
                        else
                        {
                            leaveRequest[i].ApplicationNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(),
                            out int employeeId))
                        {
                            leaveRequest[i].EmployeeId = employeeId;
                        }
                        else
                        {
                            leaveRequest[i].EmployeeId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            leaveRequest[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            leaveRequest[i].EmployeeName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(),
                            out DateTime dateFile))
                        {
                            leaveRequest[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            leaveRequest[i].DateFiled = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                        {
                            leaveRequest[i].LeaveType = $"{row["leaveType"]}";
                        }
                        else
                        {
                            leaveRequest[i].LeaveType = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveStartDate"].ToString()) && !string.IsNullOrEmpty(row["leaveEndDate"].ToString()) &&
                            DateTime.TryParse(row["leaveStartDate"].ToString(), out DateTime startDate) &&
                            DateTime.TryParse(row["leaveEndDate"].ToString(), out DateTime endDate))
                        {
                            leaveRequest[i].DateCoverage = $"{startDate: MM/dd/yyyy} - {endDate: MM/dd/yyyy}";
                        }
                        else
                        {
                            leaveRequest[i].DateCoverage = "--------";
                        }

                        requestListPanel.Controls.Add(leaveRequest[i]);
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

        private async void leaveRequestsUC_Load(object sender, EventArgs e)
        {
            await DisplayLeaveRequest(_userId, _userDepartment);
        }

        private async void recordNumber__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(recordNumber.Texts) && int.TryParse(recordNumber.Texts, out int number))
            {
                recordPerPage = number;
                currentPage = 1;
                await DisplayLeaveRequest(_userId, _userDepartment);
            }
            else
            {
                currentPage = 1;
                recordPerPage = 10;
                await DisplayLeaveRequest(_userId, _userDepartment); ;
                requestListPanel.Focus();
            }
        }

        private async void nextBtn_Click(object sender, EventArgs e)
        {
            currentPage++;
            requestListPanel.Focus();

            if (currentPage == totalPages)
            {
                nextBtn.Enabled = false;
            }

            previousBtn.Enabled = true;
            await DisplayLeaveRequest(_userId, _userDepartment);
        }

        private async void previousBtn_Click(object sender, EventArgs e)
        {
            currentPage--;
            requestListPanel.Focus();

            if (currentPage == 1)
            {
                previousBtn.Enabled = false;
            }

            nextBtn.Enabled = true;
            await DisplayLeaveRequest(_userId, _userDepartment);
        }
    }
}
