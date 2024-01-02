using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.System_Administrator.Department_Management.Modal.Modal_User_Control;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal
{
    public partial class departmentInformationModal : Form
    {
        private static int _userId;

        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string employeeImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public string UserRole { get; set; }
        public string SchoolName { get; set; }
        public string DateHired { get; set; }
        public string ContactNumber { get; set; }
        public string JobDescription { get; set; }
        public string DepartmentLogo { get; set; }

        public departmentInformationModal(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<DataTable> GetEmployeeList(int departmentId)
        {
            try
            {
                DataTable EmployeeTable = await generalFunctions.GetEmployeeList(departmentId);

                if (EmployeeTable != null && EmployeeTable.Rows.Count > 0)
                {
                    return EmployeeTable;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task EmployeeList(int departmentId, int userId)
        {
            try
            {
                DataTable EmployeeTable = await GetEmployeeList(departmentId);

                if (EmployeeTable != null && EmployeeTable.Rows.Count > 0)
                {
                    personnelDataUC[] employee = new personnelDataUC[EmployeeTable.Rows.Count];

                    for (int i = 0; i < EmployeeTable.Rows.Count; i++)
                    {
                        DataRow row = EmployeeTable.Rows[i];
                        employee[i] = new personnelDataUC(userId);

                        if (DateTime.TryParse(row["dateHired"].ToString(), out DateTime dateHired))
                        {
                            employee[i].DateHired = dateHired.ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            employee[i].DateHired = "Not Set";
                        }

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            employee[i].EmployeeName = row["employeeName"].ToString();
                        }
                        else
                        {
                            employee[i].EmployeeName = "Not Set";
                        }

                        if (!string.IsNullOrEmpty(row["employmentStatus"].ToString()))
                        {
                            employee[i].EmploymentStatus = row["employmentstatus"].ToString();
                        }
                        else
                        {
                            employee[i].EmploymentStatus = "Not Set";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"]?.ToString()))
                        {
                            employee[i].JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            employee[i].JobDescription = $"---------";
                        }

                        if (int.TryParse(row["employeeId"].ToString(), out int id))
                        {
                            employee[i].EmployeeID = id;
                        }
                        else
                        {
                            employee[i].EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            employee[i].EmployeePicture = $"{employeeImagePath}{row["employeepicture"]}";
                        }
                        else
                        {
                            employee[i].EmployeePicture = employeeImage;
                        }

                        empList.Controls.Add(employee[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(text: sql.Message, caption: "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption: @"Inside Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBinding()
        {
            #region Function for Assigning the values

            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            departmentHead.DataBindings.Add("Text", this, "DepartmentHead");
            userRole.DataBindings.Add("Text", this, "UserRole");
            school.DataBindings.Add("Text", this, "SchoolName");
            dateHired.DataBindings.Add("Text", this, "DateHired");
            contactNumber.DataBindings.Add("Text", this, "ContactNumber");
            description.DataBindings.Add("Text", this, "JobDescription");
            departmentLogo.DataBindings.Add("ImageLocation", this, "DepartmentLogo");

            #endregion
        }

        private async void departmentInformationModal_Load(object sender, EventArgs e)
        {
            DataBinding();
            await EmployeeList(DepartmentID, _userId);
        }

        private void departmentInformationModal_KeyPress(object sender, KeyPressEventArgs e)
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
