using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Human_Resource_Management.Payroll.User_Controls;
using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using NCalc;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using Payroll_Project2.Forms.Personnel.Dashboard;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Payroll_Project2.Forms.Personnel.Payroll.Modal
{

    public partial class payslip : Form
    {
        private static int _userId;
        private static employeeList _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly payrollClass payrollClass = new payrollClass();
        private static readonly string PayrollDefaultStatus = ConfigurationManager.AppSettings.Get("PendingStatus");
        private static readonly string MonthlyToAnnualTitle = ConfigurationManager.AppSettings.Get("MonthlyToAnnualTitle");
        private static readonly string TaxValuePerMonthTitle = ConfigurationManager.AppSettings.Get("TaxValuePerMonthTitle");
        private static readonly string BasicAnnualSalaryTitle = ConfigurationManager.AppSettings.Get("BasicAnnualSalaryTitle");
        private static readonly string AnnualValueDeductionsTitle = ConfigurationManager.AppSettings.Get("AnnualValueDeductionsTitle");
        private static int numberOfMonths = DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1;
        private static readonly int DefaultNumberOfWorkingHours = 8;
        private static readonly List<(string, decimal)> EarningsList = new List<(string, decimal)>();
        private static readonly List<(int, string, decimal)> DeductionsList = new List<(int, string, decimal)>();
        private static decimal NetPayValue;
        private static decimal TotalEarningsValue;
        private static decimal TotalDeductionsValue;
        private static decimal SalaryValue;

        public int PayrollId { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string NameOfCompany { get; set; }
        public string CompanyAddress { get; set; }
        public string EmployeeDepartment { get; set; }
        public string SalaryDescription { get; set; }
        public string PayrollPeriod { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string SalaryAmount { get; set; }
        public int NumberOfLogs { get; set; }
        public int NumberOfDays { get; set; }
        public string SalarySchedule { get; set; }
        public string EmploymentStatus { get; set; }
        public string AdjustedSalary { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string NetPay { get; set; }

        public payslip(int userId, employeeList parent)
        {
            _userId = userId;
            _parent = parent;
            InitializeComponent();
        }

        #region Get and Insert Functions

        private async Task<bool> GetDeductionVerification(int detailsId, int month)
        {
            try
            {
                bool isExist = await payrollClass.CheckBenefitExist(detailsId, month);

                return isExist;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertSystemLog(DateTime logDate, string description, string caption)
        {
            try
            {
                bool systemLog = await generalFunctions.AddSystemLogs(logDate, description, caption);
                return systemLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertPayrollTransactionLog(DateTime logDate, string description, int payrollId)
        {
            try
            {
                bool insert = await payrollClass.AddCreationPayrollTransactionLog(logDate, description, payrollId);
                return insert;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetEmployeeName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertEarnings(int payrollId, string earningsDescription, decimal amount)
        {
            try
            {
                bool insert = await payrollClass.InsertNewEarnings(payrollId, earningsDescription, amount);
                return insert;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertDeductions(int payrollId, decimal amount, string description, int detailsId)
        {
            try
            {
                bool insert = await payrollClass.InsertDeductions(payrollId, amount, description, detailsId);
                return insert;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertNewPayroll(int employeeId, DateTime dateCreated, DateTime startingDate, DateTime endingDate,
            string salaryRateDescription, decimal amount, decimal totalEarnings, decimal totalDeduction, string createdBy, string status,
            string payslipType, decimal netPay, int payrollFormId)
        {
            try
            {
                bool insert = await payrollClass.InsertNewPayrollForm(employeeId, dateCreated, startingDate, endingDate, salaryRateDescription, 
                    amount, totalEarnings, totalDeduction, createdBy, status, payslipType, netPay, payrollFormId);
                return insert;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetFormula(string schedule)
        {
            try
            {
                string formula = await payrollClass.GetScheduleFormula(schedule);

                if (formula != null)
                {
                    return formula;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetEmployeeAllowance(int employeeId)
        {
            try
            {
                DataTable allowance = await payrollClass.GetEmployeeAllowance(employeeId);

                if (allowance != null && allowance.Rows.Count > 0)
                {
                    return allowance;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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

        #endregion

        #region Functions for Computations

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

        private async Task DeductBenefits(int employeeId, List<(int, string, decimal)> deductionList, string salaryValue, 
            DateTime fromDate, DateTime toDate, int numberOfDays, string employmentStatus, int numberOfLogs)
        {
            try
            {
                DataTable benefitList = await GetActiveEmployeeBenefit(employeeId);

                // Common deduction calculation logic
                await CalculateDeduction(employeeId, deductionList, salaryValue, benefitList);

                // Job order-specific deduction logic only if employment status is not regular
                if (employmentStatus != "Regular")
                {
                    CalculateJobOrderDeduction(deductionList, salaryValue, fromDate, toDate, numberOfDays, numberOfLogs);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private async Task CalculateDeduction(int employeeId, List<(int, string, decimal)> deductionList, string salaryValue, 
            DataTable benefitList)
        {
            string deductionDescription = "";
            decimal amount = 0;
            int detailsId = 0;

            // Common deduction calculation logic
            foreach (DataRow row in benefitList.Rows)
            {
                if (row["benefitsValue"] != null && decimal.TryParse(row["benefitsValue"].ToString(), out decimal value) &&
                    !string.IsNullOrEmpty(row["benefits"]?.ToString()) && !string.IsNullOrEmpty(row["detailsId"].ToString()) 
                    && int.TryParse(row["detailsId"].ToString(), out detailsId))
                {
                    deductionDescription = $"{row["benefits"]}";
                    amount = value;
                }
                else if (string.IsNullOrEmpty(row["benefitsValue"].ToString()) && !string.IsNullOrEmpty(row["benefits"]?.ToString()) &&
                    $"{row["benefits"]}" != "Witholding Tax" && int.TryParse(row["benefitsId"].ToString(), out int benefitsId) &&
                    !string.IsNullOrEmpty(row["detailsId"].ToString()) && int.TryParse(row["detailsId"].ToString(), out detailsId)
                    && decimal.TryParse(salaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal monthlySalary))
                {
                    amount = await ComputeBenefitContributionsAmount(benefitsId, monthlySalary);
                    deductionDescription = $"{row["benefits"]}";
                }
                else if (string.IsNullOrEmpty(row["benefitsValue"].ToString()) && !string.IsNullOrEmpty(row["benefits"]?.ToString()) &&
                    $"{row["benefits"]}" == "Witholding Tax" && !string.IsNullOrEmpty(row["detailsId"]?.ToString()) && 
                    int.TryParse(row["detailsId"].ToString(), out detailsId) &&
                    decimal.TryParse(salaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal newMonthlySalary)
                    && int.TryParse(row["benefitsId"].ToString(), out int newBenefitsId))
                {
                    amount = await ComputeWitholdingTaxPerMonth(newBenefitsId, newMonthlySalary, MonthlyToAnnualTitle, BasicAnnualSalaryTitle,
                        TaxValuePerMonthTitle, AnnualValueDeductionsTitle, numberOfMonths, employeeId);
                    deductionDescription = $"{row["benefits"]}";
                }

                deductionList.Add((detailsId, deductionDescription, amount));
            }
        }

        private void CalculateJobOrderDeduction(List<(int, string, decimal)> deductionList, string salaryValue, DateTime fromDate,
            DateTime toDate, int numberOfDays, int numberOfLogs)
        {
            if ((numberOfDays - numberOfLogs) > 0 && decimal.TryParse(salaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal employeeSalary))
            {
                string description = $"Absent for {(numberOfDays - numberOfLogs)} days";
                decimal amount = employeeSalary * (numberOfDays - numberOfLogs);

                deductionList.Add((-1, description, amount));
            }
            else
            {
                
            }
        }

        private async Task ForwardEmployeeAllowance(int employeeId, List<(string, decimal)> earnings)
        {
            try
            {
                DataTable allowance = await GetEmployeeAllowance(employeeId);
                string description = "";
                decimal value = 0;

                if (allowance != null)
                {
                    foreach (DataRow row in allowance.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["allowanceName"]?.ToString()) && !string.IsNullOrEmpty(row["allowanceValue"]?.ToString())
                            && decimal.TryParse(row["allowanceValue"].ToString(), out value))
                        {
                            description = $"{row["allowanceName"]}";
                            earnings.Add((description, value));
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

        private async Task<decimal> ComputeAdjustedSalary(string salaryValue, int numberOfDays, string employmentStatus, List<(string, decimal)> earningsList, 
            string schedule)
        {
            decimal salary = 0;

            if (employmentStatus == "Regular")
            {
                salary = decimal.Parse(salaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture);
                string formula = await GetFormula(schedule);

                if (formula != null)
                {
                    Expression expression = new Expression(formula);

                    expression.Parameters["monthlySalary"] = salary;

                    object result = expression.Evaluate();

                    if(result != null && decimal.TryParse(result.ToString(), out decimal formulatedSalary))
                    {
                        salaryAdjustment.Text = $"Adjusted Salary";
                        earningsList.Add(($"Adjusted Salary", formulatedSalary));
                        return formulatedSalary;
                    }
                }

            }
            else
            {
                salary = decimal.Parse(salaryValue, NumberStyles.Currency, CultureInfo.CurrentCulture);

                salaryAdjustment.Text = $"Basic Salary * {numberOfDays}";
                earningsList.Add(($"Basic salary * numberOfDays)", salary * numberOfDays));
                return salary * numberOfDays;
            }

            return 0;
        }

        private decimal CalculateTotalEarnings(List<(string, decimal)> earningsList)
        {
            decimal amount = 0;

            foreach (var item in earningsList)
            {
                amount += item.Item2;
            }

            return amount;
        }

        private decimal CalculateTotalDeduction(List<(int, string, decimal)> deductionList)
        {
            decimal amount = 0;

            if (deductionList.Count > 0)
            {
                foreach (var item in deductionList)
                {
                    amount += item.Item3;
                }
            }

            return amount;
        }

        #endregion

        #region Parsing Functions

        private void DisplayEarnings(List<(string, decimal)> earningsList, int userId)
        {
            if (earningsList != null && earningsList.Count > 0)
            {
                earningsUC[] earnings = new earningsUC[earningsList.Count];
                int currentIndex = 0;

                foreach (var earningsItems in earningsList)
                {
                    earnings[currentIndex] = new earningsUC(userId, this);

                    earnings[currentIndex].EarningsDescription = earningsItems.Item1;
                    earnings[currentIndex].EarningsAmount = $"{earningsItems.Item2:C2}";

                    earningsListPanel.Controls.Add(earnings[currentIndex]);

                    currentIndex++;
                }
            }
        }

        private async void DisplayDeductions(List<(int, string, decimal)> deductionList, int month, int userId)
        {
            try
            {
                if (deductionList != null && deductionList.Count > 0)
                {
                    int currentIndex = deductionList.Count - 1; // Start from the end

                    for (int i = currentIndex; i >= 0; i--)
                    {
                        var deductionItems = deductionList[i];
                        bool checkDeduction = await GetDeductionVerification(deductionItems.Item1, month);

                        if (checkDeduction)
                        {
                            deductionList.RemoveAt(i);
                        }
                        else
                        {
                            var deductionControl = new deductionsUC(userId, this)
                            {
                                DeductionDescription = deductionItems.Item2,
                                DeductionAmount = $"{deductionItems.Item3:C2}"
                            };
                            deductionsListPanel.Controls.Add(deductionControl);
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

        public void ForwardNewEarnings(string earningsName, decimal earningsAmount)
        {
            EarningsList.Add((earningsName, earningsAmount));
            DisplayEarnings(EarningsList, _userId);
        }

        public void ForwardNewDeductions(string deductionName, decimal deductionAmount)
        {
            DeductionsList.Add((-1, deductionName, deductionAmount));

            DisplayDeductions(DeductionsList, DateTime.Today.Month, _userId);
        }

        #endregion

        #region Custom Functions

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearBindings()
        {
            employeeId.DataBindings.Clear();
            employeeName.DataBindings.Clear();
            companyName.DataBindings.Clear();
            companyAddress.DataBindings.Clear();
            departmentName.DataBindings.Clear();
            salaryDescription.DataBindings.Clear();
            payrollPeriod.DataBindings.Clear();
            basicSalaryAmount.DataBindings.Clear();
            salaryAdjustment.DataBindings.Clear();
            totalEarnings.DataBindings.Clear();
            totalDeductions.DataBindings.Clear();
            netPay.DataBindings.Clear();
            payrollId.DataBindings.Clear();

            EarningsList.Clear();
            DeductionsList.Clear();
        }

        private async Task DataBinding()
        {
            try
            {
                ClearBindings();
                earningsListPanel.Controls.Clear();
                deductionsListPanel.Controls.Clear();
                await DeductBenefits(EmployeeID, DeductionsList, SalaryAmount, FromDate, ToDate, NumberOfDays, EmploymentStatus, 
                    NumberOfLogs);
                await ForwardEmployeeAllowance(EmployeeID, EarningsList);

                DisplayEarnings(EarningsList, _userId);
                DisplayDeductions(DeductionsList, DateTime.Today.Month, _userId);

                SalaryValue = await ComputeAdjustedSalary(SalaryAmount, NumberOfDays, EmploymentStatus, EarningsList, SalarySchedule);
                TotalEarningsValue = CalculateTotalEarnings(EarningsList);
                TotalDeductionsValue = CalculateTotalDeduction(DeductionsList);
                NetPayValue = TotalEarningsValue - TotalDeductionsValue;

                AdjustedSalary = $"{SalaryValue:C2}";
                TotalEarnings = $"{TotalEarningsValue:C2}";
                TotalDeductions = $"{TotalDeductionsValue:C2}";
                NetPay = $"{NetPayValue:C2}";

                employeeId.DataBindings.Add("Text", this, "EmployeeID");
                employeeName.DataBindings.Add("Text", this, "EmployeeName");
                companyName.DataBindings.Add("Text", this, "NameOfCompany");
                companyAddress.DataBindings.Add("Text", this, "CompanyAddress");
                departmentName.DataBindings.Add("Text", this, "EmployeeDepartment");
                salaryDescription.DataBindings.Add("Text", this, "SalaryDescription");
                payrollPeriod.DataBindings.Add("Text", this, "PayrollPeriod");
                basicSalaryAmount.DataBindings.Add("Text", this, "SalaryAmount");
                salaryAdjustmentValue.DataBindings.Add("Text", this, "AdjustedSalary");
                totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
                totalDeductions.DataBindings.Add("Text", this, "TotalDeductions");
                netPay.DataBindings.Add("Text", this, "NetPay");
                payrollId.DataBindings.Add("Text", this, "PayrollId");
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

        #region Event Handlers

        private async void payslip_Load(object sender, EventArgs e)
        {
            await DataBinding();
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Encapsulated Functions

        private async Task<string> RetriveEmployeeName(int userId)
        {
            try
            {
                string name = await GetEmployeeName(userId);
                
                if(name == null)
                {
                    ErrorMessages("Therer is error in retrieving the Name of the User", "Name Retrieval Error");
                    return null;
                }
                else
                {
                    return name;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddNewPayrollForm(int employeeId, DateTime dateCreated, DateTime startingDate, DateTime endingDate,
            string salaryRateDescription, decimal amount, decimal totalEarnings, decimal totalDeduction, string createdBy, string status,
            string payslipType, decimal netPay, int payrollFormId)
        {
            try
            {
                bool insert = await InsertNewPayroll(employeeId, dateCreated, startingDate, endingDate, salaryRateDescription, amount,
                    totalEarnings, totalDeduction, createdBy, status, payslipType, netPay, payrollFormId);

                if (insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error in adding the payroll form please contact system administrator for resolution.",
                        "Payroll Addition Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddNewEarnings(List<(string, decimal)> earningsList, int payrollId)
        {
            try
            {
                foreach(var items in earningsList)
                {
                    bool insert = await InsertEarnings(payrollId, items.Item1, items.Item2);

                    if(!insert)
                    {
                        ErrorMessages($"Insertion of the Earning/s {items.Item1} failed. Please let the system administrator know for " +
                            $"resolution", "Earnings Addition Error");
                    }
                }

                return true;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddNewDeductions(List<(int, string, decimal)> deductionList, int payrollId)
        {
            try
            {
                if (deductionList != null)
                {
                    foreach (var item in deductionList)
                    {
                        bool insert = await InsertDeductions(payrollId, item.Item3, item.Item2, item.Item1);

                        if(!insert)
                        {
                            ErrorMessages($"Insertion of the Deduction/s {item.Item2} failed. Please let the system administrator know for " +
                            $"resolution", "Deduction Addition Error");
                        }
                    }

                    return true;
                }
                else
                {
                    SuccessMessages($"There is no deduction/s recorded and will proceed to the next step. Please await further approval from " +
                        $"respective personnel.", "No Deduction Records");
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddSystemLog(DateTime logDate, string name, int userId, int employeeId, string employeeName)
        {
            try
            {
                string description = $"Creation of Payroll for ({employeeName} ID: {employeeId}) " +
                    $"|| Created by: ({name} ID: {userId}) " +
                    $"|| Date and Time: {logDate:MMMM dd, yyyy} - {logDate:t}";
                string caption = $"Payroll Creation";
                bool insert = await InsertSystemLog(logDate, description, caption);
                
                if(insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered during the addition into the System Logs. As the Payroll is already " +
                        "created and forwarded please await further approval and notice!", "System Log Insertion Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddTransactionLog(DateTime logDate, int userId, int payrollId, string employeeName, 
            string name)
        {
            try
            {
                string description = $"Payroll Creation for Employee {employeeName} ID: {employeeId}" +
                    $"|| Created By: {name} ID: {userId} " +
                    $"|| PayrollID: {payrollId}";
                bool insert = await InsertPayrollTransactionLog(logDate, description, payrollId);

                if (insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered during the addition into the Transaction Logs. As the Payroll is already " +
                        "created and forwarded please await further approval and notice!", "Transaction Log Insertion Error");
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
                string name = await RetriveEmployeeName(_userId);
                if (name == null)
                    return;

                bool addPayroll = await AddNewPayrollForm(EmployeeID, DateTime.Today, FromDate, ToDate, SalaryDescription, SalaryValue,
                    TotalEarningsValue, TotalDeductionsValue, name, PayrollDefaultStatus, SalarySchedule, NetPayValue, PayrollId);
                if (!addPayroll)
                    return;

                bool addEarnings = await AddNewEarnings(EarningsList, PayrollId);
                if (!addEarnings) 
                    return;

                bool addDeductions = await AddNewDeductions(DeductionsList, PayrollId);
                if (!addDeductions)
                    return;

                bool transaction = await AddTransactionLog(DateTime.Today, _userId, PayrollId, EmployeeName, name);
                if (!transaction)
                    return;

                bool systemLog = await AddSystemLog(DateTime.Today, name, _userId, EmployeeID, EmployeeName);
                if(!systemLog)
                    return;

                SuccessMessages($"The payroll form with the transaction number {PayrollId} is on the process and is pending for " +
                    $"proper review and approval.", "Payroll Form Generation Done");
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
