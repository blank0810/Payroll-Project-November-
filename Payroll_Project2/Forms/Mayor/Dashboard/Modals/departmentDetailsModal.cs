using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Mayor.Dashboard.Dashboard_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Dashboard.Modals
{
    public partial class departmentDetailsModal : Form
    {
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string defaultImage = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public string UserRole { get; set; }
        public string SchoolName { get; set; }
        public string DateHired { get; set; }
        public string ContactNumber { get; set; }
        public string JobDescription { get; set; }
        public string DepartmentLogo { get; set; }

        public departmentDetailsModal()
        {
            InitializeComponent();
        }

        private async Task<DataTable> GetEmployeeList(int departmentId)
        {
            try
            {
                DataTable list = await generalFunctions.GetEmployeeList(departmentId);

                if (list != null)
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

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task DisplayEmployee(int departmentId, string defaultImage)
        {
            try
            {
                DataTable list = await GetEmployeeList(departmentId);
                employeeListPanel.Controls.Clear();

                if (list != null)
                {
                    employeeDataUC[] employeeList = new employeeDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        employeeList[i] = new employeeDataUC();
                        DataRow row = list.Rows[i];

                        AssignValueIfNotEmpty(row, "employeeName", value => employeeList[i].EmployeeName = value, "-------");
                        AssignValueIfNotEmpty(row, "employmentStatus", value => employeeList[i].EmploymentStatus = value, "-------");
                        AssignValueIfNotEmpty(row, "employeeJobDesc", value => employeeList[i].JobDescription = value, "--------");

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(),
                            out int employeeId))
                        {
                            employeeList[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            employeeList[i].EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            employeeList[i].EmployeePicture = $"{EmployeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeePicture = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["dateHired"].ToString()) && DateTime.TryParse(row["dateHired"].ToString(),
                            out DateTime dateHired))
                        {
                            employeeList[i].DateHired = $"{dateHired: MM-dd-yyyy}";
                        }
                        else
                        {
                            employeeList[i].DateHired = "--:--:--";
                        }

                        employeeListPanel.Controls.Add(employeeList[i]);
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

        private void DataBinding()
        {
            departmentHead.DataBindings.Clear();
            departmentName.DataBindings.Clear();
            userRole.DataBindings.Clear();
            school.DataBindings.Clear();
            dateHired.DataBindings.Clear();
            contactNumber.DataBindings.Clear();
            description.DataBindings.Clear();
            departmentLogo.DataBindings.Clear();

            departmentHead.DataBindings.Add("Text", this, "DepartmentHead");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            userRole.DataBindings.Add("Text", this, "UserRole");
            school.DataBindings.Add("Text", this, "SchoolName");
            dateHired.DataBindings.Add("Text", this, "DateHired");
            contactNumber.DataBindings.Add("Text", this, "ContactNumber");
            description.DataBindings.Add("Text", this, "JobDescription");
            departmentLogo.DataBindings.Add("ImageLocation", this, "DepartmentLogo");
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

        private async void departmentDetailsModal_Load(object sender, EventArgs e)
        {
            DataBinding();
            await DisplayEmployee(DepartmentId, defaultImage);
        }

        private void departmentDetailsModal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Escape key
            if (e.KeyChar == (char)27) // 27 is the ASCII code for the Escape key
            {
                // Close the form
                this.Close();
            }
        }
    }
}
