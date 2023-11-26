using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Dashboard;
using Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Pass_Slip_Request_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pass_Slip_Requests
{
    public partial class passSlipRequestsUC : UserControl
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


        public passSlipRequestsUC(int userId, MayorDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = department;
        }

        private async Task<DataTable> GetSlipRequestList(string department, int offset, int recordPerPage)
        {
            try
            {
                DataTable list = await formRequestClass.GetSlipRequest(department, offset, recordPerPage);

                if(list != null && list.Rows.Count > 0)
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
                int count = await mayorDashboard.GetNumberOfSlipRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

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

        private void AssignValueIfNotEmpty(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            string value = row[columnName]?.ToString();
            assignAction(!string.IsNullOrEmpty(value) ? value : defaultValue);
        }

        private void ParseAndAssignDateTime(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            if (!string.IsNullOrEmpty(row[columnName]?.ToString()) && DateTime.TryParse(row[columnName]?.ToString(), out DateTime parsedDate))
            {
                assignAction($"{parsedDate: MMM dd, yyyy}");
            }
            else
            {
                assignAction(defaultValue);
            }
        }

        private void ParseAndAssignInt(DataRow row, string columnName, Action<int> assignAction, int defaultValue)
        {
            if (!string.IsNullOrEmpty(row[columnName]?.ToString()) && int.TryParse(row[columnName]?.ToString(), out int parsedInt))
            {
                assignAction(parsedInt);
            }
            else
            {
                assignAction(defaultValue);
            }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async Task DisplayRequest(int userId, string department)
        {
            try
            {
                totalRecord = await GetTotalRecords(department);
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                requestListPanel.Controls.Clear();
                DataTable list = await GetSlipRequestList(department, offset, recordPerPage);

                if (list != null)
                {
                    slipRequestDataUC[] slipList = new slipRequestDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        slipList[i] = new slipRequestDataUC(userId, this, department);
                        DataRow row = list.Rows[i];

                        ParseAndAssignInt(row, "employeeId", value => slipList[i].EmployeeId = value, 0);
                        AssignValueIfNotEmpty(row, "employeeName", value => slipList[i].EmployeeName = value, "---------");
                        ParseAndAssignInt(row, "slipControlNumber", value => slipList[i].ControlNumber = value, 0);
                        ParseAndAssignDateTime(row, "dateFile", value => slipList[i].DateFiled = value, "---------");
                        ParseAndAssignDateTime(row, "slipDate", value => slipList[i].SlipDate = value, "---------");

                        if (!string.IsNullOrEmpty(row["timeUsed"]?.ToString()) && TimeSpan.TryParse(row["timeUsed"]?.ToString(), 
                            out TimeSpan timeUsed))
                        {
                            slipList[i].TimeUsed = timeUsed;
                        }
                        else
                        {
                            slipList[i].TimeUsed = TimeSpan.Zero;
                        }

                        if(!string.IsNullOrEmpty(row["isNoted"]?.ToString()))
                        {
                            slipList[i].IsNoteNull = true;
                        }
                        else
                        {
                            slipList[i].IsNoteNull = false;
                        }

                        requestListPanel.Controls.Add(slipList[i]);
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

        private async void passSlipRequestsUC_Load(object sender, EventArgs e)
        {
            await DisplayRequest(_userId, _userDepartment);
        }

        private async void recordNumber__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(recordNumber.Texts) && int.TryParse(recordNumber.Texts, out int number))
            {
                recordPerPage = number;
                currentPage = 1;
                await DisplayRequest(_userId, _userDepartment);
            }
            else
            {
                currentPage = 1;
                recordPerPage = 10;
                await DisplayRequest(_userId, _userDepartment);
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
            await DisplayRequest(_userId, _userDepartment);
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
            await DisplayRequest(_userId, _userDepartment);
        }
    }
}
