using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator
{
    public class logsClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public logsClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<DataTable> GetAllSystemLogs()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_systemLogs";

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

        public async Task<DataTable> GetEmployeeLogs()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_employeeDataLogChanges";

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

        public async Task<DataTable> GetPayrollLogs()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select * from tbl_payrollTransactionLog";

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

        public async Task<string> GetSystemLogDescription(int logId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select systemLogDescription from tbl_systemLogs where systemLogId = @logId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logId", logId);

                        object result = await cmd.ExecuteScalarAsync();

                        if(!string.IsNullOrEmpty(result.ToString()))
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
            catch (SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }

        public async Task<string> GetEmployeeDataLogDescription(int logId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT logDescription FROM tbl_employeeDataLogChanges WHERE dataLogChangeId = @logId";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logId", logId);

                        object result = await cmd.ExecuteScalarAsync();

                        return result?.ToString();
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

        public async Task<string> GetPayrollTransactionLogDescription(int transactionLogId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT logDescription FROM tbl_payrollTransactionLog WHERE transactionLogId = @transactionLogId";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@transactionLogId", transactionLogId);

                        object result = await cmd.ExecuteScalarAsync();

                        return result?.ToString();
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
