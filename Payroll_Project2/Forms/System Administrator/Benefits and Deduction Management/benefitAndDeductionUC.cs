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

namespace Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management
{
    public partial class benefitAndDeductionUC : UserControl
    {
        private static int _userId;
        private static readonly benefitManagementClass benefitManagementClass = new benefitManagementClass();

        public benefitAndDeductionUC(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<DataTable> GetBenefitList()
        {
            try
            {
                DataTable list = await benefitManagementClass.GetBenefitList();
                
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

        public async Task DisplayBenefits(int userId)
        {
            try
            {
                DataTable list = await GetBenefitList();
                listPanel.Controls.Clear();

                if(list != null)
                {
                    benefitDataUC[] benefits = new benefitDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        benefits[i] = new benefitDataUC(userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["benefits"]?.ToString()))
                        {
                            benefits[i].BenefitName = $"{row["benefits"]}";
                        }
                        else
                        {
                            benefits[i].BenefitName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["benefitsDescription"]?.ToString()))
                        {
                            benefits[i].BenefitDescription = $"{row["benefitsDescription"]}";
                        }
                        else
                        {
                            benefits[i].BenefitDescription = "-----------";
                        }

                        if (!string.IsNullOrEmpty(row["benefitsId"]?.ToString()) && int.TryParse(row["benefitsId"]?.ToString(), 
                            out int benefitsId))
                        {
                            benefits[i].BenefitID = benefitsId;
                        }
                        else
                        {
                            benefits[i].BenefitID = 0;
                        }

                        listPanel.Controls.Add(benefits[i]);
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

        private async void benefitAndDeductionUC_Load(object sender, EventArgs e)
        {
            await DisplayBenefits(_userId);
        }
    }
}
