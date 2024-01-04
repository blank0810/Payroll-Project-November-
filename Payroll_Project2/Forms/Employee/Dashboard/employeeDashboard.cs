using NCalc;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control;
using Payroll_Project2.Forms.Employee.Dashboard.Modals;
using Payroll_Project2.Forms.Employee.File_leave;
using Payroll_Project2.Forms.Employee.File_Pass_Slip;
using Payroll_Project2.Forms.Employee.File_Travel_Order;
using Payroll_Project2.Forms.Employee.Leave_Logs;
using Payroll_Project2.Forms.Employee.Pass_Slip_Logs;
using Payroll_Project2.Forms.Employee.Personal_DTR;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Dashboard
{
    public partial class employeeDashboard : Form
    {
        private static int _userId;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static int numberOfMonths = DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1;
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string EmployeeSignaturePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeSignaturePath");
        private static readonly string MonthlyToAnnualTitle = ConfigurationManager.AppSettings.Get("MonthlyToAnnualTitle");
        private static readonly string TaxValuePerMonthTitle = ConfigurationManager.AppSettings.Get("TaxValuePerMonthTitle");
        private static readonly string BasicAnnualSalaryTitle = ConfigurationManager.AppSettings.Get("BasicAnnualSalaryTitle");
        private static readonly string AnnualValueDeductionsTitle = ConfigurationManager.AppSettings.Get("AnnualValueDeductionsTitle");

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string JobDescription { get; set; }
        public string EmailAddress { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string MobileNumber { get; set; }
        public string DepartmentName { get; set; }
        public string AccountStatus { get; set; }
        public string AccessLevel { get; set; }
        public string TelephoneNumber { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string EducationalAttainment { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Course { get; set; }
        public string SalaryRate { get; set; }
        public string SalaryValue { get; set; }
        public string PayrollSchedule { get; set; }
        public string EmploymentStatus { get; set; }
        public string DateHired { get; set; }
        public string DateResigned { get; set; }
        public string EmployeeSignature { get; set; }
        public string EmployeeImage { get; set; }
        public string Password { get; set; }

        public employeeDashboard()
        {
            InitializeComponent();
        }

        private async Task<string> GetDepartment(int employeeId)
        {
            try
            {
                string department = await generalFunctions.GetPersonnelDepartment(employeeId);

                if (department != null)
                {
                    return department;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //Function responsible for remmitanc report
        private async Task<DataTable> GetBenefitRemmitance(int employeeId, int benefitId)
        {
            try
            {
                DataTable remmitance = await generalFunctions.GetBenefitRemmitance(employeeId, benefitId);

                if (remmitance != null && remmitance.Rows.Count > 0)
                {
                    return remmitance;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the employee's Benefits
        private async Task<DataTable> GetEmployeeBenefit(int formId)
        {
            try
            {
                DataTable benefitList = await generalFunctions.GetEmployeeBenefits(formId);
                if (benefitList != null)
                {
                    return benefitList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the active employee benefits
        private async Task<DataTable> GetActiveEmployeeBenefit(int formId)
        {
            try
            {
                DataTable activeBenefit = await generalFunctions.GetActiveEmployeeBenefits(formId);

                if (activeBenefit != null && activeBenefit.Rows.Count > 0)
                {
                    return activeBenefit;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the General Formula
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

        // Function responsible for getting the benefits contributions value
        private async Task<DataTable> GetBenefitContributions(int benefitsId)
        {
            try
            {
                DataTable contribution = await generalFunctions.GetBenefitContributions(benefitsId);

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

        // Custom function for retrieving the Value of the benefit
        private async Task<decimal> ComputeBenefitContributionsAmount(int benefitsId, decimal monthlySalary)
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
                        if (Decimal.TryParse(row["personalShareValue"].ToString(), out decimal personalSharePercentage) &&
                            Decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerSharePercentage))
                        {
                            expression.Parameters["personalSharePercentage"] = personalSharePercentage;
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

        // Custom function for retrieving the Personal Share Percentage
        private async Task<decimal> GetPersonalSharePercentage(int benefitsId)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);

                if (contributions != null)
                {
                    foreach (DataRow row in contributions.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["personalShareValue"]?.ToString()) && decimal.TryParse(row["personalShareValue"].ToString(),
                            out decimal personalPercentage))
                        {
                            return personalPercentage;
                        }
                    }

                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for retrieving the Personal Share Percentage
        private async Task<decimal> GetEmployerSharePercentage(int benefitsId)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitsId);

                if (contributions != null)
                {
                    foreach (DataRow row in contributions.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["personalShareValue"]?.ToString()) && decimal.TryParse(row["employerShareValue"].ToString(),
                            out decimal employerPercentage))
                        {
                            return employerPercentage;
                        }
                    }

                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for getting the amount of benefit value from the contributions
        // Applicable only to the benefits that is with mandated percentages and not fixed values
        private async Task<decimal> GetBenefitValue(int benefitId, decimal monthlySalary)
        {
            try
            {
                DataTable contributions = await GetBenefitContributions(benefitId);
                string formula = await GetBenefitFormula(benefitId);

                if (contributions != null && !string.IsNullOrEmpty(formula))
                {
                    Expression expression = new Expression(formula);
                    decimal totalAmount = 0;

                    foreach (DataRow row in contributions.Rows)
                    {
                        if (Decimal.TryParse(row["personalShareValue"].ToString(), out decimal personalSharePercentage) &&
                            Decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerSharePercentage))
                        {
                            expression.Parameters["personalSharePercentage"] = personalSharePercentage;
                            expression.Parameters["employerSharePercentage"] = employerSharePercentage;
                            expression.Parameters["monthlySalary"] = monthlySalary;

                            object result = expression.Evaluate();

                            if (result != null && !string.IsNullOrEmpty(result.ToString()) && decimal.TryParse(result.ToString(),
                                out decimal benefitValue))
                            {
                                totalAmount += benefitValue;
                            }
                        }
                    }

                    return totalAmount;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for computing the annual deduction
        private decimal AnnualDeductionValue(decimal totalAmout, int numberOfMonth, string formulaExpression)
        {
            try
            {
                Expression expression = new Expression(formulaExpression);

                expression.Parameters["totalValue"] = totalAmout;
                expression.Parameters["numberOfMonthsInAYear"] = numberOfMonth;

                object result = expression.Evaluate();

                if (!string.IsNullOrEmpty(result?.ToString()) && decimal.TryParse(result.ToString(), out decimal value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for computing the annual salary
        private decimal AnnualSalaryValue(decimal monthlySalary, int numberOfMonth, string formula)
        {
            try
            {
                Expression expression = new Expression(formula);

                expression.Parameters["monthlySalary"] = monthlySalary;
                expression.Parameters["numberOfMonthsInAYear"] = numberOfMonth;

                object result = expression.Evaluate();

                if (result != null && !string.IsNullOrEmpty(result.ToString()) && decimal.TryParse(result.ToString(),
                    out decimal value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for computing the basic annual salary
        private decimal BasicAnnualSalaryValue(decimal annualSalary, decimal annualDeduction, string formula)
        {
            try
            {
                Expression expression = new Expression(formula);

                expression.Parameters["totalAnnualSalary"] = annualSalary;
                expression.Parameters["totalAnnualDeductions"] = annualDeduction;

                object result = expression.Evaluate();

                if (result != null && !string.IsNullOrEmpty(result.ToString()) && decimal.TryParse(result.ToString(),
                    out decimal value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for computing the annual salary tax rate
        private async Task<decimal> AnnualTaxRateValue(decimal basicAnnualSalary, string formula)
        {
            try
            {
                DataTable parameters = await GetWitholdingTaxRate(basicAnnualSalary);

                if (parameters != null)
                {
                    Expression expression = new Expression(formula);
                    decimal amount = 0;

                    foreach (DataRow row in parameters.Rows)
                    {
                        expression.Parameters["basicAnnualSalary"] = basicAnnualSalary;

                        if (!string.IsNullOrEmpty(row["amountExcess"].ToString()) && decimal.TryParse(row["amountExcess"].ToString(),
                            out decimal amountExcess))
                        {
                            expression.Parameters["amountExcess"] = amountExcess;
                        }
                        else
                        {
                            expression.Parameters["amountExcess"] = 0;
                        }

                        if (!string.IsNullOrEmpty(row["percentageToBeDeducted"].ToString()) && decimal.TryParse(row["percentageToBeDeducted"].ToString(),
                            out decimal percentageToBeDededucted))
                        {
                            expression.Parameters["percentageToBeDeducted"] = percentageToBeDededucted;
                        }
                        else
                        {
                            expression.Parameters["percentageToBeDeducted"] = 0;
                        }

                        if (!string.IsNullOrEmpty(row["amountToBeDeducted"].ToString()) && decimal.TryParse(row["amountToBeDeducted"].ToString(),
                            out decimal amountToBeDeducted))
                        {
                            expression.Parameters["amountToBeDeducted"] = amountToBeDeducted;
                        }

                        object result = expression.Evaluate();

                        if (result != null && !string.IsNullOrEmpty(result.ToString()) && decimal.TryParse(result.ToString(),
                            out decimal value))
                        {
                            amount += value;
                        }
                    }

                    return amount;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function to compute the witholding tax total amount
        private async Task<decimal> ComputeWitholdingTaxPerMonth(int benefitsId, decimal monthlySalary, string monthlyToAnnualTitle,
            string basicAnnualSalaryTitle, string taxValuePerMonthTitle, string annualValueDeductionsTitle, int numberOfMonth, int employeeId)
        {
            try
            {
                DataTable benefitList = await GetActiveEmployeeBenefit(employeeId);
                decimal annualSalary = 0;
                decimal basicAnnualSalary = 0;
                decimal taxValue = 0;
                decimal annualDeduction = 0;
                decimal totalAmount = 0;
                string monthlyToAnnualSalary = await GetGeneralFormula(monthlyToAnnualTitle);
                string gettingBasicAnnualSalary = await GetGeneralFormula(basicAnnualSalaryTitle);
                string taxValuePerMonth = await GetGeneralFormula(taxValuePerMonthTitle);
                string annualValueDeduction = await GetGeneralFormula(annualValueDeductionsTitle);
                string witholdingTaxFormula = await GetBenefitFormula(benefitsId);

                if (benefitList != null && !string.IsNullOrEmpty(monthlyToAnnualTitle) && !string.IsNullOrEmpty(gettingBasicAnnualSalary) &&
                    !string.IsNullOrEmpty(taxValuePerMonth) && !string.IsNullOrEmpty(annualValueDeduction) &&
                    !string.IsNullOrEmpty(witholdingTaxFormula))
                {
                    foreach (DataRow row in benefitList.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["benefitsValue"].ToString()) && decimal.TryParse(row["benefitsValue"].ToString(),
                            out decimal value))
                        {
                            totalAmount += value;
                        }
                        else if (string.IsNullOrEmpty(row["benefitsValue"].ToString()) && int.TryParse(row["benefitsId"].ToString(),
                            out int newBenefitId))
                        {
                            totalAmount += await GetBenefitValue(newBenefitId, monthlySalary);
                        }
                    }
                }

                annualSalary = AnnualSalaryValue(monthlySalary, numberOfMonth, monthlyToAnnualSalary);
                annualDeduction = AnnualDeductionValue(totalAmount, numberOfMonth, annualValueDeduction);
                basicAnnualSalary = BasicAnnualSalaryValue(annualSalary, annualDeduction, gettingBasicAnnualSalary);
                taxValue = await AnnualTaxRateValue(basicAnnualSalary, witholdingTaxFormula);

                Expression expression = new Expression(taxValuePerMonth);

                expression.Parameters["totalTax"] = taxValue;
                expression.Parameters["numberOfMonthsInAYear"] = numberOfMonth;

                object result = expression.Evaluate();

                if (result != null && !string.IsNullOrEmpty(result.ToString()) && decimal.TryParse(result.ToString(), out decimal witholdingTaxValue))
                {
                    return witholdingTaxValue;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for getting the tax rate description for the witholding tax
        private async Task<string> GetWitholdingTaxRateDescription(int benefitsId, decimal monthlySalary, string monthlyToAnnualTitle, int employeeId,
            string basicAnnualSalaryTitle, string taxValuePerMonthTitle, string annualValueDeductionsTitle, int numberOfMonth)
        {
            try
            {
                DataTable benefitList = await GetEmployeeBenefit(employeeId);
                decimal annualSalary = 0;
                decimal basicAnnualSalary = 0;
                decimal annualDeduction = 0;
                decimal totalAmount = 0;
                string monthlyToAnnualSalary = await GetGeneralFormula(monthlyToAnnualTitle);
                string gettingBasicAnnualSalary = await GetGeneralFormula(basicAnnualSalaryTitle);
                string taxValuePerMonth = await GetGeneralFormula(taxValuePerMonthTitle);
                string annualValueDeduction = await GetGeneralFormula(annualValueDeductionsTitle);
                string witholdingTaxFormula = await GetBenefitFormula(benefitsId);

                if (benefitList != null && !string.IsNullOrEmpty(monthlyToAnnualTitle) && !string.IsNullOrEmpty(gettingBasicAnnualSalary) &&
                    !string.IsNullOrEmpty(taxValuePerMonth) && !string.IsNullOrEmpty(annualValueDeduction) &&
                    !string.IsNullOrEmpty(witholdingTaxFormula))
                {
                    foreach (DataRow row in benefitList.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["benefitsValue"].ToString()) && decimal.TryParse(row["benefitsValue"].ToString(),
                            out decimal value))
                        {
                            totalAmount += value;
                        }
                        else if (string.IsNullOrEmpty(row["benefitsValue"].ToString()) && int.TryParse(row["benefitsId"].ToString(),
                            out int newBenefitId))
                        {
                            totalAmount += await GetBenefitValue(newBenefitId, monthlySalary);
                        }
                    }
                }

                annualSalary = AnnualSalaryValue(monthlySalary, numberOfMonth, monthlyToAnnualSalary);
                annualDeduction = AnnualDeductionValue(totalAmount, numberOfMonth, annualValueDeduction);
                basicAnnualSalary = BasicAnnualSalaryValue(annualSalary, annualDeduction, gettingBasicAnnualSalary);
                DataTable getRate = await GetWitholdingTaxRate(basicAnnualSalary);

                if (getRate != null)
                {
                    foreach (DataRow row in getRate.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["taxRateDescription"].ToString()))
                        {
                            return $"{row["taxRateDescription"]}";
                        }
                    }
                }

                return null;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void employeeDashboard_Load(object sender, EventArgs e)
        {
            DataBinding();
            personalLeaveSubPanel.Visible = false;
            personalTravelSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;
        }

        // Function that responsible for retrieving automated application number for the application for leave creation
        private async Task<int> GetApplicationNumber()
        {
            try
            {
                int applicationNumber = await generalFunctions.GetApplicationNumber();

                if (applicationNumber >= 0)
                {
                    return ++applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function that responsible for retrieving the automated control number for the pass slip creation
        private async Task<int> GetSlipControlNumber()
        {
            try
            {
                int applicationNumber = await generalFunctions.GetSlipControlNumber();

                if (applicationNumber >= 0)
                {
                    return ++applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function that responsible for retrieving the automated control number of the travel order creation
        private async Task<int> GetTravelControlNumber()
        {
            try
            {
                int applicationNumber = await generalFunctions.GetTravelControlNumber();

                if (applicationNumber >= 0)
                {
                    return ++applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void DataBinding()
        {
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            generalEmployeeName.DataBindings.Add("Text", this, "EmployeeName");
            emailAddress.DataBindings.Add("Text", this, "EmailAddress");
            generalEmailAddress.DataBindings.Add("Text", this, "EmailAddress");
            barangay.DataBindings.Add("Text", this, "Barangay");
            municipality.DataBindings.Add("Text", this, "Municipality");
            province.DataBindings.Add("Text", this, "Province");
            zipCode.DataBindings.Add("Text", this, "ZipCode");
            mobileNumber.DataBindings.Add("Text", this, "MobileNumber");
            generalMobileNumber.DataBindings.Add("Text", this, "MobileNumber");
            birthday.DataBindings.Add("Text", this, "Birthday");
            gender.DataBindings.Add("Text", this, "Gender");
            civilStatus.DataBindings.Add("Text", this, "CivilStatus");
            accessLevel.DataBindings.Add("Text", this, "AccessLevel");
            generalAccountStatus.DataBindings.Add("Text", this, "AccountStatus");
            educationalAttainment.DataBindings.Add("Text", this, "EducationalAttainment");
            schoolName.DataBindings.Add("Text", this, "SchoolName");
            schoolAddress.DataBindings.Add("Text", this, "SchoolAddress");
            course.DataBindings.Add("Text", this, "Course");
            employeeID.DataBindings.Add("Text", this, "EmployeeID");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            generalDepartmentName.DataBindings.Add("Text", this, "DepartmentName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            generalJobDescription.DataBindings.Add("Text", this, "JobDescription");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            salaryValue.DataBindings.Add("Text", this, "SalaryValue");
            payrollSchedule.DataBindings.Add("Text", this, "PayrollSchedule");
            employmentStatus.DataBindings.Add("Text", this, "EmploymentStatus");
            dateHired.DataBindings.Add("Text", this, "DateHired");
            dateResigned.DataBindings.Add("Text", this, "DateResigned");
            employeePicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");

            DisplayGeneral();
        }

        private void DisplayGeneral()
        {
            generalPanel.Visible = true;
            educationPanel.Visible = false;
            employmentPanel.Visible = false;

            generalBtn.BorderColor = Color.DodgerBlue;
            generalBtn.ForeColor = Color.DodgerBlue;
            educationBtn.BorderColor = Color.Transparent;
            educationBtn.ForeColor = Color.DimGray;
            employmentBtn.BorderColor = Color.Transparent;
            employmentBtn.ForeColor = Color.DimGray;
        }

        private void DisplayEducation()
        {
            generalPanel.Visible = false;
            educationPanel.Visible = true;
            employmentPanel.Visible = false;

            generalBtn.BorderColor = Color.Transparent;
            generalBtn.ForeColor = Color.DimGray;
            educationBtn.BorderColor = Color.DodgerBlue;
            educationBtn.ForeColor = Color.DodgerBlue;
            employmentBtn.BorderColor = Color.Transparent;
            employmentBtn.ForeColor = Color.DimGray;
        }

        private async Task UpdateModal()
        {
            updateModal update = new updateModal(_userId, this);

            update.EmailAddress = EmailAddress;
            update.MobileNumber = MobileNumber;
            update.ZipCode = ZipCode;
            update.Province = Province;
            update.Municipality = Municipality;
            update.Barangay = Barangay;
            update.Gender = Gender;
            update.Password = Password;
            update.ShowDialog();
        }

        private async Task DisplayEmployment()
        {
            generalPanel.Visible = false;
            educationPanel.Visible = false;
            employmentPanel.Visible = true;

            generalBtn.BorderColor = Color.Transparent;
            generalBtn.ForeColor = Color.DimGray;
            educationBtn.BorderColor = Color.Transparent;
            educationBtn.ForeColor = Color.DimGray;
            employmentBtn.BorderColor = Color.DodgerBlue;
            employmentBtn.ForeColor = Color.DodgerBlue;

            await DisplayBenefits(_userId);
        }

        private async Task DisplayBenefits(int employeeId)
        {
            try
            {
                benefitListPanel.Controls.Clear();
                DataTable benefitList = await GetEmployeeBenefit(employeeId);

                if (benefitList != null && benefitList.Rows.Count > 0)
                {
                    for (int i = 0; i < benefitList.Rows.Count; i++)
                    {
                        benefitDataUC[] details = new benefitDataUC[benefitList.Rows.Count];
                        DataRow row = benefitList.Rows[i];

                        details[i] = new benefitDataUC(employeeId, this);

                        if (int.TryParse(row["detailsId"].ToString(), out int id))
                        {
                            details[i].DetailsID = id;
                        }
                        else
                        {
                            details[i].DetailsID = 0;
                        }

                        if (row["benefits"] != null)
                        {
                            details[i].BenefitName = row["benefits"].ToString();
                        }
                        else
                        {
                            details[i].BenefitName = "Not Set";
                        }

                        if (row["isBenefitActive"] != null && bool.TryParse(row["isBenefitActive"].ToString(), out
                            bool isActive))
                        {
                            if (isActive)
                            {
                                details[i].BenefitStatus = "Active";
                            }
                            else
                            {
                                details[i].BenefitStatus = "Inactive";
                            }
                        }
                        else
                        {
                            details[i].BenefitStatus = "Not Set";
                        }

                        if (row["benefitsValue"] != null && decimal.TryParse(row["benefitsValue"].ToString(), out decimal value) &&
                            !string.IsNullOrEmpty(row["personalShareValue"].ToString()) && !string.IsNullOrEmpty(row["employerShareValue"].ToString())
                             && decimal.TryParse(row["personalShareValue"].ToString(), out decimal personalShare) &&
                             decimal.TryParse(row["employerShareValue"].ToString(), out decimal employerShare))
                        {
                            details[i].BenefitValue = $"{value:C2}";
                            details[i].RateDescriptions = $"Employer Share = {employerShare:C2}\n" +
                                $"Personal Share = {personalShare:C2}";
                        }
                        else if (string.IsNullOrEmpty(row["benefitsValue"].ToString()) && details[i].BenefitName != "Witholding Tax" &&
                            decimal.TryParse(SalaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal monthlySalary)
                            && int.TryParse(row["benefitsId"].ToString(), out int benefitsId))
                        {
                            decimal benefitValue = await ComputeBenefitContributionsAmount(benefitsId, monthlySalary);
                            decimal personalShareValue = await ComputePersonalShareAmount(benefitsId, monthlySalary);
                            decimal employerShareValue = await ComputeEmployerShareAmount(benefitsId, monthlySalary);
                            decimal personalPercentage = await GetPersonalSharePercentage(benefitsId);
                            decimal employerPercentage = await GetEmployerSharePercentage(benefitsId);

                            details[i].BenefitValue = $"{benefitValue:C2}";
                            details[i].RateDescriptions = $"Personal Share is {personalPercentage}% = {personalShareValue:C2}\n" +
                                $"Employer Share is {employerPercentage}% = {employerShareValue:C2}";
                        }
                        else if (string.IsNullOrEmpty(row["benefitsValue"].ToString()) && details[i].BenefitName == "Witholding Tax" &&
                            decimal.TryParse(SalaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal newMonthlySalary)
                            && int.TryParse(row["benefitsId"].ToString(), out int newBenefitsId))
                        {
                            decimal amount = await ComputeWitholdingTaxPerMonth(newBenefitsId, newMonthlySalary, MonthlyToAnnualTitle, BasicAnnualSalaryTitle,
                                TaxValuePerMonthTitle, AnnualValueDeductionsTitle, numberOfMonths, employeeId);
                            details[i].BenefitValue = $"{amount:C2}";

                            string rate = await GetWitholdingTaxRateDescription(newBenefitsId, newMonthlySalary, MonthlyToAnnualTitle, employeeId,
                                BasicAnnualSalaryTitle, TaxValuePerMonthTitle, AnnualValueDeductionsTitle, numberOfMonths);

                            if (!string.IsNullOrEmpty(rate))
                            {
                                details[i].RateDescriptions = rate;
                            }
                            else
                            {
                                details[i].RateDescriptions = string.Empty;
                            }
                        }
                        else
                        {
                            details[i].BenefitValue = $"{0:C2}";
                        }

                        benefitListPanel.Controls.Add(details[i]);
                    }
                }
                else
                {
                    ErrorMessage("No benefits have been designated for the employee. Please ensure that at least one benefit is " +
                    "assigned to the employee before proceeding.", "No Designated Benefits");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task DisplayContributions(int employeeId, int benefitId)
        {
            try
            {
                benefitListPanel.Controls.Clear();
                DataTable contributions = await GetBenefitRemmitance(employeeId, benefitId);

                if (contributions != null && contributions.Rows.Count > 0)
                {
                    benefitInformationUC[] contributionsList = new benefitInformationUC[contributions.Rows.Count];

                    for (int i = 0; i < contributions.Rows.Count; i++)
                    {
                        contributionsList[i] = new benefitInformationUC();
                        DataRow row = contributions.Rows[i];

                        if (!string.IsNullOrEmpty(row["dateCreated"].ToString()))
                        {
                            DateTime month = DateTime.Parse(row["dateCreated"].ToString());

                            contributionsList[i].Month = month.ToString("MMM, yyyy");
                        }
                        else
                        {
                            contributionsList[i].Month = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["payrollId"].ToString()))
                        {
                            int payrollId = int.Parse(row["payrollId"].ToString());

                            contributionsList[i].PayrollID = payrollId;
                        }
                        else
                        {
                            contributionsList[i].PayrollID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["deductionAmount"].ToString()) && decimal.TryParse(row["deductionAmount"].ToString(),
                            out decimal amount))
                        {
                            contributionsList[i].TotalValue = $"{amount:C2}";
                        }
                        else
                        {
                            contributionsList[i].TotalValue = $"{0:C2}";
                        }

                        benefitListPanel.Controls.Add(contributionsList[i]);
                    }

                    label22.Visible = true;
                    label24.Visible = true;
                    label26.Visible = true;
                    label30.Visible = true;
                    returnBtn.Visible = true;

                    label48.Visible = false;
                    label47.Visible = false;
                    label46.Visible = false;
                    label21.Visible = false;
                }
                else
                {
                    MessageBox.Show("No Records Found for Contributions Designated to This Specific Benefit", "No Contribution Records",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await DisplayBenefits(employeeId);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Custom function responsible for showing employee signature
        public void DisplaySignature()
        {
            try
            {
                employeeSignatureModal signatureModal = new employeeSignatureModal(_userId, this);

                signatureModal.EmployeeFullName = EmployeeName;
                signatureModal.EmployeeId = EmployeeID;
                signatureModal.EmployeeSignature = EmployeeSignature;
                signatureModal.ResponseText = EmployeeSignature;
                signatureModal.DateCaptured = DateHired;
                signatureModal.ShowDialog();
            }
            catch (SqlException sql) { ErrorMessage(sql.Message, "Sql Error"); }
            catch (Exception ex) { ErrorMessage(ex.Message, "Error"); }
        }

        // Custom function responsible for displaying an errorr messages when an exception/error is encountered
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Custom function responsible for displaying a success message after every sucessfull transaction
        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task ReturnBehaviour()
        {
            label22.Visible = false;
            label24.Visible = false;
            label26.Visible = false;
            returnBtn.Visible = false;

            label48.Visible = true;
            label47.Visible = true;
            label46.Visible = true;

            await DisplayBenefits(_userId);
        }

        public async Task ContributionsBehaviour(int benefitId)
        {
            await DisplayContributions(_userId, benefitId);
        }

        public async Task DisplayFileLeave()
        {
            try
            {
                int applicationNumber = await GetApplicationNumber();
                content.Controls.Clear();
                fileLeaveUC fileLeave = new fileLeaveUC();
                fileLeave.ApplicationNumber = applicationNumber;

                if (!content.Controls.Contains(fileLeave))
                {
                    content.Controls.Add(fileLeave);
                    fileLeave.Dock = DockStyle.Fill;
                    fileLeave.BringToFront();
                }
                else
                {
                    fileLeave.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        public async Task DisplayFilePassSlip()
        {
            try
            {
                int controlNumber = await GetSlipControlNumber();
                content.Controls.Clear();
                filePassSlipUC passSlip = new filePassSlipUC();
                passSlip.ControlNumber = controlNumber;

                if (!content.Controls.Contains(passSlip))
                {
                    content.Controls.Add(passSlip);
                    passSlip.Dock = DockStyle.Fill;
                    passSlip.BringToFront();
                }
                else
                {
                    passSlip.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        public async Task DisplayFileTravelOrder()
        {
            try
            {
                int controlNumber = await GetTravelControlNumber();
                content.Controls.Clear();
                fileTravelOrderUC fileTravel = new fileTravelOrderUC();
                fileTravel.ControlNumber = controlNumber;

                if (!content.Controls.Contains(fileTravel))
                {
                    content.Controls.Add(fileTravel);
                    fileTravel.Dock = DockStyle.Fill;
                    fileTravel.BringToFront();
                }
                else
                {
                    fileTravel.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        private void personalProfileUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void generalBtn_Click(object sender, EventArgs e)
        {
            DisplayGeneral();
        }

        private void educationBtn_Click(object sender, EventArgs e)
        {
            DisplayEducation();
        }

        private async void employmentBtn_Click(object sender, EventArgs e)
        {
            await DisplayEmployment();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            await UpdateModal();
        }

        private async void returnBtn_Click(object sender, EventArgs e)
        {
            await ReturnBehaviour();
        }

        private void employeeSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplaySignature();
        }

        private void profileBtn_Click_1(object sender, EventArgs e)
        {
            content.Controls.Clear();

            if(!content.Controls.Contains(dashboardPanel))
            {
                content.Controls.Add(dashboardPanel);
                dashboardPanel.Dock = DockStyle.Fill;
                dashboardPanel.BringToFront();
            }
            else
            {
                dashboardPanel.BringToFront();
            }
        }

        private void personalDTRBtn_Click(object sender, EventArgs e)
        {
            personalDTR dtr = new personalDTR();
            content.Controls.Clear();

            if (!content.Controls.Contains(dtr))
            {
                content.Controls.Add(dtr);
                dtr.Dock = DockStyle.Fill;
                dtr.BringToFront();
            }
            else
            {
                dtr.BringToFront();
            }
        }

        private void personalLeaveBtn_Click(object sender, EventArgs e)
        {
            personalTravelSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;

            if (personalLeaveSubPanel.Visible)
            {
                personalLeaveSubPanel.Visible = false;
            }
            else
            {
                personalLeaveSubPanel.Visible = true;
            }
        }

        private async void personalFileLeaveBtn_Click(object sender, EventArgs e)
        {
            await DisplayFileLeave();
            //fileLeaveModal fileLeave = new fileLeaveModal(_userId, this);
            //fileLeave.ShowDialog();
        }

        private void leaveLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = leaveLogsBtn.Text;
            leaveLogsUC leaveLogs = new leaveLogsUC();
            content.Controls.Clear();

            if (!content.Controls.Contains(leaveLogs))
            {
                content.Controls.Add(leaveLogs);
                leaveLogs.Dock = DockStyle.Fill;
                leaveLogs.BringToFront();
            }
            else
            {
                leaveLogs.BringToFront();
            }
        }

        private void personalTravelBtn_Click(object sender, EventArgs e)
        {
            personalLeaveSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;

            if (personalTravelSubPanel.Visible)
            {
                personalTravelSubPanel.Visible = false;
            }
            else
            {
                personalTravelSubPanel.Visible = true;
            }
        }

        private async void fileTravelBtn_Click(object sender, EventArgs e)
        {
            await DisplayFileTravelOrder();
            //fileTravelOrderModal travelOrder = new fileTravelOrderModal(_userId, this);
            //travelOrder.ShowDialog();
        }

        private void travelLogsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be soon release", "Unavailable Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*titleLabel.Text = travelLogsBtn.Text;
            travelOrderLogUC travelOrderLog = new travelOrderLogUC(_userId, this);
            content.Controls.Clear();

            if (!content.Controls.Contains(travelOrderLog))
            {
                content.Controls.Add(travelOrderLog);
                travelOrderLog.Dock = DockStyle.Fill;
                travelOrderLog.BringToFront();
            }
            else
            {
                travelOrderLog.BringToFront();
            }*/
        }

        private void personalSlipBtn_Click(object sender, EventArgs e)
        {
            personalLeaveSubPanel.Visible = false;
            personalLeaveSubPanel.Visible = false;

            if (personalSlipSubPanel.Visible)
            {
                personalSlipSubPanel.Visible = false;
            }
            else
            {
                personalSlipSubPanel.Visible = true;
            }
        }

        private async void fileSlipBtn_Click(object sender, EventArgs e)
        {
            await DisplayFilePassSlip();

            //filePassSlipModal fileSlip = new filePassSlipModal(_userId, this);
            //Slip.ShowDialog();
        }

        private void slipLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = slipLogsBtn.Text;
            slipLogsUC slipLogs = new slipLogsUC();
            content.Controls.Clear();

            if (!content.Controls.Contains(slipLogs))
            {
                content.Controls.Add(slipLogs);
                slipLogs.Dock = DockStyle.Fill;
                slipLogs.BringToFront();
            }
            else
            {
                slipLogs.BringToFront();
            }
        }

        private void personalPayslipBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be soon release", "Unavailable Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*titleLabel.Text = personalPayslipBtn.Text;
            HideDepartmentPortal();
            payslipLogsUC payslip = new payslipLogsUC(_userId, this);
            content.Controls.Clear();

            if (!content.Controls.Contains(payslip))
            {
                content.Controls.Add(payslip);
                payslip.Dock = DockStyle.Fill;
                payslip.BringToFront();
            }
            else
            {
                payslip.BringToFront();
            }*/
        }
    }
}
