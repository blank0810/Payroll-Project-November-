using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Employee.Modal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal
{
    public partial class addEmployeeModal : Form
    {
        #region Private and Public Variables

        private static int _userId;
        private static employeeUserControl _parent;
        private static readonly string MorningShift = "8:00 AM - 12:00 PM";
        private static readonly string AfternoonShift = "1:00 PM - 5:00 PM";
        private static int numberOfMonth = DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1;
        private static string defaultHours = ConfigurationManager.AppSettings["DefaultSlipHours"];
        private static int _year = DateTime.Now.Year;
        private static int _month = DateTime.Now.Month;
        private generalFunctions generalFunctions = new generalFunctions();
        private employeeClass employeeClass = new employeeClass();

        private static decimal minimumBenefitValue = 0; 
        
        // This status indicates for the default status of benefits when added into the employee
        private static string status = "Active";

        // This is a static string variable in which the default account status of a new employee is Active
        private static bool accountStatus = false;

        private static string employeeImageDestination = ConfigurationManager.AppSettings["DestinationEmployeeImagePath"];

        private static string employeeSignatureDestination = ConfigurationManager.AppSettings["DestinationEmployeeSignaturePath"];

        // String value that will hold the value for the location of employee Image
        private static string employeeImageLocation;

        // String value that will hold the value for the location of employee Signature
        private static string employeeSignatureLocation;

        // The variables below serve as the storage of every data the user will input into the form
        public int EmployeeID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string MiddleName { get; set; }
        private DateTime Birthday { get; set; }
        private string Nationality { get; set; }
        private string Barangay { get; set; }
        private string Municipality { get; set; }
        private string Province { get; set; }
        private string ZipCode { get; set; }
        private string CivilStatus { get; set; }
        private string Sex { get; set; }
        private string ContactNumber { get; set; }
        private string EmailAddress { get; set; }
        private string EducationalAttainment { get; set; }
        private string SchoolAddress { get; set; }
        private string SchoolName { get; set; }
        private string Course { get; set; }
        private string DepartmentName { get; set; }
        private string JobDescription { get; set; }
        private string EmploymentStatus { get; set; }
        private string UserRole { get; set; }
        private string SalaryRate { get; set; }
        private int SalaryRateValue { get; set; }
        private string SalarySchedule { get; set; }
        public DateTime DateHired { get; set; }
        private DateTime? DateRetired { get; set; }
        private string EmployeePicture { get; set; }
        private string EmployeeSignature { get; set; }

        private static readonly List<(string, decimal)> benefitList = new List<(string, decimal)>();

        #endregion
        
        public addEmployeeModal(int userId, employeeUserControl parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        #region Custom functions responsible for responsiveness of the Form

        // Function for binding and populating some combo boxes and controls
        private async Task DataBinding()
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                DataTable departmentTable = await generalFunctions.GetDepartmentList();
                DataTable employmentStatusTable = await generalFunctions.GetEmploymentStatus();
                DataTable salaryRateDescription = await employeeClass.GetSalaryRate();
                DataTable educationalAttainmentTable = await employeeClass.GetEducationalAttainment();
                DataTable scheduleDescription = await employeeClass.GetScheduleDescription();

                civilStatus.AutoCompleteMode = AutoCompleteMode.Suggest;

                departmentName.AutoCompleteMode = AutoCompleteMode.Suggest;
                departmentName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                AutoCompleteStringCollection salaryRateCollection = new AutoCompleteStringCollection();
                AutoCompleteStringCollection autoCompleteValues = new AutoCompleteStringCollection();

                List<string> employmentStatusList = new List<string>();
                List<string> educationalAttainmentList = new List<string>();
                List<string> scheduleDescriptionList = new List<string>();

                foreach (DataRow row in salaryRateDescription.Rows)
                {
                    salaryRateCollection.Add(row["salaryratedescription"].ToString().ToUpper());
                }
                salaryRateCollection.Add("Custom");

                foreach (DataRow row in departmentTable.Rows)
                {
                    collection.Add(row["departmentName"].ToString().ToUpper());
                }

                foreach (DataRow row in employmentStatusTable.Rows)
                {
                    string statusItem = row["employmentstatus"].ToString().ToUpper();
                    employmentStatusList.Add(statusItem);
                }

                foreach (DataRow row in educationalAttainmentTable.Rows)
                {
                    string educationalItems = row["educationalattainment"].ToString().ToUpper();
                    educationalAttainmentList.Add(educationalItems);
                }

                foreach (DataRow row in scheduleDescription.Rows)
                {
                    string scheduleItems = row["payrollscheduledescription"].ToString().ToUpper();
                    scheduleDescriptionList.Add(scheduleItems);
                }

                departmentName.DataSource = collection;
                salaryRate.DataSource = salaryRateCollection;
                employmentStatus.DataSource = employmentStatusList;
                educationalAttainment.DataSource = educationalAttainmentList;
                scheduleBox.DataSource = scheduleDescriptionList;

                departmentName.AutoCompleteCustomSource = collection;

                employmentStatus.SelectedIndex = -1;
                departmentName.SelectedIndex = -1;
                salaryRate.SelectedIndex = salaryRate.SelectionLength - 1;
                educationalAttainment.SelectedIndex = -1;
                scheduleBox.SelectedIndex = -1;
                benefitName.SelectedIndex = -1;
                employeeID.DataBindings.Add("Text", this, "EmployeeID");
                morningShiftLabel.Text = MorningShift;
                afternoonShiftLabel.Text = AfternoonShift;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: @"Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function responsible for computing the total value of mandated benefit if its percentage
        private decimal ComputeTotalValue(int totalPercentage, int salaryRate)
        {
            try
            {
                decimal totalValue = (totalPercentage * salaryRate) / 100;
                return totalValue;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for displaying the mandated benefits
        private async Task ForwardMandatedValue(string employmentStatus)
        {
            try
            {
                mandatedPanel.Controls.Clear();
                DataTable benefits = await GetMandated(employmentStatus);

                if (benefits != null && benefits.Rows.Count > 0)
                {
                    mandateDeductionsUC[] mandated = new mandateDeductionsUC[benefits.Rows.Count];
                    for (int i = 0; i < benefits.Rows.Count; i++)
                    {
                        DataRow row = benefits.Rows[i];
                        mandated[i] = new mandateDeductionsUC();

                        if ((bool)row["isPercentage"])
                        {
                            decimal totalValue = ComputeTotalValue(int.Parse(row["value"].ToString()), SalaryRateValue);

                            mandated[i].BenefitName = row["benefits"].ToString();
                            mandated[i].EmployeeShare = $"{row["personalShareValue"]} %";
                            mandated[i].EmployerShare = $"{row["employerShareValue"]} %";
                            mandated[i].TotalValue = $"${totalValue}";

                            mandatedPanel.Controls.Add(mandated[i]);
                            benefitList.Add((row["benefits"].ToString(), totalValue));
                        }
                        else
                        {
                            mandated[i].BenefitName = row["benefits"].ToString();
                            mandated[i].EmployeeShare = $"${row["personalShareValue"]}";
                            mandated[i].EmployerShare = $"${row["employerShareValue"]}";
                            mandated[i].TotalValue = $"${row["value"]}";

                            mandatedPanel.Controls.Add(mandated[i]);
                            benefitList.Add((row["benefits"].ToString(), Convert.ToDecimal(row["value"])));
                        }
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

        // Function for populating user role depending to the chosen employment
        private async Task PopulateUserRole(string employmentStatus)
        {
            try
            {
                DataTable role = await GetUserRole(employmentStatus);
                List<string> roleList = new List<string>();

                if (role != null && role.Rows.Count > 0)
                {
                    foreach (DataRow row in role.Rows)
                    {
                        roleList.Add(row["roleName"].ToString());
                    }

                    userRole.DataSource = roleList;
                    userRole.SelectedIndex = -1;
                }
                else
                {
                    roleList.Add("No Choices available");
                    userRole.DataSource = roleList;
                    userRole.SelectedIndex = 0;
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

        // Function use to populate benefit list
        private async Task<List<string>> PopulateBenefitList(string employmentStatus)
        {
            try
            {
                DataTable benefits = await GetBenefitList(employmentStatus);
                List<string> items = new List<string>();

               if (benefits != null && benefits.Rows.Count > 0)
                {
                    foreach (DataRow row in benefits.Rows)
                    {
                        items.Add(row["benefits"].ToString());
                    }
                    return items;
                }
               else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } 
            catch (Exception ex) { throw ex; }
        }

        // Function that makes that set the date retired of an employment aside from a regular
        private async Task<DateTime?> SetDateRetired(string employmentStatus)
        {
            try
            {
                DataTable numbers = await GetContractLength(employmentStatus);

                if (numbers != null)
                {
                    foreach (DataRow row in numbers.Rows)
                    {
                        if (row["numberOfYears"] != null && int.TryParse(row["numberOfYears"].ToString(), out int years))
                        {
                            return DateHired.AddYears(years);
                        }
                        else if (row["numberOfMonths"] != null && int.TryParse(row["numberOfMonths"].ToString(), out int months))
                        {
                            return DateHired.AddMonths(months);
                        }
                        else if ((row["numberOfYears"] != null && row["numberOfMonths"] != null) && int.TryParse(row["numberOfYears"].ToString(),
                            out int numberOfYears) && int.TryParse(row["numberOfMonths"].ToString(), out int numberOfMonths))
                        {
                            DateTime newDate = DateHired.AddYears(numberOfYears);
                            newDate = newDate.AddMonths(numberOfMonths);
                            return newDate;
                        }
                    }
                    ErrorMessages("There is no record of how many years/months will the contract last. " +
                                "Please contact the system administrators for resolution. Just add the employee as of now the contract length" +
                                " will be updated on the later date and will notify the Employee.", "Contract Error");
                    return null;
                }
                else
                {
                    ErrorMessages("There is no record of how many years/months will the contract last. " +
                                "Please contact the system administrators for resolution. Just add the employee as of now the contract length" +
                                " will be updated on the later date and will notify the Employee.", "Contract Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Functions inside serves to communicate with the Employee Class

        // Function responsible for retrieving the contract length of an employment aside from a regular
        private async Task<DataTable> GetContractLength(string employmentStatus)
        {
            try
            {
                DataTable numbers = await employeeClass.GetContractLength(employmentStatus);

                if (numbers != null && numbers.Rows.Count > 0)
                {
                    return numbers;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        //Function in retrieving the User Role
        private async Task<DataTable> GetUserRole(string employmentStatus)
        {
            try
            {
                DataTable userRoleTable = await employeeClass.GetUserRoles(employmentStatus);

                if (userRoleTable != null && userRoleTable.Rows.Count > 0)
                {
                    return userRoleTable;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function serves as verification on the actions done in this form its purpose is to verify if the said user is allowed to this actions or not
        private async Task<string> GetValidation(int userid)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool validation = await generalFunctions.GetValidation(userid);

                if (validation)
                {
                    return "Personnel";
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function return the count of every custom salary rate from the database this will be used if the new employee
        // salary rate is not in the choices then it will retrieve the count of custom made salary rate in the database and increment into 1
        private async Task<int> GetCustomCount(string description)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                int customCount = await employeeClass.GetCustomSalaryCount(description);

                if (customCount == 0)
                {
                    return customCount;
                }
                else
                {
                    return customCount;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function return the value of the salary rate chosen by the user in the combo box such as the value of a
        // Salary Grade 1
        private async Task<int> GetValue(string description)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                int values = await employeeClass.GetSalaryRateValue(description);

                if (values > 0)
                {
                    return values;
                }
                else
                {
                    return values;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function return some details based on the userId parameter for the system logs and employee logs
        private async Task<string> UserDetails(int userId)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                DataTable userDetails = await generalFunctions.GetUserDetails(userId);

                if (userDetails != null)
                {
                    foreach (DataRow row in userDetails.Rows)
                    {
                        string name = row["employeefname"].ToString() + " " + row["employeelname"];
                        string formattedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());

                        return formattedName;
                    }
                }
                else
                {
                    return null;
                }

                return null;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as adding a custom salary rate if the salary rate is custom before adding the new employee
        // It will return true if the salary rate is being added or false is not
        private async Task<bool> AddSalaryRate(string description, int value)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addSalaryRate = await employeeClass.AddSalaryRate(description, value);

                if (addSalaryRate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for adding new employee into the database
        // It will return true if it added or false if its not
        private async Task<bool> AddEmployee(string password, string employeePicture, string employeeSignature)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addEmployee = await employeeClass.AddEmployee(password, accountStatus, FirstName, LastName, MiddleName, Birthday, 
                    CivilStatus, Sex, ContactNumber, EmailAddress, EducationalAttainment, SchoolName, Course, SchoolAddress, DepartmentName, 
                    JobDescription, UserRole, employeePicture, employeeSignature, Nationality, Barangay, Municipality, Province, ZipCode);

                if (addEmployee)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for creating new appointment form for the new employee
        // It will return true if the form is created false if not
        private async Task<bool> AddAppointmentForm(int employeeId, string salaryRate, DateTime date, DateTime dateHired, DateTime? dateRetired, 
            string schedule, string employmentStatus, string morningShift, string afternoonShift)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addAppointmentForm = await employeeClass.AddAppointmentForm(employeeId, salaryRate, date, dateHired, dateRetired, schedule, 
                    employmentStatus, morningShift, afternoonShift);

                if (addAppointmentForm)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function responsible for adding a time log into the employee DTR indicating that the employee is hired on that date
        private async Task<bool> AddHiredLog(int employeeId, DateTime dateLog, string status)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool add = await employeeClass.InsertNewLog(employeeId, dateLog, status);
                return add;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> CheckEmployeeBenefitExist(int id, string benefitName)
        {
            #region This function when called is use to check if the benefit that will be addded does exist on the employee appointment form or not
            // If the benefit exist then the function will notify the personnel that this benefit is already exist on employee appointment form

            try
            {
                employeeClass employeeClass = new employeeClass();
                DataTable employeeBenefitList = await generalFunctions.GetEmployeeBenefits(id);

                if (employeeBenefitList != null)
                {
                    foreach (DataRow row in employeeBenefitList.Rows)
                    {
                        if (row["benefits"].ToString().ToUpper() == benefitName)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

        private async Task<DataTable> GetBenefitList(string employmentStatus)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                DataTable benefitTable = await employeeClass.GetBenefitList(employmentStatus);
                
                if (benefitTable != null && benefitTable.Rows.Count > 0)
                {
                    return benefitTable;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<DataTable> GetMandated(string employmentStatus)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                DataTable benefitTable = await employeeClass.GetMandatedBenefit(employmentStatus);

                if (benefitTable != null && benefitTable.Rows.Count > 0)
                {
                    return benefitTable;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> AddBenefit(int id, string benefitName, decimal benefitValue, string benefitStatus)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addBenefit = await employeeClass.AddEmployeeBenefit(id, benefitName, benefitValue, benefitStatus);

                if (addBenefit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for leaving a record or logs for every actions done in the system
        // Purpose for this if there is necesarry review that must be done they can see it into the logs
        private async Task<bool> AddSystemLogs(DateTime date, string description, string caption)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addSystemLog = await generalFunctions.AddSystemLogs(date, description, caption);

                if (addSystemLog)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is same as system logs but this function is can be view by the specific employee only
        // Same purpose for the system logs
        private async Task<bool> AddEmployeeLogs(int employeeId, DateTime date, string description, string caption)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addEmployeeLog = await employeeClass.AddEmployeeDataLog(employeeId, date, description, caption);

                if (addEmployeeLog)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the benefit value if there is minimum value of it
        private async Task<DataTable> GetBenefitValue(string benefitName)
        {
            try
            {
                DataTable value = await employeeClass.GetValue(benefitName);

                if (value != null && value.Rows.Count > 0)
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for getting the default leave credits
        private async Task<DataTable> GetLeaveCredits()
        {
            try
            {
                DataTable leaveCredits = await employeeClass.GetLeaveCredits();

                if (leaveCredits != null)
                {
                    return leaveCredits;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for adding the employee's leave credits
        private async Task<bool> AddLeaveCredits(int employeeId, string leaveType, float numberOfCredits, int year)
        {
            try
            {
                bool addLeaveCredits = await employeeClass.AddEmployeeLeaveCredits(employeeId, leaveType, numberOfCredits, year);

                return addLeaveCredits;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for adding the employee's pass slip hours would serve as an automatic allocation for pass slip hours
        private async Task<bool> AddSlipHours(int employeeId, int year, int month, TimeSpan hours)
        {
            try
            {
                bool addSlip = await employeeClass.AddEmployeeSlipHours(employeeId, month, year, hours);
                return addSlip;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Functions inside are responsible for Authorization before proceeding  to each steps

        private bool AuthorizedAccountPanel()
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Texts) || string.IsNullOrWhiteSpace(lastNameTextBox.Texts) || string.IsNullOrWhiteSpace(middleNameTextBox.Texts))
            {
                ErrorMessages("Kindly ensure that you furnish the comprehensive particulars of the employee's name. " +
                    "Your attention to supplying complete information is greatly appreciated. Thank you.",
                    "Employee Name: Incomplete Information");
                return false;
            }
            else if (employeeImage.Image == null || signatureImage.Image == null)
            {
                ErrorMessages("Please ensure that you upload both the employee's image and signature. Your attention to fulfilling these " +
                    "requirements is greatly appreciated. Thank you.", "Image and Signature Upload: Incomplete Information");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool AuthorizedEmploymentPanel()
        {
            if (string.IsNullOrWhiteSpace(departmentName.Text) || departmentName.SelectedIndex <= -1)
            {
                ErrorMessages("Please provide the designated department for the Employee", "Employee Department Assigned");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(jobDescriptionBox.Texts))
            {
                ErrorMessages("Please provide the Employee's Job Description", "Employee Job Description");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(employmentStatus.Text) || employmentStatus.SelectedIndex <= -1)
            {
                ErrorMessages("Please choose one for the Employment Status", "Employment Status Selection");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(employmentStatus.Text) && userRole.SelectedIndex == -1)
            {
                ErrorMessages("Please choose one of the access level choices", "Access Level Information");
                return false;
            }
            else if (employmentStatus.Text.ToUpper() != "REGULAR" && dateRetired.Value.Date == DateTime.Today)
            {
                ErrorMessages("Please provide the number of years stated in Contract", "Incomplete Contract Information");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(salaryRate.Text) || salaryRate.SelectedIndex <= -1)
            {
                ErrorMessages("Please choose for the Employee Salary rate or create one", "Salary Rate Selection");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(salaryRateValueTextBox.Texts) && salaryRate.Text.ToUpper().Contains("CUSTOM"))
            {
                ErrorMessages("We apologize for the inconvenience there is an error in assigning the Salary Value. Please review the details" +
                    " or Contact System Administrator for assistance", "Salary Rate Value Error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(scheduleBox.Text) || scheduleBox.SelectedIndex <= -1)
            {
                ErrorMessages("Choose one for the Employee Payroll Schedule", "Employee Payroll Schedule");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool AuthorizedPersonalPanel()
        {
            if (!string.IsNullOrWhiteSpace(birthdayError.GetError(dateOfBirthPicker)))
            {
                ErrorMessages("The age of the employee does not meet the company's policy requirements. Please ensure that the employee's age qualifies as per the policy.", "Age Requirement Not Met");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(sex.Text) || sex.SelectedIndex <= -1)
            {
                ErrorMessages("Please ensure you select the appropriate gender for the employee.", "Gender Selection Required");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(nationalityBox.Texts))
            {
                ErrorMessages("Please input the employee's nationality. This information is required for proper record keeping.", "Nationality Information Missing");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(civilStatus.Text) || civilStatus.SelectedIndex <= -1)
            {
                ErrorMessages("Please choose the civil status of the employee. This information is important for accurate record keeping.", "Civil Status Selection Required");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(contactNumberBox.Texts) || !string.IsNullOrWhiteSpace(mobileNumberError.GetError(contactNumberBox)))
            {
                ErrorMessages("Please provide the contact number of the employee. This information is necessary for communication purposes and record keeping.", "Contact Number Required");
                return false;

            }
            else if (!string.IsNullOrWhiteSpace(emailAddressBox.Texts) && !ValidateEmail(emailAddressBox.Texts))
            {
                ErrorMessages("Please provide a valid email address. This information is necessary for communication " +
                    "purposes and record keeping.", "Valid Email Address");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(barangayError.GetError(barangayBox)) ||
                !string.IsNullOrWhiteSpace(municipalityError.GetError(municipalityBox)) ||
                !string.IsNullOrWhiteSpace(provinceError.GetError(provinceBox)) || string.IsNullOrWhiteSpace(zipCode.Texts))
            {
                ErrorMessages("Please ensure that all required information related to the employee's address is provided. Complete address details are essential for accurate records.", "Incomplete Address Information");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool AuthorizedEducationPanel()
        {
            if (string.IsNullOrWhiteSpace(educationalAttainment.Text) || educationalAttainment.SelectedIndex <= -1)
            {
                ErrorMessages("Kindly ensure you select the highest educational attainment", "Employee Educational Attainment");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(schoolAddressBox.Texts))
            {
                ErrorMessages("Kindly provide the School Address", "School Address Input");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(schoolName.Texts))
            {
                ErrorMessages("Kindly Provide the School Name", "School Name Input");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(courseBox.Texts))
            {
                ErrorMessages("Please ensure to provide also the Course / Strand of the Employee's Education", "Employee's Course / Strand Input");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool AuthorizedBenefitPanel()
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to proceed with employee creation?", "Employee Creation Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Functions and Event Handler inside is responsible for the User Interface to be responsive

        private void DisplayAccountPanel()
        {
            accountBtn.BackColor = Color.DodgerBlue;
            accountBtn.TextColor = Color.White;
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            educationBtn.BackColor = Color.White;
            educationBtn.TextColor = Color.DodgerBlue;
            personalBtn.BackColor = Color.White;
            personalBtn.TextColor = Color.DodgerBlue;
            benefitsBtn.BackColor = Color.White;
            benefitsBtn.TextColor = Color.DodgerBlue;

            employmentPanel.Visible = false;
            personalPanel.Visible = false;
            educationPanel.Visible = false;
            benefitPanel.Visible = false;
            accountPanel.Visible = true;

            accountPanel.BringToFront();
            previousBtn.Visible = false;
            nextBtn.Visible = true;
            submitBtn.Visible = false;
        }

        private void DisplayEmploymentPanel()
        {
            employmentBtn.BackColor = Color.DodgerBlue;
            employmentBtn.TextColor = Color.White;
            accountBtn.TextColor = Color.DodgerBlue;
            accountBtn.BackColor = Color.White;
            personalBtn.BackColor = Color.White;
            personalBtn.TextColor = Color.DodgerBlue;
            educationBtn.BackColor = Color.White;
            educationBtn.TextColor = Color.DodgerBlue;
            benefitsBtn.BackColor = Color.White;
            benefitsBtn.TextColor = Color.DodgerBlue;

            employmentPanel.Visible = true;
            accountPanel.Visible = false;
            educationPanel.Visible = false;
            benefitPanel.Visible = false;
            personalPanel.Visible = false;

            employmentPanel.BringToFront();
            previousBtn.Visible = true;
            nextBtn.Visible = true;
            submitBtn.Visible = false;
        }

        private void DisplayPersonalPanel()
        {
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            accountBtn.TextColor = Color.DodgerBlue;
            accountBtn.BackColor = Color.White;
            personalBtn.BackColor = Color.DodgerBlue;
            personalBtn.TextColor = Color.White;
            educationBtn.BackColor = Color.White;
            educationBtn.TextColor = Color.DodgerBlue;
            benefitsBtn.BackColor = Color.White;
            benefitsBtn.TextColor = Color.DodgerBlue;

            employmentPanel.Visible = false;
            accountPanel.Visible = false;
            educationPanel.Visible = false;
            benefitPanel.Visible = false;
            personalPanel.Visible = true;

            personalPanel.BringToFront();
            previousBtn.Visible = true;
            nextBtn.Visible = true;
            submitBtn.Visible = false;
        }

        private void DisplayEducationPanel()
        {
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            accountBtn.TextColor = Color.DodgerBlue;
            accountBtn.BackColor = Color.White;
            personalBtn.BackColor = Color.White;
            personalBtn.TextColor = Color.DodgerBlue;
            educationBtn.BackColor = Color.DodgerBlue;
            educationBtn.TextColor = Color.White;
            benefitsBtn.BackColor = Color.White;
            benefitsBtn.TextColor = Color.DodgerBlue;

            employmentPanel.Visible = false;
            accountPanel.Visible = false;
            educationPanel.Visible = true;
            benefitPanel.Visible = false;
            personalPanel.Visible = false;

            educationPanel.BringToFront();
            previousBtn.Visible = true;
            nextBtn.Visible = true;
            submitBtn.Visible = false;
        }

        private void DisplayBenefitPanel()
        {
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            accountBtn.TextColor = Color.DodgerBlue;
            accountBtn.BackColor = Color.White;
            personalBtn.BackColor = Color.White;
            personalBtn.TextColor = Color.DodgerBlue;
            educationBtn.BackColor = Color.White;
            educationBtn.TextColor = Color.DodgerBlue;
            benefitsBtn.BackColor = Color.DodgerBlue;
            benefitsBtn.TextColor = Color.White;

            employmentPanel.Visible = false;
            accountPanel.Visible = false;
            educationPanel.Visible = false;
            benefitPanel.Visible = true;
            personalPanel.Visible = false;

            benefitPanel.BringToFront();
            nextBtn.Visible = false;
            previousBtn.Visible = true;
            submitBtn.Visible = true;
        }

        private async void addEmployeeModal_Load(object sender, EventArgs e)
        {
            await DataBinding();
            DisplayAccountPanel();
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            DisplayAccountPanel();
        }

        private void employmentBtn_Click(object sender, EventArgs e)
        {
            if (!AuthorizedAccountPanel())
                return;

            DisplayEmploymentPanel();
        }

        private void personalBtn_Click(object sender, EventArgs e)
        {
            if (!AuthorizedEmploymentPanel())
                return;

            DisplayPersonalPanel();
        }

        private void educationBtn_Click(object sender, EventArgs e)
        {
            if (!AuthorizedPersonalPanel())
                return;

            DisplayEducationPanel();
        }

        private void benefitsBtn_Click(object sender, EventArgs e)
        {
            if (!AuthorizedEducationPanel())
                return;

            DisplayBenefitPanel();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (accountPanel.Visible)
            {
                if (!AuthorizedAccountPanel())
                    return;

                DisplayEmploymentPanel();
            }
            else if (employmentPanel.Visible)
            {
                if (!AuthorizedEmploymentPanel())
                    return;

                DisplayPersonalPanel();
            }
            else if (personalPanel.Visible)
            {
                if (!AuthorizedPersonalPanel())
                    return;

                DisplayEducationPanel();
            }
            else if (educationPanel.Visible)
            {
                if (!AuthorizedEducationPanel())
                    return;

                DisplayBenefitPanel();
            }
            else
            {
                nextBtn.Visible = false;
            }
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            if (benefitPanel.Visible)
            {
                DisplayEducationPanel();
            }
            else if (educationPanel.Visible)
            {
                DisplayPersonalPanel();
            }
            else if (personalPanel.Visible)
            {
                DisplayEmploymentPanel();
            }
            else if (employmentPanel.Visible)
            {
                DisplayAccountPanel();
            }
            else
            {
                previousBtn.Visible = false;
            }
        }

        private void accountCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (accountCheck.Checked)
            {
                emailLabel.Visible = true;
                emailAddressBox.Visible = true;
                accessLabel.Visible = true;
                userRole.Visible = true;
                accountStatus = true;
            }
            else
            {
                emailLabel.Visible = false;
                emailAddressBox.Visible = false;
                accessLabel.Visible = false;
                userRole.Visible = false;
            }
        }

        private void addBtn0_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"{benefitList.Count}");
                if ((!string.IsNullOrEmpty(benefitName.Text) && int.TryParse(benefitValue.Texts, out int value)) && (value != 0 && value >= minimumBenefitValue))
                {
                    if (!benefitList.Any(item => item.Item1 == benefitName.Text))
                    {
                        mandateDeductionsUC mandateDeductions = new mandateDeductionsUC();

                        mandateDeductions.BenefitName = benefitName.Text;
                        mandateDeductions.TotalValue = $"${value}";

                        mandatedPanel.Controls.Add(mandateDeductions);
                        benefitList.Add((benefitName.Text, value));

                        benefitName.SelectedIndex = -1;
                        benefitValue.Texts = "";
                    }
                    else
                    {
                        ErrorMessages("The chosen benefit is already available to be added. Please choose another benefit / deductions", 
                            "Option Invalid");
                    }
                }
                else
                {
                    ErrorMessages("Kindly provide the necessary details for the additional benefits. Ensure that the chosen benefit and its value " +
                        "is greater than or equal to the designated minimum value", "Insufficient Information");
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void removeBtn0_Click(object sender, EventArgs e)
        {
            benefitName.SelectedIndex = -1;
            benefitValue.Texts = "";
        }

        // This function responsible for formatting the user input into a sentence format
        // Also the user input will be automatically saved to the FirstName variable
        private void firstNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                FirstName = capitalizedText;
            }
        }

        // This function is responsible so that no numbers can be inputted into the First name text box
        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the digit from being entered
            }
        }

        // This function responsible for converting the user input into a sentence format
        // Also it will automatically save the text into the last name variable
        private void lastNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                LastName = capitalizedText;
            }
        }

        // Function is used so that no number can be inputted into the last name textbox
        private void lastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the digit from being entered
            }
        }

        // This function is responsible for making the user input into a sentence format
        // Also it will automatically save the user input into the MiddleName variable
        private void middleNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(middleNameTextBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                MiddleName = capitalizedText;
            }
        }

        // Function is used so that no number can be inputted into the middle name textbox
        private void middleNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the digit from being entered
            }
        }

        private void userRole_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(userRole.Text))
            {
                UserRole = userRole.Text;
            }
        }

        // This function is responsible for saving the user input email address into the variable
        private void emailAddressBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(emailAddressBox.Texts))
            {
                EmailAddress = emailAddressBox.Texts;
            }
        }

        private void employeeImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog employeefile = new OpenFileDialog();
            employeefile.Filter = "Image Files (*.jpg; *jpeg; *.png;) | *.jpg; *jpeg; *.png;";
            employeefile.Title = "Select an Image";

            if (employeefile.ShowDialog() == DialogResult.OK)
            {
                employeeImageLocation = employeefile.FileName;
                Bitmap originalImage = new Bitmap(employeefile.FileName);

                float resolution = originalImage.HorizontalResolution;

                int newHeight = 500;
                int newWidth = 500;
                Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
                employeeImage.Image = newImage;
                originalImage.Dispose();
            }
        }

        private void signatureImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog signaturefile = new OpenFileDialog();
            signaturefile.Filter = "Image Files (*.jpg; *jpeg; *.png;) | *.jpg; *jpeg; *.png;";
            signaturefile.Title = "Select an Image";

            if (signaturefile.ShowDialog() == DialogResult.OK)
            {
                employeeSignatureLocation = signaturefile.FileName;
                Bitmap originalImage = new Bitmap(signaturefile.FileName);
                originalImage.MakeTransparent();

                float resolution = originalImage.HorizontalResolution;

                SizeF imageSize = new SizeF(2, 2);
                Size newSize = new Size((int)(imageSize.Width * resolution), (int)(imageSize.Height * resolution));

                signatureImage.Image = new Bitmap(originalImage, newSize);
                originalImage.Dispose();
            }
        }

        private void departmentName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(departmentName.Text) && departmentName.SelectedIndex != -1)
            {
                DepartmentName = departmentName.Text;
            }
        }

        private void jobDescriptionBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(jobDescriptionBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                JobDescription = capitalizedText;
            }
        }

        private async void salaryRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (salaryRate.Text != "Custom" && salaryRate.Text != string.Empty && EmploymentStatus == "REGULAR")
                {
                    int value = await GetValue(salaryRate.Text);

                    SalaryRate = salaryRate.Text;

                    if (value > 0)
                    {
                        salaryRateValueTextBox.Visible = false;
                        salaryRateValueLabel.Visible = true;
                        salaryRateValueLabel.BringToFront();

                        salaryRateValueLabel.Text = value.ToString();
                    }
                    else
                    {
                        salaryRateValueLabel.Text = "Error";
                    }
                }
                else if ((salaryRate.Text == "Custom" || string.IsNullOrEmpty(salaryRate.Text)) && EmploymentStatus != "REGULAR")
                {
                    salaryRateValueLabel.Visible = false;
                    salaryRateValueTextBox.Visible = true;

                    int count = await GetCustomCount(salaryRate.Text) + 1;

                    if (count >= 0)
                    {
                        SalaryRate = salaryRate.Text + count.ToString();
                        salaryRateValueTextBox.Visible = true;
                        salaryRateValueTextBox.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("There is an error in retrieving custom count");
                    }
                }
                else if (EmploymentStatus == "REGULAR" && salaryRate.Text == "Custom")
                {
                    salaryRate.SelectedIndex = -1;
                    ErrorMessages("A regular employee salary rate must only be chosen from a designated salary grade. Please choose the proper salary grade " +
                        "below", "Invalid Salary Rate");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: @"Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: @"Salary Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salaryRateValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press event
                salaryValueError.SetError(salaryRateValueTextBox, "Only numbers allowed");
            }
            else
            {
                salaryValueError.SetError(salaryRateValueTextBox, "");
            }
        }

        private async void salaryRateValueTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(salaryRateValueTextBox.Texts) && int.TryParse(salaryRateValueTextBox.Texts, out int salary) && EmploymentStatus != "REGULAR")
            {
                SalaryRateValue = salary;
                await ForwardMandatedValue(EmploymentStatus);
            }
        }

        private async void salaryRateValueLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(salaryRateValueLabel.Text) && int.TryParse(salaryRateValueLabel.Text, out int salary) && EmploymentStatus == "REGULAR")
            {
                SalaryRateValue = salary;
                await ForwardMandatedValue(EmploymentStatus);
            }
        }

        private void scheduleBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(scheduleBox.Text))
            {
                SalarySchedule = scheduleBox.Text;
            }
        }

        private async void employmentStatus_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(employmentStatus.Text) && employmentStatus.SelectedIndex > -1 && employmentStatus.Text.ToUpper() != "REGULAR")
            {
                EmploymentStatus = employmentStatus.Text;
                DateTime? newDateRetired = await SetDateRetired(employmentStatus.Text);
                dateRetired.Value = newDateRetired.Value.Date;
                retiredLabel.Visible = true;
                dateRetired.Visible = true;
                retiredWarning.Visible = true;

                await PopulateUserRole(employmentStatus.Text);
                benefitName.DataSource = await PopulateBenefitList(employmentStatus.Text);
                benefitName.SelectedIndex = -1;

                int index = salaryRate.Items.IndexOf("Custom");
                salaryRate.SelectedIndex = index;
                salaryRate.Enabled = false;
                salaryWarning.Visible = true;
            }
            else if (!string.IsNullOrEmpty(employmentStatus.Text) && employmentStatus.SelectedIndex > -1 && employmentStatus.Text.ToUpper() == "REGULAR")
            {
                EmploymentStatus = employmentStatus.Text;
                retiredLabel.Visible = false;
                dateRetired.Visible = false;
                retiredWarning.Visible = false;
                dateRetired.Value = DateTime.Today;

                await PopulateUserRole(employmentStatus.Text);
                benefitName.DataSource = await PopulateBenefitList(employmentStatus.Text);
                benefitName.SelectedIndex = -1;

                salaryRate.SelectedIndex = -1;
                salaryRate.Enabled = true;
                salaryWarning.Visible = false;
            }
        }

        private void dateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            if (((DateTime.Today.Year - dateOfBirthPicker.Value.Year) >= 18 ||
                ((DateTime.Today.Year - dateOfBirthPicker.Value.Year) == 17 &&
                DateTime.Today.DayOfYear >= dateOfBirthPicker.Value.DayOfYear)))
            {
                Birthday = dateOfBirthPicker.Value.Date;
                birthdayError.SetError(dateOfBirthPicker, "");
                dateOfBirthPicker.BorderColor = Color.Gray;
            }
            else
            {
                birthdayError.SetError(dateOfBirthPicker, "The Employee must be atleast 18 years of age or turning 18 this year!");
                dateOfBirthPicker.BorderColor = Color.Red;
            }
        }

        private void sex_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sex.Text) && sex.SelectedIndex > -1)
            {
                Sex = sex.Text;
            }
        }

        private void nationalityBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nationalityBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                Nationality = capitalizedText;
            }
        }

        private void civilStatus_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(civilStatus.Text) && civilStatus.SelectedIndex > -1)
            {
                CivilStatus = civilStatus.Text;
            }
        }

        private void contactNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress non-digit input
                mobileNumberError.SetError(contactNumberBox, "Only Numbers allowed");
            }
            else
            {
                mobileNumberError.SetError(contactNumberBox, "");
            }
        }

        private void contactNumberBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(contactNumberBox.Texts) && int.TryParse(contactNumberBox.Texts, out _))
            {
                ContactNumber = contactNumberBox.Texts;
            }
        }

        private void municipalityBox_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(barangayBox.Texts))
            {
                barangayBox.BorderColor = Color.Red;
                barangayError.SetError(barangayBox, "Kindly provide the barangay address of the employee.");
                barangayBox.Focus();
            }
            else
            {
                barangayBox.BorderColor = Color.DimGray;
                barangayError.SetError(barangayBox, "");
            }
        }

        private void provinceBox_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(municipalityBox.Texts))
            {
                municipalityBox.BorderColor = Color.Red;
                municipalityError.SetError(municipalityBox, "Kindly provide the municipal or city address of the employee.");
                municipalityBox.Focus();
            }
            else
            {
                municipalityBox.BorderColor = Color.DimGray;
                municipalityError.SetError(municipalityBox, "");
            }
        }

        private void barangayBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(barangayBox.Texts))
            {
                Barangay = barangayBox.Texts;
            }
        }

        private void municipalityBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(municipalityBox.Texts))
            {
                Municipality = municipalityBox.Texts;
            }
        }

        private void provinceBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(provinceBox.Texts))
            {
                Province = provinceBox.Texts;
            }
        }

        private void zipCode_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(provinceBox.Texts))
            {
                provinceBox.BorderColor = Color.Red;
                provinceError.SetError(provinceBox, "Kindly provide the province address of the employee.");
                provinceBox.Focus();
            }
            else
            {
                provinceBox.BorderColor = Color.DimGray;
                provinceError.SetError(provinceBox, "");
            }
        }

        private void zipCode__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(zipCode.Texts))
            {
                ZipCode = zipCode.Texts;
            }
        }

        private void educationalAttainment_TextChanged(object sender, EventArgs e)
        {
            int chosen = educationalAttainment.SelectedIndex;

            if (chosen >= 6)
            {
                courseBox.Texts = "N/A";
                courseBox.Enabled = false;
            }
            else
            {
                courseBox.Texts = "Enter Course";
                courseBox.Enabled = true;
            }

            EducationalAttainment = educationalAttainment.Text;
        }

        private void schoolAddressBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(schoolAddressBox.Texts))
            {
                SchoolAddress = schoolAddressBox.Texts;
            }
        }

        private void schoolName__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(schoolName.Texts))
            {
                SchoolName = schoolName.Texts;
            }
        }

        private void courseBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(courseBox.Texts))
            {
                Course = courseBox.Texts;
            }
        }

        private void benefitValue0_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a dot
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }

            // Allow the dot if it's not already present in the text
            if (e.KeyChar == '.' && benefitValue.Texts.Contains("."))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void dateRetired_ValueChanged(object sender, EventArgs e)
        {
            if (dateRetired.Value != DateTime.Today)
            {
                DateRetired = dateRetired.Value;
            }
            else
            {
                DateRetired = null;
            }
        }

        private async void benefitName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(benefitName.Text) && benefitName.SelectedIndex > -1)
            {
                DataTable value = await GetBenefitValue(benefitName.Text);

                if (value != null)
                {
                    DataRow row = value.Rows[0];
                    
                    if ((bool)row["isPercentage"])
                    {
                        int totalPercent = int.Parse(row["totalValue"].ToString());
                        decimal totalValue = ComputeTotalValue(totalPercent, SalaryRateValue);
                        minimumBenefitValue = totalValue;
                        benefitValue.Texts = $"{totalValue}";
                    }
                    else
                    {
                        benefitValue.Texts = $"{row["totalValue"]}";
                        minimumBenefitValue = Convert.ToDecimal(row["totalValue"].ToString());
                    }
                }
                else
                {
                    benefitValue.Texts = "";
                }
            }
            else
            {
                benefitValue.Texts = "";
            }
        }

        #endregion

        #region Custom Functions Used for Authorization and Validation of User Inputs before proceeding to every transactions

        //Function for checking the authorization
        private async Task<bool> IsAuthorized(int userId)
        {
            try
            {
                string getValidation = await GetValidation(userId);
                if (getValidation != null && getValidation == "Personnel")
                {
                    return true;
                }
                else
                {
                    ErrorMessages(userId.ToString(),
                        "Authorization Error");
                    //ErrorMessages("You are not authorized to perform this action. Please contact the system administrator for assistance.",
                    //"Authorization Error");
                    return false;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string PasswordGenerator(string employeeId)
        {
            try
            {
                string password = $"{employeeId}".Replace(" ", "").ToLower();
                return password;
            }
            catch(SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Function responsible for adding the new Employee, Appointment Form and Custom Salary Rate if needed
        private async Task<bool> AddNewEmployee(string password)
        {
            try
            {
                EmployeePicture = Path.Combine(employeeImageDestination, FirstName + LastName + MiddleName + Path.GetExtension(employeeImageLocation));
                EmployeeSignature = Path.Combine(employeeSignatureDestination, FirstName + LastName + MiddleName + Path.GetExtension(employeeSignatureLocation));
                File.Copy(employeeImageLocation, EmployeePicture, true);
                File.Copy(employeeSignatureLocation, EmployeeSignature, true);

                bool addSalaryRate = false;
                bool addEmployee = false;
                bool addAppointmentForm = false;

                if (SalaryRate.ToUpper().Contains("CUSTOM"))
                {
                    int customCount = await GetCustomCount(SalaryRate) + 1;
                    SalaryRate += customCount;
                    addSalaryRate = await AddSalaryRate(SalaryRate, SalaryRateValue);
                    addEmployee = await AddEmployee(password, EmployeePicture, EmployeeSignature);
                    addAppointmentForm = await AddAppointmentForm(EmployeeID, SalaryRate, DateTime.Today, DateHired, DateRetired, SalarySchedule, 
                        EmploymentStatus, MorningShift, AfternoonShift);
                }
                else
                {
                    addSalaryRate = true;
                    addEmployee = await AddEmployee(password, EmployeePicture, EmployeeSignature);
                    addAppointmentForm = await AddAppointmentForm(EmployeeID, SalaryRate, DateTime.Today, DateHired, DateRetired, SalarySchedule, 
                        EmploymentStatus, MorningShift, AfternoonShift);
                }

                if (!addSalaryRate && !addEmployee && !addAppointmentForm)
                {
                    ErrorMessages("An error occurred while attempting to add the new employee/Appointment Form. " +
                        "Please review the information and try again later. If the issue persists, kindly contact the system administrator. " +
                        "Thank you for your understanding.", "Error Adding New Employee");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //Function responsible for adding the date and time stamp in employee DTR indicating that employee is hired
        private async Task<bool> AddNewDTRLog(int employeeId)
        {
            try
            {
                bool addDtrLog = await AddHiredLog(employeeId, DateTime.Today, "Just Got Hired");

                if (addDtrLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is some error in adding the Date Hired in employee DTR. Please do it manually on the DTR Section",
                        "Error DTR Log");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //Function responsible for adding into the Employee Data Logs and System Logs
        private async Task<bool> AddNewLog(string userName, string employeeName, int employeeId)
        {
            try
            {
                string systemLogDescription = "The personnel " + userName + " added " + employeeName + " as a new employee. Date and time added is " + DateTime.Now.ToString("f");
                string employeeLogDescription = "The personnel " + userName + " added " + employeeName + " as a new employee. Date and time added is " + DateTime.Now.ToString("f");
                string caption = "New Employee Added";

                bool addSystemLog = await AddSystemLogs(DateTime.Today, systemLogDescription, caption);
                bool addEmployeeLog = await AddEmployeeLogs(employeeId, DateTime.Today, employeeLogDescription, caption);

                if (!addSystemLog && !addEmployeeLog)
                {
                    ErrorMessages("The Employee is already added but there is some issues in adding the event into the System Logs. " +
                        "Please inform the System Administrator to resolve the Issues.", "Error in Inserting Logs");
                    return false;
                }
                else
                {
                    SuccessMessages("The employee has been successfully registered and can now be viewed in the employee list section. " +
                        "Please review the employee details to ensure that all information is accurate.", "Employee Register");
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for adding the benefits and deductions
        private async Task<bool> AddEmployeeBenefit(int employeeId, string status)
        {
            try
            {
                if (benefitList.Count > 0)
                {
                    foreach (var benefit in benefitList)
                    {
                        bool isAllowed = await CheckEmployeeBenefitExist(employeeId, benefit.Item1);

                        if (isAllowed)
                        {
                            bool addEmployeeBenefit = await AddBenefit(employeeId, benefit.Item1, benefit.Item2, status);

                            if (addEmployeeBenefit)
                            {
                                SuccessMessages($"The benefit '{benefit.Item1}' has been successfully added to the Appointment form.",
                               "Benefit Addition Successful");
                            }
                            else
                            {
                                ErrorMessages("An error occurred while adding the benefit. Please review the provided details and try again.",
                                "Benefit Addition Error");
                            }
                        }
                        else
                        {
                            ErrorMessages($"The benefit named '{benefit.Item1}' already exists on the employee's appointment form. " +
                           "Please review the form and ensure that duplicate benefits are not added.",
                           "Benefit Insertion Error");
                        }
                    }

                    return true;
                }
                else
                {
                    DialogResult result = MessageBox.Show("There is no mandated deductions or benefits appointed to this Employee. Would you still " +
                        "to proceed adding this employee to the database?", "Proceed without Mandated Deductions/Benefits?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        return true;
                    }

                    ErrorMessages("Please add new benefits / deductions before proceeding", "Benefit Addition");
                    return false;
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, caption: "Sql Error");
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, caption: "Error");
                return false;
            }
        }

        //Function responsible for adding employee's leave credits
        private async Task<bool> AddLeaveCredits(int employeeId, string employmentStatus)
        {
            try
            {
                if (employmentStatus != "REGULAR" && employmentStatus != "Regular")
                {
                    SuccessMessages("Given that the employee being added is not in a regular status, providing leave credits to the employee is not permissible.",
                        "Leave Credits Allocation Restriction");
                    return true;
                }
                else if (employmentStatus == "REGULAR" || employmentStatus == "Regular")
                {
                    DataTable leaveCredits = await GetLeaveCredits();

                    if(leaveCredits != null)
                    {
                        foreach (DataRow row in leaveCredits.Rows)
                        {
                            bool addLeaveCredits = await AddLeaveCredits(employeeId, $"{row["leaveType"]}",
                                float.Parse($"{row["numberOfCredits"]}"), DateTime.Today.Year);

                            if(!addLeaveCredits)
                            {
                                ErrorMessages($"An error occurred while allocating the leave credits for {row["leaveType"]}. " +
                                    $"Please contact the system administrators for resolution", "Leave Credits Allocation Error");
                                return false;
                            }
                            SuccessMessages($"The allocation for the leave credits for {row["leaveType"]} has been successfully completed", 
                                "Leave Credits Allocation");
                        }
                        return true;
                    }

                    ErrorMessages("No leave credits were retrieved. Please contact the system administrator for resolution",
                        "Leave Credits Retrieval Error");
                    return false;
                }
                else
                {
                    ErrorMessages("An error occurred during the allocation of leave credits. Please contact the system administrator for resolution.",
                                    "Leave Credits Allocation Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for adding employee pass slip hours
        private async Task<bool> SubmitSlipHours(int employeeId, int month, int year, int numberOfMonth, string hours)
        {
            try
            {
                if(TimeSpan.TryParse(hours, out TimeSpan employeeHours))
                {
                    for (int i = month; i <= numberOfMonth; i++)
                    {
                        bool addSlip = await AddSlipHours(employeeId, year, month, employeeHours);

                        if(!addSlip)
                        {
                            ErrorMessages($"There is an error in allocating the employee's pass slip hours for the month of " +
                                $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} please do contact the system administrator " +
                                $"and the pass slip hours allocation is halt for now. System Administrators will add the hours later on " +
                                $"if the situation is resolve", "Pass Slip Hours Allocation Error");
                            return false;
                        }
                    }
                    SuccessMessages("Pass Slip Hours allocation is done for this year.", "Pass Slip Hours Allocation");
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error in converting the hours retrieved from the Configuration. Please contact system " +
                        $"administrator for resolution. Allocating of hours is temporarily terminated, system administrator will add the " +
                        $"employee's hours on a later time after the error is resolved", "Pass Slip Hours Allocation Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // function for checking if the email submitted is a valid email based only from the format
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                             + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            return Regex.IsMatch(email, pattern);
        }

        private void ErrorMessages(string description, string caption)
        {
            MessageBox.Show(description, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string description, string caption)
        {
            MessageBox.Show(description, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorizedBenefitPanel())
                    return;

                bool isAuthorized = await IsAuthorized(_userId);
                if (!isAuthorized)
                    return;

                string password = PasswordGenerator(EmployeeID.ToString());
                if (string.IsNullOrEmpty(password))
                    return;

                bool addEmployee = await AddNewEmployee(password);
                if (!addEmployee)
                    return;

                bool addBenefit = await AddEmployeeBenefit(EmployeeID, status);
                if (!addBenefit)
                    return;

                bool addLeaveCredits = await AddLeaveCredits(EmployeeID, EmploymentStatus);
                if (!addLeaveCredits)
                    return;

                bool addSlip = await SubmitSlipHours(EmployeeID, _month, _year, numberOfMonth, defaultHours);
                if (!addSlip)
                    return;

                bool addDtr = await AddNewDTRLog(EmployeeID);
                if(!addDtr) 
                    return;

                string userName = await UserDetails(_userId);
                if (string.IsNullOrEmpty(userName))
                    return;

                bool addNewLog = await AddNewLog(userName, $"{FirstName} {LastName}", EmployeeID);
                if(!addNewLog)
                    return;

                this.Close();
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
    }
}
