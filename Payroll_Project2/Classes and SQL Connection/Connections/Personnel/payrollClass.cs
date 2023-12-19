using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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


        public async Task<int> GetPayrollId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT IDENT_CURRENT('tbl_payrollForm')";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && int.TryParse(result.ToString(), out int id))
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
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckBenefitExist(int detailsId, int month)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_deductionDetails " +
                        "join tbl_payrollForm on tbl_payrollForm.payrollId = tbl_deductionDetails.payrollId " +
                        "where month(dateCreated) = @month and detailsId = @detailsId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@detailsId", detailsId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count > 0;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> CertifyPayroll(bool certify, string name, DateTime certifiedDate, int payrollId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                UPDATE tbl_payrollForm 
                SET 
                    isCertifyByOficeHead = @certify,
                    certifiedByOfficeHeadName = @name,
                    certifedByOfficeHeadDate = @date
                WHERE 
                    payrollId = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@certify", certify);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@date", certifiedDate);
                        cmd.Parameters.AddWithValue("@id", payrollId);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0; // Returns true if any rows were affected
                    }
                }
            }
            catch (SqlException sql)
            {
                // Handle SQL exception
                throw sql;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }

        public async Task<bool> AddCreationPayrollTransactionLog(DateTime logDate, string description, int payrollId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_payrollTransactionLog (logDate, payrollId, logDescription) " +
                        "values (@logDate, @payrollId, @description)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logDate", logDate);
                        cmd.Parameters.AddWithValue("@payrollId", payrollId);;
                        cmd.Parameters.AddWithValue("@description", description);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<string> GetScheduleFormula(string schedule)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "select scheduleFormula from tbl_payrollSched where payrollScheduleDescription = @schedule";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@schedule", schedule);

                        object result = await cmd.ExecuteScalarAsync();

                        if(!string.IsNullOrEmpty(result?.ToString()))
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

        public async Task<DataTable> GetEmployeeAllowance(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "select allowanceName, allowanceValue from tbl_employeeAllowance " +
                        "join tbl_allowanceList on tbl_employeeAllowance.allowanceListId = tbl_allowanceList.allowanceListId " +
                        "join tbl_employee on tbl_employee.employeeId = tbl_employeeAllowance.employeeId " +
                        "where tbl_employee.employeeId = @employeeId and isAllowanceEnforced = 1";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

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

        public async Task<DataTable> GetAllEmployeeList(DateTime fromDate, DateTime toDate)
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

        public async Task<DataTable> GetSpecificEmployeeList(DateTime fromDate, DateTime toDate, string employmentStatus)
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
                        "JOIN tbl_appointmentForm ON tbl_employee.employeeId = tbl_appointmentForm.employeeId " +
                        "JOIN tbl_employmentStatus on tbl_appointmentForm.employmentStatusId = tbl_employmentStatus.employmentStatusId " +
                        "WHERE dateLog >= @fromDate AND dateLog <= @toDate and employmentStatus = @employmentStatus " +
                        "GROUP BY tbl_employee.employeeid, employeeFname, employeeLname, " +
                        "employeePicture, departmentName";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                        cmd.Parameters.AddWithValue("@employmentStatus", employmentStatus);

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

        public async Task<int> GetTotalHoursWorked(DateTime fromDate, DateTime toDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string commandText = "SELECT SUM(totalHoursWorked) as totalHours dateLog >= @fromDate and dateLog <= @toDate and " +
                        "employeeId = @employeeId";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

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
            string salaryRateDescription, decimal amount, decimal totalEarnings, decimal totalDeduction, string createdBy, string status, 
            string payslipType, decimal netPay)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_payrollForm (employeeId, dateCreated, payrollStartingDate, payrollEndingDate, " +
                        "salaryRateDescription, salaryRateValue, totalEarnings, totalDeduction, createdBy, statusId, payslipType, " +
                        "netAmount) " +
                        "values (@employeeId, @dateCreated, @startingDate, @endingDate, @salaryRateDescription, @amount, @earnings, " +
                        "@deduction, @createdBy, (select statusId from tbl_status where statusDecription = @status), @payslipType, " +
                        "@netAmount)";

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
                        cmd.Parameters.AddWithValue("@payslipType", payslipType);
                        cmd.Parameters.AddWithValue("@netAmout", netPay);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewEarnings(int payrollId, string earningsDescription, decimal amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_earningsList (payrollId, earningsDescription, earningsAmount) " +
                        "values (@payrollId, @earningsDescription, @amount)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@payrollId", payrollId);
                        cmd.Parameters.AddWithValue("@earningsDescription", earningsDescription);
                        cmd.Parameters.AddWithValue("@amount", amount);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertDeductions(int payrollId, decimal amount, string description, int detailsId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_deductionDetails (payrollId, deductionDescription, deductionAmount, detailsId) " +
                        "values (@payrollId, @description, @amount, @detailsId)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@payrollId", payrollId);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@detailsId", (detailsId != -1) ? (object)detailsId : DBNull.Value);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}
