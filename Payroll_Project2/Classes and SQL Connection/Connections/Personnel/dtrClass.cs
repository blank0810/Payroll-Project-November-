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

        //This function will be responsible for retrieving the count of an employee's number of work days
        // But based on a specific Date
        public async Task<int> GetSpecificWorkDaysCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'On Time' or afternoonStatus = " +
                        "'On Time') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of Leave
        //Based on specific date
        public async Task<int> GetSpecificleaveCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'Leave' or afternoonStatus = " +
                        "'Leave') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of Travel Order
        public async Task<int> GetSpecificTravelOrderCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'Travel Order' or afternoonStatus = " +
                        "'Travel Order') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of Pass Slip
        public async Task<int> GetSpecificPassSlipCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'Pass Slip' or afternoonStatus = " +
                        "'Pass Slip') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of late
        public async Task<int> GetSpecificLateCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'Late' or afternoonStatus = " +
                        "'Late') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of undertime
        public async Task<int> GetSpecificUndertimeCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'Undertime' or afternoonStatus = " +
                        "'Undertime') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of overtime
        public async Task<int> GetSpecificOvertimeCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'Overtime' or afternoonStatus = " +
                        "'Overtime') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of absent
        public async Task<int> GetSpecificAbsentCount(int employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as late from tbl_timeLog where (morningStatus = 'Absent' or afternoonStatus = " +
                        "'Absent') and logDate between @fromDate and @toDate and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == DBNull.Value || result == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return (int)result;
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
        public async Task<bool> InsertNewLog(int EmployeeId, DateTime DateLog, DateTime? MorningIn, DateTime? MorningOut, string MorningStatus, DateTime? AfternoonIn, DateTime? AfternoonOut, string AfternoonStatus, int TotalHoursWorked)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, morningIn, morningOut, morningStatus, afternoonIn, afternoonOut, afternoonStatus, totalHoursWorked) " +
                        "values (@employeeId, @dateLog, @morningIn, @morningOut, @morningStatus, @afternoonIn, @afternoonOut, @afternoonStatus, @totalHoursWorked)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", EmployeeId);
                        cmd.Parameters.AddWithValue("@dateLog", DateLog);
                        cmd.Parameters.AddWithValue("@morningIn", MorningIn ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@morningOut", MorningOut ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@morningStatus", MorningStatus ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@afternoonIn", AfternoonIn ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@afternoonOut", AfternoonOut ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@afternoonStatus", AfternoonStatus ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@totalHoursWorked", TotalHoursWorked);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        //This function is responsible for updating the employee specific time log
        public async Task<bool> UpdateTimeLog(int timeLogId, DateTime UpdateMorningIn, DateTime? UpdateMorningOut, string UpdateMorningStatus, DateTime? UpdateAfternoonIn, DateTime? UpdateAfternoonOut, string UpdateAfternoonStatus, int TotalHours)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set morningIn = @UpdateMorningIn, morningOut = @UpdateMorningOut, " +
                        "morningStatus = @UpdateMorningStatus, afternoonIn = @UpdateAfternoonIn, afternoonOut = @UpdateAfternoonOut, " +
                        "afternoonStatus = @UpdateAfternoonStatus, totalHoursWorked = @total where timeLogId = @timeLogId";
                    
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);
                        cmd.Parameters.AddWithValue("@UpdateMorningIn", UpdateMorningIn);
                        cmd.Parameters.AddWithValue("@UpdateMorningOut", UpdateMorningOut);
                        cmd.Parameters.AddWithValue("@UpdateMorningStatus", UpdateMorningStatus);
                        cmd.Parameters.AddWithValue("@UpdateAfternoonIn", UpdateAfternoonIn);
                        cmd.Parameters.AddWithValue("@UpdateAfternoonOut", UpdateAfternoonOut);
                        cmd.Parameters.AddWithValue("@UpdateAfternoonStatus", UpdateAfternoonStatus);
                        cmd.Parameters.AddWithValue("@total", TotalHours);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}
