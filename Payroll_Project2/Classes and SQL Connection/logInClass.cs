using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Class
{
    public class LogInConnection
    {
        public string connectionString;

        public LogInConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        // This method will check if the user credentials does exist in database or not
        public async Task<bool> GetAuthenticate(int id, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "Select employeeId from tbl_employee where employeeid = @id and employeepassword = @password";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = await cmd.ExecuteScalarAsync();
                        conn.Close();

                        if (result != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
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
        
        // This will check if the account status if the user is still active or frozen
        public async Task<bool> GetAccountStatus(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select isActive from tbl_employee where employeeid = @id";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            return (bool)result;
                        }
                        else
                        {
                            return (bool)result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        // This will get the user role of the user so that it will redirect on what platform the user will go
        public async Task<string> GetUserRole(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select roleName from tbl_employee join tbl_userrole on tbl_employee.roleid = tbl_userrole.roleid where " +
                        "employeeid = @id";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        object result = await cmd.ExecuteScalarAsync();
                        string role = result.ToString();
                        return role;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
