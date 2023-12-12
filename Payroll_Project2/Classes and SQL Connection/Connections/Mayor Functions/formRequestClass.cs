using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions
{
    public class formRequestClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public formRequestClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<bool> CheckIfEmployeeHasLog(DateTime dateLog, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_timeLog where dateLog = @dateLog and employeeId = @employeeId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@dateLog", dateLog);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (!string.IsNullOrEmpty(result?.ToString()) && int.TryParse(result.ToString(), out int count))
                        {
                            return count > 0;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving the list of leave request needed to be approved
        public async Task<DataTable> GetLeaveRequestList(string department, int offset, int recordPerPage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName, applicationNumber, dateFile, leaveType, " +
                        "leaveStartDate, leaveEndDate, tbl_employee.employeeId, isRecommended " +
                        "from tbl_leave " +
                        "join tbl_employee on tbl_employee.employeeId = tbl_leave.employeeId " +
                        "join tbl_leaveType on tbl_leaveType.typeId = tbl_leave.typeId " +
                        "join tbl_department on tbl_employee.departmentId = tbl_department.departmentId " +
                        "where (departmentName = @department " +
                        "and isRecommended is null " +
                        "and isApproved is null) " +
                        "or (isRecommended is not null " +
                        "and isCertified is not null " +
                        "and isApproved is null) " +
                        "order by applicationNumber offset @offset rows fetch next @recordPerPage rows only";
                    
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@recordPerPage", recordPerPage);

                        using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
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

        // This function is responsible for retrieving the list of travel order request needed to be approved
        public async Task<DataTable> GetTravelRequest(string department, int offset, int recordPerPage)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName, dateFiled, orderControlNumber, " +
                        "dateDeparture, tbl_employee.employeeId, " +
                        "isNoted from tbl_travelOrder " +
                        "join tbl_employee on tbl_travelOrder.employeeId = tbl_employee.employeeId " +
                        "join tbl_department on tbl_department.departmentId = tbl_employee.departmentId " +
                        "where (departmentName = @department and isNoted is null and isApproved is null) " +
                        "or (isApproved is null and isNoted is not null) " +
                        "order by orderControlNumber offset @offset rows fetch next @recordPerPage rows only";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@recordPerPage", recordPerPage);

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

        // This function is responsible for retrieving the list of pass slip request needed to be approved
        public async Task<DataTable> GetSlipRequest(string department, int offset, int recordPerPage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT CONCAT(employeeFname, ' ', employeeLname) AS employeeName, dateFile, slipControlNumber, " +
                        "isNoted, CAST(slipEndingTime - slipStartingTime AS TIME) AS timeUsed, tbl_employee.employeeId, slipDate " +
                        "FROM tbl_passSlip " +
                        "JOIN tbl_employee ON tbl_passSlip.employeeId = tbl_employee.employeeId " +
                        "JOIN tbl_department ON tbl_department.departmentId = tbl_employee.departmentId " +
                        "WHERE (departmentName = @department AND isNoted IS NULL AND isApproved IS NULL) " +
                        "OR (isApproved IS NULL AND isNoted IS NOT NULL) " +
                        "ORDER BY slipControlNumber OFFSET @offset ROWS FETCH NEXT @recordPerPage ROWS ONLY";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@recordPerPage", recordPerPage);

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

        // This function is responsible for approving the leave request
        public async Task<bool> ApproveLeaveRequest(int applicationNumber, bool isApproved, string approvedBy, DateTime approvedDate, 
            bool isWithPay, int approvedNumberOfDay, string status, string reason)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_leave set " +
                        "isApproved = @isApproved, " +
                        "approvedBy = @approvedBy, " +
                        "approvedDate = @approvedDate, " +
                        "withPay = @isWithPay, " +
                        "approvedNumberDay = @approvedNumberOfDay, " +
                        "statusId = (select statusId from tbl_status where statusDescription = @status), " +
                        "disapproveReason = @reason " +
                        "where applicationNumber = @applicationNumber";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@isApproved", isApproved);
                        cmd.Parameters.AddWithValue("@approvedBy", approvedBy);
                        cmd.Parameters.AddWithValue("@approvedDate", approvedDate);
                        cmd.Parameters.AddWithValue("@isWithPay", isWithPay);
                        cmd.Parameters.AddWithValue("@approvedNumberOfDay", approvedNumberOfDay);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@reason", reason);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for approving the travel order request
        public async Task<bool> ApproveTravelRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate, 
            string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string command = "update tbl_travelOrder set " +
                    "isApproved = @isApproved, " +
                    "approvedBy = @approvedBy, " +
                    "approvedDate = @approvedDate, " +
                    "statusId = (select statusId from tbl_status where statusDescription = @status) " +
                    "where orderControlNumber = @controlNumber";

                using (cmd = new SqlCommand(command, conn))
                {
                    cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                    cmd.Parameters.AddWithValue("@isApproved", isApproved);
                    cmd.Parameters.AddWithValue("@approvedBy", approvedBy);
                    cmd.Parameters.AddWithValue("@approvedDate", approvedDate);
                    cmd.Parameters.AddWithValue("@status", status);


                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        // This function is responsible for approving pass slip request
        public async Task<bool> ApproveSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate,
            string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_passSlip set " +
                        "isApproved = @isApproved, " +
                        "approvedBy = @approvedBy, " +
                        "approvedDate = @approvedDate, " +
                        "statusId = (select statusId from tbl_status where statusDescription = @status) " +
                        "where slipControlNumber = @controlNumber";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                        cmd.Parameters.AddWithValue("@isApproved", isApproved);
                        cmd.Parameters.AddWithValue("@approvedBy", approvedBy);
                        cmd.Parameters.AddWithValue("@approvedDate", approvedDate);
                        cmd.Parameters.AddWithValue("@status", status);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for deducting leave credits after the approval if its approved
        public async Task<bool> UpdateEmployeeLeaveCredits(int employeeId, string leaveType, decimal newCredits)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_employeeLeaveCredits set " +
                        "numberOfCredits = @newCredits " +
                        "where employeeId = @employeeId and typeId = (select typeId from tbl_leaveType where leaveType = @leaveType)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@leaveType", leaveType);
                        cmd.Parameters.AddWithValue("@newCredits", newCredits);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex;}
        }

        // This function is responsible for deducting employee's slip hours if employee pass slip is approved
        public async Task<bool> UpdateEmployeeSlipHours(int employeeId, int month, int year, TimeSpan newHours)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_employeePassSlipHours " +
                        "set " +
                        "numberOfHours = @newHours " +
                        "where employeeId = @employeeId " +
                        "and month = @month " +
                        "and year = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@newHours", newHours);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", year);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding the leave into employee DTR
        public async Task<bool> AddLeaveSpecialPrivilegeLog(int applicationNumber, DateTime dateLog, string remarks, string description)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_specialPrivilege (specialPrivilegeLogDate, applicationNumber, " +
                        "specialPrivilegeDescription, specialPrivilegeRemarks) " +
                        "values (@dateLog, @applicationNumber, @description, @remarks)";

                    using (cmd = new SqlCommand (command, conn))
                    {
                        cmd.Parameters.AddWithValue("@dateLog", dateLog);
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@remarks", remarks);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding the leave into employee DTR
        public async Task<bool> AddTravelSpecialPrivilegeLog(int orderControlNumber, DateTime dateLog, string remarks, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_specialPrivilege (specialPrivilegeLogDate, orderControlNumber, " +
                        "specialPrivilegeDescription, specialPrivilegeRemarks) " +
                        "values (@dateLog, @orderControlNumber, @description, @remarks)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@dateLog", dateLog);
                        cmd.Parameters.AddWithValue("@orderControlNumber", orderControlNumber);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@remarks", remarks);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding the leave into employee DTR
        public async Task<bool> AddSlipSpecialPrivilegeLog(int slipControlNumber, DateTime dateLog, string remarks, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_specialPrivilege (specialPrivilegeLogDate, slipControlNumber, " +
                        "specialPrivilegeDescription, specialPrivilegeRemarks) " +
                        "values (@dateLog, @slipControlNumber, @description, @remarks)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@dateLog", dateLog);
                        cmd.Parameters.AddWithValue("@slipControlNumber", slipControlNumber);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@remarks", remarks);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateExistingLeaveDTRLog(int applicationNumber, DateTime logDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set specialPrivilegeId = (select specialPrivilegeId from tbl_specialPrivilege " +
                        "where applicationNumber = @applicationNumber) where employeeId = @employeeId and dateLog = @logDate";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@logDate", logDate);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateExistingTravelDTRLog(int controlNumber, DateTime logDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set specialPrivilegeId = (select specialPrivilegeId from tbl_specialPrivilege " +
                        "where orderControlNumber = @controlNumber) where employeeId = @employeeId and dateLog = @logDate";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", controlNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@logDate", logDate);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateExistingSlipDTRLog(int controlNumber, DateTime logDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_timeLog set specialPrivilegeId = (select specialPrivilegeId from tbl_specialPrivilege " +
                        "where slipControlNumber = @controlNumber) where employeeId = @employeeId and dateLog = @logDate";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@logDate", logDate);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewLeaveDTRLog(int applicationNumber, DateTime logDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_timeLog (dateLog, employeeId, specialPrivilegeId) " +
                        "values (@logDate, @employeeId, (select specialPrivilegeId from tbl_specialPrivilege where applicationNumber = " +
                        "@applicationNumber))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@logDate", logDate);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewTravelDTRLog(int controlNumber, DateTime logDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_timeLog (dateLog, employeeId, specialPrivilegeId) " +
                        "values (@logDate, @employeeId, (select specialPrivilegeId from tbl_specialPrivilege " +
                        "where orderControlNumber = @controlNumber))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@logDate", logDate);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> InsertNewSlipDTRLog(int controlNumber, DateTime logDate, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_timeLog (dateLog, employeeId, specialPrivilegeId) " +
                        "values (@logDate, @employeeId, (select specialPrivilegeId from tbl_specialPrivilege " +
                        "where slipControlNumber = @controlNumber))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@logDate", logDate);

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
