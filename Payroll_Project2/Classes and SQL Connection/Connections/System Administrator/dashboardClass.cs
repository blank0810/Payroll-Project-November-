using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator
{
    public class dashboardClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public dashboardClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<DataTable> GetCompanyDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_companyDetails";

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

        public async Task<string> GetMayorName()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName from tbl_employee " +
                        "join tbl_mayorDetails on tbl_employee.employeeId = tbl_mayorDetails.employeeId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if(!string.IsNullOrEmpty(result?.ToString()) && result != DBNull.Value)
                        {
                            return $"{result}";
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<string> GetViceMayorName()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName from tbl_employee " +
                        "join tbl_viceMayorDetails on tbl_employee.employeeId = tbl_viceMayorDetails.employeeId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (!string.IsNullOrEmpty(result?.ToString()) && result != DBNull.Value)
                        {
                            return $"{result}";
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateCompanyLogo(string logoName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "UPDATE tbl_companyDetails " +
                                     "SET " +
                                     "companyLogo = @name";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", logoName);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateCompanyDetails(string companyName, string companyType, string companyEmail,
            string facebookName, string facebookLink, string barangay, string municipality, string province,
            string zipCode, string contactNumber, string companyLogo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "UPDATE tbl_companyDetails " +
                                     "SET " +
                                     "companyName = @companyName, " +
                                     "companyType = @companyType, " +
                                     "companyEmail = @companyEmail, " +
                                     "companyFacebookName = @facebookName, " +
                                     "companyFacebookLink = @facebookLink, " +
                                     "barangay = @barangay, " +
                                     "municipality = @municipality, " +
                                     "province = @province, " +
                                     "zipCode = @zipCode, " +
                                     "contactNumber = @contactNumber, " +
                                     "companyLogo = @companyLogo";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@companyName", companyName);
                        cmd.Parameters.AddWithValue("@companyType", companyType);
                        cmd.Parameters.AddWithValue("@companyEmail", companyEmail);
                        cmd.Parameters.AddWithValue("@facebookName", facebookName);
                        cmd.Parameters.AddWithValue("@facebookLink", facebookLink);
                        cmd.Parameters.AddWithValue("@barangay", barangay);
                        cmd.Parameters.AddWithValue("@municipality", municipality);
                        cmd.Parameters.AddWithValue("@province", province);
                        cmd.Parameters.AddWithValue("@zipCode", zipCode);
                        cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@companyLogo", companyLogo);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
