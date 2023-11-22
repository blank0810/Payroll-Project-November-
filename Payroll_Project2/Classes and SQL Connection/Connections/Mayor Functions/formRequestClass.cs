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
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName, dateFile, slipControlNumber, isNoted " +
                        "from tbl_passSlip " +
                        "join tbl_employee on tbl_passSlip.employeeId = tbl_employee.employeeId " +
                        "join tbl_department on tbl_department.departmentId = tbl_employee.departmentId " +
                        "where (departmentName = @department and isNoted is null and isApproved is null) " +
                        "or (isApproved is null and isNoted is not null) " +
                        "order by slipControlNumber offset @offset rows fetch next @recordPerPage rows only";

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
                    "statusId = (select statusId from tbl_status where statusDescription = @status)" +
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
        public async Task<bool> ApproveSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_passSlip set " +
                        "isApproved = @isApproved, " +
                        "approvedBy = @approvedBy, " +
                        "approvedDate = @approvedDate " +
                        "where slipControlNumber = @controlNumber";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);
                        cmd.Parameters.AddWithValue("@isApproved", isApproved);
                        cmd.Parameters.AddWithValue("@approvedBy", approvedBy);
                        cmd.Parameters.AddWithValue("@approvedDate", approvedDate);

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

        // This function is responsible for adding the leave into employee DTR
        public async Task<bool> AddDTRLog(int employeeId, DateTime dateLog, string status, int totalHours)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, morningStatus, afternoonStatus, totalHoursWorked) " +
                        "values (@employeeId, @dateLog, @morningStatus, @afternoonStatus, @totalHours)";

                    using (cmd = new SqlCommand (command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateLog", dateLog);
                        cmd.Parameters.AddWithValue("@morningStatus", status);
                        cmd.Parameters.AddWithValue("@afternoonStatus", status);
                        cmd.Parameters.AddWithValue("@totalHours", totalHours);

                        int result = await cmd.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}
