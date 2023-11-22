using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions
{
    public class mayorDashboard
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public mayorDashboard()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        // This function is responsible for retrieving the count of leave request
        public async Task<int> GetNumberOfLeaveRequest(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT COUNT(*) AS leaveRequestCount " +
                                     "FROM tbl_leave " +
                                     "JOIN tbl_employee ON tbl_leave.employeeId = tbl_employee.employeeId " +
                                     "JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId " +
                                     "WHERE (tbl_department.departmentName = @department " +
                                     "AND tbl_leave.isRecommended IS NULL " +
                                     "AND tbl_leave.isCertified IS NOT NULL " +
                                     "AND tbl_leave.isApproved IS NULL) " +
                                     "OR (tbl_leave.isRecommended IS NOT NULL " +
                                     "AND tbl_leave.isCertified IS NOT NULL " +
                                     "AND tbl_leave.isApproved IS NULL)";

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
                    string command = "SELECT COUNT(*) " +
                                     "FROM tbl_travelOrder " +
                                     "JOIN tbl_employee ON tbl_travelOrder.employeeId = tbl_employee.employeeId " +
                                     "JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId " +
                                     "WHERE (tbl_department.departmentName = @department " +
                                     "AND tbl_travelOrder.isNoted IS NULL " +
                                     "AND tbl_travelOrder.isApproved IS NULL) " +
                                     "OR (tbl_travelOrder.isApproved IS NULL and isNoted is not null)";

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
                    string command = "SELECT COUNT(*) " +
                                     "FROM tbl_passSlip " +
                                     "JOIN tbl_employee ON tbl_passSlip.employeeId = tbl_employee.employeeId " +
                                     "JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId " +
                                     "WHERE (tbl_department.departmentName = @department " +
                                     "AND tbl_passSlip.isNoted IS NULL " +
                                     "AND tbl_passSlip.isApproved IS NULL) " +
                                     "OR (tbl_passSlip.isApproved IS NULL and isNoted is not null)";

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
    }
}
