using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll
{
    public partial class payroll : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly payrollClass payrollClass = new payrollClass();
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string EmployeeSignaturePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeSignaturePath");
        private static readonly string DefaultImage = ConfigurationManager.AppSettings.Get("DefaultLogo");

        public payroll(int userId, newDashboard parent)
        {
            _userId = userId;
            _parent = parent;
            InitializeComponent();
        }

        private async Task<DataTable> GetEmploymentStatus()
        {
            try
            {
                DataTable employment = await generalFunctions.GetEmploymentStatus();

                if (employment != null && employment.Rows.Count > 0)
                {
                    return employment;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetPayrollSchedule()
        {
            try
            {
                DataTable schedule = await payrollClass.GetPayrollSchedule();

                if (schedule != null && schedule.Rows.Count > 0)
                {
                    return schedule;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetEmployeeList(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable employeeList = await payrollClass.GetAllEmployeeList(fromDate, toDate);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetSpecificEmployeeList(DateTime fromDate, DateTime toDate, string employmentStatus)
        {
            try
            {
                DataTable employeeList = await payrollClass.GetSpecificEmployeeList(fromDate, toDate, employmentStatus);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task DisplayEmployee(DateTime fromDate, DateTime toDate, string employmentStatus, string imagePath, int userId, 
            string defaultImage, string schedule)
        {
            try
            {
                DataTable employeeList = employmentStatus == "Select All" ?
                await GetEmployeeList(fromDate, toDate) : await GetSpecificEmployeeList(fromDate, toDate, employmentStatus);

                if (employeeList != null)
                {
                    employeeListPanel.Controls.Clear();
                    employeeList[] employee = new employeeList[employeeList.Rows.Count];

                    for (int i = 0; i < employeeList.Rows.Count; i++)
                    {
                        employee[i] = new employeeList(userId, this);
                        DataRow row = employeeList.Rows[i];

                        employee[i].SalarySchedule = schedule;
                        employee[i].FromDate = fromDate;
                        employee[i].ToDate = toDate;

                        if (!string.IsNullOrEmpty(row["employeeName"]?.ToString()))
                        {
                            employee[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employee[i].EmployeeName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"]?.ToString()) && int.TryParse(row["employeeId"].ToString(),
                            out int employeeId))
                        {
                            employee[i].EmployeeId = employeeId;
                        }
                        else
                        {
                            employee[i].EmployeeId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"]?.ToString()))
                        {
                            employee[i].EmployeePicture = $"{imagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            employee[i].EmployeePicture = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"]?.ToString()))
                        {
                            employee[i].Department = $"{row["departmentName"]}";
                        }
                        else
                        {
                            employee[i].Department = "--------";
                        }

                        employeeListPanel.Controls.Add(employee[i]);
                    }
                }
                else
                {
                    SuccessMessages("There were no records found in the database. Please try again later", "No Records");
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

        public async Task DisplayEmployeeBehaviour()
        {
            await DisplayEmployee(fromDate.Value, toDate.Value, employmentType.Text, EmployeeImagePath, _userId, DefaultImage, scheduleType.Text);
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task DataBinding()
        {
            try
            {
                DataTable employment = await GetEmploymentStatus();
                DataTable schedule = await GetPayrollSchedule();
                fromDate.Value = DateTime.Parse("November 1, 2023");
                toDate.Value = DateTime.Parse("November 30, 2023");

                List<string> employmentList = new List<string>()
                {
                    "Select All"
                };

                List<string> scheduleList = new List<string>();


                if (employment != null && schedule != null)
                {
                    foreach (DataRow row in employment.Rows)
                    {
                        employmentList.Add($"{row["employmentStatus"]}");
                    }

                    foreach (DataRow row in schedule.Rows)
                    {
                        scheduleList.Add($"{row["payrollScheduleDescription"]}");
                    }
                }
                else
                {
                    scheduleList.Add("No Schedule Available");
                    employmentList.Clear();
                    employmentList.Add("No Employment Type Available");
                }

                employmentType.DataSource = employmentList;
                scheduleType.DataSource = scheduleList;

                employmentType.SelectedIndex = -1;
                scheduleType.SelectedIndex = -1;
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

        private async void payroll_Load(object sender, EventArgs e)
        {
            await DataBinding();
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(scheduleType.Text))
            {
                ErrorMessages("Please select the corresponding Payroll Type", "Invalid User Input");
                scheduleType.Focus();
            }
            else if(fromDate.Value == DateTime.Today || toDate.Value == DateTime.Today)
            {
                ErrorMessages("Please choose the designated dates", "Date Invalid");
            }
            else if (fromDate.Value > toDate.Value)
            {
                ErrorMessages("The ending date must be greater than the staring date", "Date Input Invalid");
            }
            else
            {
                await DisplayEmployee(fromDate.Value, toDate.Value, employmentType.Text, EmployeeImagePath, _userId, DefaultImage,scheduleType.Text);
            }
        }
    }
}
