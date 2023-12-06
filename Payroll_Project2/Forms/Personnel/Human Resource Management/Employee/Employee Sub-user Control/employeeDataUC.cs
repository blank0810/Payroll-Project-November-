using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Employee.Modal;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control
{
    public partial class employeeDataUC : UserControl
    {
        private static int userId;
        private static employeeUserControl _parent;
        employeeClass employeeClass = new employeeClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static readonly string defaultImage = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string employeeSignaturePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeSignaturePath");

        public string employeeName { get; set; }
        public int employeeId { get; set; }
        public string employeeStatus { get; set; }
        public string employeeDepartment { get; set; }
        public string jobDescription { get; set; }
        public string employeeImage { get; set; }


        public employeeDataUC(employeeUserControl parent, int id)
        {
            InitializeComponent();
            _parent = parent;
            userId = id;
        }

        // Function responsible for retrieving the Employee Details
        private async Task<DataTable> GetEmployeeDetails(int employeeId)
        {
            try
            {
                DataTable employeeDataTable = await generalFunctions.GetEmployeeDetails(employeeId);

                if (employeeDataTable != null && employeeDataTable.Rows.Count > 0)
                {
                    return employeeDataTable;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for formatting text input
        private string FormatAsSentenceCase(string input)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input);
        }

        // Custom function responsible for binding values into the User Interface Controls
        private void DataBinding()
        {
            empName.DataBindings.Add("Text", this, "employeeName");
            empid.DataBindings.Add("Text", this, "employeeId");
            empStatus.DataBindings.Add("Text", this, "employeeStatus");
            departmentLabel.DataBindings.Add("Text", this, "employeeDepartment");
            jobDesc.DataBindings.Add("Text", this, "jobDescription");
            empPicture.DataBindings.Add("ImageLocation", this, "employeeImage");
        }

        // Function responsible for forwarding the Employee Details
        public async Task EmployeeDetails(int employeeId)
        {
            #region Function in assigning the employee details
            try
            {
                DataTable employeeDataTable = await GetEmployeeDetails(employeeId);

                if (employeeDataTable != null & employeeDataTable.Rows.Count == 1)
                {
                    employeeDetailsUserControl employeeDetails = new employeeDetailsUserControl(userId, this);

                    foreach (DataRow row in employeeDataTable.Rows)
                    {
                        if (row["employeeid"] != null)
                        {
                            employeeDetails.EmployeeId = (int)row["employeeid"];
                        }
                        else
                        {
                            employeeDetails.EmployeeId = 0;
                        }

                        if (row["employeefname"] != null)
                        {
                            employeeDetails.EmployeeFname = FormatAsSentenceCase(row["employeefname"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeFname = "Not Set";
                        }

                        if (row["employeelname"] != null)
                        {
                            employeeDetails.EmployeeLname = FormatAsSentenceCase(row["employeelname"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeLname = "Not Set";
                        }

                        if (row["employeemname"] != null)
                        {
                            employeeDetails.EmployeeMname = FormatAsSentenceCase(row["employeemname"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeMname = "Not Set";
                        }

                        if (row["employeejobdesc"] != null)
                        {
                            employeeDetails.EmployeeJobDescription = FormatAsSentenceCase(row["employeejobdesc"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeJobDescription = "Not Set";
                        }

                        if (row["employeecontactnumber"] != null)
                        {
                            employeeDetails.ContactNumber = row["employeecontactnumber"].ToString();
                        }
                        else
                        {
                            employeeDetails.ContactNumber = "Not Set";
                        }

                        if (row["employeesex"] != null)
                        {
                            employeeDetails.Sex = FormatAsSentenceCase(row["employeesex"].ToString());
                        }
                        else
                        {
                            employeeDetails.Sex = "Not Set";
                        }

                        if (row["employeecivilstatus"] != null)
                        {
                            employeeDetails.CivilStatus = FormatAsSentenceCase(row["employeecivilstatus"].ToString());
                        }
                        else
                        {
                            employeeDetails.CivilStatus = "Not Set";
                        }

                        if (row["nationality"] != null)
                        {
                            employeeDetails.Nationality = FormatAsSentenceCase(row["nationality"].ToString());
                        }
                        else
                        {
                            employeeDetails.Nationality = "Not Set";
                        }

                        if (row["employeebirth"] != null && DateTime.TryParse(row["employeeBirth"].ToString(), out DateTime birth))
                        {
                            employeeDetails.Birthday = birth.ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            employeeDetails.Birthday = "Not Set";
                        }

                        if (row["employeeemailaddress"] != null)
                        {
                            employeeDetails.EmailAddress = row["employeeemailaddress"].ToString();
                        }
                        else
                        {
                            employeeDetails.EmailAddress = "Not Set";
                        }

                        if (row["barangay"] != null)
                        {
                            employeeDetails.EmployeeBarangay = FormatAsSentenceCase(row["barangay"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeBarangay = "Not Set";
                        }

                        if (row["municipality"] != null)
                        {
                            employeeDetails.EmployeeMunicipality = FormatAsSentenceCase(row["municipality"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeMunicipality = "Not Set";
                        }

                        if (row["province"] != null)
                        {
                            employeeDetails.EmployeeProvince = FormatAsSentenceCase(row["province"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeProvince = "Not Set";
                        }

                        if (row["zipCode"] != null)
                        {
                            employeeDetails.EmployeeZipCode = row["zipCode"].ToString();
                        }
                        else
                        {
                            employeeDetails.EmployeeZipCode = "Not Set";
                        }

                        if (row["educationalattainment"] != null)
                        {
                            employeeDetails.EducationalAttainment = FormatAsSentenceCase(row["educationalattainment"].ToString());
                        }
                        else
                        {
                            employeeDetails.EducationalAttainment = "Not Set";
                        }

                        if (row["course"] != null)
                        {
                            employeeDetails.Course = FormatAsSentenceCase(row["course"].ToString());
                        }
                        else
                        {
                            employeeDetails.Course = "Not Set";
                        }

                        if (row["nameofschool"] != null)
                        {
                            employeeDetails.SchoolName = FormatAsSentenceCase(row["nameofschool"].ToString());
                        }
                        else
                        {
                            employeeDetails.SchoolName = "Not Set";
                        }

                        if (row["schooladdress"] != null)
                        {
                            employeeDetails.SchoolAddress = FormatAsSentenceCase(row["schooladdress"].ToString());
                        }
                        else
                        {
                            employeeDetails.SchoolAddress = "Not Set";
                        }

                        if (row["datehired"] != null && DateTime.TryParse(row["datehired"].ToString(), out DateTime dateHired))
                        {
                            employeeDetails.EmployeeDateHired = dateHired.ToString("MMMM/dd/yyyy");
                        }
                        else
                        {
                            employeeDetails.EmployeeDateHired = "Not Set";
                        }

                        if (row["employmentstatus"] != null)
                        {
                            employeeDetails.EmployeeEmploymentStatus = FormatAsSentenceCase(row["employmentstatus"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeEmploymentStatus = "Not Set";
                        }

                        if (row["dateretired"] != null && DateTime.TryParse(row["dateretired"].ToString(), out DateTime dateRetired))
                        {
                            employeeDetails.EmployeeDateRetired = dateRetired.ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            employeeDetails.EmployeeDateRetired = "Not Set";
                        }

                        if (row["departmentname"] != null)
                        {
                            employeeDetails.EmployeeDepartmentName = FormatAsSentenceCase(row["departmentname"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeDepartmentName = "Not Set";
                        }

                        if (row["rolename"] != null)
                        {
                            employeeDetails.EmployeeUserRole = FormatAsSentenceCase(row["rolename"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeUserRole = "Not Set";
                        }

                        if (row["isActive"] != null && bool.TryParse(row["isActive"].ToString(), out bool isActive))
                        {
                            if (isActive)
                            {
                                employeeDetails.EmployeeAccountStatus = FormatAsSentenceCase("Active");
                            }
                            else
                            {
                                employeeDetails.EmployeeAccountStatus = FormatAsSentenceCase("Inactive");
                            }
                        }
                        else
                        {
                            employeeDetails.EmployeeAccountStatus = "Not Set";
                        }

                        if (row["employeepicture"] != null)
                        {
                            employeeDetails.EmployeeImage = $"{employeeImagePath}{row["employeepicture"]}";
                        }
                        else
                        {
                            employeeDetails.EmployeeImage = defaultImage;
                        }

                        if (row["salaryRateDescription"] != null)
                        {
                            employeeDetails.EmployeeSalaryRate = FormatAsSentenceCase(row["salaryRateDescription"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeSalaryRate = "Not Set";
                        }

                        if (row["amount"] != null && row["salaryRateSchedule"] != null)
                        {
                            decimal amount = decimal.Parse(row["amount"].ToString());
                            employeeDetails.EmployeeSalaryValue = $"{amount:C2}";
                        }
                        else
                        {
                            employeeDetails.EmployeeSalaryValue = "";
                        }

                        if (row["salaryRateSchedule"] != null)
                        {
                            employeeDetails.EmployeeSalarySchedule = FormatAsSentenceCase(row["salaryRateSchedule"].ToString());
                        }
                        else
                        {
                            employeeDetails.EmployeeSalarySchedule = "Not Set";
                        }

                        if (row["employeesignature"] != null)
                        {
                            employeeDetails.EmployeeSignature = $"{employeeSignaturePath}{row["employeesignature"]}";
                        }
                        else
                        {
                            employeeDetails.EmployeeSignature = ConfigurationManager.AppSettings["DefaultLogo"];
                        }

                    }
                    Panel parentPanel = _parent.Controls["content"] as Panel;
                    parentPanel.Controls.Clear();
                    parentPanel.Controls.Add(employeeDetails);
                    employeeDetails.Dock = DockStyle.Fill;
                    _parent.UserControlBehaviour();
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: @"SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        // Function responsible for forwarding the employee details into the modification form
        public async Task EmployeeModifyDetails (int employeeId)
        {
            try
            {
                DataTable employeeDetails = await GetEmployeeDetails(employeeId);

                if (employeeDetails != null) 
                {
                    modificationEmployeeForm modifyEmployee = new modificationEmployeeForm(userId, this, employeeId);

                    foreach (DataRow row in employeeDetails.Rows)
                    {
                        modifyEmployee.FirstName = FormatAsSentenceCase(row["employeefname"].ToString());
                        modifyEmployee.LastName = FormatAsSentenceCase(row["employeelname"].ToString());
                        modifyEmployee.MiddleName = FormatAsSentenceCase(row["employeemname"].ToString());
                        modifyEmployee.Birthday = Convert.ToDateTime(row["employeeBirth"]);
                        modifyEmployee.Barangay = FormatAsSentenceCase(row["barangay"].ToString());
                        modifyEmployee.Municipality = FormatAsSentenceCase(row["municipality"].ToString());
                        modifyEmployee.Province = FormatAsSentenceCase(row["province"].ToString());
                        modifyEmployee.ZipCode = row["zipCode"].ToString();
                        modifyEmployee.Nationality = FormatAsSentenceCase(row["nationality"].ToString());
                        modifyEmployee.CivilStatus = FormatAsSentenceCase(row["employeecivilstatus"].ToString());
                        modifyEmployee.Sex = FormatAsSentenceCase(row["employeeSex"].ToString());
                        modifyEmployee.PhoneNumber = row["employeecontactnumber"].ToString();
                        modifyEmployee.EmailAddress = row["employeeemailaddress"].ToString();
                        modifyEmployee.EducationalAttainment = FormatAsSentenceCase(row["educationalattainment"].ToString());
                        modifyEmployee.SchoolAddress = FormatAsSentenceCase(row["schooladdress"].ToString());
                        modifyEmployee.Schoolname = FormatAsSentenceCase(row["nameofschool"].ToString());
                        modifyEmployee.Course = FormatAsSentenceCase(row["course"].ToString());
                        modifyEmployee.Department = FormatAsSentenceCase(row["departmentname"].ToString());
                        modifyEmployee.JobDescription = FormatAsSentenceCase(row["employeejobdesc"].ToString());
                        modifyEmployee.UserRole = FormatAsSentenceCase(row["rolename"].ToString());
                        modifyEmployee.EmployeeImage = row["employeePicture"].ToString();
                        modifyEmployee.EmployeeSignature = row["employeeSignature"].ToString();
                        modifyEmployee.EmployeeID = employeeId;
                        modifyEmployee.EmploymentStatus = FormatAsSentenceCase(row["employmentStatus"].ToString());
                        modifyEmployee.SalaryRate = FormatAsSentenceCase(row["salaryRateDescription"].ToString());
                        modifyEmployee.SalarySchedule = FormatAsSentenceCase(row["payrollScheduleDescription"].ToString());

                        if (row["dateRetired"] != null && DateTime.TryParse(row["dateRetired"].ToString(), out DateTime retired))
                        {
                            modifyEmployee.DateRetired = retired;
                        }
                        else
                        {
                            modifyEmployee.DateRetired = DateTime.Today;
                        }

                        if (row["dateHired"] != null && DateTime.TryParse(row["dateHired"].ToString(), out DateTime hired))
                        {
                            modifyEmployee.DateHired = hired;
                        }
                        else
                        {
                            modifyEmployee.DateHired = DateTime.Today;
                        }
                    }

                    modifyEmployee.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error in retrieving the Employee Details");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: @"SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption:@"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event Handler that handles if the details button is clicked
        private async void detailsBtn_Click(object sender, EventArgs e)
        {
            await EmployeeDetails(employeeId);
        }

        // Event Handler that handles if the employee user control is loaded into the system
        private void employeeDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event Handler that handles if the modify button is clicked
        private async void modifyBtn_Click(object sender, EventArgs e)
        {
            await EmployeeModifyDetails(employeeId);
            await _parent.DisplayEmployee();
        }
    }
}
