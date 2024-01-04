using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator
{
    public class benefitManagementClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public benefitManagementClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<DataTable> GetBenefitList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_benefits";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetBenefitRate(int benefitId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_benefitsContributions where benefitsId = @benefitId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitId", benefitId);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetWitholdingTaxRate()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_witholdingTaxRates";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateBenefitRate(int id, decimal personalShare, decimal employerShare, bool status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_benefitsContributions " +
                        "set " +
                        "personalShareValue = @personalShare, " +
                        "employerShareValue = @employerShare, " +
                        "isBenefitContributionActive = @status " +
                        "where " +
                        "benefitContributionsId = @id";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@personalShare", personalShare);
                        cmd.Parameters.AddWithValue("@employerShare", employerShare);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", id);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateTaxRate(int taxRateId, string description, decimal fromAnnual, decimal toAnnual, 
            decimal percentage, decimal amount, decimal excessAmount, bool status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_witholdingTaxRates " +
                        "set " +
                        "isTaxRateActive = @status, " +
                        "taxRateDescription = @description, " +
                        "fromAnnualSalaryValue = @fromAnnual, " +
                        "toAnnualSalaryValue = @toAnnual, " +
                        "percentageToBeDeducted = @percentage, " +
                        "amountToBeDeducted = @amount, " +
                        "amountExcess = @excessAmount " +
                        "where taxRateId = @id";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", taxRateId);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@fromAnnual", fromAnnual);
                        cmd.Parameters.AddWithValue("@toAnnual", toAnnual);
                        cmd.Parameters.AddWithValue("@percentage", percentage);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@excessAmount", excessAmount);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}
