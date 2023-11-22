using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel
{
    public class personnelDashboard
    {
        public int userId;
        public string password;
        private readonly string connectionString;
        SqlCommand cmd = new SqlCommand();

        public personnelDashboard()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        #region All Get Methods

        // This method retrieves the number of department saved in the database
        public async Task<int> GetNumberOfDepartment()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string departmentNumber = "select count(*) from tbl_department";
                using (cmd = new SqlCommand(departmentNumber, connection))
                {
                    object result = cmd.ExecuteScalar();
                    connection.Close();

                    int number = Convert.ToInt16(result);
                    return number;
                }
            }
        }

        // This method will retrieve the number of employee who is still active in the organization
        public async Task<int> GetNumberOfActive()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string numactive = "select count(*) from tbl_employee where isActive = @active";
                    await connection.OpenAsync();
                    using (cmd = new SqlCommand(numactive, connection))
                    {
                        cmd.Parameters.AddWithValue("@active", 1);
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            if (int.TryParse(result.ToString(), out int count))
                            {
                                return count;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This method will retrieve all department
        public async Task<DataTable> GetDepartmentList()
        {
            try
            {
                string queryParameter = "Department Head";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeeFname, employeeLname, departmentName, departmentLogo from tbl_department left join tbl_employee " +
                        "on tbl_department.departmentid = tbl_employee.departmentid and tbl_employee.roleid = (select roleId from tbl_userRole where " +
                        "rolename = @queryParameter)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@queryParameter", queryParameter);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            conn.Close();
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This method will retrieve the department searched by the user
        public async Task<DataTable> GetSearchDepartment(string search)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string command = "select departmentName, departmentlogo from tbl_department where departmentName like '%'+@search+'%'";
                    using (cmd = new SqlCommand(command, connection))
                    {
                        cmd.Parameters.AddWithValue("@search", search);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            connection.Close();
                            return dt;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function responsible for checking if the department being added exist or not
        public async Task<bool> CheckDepartment(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_department where departmentName = @departmentname";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentname", departmentName);

                        object result = await cmd.ExecuteScalarAsync();

                        if ((int)result == 0 || result == DBNull.Value)
                        {
                            return true;
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

        // This method will retrieve the total count the number of regular, job order, and total employee of a specific department
        // for the department card
        public async Task<DataTable> GetCounts(string departmentName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(case when employmentStatus = 'Job Order' then 1 end) as jobOrderCount, " +
                        "count(case when employmentStatus = 'Regular' then 1 end) as regularCount, " +
                        "count(*) employeeCount from tbl_employee join tbl_appointmentForm on " +
                        "tbl_appointmentForm.employeeid = tbl_employee.employeeId join tbl_department on " +
                        "tbl_department.departmentId = tbl_employee.departmentId join tbl_employmentStatus on " +
                        "tbl_appointmentForm.employmentStatusId = tbl_employmentStatus.employmentStatusId where " +
                        "departmentName = @department";

                    using(cmd = new SqlCommand(command, conn))
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

        #endregion

        #region All Add methods

        // This method will add a department into the database
        public async Task<bool> AddDepartment(string departmentName, string departmentInitial, string departmentLogo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string command = "Insert into tbl_department (departmentname, departmentInitial, departmentLogo) " +
                        "values (@departmentname, @departmentinitial, @departmentlogo)";
                    using (cmd = new SqlCommand(command,conn))
                    {
                        await conn.OpenAsync();
                        cmd.Parameters.AddWithValue("@departmentname", departmentName);
                        cmd.Parameters.AddWithValue("@departmentinitial", departmentInitial);
                        cmd.Parameters.AddWithValue("@departmentlogo", departmentLogo);

                        object result = await cmd.ExecuteNonQueryAsync();

                        if (result != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
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
        #endregion
    }
}
