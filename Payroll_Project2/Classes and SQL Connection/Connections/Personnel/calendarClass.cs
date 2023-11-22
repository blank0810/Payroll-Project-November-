using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel
{
    public class calendarClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public calendarClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<string> GetEventName(DateTime date)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select eventName from tbl_calendarEvent where cast(eventStartDate as date) = @date";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        return (string)result;
                    }
                }
            }
            catch(SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetEventDetails(string EventName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select eventDescription, eventStartDate, eventEndDate, memorandumNumber, " +
                        "eventAddedBy from tbl_calendarEvent where eventName = @eventName";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@eventName", EventName);

                        using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch(SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }

        public async Task<bool> AddEvent(DateTime eventDateAdded, string eventName, string eventDescription, DateTime eventStartDate, DateTime eventEndDate, string memorandumNumber, string eventAddedBy)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_calendarEvent (eventDateAdded, eventName, eventDescription, eventStartDate, eventEndDate, " +
                        "memorandumNumber, eventAddedBy) values (@eventDateAdded, @eventName, @eventDescription, @eventStartDate, " +
                        "@eventEndDate, @memorandumNumber, @eventAddedBy)";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@eventDateAdded", eventDateAdded);
                        cmd.Parameters.AddWithValue("@eventName", eventName);
                        cmd.Parameters.AddWithValue("@eventDescription", eventDescription);
                        cmd.Parameters.AddWithValue("@eventStartDate", eventStartDate);
                        cmd.Parameters.AddWithValue("@eventEndDate", eventEndDate);
                        cmd.Parameters.AddWithValue("@memorandumNumber", memorandumNumber);
                        cmd.Parameters.AddWithValue("@eventAddedBy", eventAddedBy);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function would be responsible for inserting new log in employee DTR
        public async Task<bool> InsertNewLog(int EmployeeId, DateTime DateLog, string status)
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
                        cmd.Parameters.AddWithValue("@morningStatus", status ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@afternoonStatus", status ?? (object)DBNull.Value);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function will retrieve all employee Id saved in the database
        public async Task<DataTable> GetEmployeeId()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeeId from tbl_employee";

                    cmd = new SqlCommand( command, conn);

                    using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
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
