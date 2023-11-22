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
    public class subordinateManagementClass
    {
        private readonly string connectionString;
        static SqlCommand cmd;

        public subordinateManagementClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        // This function is responsible for retrieving the list of employee in a specified department
        public async Task<DataTable> GetDepartmentEmployeeList(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeePicture, concat(employeeFname, ' ', employeeLname) as employeeName, employeeJobDesc, " +
                        "employeeEmailAddress, employeeContactNumber, departmentName, employmentStatus from tbl_employee join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId join tbl_appointmentForm on tbl_employee.employeeId = " +
                        "tbl_appointmentForm.employeeId join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = tbl_appointmentForm." +
                        "employmentStatusId where departmentName = @department";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);

                        using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
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
