using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel
{
    public class employeeClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public employeeClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        // Double Click to display the methods
        #region Inside is all Get Methods

        // This function checks if the benefit if its mandated before make it inactive
        public async Task<bool> CheckBenefitIsMandated(int detailsId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving the number of years/months of the contract depending of the employment type
        public async Task<DataTable> GetContractLength(string employmentStatus)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select numberOfYears, numberOfMonths from tbl_contractLength join tbl_employmentStatus on tbl_contract" +
                        "Length.employmentStatusId = tbl_employmentStatus.employmentStatusId where employmentStatus = @status";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", employmentStatus);

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex;}
        }

        // This function is responsible for the the retrieving of list of pass slip that is being created and approved or denied for the employee's form list
        public async Task<DataTable> GetSlipList(int employeeId, int year)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select slipcontrolnumber, datefile, statusdescription from tbl_passslip join " +
                        "tbl_status on tbl_passslip.statusid = tbl_status.statusid where employeeid = @employeeid and " +
                        "year(dateFile) = @year";
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);
                        using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
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
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select ordercontrolnumber, datefiled, statusdescription from tbl_travelorder join " +
                        "tbl_status on tbl_travelorder.statusid = tbl_status.statusid where employeeid = @employeeid and " +
                        "year(dateFiled) = @year";
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);
                        using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
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
                    string command = "SELECT COUNT(*) AS custom_Count FROM tbl_salaryRate WHERE salaryratedescription LIKE '%' + @description + '%'";
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
                    string command = "select max(employeeId) from tbl_employee";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int lastId) && result != DBNull.Value)
                        {
                            return ++lastId;
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

        // This function is to retrieve the salary value of a salary grade
        public async Task<int> GetSalaryRateValue(string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select salaryvalue from tbl_salaryrate where salaryRateDescription = @description";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", description);

                        object result = await cmd.ExecuteScalarAsync();
                        conn.Close();

                        if (result != null && result != DBNull.Value)
                        {
                            return (int)result;
                        }
                        else
                        {
                            return -1;
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

        // This function is responsible for retrieving the list of available benefits that the employee can avail
        public async Task<DataTable> GetBenefitList(int employeeId, string employmentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT benefits, mb.benefitsId FROM tbl_mandatedBenefits mb join tbl_benefits on mb.benefitsId = tbl_benefits.benefitsId " +
                        "WHERE NOT EXISTS (SELECT 1 FROM tbl_appointmentFormBenefitsDetails ab WHERE mb.benefitsId = ab.benefitsId) AND ( " +
                        "mb.employmentStatusId = (SELECT employmentStatusId FROM tbl_appointmentForm WHERE employeeid = @employeeId) or " +
                        "mb.employmentStatusId = (select employmentStatusId from tbl_employmentStatus where employmentStatus = @employmentStatus));";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", (object)employeeId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@employmentStatus", employmentStatus ?? string.Empty);

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
                    string command = "select benefits, isPercentage, personalShareValue, employerShareValue, " +
                        "sum(personalShareValue + employerShareValue) as value " +
                        "from tbl_mandatedBenefits join tbl_benefits on tbl_mandatedBenefits.benefitsId = " +
                        "tbl_benefits.benefitsId join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = " +
                        "tbl_mandatedBenefits.employmentStatusId " +
                        "where employmentStatus = @status and isMandated = 1 group by benefits, isPercentage, personalShareValue, " +
                        "employerShareValue";

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
        public async Task<DataTable> GetUserRoles(string employmentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select roleName from tbl_employmentStatusAccess join tbl_employmentStatus on tbl_employmentStatusAccess." +
                        "employmentStatusId = tbl_employmentStatus.employmentStatusId join tbl_userRole on tbl_userRole.roleId = tbl_employment" +
                        "StatusAccess.roleId where employmentStatus = @status";
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
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function is responsible retrieving the list of salary rate saved in the database aside from custom ones
        public async Task<DataTable> GetSalaryRate()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select salaryratedescription from tbl_salaryrate where salaryratedescription not like '%custom%'";
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

        // This function is responsible for retrieving the all salary rate saved in the database
        // Purpose for this is when modifying the salary rate of an employee
        public async Task<DataTable> GetAllSalaryRate()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select salaryratedescription from tbl_salaryrate";
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

        // Function responsible for retrieving the minimum values of the benefit
        // Only the active contributions or contributions currently imposed
        public async Task<DataTable> GetValue(string benefitName)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select bc.benefitsId, isPercentage, employerShareValue, personalShareValue, " +
                        "sum(personalShareValue + employerShareValue) as " +
                        "totalValue from tbl_benefitsContributions bc join tbl_benefits b on b.benefitsId = bc.benefitsId " +
                        "where bc.benefitsId = (select benefitsId from tbl_benefits where benefits = 'SSS') and isBenefitContributionActive = 1 " +
                        "group by bc.benefitsId, isPercentage, personalShareValue, employerShareValue";
                    
                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefit", benefitName);

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

        // Function responsible for retrieving the default leave credits
        public async Task<DataTable> GetLeaveCredits()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
                        "departmentName = @department";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@roleName", roleName);
                        cmd.Parameters.AddWithValue("@department", department);

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

        // This function is responsible for retrieving the benefit ID based of a benefit name
        public async Task<int> GetBenefitId (string benefitName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "Select benefitsId from tbl_benefits where benefits = @benefitName";

                    using (cmd = new SqlCommand (command, conn))
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        #endregion for get methods

        #region Inside is all Add Methods

        // This function is responsible for adding a new salary rate which means the salary rate of the employee does not exist in the database
        // and needed to be a custom one
        public async Task<bool> AddSalaryRate(string description, int value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_salaryrate (salaryratedescription, salaryValue) " +
                        "values (@description, @value)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@value", value);

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding the new employee
        public async Task<bool> AddEmployee(string password, bool isActive, string fName, string lName, string mName, 
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
                    string command = "insert into tbl_employee (employeePassword, isActive, employeeFname, employeeLname, employeeMname, " +
                        "employeeBirth, employeeCivilStatus, employeeSex,employeeContactNumber, " +
                        "employeeEmailAddress, educationalAttainmentId, nameOfSchool, course, schoolAddress, departmentId,employeeJobDesc, " +
                        "roleId, employeePicture, employeeSignature, nationality, barangay, municipality, province, zipCode) "+
                        "values (@password, @accountStatus, @fname, @lname, @mname, @birthday, @civilstatus, @sex, " +
                        "@contactnumber, @emailaddress, (select educationalattainmentid from tbl_educationalattainment where educationalattainment " +
                        "= @educationalattainment), @schoolname, @course, @schooladdress, (select departmentid from tbl_department " +
                        "where departmentname = @department), " +
                        "@jobdescription, (select roleid from tbl_userrole where rolename = @rolename), @employeepicture, @employeesignature, " +
                        "@nationality, @barangay, @municipality, @province, @zipCode)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@accountstatus", isActive);
                        cmd.Parameters.AddWithValue("@fname", fName);
                        cmd.Parameters.AddWithValue("@lName", lName);
                        cmd.Parameters.AddWithValue("@mname", mName);
                        cmd.Parameters.AddWithValue("@birthday", birthday);
                        cmd.Parameters.AddWithValue("@civilstatus", civilStatus);
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.Parameters.AddWithValue("@contactnumber", contactNumber);
                        cmd.Parameters.AddWithValue("@emailaddress", emailAddress ?? (object) DBNull.Value);
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
                        cmd.Parameters.AddWithValue("@zipCode", zipCode ?? (object) DBNull.Value);

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

        // This function is responsible for adding a new appointment form for every employee being added
        public async Task<bool> AddAppointmentForm(int employeeId, string salaryRate, DateTime date, DateTime dateHired, DateTime? dateRetired, 
            string schedule, string employmentStatus, string morningShift, string afternoonShift)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_appointmentform (employeeid, salaryrateid, datecreated, datehired, " +
                        "dateretired, payrollschedid, employmentstatusid, morningShiftTime, afternoonShiftTime) " +
                        "values (@employeeid, (select salaryrateid from tbl_salaryrate where salaryratedescription = @salaryrate), " +
                        "@date, @datehired, @dateretired, " +
                        "(select payrollschedid from tbl_payrollsched where payrollscheduledescription = @schedule), " +
                        "(select employmentstatusid from tbl_employmentstatus where employmentstatus = @employmentstatus), @morningShift, " +
                        "@afternoonShift)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);
                        cmd.Parameters.AddWithValue("@salaryrate", salaryRate);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@datehired", dateHired);
                        cmd.Parameters.AddWithValue("@dateretired", dateRetired ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@schedule", schedule);
                        cmd.Parameters.AddWithValue("@employmentstatus", employmentStatus);
                        cmd.Parameters.AddWithValue("@morningShift", morningShift);
                        cmd.Parameters.AddWithValue("@afternoonShift", afternoonShift);

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

        // This function would be responsible for adding the employee default leave credits if it is regular
        public async Task<bool> AddEmployeeLeaveCredits(int employeeId, string leaveType, float numberOfCredits, int year)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_employeeLeaveCredits (employeeId, typeId, numberOfCredits, leaveCreditYear) " +
                        "values (@employeeId, (select typeId from tbl_leaveType where leaveType = @leaveType), @numberOfCredits, @year)";

                    using(cmd = new SqlCommand(command, conn))
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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

        // This function would be responsible for inserting new log in employee DTR
        public async Task<bool> InsertNewLog(int EmployeeId, DateTime DateLog, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_timeLog (employeeId, dateLog, morningStatus, afternoonStatus) " +
                        "values (@employeeId, @dateLog, @morningStatus, @afternoonStatus)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", EmployeeId);
                        cmd.Parameters.AddWithValue("@dateLog", DateLog);
                        cmd.Parameters.AddWithValue("@morningStatus", status);
                        cmd.Parameters.AddWithValue("@afternoonStatus", status);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion for add methods

        #region Inside is all Update Methods

        public async Task<bool> UpdateEmployeeAndAppointmentForm(int employeeId, string fName, string lName, string mName, DateTime birthday, string barangay, string municipality, string province, string zipCode, string civilStatus, string sex, string contactNumber, string emailAddress, string educationalAttainment, string schoolName, string course, string schoolAddress, string department, string jobDescription, string roleName, string employeePicture, string employeeSignature, string nationality, string salaryRate, DateTime dateRetired, string payrollSched, string employmentStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    await UpdateAppointmentForm(conn, transaction, employeeId, salaryRate, dateRetired, payrollSched, employmentStatus);
                    await UpdateEmployeeData(conn, transaction, employeeId, fName, lName, mName, birthday, barangay, municipality, province, zipCode, civilStatus, sex, contactNumber, emailAddress, educationalAttainment, schoolName, course, schoolAddress, department, jobDescription, roleName, employeePicture, employeeSignature, nationality);

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // This function is responsible if there someone will modify the employee's appointment form
        public async Task UpdateAppointmentForm(SqlConnection conn, SqlTransaction transaction, int employeeId, string salaryRate, DateTime dateRetired, string payrollSched, string employmentStatus)
        {
            try
            {
                string command = "UPDATE tbl_appointmentform SET salaryrateid = (SELECT salaryrateid FROM tbl_salaryRate WHERE " +
                    "salaryratedescription = @salaryrate), dateretired = @dateretired, payrollSchedid = (select payrollSchedid from " +
                    "tbl_payrollSched where payrollScheduleDescription = @payrollSched), employmentStatusId = (select employmentStatusId from " +
                    "tbl_employmentStatus where employmentStatus = @employmentStatus) " +
                    "WHERE appointmentformid = (SELECT appointmentFormId FROM tbl_appointmentForm WHERE employeeId = @employeeId)";

                using (SqlCommand cmd = new SqlCommand(command, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.Parameters.AddWithValue("@salaryrate", salaryRate);
                    cmd.Parameters.AddWithValue("@dateretired", dateRetired);
                    cmd.Parameters.AddWithValue("@payrollSched", payrollSched);
                    cmd.Parameters.AddWithValue("@employmentStatus", employmentStatus);
                    // Include other parameters

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected != 1)
                    {
                        throw new Exception("Error updating appointment form.");
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for updating an Employee's Data
        public async Task UpdateEmployeeData(SqlConnection conn, SqlTransaction transaction, int employeeId, string fName, string lName, string mName, DateTime birthday, string barangay, string municipality, string province, string zipCode, string civilStatus, string sex, string contactNumber, string emailAddress, string educationalAttainment, string schoolName, string course, string schoolAddress, string department, string jobDescription, string roleName, string employeePicture, string employeeSignature, string nationality)
        {
            try
            {
                string query = @"UPDATE tbl_employee 
                    SET employeeFname = @fname, 
                        employeeLname = @lname, 
                        employeeMname = @mName, 
                        employeeBirth = @birthday, 
                        barangay = @barangay, 
                        municipality = @municipality, 
                        province = @province, 
                        zipCode = @zipCode, 
                        employeecivilstatus = @civilstatus, 
                        nationality = @nationality, 
                        employeesex = @sex, 
                        employeecontactnumber = @contactnumber, 
                        employeeemailaddress = @emailaddress, 
                        educationalattainmentid = 
                            (SELECT educationalattainmentid 
                             FROM tbl_educationalattainment 
                             WHERE educationalattainment = @educationalattainment), 
                        nameofschool = @schoolname, 
                        course = @course, 
                        schooladdress = @schooladdress, 
                        departmentid = 
                            (SELECT departmentid 
                             FROM tbl_department 
                             WHERE departmentname = @department), 
                        employeejobdesc = @jobdescription, 
                        roleid = 
                            (SELECT roleid 
                             FROM tbl_userrole 
                             WHERE rolename = @rolename), 
                        employeepicture = @employeepicture, 
                        employeesignature = @employeesignature 
                    WHERE employeeId = @employeeid";

                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mName", mName);
                    cmd.Parameters.AddWithValue("@birthday", birthday);
                    cmd.Parameters.AddWithValue("@barangay", barangay);
                    cmd.Parameters.AddWithValue("@municipality", municipality);
                    cmd.Parameters.AddWithValue("@province", province);
                    cmd.Parameters.AddWithValue("@zipCode", string.IsNullOrEmpty(zipCode) ? (object)DBNull.Value : zipCode);
                    cmd.Parameters.AddWithValue("@civilstatus", civilStatus);
                    cmd.Parameters.AddWithValue("@nationality", nationality);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@contactnumber", contactNumber);
                    cmd.Parameters.AddWithValue("@emailaddress", emailAddress);
                    cmd.Parameters.AddWithValue("@educationalattainment", educationalAttainment);
                    cmd.Parameters.AddWithValue("@schoolname", schoolName);
                    cmd.Parameters.AddWithValue("@course", course);
                    cmd.Parameters.AddWithValue("@schooladdress", schoolAddress);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@jobdescription", jobDescription);
                    cmd.Parameters.AddWithValue("@rolename", roleName);
                    cmd.Parameters.AddWithValue("@employeepicture", employeePicture);
                    cmd.Parameters.AddWithValue("@employeesignature", employeeSignature);
                    cmd.Parameters.AddWithValue("@employeeid", employeeId);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected != 1)
                    {
                        throw new Exception("Error updating employee data.");
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

        // This function is responsible if there is an update or modification for the employee's salary rate
        public async Task<bool> UpdateSalaryRate(string salaryDescription, int salaryValue)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_salaryrate set salaryvalue = @salaryvalue where salaryratedescription = @salarydescription";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@salaryvalue", salaryValue);
                        cmd.Parameters.AddWithValue("@salarydescription", salaryDescription);

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

        // This function is responsible if a benefit of an employee will be change its status
        public async Task<bool> UpdateEmployeeBenefitStatus(int id, bool updateStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_appointmentformBenefitsDetails set isBenefitActive = @updateValue where detailsId = @id";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@updateValue", updateStatus);
                        cmd.Parameters.AddWithValue("@id", id);

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

        // This function is responsible for updating the employee picture
        public async Task<bool> UpdateEmployeePicture(int id, string imageSource)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_employee set employeePicture = @imageSource where employeeId = @id";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@imageSource", imageSource);
                        cmd.Parameters.AddWithValue("@id", id);

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

        #endregion for update methods
    }
}
