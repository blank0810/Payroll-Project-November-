using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Custom;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Modal
{
    public partial class modificationEmployeeForm : Form
    {
        private static employeeClass employeeClass = new employeeClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static string employeeImageDestination = ConfigurationManager.AppSettings["DestinationEmployeeImagePath"];
        private static string employeeSignatureDestination = ConfigurationManager.AppSettings["DestinationEmployeeSignaturePath"];

        public int EmployeeID;
        public DateTime DateRetired;
        public DateTime DateHired;
        public string SalaryRate;
        public string SalarySchedule;
        public string EmploymentStatus;
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public DateTime Birthday;
        public string Barangay;
        public string Municipality;
        public string Province;
        public string ZipCode;
        public string Nationality;
        public string CivilStatus;
        public string Sex;
        public string PhoneNumber;
        public string EmailAddress;
        public string EducationalAttainment;
        public string SchoolAddress;
        public string Schoolname;
        public string Course;
        public string Department;
        public string JobDescription;
        public string UserRole;
        public string EmployeeImage;
        public string EmployeeSignature;

        private static string newEmployeePicture;
        private static string newEmployeeSignature;
        private static int _userId;
        private static int _employeeId;
        private static employeeDataUC _parent;
        // This status indicates for the default status of benefits when added into the employee
        private static string status = "Active";
        private static readonly List<(string, decimal)> benefitList = new List<(string, decimal)>();

        public modificationEmployeeForm(int userId, employeeDataUC parent, int employeeId)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        #region Function responsible for communicating with employeeClass and generalFunctions class

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
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

        private async Task<DataTable> GetEmploymentStatus()
        {
            try
            {
                DataTable employmentStatus = await generalFunctions.GetEmploymentStatus();

                if (employmentStatus == null)
                {
                    return null;
                }
                else
                {
                    return employmentStatus;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetAllSalaryRate()
        {
            try
            {
                DataTable salaryRate = await employeeClass.GetAllSalaryRate();

                if (salaryRate == null)
                {
                    return null;
                }
                else
                {
                    return salaryRate;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetScheduleDescription()
        {
            try
            {
                DataTable description = await employeeClass.GetScheduleDescription();

                if (description == null)
                {
                    return null;
                }
                else
                {
                    return description;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetEducationalAttainment()
        {
            try
            {
                DataTable list = await employeeClass.GetEducationalAttainment();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetDepartmentList()
        {
            try
            {
                DataTable department = await generalFunctions.GetDepartmentList();

                if (department == null)
                {
                    return null;
                }
                else
                {
                    return department;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> UpdateSalaryRate(string salaryDescription, int salaryValue)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool updateSalaryRate = await employeeClass.UpdateSalaryRate(salaryDescription, salaryValue);

                if (updateSalaryRate)
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

        private async Task<bool> UpdateEmployeeAndAppointmentForm(int employeeId, string fName, string lName, string mName, DateTime birthday, string barangay, string municipality, string province, string zipCode, string civilStatus, string sex, string contactNumber, string emailAddress, string educationalAttainment, string schoolName, string course, string schoolAddress, string department, string jobDescription, string roleName, string employeePicture, string employeeSignature, string nationality, string salaryRate, DateTime dateRetired, string payrollSched, string employmentStatus)
        {
            try
            {
                bool updateData = await employeeClass.UpdateEmployeeAndAppointmentForm(employeeId, fName, lName, mName, birthday, barangay, municipality, province, zipCode, civilStatus, sex, contactNumber, emailAddress, educationalAttainment, schoolName, course, schoolAddress, department, jobDescription, roleName, employeePicture, employeeSignature, nationality, salaryRate, dateRetired, payrollSched, employmentStatus);

                return updateData;
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

        // This function return some details based on the userId parameter for the systme logs and employee logs
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

        private async Task<bool> CheckEmployeeBenefitExist(int id, string benefitName)
        {
            #region This function when called is use to check if the benefit that will be addded does exist on the employee appointment form or not
            // If the benefit exist then the function will notify the personnel that this benefit is already exist on employee appointment form

            try
            {
                DataTable employeeBenefitList = await generalFunctions.GetEmployeeBenefits(id);

                if (employeeBenefitList != null && employeeBenefitList.Rows.Count > 0)
                {
                    foreach (DataRow row in employeeBenefitList.Rows)
                    {

                        if (row["benefits"].ToString().ToUpper() == benefitName)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

        private async Task<int> GetRoleCount(string roleName, string department)
        {
            try
            {
                int count = await employeeClass.GetRoleCount(roleName, department);
                return count;
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for adding the employee's leave credits
        private async Task<bool> AddLeaveCredits(int employeeId, string leaveType, float numberOfCredits, int year)
        {
            try
            {
                bool addLeaveCredits = await employeeClass.AddEmployeeLeaveCredits(employeeId, leaveType, numberOfCredits, year);

                return addLeaveCredits;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Custom functions for functionality

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

                    userRoleBox.DataSource = roleList;
                }
                else
                {
                    roleList.Add("No Choices available");
                    userRoleBox.DataSource = roleList;
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

        // Function that makes that set the date retired of an employment aside from a regular
        private async Task<DateTime?> SetDateRetired(string employmentStatus)
        {
            try
            {
                if (DateRetired == null)
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
                else
                {
                    return DateRetired;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for computing the total value of mandated benefit if its percentage
        private decimal ComputeTotalValue(int totalPercentage, decimal salaryRate)
        {
            try
            {
                decimal totalValue = (totalPercentage * salaryRate) / 100;
                return totalValue;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for displaying the mandated benefits
        private async Task ForwardMandatedValue(string employmentStatus)
        {
            try
            {
                DataTable benefits = await GetMandated(employmentStatus);
                benefitList.Clear();

                if (benefits != null && benefits.Rows.Count > 0)
                {
                    if (employmentStatus == "REGULAR" && decimal.TryParse(salaryRateValueLabel.Text, out decimal value))
                    {
                        for (int i = 0; i < benefits.Rows.Count; i++)
                        {
                            DataRow row = benefits.Rows[i];

                            if ((bool)row["isPercentage"])
                            {
                                decimal totalValue = ComputeTotalValue(int.Parse(row["value"].ToString()), value);

                                benefitList.Add((row["benefits"].ToString(), totalValue));
                            }
                            else
                            {
                                benefitList.Add((row["benefits"].ToString(), Convert.ToDecimal(row["value"])));
                            }
                        }
                    }
                    else if (employmentStatus != "REGULAR" && decimal.TryParse(salaryValueTextBox.Texts, out decimal labelValue))
                    {
                        for (int i = 0; i < benefits.Rows.Count; i++)
                        {
                            DataRow row = benefits.Rows[i];

                            if ((bool)row["isPercentage"])
                            {
                                decimal totalValue = ComputeTotalValue(int.Parse(row["value"].ToString()), labelValue);

                                benefitList.Add((row["benefits"].ToString(), totalValue));
                            }
                            else
                            {
                                benefitList.Add((row["benefits"].ToString(), Convert.ToDecimal(row["value"])));
                            }
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

        // this function is responsible for double checking controls that must not have any numbers
        private bool ContainsNumber(string word)
        {
            foreach (char c in word)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        // same function also responsible for double checking to capitalize controls needed to be capitalize
        private string CapitalizeFirstLetter(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                string firstLetter = word.Substring(0, 1).ToUpper();
                string remainingLetters = word.Substring(1).ToLower();
                return firstLetter + remainingLetters;
            }
            return word;
        }

        #endregion

        #region Function and Event handlers

        private async Task DataBinding()
        {
            try
            {
                employeeClass employeeClass = new employeeClass();

                DataTable educationalAttainmentTable = await GetEducationalAttainment();
                DataTable departmentTable = await GetDepartmentList();
                DataTable employmentStatusTable = await GetEmploymentStatus();
                DataTable salaryRateDescription = await GetAllSalaryRate();
                DataTable scheduleDescription = await GetScheduleDescription();

                List<string> salaryRateList = new List<string>();
                List<string> employmentStatusList = new List<string>();
                List<string> scheduleDescriptionList = new List<string>();
                List<string> educationalAttainmentList = new List<string>();
                List<string> userRoleList = new List<string>();
                List<string> departmentStringList = new List<string>();

                foreach (DataRow row in salaryRateDescription.Rows)
                {
                    string salaryRateItems = row["salaryratedescription"].ToString().ToUpper();
                    salaryRateList.Add(salaryRateItems);
                }

                foreach (DataRow row in employmentStatusTable.Rows)
                {
                    string statusItem = row["employmentstatus"].ToString().ToUpper();
                    employmentStatusList.Add(statusItem);
                }

                foreach (DataRow row in scheduleDescription.Rows)
                {
                    string scheduleItems = row["payrollscheduledescription"].ToString().ToUpper();
                    scheduleDescriptionList.Add(scheduleItems);
                }

                foreach (DataRow row in educationalAttainmentTable.Rows)
                {
                    string educationalItems = row["educationalattainment"].ToString().ToUpper();
                    educationalAttainmentList.Add(educationalItems);
                }

                foreach (DataRow row in departmentTable.Rows)
                {
                    string departmentItem = (row["departmentName"].ToString().ToUpper());
                    departmentStringList.Add(departmentItem);
                }

                educationalAttainmentBox.DataSource = educationalAttainmentList;
                departmentList.DataSource = departmentStringList;
                userRoleBox.DataSource = userRoleList;
                employmentStatus.DataSource = employmentStatusList;
                scheduleBox.DataSource = scheduleDescriptionList;
                salaryRate.DataSource = salaryRateList;

                dateRetire.Value = DateRetired;
                salaryRate.SelectedItem = SalaryRate.ToUpper();
                scheduleBox.Text = SalarySchedule;
                employmentStatus.Text = EmploymentStatus;
                firstNameTextBox.Texts = FirstName;
                lastName.Texts = LastName;
                middleName.Texts = MiddleName;
                dateOfBirthPicker.Value = Birthday;
                civilStatusBox.Texts = CivilStatus;
                nationalityBox.Texts = Nationality;
                barangay.Texts = Barangay;
                municipality.Texts = Municipality;
                province.Texts = Province;
                zipCode.Texts = ZipCode;
                sexBox.Texts = Sex;
                contactNumberBox.Texts = PhoneNumber;
                emailAddressBox.Texts = EmailAddress;
                schoolAddressBox.Texts = SchoolAddress;
                schoolNameBox.Texts = Schoolname;
                courseBox.Texts = Course;
                jobDescriptionBox.Texts = JobDescription;
                educationalAttainmentBox.Text = EducationalAttainment;
                departmentList.Text = Department;
                empImage.ImageLocation = EmployeeImage;
                signatureImage.ImageLocation = EmployeeSignature;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: @"SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void modificationEmployeeForm_Load(object sender, EventArgs e)
        {
            await DataBinding();
        }

        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            customTextBox2 textBox = (customTextBox2)sender;
            int selectionStart = textBox.SelectionStart;

            if (selectionStart > 0 && char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(textBox.Text[selectionStart - 1]))
            {
                e.KeyChar = char.ToLower(e.KeyChar);
            }
        }

        private void firstNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int cursorPosition = textBox.SelectionStart;

            string input = textBox.Text;
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]) && !ContainsNumber(words[i]))
                {
                    words[i] = CapitalizeFirstLetter(words[i]);
                }
            }

            textBox.Text = string.Join(" ", words);
            textBox.SelectionStart = cursorPosition;
        }

        private void firstNameTextBox__TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            textBox.Text = capitalizedText;
            textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end
        }

        private void lastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            customTextBox2 textBox = (customTextBox2)sender;
            int selectionStart = textBox.SelectionStart;

            if (selectionStart > 0 && char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(textBox.Text[selectionStart - 1]))
            {
                e.KeyChar = char.ToLower(e.KeyChar);
            }
        }

        private void lastName_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int cursorPosition = textBox.SelectionStart;

            string input = textBox.Text;
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]) && !ContainsNumber(words[i]))
                {
                    words[i] = CapitalizeFirstLetter(words[i]);
                }
            }

            textBox.Text = string.Join(" ", words);
            textBox.SelectionStart = cursorPosition;
        }

        private void lastName__TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            textBox.Text = capitalizedText;
            textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end
        }

        private void middleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            customTextBox2 textBox = (customTextBox2)sender;
            int selectionStart = textBox.SelectionStart;

            if (selectionStart > 0 && char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(textBox.Text[selectionStart - 1]))
            {
                e.KeyChar = char.ToLower(e.KeyChar);
            }
        }

        private void middleName_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int cursorPosition = textBox.SelectionStart;

            string input = textBox.Text;
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]) && !ContainsNumber(words[i]))
                {
                    words[i] = CapitalizeFirstLetter(words[i]);
                }
            }

            textBox.Text = string.Join(" ", words);
            textBox.SelectionStart = cursorPosition;
        }

        private void middleName__TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            textBox.Text = capitalizedText;
            textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end
        }

        private void contactNumberBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.V || e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void contactNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press event
            }
        }

        private void contactNumberBox__TextChanged(object sender, EventArgs e)
        {
            if (contactNumberBox.Texts == string.Empty)
            {
                contactNumberBox.Texts = PhoneNumber;
            }
        }

        private void emailAddressBox__TextChanged(object sender, EventArgs e)
        {
            if (emailAddressBox.Texts == string.Empty)
            {
                emailAddressBox.Texts = EmailAddress;
            }
        }

        private void educationalAttainment_TextChanged(object sender, EventArgs e)
        {
            int chosen = educationalAttainmentBox.SelectedIndex;

            if (chosen >= 6)
            {
                courseBox.Texts = "N/A";
                courseBox.Enabled = false;
            }
            else
            {
                courseBox.Texts = Course;
                courseBox.Enabled = true;
            }
        }

        private void course__TextChanged(object sender, EventArgs e)
        {
            if (courseBox.Texts != string.Empty && courseBox.Texts != "N/A")
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end
            }
        }

        private void ErrorMessages(string description, string caption)
        {
            MessageBox.Show(description, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string description, string caption)
        {
            MessageBox.Show(description, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void employmentStatus_TextChanged(object sender, EventArgs e)
        {
            await PopulateUserRole(employmentStatus.Text);
            userRoleBox.SelectedItem = UserRole;

            if (!string.IsNullOrEmpty(employmentStatus.Text) && employmentStatus.SelectedIndex > -1 && employmentStatus.Text.ToUpper() != "REGULAR")
            {
                DateTime? newDateRetired = await SetDateRetired(employmentStatus.Text);
                dateRetire.Value = newDateRetired.Value.Date;
                retiredWarning.Visible = true;
                await ForwardMandatedValue(employmentStatus.Text);

                salaryRate.Enabled = false;
                salaryWarning.Visible = true;
            }
            else if (!string.IsNullOrEmpty(employmentStatus.Text) && employmentStatus.SelectedIndex > -1 && employmentStatus.Text.ToUpper() == "REGULAR")
            {
                DateTime? newDateRetired = await SetDateRetired(employmentStatus.Text);
                dateRetire.Value = newDateRetired.Value.Date;
                await ForwardMandatedValue(employmentStatus.Text);

                salaryRate.Enabled = true;
                salaryWarning.Visible = false;
                retiredWarning.Visible = false;
            }
        }

        private async void salaryRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (salaryRate.Text != "CUSTOM" && salaryRate.Text != string.Empty && employmentStatus.Text == "REGULAR")
                {
                    int value = await GetValue(salaryRate.Text);

                    SalaryRate = salaryRate.Text;

                    if (value > 0)
                    {
                        salaryValueTextBox.Visible = false;
                        salaryRateValueLabel.Visible = true;
                        salaryRateValueLabel.BringToFront();

                        salaryRateValueLabel.Text = value.ToString();
                    }
                    else
                    {
                        salaryRateValueLabel.Text = "Error";
                    }
                }
                else if ((salaryRate.Text == "CUSTOM" || string.IsNullOrEmpty(salaryRate.Text)) && employmentStatus.Text != "REGULAR")
                {
                    salaryRateValueLabel.Visible = false;
                    salaryValueTextBox.Visible = true;

                    int count = await GetCustomCount(salaryRate.Text) + 1;

                    if (count >= 0)
                    {
                        SalaryRate = salaryRate.Text + count.ToString();
                        salaryValueTextBox.Visible = true;
                        salaryValueTextBox.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("There is an error in retrieving custom count");
                    }
                }
                else if (employmentStatus.Text == "REGULAR" && salaryRate.Text == "Custom")
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
                salaryValueError.SetError(salaryValueTextBox, "Only numbers allowed");
            }
            else
            {
                salaryValueError.SetError(salaryValueTextBox, "");
            }
        }

        private async void salaryRateValueTextBox__TextChanged(object sender, EventArgs e)
        {
            int value = await GetValue(salaryRate.Text);

            if (!string.IsNullOrEmpty(salaryValueTextBox.Texts) && int.TryParse(salaryValueTextBox.Texts, out int salary) && employmentStatus.Text != "REGULAR"
                && employmentStatus.Text != EmploymentStatus && salary == value)
            {
                salaryRateValueLabel.Text = "";
                await ForwardMandatedValue(employmentStatus.Text);
            }
            else if (!string.IsNullOrEmpty(salaryValueTextBox.Texts) && int.TryParse(salaryValueTextBox.Texts, out int salaryValue) && employmentStatus.Text != "REGULAR"
                && employmentStatus.Text != EmploymentStatus && salaryValue != value)
            {
                salaryRateValueLabel.Text = "";
                bool updateSalaryRate = await UpdateSalaryRate(salaryRate.Text, salaryValue);

                if (updateSalaryRate)
                {
                    await ForwardMandatedValue(employmentStatus.Text);
                }
                else
                {
                    ErrorMessages("There is an error in updating the new value of the employee's salary rate", "Salary Rate Error");
                }
            }
        }

        private async void salaryRateValueLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(salaryRateValueLabel.Text) && int.TryParse(salaryRateValueLabel.Text, out _) && 
                employmentStatus.Text == "REGULAR" && employmentStatus.Text != EmploymentStatus)
            {
                salaryValueTextBox.Texts = "";
                await ForwardMandatedValue(employmentStatus.Text);
            }
        }

        private void employeeImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog employeefile = new OpenFileDialog();
            employeefile.Filter = "Image Files (*.jpg; *jpeg; *.png;) | *.jpg; *jpeg; *.png;";
            employeefile.Title = "Select an Image";

            if (employeefile.ShowDialog() == DialogResult.OK)
            {
                employeeImageBox.Texts = employeefile.FileName;
                Bitmap originalImage = new Bitmap(employeefile.FileName);

                float resolution = originalImage.HorizontalResolution;

                int newHeight = 500;
                int newWidth = 500;
                Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
                empImage.Image = newImage;
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
                signatureImageBox.Texts = signaturefile.FileName;
                Bitmap originalImage = new Bitmap(signaturefile.FileName);
                originalImage.MakeTransparent();

                float resolution = originalImage.HorizontalResolution;

                SizeF imageSize = new SizeF(2, 2);
                Size newSize = new Size((int)(imageSize.Width * resolution), (int)(imageSize.Height * resolution));

                signatureImage.Image = new Bitmap(originalImage, newSize);
                originalImage.Dispose();
            }
        }

        #endregion

        #region Encapsulated Functions for Updating Employee Data

        // function for checking if the email submitted is a valid email based only from the format
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                             + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            if(Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                ErrorMessages("The email address input is not valid, please review it", "Email Address Invalid");
                return false;
            }
        }

        private bool IsSalaryRateValid()
        {
            bool isSalaryRateValid = int.TryParse(salaryRateValueLabel.Text, out int salaryRateValue) && salaryRateValueLabel.Visible;
            bool isSalaryValueValid = int.TryParse(salaryValueTextBox.Texts, out int salaryValue) && salaryValueTextBox.Visible;

            if (!isSalaryRateValid && !isSalaryValueValid)
            {
                MessageBox.Show("Salary Rate Value is not valid. Contact System Admin", "Invalid Input", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> IsEmployeeValid(string roleName, string department)
        {
            try
            {
                int count = await GetRoleCount(roleName, department);

                if(UserRole != roleName)
                {
                    if (roleName != "Employee" && count == 1)
                    {
                        ErrorMessages($"Sorry to informed you but the designated role {roleName} must only be assigned to a one employee as per " +
                            $"regulations.", "Employee Role Designation Restriction");
                        return false;
                    }
                    else if (roleName != "Employee" && count < 0)
                    {
                        ErrorMessages("There is an error in validating the employee's role vacancy. Please contact the system administrator for this " +
                            "issue", "Erro in Validation");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
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

        private bool UploadImages()
        {
            try
            {
                if (string.IsNullOrEmpty(employeeImageBox.Texts) && string.IsNullOrEmpty(signatureImageBox.Texts))
                {
                    newEmployeePicture = EmployeeImage;
                    newEmployeeSignature = EmployeeSignature;
                    return true;
                }
                else if (string.IsNullOrEmpty(signatureImageBox.Texts) && !string.IsNullOrEmpty(employeeImageBox.Texts))
                {
                    newEmployeeSignature = EmployeeSignature;
                    newEmployeePicture = Path.Combine(employeeImageDestination, firstNameTextBox.Texts + lastName.Texts + middleName.Texts + Path.GetExtension(employeeImageBox.Texts));
                    File.Copy(employeeImageBox.Texts, newEmployeePicture, true);
                    SuccessMessages("New Employee Image is already uploaded into the server", "Employee Image Uploaded");
                    return true;
                }
                else if (!string.IsNullOrEmpty(signatureImageBox.Texts) && string.IsNullOrEmpty(employeeImageBox.Texts))
                {
                    newEmployeePicture = EmployeeImage;
                    newEmployeeSignature = Path.Combine(employeeSignatureDestination, firstNameTextBox.Texts + lastName.Texts + Path.GetExtension(signatureImageBox.Texts));
                    File.Copy(signatureImageBox.Texts, newEmployeeSignature, true);
                    SuccessMessages("New Employee Signature Image is already uploaded into the server", "Employee Signature Uploaded");
                    return true;
                }
                else
                {
                    newEmployeeSignature = Path.Combine(employeeSignatureDestination, firstNameTextBox.Texts + lastName.Texts + Path.GetExtension(signatureImageBox.Texts));
                    File.Copy(signatureImageBox.Texts, newEmployeeSignature, true);
                    newEmployeePicture = Path.Combine(employeeImageDestination, firstNameTextBox.Texts + lastName.Texts + middleName.Texts + Path.GetExtension(employeeImageBox.Texts));
                    File.Copy(employeeImageBox.Texts, newEmployeePicture, true);
                    return true;
                }
            }
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
                        bool isAllowed = await CheckEmployeeBenefitExist(employeeId, benefit.Item1.ToUpper());

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
                    DialogResult result = MessageBox.Show("There is no mandated deductions or benefits appointed to this Employee. Kindly " +
                        "add the mandated benefit / deduction in the Add Benefit Section in the Employee Details", "Proceed without Mandated Deductions/Benefits",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
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

        private async Task<bool> UpdateData()
        {
            try
            {
                bool updateData = await UpdateEmployeeAndAppointmentForm(EmployeeID, firstNameTextBox.Texts, lastName.Texts,
                            middleName.Texts, dateOfBirthPicker.Value, barangay.Texts, municipality.Texts, province.Texts, zipCode.Texts,
                            civilStatusBox.Texts, sexBox.Texts, contactNumberBox.Texts, emailAddressBox.Texts, educationalAttainmentBox.Text,
                            schoolNameBox.Texts, courseBox.Texts, schoolAddressBox.Texts, departmentList.Text, jobDescriptionBox.Texts,
                            userRoleBox.Text, newEmployeePicture, newEmployeeSignature, nationalityBox.Texts, salaryRate.Text, dateRetire.Value,
                            scheduleBox.Text, employmentStatus.Text);

                if (updateData)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error in updating Employee {FirstName} {LastName} data. Please contact system administrator!",
                        $"Error in Employee Data Update");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        //Function responsible for adding employee's leave credits
        private async Task<bool> AddLeaveCredits(int employeeId, string employmentStatus)
        {
            try
            {
                if (employmentStatus != "REGULAR" && employmentStatus != "Regular")
                {
                    SuccessMessages("Given that the employee being modified is not in a regular status, providing leave credits to the employee is not permissible.",
                        "Leave Credits Allocation Restriction");
                    return true;
                }
                else if (employmentStatus == "REGULAR" || employmentStatus == "Regular")
                {
                    DataTable leaveCredits = await GetLeaveCredits();

                    if (leaveCredits != null)
                    {
                        foreach (DataRow row in leaveCredits.Rows)
                        {
                            bool addLeaveCredits = await AddLeaveCredits(employeeId, $"{row["leaveType"]}",
                                float.Parse($"{row["numberOfCredits"]}"), DateTime.Today.Year);

                            if (!addLeaveCredits)
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> PersonnelName(int userId)
        {
            try
            {
                string personnelName = await UserDetails(userId);

                if (personnelName != null)
                {
                    return personnelName;
                }
                else
                {
                    ErrorMessages($"Error in retrieving the Personnel Name for logs. Updated Information is already saved in the database",
                        "Personnel Name Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddEmployeeLog(string personnelName)
        {
            try
            {
                string employeeLogDescription = $"Personal details updated by {personnelName}. Date and time of update: {DateTime.Now.ToString("f")}";
                string employeeLogCaption = "Employee Data Update";
                bool addEmployeeLog = await AddEmployeeLogs(_employeeId, DateTime.Now, employeeLogDescription, employeeLogCaption);

                if (addEmployeeLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("Employee data is already updated but it encouters error in adding into the Employee Logs",
                        "Employee Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddSystemLog(string personnelName)
        {
            try
            {
                string systemLogDescription = $"Employee {personnelName} has updated the data of {firstNameTextBox.Texts} {lastName.Texts}. Date and time of update: {DateTime.Now.ToString("f")}";
                string systemLogCaption = "Employee Data Update";
                bool addSystemLogs = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addSystemLogs)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("Updated data is already saved but there is an error in adding new system logs", "System Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateEmail(emailAddressBox.Texts))
                    return;

                if (!IsSalaryRateValid())
                    return;

                bool vacancyValid = await IsEmployeeValid(userRoleBox.Text, departmentList.Text);
                if (!vacancyValid)
                    return;

                if (!UploadImages())
                    return;

                bool updateData = await UpdateData();
                if (!updateData)
                    return;

                bool addLeaveCredits = await AddLeaveCredits(EmployeeID, employmentStatus.Text);
                if (!addLeaveCredits)
                    return;

                bool addBenefit = await AddEmployeeBenefit(_employeeId, status);
                if (!addBenefit)
                    return;

                string personnelName = await PersonnelName(_userId);
                if (personnelName == null)
                    this.Close();

                bool employeeLog = await AddEmployeeLog(personnelName);
                if (!employeeLog)
                    this.Close();

                bool systemLog = await AddSystemLog(personnelName);
                if (!systemLog)
                    this.Close();

                SuccessMessages($"Employee {FirstName} {LastName} information is already updated. Please review the updated details at " +
                    $"Employee Details Section", "Employee Update Completed");
                this.Close();
            }
            catch (SqlException sql) 
            {
                ErrorMessages(sql.Message, "Sql Error");
            } 
            catch (Exception ex) 
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
