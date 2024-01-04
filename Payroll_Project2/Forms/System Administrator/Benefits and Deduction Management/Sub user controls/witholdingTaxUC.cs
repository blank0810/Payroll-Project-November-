using Newtonsoft.Json.Linq;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Modal;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls
{
    public partial class witholdingTaxUC : UserControl
    {
        private static int _userId;
        private static witholdingTaxRateModal _parent;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();
        private static readonly  generalFunctions generalFunctions = new generalFunctions();

        public string BenefitName { get; set; }
        public int TaxRateId { get; set; }
        public string Description { get; set; }
        public string AnnualSalaryValue { get; set; }
        public decimal FromAnnualSalary { get; set; }
        public decimal ToAnnualSalary { get; set; }
        public string Percentage { get; set; }
        public string Amount { get; set; }
        public string ExcessAmount { get; set; }
        public string YearEffective { get; set; }
        public string Status { get; set; }

        public witholdingTaxUC(int userId, witholdingTaxRateModal parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<bool> UpdateTaxRate(int taxRateId, string description, decimal fromAnnual, decimal toAnnual,
            decimal percentage, decimal amount, decimal excessAmount, bool status)
        {
            try
            {
                bool update = await benefitManagementClass.UpdateTaxRate(taxRateId, description, fromAnnual, toAnnual, percentage,
                    amount, excessAmount, status);
                return update;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddSystemLog(string description, string caption, DateTime date)
        {
            try
            {
                bool systemLog = await generalFunctions.AddSystemLogs(date, description, caption);
                return systemLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetUserName(int userId)
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ParseValues()
        {
            ShowControls();

            descriptionBox.Texts = Description;
            fromAnnualBox.Texts = $"{FromAnnualSalary:C2}";
            toAnnualBox.Texts = $"{ToAnnualSalary:C2}";
            percentageBox.Texts = Percentage;
            amountBox.Texts = Amount;
            excessAmountBox.Texts = ExcessAmount;
            rateStatusChoices.SelectedItem = Status;
        }

        private void HideControls()
        {
            descriptionBox.Visible = false;
            fromAnnualBox.Visible = false;
            toAnnualBox.Visible = false;
            annualSalaryIndicator.Visible = false;
            percentageBox.Visible = false;
            amountBox.Visible = false;
            excessAmountBox.Visible = false;
            rateStatusChoices.Visible = false;
            submitBtn.Visible = false;
            cancelBtn.Visible = false;

            description.Visible = true;
            annualSalaryValue.Visible = true;
            percentage.Visible = true;
            amount.Visible = true;
            excessAmount.Visible = true;
            status.Visible = true;
            modifyBtn.Visible = true;
        }

        private void ShowControls()
        {
            descriptionBox.Visible = true;
            fromAnnualBox.Visible = true;
            toAnnualBox.Visible = true;
            annualSalaryIndicator.Visible = true;
            percentageBox.Visible = true;
            amountBox.Visible = true;
            excessAmountBox.Visible = true;
            rateStatusChoices.Visible = true;
            submitBtn.Visible = true;
            cancelBtn.Visible = true;

            description.Visible = false;
            annualSalaryValue.Visible = false;
            percentage.Visible = false;
            amount.Visible = false;
            excessAmount.Visible = false;
            status.Visible = false;
            modifyBtn.Visible = false;
        }

        private void ClearBinding()
        {
            description.DataBindings.Clear();
            annualSalaryValue.DataBindings.Clear();
            percentage.DataBindings.Clear();
            amount.DataBindings.Clear();
            excessAmount.DataBindings.Clear();
            yearEffective.DataBindings.Clear();
            status.DataBindings.Clear();
        }

        private void DataBinding()
        {
            HideControls();
            ClearBinding();
            description.DataBindings.Add("Text", this, "Description");
            annualSalaryValue.DataBindings.Add("Text", this, "AnnualSalaryValue");
            percentage.DataBindings.Add("Text", this, "Percentage");
            amount.DataBindings.Add("Text", this, "Amount");
            excessAmount.DataBindings.Add("Text", this, "ExcessAmount");
            yearEffective.DataBindings.Add("Text", this, "YearEffective");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(StatusBinding_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void StatusBinding_Format(object sender, ConvertEventArgs e)
        {
            if(e.Value.ToString() == "Inactive")
            {
                status.ForeColor = Color.Maroon;
            }
            else
            {
                status.ForeColor = Color.ForestGreen;
            }
        }

        private void witholdingTaxUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            ParseValues();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            HideControls();
        }

        private bool StatusIndicator(string status)
        {
            if (status == "Active")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private decimal PercentageToDecimal(string percent)
        {
            if (decimal.TryParse(percent.TrimEnd('%'), out decimal result))
            {
                return result;
            }
            else
            {
                ErrorMessages("There is an error in converting the inputed value.", "Percentage Conversion Error");
                HideControls();
                return -1;
            }
        }

        private decimal CurrencyToDecimal(string currency)
        {
            if(decimal.TryParse(currency, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal result))
            {
                return result;
            }
            else
            {
                ErrorMessages("There is an error in converting the inputed value.", "Currency Conversion Error");
                HideControls();
                return -1;
            }
        }

        private async Task<string> GetEmployeeName(int userId)
        {
            try
            {
                string name = await GetUserName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    ErrorMessages("There is an error retrieving the administrator name!", "Administrator Name Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitUpdateTaxRate(int taxRateId, string description, decimal fromAnnual, decimal toAnnual,
            decimal percentage, decimal amount, decimal excessAmount, bool status)
        { 
            try
            {
                bool update = await UpdateTaxRate(taxRateId, description, fromAnnual, toAnnual, percentage, amount,
                    excessAmount, status);

                if(update)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error updating the rate. Please contact IT office for prompt resolution!",
                        "Rate Update Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for adding a new system logs
        private async Task<bool> AddNewSystemLogs(string name, DateTime date, string benefitName)
        {
            try
            {
                string systemLogDescription = benefitName + ": " +
                    "||Administrator Name: " + name +
                    "||Benefit Name: " + benefitName +
                    "||Date and Time Added: " + DateTime.Now.ToString("f");

                string systemLogCaption = "Rate Update";

                bool addSystemLog = await AddSystemLog(systemLogDescription, systemLogCaption, date);

                if (addSystemLog)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"The new rate is already reflected, but there is an error in adding the transaction into the system logs. Please " +
                        $"contact the system administrators for this issue.", "System Log Addition Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await GetEmployeeName(_userId);
                if (name == null)
                    return;

                bool status = StatusIndicator(rateStatusChoices.Text);

                decimal fromAnnual = CurrencyToDecimal(fromAnnualBox.Texts);
                if (fromAnnual < 0)
                    return;

                decimal toAnnual = CurrencyToDecimal(toAnnualBox.Texts);
                if (toAnnual < 0)
                    return;

                decimal percentage = PercentageToDecimal(percentageBox.Texts);
                if (percentage < 0)
                    return;

                decimal amount = CurrencyToDecimal(amountBox.Texts);
                if (amount < 0)
                    return;

                decimal excessAmount = CurrencyToDecimal(excessAmountBox.Texts);
                if (excessAmount < 0)
                    return;

                bool updateTax = await SubmitUpdateTaxRate(TaxRateId, descriptionBox.Texts, fromAnnual, toAnnual, percentage, amount,
                    excessAmount, status);
                if (!updateTax)
                    return;

                bool systemLog = await AddNewSystemLogs(name, DateTime.Today, BenefitName);
                if (!systemLog) 
                    return;

                SuccessMessages($"Rate Update is already done and reflected. Please do " +
                    $"check the update rates if there is any error.", "Rate Update Done");
                await _parent.DisplayRate(_userId);

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
