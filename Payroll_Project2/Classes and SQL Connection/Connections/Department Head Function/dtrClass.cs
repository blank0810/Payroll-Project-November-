using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        // This function is responsible for retrieving the all list of employee in the database
        public async Task<DataTable> GetEmployeeList(int offset, int recordPerPage, string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = $"SELECT " +
                        "tbl_employee.employeeid, employeefname, employeelname, departmentname, " +
                        "employeejobdesc, employmentstatus, employeepicture, morningShiftTime, afternoonShiftTime " +
                        "FROM tbl_employee " +
                        "JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId " +
                        "JOIN tbl_appointmentform ON tbl_employee.employeeid = tbl_appointmentform.employeeid " +
                        "JOIN tbl_employmentstatus ON tbl_appointmentform.employmentstatusid = tbl_employmentstatus.employmentstatusid " +
                        "WHERE departmentname = @department " +
                        "ORDER BY tbl_employee.employeeId " +
                        $"OFFSET @offset ROWS FETCH NEXT @recordPerPage ROWS ONLY";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@recordPerPage", recordPerPage);
                        cmd.Parameters.AddWithValue("offset", offset);
                        cmd.Parameters.AddWithValue("@department", department);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            conn.Close();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This method retrieves the number of employee saved in the database
        public async Task<int> GetNumberOfEmployee(string department)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string numOfEmployee = "select count(*) from tbl_employee " +
                        "join tbl_department on tbl_department.departmentId = tbl_employee.departmentId " +
                        "where departmentName = @department";
                    await connection.OpenAsync();

                    using (cmd = new SqlCommand(numOfEmployee, connection))
                    {
                        cmd.Parameters.AddWithValue("@department", department);

                        int employee = (int)cmd.ExecuteScalar();
                        connection.Close();
                        return employee;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
