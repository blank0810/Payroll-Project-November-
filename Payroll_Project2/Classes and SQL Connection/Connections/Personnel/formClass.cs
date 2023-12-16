using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel
{
    public class formClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public formClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        #region Inside is the all Get Methods

        // This function is responsible for the Retrieval for the Personnel Name who logged In
        public async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeefname, employeelname from tbl_employee where employeeid = @userid";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                string name = reader["employeefname"].ToString() + " " + reader["employeelname"].ToString();
                                conn.Close();
                                return name;
                            }
                            else
                            {
                                conn.Close();
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function will only retrieve list of employee who have a submitted a travel order
        public async Task<DataTable> GetCompleteTravelList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_travelOrder.employeeId, employeeFname, employeeLname, departmentName, employeePicture from tbl_travelOrder " +
                        "join tbl_employee on tbl_travelOrder.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId where isApproved is not null";

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function will only retrieve list of employee who have a submitted a travel order but searched
        public async Task<DataTable> GetSearchCompleteTravelList(string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_travelOrder.employeeId, employeeFname, employeeLname, departmentName, employeePicture from tbl_travelOrder " +
                        "join tbl_employee on tbl_travelOrder.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId where isApproved is not null and " +
                        "(tbl_travelorder.employeeId = @search or tbl_travelorder.employeeId = (select employeeId from tbl_employee " +
                        "where employeeFname like '%'+@search+'%') or tbl_travelOrder.employeeId = (select employeeId from tbl_employee where " +
                        "employeeLname like '%'+@search+'%') or tbl_travelOrder.employeeId = (select employeeId from tbl_employee " +
                        "where concat(employeeFname, ' ', employeeLname) like '%'+@search+'%'))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);

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

        // This function will only retrieve list of employee who have a submitted a pass slip
        public async Task<DataTable> GetCompleteSlipList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_passSlip.employeeId, employeeFname, employeeLname, departmentName, employeePicture from tbl_passSlip " +
                        "join tbl_employee on tbl_passSlip.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId where isApproved is not null";

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function will only retrieve list of employee who have a submitted a pass slip but searched
        public async Task<DataTable> GetSearchCompleteSlipList(string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_passSlip.employeeId, employeeFname, employeeLname, departmentName, employeePicture from tbl_passSlip " +
                        "join tbl_employee on tbl_passSlip.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId where isApproved is not null and (tbl_passSlip.employeeId = " +
                        "@search or tbl_employee.employeeId = (select employeeId from tbl_employee where employeeFname like '%'+@search+'%') or " +
                        "tbl_passSlip.employeeId = (select employeeId from tbl_employee where employeeLname like '%'+@search+'%') or " +
                        "tbl_employee.employeeId = (select employeeId from tbl_employee where concat(employeeFname, ' ', employeeLname) like " +
                        "'%'+search+'%'))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);

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

        // This function will only retrieve list of employee who have a submitted a complete leave
        public async Task<DataTable> GetCompleteLeaveList()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_leave.employeeId, employeeFname, employeeLname, departmentName, employeePicture from tbl_leave " +
                        "join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId where isApproved is not null";
                    
                    using(cmd = new SqlCommand(command, conn))
                    {
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

        // This function will only retrieve list of employee who have a submitted a complete leave
        public async Task<DataTable> GetSearchCompleteLeaveList(string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_leave.employeeId, employeeFname, employeeLname, departmentName, employeePicture from tbl_leave " +
                        "join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId where isApproved is not null and (tbl_leave.employeeId = " +
                        "@search or tbl_leave.employeeId = (select employeeId from tbl_employee where employeeFname like '%'+@search+'%') or " +
                        "tbl_passSlip.employee = (select employeeId from tbl_employee where employeeLname like '%'+@search+'%') or " +
                        "tbl_passSlip.employeeId = (select employeeId from tbl_employee where concat(employeeFname, ' ', employeeLname) " +
                        "like '%'+@search+'%'))";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);

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

        // This function would be responsible for retrieving the list of all completed application for leave
        // On a specific employee
        public async Task<DataTable> GetEmployeeLeaveList(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select applicationNumber, statusDescription, approvedDate from tbl_leave " +
                        "join tbl_status on tbl_leave.statusId = tbl_status.statusId " +
                        "where isApproved is not null and isRecommended is not null " +
                        "and isCertified is not null and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            conn.Close();

                            if (dt != null)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function would be responsible for retrieving the list of all completed travel order
        // On a specific employee
        public async Task<DataTable> GetEmployeeTravelList(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select orderControlNumber, statusDescription, approvedDate from tbl_travelOrder " +
                        "join tbl_status on tbl_travelOrder.statusId = tbl_status.statusId " +
                        "where isApproved is not null and isNoted is not null " +
                        "and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            conn.Close();

                            if (dt != null)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function would be responsible for retrieving the list of all completed application for leave
        // On a specific employee
        public async Task<DataTable> GetEmployeeSlipList(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select slipControlNumber, statusDescription, approvedDate from tbl_passSlip " +
                        "join tbl_status on tbl_passSlip.statusId = tbl_status.statusId " +
                        "where isApproved is not null and isNoted is not null " +
                        "and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            conn.Close();

                            if (dt != null)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the list of all application for leave that needs approval
        public async Task<DataTable> GetLeaveList(string departmentName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_leave.employeeId, employeeFname, employeeLname, employeePicture, applicationNumber, departmentName, leaveType, dateFile " +
                        "from tbl_leave join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId join tbl_status " +
                        "on tbl_leave.statusId = tbl_status.statusId join tbl_leaveType on tbl_leave.typeId = tbl_leaveType.typeId " +
                        "where (certifiedBy is null and certificationDate is null and isRecommended is not null and dateRecommended is not null) " +
                        "or " +
                        "(departmentName = @departmentName and isRecommended is null)";
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);

                        using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            conn.Close();

                            if (dt != null)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the list of all application for leave that needs approval
        public async Task<DataTable> GetSearchLeaveList(string search, string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeeFname, employeeLname, employeePicture, leaveId, departmentName from tbl_leave " +
                        "join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId join tbl_department " +
                        "on tbl_employee.departmentId = tbl_department.departmentId join tbl_status " +
                        "on tbl_leave.statusId = tbl_status.statusId join tbl_leaveType where tbl_leave.typeId = tbl_leaveType.typeId " +
                        "where (certifiedBy is null and certificationDate is null and " +
                        "dateFile <= @date and tbl_leave.employeeId = @search or tbl_leave.employeeId = (select employeeId from tbl_employee " +
                        "where employeeFname like '%'+@search+'%') or tbl_leave.employeeId = (select employeeId from tbl_employee where " +
                        "concat(employeeFname, ' ', employeeLname) = '%'+@search+'%')) or " +
                        "(departmentName = @departmentName and isRecommended is null)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);
                        cmd.Parameters.AddWithValue("@departmentName", department);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            conn.Close();

                            if (dt != null)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the pass slip list that needs approval
        public async Task<DataTable> GetSlipList(string departmentName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeId, employeeFname, employeeLname, employeePicture, slipControlNumber, " +
                        "dateFile, departmentName from tbl_passSlip join tbl_employee on tbl_passSlip.employeeId = tbl_employee.employeeId " +
                        "join tbl_department on tbl_employee.departmentId = tbl_department.departmentId where isNoted is null and isApproved " +
                        "is null and departmentName = @department";

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the pass slip needs approval
        // But this function specifically is for searching
        public async Task<DataTable> GetSearchSlipList(string department, string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeId, employeeFname, employeeLname, employeePicture, slipControlNumber, " +
                        "dateFile, departmentName from tbl_passSlip join tbl_employee on tbl_passSlip.employeeId = tbl_employee.employeeId " +
                        "join tbl_department on tbl_employee.departmentId = tbl_department.departmentId where (isNoted is null and isApproved " +
                        "is null and departmentName = @department) or (tbl_passSlip.employeeId = @search or " +
                        "employeeFname like '%'+@search+'%' or employeeLname like '%'+@search+'%' " +
                        "or concat(employeeFname, ' ', employeeLname) like '%'+@search+'%')";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@search", search);

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

        // This function is responsible for retrieving the Travel order requests needs approval
        public async Task<DataTable> GetTravelList(string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_travelOrder.employeeId, employeeFname, employeeLname, employeePicture, orderControlNumber, " +
                        "dateFiled, departmentName from tbl_travelOrder join tbl_employee on tbl_employee.employeeId = " +
                        "tbl_travelOrder.employeeId join tbl_department on tbl_employee.departmentId = tbl_department.departmentId where " +
                        "isNoted is null and departmentName = @department";

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

        // This function is responsible for retrieving the travel order request that needs approval
        // But this function is for specifically for searching
        public async Task<DataTable> GetSearchTravelList(string department, string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_travelOrder.employeeId, employeeFname, employeeLname, employeePicture, orderControlNumber, " +
                        "dateFiled, departmentName from tbl_travelOrder join tbl_employee on tbl_employee.employeeId = " +
                        "tbl_travelOrder.employeeId join tbl_department on tbl_employee.departmentId = tbl_department.departmentId where " +
                        "(isNoted is null and departmentName = @department) or (tbl_travelOrder.employeeId = @search " +
                        "or employeeFname like '%'+@search+'%' or employeeLname like '%'+@search+'%' or concat(employeeFname, ' ', employeeLname) " +
                        "like '%'+@search+'%')";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@search", search);
                        
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

        // This function is responsible for the Retrieval for the Mayor's Name
        public async Task<string> GetMayorName(string userRole)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeefname, employeelname from tbl_employee join tbl_userrole on " +
                        "tbl_employee.roleid = tbl_userrole.roleid where rolename = @userrole";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@userrole", userRole);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                string name = reader["employeefname"].ToString() + " " + reader["employeelname"].ToString();
                                conn.Close();
                                return name;
                            }
                            else
                            {
                                conn.Close();
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for the Retrieval for the User Role Name
        // Purpose for this is to check if the user allowed to do a specific funtion
        public async Task<string> GetUserRole(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select roleName from tbl_employee join tbl_userrole on tbl_employee.roleid = tbl_userrole.roleid " +
                        "where employeeid = @userid";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);

                        object result = await cmd.ExecuteScalarAsync();
                        conn.Close();

                        if (result != null || result != DBNull.Value)
                        {
                            return (string)result;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is the one responsible for the retrieval for the Department Head of the employee based on his or her department
        public async Task<string> GetDepartmentHead(string department, string roleName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeefname, employeelname from tbl_employee join tbl_department on " +
                        "tbl_department.departmentid = tbl_employee.departmentid join tbl_userrole on tbl_userrole.roleid = tbl_employee.roleid " +
                        "where departmentname = @department and rolename = @rolename";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@rolename", roleName);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                string name = reader["employeefname"].ToString() + " " + reader["employeelname"].ToString();
                                conn.Close();
                                return name;
                            }
                            else
                            {
                                conn.Close();
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is the one responsible to retrieve the details of the employee being search
        public async Task<DataTable> GetSearchEmployee(string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeid, employeefname, employeelname, departmentname, " +
                        "employeepicture from tbl_employee join tbl_department on tbl_employee.departmentId = tbl_department.departmentId " +
                        "where tbl_employee.employeeid like '%'+@search+'%' or employeefname like '%'+@search+'%' or employeelname like '%'+@search+'%' " +
                        "or concat(employeeFname, ' ', employeeLname) like '%'+@search+'%' or departmentname like '%'+@search+'%'";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Inside is all the Add Methods

        // This function is responsible for the adding a new leave request
        public async Task<bool> AddLeave(int applicationNumber, int employeeId, DateTime dateFile, string leaveType, string formType, string leaveDetails,
            bool isRecommended, string recommendedBy, DateTime dateRecommended, bool isCertified, string certifiedBy, 
            DateTime certificationDate, string statusDescription, DateTime leaveStartDate, DateTime leaveEndDate, int numberOfDays, 
            decimal creditsUsed)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_leave (applicationNumber, employeeId, dateFile, typeId, formId, leaveDetails," +
                        "isRecommended, recommendedBy, dateRecommended, isCertified, certifiedBy, certificationDate, statusId, " +
                        "leaveStartDate, leaveEndDate, numberOfDays, creditsUsed) " +
                        "values (@applicationnumber, @employeeid, @datefile, (select typeid from tbl_leaveType where leaveType = @leavetype), " +
                        "(select formId from tbl_formType where formName = @formtype), @leavedetails, @isRecommended, @recommendedby, " +
                        "@daterecommended, @isCertified, @certifiedby, @certificationdate, " +
                        "(select statusid from tbl_status where statusdescription = @statusdescription), " +
                        "@leaveStartDate, @leaveEndDate, @numberOfDays, @creditsUsed)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationnumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@datefile", dateFile);
                        cmd.Parameters.AddWithValue("@leavetype", leaveType);
                        cmd.Parameters.AddWithValue("@formtype", formType);
                        cmd.Parameters.AddWithValue("@leavedetails", leaveDetails);
                        cmd.Parameters.AddWithValue("@isRecommended", isRecommended);
                        cmd.Parameters.AddWithValue("@recommendedby", recommendedBy);
                        cmd.Parameters.AddWithValue("@daterecommended", dateRecommended);
                        cmd.Parameters.AddWithValue("@isCertified", isCertified);
                        cmd.Parameters.AddWithValue("@certifiedBy", certifiedBy);
                        cmd.Parameters.AddWithValue("@certificationDate", certificationDate);
                        cmd.Parameters.AddWithValue("@statusdescription", statusDescription);
                        cmd.Parameters.AddWithValue("@leaveStartDate", leaveStartDate);
                        cmd.Parameters.AddWithValue("@leaveEndDate", leaveEndDate);
                        cmd.Parameters.AddWithValue("@numberOfDays", numberOfDays);
                        cmd.Parameters.AddWithValue("@credtisUsed", creditsUsed);

                        object result = await cmd.ExecuteNonQueryAsync();
                        conn.Close();

                        if ((int)result != 0)
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

        // This funcion is responsible for submitting a new pass slip request and saving it to the database
        public async Task<bool> AddPassSlip(int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate,
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime, 
            bool isNoted, string slipNotedBy, DateTime slipNotedDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_passSlip (slipControlNumber, employeeId, dateFile, slipDate, slipDestination, " +
                        "slipCreatedBy, formId, statusId, isNoted, slipNotedBy, slipNotedDate, slipStartingTime, slipEndingTime) " +
                        "values (@slipControlNumber, @employeeId, @dateFile, @slipDate, @slipDestination, @createdBy, (select formId from " +
                        "tbl_formType where formName = @formType), (select statusId from tbl_status where statusDescription = @status), " +
                        "@isNoted, @slipNotedBy, @slipNotedDate, @slipStartTime, @slipEndTime)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@slipControlNumber", slipControlNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateFile", dateFile);
                        cmd.Parameters.AddWithValue("@slipDate", slipDate);
                        cmd.Parameters.AddWithValue("@slipDestination", slipDestination);
                        cmd.Parameters.AddWithValue("@createdBy", createdBy);
                        cmd.Parameters.AddWithValue("@formType", formType);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@slipStartTime", slipStartTime);
                        cmd.Parameters.AddWithValue("@slipEndTime", slipEndTime);
                        cmd.Parameters.AddWithValue("@isNoted", isNoted);
                        cmd.Parameters.AddWithValue("@slipNotedBy", slipNotedBy);
                        cmd.Parameters.AddWithValue("@slipnotedDate", slipNotedDate);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding a new travel order request and saving it to the database
        public async Task<bool> AddPersonnelTravelOrder(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture, 
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks, string status, 
            string formName, string createdBy, DateTime createdDate, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_travelOrder (orderControlNumber, employeeId, dateFiled, dateDeparture, departureTime, " +
                        "returnTime, destination, purpose, remarks, statusId, formId, createdBy, createdDate, isNoted, notedBy, notedDate) " +
                        "values (@ordercontrolnumber, @employeeid, @datefiled, @datedeparture, @departuretime, @returntime, @destination, " +
                        "@purpose, @remarks, (select statusid from tbl_status where statusdescription = @status), " +
                        "(select formid from tbl_formType where formName = @formname), " +
                        "@createdby, @createddate, @isNoted, @notedBy, @notedDate)";
                    using(cmd = new SqlCommand(command, conn))
                    {
                        var parameters = new Dictionary<string, object>
                        {
                            { "@ordercontrolnumber", orderControlNumber },
                            { "@employeeid", employeeId },
                            { "@datefiled", dateFiled },
                            { "@datedeparture", dateDeparture },
                            { "@departuretime", departureTime },
                            { "@returntime", returnTime },
                            { "@destination", destination },
                            { "@purpose", purpose },
                            { "@remarks", remarks },
                            { "@status", status },
                            { "@formname", formName },
                            { "@createdby", createdBy },
                            { "@createddate", createdDate },
                            { "@isNoted", isNoted },
                            { "@notedBy", notedBy },
                            { "@notedDate", notedDate }
                        };

                        foreach (var parameter in  parameters)
                        {
                            cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }

                        object result = await cmd.ExecuteNonQueryAsync();
                        conn.Close();

                        if ((int)result != 0)
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

        #endregion

        // This function certifies the leave request
        public async Task<bool> UpdateLeaveRequest(int applicationNumber, string certifiedBy, DateTime certifiedDate, bool isCertify)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_leave set certifiedBy = @certifiedBy, certificationDate = @certifiedDate, " +
                        "isCertified = @isCertify where applicationNumber = @applicationNumber";
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@certifiedBy", certifiedBy);
                        cmd.Parameters.AddWithValue("@certifiedDate", certifiedDate);
                        cmd.Parameters.AddWithValue("@isCertify", isCertify);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result == 1;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}