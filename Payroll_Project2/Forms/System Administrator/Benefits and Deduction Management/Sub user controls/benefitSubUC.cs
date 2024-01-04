using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Modal;

namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls
{
    public partial class benefitSubUC : UserControl
    {
        private static int _userId;
        private static benefitRateModal _parent;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public string BenefitName { get; set; }
        public int BenefitContributionsID { get; set; }
        public string PersonalShare { get; set; }
        public string EmployerShare { get; set; }
        public string RateStatus { get; set; }
        public string Year { get; set; }
        public bool IsPercentage { get; set; }

        public benefitSubUC(int userId, benefitRateModal parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<bool> UpdateRate(decimal personalShare, decimal employerShare, bool status, int id)
        {
            try
            {
                bool update = await benefitManagementClass.UpdateBenefitRate(id, personalShare, employerShare, status);
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void HideControls()
        {
            personalShareBox.Visible = false;
            employerShareBox.Visible = false;
            rateStatusChoices.Visible = false;
            submitBtn.Visible = false;
            cancelBtn.Visible = false;
            
            modifyBtn.Visible = true;
            personalShare.Visible = true;
            employerShare.Visible = true;
            rateStatus.Visible = true;
        }

        private void ShowControls()
        {
            personalShareBox.Visible = true;
            employerShareBox.Visible = true;
            rateStatusChoices.Visible = true;
            submitBtn.Visible = true;
            cancelBtn.Visible = true;

            modifyBtn.Visible = false;
            personalShare.Visible = false;
            employerShare.Visible = false;
            rateStatus.Visible = false;
        }

        private void ParseValues(string employerShare, string personalShare, string status)
        {
            ShowControls();

            personalShareBox.Texts = personalShare;
            employerShareBox.Texts = employerShare;
            rateStatusChoices.SelectedItem = status;
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearBinding()
        {
            personalShare.DataBindings.Clear();
            employerShare.DataBindings.Clear();
            rateStatus.DataBindings.Clear();
            year.DataBindings.Clear();
        }

        private void DataBinding()
        {
            ClearBinding();
            HideControls();
            personalShare.DataBindings.Add("Text", this, "PersonalShare");
            employerShare.DataBindings.Add("Text", this, "EmployerShare");
            year.DataBindings.Add("Text", this, "Year");

            Binding rateBinding = new Binding("Text", this, "RateStatus");
            rateBinding.Format += new ConvertEventHandler(RateStatus_Format);
            rateStatus.DataBindings.Add(rateBinding);
        }

        private void RateStatus_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Inactive")
            {
                rateStatus.ForeColor = Color.Maroon;
            }
            else
            {
                rateStatus.ForeColor = Color.ForestGreen;
            }
        }

        private void benefitSubUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            ParseValues(EmployerShare, PersonalShare, RateStatus);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            HideControls();
        }

        private decimal DecimalConversion(string value, bool isPercentage)
        {
            decimal result = 0;

            if(!string.IsNullOrEmpty(value) && isPercentage)
            {
                if(decimal.TryParse(value.TrimEnd('%'), out result))
                {
                    return result;
                }
                else
                {
                    ErrorMessages("There is an error in converting the inputted value.", "Conversion Error");
                    HideControls();
                    return -1;
                }
            }
            else
            {
                if (decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out result))
                {
                    return result;
                }
                else
                {
                    ErrorMessages("There is an error in converting the inputted value.", "Conversion Error");
                    HideControls();
                    return -1;
                }
            }
        }

        private bool StatusIndicator(string status)
        {
            if(status == "Active")
            {
                return true;
            }
            else
            {
                return false;
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitUpdateRate(int id, decimal personalShare, decimal employerShare, bool rateStatus)
        {
            try
            {
                bool update = await UpdateRate(personalShare, employerShare, rateStatus, id);

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

                decimal personalShare = DecimalConversion(personalShareBox.Texts, IsPercentage);
                if (personalShare < 0)
                    return;

                decimal employerShare = DecimalConversion(employerShareBox.Texts, IsPercentage);
                if (employerShare < 0)
                    return;

                bool status = StatusIndicator(rateStatusChoices.Text);

                bool update = await SubmitUpdateRate(BenefitContributionsID, personalShare, employerShare, status);
                if (!update)
                    return;

                bool systemLog = await AddNewSystemLogs(name, DateTime.Today, BenefitName);
                if (!systemLog)
                    return;

                SuccessMessages($"Rate Update is already done and reflected. Please do " +
                    $"check the update rates if there is any error.", "Rate Update Done");
                await _parent.DisplayRate(_userId, BenefitName);

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
