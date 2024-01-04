using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator
{
    public class employeeClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public employeeClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        #region Inside is all Get Methods

        public async Task<DataTable> GetEmployeeList(string roleName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = $"SELECT " +
                        "tbl_employee.employeeid, concat(employeeFname, ' ', employeeLname) as employeeName, departmentname, " +
                        "employeejobdesc, employmentstatus, employeepicture, morningShiftTime, afternoonShiftTime " +
                        "FROM tbl_employee " +
                        "JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId " +
                        "JOIN tbl_appointmentform ON tbl_employee.employeeid = tbl_appointmentform.employeeid " +
                        "JOIN tbl_employmentstatus ON tbl_appointmentform.employmentstatusid = tbl_employmentstatus.employmentstatusid " +
                        "JOIN tbl_userRole ON tbl_userRole.roleId = tbl_employee.roleId " +
                        "WHERE roleName = @roleName ";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@roleName", roleName);

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

        // This function retrieves the allowance list employee can avail
        public async Task<DataTable> GetAllowanceList(string employmentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT tbl_allowanceList.allowanceListId, allowanceMinimumValue, allowanceName " +
                                     "FROM tbl_employeeAllowanceAccess " +
                                     "JOIN tbl_allowanceList ON tbl_employeeAllowanceAccess.allowanceListId = tbl_allowanceList.allowanceListId " +
                                     "JOIN tbl_employmentStatus ON tbl_employeeAllowanceAccess.employmentStatusId = tbl_employmentStatus.employmentStatusId " +
                                     "WHERE employmentStatus = @employmentStatus";

                    using (cmd = new SqlCommand(command, conn))
                    {
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the salary amount and step number based on the salary rate value Id
        public async Task<DataTable> GetSalaryRateDetails(int salaryRateValueId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select salaryRateDescription, salaryRateStepDescription, amount from tbl_salaryRateValue " +
                        "join tbl_salaryRate on tbl_salaryRate.salaryRateId = tbl_salaryRateValue.salaryRateId " +
                        "left join tbl_salaryRateStep on tbl_salaryRateStep.stepId = tbl_salaryRateValue.stepId " +
                        "where salaryRateValueId = @salaryRateValueId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@salaryRateValueId", salaryRateValueId);

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

        // This function checks if the benefit if its mandated before make it inactive
        public async Task<bool> CheckBenefitIsMandated(int detailsId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select isMandated from tbl_mandatedBenefits where benefitsId = (select benefitsId from " +
                        "tbl_appointmentFormBenefitsDetails where detailsId = @detailsId)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@detailsId", detailsId);

                        object result = await cmd.ExecuteScalarAsync();

                        return (bool)result;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving the number of years/months of the contract depending of the employment type
        public async Task<DataTable> GetContractLength(string employmentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select numberOfYears, numberOfMonths from tbl_contractLength join tbl_employmentStatus on tbl_contract" +
                        "Length.employmentStatusId = tbl_employmentStatus.employmentStatusId where employmentStatus = @status";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", employmentStatus);

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

        // This function is responsible for the the retrieving of list of leave that is being created and approved or denied for the
        // employee's form list
        public async Task<DataTable> GetLeaveList(int employeeId, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select applicationnumber, datefile, statusdescription from tbl_leave join " +
                        "tbl_status on tbl_leave.statusid = tbl_status.statusid where employeeid = @employeeid and " +
                        "year(dateFile) = @year";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);
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

        // This function is responsible for the the retrieving of list of pass slip that is being created and approved or denied for the employee's form list
        public async Task<DataTable> GetSlipList(int employeeId, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select slipcontrolnumber, datefile, statusdescription from tbl_passslip join " +
                        "tbl_status on tbl_passslip.statusid = tbl_status.statusid where employeeid = @employeeid and " +
                        "year(dateFile) = @year";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);
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

        // This function is responsible for the the retrieving of list of travel order that is being created and approved or denied for the employee's form list
        public async Task<DataTable> GetTravelList(int employeeId, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select ordercontrolnumber, datefiled, statusdescription from tbl_travelorder join " +
                        "tbl_status on tbl_travelorder.statusid = tbl_status.statusid where employeeid = @employeeid and " +
                        "year(dateFiled) = @year";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);
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

        // This function is responsible for checking the custom salary count if the salary rate is being created as a custom or not in the database
        public async Task<int> GetCustomSalaryCount(string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT COUNT(*) AS custom_Count FROM tbl_salaryRate WHERE salaryratedescription " +
                        "LIKE '%' + @description + '%'";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", description);

                        Object result = await cmd.ExecuteScalarAsync();
                        conn.Close();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            return count;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for showing the salary schedule of the employee
        // This is being shown in employee's appointment form
        public async Task<DataTable> GetScheduleDescription()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select payrollscheduledescription from tbl_payrollsched";

                    using (cmd = new SqlCommand(command, conn))
                    {
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
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function is responsible for retrieving the last employeeId
        // Purpose for this is that to increment the retrieved value for to automatically assigned an Id to the new added employee
        public async Task<int> GetEmployeeId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT IDENT_CURRENT('tbl_employee')";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int lastId) && result != DBNull.Value)
                        {
                            return lastId;
                        }
                        else
                        {
                            return 1;
                        }

                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the employee appointment form and its details
        public async Task<DataTable> GetEmployeeAppointmentForm(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select appointmentFormId, salaryRateDescription, payrollScheduleDescription, salaryValue, dateCreated, " +
                        "employmentStatus from tbl_appointmentForm join tbl_salaryRate on " +
                        "tbl_appointmentForm.salaryRateId = tbl_salaryRate.salaryRateId join tbl_payrollSched on " +
                        "tbl_appointmentform.payrollschedid = tbl_payrollSched.payrollSchedId join tbl_employmentStatus " +
                        "on tbl_appointmentform.employmentstatusid = tbl_employmentStatus.employmentStatusId where employeeid = @id";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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

        // This function get the benefits that is mandated that will be added during the addition of employee
        public async Task<DataTable> GetBenefitList(string employmentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select benefits " +
                        "from tbl_mandatedBenefits join tbl_benefits on tbl_mandatedBenefits.benefitsId = " +
                        "tbl_benefits.benefitsId join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = " +
                        "tbl_mandatedBenefits.employmentStatusId " +
                        "where employmentStatus = @status and isMandated = 0";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", employmentStatus);

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

        // This function is responsible for retrieving the list of available benefits that the employee can avail
        public async Task<DataTable> GetAvailableBenefitList(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT DISTINCT mb.benefitsId, tb.benefits FROM tbl_mandatedBenefits mb " +
                        "JOIN tbl_benefits tb ON mb.benefitsId = tb.benefitsId " +
                        "LEFT JOIN tbl_appointmentFormBenefitsDetails ab ON mb.benefitsId = ab.benefitsId " +
                        "AND ab.appointmentFormId = (SELECT appointmentFormId FROM tbl_appointmentForm WHERE employeeid = @employeeId) " +
                        "WHERE mb.employmentStatusId = (SELECT TOP 1 employmentStatusId FROM tbl_appointmentForm WHERE employeeid = @employeeId) " +
                        "AND ab.benefitsId IS NULL";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

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

        // This function is responsible for retrieving the benefits listed in the database
        public async Task<DataTable> GetMandatedBenefit(string employmentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT isPercentage, benefits, tbl_benefits.benefitsId " +
                                     "FROM tbl_mandatedBenefits " +
                                     "JOIN tbl_benefits ON tbl_mandatedBenefits.benefitsId = tbl_benefits.benefitsId " +
                                     "JOIN tbl_employmentStatus ON tbl_employmentStatus.employmentStatusId = tbl_mandatedBenefits.employmentStatusId " +
                                     "LEFT JOIN tbl_benefitsContributions ON tbl_mandatedBenefits.benefitsId = tbl_benefitsContributions.benefitsid " +
                                     "AND tbl_benefitsContributions.isBenefitContributionActive = 1 " +
                                     "WHERE employmentStatus = @status AND isMandated = 1";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", employmentStatus);

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

        // This function is responsible for retrieving the List of all educational attainment saved in the database
        public async Task<DataTable> GetEducationalAttainment()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select educationalattainment from tbl_educationalattainment";
                    using (cmd = new SqlCommand(command, conn))
                    {
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

        // This function is responsible for retrieving the list of all user roles saved in the database
        public async Task<DataTable> GetUserRoles(string employmentStatus, string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select roleName from tbl_employmentStatusAccess " +
                        "join tbl_userRole on tbl_userRole.roleId = tbl_employmentStatusAccess.roleId " +
                        "join tbl_department on tbl_department.departmentId = tbl_employmentStatusAccess.departmentId " +
                        "join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = tbl_employmentStatusAccess.employmentStatusId " +
                        "where employmentStatus = @status and tbl_department.departmentName = @departmentName";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", employmentStatus);
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);

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
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the minimum values of the benefit
        // Only the active contributions or contributions currently imposed
        public async Task<DataTable> GetValue(string benefitName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select bc.benefitsId, isPercentage, employerShareValue, personalShareValue, " +
                        "sum(personalShareValue + employerShareValue) as " +
                        "totalValue from tbl_benefitsContributions bc join tbl_benefits b on b.benefitsId = bc.benefitsId " +
                        "where bc.benefitsId = (select benefitsId from tbl_benefits where benefits = 'SSS') and isBenefitContributionActive = 1 " +
                        "group by bc.benefitsId, isPercentage, personalShareValue, employerShareValue";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefit", benefitName);

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

        // Function responsible for retrieving the default leave credits
        public async Task<DataTable> GetLeaveCredits()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select leaveType, numberOfCredits from tbl_leaveDefaultCredits join tbl_leaveType on tbl_leaveDefaultCredits.typeId " +
                        "= tbl_leaveType.typeId";

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

        // Function responsible for retrieving the count of a specific user role purpose for this is to check if its allowed to add new employee
        // with the same user role. It is used for restriction e.g only 1 department head every department
        public async Task<int> GetRoleCount(string roleName, string department)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_employee join tbl_userRole on tbl_employee.roleId = tbl_userRole.roleId " +
                        "join tbl_department on tbl_employee.departmentId = tbl_department.departmentId where roleName = @roleName and " +
                        "departmentName = @department and roleName != 'Employee'";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@roleName", roleName);
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

        // This function is responsible for retrieving the benefit ID based of a benefit name
        public async Task<int> GetBenefitId(string benefitName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "Select benefitsId from tbl_benefits where benefits = @benefitName";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitName", benefitName);

                        object result = await cmd.ExecuteScalarAsync();


                        if (result != null && result != DBNull.Value)
                        {
                            if (int.TryParse(result.ToString(), out int parsed))
                            {
                                return parsed;
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion for get methods

        // This function is responsible for adding the new employee
        public async Task<bool> AppointMayor(string password, bool isActive, string fName, string lName, string mName,
            DateTime birthday, string civilStatus, string sex, string contactNumber, string emailAddress, string educationalAttainment,
            string schoolName, string course, string schoolAddress, string department, string jobDescription, string roleName,
            string employeePicture, string employeeSignature, string nationality, string barangay, string municipality, string province,
            string zipCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string command = "insert into tbl_employee (employeePassword, isActive, employeeFname, employeeLname, employeeMname, " +
                                "employeeBirth, employeeCivilStatus, employeeSex,employeeContactNumber, " +
                                "employeeEmailAddress, educationalAttainmentId, nameOfSchool, course, schoolAddress, departmentId,employeeJobDesc, " +
                                "roleId, employeePicture, employeeSignature, nationality, barangay, municipality, province, zipCode) " +
                                "values (@password, @accountStatus, @fname, @lname, @mname, @birthday, @civilstatus, @sex, " +
                                "@contactnumber, @emailaddress, (select educationalattainmentid from tbl_educationalattainment where educationalattainment " +
                                "= @educationalattainment), @schoolname, @course, @schooladdress, (select departmentid from tbl_department " +
                                "where departmentname = @department), " +
                                "@jobdescription, (select roleid from tbl_userrole where rolename = @rolename), @employeepicture, @employeesignature, " +
                                "@nationality, @barangay, @municipality, @province, @zipCode)";

                            using (cmd = new SqlCommand(command, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@accountstatus", isActive);
                                cmd.Parameters.AddWithValue("@fname", fName);
                                cmd.Parameters.AddWithValue("@lName", lName);
                                cmd.Parameters.AddWithValue("@mname", mName ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@birthday", birthday);
                                cmd.Parameters.AddWithValue("@civilstatus", civilStatus);
                                cmd.Parameters.AddWithValue("@sex", sex);
                                cmd.Parameters.AddWithValue("@contactnumber", contactNumber);
                                cmd.Parameters.AddWithValue("@emailaddress", emailAddress ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@educationalattainment", educationalAttainment);
                                cmd.Parameters.AddWithValue("@schoolname", schoolName);
                                cmd.Parameters.AddWithValue("@course", course);
                                cmd.Parameters.AddWithValue("@schooladdress", schoolAddress);
                                cmd.Parameters.AddWithValue("@department", department);
                                cmd.Parameters.AddWithValue("@jobdescription", jobDescription);
                                cmd.Parameters.AddWithValue("@rolename", roleName);
                                cmd.Parameters.AddWithValue("@employeepicture", employeePicture);
                                cmd.Parameters.AddWithValue("@employeesignature", employeeSignature);
                                cmd.Parameters.AddWithValue("@nationality", nationality);
                                cmd.Parameters.AddWithValue("@barangay", barangay);
                                cmd.Parameters.AddWithValue("@municipality", municipality);
                                cmd.Parameters.AddWithValue("@province", province);
                                cmd.Parameters.AddWithValue("@zipCode", zipCode ?? (object)DBNull.Value);

                                int result = await cmd.ExecuteNonQueryAsync();

                                if (result > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding the new employee
        public async Task<bool> AppointEmployee(string password, bool isActive, string fName, string lName, string mName,
            DateTime birthday, string civilStatus, string sex, string contactNumber, string emailAddress, string educationalAttainment,
            string schoolName, string course, string schoolAddress, string department, string jobDescription, string roleName,
            string employeePicture, string employeeSignature, string nationality, string barangay, string municipality, string province,
            string zipCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string command = "insert into tbl_employee (employeePassword, isActive, employeeFname, employeeLname, employeeMname, " +
                                "employeeBirth, employeeCivilStatus, employeeSex,employeeContactNumber, " +
                                "employeeEmailAddress, educationalAttainmentId, nameOfSchool, course, schoolAddress, departmentId,employeeJobDesc, " +
                                "roleId, employeePicture, employeeSignature, nationality, barangay, municipality, province, zipCode) " +
                                "values (@password, @accountStatus, @fname, @lname, @mname, @birthday, @civilstatus, @sex, " +
                                "@contactnumber, @emailaddress, (select educationalattainmentid from tbl_educationalattainment where educationalattainment " +
                                "= @educationalattainment), @schoolname, @course, @schooladdress, (select departmentid from tbl_department " +
                                "where departmentname = @department), " +
                                "@jobdescription, (select roleid from tbl_userrole where rolename = @rolename), @employeepicture, @employeesignature, " +
                                "@nationality, @barangay, @municipality, @province, @zipCode)";

                            using (cmd = new SqlCommand(command, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@accountstatus", isActive);
                                cmd.Parameters.AddWithValue("@fname", fName);
                                cmd.Parameters.AddWithValue("@lName", lName);
                                cmd.Parameters.AddWithValue("@mname", mName ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@birthday", birthday);
                                cmd.Parameters.AddWithValue("@civilstatus", civilStatus);
                                cmd.Parameters.AddWithValue("@sex", sex);
                                cmd.Parameters.AddWithValue("@contactnumber", contactNumber);
                                cmd.Parameters.AddWithValue("@emailaddress", emailAddress ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@educationalattainment", educationalAttainment);
                                cmd.Parameters.AddWithValue("@schoolname", schoolName);
                                cmd.Parameters.AddWithValue("@course", course);
                                cmd.Parameters.AddWithValue("@schooladdress", schoolAddress);
                                cmd.Parameters.AddWithValue("@department", department);
                                cmd.Parameters.AddWithValue("@jobdescription", jobDescription);
                                cmd.Parameters.AddWithValue("@rolename", roleName);
                                cmd.Parameters.AddWithValue("@employeepicture", employeePicture);
                                cmd.Parameters.AddWithValue("@employeesignature", employeeSignature);
                                cmd.Parameters.AddWithValue("@nationality", nationality);
                                cmd.Parameters.AddWithValue("@barangay", barangay);
                                cmd.Parameters.AddWithValue("@municipality", municipality);
                                cmd.Parameters.AddWithValue("@province", province);
                                cmd.Parameters.AddWithValue("@zipCode", zipCode ?? (object)DBNull.Value);

                                int result = await cmd.ExecuteNonQueryAsync();

                                if (result > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function inserts employee allowance available or mandated to  them
        public async Task<bool> InsertEmployeeAllowance(int employeeId, int allowanceListId, decimal value, bool allowanceStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_employeeAllowance (allowanceListId, employeeId, allowanceValue, isAllowanceEnforced) " +
                        "values (@allowanceListId, @employeeId, @value, @allowanceStatus)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@allowanceListId", allowanceListId);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.Parameters.AddWithValue("@allowanceStatus", allowanceStatus);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> AddSalaryRate(string description, string schedule)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string command = "INSERT INTO tbl_salaryrate (salaryratedescription, salaryRateSchedule) " +
                                "VALUES (@description, @schedule)";

                            using (cmd = new SqlCommand(command, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@description", description);
                                cmd.Parameters.AddWithValue("@schedule", schedule);

                                int result = await cmd.ExecuteNonQueryAsync();

                                if (result > 0)
                                {
                                    // If everything is successful, commit the transaction
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    // If the result is not greater than 0, consider rolling back the transaction
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions and rollback the transaction
                            transaction.Rollback();
                            throw ex;
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

        // This function is responsible for adding the salary value of the custom salary rate
        public async Task<bool> AddCustomValue(string customDescription, decimal value, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string command = "Insert into tbl_salaryRateValue (salaryRateId, amount, tranchedId, yearEffective, isActive) " +
                                "values ((select salaryRateId from tbl_salaryRate where salaryRateDescription = @customDescription), " +
                                "@value, (select trancheId from tbl_salaryRateTranche where isTrancheUsed = 1), @year, 1)";

                            using (cmd = new SqlCommand(command, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@customDescription", customDescription);
                                cmd.Parameters.AddWithValue("@value", value);
                                cmd.Parameters.AddWithValue("@year", year);

                                int result = await cmd.ExecuteNonQueryAsync();

                                if (result > 0)
                                {
                                    // If everything is successful, commit the transaction
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    // If the result is not greater than 0, consider rolling back the transaction
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions and rollback the transaction
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> AddAppointmentForm(int employeeId, decimal amount, DateTime date, DateTime dateHired, DateTime? dateRetired,
            string schedule, string employmentStatus, string morningShift, string afternoonShift, DateTime dateNextStepIncrement)
        {
            try
            {
                // Open a new SqlConnection and initiate a SqlTransaction
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // SQL command to insert a new record into tbl_appointmentform
                            string command = "INSERT INTO tbl_appointmentform (employeeid, salaryRateValueId, datecreated, datehired, " +
                                              "dateretired, payrollschedid, employmentstatusid, morningShiftTime, afternoonShiftTime, " +
                                              "salaryRateValueNextStepIncrement) " +
                                              "VALUES (@employeeid, (SELECT salaryRateValueId FROM tbl_salaryRateValue WHERE amount = @amount), @date, @datehired, " +
                                              "@dateretired, (SELECT payrollschedid FROM tbl_payrollsched WHERE payrollscheduledescription = @schedule), " +
                                              "(SELECT employmentstatusid FROM tbl_employmentstatus WHERE employmentstatus = @employmentstatus), @morningShift, " +
                                              "@afternoonShift, @dateNextStepIncrement)";

                            // Execute the command
                            using (cmd = new SqlCommand(command, conn, transaction))
                            {
                                // Set parameters for the SQL command
                                cmd.Parameters.AddWithValue("@employeeid", employeeId);
                                cmd.Parameters.AddWithValue("@amount", amount);
                                cmd.Parameters.AddWithValue("@date", date);
                                cmd.Parameters.AddWithValue("@datehired", dateHired);
                                cmd.Parameters.AddWithValue("@dateretired", dateRetired ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@schedule", schedule);
                                cmd.Parameters.AddWithValue("@employmentstatus", employmentStatus);
                                cmd.Parameters.AddWithValue("@morningShift", morningShift);
                                cmd.Parameters.AddWithValue("@afternoonShift", afternoonShift);
                                cmd.Parameters.AddWithValue("@dateNextStepIncrement", dateNextStepIncrement);

                                // Execute the command and get the result
                                int result = await cmd.ExecuteNonQueryAsync();

                                // Commit or rollback the transaction based on the result
                                if (result > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions and rollback the transaction
                            transaction.Rollback();
                            throw ex;
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

        // This function would be responsible for adding the employee default leave credits if it is regular
        public async Task<bool> AddEmployeeLeaveCredits(int employeeId, string leaveType, float numberOfCredits, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_employeeLeaveCredits (employeeId, typeId, numberOfCredits, leaveCreditYear) " +
                        "values (@employeeId, (select typeId from tbl_leaveType where leaveType = @leaveType), @numberOfCredits, @year)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@leaveType", leaveType);
                        cmd.Parameters.AddWithValue("@numberOfCredits", numberOfCredits);
                        cmd.Parameters.AddWithValue("@year", year);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function would be responsible for adding the employee's pass slip hours
        public async Task<bool> AddEmployeeSlipHours(int employeeId, int month, int year, TimeSpan numberOfHours)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_employeePassSlipHours (employeeId, month, year, numberOfHours) " +
                        "values (@employeeId, @month, @year, @numberOfHours)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@numberOfHours", numberOfHours);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding new employee logs related to every employee data changes
        public async Task<bool> AddEmployeeDataLog(int employeeId, DateTime date, string description, string caption)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_employeeDataLogChanges (employeeid, datelog, logdescription, logCaption) " +
                        "values (@employeeid, @date, @description, @caption)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@caption", caption);

                        object result = await cmd.ExecuteNonQueryAsync();
                        conn.Close();

                        if ((int)result == 1)
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

        // This function is responsible for adding new benefit if the employee's choice of benefit is not in the database
        public async Task<bool> AddBenefit(string benefitName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_benefits (benefits) values (@benefitName)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitName", benefitName);
                        object result = await cmd.ExecuteNonQueryAsync();
                        conn.Close();

                        if ((int)result > 0)
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
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function is responsible for adding the employee's benefit into their appointment form
        public async Task<bool> AddEmployeeBenefit(int id, int benefitId, decimal personalShare, decimal employerShare, bool isBenefitActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_appointmentformBenefitsDetails " +
                        "(appointmentFormId, benefitsId, isBenefitActive, personalShareValue,employerShareValue) " +
                        "values " +
                        "((select appointmentFormId from tbl_appointmentForm where employeeId = @id), " +
                        "@benefitsId, @isBenefitActive, @personalShare, @employerShare)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@benefitsId", benefitId);
                        cmd.Parameters.AddWithValue("@isBenefitActive", isBenefitActive);
                        cmd.Parameters.AddWithValue("@personalShare", (personalShare != -1) ? (object)personalShare : DBNull.Value);
                        cmd.Parameters.AddWithValue("@employerShare", (employerShare != -1) ? (object)employerShare : DBNull.Value);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
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
        // This function inserts employee allowance available or mandated to  them
       
        public async Task<bool> UpdateEmployeeAccountStatus(int employeeId, bool isActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_employee " +
                        "set " +
                        "isActive = @isActive " +
                        "where employeeId = @employeeId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

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
