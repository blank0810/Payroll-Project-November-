using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function
{
    public class formManagementClass
    {
        private readonly string connectionString;
        static SqlCommand cmd;

        public formManagementClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        // This function is responsible for retrieving the list of employee that have leave requests thats needs to be noted
        public async Task<DataTable> GetLeaveRequestList(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName, tbl_leave.employeeId, applicationNumber, dateFile, " +
                        "leaveType, leaveStartDate, leaveEndDate from tbl_leave join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId " +
                        "join tbl_department on tbl_department.departmentId = tbl_employee.departmentId join tbl_leaveType on " +
                        "tbl_leave.typeId = tbl_leaveType.typeId " +
                        "where departmentName = @departmentName and " +
                        "isRecommended is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);

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

        // This function is responsible for retrieving the leave list of employee's under the department
        public async Task<DataTable> GetEmployeeList(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT CONCAT(employeeFname, ' ', employeeLname) AS employeeName, " +
                        "MAX(tbl_employee.employeeId) AS employeeId, " +
                        "MAX(employeePicture) AS employeePicture " +
                        "FROM tbl_leave " +
                        "JOIN tbl_employee ON tbl_employee.employeeId = tbl_leave.employeeId " +
                        "JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId " +
                        "WHERE departmentName = @department " +
                        "GROUP BY CONCAT(employeeFname, ' ', employeeLname)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);

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

        // This function is responsible for retrieving the list of employee that have travel order requests thats needs to be noted
        public async Task<DataTable> GetTravelRequestList(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeeFname, ' ', employeeLname) as employeeName, tbl_travelOrder.employeeId, " +
                        "orderControlNumber, dateFiled, dateDeparture " +
                        "from tbl_travelOrder join tbl_employee on tbl_travelOrder.employeeId = tbl_employee.employeeId " +
                        "join tbl_department on tbl_department.departmentId = tbl_employee.departmentId " +
                        "where departmentName = @departmentName and " +
                        "isNoted is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);

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

        // This function is responsible for retrieving the employee logs under the department
        public async Task<DataTable> GetTravelEmployeeList(string departmentName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT CONCAT(employeeFname, ' ', employeeLname) as employeeName, MAX(tbl_employee.employeeId) as " +
                        "employeeId, MAX(employeePicture) as employeePicture, COUNT(*) as total FROM tbl_travelOrder JOIN tbl_employee ON " +
                        "tbl_travelOrder.employeeId = tbl_employee.employeeId JOIN tbl_department ON tbl_department.departmentId = " +
                        "tbl_employee.departmentId WHERE departmentName = @departmentName GROUP BY CONCAT(employeeFname, ' ', employeeLname)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);

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

        // This function is responsible for retrieving the list of employee that have a pass slip request
        public async Task<DataTable> GetSlipRequestList(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeId, concat(employeeFname, ' ', employeeLname) as employeeName, slipControlNumber, " +
                        "dateFile from tbl_passSlip join tbl_employee on tbl_passSlip.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_department.departmentId = tbl_employee.departmentId where departmentName = @department and isNoted is null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", departmentName);

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

        // This function is responsible for retrieving the employee list for the slip logs
        public async Task<DataTable> GetSlipEmployeeList(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select max(tbl_employee.employeeId) as employeeId, max(employeePicture) as employeePicture, " +
                        "concat(employeeFname, ' ', employeeLname) as employeeName, count(*) as total from tbl_passSlip join tbl_employee " +
                        "on tbl_passSlip.employeeId = tbl_employee.employeeId join tbl_department on tbl_department.departmentId = " +
                        "tbl_employee.departmentId where departmentName = @department group by concat(employeeFname, ' ', employeeLname)";
                    
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", departmentName);

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
    }
}
