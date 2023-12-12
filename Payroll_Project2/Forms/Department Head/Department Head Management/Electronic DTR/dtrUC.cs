using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Electronic_DTR.DTR_Sub_User_Control;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll_Project2.Forms.Personnel.DTR.DTR_User_Controls;
using System.Collections.Generic;
using System.Configuration;

namespace Payroll_Project2.Forms.Department_Head.Electronic_DTR
{
    public partial class dtrUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static dtrClass dtrClass = new dtrClass();
        private static dashboardClass dashboardClass = new dashboardClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static readonly string LeaveStatus = ConfigurationManager.AppSettings.Get("DefaultLeaveStatus");
        private static readonly string SlipStatus = ConfigurationManager.AppSettings.Get("DefaultSlipStatus");
        private static readonly string TravelStatus = ConfigurationManager.AppSettings.Get("DefaultTravelStatus");
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        private static int currentPage = 1;
        private static int recordPerPage = 10;
        private static int offset;
        private static int totalRecord;
        private static int totalPages;
        private static bool messageBoxShow = false;

        public dtrUC(int userId, departmentHeadDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        #region Functions responsible for communicating with the DTR Class

        // Function responsible for retrieving the total number of records of employee in the database
        private async Task<int> GetTotalRecords(string department)
        {
            try
            {
                int totalRecords = await dashboardClass.GetNumberOfEmployee(department);
                return totalRecords;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the lists of employee
        private async Task<DataTable> GetEmployeeList(int offset, int recordPerPage, string department)
        {
            try
            {
                DataTable employeeData = await generalFunctions.GetEmployeeList(offset, recordPerPage, department);

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

        // Function Responsible for Retrieving the searched employee
        private async Task<DataTable> GetSearchEmployee(string search, string department)
        {
            try
            {
                DataTable searchEmployeeData = await generalFunctions.GetSearchEmployee(search, department);

                if (searchEmployeeData != null && searchEmployeeData.Rows.Count > 0)
                {
                    return searchEmployeeData;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's On Time
        private async Task<int> GetOnTimeCount(int employeeId)
        {
            try
            {
                int count = await generalFunctions.GetWorkDaysCount(employeeId);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Leave
        private async Task<int> GetLeaveCount(int employeeId,string status)
        {
            try
            {
                int count = await generalFunctions.GetleaveCount(employeeId, status);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Travel Order
        private async Task<int> GetTravelOrderCount(int employeeId, string status)
        {
            try
            {
                int count = await generalFunctions.GetTravelOrderCount(employeeId, status);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Pass Slip
        private async Task<int> GetPassSlipCount(int employeeId, string status)
        {
            try
            {
                int count = await generalFunctions.GetPassSlipCount(employeeId, status);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Late
        private async Task<int> GetLateCount(int employeeId)
        {
            try
            {
                int count = await generalFunctions.GetLateCount(employeeId);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Undertime
        private async Task<int> GetUndertimeCount(int employeeId)
        {
            try
            {
                int count = await generalFunctions.GetUndertimeCount(employeeId);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Overtime
        private async Task<int> GetOvertimeCount(int employeeId)
        {
            try
            {
                int count = await generalFunctions.GetOvertimeCount(employeeId);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of the employee's Absent
        private async Task<int> GetAbsentCount(int employeeId)
        {
            try
            {
                int count = await generalFunctions.GetAbsentCount(employeeId);

                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Custom functions responsible for displaying data into the UI

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

        // This custom function is the one who display employee
        public async Task DisplayEmployeeList()
        {
            try
            {
                totalRecord = await GetTotalRecords(_department);
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                dtrContent.Controls.Clear();
                DataTable list = await GetEmployeeList(offset, recordPerPage, _department);

                if (list != null && list.Rows.Count > 0)
                {
                    dtrSubUC[] employee = new dtrSubUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        employee[i] = new dtrSubUC(_userId, this);
                        DataRow row = list.Rows[i];

                        employee[i].EmployeeId = (int)row["employeeId"];
                        employee[i].EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                        employee[i].EmployeeImage = $"{EmployeeImagePath}{row["employeePicture"]}";
                        employee[i].Departmentname = $"{row["departmentName"]}";
                        employee[i].MorningShift = $"Morning: {row["morningShiftTime"]}";
                        employee[i].AfternoonShift = $"Afternoon: {row["afternoonShiftTime"]}";
                        employee[i].DaysWorkedCount = await GetOnTimeCount((int)row["employeeId"]);
                        employee[i].LeaveCount = await GetLeaveCount((int)row["employeeId"], LeaveStatus);
                        employee[i].TravelOrderCount = await GetTravelOrderCount((int)row["employeeId"], TravelStatus);
                        employee[i].PassSlipCount = await GetPassSlipCount((int)row["employeeId"], SlipStatus);
                        employee[i].LateCount = await GetLateCount((int)row["employeeId"]);
                        employee[i].UndertimeCount = await GetUndertimeCount((int)row["employeeId"]);
                        employee[i].OvertimeCount = await GetOvertimeCount((int)row["employeeId"]);
                        employee[i].AbsentCount = await GetAbsentCount((int)row["employeeId"]);

                        dtrContent.Controls.Add(employee[i]);
                    }
                }
                else
                {
                    MessageBox.Show("No records of employees were found in the database. Please kindly notify the IT department for " +
                        "further assistance.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Function Responsible for Displaying the searched employee
        private async Task DisplaySearchEmployee(string search, string department)
        {
            try
            {
                dtrContent.Controls.Clear();
                DataTable searchEmployeeData = await GetSearchEmployee(search, department);
                totalRecord = searchEmployeeData.Rows.Count;
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";

                if (string.IsNullOrEmpty(search))
                {
                    dtrContent.Focus();
                    await DisplayEmployeeList();
                }
                else
                {
                    if (searchEmployeeData != null)
                    {
                        if (searchEmployeeData.Rows.Count > 0)
                        {
                            dtrSubUC[] employee = new dtrSubUC[searchEmployeeData.Rows.Count];

                            for (int i = 0; i < searchEmployeeData.Rows.Count; i++)
                            {
                                employee[i] = new dtrSubUC(_userId, this);
                                DataRow row = searchEmployeeData.Rows[i];

                                employee[i].EmployeeId = (int)row["employeeId"];
                                employee[i].EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                                employee[i].EmployeeImage = $"{EmployeeImagePath}{row["employeePicture"]}";
                                employee[i].Departmentname = $"{row["departmentName"]}";
                                employee[i].MorningShift = $"Morning: {row["morningShiftTime"]}";
                                employee[i].AfternoonShift = $"Afternoon: {row["afternoonShiftTime"]}";
                                employee[i].DaysWorkedCount = await GetOnTimeCount((int)row["employeeId"]);
                                employee[i].LeaveCount = await GetLeaveCount((int)row["employeeId"], LeaveStatus);
                                employee[i].TravelOrderCount = await GetTravelOrderCount((int)row["employeeId"], TravelStatus);
                                employee[i].PassSlipCount = await GetPassSlipCount((int)row["employeeId"], SlipStatus);
                                employee[i].LateCount = await GetLateCount((int)row["employeeId"]);
                                employee[i].UndertimeCount = await GetUndertimeCount((int)row["employeeId"]);
                                employee[i].OvertimeCount = await GetOvertimeCount((int)row["employeeId"]);
                                employee[i].AbsentCount = await GetAbsentCount((int)row["employeeId"]);

                                dtrContent.Controls.Add(employee[i]);
                            }
                        }
                        else
                        {
                            if (!messageBoxShow)
                            {
                                messageBoxShow = true;
                                MessageBox.Show(@"There is no records in regarding to " + searchEmployee.Texts + " stored in the database", 
                                    @"No Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            await DisplayEmployeeList();
                            dtrContent.Focus();
                        }
                    }
                }
            }
            catch (SqlException sql) { MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Event handlers for the User Interface

        // Event handlers that handles if the User Control is loaded into the application
        private async void dtrUC_Load(object sender, EventArgs e)
        {
            await DisplayEmployeeList();
        }

        private async void recordNumber__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(recordNumber.Texts) && int.TryParse(recordNumber.Texts, out int number))
            {
                recordPerPage = number;
                currentPage = 1;
                await DisplayEmployeeList();
            }
            else
            {
                currentPage = 1;
                recordPerPage = 10;
                await DisplayEmployeeList();
                dtrContent.Focus();
            }
        }

        private async void nextBtn_Click(object sender, EventArgs e)
        {
            currentPage++;
            dtrContent.Focus();

            if (currentPage == totalPages)
            {
                nextBtn.Enabled = false;
            }

            previousBtn.Enabled = true;
            await DisplayEmployeeList();
        }

        private async void previousBtn_Click(object sender, EventArgs e)
        {
            currentPage--;
            dtrContent.Focus();

            if (currentPage == 1)
            {
                previousBtn.Enabled = false;
            }

            nextBtn.Enabled = true;
            await DisplayEmployeeList();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(searchEmployee.Texts))
            {
                await DisplaySearchEmployee(searchEmployee.Texts, _department);
            }
            else
            {
                await DisplayEmployeeList();
            }
        }

        #endregion
    }
}
