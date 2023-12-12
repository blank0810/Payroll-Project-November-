using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel
{
    public class payrollClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public payrollClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<DataTable> GetPayrollSchedule()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "select payrollScheduleDescription from tbl_payrollSched";

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

        public async Task<DataTable> GetEmployeeList(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string commandText = "SELECT tbl_employee.employeeid, " +
                        "CONCAT(employeeFname, ' ', employeeLname) AS employeeName, " +
                        "employeePicture, departmentName " +
                        "FROM tbl_timeLog " +
                        "JOIN tbl_employee ON tbl_timeLog.employeeId = tbl_employee.employeeId " +
                        "JOIN tbl_department ON tbl_department.departmentId = tbl_employee.departmentId " +
                        "WHERE dateLog >= @fromDate AND dateLog <= @toDate " +
                        "GROUP BY tbl_employee.employeeid, employeeFname, employeeLname, " +
                        "employeePicture, departmentName";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
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

        public async Task<int> GetTotalHoursWorked()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string commandText = "SELECT SUM(totalHoursWorked) as totalHours FROM tbl_timeLog";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        // If result is not null, return it as int; otherwise, return 0
                        return result != null ? Convert.ToInt32(result) : 0;
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

        public async Task<bool> IsTimelogAlreadyProcessed(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string commandText = @"
                SELECT 
                    CASE 
                        WHEN COUNT(*) > 0 THEN 1 
                        ELSE 0 
                    END AS IsAlreadyProcessed
                FROM tbl_timeLog t
                WHERE t.timelogId IN (
                    SELECT timeLogId 
                    FROM tbl_timeLog 
                    WHERE dateLog >= @fromDate AND dateLog <= @toDate
                )
                AND EXISTS (
                    SELECT 1
                    FROM tbl_listOfWorkingDays l
                    WHERE l.timeLogId = t.timelogId
                )";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);

                        object result = await cmd.ExecuteScalarAsync();

                        // If result is not null and is equal to 1, consider it as true; otherwise, false
                        return result != null && Convert.ToInt32(result) == 1;
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

        public async Task<bool> InsertNewPayrollForm(int employeeId, DateTime dateCreated, DateTime startingDate, DateTime endingDate, 
            string salaryRateDescription, decimal amount, decimal totalEarnings, decimal totalDeduction, string createdBy, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_payrollForm (employeeId, dateCreated, payrollStartingDate, payrollEndingDate, " +
                        "salaryRateDescription, salaryRateValue, totalEarnings, totalDeduction, createdBy, statusId) " +
                        "values (@employeeId, @dateCreated, @startingDate, @endingDate, @salaryRateDescription, @amount, @earnings, " +
                        "@deduction, @createdBy, (select statusId from tbl_status where statusDecription = @status))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                        cmd.Parameters.AddWithValue("@startingDate", startingDate);
                        cmd.Parameters.AddWithValue("@endingDate", endingDate);
                        cmd.Parameters.AddWithValue("@salaryRateDescription", salaryRateDescription);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@earnings", totalEarnings);
                        cmd.Parameters.AddWithValue("@deduction", totalDeduction);
                        cmd.Parameters.AddWithValue("@createdBy", createdBy);
                        cmd.Parameters.AddWithValue("@status", status);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewEarnings(int employeeId, DateTime dateCreated, string earningsDescription, decimal amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_earningsList (payrollId, earningsDescription, earningsAmount) " +
                        "values ((select payrollId from tbl_payrollForm where employeeId = @employeeId and dateCreated = @dateCreated), " +
                        "@earningsDescription, @amount)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                        cmd.Parameters.AddWithValue("@earningsDescription", earningsDescription);
                        cmd.Parameters.AddWithValue("@amount", amount);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertDeductions(int employeeId, DateTime dateCreated, decimal employerShare, decimal personalShare, 
            string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_deductionDetails (payrollId, deductionDescription, employerShare, personalShare) " +
                        "values ((select payrollId from tbl_payrollForm where employeeId = @employeeId and dateCreated = @dateCreated), " +
                        "@description, @employerShare, @personalShare)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                        cmd.Parameters.AddWithValue("@employerShare", employerShare);
                        cmd.Parameters.AddWithValue("@personalShare", personalShare);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertPenalties(int employeeId, int  timeLogId, DateTime dateCreated, decimal employerShare, decimal personalShare,
            string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_deductionDetails (payrollId, timeLogId, deductionDescription, employerShare, personalShare) " +
                        "values ((select payrollId from tbl_payrollForm where employeeId = @employeeId and dateCreated = @dateCreated), " +
                        "@timeLogId, @description, @employerShare, @personalShare)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                        cmd.Parameters.AddWithValue("@employerShare", employerShare);
                        cmd.Parameters.AddWithValue("@personalShare", personalShare);
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);

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
