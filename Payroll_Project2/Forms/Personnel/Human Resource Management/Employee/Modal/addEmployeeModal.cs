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
using NCalc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System.Collections.ObjectModel;
using System.Collections;

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
        private static readonly int numberOfYears = int.Parse(ConfigurationManager.AppSettings["DefaultNumberOfYearsToIncreaseStep"]);
        private static string defaultHours = ConfigurationManager.AppSettings["DefaultSlipHours"];
        private static readonly string CustomSchedule = ConfigurationManager.AppSettings.Get("DefaultCustomSchedule");
        private static int _year = DateTime.Now.Year;
        private static int _month = DateTime.Now.Month;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly employeeClass employeeClass = new employeeClass();
        private static decimal minimumBenefitValue = 0;
        private static readonly int defaultStepNumber = 1;
        private static bool IsPercentage;
        
        // This status indicates for the default status of benefits when added into the employee
        private static bool status = true;

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
        private decimal SalaryRateValue { get; set; }
        private decimal SalaryRateValueId { get; set; }
        private string SalarySchedule { get; set; }
        private decimal PersonalShare { get; set; }
        private decimal EmployerShare { get; set; }
        public DateTime DateHired { get; set; }
        private DateTime? DateRetired { get; set; }
        private string EmployeePicture { get; set; }
        private string EmployeeSignature { get; set; }

        private static readonly List<(int, decimal, decimal)> benefitList = new List<(int, decimal, decimal)>();

        #endregion
        
        public addEmployeeModal(int userId, employeeUserControl parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        #region Custom functions responsible for responsiveness of the Form

        // Custom function for getting the number of working days in a month
        private static int CountWeekdays(int year, int month)
        {
            DateTime startOfMonth = new DateTime(year, month, 1);
            DateTime endOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            int count = 0;
            DateTime currentDate = startOfMonth;

            while (currentDate <= endOfMonth)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return count;
        }

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
                AutoCompleteStringCollection autoCompleteValues = new AutoCompleteStringCollection();

                List<string> employmentStatusList = new List<string>();
                List<string> educationalAttainmentList = new List<string>();
                List<string> scheduleDescriptionList = new List<string>();
                List<string> salaryRateCollection = new List<string>()
                {
                    "Custom"
                };

                foreach (DataRow row in salaryRateDescription.Rows)
                {
                    salaryRateCollection.Add($"{row["salaryRateDescription"]}");
                }

                foreach (DataRow row in departmentTable.Rows)
                {
                    collection.Add($"{row["departmentName"]}");
                }

                foreach (DataRow row in employmentStatusTable.Rows)
                {
                    employmentStatusList.Add($"{row["employmentStatus"]}");
                }

                foreach (DataRow row in educationalAttainmentTable.Rows)
                {
                    educationalAttainmentList.Add($"{row["educationalAttainment"]}");
                }

                foreach (DataRow row in scheduleDescription.Rows)
                {
                    scheduleDescriptionList.Add($"{row["payrollscheduledescription"]}");
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

        private void ClearAll()
        {
            try
            {
                departmentName.DataSource = null;
                salaryRate.DataSource = null;
                employmentStatus.DataSource = null;
                educationalAttainment.DataSource = null;
                scheduleBox.DataSource = null;

                departmentName.Items.Clear();
                salaryRate.Items.Clear();
                employmentStatus.Items.Clear();
                educationalAttainment.Items.Clear();
                scheduleBox.Items.Clear();
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        // Function responsible for displaying the mandated benefits
        private async Task ForwardMandatedValue(string employmentStatus, decimal monthlySalary, List<(int, decimal, decimal)> benefitList)
        {
            try
            {
                mandatedPanel.Controls.Clear();
                DataTable benefits = await GetMandated(employmentStatus);
                bool isPercentage = false;

                if (benefits != null && benefits.Rows.Count > 0)
                {
                    mandateDeductionsUC[] mandated = new mandateDeductionsUC[benefits.Rows.Count];
                    for (int i = 0; i < benefits.Rows.Count; i++)
                    {
                        DataRow row = benefits.Rows[i];
                        mandated[i] = new mandateDeductionsUC();

                        if (!string.IsNullOrEmpty(row["isPercentage"]?.ToString()) && bool.TryParse(row["isPercentage"].ToString(), 
                            out isPercentage))
                        {

                        }

                        if (!string.IsNullOrEmpty(row["benefits"].ToString()))
                        {
                            mandated[i].BenefitName = $"{row["benefits"]}";
                        }
                        else
                        {
                            mandated[i].BenefitName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["benefitsId"].ToString()) && int.TryParse(row["benefitsId"].ToString(), 
                            out int benefitsId))
                        {
                            mandated[i].BenefitId = benefitsId;
                        }
                        else
                        {
                            mandated[i].BenefitId = 0;
                        }

                        if (mandated[i].BenefitId != 0 && mandated[i].BenefitName != "Witholding Tax" && isPercentage)
                        {
                            decimal employerShare = await GetEmployerShareValue(mandated[i].BenefitId);
                            decimal personalShare = await GetPersonalShareValue(mandated[i].BenefitId);
                            decimal amount = await ComputeBenefitContributionsAmount(mandated[i].BenefitId, monthlySalary);

                            mandated[i].EmployeeShare = $"{personalShare}%";
                            mandated[i].EmployerShare = $"{employerShare}%";
                            mandated[i].TotalValue = $"{amount:C2}";

                            benefitList.Add((mandated[i].BenefitId, -1, -1));
                        }
                        else if (mandated[i].BenefitId != 0 && mandated[i].BenefitName != "Witholding Tax" && !isPercentage)
                        {
                            decimal employerShare = await GetEmployerShareValue(mandated[i].BenefitId);
                            decimal personalShare = await GetPersonalShareValue(mandated[i].BenefitId);
                            decimal amount = await ComputeBenefitContributionsAmount(mandated[i].BenefitId, monthlySalary);

                            mandated[i].EmployeeShare = $"{personalShare:C2}";
                            mandated[i].EmployerShare = $"{employerShare:C2}";
                            mandated[i].TotalValue = $"{amount:C2}";

                            benefitList.Add((mandated[i].BenefitId, employerShare, personalShare));
                        }
                        else
                        {
                            mandated[i].EmployeeShare = string.Empty;
                            mandated[i].EmployerShare = string.Empty;
                            mandated[i].TotalValue = $"Pending Value!";
                            benefitList.Add((mandated[i].BenefitId, -1, -1));
                        }

                        mandatedPanel.Controls.Add(mandated[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Benefits Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        // Function responsible for adding the new benefit into the mandate user control
        private async Task AddNewBenefit(string benefitName, decimal personalShare, decimal employerShare, bool isPercentage,
            List<(int, decimal, decimal)> benefitList, decimal monthlySalary)
        {
            try
            {
                int benefitsId = await GetBenefitsId(benefitName);
                DataTable contributions = await GetBenefitContributions(benefitsId);
                mandateDeductionsUC mandate = new mandateDeductionsUC();

                if (contributions != null && benefitsId != 0)
                {
                    foreach (DataRow row in contributions.Rows)
                    {
                        if (!isPercentage)
                        {
                            decimal amount = personalShare + employerShare;

                            mandate.BenefitId = benefitsId;
                            mandate.BenefitName = benefitName;
                            mandate.EmployeeShare = $"{personalShare:C2}";
                            mandate.EmployerShare = $"{employerShare:C2}";
                            mandate.TotalValue = $"{amount:C2}";

                            benefitList.Add((benefitsId, employerShare, personalShare));
                        }
                        else
                        {
                            decimal personalShareValue = await GetPersonalShareValue(benefitsId);
                            decimal employerShareValue = await GetEmployerShareValue(benefitsId);
                            decimal amount = await ComputeBenefitContributionsAmount(benefitsId, monthlySalary);
                            MessageBox.Show($"{personalShareValue}");
                            MessageBox.Show($"{employerShareValue}");

                            mandate.BenefitId = benefitsId;
                            mandate.BenefitName = benefitName;
                            mandate.EmployeeShare = $"{personalShareValue}%";
                            mandate.EmployerShare = $"{employerShareValue}%";
                            mandate.TotalValue = $"{amount:C2}";

                            benefitList.Add((benefitsId, -1, -1));
                        }

                        mandatedPanel.Controls.Add(mandate);
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<decimal> GetPersonalShareValue(int benefitsId)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);

                if(contributions != null)
                {
                    foreach(DataRow row in contributions.Rows)
                    {
                        if (decimal.TryParse(row["personalShareValue"].ToString(), out decimal value))
                        {
                            return value;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                return 0;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<decimal> GetEmployerShareValue(int benefitsId)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);

                if (contributions != null)
                {
                    foreach (DataRow row in contributions.Rows)
                    {
                        if (decimal.TryParse(row["employerShareValue"].ToString(),
                                out decimal employerShare))
                        {
                            return employerShare;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                return 0;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for retrieving the Value of the benefit
        private async Task<decimal> ComputeBenefitContributionsAmount(int benefitsId, decimal monthlySalary)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);

                if (contributions != null)
                {
                    decimal totalAmount = 0;

                    foreach (DataRow row in contributions.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["isPercentage"]?.ToString()) && bool.TryParse(row["isPercentage"].ToString(), out
                            bool isPercentage))
                        {
                            if (!isPercentage && decimal.TryParse(row["value"].ToString(), out decimal amount))
                            {
                                return amount;
                            }
                            else if (!string.IsNullOrEmpty(row["personalShareValue"]?.ToString()) &&
                                !string.IsNullOrEmpty(row["employerShareValue"]?.ToString()) &&
                                decimal.TryParse(row["personalShareValue"].ToString(), out decimal personalShare) &&
                                decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerShare))
                            {

                                string formula = await GetBenefitFormula(benefitsId);
                                Expression expression = new Expression(formula);

                                expression.Parameters["personalSharePercentage"] = personalShare;
                                expression.Parameters["employerSharePercentage"] = employerShare;
                                expression.Parameters["monthlySalary"] = monthlySalary;

                                object result = expression.Evaluate();

                                if (!string.IsNullOrEmpty(result?.ToString()) && Decimal.TryParse(result.ToString(), out decimal value))
                                {
                                    totalAmount += value;
                                }

                                return totalAmount;
                            }
                        }
                    }

                    return totalAmount;
                }
                else
                {
                    // Handle null contributions or formula if needed
                    return -1;
                }
            }
            catch (SqlException sql)
            {
                // Log or handle the SQL exception
                throw sql;
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                throw ex;
            }
        }

        // Custom function for retrieving the Personal Share Value
        private async Task<decimal> ComputePersonalShareAmount(int benefitsId, decimal monthlySalary)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);
                string formula = await GetBenefitFormula(benefitsId);

                if (contributions != null && formula != null)
                {
                    Expression expression = new Expression(formula);
                    decimal totalAmount = 0;

                    foreach (DataRow row in contributions.Rows)
                    {
                        if (Decimal.TryParse(row["personalShareValue"].ToString(), out decimal personalSharePercentage))
                        {
                            expression.Parameters["personalSharePercentage"] = personalSharePercentage;
                            expression.Parameters["employerSharePercentage"] = 0;
                            expression.Parameters["monthlySalary"] = monthlySalary;

                            object result = expression.Evaluate();

                            if (!string.IsNullOrEmpty(result?.ToString()) && Decimal.TryParse(result.ToString(), out decimal value))
                            {
                                totalAmount += value;
                            }
                            else
                            {
                                // Handle parsing errors or empty result if needed
                            }
                        }
                        else
                        {
                            // Handle parsing errors if needed
                        }
                    }

                    return totalAmount;
                }
                else
                {
                    // Handle null contributions or formula if needed
                    return 0;
                }
            }
            catch (SqlException sql)
            {
                // Log or handle the SQL exception
                throw sql;
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                throw ex;
            }
        }

        // Custom function for retrieving the Employer Share Value
        private async Task<decimal> ComputeEmployerShareAmount(int benefitsId, decimal monthlySalary)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);
                string formula = await GetBenefitFormula(benefitsId);

                if (contributions != null && formula != null)
                {
                    Expression expression = new Expression(formula);
                    decimal totalAmount = 0;

                    foreach (DataRow row in contributions.Rows)
                    {
                        if (decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerSharePercentage))
                        {
                            expression.Parameters["personalSharePercentage"] = 0;
                            expression.Parameters["employerSharePercentage"] = employerSharePercentage;
                            expression.Parameters["monthlySalary"] = monthlySalary;

                            object result = expression.Evaluate();

                            if (!string.IsNullOrEmpty(result?.ToString()) && Decimal.TryParse(result.ToString(), out decimal value))
                            {
                                totalAmount += value;
                            }
                            else
                            {
                                // Handle parsing errors or empty result if needed
                            }
                        }
                        else
                        {
                            // Handle parsing errors if needed
                        }
                    }

                    return totalAmount;
                }
                else
                {
                    // Handle null contributions or formula if needed
                    return 0;
                }
            }
            catch (SqlException sql)
            {
                // Log or handle the SQL exception
                throw sql;
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                throw ex;
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
                List<string> items = new List<string>
                {
                    "Choose benefit/s"
                };

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
                            retiredWarning.Text = $"Notice: {employmentStatus} employee's have a\n {years} year/s contract\n as mandated by LGU - Initao";
                            return DateHired.AddYears(years);
                        }
                        else if (row["numberOfMonths"] != null && int.TryParse(row["numberOfMonths"].ToString(), out int months))
                        {
                            retiredWarning.Text = $"Notice: {employmentStatus} employee's have a\n {months} month/s contract\n as mandated by LGU - Initao";
                            return DateHired.AddMonths(months);
                        }
                        else if ((row["numberOfYears"] != null && row["numberOfMonths"] != null) && int.TryParse(row["numberOfYears"].ToString(),
                            out int numberOfYears) && int.TryParse(row["numberOfMonths"].ToString(), out int numberOfMonths))
                        {
                            DateTime newDate = DateHired.AddYears(numberOfYears);
                            newDate = newDate.AddMonths(numberOfMonths);
                            retiredWarning.Text = $"Notice: {employmentStatus} employee's have a\n {numberOfYears} year/s and {numberOfMonths} month/s " +
                                $"contract\n as mandated by LGU - Initao";
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

        // Function to parse the display the salary value
        private async Task DisplaySalaryRateValue(string salaryRateDescription, int stepNumber)
        {
            try
            {
                int salaryRateId =  await GetSalaryRateId(salaryRateDescription);
                decimal salaryRateValue = await GetSalaryRateValue(salaryRateId, stepNumber);

                salaryRateValueTextBox.Visible = false;
                salaryRateValueLabel.Visible = true;
                salaryRateValueLabel.BringToFront();

                if(salaryRateValue > -1)
                {
                    salaryRateValueLabel.Text = $"{salaryRateValue:C2}";
                }
                else
                {
                    salaryRateValueLabel.Text = $"{-1:C2}";
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Salary Rate Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        // Function responsible for parsing the benefit value of chosen benefits
        private async Task ParsingBenefitContributions(string benefitName, decimal monthlySalary)
        {
            try
            {
                int benefitId = await GetBenefitsId(benefitName);
                DataTable contributions = await GetBenefitContributions(benefitId);

                if (contributions != null && benefitId > -1)
                {
                    foreach (DataRow row in contributions.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["isPercentage"].ToString()) && bool.TryParse(row["isPercentage"].ToString(),
                            out bool isPercentage))
                        {
                            if (!isPercentage)
                            {
                                IsPercentage = false;

                                if (!string.IsNullOrEmpty(row["personalShareValue"].ToString()) && !string.IsNullOrEmpty(row["employerShareValue"].ToString())
                                    && decimal.TryParse(row["personalShareValue"].ToString(), out decimal personalShareValueMoney) &&
                                    decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerShareValueMoney))
                                {
                                    personalShareValue.Enabled = true;
                                    employerShareValue.Enabled = true;
                                    employerShareValue.Texts = $"{employerShareValueMoney:C2}";
                                    personalShareValue.Texts = $"{personalShareValueMoney:C2}";
                                    personalMinimumAmountLabel.Visible = true;
                                    employerMinimumAmountLabel.Visible = true;

                                    personalPercentageWarningLabel.Visible = false;
                                    employerPercentageWarningLabel.Visible = false;
                                }
                                else
                                {
                                    employerShareValue.Texts = $"0";
                                    personalShareValue.Texts = $"0";
                                    employerShareValue.Enabled = false;
                                    personalShareValue.Enabled = false;
                                    personalMinimumAmountLabel.Visible = false;
                                    employerMinimumAmountLabel.Visible = false;
                                    personalPercentageWarningLabel.Visible = false;
                                    employerPercentageWarningLabel.Visible = false;
                                }
                            }
                            else if (!string.IsNullOrEmpty(row["personalShareValue"].ToString()) && decimal.TryParse(row["personalShareValue"].ToString(),
                                out decimal personalShare) && !string.IsNullOrEmpty(row["employerShareValue"].ToString()) &&
                                decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerShare))
                            {

                                decimal personalSharePreviewValue = await ComputePersonalShareAmount(benefitId, monthlySalary);
                                decimal employerSharePreviewValue = await ComputeEmployerShareAmount(benefitId, monthlySalary);

                                employerShareValue.Texts = $"{employerShare}% = {employerSharePreviewValue:C2}";
                                personalShareValue.Texts = $"{personalShare}% = {personalSharePreviewValue:C2}";

                                employerShareValue.Enabled = false;
                                personalShareValue.Enabled = false;

                                personalMinimumAmountLabel.Visible = false;
                                employerMinimumAmountLabel.Visible = false;
                                personalPercentageWarningLabel.Visible = true;
                                employerPercentageWarningLabel.Visible = true;

                                IsPercentage = true;
                            }
                        }
                    }
                }
                else
                {
                    ErrorMessages($"No contributions have been recorded for the benefit '{benefitName}'. " +
                        $"Please contact the system administrator for resolution.", "Benefit Contributions Error");
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

        #endregion

        #region Functions inside serves to communicate with the Employee Class

        // Function responsible for getting the salary rate id
        public async Task<int> GetSalaryRateId(string description)
        {
            try
            {
                int id = await employeeClass.GetSalaryRateDescriptionId(description);
                return id;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the Proper Witholding Tax Rate
        private async Task<DataTable> GetWitholdingTaxRate(decimal basicAnnualSalary)
        {
            try
            {
                DataTable taxRate = await generalFunctions.GetWitholdingTaxRate(basicAnnualSalary);

                if (taxRate != null && taxRate.Rows.Count > 0)
                {
                    return taxRate;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetGeneralFormula(string title)
        {
            try
            {
                string formulaExpression = await generalFunctions.GetGeneralFormula(title);
                return formulaExpression;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for getting the formula of the selected benefit
        private async Task<string> GetBenefitFormula(int benefitId)
        {
            try
            {
                string formula = await generalFunctions.GetBenefitsFormula(benefitId);
                return formula;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetBenefitContributions(int benefitId)
        {
            try
            {
                DataTable contribution = await generalFunctions.GetBenefitContributions(benefitId);

                if (contribution != null && contribution.Rows.Count > 0)
                {
                    return contribution;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetBenefitsId(string benefitName)
        {
            try
            {
                int benefitId = await employeeClass.GetBenefitId(benefitName);
                return benefitId;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
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
        private async Task<decimal> GetSalaryRateValue(int salaryRateId, int stepNumber)
        {
            try
            {
                decimal value = await employeeClass.GetSalaryRateValue(salaryRateId, stepNumber);
                return value;
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
        private async Task<bool> AddSalaryRate(string description, string schedule)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addSalaryRate = await employeeClass.AddSalaryRate(description, schedule);

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

        // This function would be responsible for adding the value of the custom salary rate
        private async Task<bool> AddCustomSalaryValue(string description, decimal value)
        {
            try
            {
                bool addValue = await employeeClass.AddCustomValue(description, value);
                return addValue;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
        private async Task<bool> AddAppointmentForm(int employeeId, decimal amount, DateTime date, DateTime dateHired, DateTime? dateRetired, 
            string schedule, string employmentStatus, string morningShift, string afternoonShift, DateTime dateNextStep)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addAppointmentForm = await employeeClass.AddAppointmentForm(employeeId, amount, date, dateHired, dateRetired, schedule, 
                    employmentStatus, morningShift, afternoonShift, dateNextStep);

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

        private async Task<DataTable> GetBenefitList(string employmentStatus)
        {
            try
            {
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

        private async Task<bool> AddBenefit(int id, int benefitsId, decimal personalShare, decimal employerShare, bool isActive)
        {
            try
            {
                bool addBenefit = await employeeClass.AddEmployeeBenefit(id, benefitsId, personalShare, employerShare, isActive);

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
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Texts) || string.IsNullOrWhiteSpace(lastNameTextBox.Texts))
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
            else if (employmentStatus.Text != "Regular" && dateRetired.Value.Date == DateTime.Today)
            {
                ErrorMessages("Please provide the number of years stated in Contract", "Incomplete Contract Information");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(salaryRate.Text) || salaryRate.SelectedIndex <= -1)
            {
                ErrorMessages("Please choose for the Employee Salary rate or create one", "Salary Rate Selection");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(salaryRateValueTextBox.Texts) && salaryRate.Text.Contains("Custom"))
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

            if(EmploymentStatus == "Regular")
            {
                MessageBox.Show(
                    $"The calculation of deductions for Witholding Tax is pending, as both deductions and benefits need to be " +
                    $"finalized. The employee will be able to view the final tax rate after saving the employee information in the database.",
                    "Pending Tax Rate",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

        private async void addEmployeeModal_Load(object sender, EventArgs e)
        {
            await DataBinding();
            DisplayAccountPanel();
        }

        private void addEmployeeModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearAll();
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

        private async void addBtn0_Click(object sender, EventArgs e)
        {
            try
            {
                await AddNewBenefit(benefitName.Text, PersonalShare, EmployerShare, IsPercentage, benefitList, SalaryRateValue);
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
            bool isUserRoleDepartmentHead = !string.IsNullOrEmpty(userRole.Text) && userRole.Text == "Department Head";
            bool isDepartmentAllowed = DepartmentName == "Mayor's Office" || DepartmentName == "Human Resources Office";

            if (isUserRoleDepartmentHead && isDepartmentAllowed)
            {
                ErrorMessages("The role Department Head is not allowed for the department Mayor's Office or in Human Resources Office",
                    "User Role Restriction Error");
                userRole.SelectedIndex = -1;
            }
            else
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
                if (salaryRate.Text != "Custom" && salaryRate.Text != string.Empty && EmploymentStatus == "Regular")
                {
                    await DisplaySalaryRateValue(salaryRate.Text, defaultStepNumber);
                }
                else if ((salaryRate.Text == "Custom" || string.IsNullOrEmpty(salaryRate.Text)) && EmploymentStatus != "Regular")
                {
                    salaryRateValueLabel.Visible = false;
                    salaryRateValueLabel.Text = string.Empty;
                    salaryRateValueTextBox.Visible = true;
                    salaryRateValueTextBox.BringToFront();

                    int count = await GetCustomCount(salaryRate.Text);

                    if (count >= 0)
                    {
                        SalaryRate = $"{salaryRate.Text}{++count}";
                    }
                    else
                    {
                        ErrorMessages("There is an error in retrieving custom count", "Custom Count Retrieval");
                    }
                }
                else if (EmploymentStatus == "Regular" && salaryRate.Text == "Custom")
                {
                    salaryRate.SelectedIndex = -1;
                    ErrorMessages("A regular employee salary rate must only be chosen from a designated salary grade. " +
                        "Please choose the proper salary grade " +
                        "below", "Invalid Salary Rate");

                    salaryRateValueLabel.Visible = false;
                    salaryRateValueLabel.Text = string.Empty;
                    salaryRateValueTextBox.Visible = true;
                    salaryRateValueTextBox.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, caption: "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: "Salary Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!string.IsNullOrEmpty(salaryRateValueTextBox.Texts) && decimal.TryParse(salaryRateValueTextBox.Texts, out decimal salary) 
                && EmploymentStatus != "Regular")
            {
                int numberOfDays = CountWeekdays(_year, _month);
                SalaryRateValue = salary;
                await ForwardMandatedValue(EmploymentStatus, SalaryRateValue * numberOfDays, benefitList);
            }
        }

        private async void salaryRateValueLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(salaryRateValueLabel.Text) && decimal.TryParse(salaryRateValueLabel.Text, NumberStyles.Currency, 
                CultureInfo.CurrentCulture, out decimal salary) 
                && EmploymentStatus == "Regular")
            {
                salaryRateValueTextBox.Texts = string.Empty;
                SalaryRateValue = salary;
                await ForwardMandatedValue(EmploymentStatus, SalaryRateValue, benefitList);
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
            try
            {
                if (!string.IsNullOrEmpty(employmentStatus.Text) && employmentStatus.SelectedIndex > -1 && employmentStatus.Text != "Regular")
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
                else if (!string.IsNullOrEmpty(employmentStatus.Text) && employmentStatus.SelectedIndex > -1 && employmentStatus.Text == "Regular")
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
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
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
            if (e.KeyChar == '.' && personalShareValue.Texts.Contains("."))
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
            if (!string.IsNullOrEmpty(benefitName.Text) && benefitName.SelectedIndex > 0)
            {
                await ParsingBenefitContributions(benefitName.Text, SalaryRateValue);
            }
            else
            {
                personalShareValue.Texts = string.Empty;
                employerShareValue.Texts = string.Empty;
            }
        }

        private void personalShareValue__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(personalShareValue.Texts) && decimal.TryParse(personalShareValue.Texts,
                NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal personalShare))
            {
                if (personalShare >= PersonalShare)
                {
                    PersonalShare = personalShare;
                }
                else
                {
                    personalShareValue.Enabled = true;
                    personalMinimumAmountLabel.Visible = false;
                    personalMinimumAmountWarning.Text = $"(The user input must be greater than or equal to {PersonalShare:C2}, " +
                        $"which represents the designated minimum value for this benefit!)";
                    personalMinimumAmountWarning.Visible = true;
                    personalMinimumAmountWarning.BringToFront();
                    personalShareValue.Texts = $"{PersonalShare:C2}";
                    IsPercentage = false;
                }
            }
            else
            {
                IsPercentage = true;
                PersonalShare = -1;
            }
        }

        private void employerShareValue__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(employerShareValue.Texts) && decimal.TryParse(employerShareValue.Texts,
                NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal employerValue))
            {
                if (employerValue >= EmployerShare)
                {
                    EmployerShare = employerValue;
                }
                else
                {
                    employerMinimumAmountLabel.Visible = false;
                    employerMinimumAmountWarning.Text = $"(The user input must be greater than or equal to {EmployerShare:C2}, " +
                        "which represents the designated minimum value for this benefit!)";
                    employerMinimumAmountWarning.Visible = true;
                    employerMinimumAmountLabel.BringToFront();
                    employerShareValue.Enabled = true;
                    employerShareValue.Texts = $"{EmployerShare:C2}";
                    IsPercentage = false;
                }
            }
            else
            {
                EmployerShare = -1;
                IsPercentage = true;
            }
        }

        private void addEmployeeModal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Escape key
            if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Do you wish to cancel the addition of a new employee?", "Cancel Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
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

        private async Task<bool> AddCustomSalaryRate(string description, string schedule)
        {
            try
            {
                bool addCustomSalaryRate = await AddSalaryRate(description, schedule);
                return addCustomSalaryRate;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddCustomValue(string description, decimal value)
        {
            try
            {
                bool addValue = await AddCustomSalaryValue(description, value);
                return addValue;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        //Function responsible for adding the new Employee, Appointment Form and Custom Salary Rate if needed
        private async Task<bool> AddNewEmployee(string password)
        {
            try
            {
                EmployeePicture = FirstName.Replace(" ", "") + LastName + MiddleName + Path.GetExtension(employeeImageLocation);
                EmployeeSignature = FirstName.Replace(" ", "") + LastName + MiddleName + Path.GetExtension(employeeSignatureLocation);
                MessageBox.Show(EmployeePicture);
                MessageBox.Show(EmployeeSignature);
                File.Copy(employeeImageLocation, $"{employeeImageDestination}{EmployeePicture}", true);
                File.Copy(employeeSignatureLocation, $"{employeeSignatureDestination}{EmployeeSignature}", true);

                bool addSalaryRate = false;
                bool addValue = false;
                bool addEmployee = false;
                bool addAppointmentForm = false;

                if (SalaryRate.Contains("Custom"))
                {
                    addSalaryRate = await AddCustomSalaryRate(SalaryRate, CustomSchedule);
                    addValue = await AddCustomValue(SalaryRate, SalaryRateValue);
                    addEmployee = await AddEmployee(password, EmployeePicture, EmployeeSignature);
                    addAppointmentForm = await AddAppointmentForm(EmployeeID, SalaryRateValue, DateTime.Today, DateHired, DateRetired, SalarySchedule, 
                        EmploymentStatus, MorningShift, AfternoonShift, DateHired.AddYears(numberOfYears));
                }
                else
                {
                    addSalaryRate = true;
                    addEmployee = await AddEmployee(password, EmployeePicture, EmployeeSignature);
                    addAppointmentForm = await AddAppointmentForm(EmployeeID, SalaryRateValue, DateTime.Today, DateHired, DateRetired, SalarySchedule, 
                        EmploymentStatus, MorningShift, AfternoonShift, DateHired.AddYears(numberOfYears));
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
        private async Task<bool> AddEmployeeBenefit(int employeeId, bool status)
        {
            try
            {
                if (benefitList.Count > 0)
                {
                    foreach (var benefit in benefitList)
                    {

                        bool addEmployeeBenefit = await AddBenefit(employeeId, benefit.Item1, benefit.Item3, benefit.Item2, status);

                        if (!addEmployeeBenefit)
                        {
                            ErrorMessages($"An error occurred while adding the benefit number {benefit.Item1}. Please review the provided details and try again.",
                            "Benefit Addition Error");
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

                MessageBox.Show("1st");

                bool isAuthorized = await IsAuthorized(_userId);
                if (!isAuthorized)
                    return;

                MessageBox.Show("2nd");

                string password = PasswordGenerator(EmployeeID.ToString());
                if (string.IsNullOrEmpty(password))
                    return;

                MessageBox.Show("3rd");

                bool addEmployee = await AddNewEmployee(password);
                if (!addEmployee)
                    return;

                MessageBox.Show("4th");

                bool addBenefit = await AddEmployeeBenefit(EmployeeID, status);
                if (!addBenefit)
                    return;

                MessageBox.Show("5th");

                bool addLeaveCredits = await AddLeaveCredits(EmployeeID, EmploymentStatus);
                if (!addLeaveCredits)
                    return;

                MessageBox.Show("6");

                bool addSlip = await SubmitSlipHours(EmployeeID, _month, _year, numberOfMonth, defaultHours);
                if (!addSlip)
                    return;

                MessageBox.Show("7th");

                bool addDtr = await AddNewDTRLog(EmployeeID);
                if(!addDtr) 
                    return;

                MessageBox.Show("8th");

                string userName = await UserDetails(_userId);
                if (string.IsNullOrEmpty(userName))
                    return;

                MessageBox.Show("9th");

                bool addNewLog = await AddNewLog(userName, $"{FirstName} {LastName}", EmployeeID);
                if(!addNewLog)
                    return;

                this.Close();
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
    }
}
