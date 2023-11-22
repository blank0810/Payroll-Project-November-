using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents.Modal
{
    public partial class employeeList : Form
    {
        private static appForLeave _appForLeave;
        private static personnelPassSlipUC _passSlipUC;
        private static travelOrder _travelOrder;
        private static readonly string defaultUserRole = "Department Head";

        private static generalFunctions generalFunctions = new generalFunctions();
        private static formClass formClass = new formClass();

        private static int currentPage = 1;
        private static int recordPerPage = 10;
        private static int offset;
        private static int totalRecord;
        private static int totalPages;

        public employeeList(appForLeave appForLeave, personnelPassSlipUC passSlipUC, travelOrder travelOrder)
        {
            InitializeComponent();
            _appForLeave = appForLeave;
            _passSlipUC = passSlipUC;
            _travelOrder = travelOrder;
        }

        #region This functions inside responsible for communicating with the formClass in which responsible for forwarding the values retrieved by formClass into the User Interface

        // Function responsible for retrieving employee list
        private async Task<DataTable> GetEmployeeList(int offset, int recordPerPage)
        {
            try
            {
                //DataTable employeeData = await generalFunctions.GetEmployeeList();
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This functions are responsible for communicating with the formClass and the one responsible for 
        // forwarding the values from formClass to the User Interface
        // Specifically this function is responsible for forwarding the employee details
        private async Task<DataTable> GetEmployeeDetail(int employeeId)
        {
            try
            {
                formClass formClass = new formClass();
                DataTable employeeDetails = await generalFunctions.GetEmployeeDetails(employeeId);

                if (employeeDetails != null)
                {
                    return employeeDetails;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This functions are responsible for communicating with the formClass and the one responsible for 
        // forwarding the values from formClass to the User Interface
        // Specifically this function is responsible for forwarding the Department Head
        private async Task<string> GetDepartmentHead(string departmentName, string roleName)
        {
            try
            {
                formClass formClass = new formClass();

                string departmentHead = await formClass.GetDepartmentHead(departmentName, roleName);

                if (departmentHead != null)
                {
                    return departmentHead;
                }
                else
                {
                    return "No Department Head Available!";
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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

        // This functions are responsible for communicating with the formClass and the one responsible for 
        // forwarding the values from formClass to the User Interface
        // Specifically this function is the one responsible for forwarding the employee that is being searched
        private async Task DisplaySearchEmployee(string search)
        {
            try
            {
                DataTable employeeDetails = await formClass.GetSearchEmployee(search);
                totalRecord = employeeDetails.Rows.Count;
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                employeeListPanel.Controls.Clear();

                if (employeeDetails != null || employeeDetails.Rows.Count > 0)
                {
                    employeeListUC[] employeeListUC = new employeeListUC[employeeDetails.Rows.Count];

                    for (int i = 0; i < employeeDetails.Rows.Count; i++)
                    {
                        employeeListUC[i] = new employeeListUC(this);
                        DataRow row = employeeDetails.Rows[i];

                        employeeListUC[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                        employeeListUC[i].EmployeeID = Convert.ToInt32(row["employeeId"]);
                        employeeListUC[i].EmployeeImage = row["employeePicture"].ToString();
                        employeeListUC[i].DepartmentName = row["departmentName"].ToString();
                        employeeListPanel.Controls.Add(employeeListUC[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This functions are responsible for communicating with the formClass and the one responsible for 
        // forwarding the values from formClass to the User Interface
        // Specifically this function is the one responsible for forwarding the list of all employee
        private async Task LoadEmployeeList()
        {
            try
            {
                DataTable employeeDetails = await GetEmployeeList(offset, recordPerPage);
                totalRecord = employeeDetails.Rows.Count;
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                employeeListPanel.Controls.Clear();

                if (employeeDetails != null && employeeDetails.Rows.Count > 0)
                {
                    employeeListUC[] employeeListUC = new employeeListUC[employeeDetails.Rows.Count];

                    for (int i = 0; i < employeeDetails.Rows.Count; i++)
                    {
                        employeeListUC[i] = new employeeListUC(this);
                        DataRow row = employeeDetails.Rows[i];

                        employeeListUC[i].EmployeeName = row["employeefname"].ToString() + " " + row["employeelname"].ToString();
                        employeeListUC[i].EmployeeID = Convert.ToInt16(row["employeeid"]);
                        employeeListUC[i].EmployeeImage = row["employeepicture"].ToString();
                        employeeListUC[i].DepartmentName = row["departmentName"].ToString();
                        employeeListPanel.Controls.Add(employeeListUC[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region This functions inside is the functionality of the User Interface

        // This event is the one handles on what to display and what is not after the User Control or Form is being called
        private async void employeeList_Load(object sender, EventArgs e)
        {
            await LoadEmployeeList();
        }

        // This function is the on responsible for forwarding the employee Id of the chosen employee into the function responsible
        // for communicating with the formClass and at the same time retrieves it
        public async void ChosenName(int employeeId)
        {
            try
            {
                DataTable employeeDetails = await GetEmployeeDetail(employeeId);

                if (employeeDetails != null)
                {
                    bool leave = _appForLeave.PanelContent();
                    bool slip = _passSlipUC.PanelContent();
                    bool travel = _travelOrder.PanelContent();

                    if (leave)
                    {
                        foreach (DataRow row in employeeDetails.Rows)
                        {
                            if (row["employmentStatus"].ToString() != "Regular")
                            {
                                MessageBox.Show("Please be advised that the " + row["employeeFname"].ToString() + " " + row["employeeLname"].ToString() + 
                                  " is ineligible to apply for a leave request as they are not classified as a regular employee.",
                                  "Leave Request Ineligibility", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _appForLeave.ShowModal();
                            }
                            else
                            {
                                string firstName = row["employeefname"].ToString();
                                string lastName = row["employeelname"].ToString();
                                string middleName = row["employeemname"].ToString();
                                string department = row["departmentname"].ToString();
                                string salaryRate = row["salaryratedescription"].ToString();
                                string jobdescription = row["employeejobdesc"].ToString();
                                string departmentHead = await GetDepartmentHead(department, defaultUserRole);
                                _appForLeave.EmployeeDetails(employeeId, firstName, lastName, middleName, department, salaryRate, jobdescription, departmentHead);
                            }
                        }
                    }
                    else if(slip)
                    {
                        foreach (DataRow row in employeeDetails.Rows)
                        {
                            //MessageBox.Show(row["employeeFname"].ToString());
                            string firstName = row["employeefname"].ToString();
                            string lastName = row["employeelname"].ToString();
                            string middleName = row["employeemname"].ToString();
                            string department = row["departmentname"].ToString();
                            string departmentHead = await GetDepartmentHead(department, defaultUserRole);
                            _passSlipUC.ChosenName(employeeId, firstName, lastName, middleName, departmentHead, department);
                        }
                    }
                    else if(travel)
                    {
                        foreach (DataRow row in employeeDetails.Rows)
                        {
                            string firstName = row["employeefname"].ToString();
                            string lastName = row["employeelname"].ToString();
                            string middleName = row["employeemname"].ToString();
                            string department = row["departmentname"].ToString();
                            string departmentHead = await GetDepartmentHead(department, defaultUserRole);
                            _travelOrder.ChosenEmployee(employeeId, firstName, lastName, middleName, departmentHead, department);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Apologies, but an error has occurred in the system, preventing the recognition of the current " +
                            "form being used. Kindly reach out to the IT officers for prompt resolution of this issue.", 
                            "System Error: Form Recognition Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Close();
            }
            catch (SqlException sql) 
            { 
                MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This event handler if for the search employee box where it will detect that if ever there is changes on the text box
        // such as the user types something then a timer will start. Specifically 2 seconds after the user stop typing
        // the text will be forwarded to the timer's event handler below
        private void searchEmployee__TextChanged(object sender, EventArgs e)
        {
            employeeSearch.Stop();
            employeeSearch.Interval = 2000;
            employeeSearch.Tick += employeeSearch_Tick;
            employeeSearch.Start();
        }

        // After the user input is being forwarded here the time event below then send the text to the function
        // responsible for displaying the employee details of the searched employee based on the user input
        private async void employeeSearch_Tick(object sender, EventArgs e)
        {
            employeeSearch.Stop();
            await DisplaySearchEmployee(searchEmployee.Texts);
        }

        private async void recordNumber__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(recordNumber.Texts) && int.TryParse(recordNumber.Texts, out int number))
            {
                recordPerPage = number;
                currentPage = 1;
                await LoadEmployeeList();
            }
            else
            {
                await LoadEmployeeList();
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

            if (currentPage == totalPages)
            {
                nextBtn.Enabled = false;
            }

            previousBtn.Enabled = true;
            await LoadEmployeeList();
        }

        private async void previousBtn_Click(object sender, EventArgs e)
        {
            currentPage--;

            if (currentPage == 1)
            {
                previousBtn.Enabled = false;
            }

            nextBtn.Enabled = true;
            await LoadEmployeeList();
        }

        #endregion
    }
}
