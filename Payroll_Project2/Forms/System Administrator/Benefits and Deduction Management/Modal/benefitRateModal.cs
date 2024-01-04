using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Sub_user_controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management.Modal
{
    public partial class benefitRateModal : Form
    {
        private static int _userId;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();

        public int BenefitID { get; set; }
        public string BenefitName { get; set; }

        public benefitRateModal(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<DataTable> GetBenefitRates(int benefitId)
        {
            try
            {
                DataTable rates = await benefitManagementClass.GetBenefitRate(benefitId);

                if (rates != null && rates.Rows.Count > 0)
                {
                    return rates;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task DisplayRate(int userId, string benefitName)
        {
            try
            {
                rateListPanel.Controls.Clear();
                DataTable rates = await GetBenefitRates(BenefitID);

                if (rates != null)
                {
                    benefitSubUC[] benefitRates = new benefitSubUC[rates.Rows.Count];

                    for (int i = 0; i < rates.Rows.Count; i++)
                    {
                        benefitRates[i] = new benefitSubUC(userId, this);
                        DataRow row = rates.Rows[i];

                        benefitRates[i].Year = $"{row["benefitContributionEffectiveFromYear"]} - " +
                            $"{row["benefitContributionEffectiveToYear"]}";

                        benefitRates[i].BenefitName = benefitName;

                        if (!string.IsNullOrEmpty(row["benefitContributionsId"]?.ToString()) && 
                            int.TryParse(row["benefitContributionsId"]?.ToString(), out int id))
                        {
                            benefitRates[i].BenefitContributionsID = id;
                        }
                        else
                        {
                            benefitRates[i].BenefitContributionsID = 0;
                        }

                        if (bool.TryParse(row["isPercentage"]?.ToString(), out bool isPercentage))
                        {
                            benefitRates[i].IsPercentage = isPercentage;

                            if(isPercentage && !string.IsNullOrEmpty(row["personalShareValue"]?.ToString()) 
                                && !string.IsNullOrEmpty(row["employerShareValue"]?.ToString()) 
                                && decimal.TryParse(row["personalShareValue"]?.ToString(), out decimal personalShare) 
                                && decimal.TryParse(row["employerShareValue"]?.ToString(), out decimal employerShare))
                            {
                                benefitRates[i].PersonalShare = $"{personalShare}%";
                                benefitRates[i].EmployerShare = $"{employerShare}%";
                            }
                            else if (decimal.TryParse(row["personalShareValue"]?.ToString(), out decimal personalShareValue) 
                                && decimal.TryParse(row["employerShareValue"]?.ToString(), out decimal employerShareValue))
                            {
                                benefitRates[i].EmployerShare = $"{employerShareValue:C2}";
                                benefitRates[i].PersonalShare = $"{personalShareValue:C2}";
                            }
                        }

                        if(!string.IsNullOrEmpty(row["isBenefitContributionActive"]?.ToString()) && 
                            bool.TryParse(row["isBenefitContributionActive"]?.ToString(), out bool isActive))
                        {
                            if(isActive)
                            {
                                benefitRates[i].RateStatus = "Active";
                            }
                            else
                            {
                                benefitRates[i].RateStatus = "Inactive";
                            }
                        }
                        else
                        {
                            benefitRates[i].RateStatus = "---------";
                        }

                        rateListPanel.Controls.Add(benefitRates[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                ShowErrorMessageBox("SQL Error", sql.Message);
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox("Exception Error", ex.Message);
            }
        }

        private void ShowErrorMessageBox(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataBinding()
        {
            benefitName.DataBindings.Clear();
            benefitName.DataBindings.Add("Text", this, "BenefitName");
        }

        private async void benefitRateModal_Load(object sender, EventArgs e)
        {
            DataBinding();
            await DisplayRate(_userId, BenefitName);
        }
    }
}
