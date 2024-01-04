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
                int totalRecords = await dtrClass.GetNumberOfEmployee(department);

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
        private async Task DisplayEmployeeList(string department)
        {
            try
            {
                totalRecord = await GetTotalRecords(department);
                UpdatePagination();
                pageLabel.Text = $"Page: {currentPage} of {totalPages}";
                dtrContent.Controls.Clear();
                DataTable list = await GetEmployeeList(offset, recordPerPage, department);

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
                        employee[i].MorningShift = $"{row["morningShiftTime"]}";
                        employee[i].AfternoonShift = $"{row["afternoonShiftTime"]}";

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

        #endregion

        #region Event handlers for the User Interface

        // Event handlers that handles if the User Control is loaded into the application
        private async void dtrUC_Load(object sender, EventArgs e)
        {
            await DisplayEmployeeList(_department);
        }

        private async void recordNumber__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(recordNumber.Texts) && int.TryParse(recordNumber.Texts, out int number))
            {
                recordPerPage = number;
                currentPage = 1;
                await DisplayEmployeeList(_department);
            }
            else
            {
                currentPage = 1;
                recordPerPage = 10;
                await DisplayEmployeeList(_department);
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
            await DisplayEmployeeList(_department);
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
            await DisplayEmployeeList(_department);
        }

        #endregion
    }
}
