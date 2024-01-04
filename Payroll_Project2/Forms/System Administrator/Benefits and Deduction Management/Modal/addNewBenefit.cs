using log4net.Filter;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Modal
{
    public partial class addNewBenefit : Form
    {
        private static int _userId;
        private static benefitAndDeductionUC _parent;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public int BenefitId { get; set; }
        private string BenefitName { get; set; }
        private string BenefitDescription { get; set; }
        private bool IsPercentage { get; set; }
        private decimal PersonalShare { get; set; }
        private decimal EmployerShare { get; set; }
        private string Formula { get; set; }
        private bool IsActive { get; set; }
        private int FromYear { get; set; }
        private int ToYear { get; set; }
        private string EmploymentStatus { get; set; }
        private bool IsMandated { get; set; }

        public addNewBenefit(int userId, benefitAndDeductionUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<bool> AddBenefitFormula(string formulaDescription, string formulaExpression, int benefitsId)
        {
            try
            {
                bool formula = await benefitManagementClass.AddBenefitFormula(benefitsId, formulaDescription, formulaExpression);
                return formula;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
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

        private async Task<bool> AddSystemLog(DateTime date, string description, string caption)
        {
            try
            {
                bool systemLog = await generalFunctions.AddSystemLogs(date, description, caption);
                return systemLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddBenefitsAllocation(string employmentStatus, int benefitsId, bool isMandated)
        {
            try
            {
                bool allocation = await benefitManagementClass.AddBenefitsAllocation(employmentStatus, benefitsId, isMandated);
                return allocation;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddBenefitContributions(int benefitId, bool isPercentage, decimal personalShare, decimal employerShare,
            int fromYear, int toYear, bool isActive)
        {
            try
            {
                bool contributions = await benefitManagementClass.AddBenefitContributions(benefitId, isPercentage, personalShare, 
                    employerShare, fromYear, toYear, isActive);
                return contributions;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetEmploymentStatus()
        {
            try
            {
                DataTable employment = await generalFunctions.GetEmploymentStatus();

                if (employment != null && employment.Rows.Count > 0)
                {
                    return employment;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddBenefit(string benefitName, string description)
        {
            try
            {
                bool addBenefit = await benefitManagementClass.AddNewBenefit(benefitName, description);
                return addBenefit;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DataBinding()
        {
            try
            {
                benefitId.DataBindings.Clear();
                DataTable employmentStatus = await GetEmploymentStatus();

                List<string> employmentList = new List<string>
                {
                    "All Employment Status"
                };

                foreach(DataRow row in employmentStatus.Rows)
                {
                    employmentList.Add($"{row["employmentStatus"]}");
                }

                employmentStatusList.DataSource = employmentList;
                employmentStatusList.SelectedIndex = -1;

                benefitId.DataBindings.Add("Text", this, "BenefitId");
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

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addNewBenefit_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void benefitNameBox__TextChanged(object sender, EventArgs e)
        {
            BenefitName = benefitNameBox.Texts;
        }

        private void benefitDescriptionBox__TextChanged(object sender, EventArgs e)
        {
            BenefitDescription = benefitDescriptionBox.Texts;
        }

        private void formulaBox__TextChanged(object sender, EventArgs e)
        {
            Formula = formulaBox.Texts;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsPercentageIdentification()
        {
            if (percentageCheck.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private decimal DecimalConversion(string value)
        {
            if(decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            else
            {
                ErrorMessages($"There is an error in conversion the user input. Please try again later!", "Input Not Valid");
                return -1;
            }
        }

        private bool ContributionIdentification()
        {
            if(activeContributionCheck.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int YearConversion(string year)
        {
            if(!string.IsNullOrEmpty(year) && int.TryParse(year, out int yearResult))
            {
                return yearResult;
            }
            else
            {
                return -1;
            }
        }

        private bool MandatoryIdentification()
        {
            if (mandatoryCheck.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> SubmitNewBenefit(string benefitName, string description)
        {
            try
            {
                bool addBenefit = await AddBenefit(benefitName, description);

                if(addBenefit)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error adding the benefit {benefitName}. Please contact IT personnel " +
                        $"for quick resolution.", "Benefit Addition Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitContributionRate(int benefitId, bool isPercentage, decimal personalShare, decimal employerShare,
            int fromYear, int toYear, bool isActive, string benefitName)
        {
            try
            {
                bool contribution = await AddBenefitContributions(benefitId, isPercentage, personalShare, employerShare, fromYear,
                    toYear, isActive);

                if(contribution)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error encountered adding the benefit contribution for the benefit {benefitName}. " +
                        $"Please contact the IT personnel for quick resolution.", "Contribution Rate Addition Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitBenefitAllocation(string employmentStatus, int benefitsId, string benefitName, bool isMandated)
        {
            try
            {
                if (employmentStatus != "All Employment Status")
                {
                    bool allocation = await AddBenefitsAllocation(employmentStatus, benefitsId, isMandated);

                    if (allocation)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is an  error encountered with the allocation of the benefit {benefitName}. " +
                            $"Please contact the IT personnel for quick resolution.", "Allocation Error");
                        return false;
                    }
                }
                else
                {
                    DataTable employmentStatusList = await GetEmploymentStatus();

                    if (employmentStatusList != null)
                    {
                        foreach (DataRow row in employmentStatusList.Rows)
                        {
                            bool allocation = await AddBenefitsAllocation($"{row["employmentStatus"]}", benefitsId, isMandated);

                            if(!allocation)
                            {
                                ErrorMessages($"There is an error encounterd when allocating the benefit {benefitName} into the " +
                                    $"{row["employmentStatus"]} employment status. Contact the IT personnel for a quick resolution.",
                                    "Allocation Error");
                                return false;
                            }
                        }

                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is no employment status available to choose. Please contact IT personnel for quick " +
                            $"resolution.", "Allocation Error");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitBenefitFormula(bool isPercentage,int benefitsId, string formulaDescription, 
            string formulaExpression, string benefitName)
        {
            try
            {
                if (isPercentage)
                {
                    bool formula = await AddBenefitFormula(formulaDescription, formulaExpression, benefitsId);

                    if (formula)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is an error encountered for adding the formula for the benefit {benefitName}. " +
                            $"Please contact IT personnel for quick resolution.", "Formula Addition Error");
                        return false;
                    }
                }
                else
                {
                    SuccessMessages($"Since the benefit {benefitName} is not on a percentage value the contribution will be stored automatically.",
                        "Formula Addition Information");
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetUserName(int userId)
        {
            try
            {
                string name = await GetEmployeeName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    ErrorMessages("There is an error retrieving the user name.", "User Name Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for adding a new system logs
        private async Task<bool> AddNewSystemLogs(string name, string benefitName)
        {
            try
            {
                string systemLogDescription = "A new benefit has been added: " +
                    "||Administrator Name: " + name +
                    "||Department Name: " + benefitName +
                    "||Date and Time Added: " + DateTime.Now.ToString("f");

                string systemLogCaption = "Department Addition";

                bool addSystemLog = await AddSystemLog(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addSystemLog)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"The department is already added, but there is an error in adding the transaction into the system logs. Please " +
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
                IsPercentage = IsPercentageIdentification();
                PersonalShare = DecimalConversion(personalShareBox.Texts);
                EmployerShare = DecimalConversion(employerShareBox.Texts);
                IsActive = ContributionIdentification();
                FromYear = YearConversion(fromYearBox.Texts);
                ToYear = YearConversion(toYearBox.Texts);
                IsMandated = MandatoryIdentification();

                bool submitBenefit = await SubmitNewBenefit(BenefitName, BenefitDescription);
                if (!submitBenefit)
                    return;

                bool contributionRate = await SubmitContributionRate(BenefitId, IsPercentage, PersonalShare, EmployerShare, FromYear,
                    ToYear, IsActive, BenefitName);
                if (!contributionRate)
                    return;

                bool allocation = await SubmitBenefitAllocation(EmploymentStatus, BenefitId, BenefitName, IsMandated);
                if (!allocation)
                    return;

                string name = await GetUserName(_userId);
                if (name == null)
                    return;

                bool systemLog = await AddNewSystemLogs(name, BenefitName);
                if (!systemLog)
                    return;

                SuccessMessages($"Having to sucessfully add a new benefit called {BenefitName}. Please double check the details for any" +
                    $" possible error.", "Benefit Addition Done");
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
