using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel
{
    internal class dtrClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public dtrClass() 
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        #region All Get methods

        //This function is responsible for retrieving the time for the Morning In basis
        public async Task<TimeSpan> GetMorningInBasis()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select timeDesignation from tbl_timeDesignation where timeDesignationDescription = 'Morning In'";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value && TimeSpan.TryParse(result.ToString(), out TimeSpan time))
                        {
                            return time;
                        }
                        else
                        {
                            return TimeSpan.Zero;
                        }
                    }
                }
            }
            catch(SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }

        //This function is responsible for retrieving the time for the Morning Out basis
        public async Task<TimeSpan> GetMorningOutBasis()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select timeDesignation from tbl_timeDesignation where timeDesignationDescription = 'Morning Out'";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value && TimeSpan.TryParse(result.ToString(), out TimeSpan time))
                        {
                            return time;
                        }
                        else
                        {
                            return TimeSpan.Zero;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function is responsible for retrieving the time for the Morning Out basis
        public async Task<TimeSpan> GetAfternoonInBasis()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select timeDesignation from tbl_timeDesignation where timeDesignationDescription = 'Afternoon In'";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value && TimeSpan.TryParse(result.ToString(), out TimeSpan time))
                        {
                            return time;
                        }
                        else
                        {
                            return TimeSpan.Zero;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function is responsible for retrieving the time for the Morning Out basis
        public async Task<TimeSpan> GetAfternoonOutBasis()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select timeDesignation from tbl_timeDesignation where timeDesignationDescription = 'Afternoon Out'";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value && TimeSpan.TryParse(result.ToString(), out TimeSpan time))
                        {
                            return time;
                        }
                        else
                        {
                            return TimeSpan.Zero;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region All Add methods

        // This function would be responsible for inserting new log in employee DTR
        public async Task<bool> InsertNewMorningIn(int EmployeeId, DateTime DateLog, DateTime morningIn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, timeLog, timePeriodId, logTypeId) " +
                        "values (@employeeId, @dateLog, @morningIn, 1, 1)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", EmployeeId);
                        cmd.Parameters.AddWithValue("@dateLog", DateLog);
                        cmd.Parameters.AddWithValue("@morningIn", morningIn);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewMorningOut(int EmployeeId, DateTime DateLog, DateTime morningOut)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, timeLog, timePeriodId, logTypeId) " +
                        "values (@employeeId, @dateLog, @morningOut, 1, 2)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", EmployeeId);
                        cmd.Parameters.AddWithValue("@dateLog", DateLog);
                        cmd.Parameters.AddWithValue("@morningOut", morningOut);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewAfternoonIn(int EmployeeId, DateTime DateLog, DateTime afternoonIn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, timeLog, timePeriodId, logTypeId) " +
                        "values (@employeeId, @dateLog, @afternoonIn, 2, 1)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", EmployeeId);
                        cmd.Parameters.AddWithValue("@dateLog", DateLog);
                        cmd.Parameters.AddWithValue("@afternoonIn", afternoonIn);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewAfternoonOut(int EmployeeId, DateTime DateLog, DateTime afternoonOut)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, timeLog, timePeriodId, logTypeId) " +
                        "values (@employeeId, @dateLog, @afternoonOut, 2, 2)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", EmployeeId);
                        cmd.Parameters.AddWithValue("@dateLog", DateLog);
                        cmd.Parameters.AddWithValue("@afternoonOut", afternoonOut);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        //This function is responsible for updating the employee specific time log
        public async Task<bool> UpdateMorningInTimeLog(int timeLogId, DateTime UpdateMorningIn)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set timeLog = @updateMorningIn where timeLogId = @timeLogId";
                    
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);
                        cmd.Parameters.AddWithValue("@UpdateMorningIn", UpdateMorningIn);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateMorningOutTimeLog(int timeLogId, DateTime UpdateMorningOut)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set timeLog = @updateMorningOut where timeLogId = @timeLogId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);
                        cmd.Parameters.AddWithValue("@UpdateMorningOut", UpdateMorningOut);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateAfternoonInTimeLog(int timeLogId, DateTime UpdateAfternoonIn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set timeLog = @updateAfternoonIn where timeLogId = @timeLogId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);
                        cmd.Parameters.AddWithValue("@UpdateAfternoonIn", UpdateAfternoonIn);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateAfternoonOutTimeLog(int timeLogId, DateTime UpdateAfternoonOut)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set timeLog = @updateAfternoonOut where timeLogId = @timeLogId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);
                        cmd.Parameters.AddWithValue("@UpdateAfternoonOut", UpdateAfternoonOut);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }
    }
}
