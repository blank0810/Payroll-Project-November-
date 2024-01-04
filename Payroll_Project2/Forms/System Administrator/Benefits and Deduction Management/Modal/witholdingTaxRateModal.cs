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
    public partial class witholdingTaxRateModal : Form
    {
        private static int _userId;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();

        public int BenefitID { get; set; }
        public string BenefitName { get; set; }

        public witholdingTaxRateModal(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<DataTable> GetWitholdingTaxRate()
        {
            try
            {
                DataTable rate = await benefitManagementClass.GetWitholdingTaxRate();

                if (rate != null && rate.Rows.Count > 0)
                {
                    return rate;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task DisplayRate(int userId)
        {
            try
            {
                rateListPanel.Controls.Clear();
                DataTable rate = await GetWitholdingTaxRate();

                if (rate != null)
                {
                    witholdingTaxUC[] taxUC = new witholdingTaxUC[rate.Rows.Count];

                    for (int i = 0; i < rate.Rows.Count; i++)
                    {
                        taxUC[i] = new witholdingTaxUC(userId, this);
                        DataRow row = rate.Rows[i];
                        decimal fromAnnual = 0;
                        decimal toAnnual = 0;

                        if (!string.IsNullOrEmpty(row["taxRateId"]?.ToString()) && int.TryParse(row["taxRateId"].ToString(), 
                            out int taxRateId))
                        {
                            taxUC[i].TaxRateId = taxRateId;
                        }
                        else
                        {
                            taxUC[i].TaxRateId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["taxRateDescription"]?.ToString()))
                        {
                            taxUC[i].Description = $"{row["taxRateDescription"]}";
                        }
                        else
                        {
                            taxUC[i].Description = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["fromAnnualSalaryValue"]?.ToString())
                            && decimal.TryParse(row["fromAnnualSalaryValue"].ToString(), out fromAnnual))
                        {
                            taxUC[i].FromAnnualSalary = fromAnnual;
                        }
                        else
                        {
                            taxUC[i].FromAnnualSalary = 0;
                        }

                        if (!string.IsNullOrEmpty(row["toAnnualSalaryValue"]?.ToString()) 
                            && decimal.TryParse(row["toAnnualSalaryValue"].ToString(), out toAnnual))
                        {
                            taxUC[i].ToAnnualSalary = toAnnual;
                        }
                        else
                        {
                            taxUC[i].ToAnnualSalary = 0;
                        }

                        taxUC[i].AnnualSalaryValue = $"{fromAnnual:C2} - {toAnnual:C2}";

                        if (!string.IsNullOrEmpty(row["percentageToBeDeducted"]?.ToString()) && 
                            decimal.TryParse(row["percentageTobeDeducted"].ToString(), out decimal percentage))
                        {
                            taxUC[i].Percentage = $"{percentage}%";
                        }
                        else
                        {
                            taxUC[i].Percentage = $"{0}%";
                        }

                        if (!string.IsNullOrEmpty(row["amountToBeDeducted"]?.ToString()) &&
                            decimal.TryParse(row["amountToBeDeducted"].ToString(), out decimal amount))
                        {
                            taxUC[i].Amount = $"{amount:C2}";
                        }
                        else
                        {
                            taxUC[i].Amount = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["amountExcess"]?.ToString()) &&
                            decimal.TryParse(row["amountExcess"].ToString(), out decimal excessAmount))
                        {
                            taxUC[i].ExcessAmount = $"{excessAmount:C2}";
                        }
                        else
                        {
                            taxUC[i].ExcessAmount = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["taxRateEffectiveFromYear"]?.ToString()))
                        {
                            taxUC[i].YearEffective = $"{row["taxRateEffectiveFromYear"]}";
                        }
                        else
                        {
                            taxUC[i].YearEffective = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["isTaxRateActive"]?.ToString()) &&
                            bool.TryParse(row["isTaxRateActive"]?.ToString(), out bool status))
                        {
                            if(status)
                            {
                                taxUC[i].Status = "Active";
                            }
                            else
                            {
                                taxUC[i].Status = "Inactive";
                            }
                        }
                        else
                        {
                            taxUC[i].Status = "----------";
                        }

                        rateListPanel.Controls.Add(taxUC[i]);
                    }
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

        private void DataBinding()
        {
            benefitName.DataBindings.Clear();
            benefitName.DataBindings.Add("Text", this, "BenefitName");
        }

        private async void witholdingTaxRateModal_Load(object sender, EventArgs e)
        {
            DataBinding();
            await DisplayRate(_userId);
        }
    }
}
