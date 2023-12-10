using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls
{
    public partial class analyticsButtonModal : Form
    {
        #region Public Getters and Setters
        private static int _userId;
        private static departmentCardUC _parent;
        private static readonly string employeeImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly personnelDashboard personnel = new personnelDashboard();
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public string UserRole { get; set; }
        public string SchoolName { get; set; }
        public string DateHired { get; set; }
        public string ContactNumber { get; set; }
        public string JobDescription { get; set; }
        public string DepartmentLogo { get; set; }

        #endregion

        public analyticsButtonModal(int userId, departmentCardUC parent)
        {
            InitializeComponent();
            this.KeyPreview = true;
            _userId = userId;
            _parent = parent;
        }

        #region Functions for retrieving values from Personnel Class

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Functions under this is used for the functionality of the UI

        private async Task EmployeeList(int departmentId)
        {
            try
            {
                DataTable EmployeeTable = await GetEmployeeList(departmentId);

                if (EmployeeTable != null && EmployeeTable.Rows.Count > 0)
                {
                    employeeUC[] employee = new employeeUC[EmployeeTable.Rows.Count];
                    for (int i = 0; i < EmployeeTable.Rows.Count; i++)
                    {
                        DataRow row = EmployeeTable.Rows[i];
                        employee[i] = new employeeUC(_userId, this);

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
                MessageBox.Show(text: ex.Message, caption:@"Inside Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

        #region Functions below is used for the behaviour of UI the event handlers

        private async void analyticsButtonModal_Load(object sender, EventArgs e)
        {
            DataBinding();
            await EmployeeList(DepartmentID);
        }

        private void analyticsButtonModal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Escape key
            if (e.KeyChar == (char)27) // 27 is the ASCII code for the Escape key
            {
                // Close the form
                this.Close();
            }
        }

        #endregion
    }
}
