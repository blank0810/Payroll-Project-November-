using System;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function
{
    public class dashboardClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public dashboardClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        // This function retrieves the number of employee associated with a specific department
        public async Task<int> GetNumberOfEmployee(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_employee join tbl_department on tbl_employee.departmentId = " +
                        "tbl_department.departmentId where departmentName = @department";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", departmentName);

                        object result = await cmd.ExecuteScalarAsync();

                        if(result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function retrieves the number of employee who are present today
        public async Task<int> GetNumberOfPresent(string department, string present, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_employee join tbl_department on tbl_employee.departmentId = " +
                        "tbl_department.departmentId join tbl_timeLog on tbl_employee.employeeId = tbl_timeLog.employeeId " +
                        "where departmentName = @department and (morningStatus = @present or afternoonStatus = @present) and " +
                        "(dateLog = @date)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@present", present);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function retrieves the number of employee who are absent today
        public async Task<int> GetNumberOfAbsent(string department, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_employee join tbl_department on tbl_employee.departmentId = " +
                        "tbl_department.departmentId left join tbl_timeLog on tbl_employee.employeeId = tbl_timeLog.employeeId " +
                        "where departmentName = @department and dateLog = @date and dateLog is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function retrieves the number of employee who are late today
        public async Task<int> GetNumberOfLate(string department, string late, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_employee join tbl_department on tbl_employee.departmentId = " +
                        "tbl_department.departmentId join tbl_timeLog on tbl_employee.employeeId = tbl_timeLog.employeeId " +
                        "where departmentName = @department and (morningStatus = @late or afternoonStatus = @late) and " +
                        "(dateLog = @date)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@late", late);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of leave request
        public async Task<int> GetNumberOfLeaveRequest(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_leave join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId join " +
                        "tbl_department on tbl_employee.departmentId = tbl_department.departmentId where departmentName = @department and " +
                        "isRecommended is null and isCertified is null and isApproved is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of travel request
        public async Task<int> GetNumberOfTravelRequest(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_travelOrder join tbl_employee on tbl_travelOrder.employeeId = " +
                        "tbl_employee.employeeId join tbl_department on tbl_employee.departmentId = tbl_department.departmentId " +
                        "where departmentName = @department and isNoted is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the count of pass slip request
        public async Task<int> GetNumberOfSlipRequest(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_passSlip join tbl_employee on tbl_passSlip.employeeId = " +
                        "tbl_employee.employeeId join tbl_department on tbl_employee.departmentId = tbl_department.departmentId " +
                        "where departmentName = @department and isNoted is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the Employee List time logs on that department
        public async Task<DataTable> GetEmployeeTimeLogs(string department, DateTime date)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName, employeePicture, tbl_timeLog.employeeId, " +
                        "morningIn, morningOut, morningStatus, afternoonIn, afternoonOut, afternoonStatus, employeeJobDesc from tbl_timeLog join " +
                        "tbl_employee on tbl_timeLog.employeeId = tbl_employee.employeeId join tbl_department on tbl_employee.departmentId = " +
                        "tbl_employee.departmentId where departmentName = @department and dateLog = @date";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@date", date);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }
    }
}
