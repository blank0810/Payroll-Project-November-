using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function
{
    public class dtrClass
    {
        private readonly string connectionString;
        static SqlCommand cmd;

        public dtrClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        //This function is responsible for retrieving the time for the Morning In basis
        public async Task<TimeSpan> GetMorningInBasis()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select timeDesignation from tbl_timeDesignation where timeDesignationDescription = 'Morning In'";

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
    }
}
