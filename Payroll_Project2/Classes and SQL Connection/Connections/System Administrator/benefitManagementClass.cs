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

        public async Task<int> GetBenefitId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select ident_current('tbl_benefits')";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if(!string.IsNullOrEmpty(result.ToString()) && int.TryParse(result.ToString(), out int id))
                        {
                            return id;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> AddNewBenefit(string benefitName, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_benefits (benefits, benefitsDescription) " +
                        "values (@benefits, @description)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefits", benefitName);
                        cmd.Parameters.AddWithValue("@description", description);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> AddBenefitContributions(int benefitId, bool isPercentage, decimal personalShare, decimal employerShare, 
            int fromYear, int toYear, bool isActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_benefitsContributions (benefitsId, isBenefitContributionActive, isPercentage, " +
                        "personalShareValue, employerShareValue, benefitContributionEffectiveFromYear, " +
                        "benefitContributionEffectiveToYear) " +
                        "values (@benefitsId, @isActive, @isPercentage, @personalShare, @employerShare, @fromYear, @toYear)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitsId", benefitId);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        cmd.Parameters.AddWithValue("@isPercentage", isPercentage);
                        cmd.Parameters.AddWithValue("@personalShare", personalShare);
                        cmd.Parameters.AddWithValue("@employerShare", employerShare);
                        cmd.Parameters.AddWithValue("@fromYear", fromYear);
                        cmd.Parameters.AddWithValue("@toYear", (toYear != -1) ? (object)toYear : DBNull.Value);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> AddBenefitsAllocation(string employmentStatus, int benefitsId, bool isMandated)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_mandatedBenefits (employmentStatusId, benefitsId, isMandated) " +
                        "values ((select employmentStatusId from tbl_employmentStatus where employmentStatus = @employmentStatus), " +
                        "@benefitsId, @isMandated)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employmentStatus", employmentStatus);
                        cmd.Parameters.AddWithValue("@benefitsId", benefitsId);
                        cmd.Parameters.AddWithValue("@isMandated", isMandated);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> AddBenefitFormula(int benefitsId, string formulaDescription, string formulaExpression)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_benefitsFormula (benefitsId, formulaDescription, formulaExpression) " +
                        "values (@benefitsId, @formulaDescription, @formulaExpression)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitsId", benefitsId);
                        cmd.Parameters.AddWithValue("@formulaDescription", formulaDescription);
                        cmd.Parameters.AddWithValue("@formulaExpression", formulaExpression);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
