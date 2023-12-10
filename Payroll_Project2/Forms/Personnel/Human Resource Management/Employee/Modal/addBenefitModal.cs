using NCalc;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal
{
    public partial class addBenefitModal : Form
    {
        private static int _userId;
        private static employeeDetailsUserControl _parent;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static employeeClass employeeClass = new employeeClass();
        private static bool IsPercentage;
        private static bool IsBenefitActive = true;
        private static decimal EmployerShareValue;
        private static decimal PersonalShareValue;

        public int EmployeeID { get; set; }
        public decimal MonthlySalary { get; set; }
        private readonly bool BenfitStatus = true;

        public addBenefitModal( int userID, employeeDetailsUserControl parent)
        {
            _userId = userID;
            _parent = parent;
            InitializeComponent();
        }

        #region This Functions Below is Used for the functionality of the modal

        private async Task<string> GetBenefitsFormula(int benefitId)
        {
            try
            {
                string formula = await generalFunctions.GetBenefitsFormula(benefitId);
                return formula;
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetBenefitList(int employeeId)
        {
            try
            {
                DataTable list = await employeeClass.GetAvailableBenefitList(employeeId);

                if (list != null && list.Rows.Count > 0)
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

        private async Task<DataTable> GetBenefitsContributions(int benefitId)
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetBenefitsId(string benefitName)
        {
            try
            {
                int benefitId = await employeeClass.GetBenefitId(benefitName);
                return benefitId;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetEmploymentStatus(int employeeId)
        {
            try
            {
                DataTable details = await generalFunctions.GetEmployeeDetails(employeeId);

                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        return row["employmentStatus"].ToString();
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddExistingBenefit(int id, int benefitId, bool isBenefitActive, decimal personalShare, decimal employerShare)
        {
            #region This function is used so that the benefit that is being added into the database will be added into the employee appointment form

            try
            {
                bool addValidation = await employeeClass.AddEmployeeBenefit(id, benefitId, personalShare, employerShare, isBenefitActive);

                if (addValidation == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            #endregion
        }

        #endregion

        #region Custom functions

        private void ErrorMessages(string message, string captions)
        {
            MessageBox.Show(message, captions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string captions)
        {
            MessageBox.Show(message, captions, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task DataBinding()
        {
            #region This function is used that the value of the labels is being databind to the variables so that it will be updated in the real time
            try
            {
                DataTable benefitTable = await GetBenefitList(EmployeeID);
                List<string> autoCompleteValues = new List<string>
                    {
                        "Please choose"
                    };

                if (benefitTable != null)
                {
                    foreach (DataRow row in benefitTable.Rows)
                    {
                        autoCompleteValues.Add($"{row["benefits"]}");
                    }
                }

                benefitName.DataSource = autoCompleteValues;
                benefitName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption:@"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        private async Task<decimal> ComputePersonalShareValue(decimal personalSharePercentage, decimal monthlySalary, int benefitId)
        {
            try
            {
                string formula = await GetBenefitsFormula(benefitId);

                if (!string.IsNullOrEmpty(formula))
                {
                    Expression expression = new Expression(formula);

                    expression.Parameters["personalSharePercentage"] = personalSharePercentage;
                    expression.Parameters["employerSharePercentage"] = 0;
                    expression.Parameters["monthlySalary"] = monthlySalary;

                    object result = expression.Evaluate();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal personalValue))
                    {
                        return personalValue;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<decimal> ComputeEmployerShareValue(decimal employerSharePercentage, decimal monthlySalary, int benefitId)
        {
            try
            {
                string formula = await GetBenefitsFormula(benefitId);

                if (!string.IsNullOrEmpty(formula))
                {
                    Expression expression = new Expression(formula);

                    expression.Parameters["personalSharePercentage"] = 0;
                    expression.Parameters["employerSharePercentage"] = employerSharePercentage;
                    expression.Parameters["monthlySalary"] = monthlySalary;

                    object result = expression.Evaluate();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal employerValue))
                    {
                        return employerValue;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task ParsingBenefitContributions(string benefitName, decimal monthlySalary)
        {
            try
            {
                int benefitId = await GetBenefitsId(benefitName);
                DataTable contributions = await GetBenefitsContributions(benefitId);

                if (contributions != null)
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
                                    PersonalShareValue = personalShareValueMoney;
                                    EmployerShareValue = employerShareValueMoney;
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

                                decimal personalSharePreviewValue = await ComputePersonalShareValue(personalShare, monthlySalary, benefitId);
                                decimal employerSharePreviewValue = await ComputeEmployerShareValue(employerShare, monthlySalary, benefitId);
                                PersonalShareValue = -1;
                                EmployerShareValue = -1;

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
                    ErrorMessages($"There is no recorded contributions for {benefitName}. Please contact system administrator for resolution", "Benefit " +
                        "Contributions Error");
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

        #region The functions below is used for User Interfaces Behaviours

        private void customTextBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region This function is an event handler that restricts the text box of the benefit value that it only accepts number

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            #endregion
        }

        private async void addBenefitModal_Load(object sender, EventArgs e)
        {
            #region An event handler that when the modal will be run or called the values that is databind to the variables will be displayed

            await DataBinding();

            #endregion
        }

        private async void benefitName_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(benefitName.Text) && benefitName.Text != "No Benefits Available to add" 
                && benefitName.SelectedIndex > 0)
            {
                await ParsingBenefitContributions(benefitName.Text, MonthlySalary);
            }
            else
            {
                employerShareValue.Enabled = false;
                personalShareValue.Enabled = false;
                employerPercentageWarningLabel.Visible = false;
                personalPercentageWarningLabel.Visible = false;
                employerMinimumAmountLabel.Visible = false;
                personalMinimumAmountLabel.Visible = false;
            }
        }

        private void employerShareValue__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(employerShareValue.Texts) && decimal.TryParse(employerShareValue.Texts,
                NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal employerValue))
            {
                if (employerValue >= EmployerShareValue)
                {
                    EmployerShareValue = employerValue;
                }
            }
        }

        private void personalShareValue__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(personalShareValue.Texts) && decimal.TryParse(personalShareValue.Texts,
                NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal personalShare))
            {
                if(personalShare >=  PersonalShareValue)
                {
                    PersonalShareValue = personalShare;
                }
            }
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            #region Event handler that will close the modal when clicked

            this.Close();

            #endregion
        }

        #endregion

        #region Encapsulated Functions

        private decimal PersonalShareConverter(string personalShare, bool isPercentage)
        {
            if(isPercentage)
            {
                return -1;
            }
            else if (!isPercentage && decimal.TryParse(personalShare, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal personalValue))
            {
                return personalValue;
            }
            else
            {
                ErrorMessages("An unexpected error occurred while attempting to convert the Personal Share Value/Amount. " +
                    "Kindly review your input and attempt the operation again. For prompt resolution, please contact the system administrator.", 
                    "Error: Personal Share Value Error");
                return 0;
            }
        }

        private decimal EmployerShareConverter(string employerShare, bool isPercentage)
        {
            if (isPercentage)
            {
                MessageBox.Show("IF");
                return -1;
            }
            else if (!isPercentage && decimal.TryParse(employerShare, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal employerValue))
            {
                MessageBox.Show("Else IF");
                return employerValue;
            }
            else
            {
                ErrorMessages("An unexpected error occurred while attempting to convert the Employer Share Value/Amount. Kindly review your input and " +
                    "attempt the operation again. For prompt resolution, please contact the system administrator.", 
                    "Error: Employer Share Value Error");
                return 0;
            }
        }

        private bool IsInputValid(decimal employerShare, decimal personalShare)
        {
            if (employerShare < EmployerShareValue)
            {
                employerMinimumAmountLabel.Visible = false;
                employerMinimumAmountWarning.Text = $"(The user input must be greater than or equal to {EmployerShareValue:C2}, " +
                    "which represents the designated minimum value for this benefit!)";
                employerMinimumAmountWarning.Visible = true;
                employerMinimumAmountLabel.BringToFront();
                employerShareValue.Enabled = true;
                return false;
            }
            else if (personalShare < PersonalShareValue)
            {
                personalShareValue.Enabled = true;
                personalMinimumAmountLabel.Visible = false;
                personalMinimumAmountWarning.Text = $"(The user input must be greater than or equal to {PersonalShareValue:C2}, " +
                    $"which represents the designated minimum value for this benefit!)";
                personalMinimumAmountWarning.Visible = true;
                personalMinimumAmountWarning.BringToFront();
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<int> GetBenefitId(string benefitName)
        {
            try
            {
                int benefitId = await GetBenefitsId(benefitName);

                if(benefitId > 0)
                {
                    return benefitId;
                }
                else
                {
                    ErrorMessages($"There is no benefit ID associated with the benefit {benefitName}. Please contact the System Administrator to resolve " +
                        $"this issue.", "Benefit ID: Missing");
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddBenefit(int employeeId, int benefitId, bool isBenefitActive, decimal personalShare, decimal employerShare, 
            bool isPercentage)
        {
            try
            {
                if(!isPercentage)
                {
                    bool addExistingBenefit = await AddExistingBenefit(employeeId, benefitId, isBenefitActive, personalShare, employerShare);

                    if (addExistingBenefit)
                    {
                        return addExistingBenefit;
                    }
                    else
                    {
                        ErrorMessages("Encountered an error while attempting to add a benefit to the employee's appointment form. Please contact the system " +
                            "administrator for resolution.",
                            "Error: Benefit Addition.");
                        return false;
                    }
                }
                else
                {
                    bool addExistingBenefit = await AddExistingBenefit(employeeId, benefitId, isBenefitActive, personalShare, employerShare);

                    if (addExistingBenefit)
                    {
                        return addExistingBenefit;
                    }
                    else
                    {
                        ErrorMessages("Encountered an error while attempting to add a benefit to the employee's appointment form. Please contact the system " +
                            "administrator for resolution.",
                            "Error: Benefit Addition.");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                decimal personalShare = PersonalShareConverter(personalShareValue.Texts, IsPercentage);
                decimal employerShare = EmployerShareConverter(employerShareValue.Texts, IsPercentage);

                if (!IsInputValid(employerShare, personalShare))
                    return;

                int benefitId = await GetBenefitId(benefitName.Text);
                if (benefitId == 0)
                    return;

                bool addBenefit = await AddBenefit(EmployeeID, benefitId, IsBenefitActive, PersonalShareValue, EmployerShareValue, IsPercentage);
                if (!addBenefit)
                    return;

                SuccessMessages("The selected benefit has already been added to the employee's appointment form. Please review the details to ensure " +
                    "accuracy and completeness.", "Benefit Already Added");
                this.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, caption: "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}