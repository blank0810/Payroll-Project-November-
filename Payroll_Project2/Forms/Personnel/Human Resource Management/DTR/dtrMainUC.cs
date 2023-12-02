using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.DTR.DTR_User_Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.DTR
{
    public partial class dtrMainUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static dtrClass dtrClass = new dtrClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static readonly string LeaveStatus = ConfigurationManager.AppSettings.Get("DefaultLeaveStatus");
        private static readonly string TravelStatus = ConfigurationManager.AppSettings.Get("DefaultTravelStatus");
        private static readonly string SlipStatus = ConfigurationManager.AppSettings.Get("DefaultSlipStatus");
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        private static int currentPage = 1;
        private static int recordPerPage = 10;
        private static int offset;
        private static int totalRecord;
        private static int totalPages;
        private static bool messageBoxShow = false;

        public dtrMainUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        #region Functions responsible for communicating with the DTR Class

        // Function responsible for retrieving the total number of records of employee in the database
        private async Task<int> GetTotalRecords()
        {
            try
            {
                int totalRecords = await generalFunctions.GetNumberOfEmployee();

                if (totalRecords > 0)
                {
                    return totalRecords;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function that responsible for retrieving the Employment Status
        private async Task<DataTable> GeEmploymentStatus()
        {
            try
            {
                DataTable status = await generalFunctions.GetEmploymentStatus();

                if (status != null && status.Rows.Count > 0)
                {
                    return status;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieiving the Department Lists
        private async Task<DataTable> GetDepartmentList()
        {
            try
            {
                DataTable department = await generalFunctions.GetDepartmentList();

                if (department != null && department.Rows.Count > 0)
                {
                    return department;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the lists of employee
        private async Task<DataTable> GetEmployeeList(int offset, int recordPerPage)
        {
            try
            {
                DataTable employeeData = await generalFunctions.GetEmployeeList(offset, recordPerPage);

                if (employeeData != null && employeeData.Rows.Count > 0)
                {
                    return employeeData;
                }
                else
                {
                    return null;
                }
            }
            catch(SqlException sql) { throw sql; } catch(Exception ex) { throw ex; } 
        }

        // Function responsible for retrieving the filtered result
        private async Task<DataTable> GetFilterResults(string departmentName, string status)
        {
            try
            {
                DataTable result = await generalFunctions.GetFilterResult(departmentName, status);

                if (result != null && result.Rows.Count > 0)
                {
                    return result;
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
        private async Task<DataTable> GetSearchEmployee(string search)
        {
            try
            {
                DataTable searchEmployeeData = await generalFunctions.GetSearchEmployee(search);

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
        private async Task<int> GetLeaveCount(int employeeId, string status)
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
        private async Task<int> GetTravelOrderCount(int employeeId,string status)
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

        // Function responsible for binding values
        private async Task DataBinding()
        {
            try
            {
                DataTable status = await GeEmploymentStatus();
                DataTable deparmentTable = await GetDepartmentList();

                if ((deparmentTable != null && deparmentTable.Rows.Count > 0) && (status != null && status.Rows.Count > 0))
                {
                    List<string> employmentStatusList = new List<string>();
                    List<string> departmentList = new List<string>();

                    employmentStatusList.Add("All Employee");
                    foreach (DataRow row in status.Rows)
                    {
                        string item = (row["employmentStatus"].ToString());
                        employmentStatusList.Add(item);
                    }

                    departmentList.Add("All Departments");
                    foreach (DataRow row in deparmentTable.Rows)
                    {
                        string item = (row["departmentName"].ToString());
                        departmentList.Add(item);
                    }

                    employmentStatus.DataSource = employmentStatusList;
                    departmentName.DataSource = departmentList;

                    employmentStatus.SelectedIndex = 0;
                    departmentName.SelectedIndex = 0;
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

        // Function Responsible for Displaying the searched employee
        private async Task DisplayFilterResult(string departmentName, string status)
        {
            try
            {
                dtrContent.Controls.Clear();
                DataTable results = await GetFilterResults(departmentName, status);

                if (results != null && results.Rows.Count > 0)
                {
                    totalRecord = results.Rows.Count;
                    UpdatePagination();
                    pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                    employeeDTRUC[] employee = new employeeDTRUC[results.Rows.Count];

                    for (int i = 0; i < results.Rows.Count; i++)
                    {
                        employee[i] = new employeeDTRUC(_userId, this);
                        DataRow row = results.Rows[i];

                        employee[i].EmployeeId = (int)row["employeeId"];
                        employee[i].EmployeeName = $"{row["employeeName"]}";
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
                    totalRecord = 0;
                    UpdatePagination();
                    pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                }
            }
            catch (SqlException sql) { MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // This custom function is the one who display employee
        private async Task DisplayEmployeeList()
        {
            try
            {
                totalRecord = await GetTotalRecords();
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                dtrContent.Controls.Clear();
                DataTable list = await GetEmployeeList(offset, recordPerPage);

                if (list != null && list.Rows.Count > 0)
                {
                    employeeDTRUC[] employee = new employeeDTRUC[list.Rows.Count];

                    for(int i = 0; i < list.Rows.Count; i++)
                    {
                        employee[i] = new employeeDTRUC(_userId, this);
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
        private async Task DisplaySearchEmployee(string search)
        {
            try
            {
                dtrContent.Controls.Clear();
                DataTable searchEmployeeData = await GetSearchEmployee(search);
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
                            employeeDTRUC[] employee = new employeeDTRUC[searchEmployeeData.Rows.Count];

                            for (int i = 0; i < searchEmployeeData.Rows.Count; i++)
                            {
                                employee[i] = new employeeDTRUC(_userId, this);
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
                                MessageBox.Show(@"There is no records in regarding to " + searchEmployee.Texts + " stored in the database", @"No Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private async void dtrMainUC_Load(object sender, EventArgs e)
        {
            await DataBinding();
            await DisplayEmployeeList();
        }

        // Event handler that handles if the apply button is being clicked
        private async void applyBtn_Click(object sender, EventArgs e)
        {
            if (employmentStatus.SelectedIndex == 0 && departmentName.SelectedIndex == 0)
            {
                await DisplayFilterResult("", "");
            }
            else if (employmentStatus.SelectedIndex == 0 && departmentName.SelectedIndex > 0)
            {
                await DisplayFilterResult(departmentName.Text, "");
            }
            else if (employmentStatus.SelectedIndex > 0 && departmentName.SelectedIndex == 0)
            {
                await DisplayFilterResult("", employmentStatus.Text);
            }
            else
            {
                await DisplayFilterResult(departmentName.Text, employmentStatus.Text);
            }
        }

        private void searchEmployee__TextChanged(object sender, EventArgs e)
        {
            employeeSearchTimer.Stop();
            employeeSearchTimer.Interval = 2000;
            employeeSearchTimer.Tick += employeeSearchTimer_Tick;
            employeeSearchTimer.Start();
        }

        private async void employeeSearchTimer_Tick(object sender, EventArgs e)
        {
            employeeSearchTimer.Stop();
            await DisplaySearchEmployee(searchEmployee.Texts);
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

        #endregion
    }
}
