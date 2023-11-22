using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee
{
    public partial class employeeUserControl : UserControl
    {
        private static int userId;
        public static employeeClass employeeClass = new employeeClass();
        private static bool messageBoxShow = false;
        private static generalFunctions generalFunctions = new generalFunctions();

        private static int currentPage = 1;
        private static int recordPerPage = 10;
        private static int offset;
        private static int totalRecord;
        private static int totalPages;

        public employeeUserControl(int id)
        {
            InitializeComponent();
            userId = id;
        }

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function Responsible for Retrieving Employee List
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; } catch (Exception ex ) { throw ex; }
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function Responsible for retrieving the automated employee id from the database when adding a new employee
        private async Task<int> GetEmployeeId()
        {
            try
            {
                int employeeId = await employeeClass.GetEmployeeId();

                if (employeeId != 1)
                {
                    if (int.TryParse(employeeId.ToString(), out int id))
                    {
                        return id;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid employee ID value retrieved. Contact the System Administrator for quick resolution");
                    }
                }
                else
                {
                    return employeeId;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function Responsible for Displaying the searched employee
        private async Task DisplaySearchEmployee(string search)
        {
            try
            {
                employeeList.Controls.Clear();
                DataTable searchEmployeeData = await GetSearchEmployee(search);
                totalRecord = searchEmployeeData.Rows.Count;
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";

                if (string.IsNullOrEmpty(search))
                {
                    await DisplayEmployee();
                    employeeList.Focus();
                }
                else
                {
                    if (searchEmployeeData != null)
                    {
                        if (searchEmployeeData.Rows.Count > 0)
                        {
                            employeeDataUC[] employeeDataUC = new employeeDataUC[searchEmployeeData.Rows.Count];

                            for (int i = 0; i < searchEmployeeData.Rows.Count; i++)
                            {
                                employeeDataUC[i] = new employeeDataUC(this, userId);
                                DataRow row = searchEmployeeData.Rows[i];

                                employeeDataUC[i].employeeName = row["employeefname"].ToString() + " " + row["employeelname"].ToString();
                                employeeDataUC[i].employeeDepartment = row["departmentName"].ToString();
                                employeeDataUC[i].employeeStatus = row["employmentstatus"].ToString();
                                employeeDataUC[i].employeeId = (int)row["employeeid"];
                                employeeDataUC[i].jobDescription = row["employeejobdesc"].ToString();
                                employeeDataUC[i].employeeImage = row["employeepicture"].ToString();
                                employeeList.Controls.Add(employeeDataUC[i]);
                                employeeList.Focus();
                            }
                        }
                        else
                        {
                            if (!messageBoxShow)
                            {
                                messageBoxShow = true;
                                MessageBox.Show(@"There is no records in regarding to " + searchEmployee.Texts + " stored in the database", @"No Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            await DisplayEmployee();
                        }
                    }
                }
            }
            catch (SqlException sql) { MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Function Responsible for Displaying the searched employee
        private async Task DisplayFilterResult(string departmentName, string status)
        {
            try
            {
                employeeList.Controls.Clear();
                DataTable results = await GetFilterResults(departmentName, status);

                if (results != null && results.Rows.Count > 0)
                {
                    totalRecord = results.Rows.Count;
                    UpdatePagination();
                    pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                    employeeDataUC[] employeeDataUC = new employeeDataUC[results.Rows.Count];

                    for (int i = 0; i < results.Rows.Count; i++)
                    {
                        employeeDataUC[i] = new employeeDataUC(this, userId);
                        DataRow row = results.Rows[i];

                        employeeDataUC[i].employeeName = row["employeeName"].ToString();
                        employeeDataUC[i].employeeDepartment = row["departmentName"].ToString();
                        employeeDataUC[i].employeeStatus = row["employmentstatus"].ToString();
                        employeeDataUC[i].employeeId = (int)row["employeeid"];
                        employeeDataUC[i].jobDescription = row["employeejobdesc"].ToString();
                        employeeDataUC[i].employeeImage = row["employeepicture"].ToString();
                        employeeList.Controls.Add(employeeDataUC[i]);
                        employeeList.Focus();
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

        // Function responsible for displaying the employee lists
        public async Task DisplayEmployee()
        {
            try
            {
                totalRecord = await GetTotalRecords();
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                employeeList.Controls.Clear();
                DataTable list = await GetEmployeeList(offset, recordPerPage);

                if (list != null && list.Rows.Count > 0)
                {
                    employeeDataUC[] employeeDataUC = new employeeDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        DataRow row = list.Rows[i];

                        employeeDataUC[i] = new employeeDataUC(this, userId);

                        employeeDataUC[i].employeeName = row["employeefname"].ToString() + " " + row["employeelname"].ToString();
                        employeeDataUC[i].employeeDepartment = row["departmentName"].ToString();
                        employeeDataUC[i].employeeStatus = row["employmentstatus"].ToString();
                        employeeDataUC[i].employeeId = (int)row["employeeid"];
                        employeeDataUC[i].jobDescription = row["employeejobdesc"].ToString();
                        employeeDataUC[i].employeeImage = row["employeepicture"].ToString();

                        employeeList.Controls.Add(employeeDataUC[i]);
                    }
                }
                else
                {
                    MessageBox.Show("There is no employee recorded in the database. Please contact the System Administrator for resolution",
                        "Employee List Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Custom Function that handles what control to hide and shows for the UI behaviour
        public void UserControlBehaviour()
        {
            description.Visible = false;
            searchEmployee.Visible = false;
            searchBtn.Visible = false;
            addBtn.Visible = false;
            employmentStatus.Visible = false;
            departmentName.Visible = false;
            filterBtn.Visible = false;
            returnBtn.Visible = true;
            returnBtn.BringToFront();
        }

        // Custom function that handles of what controls to hide and shows for the UI behaviour
        public async void afterAddEmployee()
        {
            content.Controls.Clear();
            searchEmployee.Visible = true;
            searchBtn.Visible = true;
            addBtn.Visible = true;
            employmentStatus.Visible = true;
            departmentName.Visible = true;
            filterBtn.Visible = true;
            returnBtn.Visible = false;

            employeeList.Visible = true;
            description.Visible = true;
            content.Controls.Add(description);
            description.Dock = DockStyle.Top;

            content.Controls.Add(employeeList);
            employeeList.Dock = DockStyle.Fill;

            employeeList.BringToFront();
            await DisplayEmployee();
        }

        // Event Handler that handles when the Employee User Control is loaded
        private async void employeeUserControl_Load(object sender, EventArgs e)
        {
            returnBtn.Visible = false;
            await DataBinding();
            employeeList.Focus();
            await DisplayEmployee();
        }

        // Event Handler that handles if the add employee button is clicked
        private async void addBtn_Click(object sender, EventArgs e)
        {
            addEmployeeModal addEmployee = new addEmployeeModal(userId, this);
            addEmployee.EmployeeID = await GetEmployeeId();
            addEmployee.DateHired = DateTime.Today;
            addEmployee.ShowDialog();
            await DisplayEmployee();
        }

        // Event Handler that handles if the Return to list button is clicked
        private async void returnBtn_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();
            searchEmployee.Visible = true;
            searchBtn.Visible = true;
            addBtn.Visible = true;
            employmentStatus.Visible = true;
            departmentName.Visible = true;
            filterBtn.Visible = true;
            returnBtn.Visible = false;

            employeeList.Visible = true;
            description.Visible = true;
            content.Controls.Add(description);
            description.Dock = DockStyle.Top;

            content.Controls.Add(employeeList);
            employeeList.Dock = DockStyle.Fill;
            employeeList.Focus();

            employeeList.BringToFront();
            await DisplayEmployee();
        }

        // This is for the text box in for searching employee. It send responds to the background worker if the user stops typing after 2 secs
        private async void searchEmployee__TextChanged(object sender, EventArgs e)
        {
            #region This is for the user types in the text box with 2 second interval before querying

            if(!string.IsNullOrWhiteSpace(searchEmployee.Texts))
            {
                departmentSearchTimer.Stop();
                departmentSearchTimer.Interval = 1000;
                departmentSearchTimer.Tick += departmentSearchTimer_Tick;
                departmentSearchTimer.Start();
            }
            else
            {
                await DisplayEmployee();
                employeeList.Focus();
            }

            #endregion
        }

        // The background worker responsible for forwarding the value of user input for searching  the employee
        private async void departmentSearchTimer_Tick(object sender, EventArgs e)
        {
            departmentSearchTimer.Stop();
            await DisplaySearchEmployee(searchEmployee.Texts);
        }

        // Event Handler handles if the search button is clicked
        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(searchEmployee.Texts))
            {
                MessageBox.Show("Kindly provide the Employee ID or Employee Name.");
                searchEmployee.BorderColor = Color.Red;
                searchEmployee.Focus();
            }
            else
            {
                await DisplaySearchEmployee(searchEmployee.Texts);
            }
        }

        private async void filterBtn_Click(object sender, EventArgs e)
        {
            if(employmentStatus.SelectedIndex == 0 && departmentName.SelectedIndex == 0)
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

        private async void recordNumber__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(recordNumber.Texts) && int.TryParse(recordNumber.Texts, out int number))
            {
                recordPerPage = number;
                currentPage = 1;
                await DisplayEmployee();
            }
            else
            {
                currentPage = 1;
                recordPerPage = 10;
                await DisplayEmployee();
                employeeList.Focus();
            }
        }

        private void recordNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || e.KeyChar == 0)
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private async void nextBtn_Click(object sender, EventArgs e)
        {
            currentPage++;
            
            if(currentPage == totalPages)
            {
                nextBtn.Enabled = false;
            }

            previousBtn.Enabled = true;
            await DisplayEmployee();
        }

        private async void previousBtn_Click(object sender, EventArgs e)
        {
            currentPage--;

            if (currentPage == 1)
            {
                previousBtn.Enabled = false;
            }

            nextBtn.Enabled = true;
            await DisplayEmployee();
        }
    }
}
