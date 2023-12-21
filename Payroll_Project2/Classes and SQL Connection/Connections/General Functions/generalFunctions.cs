using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions
{

    // This class is responsible for storing functions that deemed to be general
    // Purpose for this is to be able to reuse codes and not necesarry to create a new functions if the functions is deemed also being used to other
    // User Interfaces and Window Forms

    public class generalFunctions
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public generalFunctions()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<bool> CertifyThePassSlip(int payrollFormId, string name, DateTime certifyDate, bool certifyStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_payrollForm set isCertifyByOfficeHead = @certifyStatus, certifiedByOfficeHeadName = @name, " +
                        "certifiedByOfficeHeadDate = @certifyDate " +
                        "where payrollFormId = @payrollFormId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@certifyStatus", certifyStatus);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@certifyDate", certifyDate);
                        cmd.Parameters.AddWithValue("@payrollFormId", payrollFormId);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetEarningsList(int payrollFormId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select earningsDescription, earningsAmount " +
                        "from tbl_earningsList " +
                        "where payrollId = (select payrollId from tbl_payrollForm where payrollFormId = @payrollFormId)";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@payrollFormId", payrollFormId);

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

        public async Task<DataTable> GetDeductionsList(int payrollFormId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select deductionDescription, deductionAmount " +
                        "from tbl_deductionDetails " +
                        "where payrollId = (select payrollId from tbl_payrollForm where payrollFormId = @payrollFormId)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@payrollFormId", payrollFormId);

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

        public async Task<bool> AddCreationPayrollTransactionLog(DateTime logDate, string description, int payrollId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string command = "insert into tbl_payrollTransactionLog (logDate, payrollId, logDescription) " +
                        "values (@logDate, @payrollId, @description)";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logDate", logDate);
                        cmd.Parameters.AddWithValue("@payrollId", payrollId); ;
                        cmd.Parameters.AddWithValue("@description", description);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetPayrollDetails(int payrollId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT 
                    CONCAT(e.employeeFname, ' ', e.employeeLname) AS EmployeeName,
                    pf.dateCreated,
                    pf.payrollStartingDate,
                    pf.payrollEndingDate,
                    pf.salaryRateDescription,
                    pf.salaryRateValue,
                    pf.totalEarnings,
                    pf.totalDeduction,
                    pf.netamount,
                    pf.createdBy,
                    pf.isCertifyByOficeHead,
                    pf.certifiedByOfficeHeadName,
                    pf.certifiedByOfficeHeadDate,
                    pf.isApproveByMayor,
                    pf.approvedByMayorName,
                    pf.approvedByMayorDate,
                    pf.isCertifiedByTreasurer,
                    pf.certifiedByTreasurerName,
                    pf.certifiedByTreasurerDate,
                    pf.isReleased,
                    pf.releasedDate,
                    pf.payrollFormId,
                    pf.payrollStartingDate,
                    pf.payrollEndingDate
                FROM 
                    tbl_payrollForm pf
                    JOIN tbl_employee e ON e.employeeId = pf.employeeId
                    JOIN tbl_status s ON s.statusId = pf.statusId
                WHERE 
                    pf.payrollFormId = @PayrollId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PayrollId", payrollId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetPayrollRequestList(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT 
                    CONCAT(e.employeeFname, ' ', e.employeeLname) AS employeeName,
                    pf.payrollFormId,
                    pf.netAmount,
	                pf.totalDeduction,
	                pf.totalEarnings,
	                pf.dateCreated,
	                e.employeeId
                FROM 
                    tbl_payrollForm pf
                    JOIN tbl_employee e ON pf.employeeId = e.employeeId
                    JOIN tbl_department d ON d.departmentId = e.departmentId
                WHERE 
                    d.departmentName = @DepartmentName and pf.isApproveByMayor is null and pf.isCertifyByOficeHead is null";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
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

        public async Task<int> GetStepNumber(string stepDescription)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select stepNumber from tbl_salaryRateStep where salaryRateStepDescription = @description";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", stepDescription);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int stepNumber))
                        {
                            return stepNumber;
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

        public async Task<DataTable> GetAllStepNumber()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select salaryRateStepDescription from tbl_salaryRateStep";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        using (SqlDataAdapter sda =  new SqlDataAdapter(cmd))
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

        // This function retrieves the salary rate description ID to be used for retrieving the salary value
        public async Task<int> GetSalaryRateDescriptionId(string salaryRateDescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select salaryRateId from tbl_salaryRate where salaryRateDescription = @description";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", salaryRateDescription);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            return id;
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

        // This function is to retrieve the salary value of a salary grade
        public async Task<decimal> GetSalaryRateValue(int salaryRateId, int stepNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT amount FROM tbl_salaryRateValue sv " +
                        "JOIN tbl_salaryRate sr ON sv.salaryRateId = sr.salaryRateId " +
                        "LEFT JOIN tbl_salaryRateStep st ON st.stepId = sv.stepId " +
                        "LEFT JOIN tbl_salaryRateTranche srt ON srt.trancheId = sv.trancheId " +
                        "WHERE sr.salaryRateId = @salaryRateId " +
                        "AND (st.stepNumber = @stepNumber OR @stepNumber IS NULL) " +
                        "AND srt.isTrancheUsed = 1";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@salaryRateId", salaryRateId);
                        cmd.Parameters.AddWithValue("@stepNumber", (stepNumber != -1) ? (object)stepNumber : DBNull.Value);

                        object result = await cmd.ExecuteScalarAsync();
                        conn.Close();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal amount))
                        {
                            return amount;
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

        public async Task<string> GetEmployeeName(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT CONCAT(employeeFname, ' ', employeeLname) FROM tbl_employee WHERE employeeId = @employeeId";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        return result != null ? $"{result}" : null;
                    }
                }
            }
            catch (SqlException sql)
            {
                Console.WriteLine("SQL Error: " + sql.Message);
                throw; // Re-throw the exception after logging or handle it appropriately
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw; // Re-throw the exception after logging or handle it appropriately
            }
        }

        // This function is for retrieving the formula for any general formulas
        public async Task<string> GetGeneralFormula(string formulaTitle)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select generalFormulaExpression from tbl_generalFormula where generalFormulaTitle = @formulaTitle";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@formulaTitle", formulaTitle);

                        object result = await cmd.ExecuteScalarAsync();

                        return result != null && result != DBNull.Value ? result.ToString() : string.Empty;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is used for retrieving the benefit's formula
        public async Task<string> GetBenefitsFormula(int benefitsId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select formulaExpression from tbl_benefitsFormula where benefitsId = @benefitsId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitsId", benefitsId);

                        object result = await cmd.ExecuteScalarAsync();

                        return result != null && result != DBNull.Value ? result.ToString() : string.Empty;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the Witholding Tax Rate based off a basic annual salary
        public async Task<DataTable> GetWitholdingTaxRate(decimal basicAnnualSalary)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT taxRateDescription, percentageToBeDeducted, amountToBeDeducted, amountExcess FROM tbl_witholdingTaxRates " +
                        "WHERE " +
                        "isTaxRateActive = 1 AND @basicAnnualSalary BETWEEN fromAnnualSalaryValue AND COALESCE(toAnnualSalaryValue, 9999999999) " +
                        "AND taxRateEffectiveFromYear <= 2023 AND (taxRateEffectiveToYear IS NULL OR taxRateEffectiveToYear >= 2023) " +
                        "ORDER BY fromAnnualSalaryValue;";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@basicAnnualSalary", basicAnnualSalary);

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

        // This function is used for retrieving the benefit contributions based on what benefits
        public async Task<DataTable> GetBenefitContributions(int benefitsId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT isPercentage, personalShareValue, employerShareValue, SUM(personalShareValue + employerShareValue) as value " +
                        "FROM tbl_benefitsContributions WHERE " +
                        "benefitsId = @benefitsId AND isBenefitContributionActive = 1 " +
                        "GROUP BY isPercentage, personalShareValue, employerShareValue";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@benefitsId", benefitsId);

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

        // This function responsible for retrieving personnel department to be used for approving requests
        public async Task<string> GetPersonnelDepartment(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select departmentName from tbl_employee join tbl_department on tbl_employee.departmentId = " +
                        "tbl_department.departmentId where employeeId = @employeeId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value)
                        {
                            return $"{result}";
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

        // This function is responsible for retrieving the Department Details that includes 
        // number of employee, regular employees, JO employee
        public async Task<DataTable> GetDepartmentListDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select d.departmentName, d.departmentLogo, d.departmentId, " +
                        "count(case when es.employmentStatus = 'Regular' then 1 end) as regularCount, " +
                        "count(case when es.employmentStatus = 'Job Order' then 1 end) as jobOrderCount, " +
                        "count(distinct e.employeeId) as totalEmployees " +
                        "from tbl_department d " +
                        "left join tbl_employee e on e.departmentId = d.departmentId " +
                        "left join tbl_appointmentForm af on e.employeeId = af.employeeId " +
                        "left join tbl_employmentStatus es on es.employmentStatusId = af.employmentStatusId " +
                        "group by " +
                        "d.departmentName, d.departmentLogo, d.departmentId";

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

        // This method return the details of the chosen department
        public async Task<DataTable> GetDepartmentDetails(int departmentId, string userRole)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "Select employeefname, employeelname, nameofschool, datehired, employeecontactnumber, " +
                        "employeejobdesc from tbl_employee join tbl_department on tbl_employee.departmentid = tbl_department.departmentid join tbl_userrole " +
                        "on tbl_employee.roleid = tbl_userrole.roleid join tbl_appointmentform on tbl_employee.employeeid = tbl_appointmentform.employeeid" +
                        " where tbl_department.departmentId = @departmentname and  rolename = @userrole";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentname", departmentId);
                        cmd.Parameters.AddWithValue("@userrole", userRole);
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

        // This function is responsible for retrieving the Department Details that includes 
        // number of employee, regular employees, JO employee
        public async Task<DataTable> GetSearchDepartmentListDetails(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select d.departmentName, d.departmentLogo, " +
                        "count(case when es.employmentStatus = 'Regular' then 1 end) as regularCount, " +
                        "count(case when es.employmentStatus = 'Job Order' then 1 end) as jobOrderCount, " +
                        "count(distinct e.employeeId) as totalEmployees " +
                        "from tbl_department d " +
                        "left join tbl_employee e on e.departmentId = d.departmentId " +
                        "left join tbl_appointmentForm af on e.employeeId = af.employeeId " +
                        "left join tbl_employmentStatus es on es.employmentStatusId = af.employmentStatusId " +
                        "where " +
                        "d.departmentName like '%'+@departmentName+'%'" +
                        "group by " +
                        "d.departmentName, d.departmentLogo";

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

        // This method will retrieve the list of employee under in a specific department
        public async Task<DataTable> GetEmployeeList(int departmentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select concat(employeefname, ' ', employeelname) as employeeName, employmentstatus, dateHired, " +
                        "tbl_employee.employeeid, " +
                        "employeepicture, employeeJobDesc from tbl_employee join " +
                        "tbl_department on tbl_employee.departmentid = tbl_department.departmentid join tbl_appointmentform on tbl_employee.employeeid = tbl_appointmentform.employeeid " +
                        "join tbl_employmentstatus on tbl_appointmentform.employmentstatusid = tbl_employmentstatus.employmentstatusid " +
                        "where tbl_department.departmentId = @departmentId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentId", departmentId);

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

        // This method will validate if the user who log in is authorize to do any actions
        public async Task<bool> GetValidation(int userid)
        {
            try
            {
                string role = "Personnel";
                string role2 = "System Administrator";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string command = "select rolename from tbl_employee join tbl_userrole on tbl_employee.roleid = tbl_userrole.roleid where" +
                        " employeeid = @userid";
                    await conn.OpenAsync();
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userid);
                        object result = await cmd.ExecuteScalarAsync();
                        conn.Close();

                        if (result.ToString() == role || result.ToString() == role2)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function is the one responsible to check if the employee chosen have any pending leave request
        // Purpose for this is to check if the chosen employee allowed to file a leave request or not
        public async Task<bool> GetLeavePendingCount(int employeeId, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_leave join tbl_status on tbl_leave.statusId = tbl_status.statusId " +
                        "where statusDescription = @status and employeeId = @employeeid";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        if ((int)result == 0 || result == DBNull.Value)
                        {
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            conn.Close();
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is the one responsible to check if the chosen employee have any pending Pass Slip request
        // Purpose is to check if the employee is eligible to file a slip request or not
        public async Task<bool> GetSlipPendingCount(int employeeId, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT COUNT(*) FROM tbl_passSlip " +
                                     "JOIN tbl_status ON tbl_passSlip.statusId = tbl_status.statusId " +
                                     "WHERE statusDescription = @status AND employeeId = @employeeId";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        return (int)(result ?? 0) == 0;
                    }
                }
            }
            catch (SqlException sql)
            {
                Console.WriteLine("SQL Error: " + sql.Message);
                throw; // Re-throw the exception after logging or handle it appropriately
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw; // Re-throw the exception after logging or handle it appropriately
            }
        }

        // This function is the one responsible to check if the chosen employee have any pending Travel Order request
        // Purpose is to check if the employee is eligible to file a travel order request or not
        public async Task<bool> GetTravelPendingCount(int employeeId, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_travelOrder join tbl_status on tbl_travelOrder.statusId = tbl_status.statusId " +
                        "where statusDescription = @status and employeeId = @employeeid";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@employeeid", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        if ((int)result == 0 || result == DBNull.Value)
                        {
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            conn.Close();
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the all list of employee in the database
        public async Task<DataTable> GetEmployeeList(int offset, int recordPerPage)
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
                        "ORDER BY tbl_employee.employeeId " +
                        $"OFFSET @offset ROWS FETCH NEXT @recordPerPage ROWS ONLY";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@recordPerPage", recordPerPage);
                        cmd.Parameters.AddWithValue("offset", offset);

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

        // This function is responsible for retrieving the full details of the Employee that is being chosen
        public async Task<DataTable> GetEmployeeDetails(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT tbl_employee.employeeId, employeePassword, employeeFname, employeeLname, employeeMname, employeeJobDesc, " +
                        "employeeContactNumber, employeeSex, employeeCivilStatus, nationality, employeeBirth, employeeEmailAddress, " +
                        "barangay, municipality, province, zipCode, educationalAttainment, course, nameOfSchool, schoolAddress, " +
                        "departmentName, dateHired, dateRetired, employmentStatus, employeePicture, employeeSignature, tbl_employee.isActive, roleName, " +
                        "amount, tbl_appointmentForm.salaryRateValueId, salaryRateDescription, salaryRateSchedule, payrollScheduleDescription, " +
                        "morningShiftTime, afternoonShiftTime " +
                        "FROM tbl_employee JOIN tbl_department ON " +
                        "tbl_employee.departmentId = tbl_department.departmentId JOIN tbl_educationalAttainment ON " +
                        "tbl_employee.educationalAttainmentId = tbl_educationalAttainment.educationalAttainmentId JOIN tbl_userRole ON " +
                        "tbl_employee.roleId = tbl_userRole.roleId JOIN tbl_appointmentForm ON tbl_employee.employeeId = " +
                        "tbl_appointmentForm.employeeId JOIN tbl_salaryRateValue ON tbl_appointmentForm.salaryRateValueId = " +
                        "tbl_salaryRateValue.salaryRateValueId JOIN tbl_salaryRate on tbl_salaryRateValue.salaryRateId = tbl_salaryRate.salaryRateId " +
                        "JOIN tbl_payrollSched ON tbl_appointmentForm.payrollSchedId = " +
                        "tbl_payrollSched.payrollSchedId JOIN tbl_employmentStatus ON tbl_appointmentForm.employmentStatusId = " +
                        "tbl_employmentStatus.employmentStatusId WHERE tbl_employee.employeeId = @id";

                    cmd = new SqlCommand(command, conn);
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
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // This function is responsible for retrieving the user first and last name
        // Purpose is that the retrieved value is used to record it in the employee logs and system logs
        public async Task<DataTable> GetUserDetails(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employeeFname, employeeLname from tbl_employee where employeeId = @userid";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", userId);

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

        // This method retrieves the number of employee saved in the database
        public async Task<int> GetNumberOfEmployee()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string numOfEmployee = "select count(*) from tbl_employee";
                    await connection.OpenAsync();
                    using (cmd = new SqlCommand(numOfEmployee, connection))
                    {
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

        // Function Responsible for retrieving the Filter Results of a searched employee
        public async Task<DataTable> GetFilterResult(string departmentName, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeId, concat(employeeFname, ' ', employeeLname) as employeeName, " +
                        "employmentStatus, departmentName, employeeJobDesc, employeePicture, morningShiftTime, afternoonShiftTime " +
                        "from tbl_employee join tbl_department on tbl_employee.departmentId = tbl_department.departmentId join tbl_appointmentForm " +
                        "on tbl_employee.employeeId = tbl_appointmentForm.employeeId join tbl_employmentStatus on tbl_appointmentForm.employment" +
                        "statusId = tbl_employmentStatus.employmentStatusId where departmentName like '%'+@departmentName+'%' " +
                        "and employmentStatus like '%'+@status+'%'";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);
                        cmd.Parameters.AddWithValue("@status", status);

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

        // This function is responsible for retrieving the list of all department
        public async Task<DataTable> GetDepartmentList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select departmentName from tbl_department";
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

        // This function is responsible for retrieving the employment status that can be chosen only 
        public async Task<DataTable> GetEmploymentStatus()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select employmentstatus from tbl_employmentstatus";
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

        // This function is responsible for retrieving employee details specifically employee that is being searched
        public async Task<DataTable> GetSearchEmployee(string search)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeid, employeefname, employeelname, departmentname, employeejobdesc, " +
                        "employmentstatus, employeepicture, morningShiftTime, afternoonShiftTime from tbl_employee join tbl_department on tbl_employee.departmentId = tbl_department.departmentId " +
                        "join tbl_appointmentform on tbl_employee.employeeid = tbl_appointmentform.employeeid " +
                        "join tbl_employmentstatus on tbl_appointmentform.employmentstatusid = tbl_employmentstatus.employmentstatusid " +
                        "where tbl_employee.employeeid like '%'+@search+'%' or employeefname like '%'+@search+'%' or employeelname like '%'+@search+'%' " +
                        "or concat(employeeFname, ' ', employeeLname) like '%'+@search+'%'";
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

        // This function is responsible for retrieving the employee's benefits
        public async Task<DataTable> GetEmployeeBenefits(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT detailsId, tbl_benefits.benefitsId, benefits, isBenefitActive, personalShareValue, employerShareValue, " +
                        "SUM(personalShareValue + employerShareValue) " +
                        "AS benefitsValue FROM tbl_appointmentFormBenefitsDetails JOIN tbl_appointmentForm ON tbl_appointmentForm.appointmentFormId = " +
                        "tbl_appointmentFormBenefitsDetails.appointmentFormId JOIN tbl_benefits ON tbl_benefits.benefitsId = " +
                        "tbl_appointmentFormBenefitsDetails.benefitsId WHERE employeeid = @id GROUP BY detailsId, tbl_benefits.benefitsId, benefits, " +
                        "isBenefitActive, personalShareValue, employerShareValue";

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

        // This function is responsible for retrieving the Active benefits this is for computing the tax rates
        public async Task<DataTable> GetActiveEmployeeBenefits(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT detailsId, tbl_benefits.benefitsId, benefits, isBenefitActive, personalShareValue, employerShareValue, " +
                        "SUM(personalShareValue + employerShareValue) " +
                        "AS benefitsValue FROM tbl_appointmentFormBenefitsDetails JOIN tbl_appointmentForm ON tbl_appointmentForm.appointmentFormId = " +
                        "tbl_appointmentFormBenefitsDetails.appointmentFormId JOIN tbl_benefits ON tbl_benefits.benefitsId = " +
                        "tbl_appointmentFormBenefitsDetails.benefitsId WHERE employeeid = @id  and isBenefitActive = 1 " +
                        "GROUP BY detailsId, tbl_benefits.benefitsId, benefits, " +
                        "isBenefitActive, personalShareValue, employerShareValue";

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the benefit contributions list
        public async Task<DataTable> GetBenefitRemmitance(int employeeId, int benefitId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_payrollForm.payrollId, dateCreated from tbl_payrollForm join tbl_deductionDetails on " +
                        "tbl_payrollForm.payrollId = tbl_deductionDetails.payrollId where employeeId = @employeeId and detailsId = @benefitId";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@benefitId", benefitId);

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

        // This function is responsible for the automatic retrieval of the Application number of Application for Leave
        public async Task<int> GetApplicationNumber()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT IDENT_CURRENT('tbl_leave')";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && int.TryParse(result.ToString(), out int id))
                        {
                            return id;
                        }
                        else
                        {
                            return 1;
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

        // This function is responsible for the automatic retrieval for the Control Number of Pass Slip
        public async Task<int> GetSlipControlNumber()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT IDENT_CURRENT('tbl_passSlip')";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && int.TryParse(result.ToString(), out int id))
                        {
                            return id;
                        }
                        else
                        {
                            return 1;
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

        // This function is responsible for the automatic retrieval for the Control Number of Travel Order
        public async Task<int> GetTravelControlNumber()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "SELECT IDENT_CURRENT('tbl_travelOrder')";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && int.TryParse(result.ToString(), out int id))
                        {
                            return id;
                        }
                        else
                        {
                            return 1;
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

        // This function is responsible for retrieving the different types of leave
        public async Task<DataTable> GetLeaveTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select leavetype from tbl_leavetype";

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

        // This function is responsible for retrieving the employee's leave credits balance
        public async Task<DataTable> GetLeaveCredits(int employeeId, int year)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select leaveType, numberOfCredits,leaveCreditYear from tbl_employeeLeaveCredits join tbl_leaveType " +
                        "on tbl_employeeLeaveCredits.typeId = tbl_leaveType.typeId where employeeId = @employeeId " +
                        "and leaveCreditYear = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);

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

        // Function responsible for retrieving the number of leave credits of employee
        public async Task<decimal> GetEmployeeLeaveCredits(int employeeId, string leaveType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select numberOfCredits from tbl_employeeLeaveCredits join tbl_leaveType on " +
                        "tbl_employeeLeaveCredits.typeId = tbl_leaveType.typeId where employeeId = @employeeId and leaveType = @leaveType";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@leaveType", leaveType);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal creditsNumber))
                        {
                            return creditsNumber;
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

        // This function is responsible for retrieving the default number of credits on a specific leave type
        public async Task<float> GetDefaultCredits(string leaveType)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select numberofCredits from tbl_leaveDefaultCredits join tbl_leaveType on " +
                        "tbl_leaveDefaultCredits.typeId = tbl_leaveType.typeId where leaveType = @leaveType";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@leaveType", leaveType);

                        object result = await cmd.ExecuteScalarAsync();

                        if(result != DBNull.Value && float.TryParse(result.ToString(), out float credits))
                        {
                            return credits;
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

        // Function responsible for retrieving the leave credits available for this leave type and for the employee
        public async Task<decimal> GetLeaveCredits(int employeeId, string leaveType, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select numberOfCredits from tbl_employeeLeaveCredits join tbl_leaveType on tbl_employeeLeaveCredits.typeId " +
                        "= tbl_leaveType.typeId where employeeId = @employeeId and leaveType = @leaveType and leaveCreditYear = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@leaveType", leaveType);
                        cmd.Parameters.AddWithValue("@year", year);

                        object result = await cmd.ExecuteScalarAsync();
                        
                        if(result != DBNull.Value && decimal.TryParse(result.ToString(), out decimal credits))
                        {
                            return credits;
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

        // This function responsible for retrieving the leave logs of employee
        public async Task<DataTable> GetLeaveList(int employeeId, int year)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select applicationNumber, leaveType, dateFile, leaveStartDate, leaveEndDate, statusDescription " +
                        "from tbl_leave join tbl_leaveType on tbl_leave.typeId = tbl_leaveType.typeId join tbl_status on tbl_leave.statusId = " +
                        "tbl_status.statusId where employeeId = @employeeId and year(dateFile) = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);

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

        // This function responsible for retrieving the list of pass slip for pass slip logs
        public async Task<DataTable> GetSlipList(int employeeId, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select slipControlNumber, dateFile, statusDescription from tbl_passSlip join tbl_status on " +
                        "tbl_passSlip.statusId = tbl_status.statusId where employeeId = @employeeId and year(dateFile) = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);

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

        // This function would be responsible for retrieving the travel order list for travel order logs
        public async Task<DataTable> GetTravelList(int employeeId, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select orderControlNumber, dateFiled, dateDeparture, statusDescription from tbl_travelOrder join tbl_status " +
                        "on tbl_travelOrder.statusId = tbl_status.statusId where employeeId = @employeeId and year(dateFiled) = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);

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

        // This function would be responsible for retrieving the recently submitted travel order in this month
        public async Task<DataTable> GetRecentTravelList(int employeeId, int month, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select orderControlNumber, dateDeparture, purpose, destination from tbl_travelOrder where " +
                        "employeeId = @employeeId and year(dateFiled) = @year and month(dateFiled) = @month and isNoted is not null and " +
                        "isApproved is not null";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@month", month);

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

        // This function will be responsible for showing the detailed view of Application for leave
        // And this only calls the leave requests that has been undergo complete process such as final approval / denial
        public async Task<DataTable> GetLeaveDetailedView(int applicationNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select applicationNumber, isRecommended, recommendedBy, dateRecommended, dateFile, leaveStartDate, leaveEndDate, " +
                        "isCertified, certifiedBy, certificationDate, isApproved, approvedBy, creditsUsed, " +
                        "approvedDate, statusDescription, employeeFname, employeeLname, employeeMname, departmentName, " +
                        "employeeJobDesc, salaryRateDescription, leaveType, leaveDetails, numberOfDays, withPay, approvedNumberDay, " +
                        "disapproveReason from tbl_leave " +
                        "join tbl_employee on tbl_leave.employeeId = tbl_employee.employeeId join tbl_department on " +
                        "tbl_employee.departmentId = tbl_department.departmentId join tbl_appointmentForm on tbl_employee.employeeId = " +
                        "tbl_appointmentForm.employeeId join tbl_salaryRate on tbl_appointmentForm.salaryRateId = " +
                        "tbl_salaryRate.salaryRateId join tbl_status on tbl_leave.statusId = tbl_status.statusId join tbl_leaveType on " +
                        "tbl_leave.typeId = tbl_leaveType.typeId where applicationNumber = @applicationNumber";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);

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

        // This function will be responsible for showing the detailed view of Pass Slip
        // And this only calls the Pass Slips that has been undergo complete process such as final approval / denial
        public async Task<DataTable> GetSlipDetailedView(int controlNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select slipControlNumber, isNoted, slipNotedBy,slipNotedDate, dateFile, slipDate, isApproved, approvedBy, " +
                        "approvedDate,  cast(slipEndingTime - slipStartingTime as time) as timeUsed, " +
                        "statusDescription, employeeFname, employeeLname, employeeMname, slipStartingTime, slipEndingTime, " +
                        "slipDestination, deniedReason from tbl_passSlip join tbl_employee on tbl_employee.employeeId = tbl_passSlip.employeeId " +
                        "join tbl_status on tbl_passSlip.statusId = tbl_status.statusId where slipControlNumber = @controlNumber";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);

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

        // This function will be responsible for showing the detailed view of Travel Orders
        // And this only calls the Travel Orders that has been undergo complete process such as final approval / denial
        public async Task<DataTable> GetTravelDetailedView(int controlNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select orderControlNumber, isNoted, notedBy, notedDate, dateFiled, dateDeparture, isApproved, " +
                        "approvedBy, approvedDate, statusDescription, " +
                        "employeeFname, employeeLname, employeeMname, departureTime, returnTime, destination, purpose, " +
                        "remarks, deniedReason from tbl_travelOrder join tbl_employee on tbl_travelOrder.employeeId = tbl_employee.employeeId " +
                        "join tbl_status on tbl_travelOrder.statusId = tbl_status.statusId where orderControlNumber = @controlNumber";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);

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

        // This function responsible for getting the employee's balance hours for pass slip
        public async Task<TimeSpan> GetEmployeeSlipHours(int employeeId, int month, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select numberOfHours from tbl_employeePassSlipHours where employeeId = @employeeId and " +
                        "month = @month and year = @year";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", year);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && TimeSpan.TryParse(result.ToString(), out TimeSpan hours))
                        {
                            return hours;
                        }
                        else
                        {
                            return TimeSpan.Zero;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the sum of employee logs
        public async Task<int> GetSumHoursWorked(int year, int month, int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select sum(totalHoursWorked) as total from tbl_timeLog where (year(dateLog) = @year and month(dateLog) = @month) " +
                        "and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == null || result == DBNull.Value)
                        {
                            return 0;
                        }
                        else
                        {
                            if (int.TryParse(result.ToString(), out int number))
                            {
                                return number;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the details description of an employee time log
        public async Task<DataTable> GetEmployeeTimeLog(int employeeId, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = @"
                SELECT
                    dateLog,
                    employeeId,
                    specialPrivilegeDescription,
                    SUM(lr.numberOfMinutes) as lateMinutes,
                    SUM(ur.numberOfMinutes) as undertimeMinutes,
                    SUM(otr.numberOfMinutes) as overtimeMinutes,
                    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 1 THEN timeLog END) AS MorningIn,
                    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 2 THEN timeLog END) AS MorningOut,
                    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 1 THEN timeLog END) AS AfternoonIn,
                    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 2 THEN timeLog END) AS AfternoonOut,
                    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 1 THEN tbl_timeLog.timelogId END) AS MorningInLogId,
                    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 2 THEN tbl_timeLog.timelogId END) AS MorningOutLogId,
                    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 1 THEN tbl_timeLog.timelogId END) AS AfternoonInLogId,
                    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 2 THEN tbl_timeLog.timelogId END) AS AfternoonOutLogId
                FROM
                    tbl_timeLog
                LEFT JOIN tbl_specialPrivilege ON tbl_specialPrivilege.specialPrivilegeId = tbl_timeLog.specialPrivilegeId
                LEFT JOIN tbl_lateRecord lr on lr.timeLogId = tbl_timeLog.timeLogId
                LEFT JOIN tbl_overtimeRecord otr on otr.timeLogId = tbl_timeLog.timeLogId
                LEFT JOIN tbl_undertimeRecord ur on ur.timeLogId = tbl_timeLog.timeLogId
                WHERE
                    employeeId = @employeeId
                    AND dateLog = @date
                GROUP BY
                    dateLog,
                    employeeId,
                    specialPrivilegeDescription;";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
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
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the time status
        public async Task<string> GetTimeLogStatus(int timeLogId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select timeStatusDescription " +
                        "from tbl_timeStatus " +
                        "where timePeriodId = (select timePeriodId from tbl_timeLog where timeLogId = @timeLogID) " +
                        "and logTypeId = (select logTypeId from tbl_timeLog where timeLogId = @timeLogId) " +
                        "and cast((select timeLog from tbl_timeLog where timeLogId = @timeLogId) as time) between fromTime and toTime";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@timeLogId", timeLogId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (!string.IsNullOrEmpty(result.ToString()) && result != DBNull.Value && result != null)
                        {
                            return $"{result}";
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of absent
        public async Task<bool> CheckAbsentLogs(int employeeId, DateTime targetDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = @"
                IF EXISTS (
                    SELECT 1
                    FROM tbl_timeLog
                    WHERE dateLog = @targetDate
                    AND employeeId = @employeeId
                    AND timePeriodId = 1 -- AM
                    AND logTypeId = 1 -- In
                )
                AND EXISTS (
                    SELECT 1
                    FROM tbl_timeLog
                    WHERE dateLog = @targetDate
                    AND employeeId = @employeeId
                    AND timePeriodId = 1 -- AM
                    AND logTypeId = 2 -- Out
                )
                AND EXISTS (
                    SELECT 1
                    FROM tbl_timeLog
                    WHERE dateLog = @targetDate
                    AND employeeId = @employeeId
                    AND timePeriodId = 2 -- PM
                    AND logTypeId = 1 -- In
                )
                AND EXISTS (
                    SELECT 1
                    FROM tbl_timeLog
                    WHERE dateLog = @targetDate
                    AND employeeId = @employeeId
                    AND timePeriodId = 2 -- PM
                    AND logTypeId = 2 -- Out
                )
                    SELECT 1
                ELSE
                    SELECT 0";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@targetDate", targetDate);

                        object result = await cmd.ExecuteScalarAsync();

                        return Convert.ToInt32(result) == 1;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //This function will be responsible for retrieving the count of an employee's number of overtime
        public async Task<int> GetOvertimeCount(int employeeId, int month, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select sum(numberOfMinutes) from tbl_overtimeRecord " +
                        "join tbl_timeLog on tbl_overtimeRecord.timeLogId = tbl_timeLog.timeLogId " +
                        "where month(dateLog) = @month and dateLog < @date and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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

        //This function will be responsible for retrieving the count of an employee's number of undertime
        public async Task<int> GetUndertimeCount(int employeeId, int month, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select sum(numberOfMinutes) from tbl_undertimeRecord " +
                        "join tbl_timeLog on tbl_undertimeRecord.timeLogId = tbl_timeLog.timeLogId " +
                        "where month(dateLog) = @month and dateLog < @date and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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

        //This function will be responsible for retrieving the count of an employee's number of late
        public async Task<int> GetLateCount(int employeeId, int month, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select sum(numberOfMinutes) from tbl_lateRecord " +
                        "join tbl_timeLog on tbl_lateRecord.timeLogId = tbl_timeLog.timeLogId " +
                        "where month(dateLog) = @month and dateLog < @date and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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

        //This function will be responsible for retrieving the count of an employee's number of Leave
        public async Task<int> GetLeaveCount(int employeeId, int month, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_specialPrivilege " +
                        "join tbl_timeLog on tbl_timeLog.specialPrivilegeId = tbl_specialPrivilege.specialPrivilegeId " +
                        "where month(dateLog) = @month and dateLog < @date and employeeId = @employeeId and applicationNumber is not null";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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

        //This function will be responsible for retrieving the count of an employee's number of Travel Order
        public async Task<int> GetTravelOrderCount(int employeeId, int month, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_specialPrivilege " +
                        "join tbl_timeLog on tbl_timeLog.specialPrivilegeId = tbl_specialPrivilege.specialPrivilegeId " +
                        "where month(dateLog) = @month and dateLog < @date and employeeId = @employeeId and orderControlNumber is not null";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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

        //This function will be responsible for retrieving the count of an employee's number of Pass Slip
        public async Task<int> GetPassSlipCount(int employeeId, int month, DateTime date)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) from tbl_specialPrivilege " +
                        "join tbl_timeLog on tbl_timeLog.specialPrivilegeId = tbl_specialPrivilege.specialPrivilegeId " +
                        "where month(dateLog) = @month and dateLog < @date and employeeId = @employeeId and slipControlNumber is not null";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@date", date);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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

        //This function will be responsible for retrieving the count of an employee's number of work days
        public async Task<int> GetWorkDaysCount(int employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select count(*) as onTime from tbl_timeLog where (morningStatus = 'On Time' or afternoonStatus = " +
                        "'On Time') and employeeId = @employeeId";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result != DBNull.Value && result != null && int.TryParse(result.ToString(), out int count))
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
                        "where departmentName = @department " +
                        "ORDER BY tbl_employee.employeeId " +
                        $"OFFSET @offset ROWS FETCH NEXT @recordPerPage ROWS ONLY";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@recordPerPage", recordPerPage);
                        cmd.Parameters.AddWithValue("@offset", offset);
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

        // This function is responsible for retrieving employee details specifically employee that is being searched
        public async Task<DataTable> GetSearchEmployee(string search, string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "select tbl_employee.employeeid, employeefname, employeelname, departmentname, employeejobdesc, " +
                        "employmentstatus, employeepicture, morningShiftTime, afternoonShiftTime from tbl_employee join tbl_department on tbl_employee.departmentId = tbl_department.departmentId " +
                        "join tbl_appointmentform on tbl_employee.employeeid = tbl_appointmentform.employeeid " +
                        "join tbl_employmentstatus on tbl_appointmentform.employmentstatusid = tbl_employmentstatus.employmentstatusid " +
                        "where (tbl_employee.employeeid like '%'+@search+'%' or employeefname like '%'+@search+'%' or employeelname like '%'+@search+'%' " +
                        "or concat(employeeFname, ' ', employeeLname) like '%'+@search+'%') and departmentName = @department";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", search);
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

        // This function is responsible for requesting the Pass Slip for an individual
        public async Task<bool> AddNewPassSlip (int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate, 
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_passSlip (slipControlNumber, employeeId, dateFile, slipDate, slipDestination, " +
                        "slipCreatedBy, formId, statusId, slipStartingTime, slipEndingTime) " +
                        "values (@slipControlNumber, @employeeId, @dateFile, @slipDate, @slipDestination, @createdBy, (select formId from " +
                        "tbl_formType where formName = @formType), (select statusId from tbl_status where statusDescription = @status), " +
                        "@slipStartTime, @slipEndTime)";

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

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function serves as indicator if the logs is added into the database or not
        // Specifically it is a system where it will records every action done in the program
        public async Task<bool> AddSystemLogs(DateTime date, string description, string caption)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_systemlogs (systemlogdate, systemlogdescription, logCaption) " +
                        "values (@date, @description, @caption)";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@caption", caption);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result == 1;
                    }
                }
            }
            catch (SqlException sql)
            {
                Console.WriteLine("SQL Error: " + sql.Message);
                return false; // Or handle the error as appropriate for your application
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Or handle the error as appropriate for your application
            }
        }

        // This function is responsible in inserting new leave request
        public async Task<bool> AddLeaveRequest(int applicationNumber, int employeeId, DateTime dateFile, string leaveType, string formType, 
            string leaveDetails, int numberOfDays, DateTime leaveStartDate, DateTime leaveEndDate, decimal creditsUsed, string status)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_leave (applicationNumber, employeeId, dateFile, typeId, formId, leaveDetails, numberOfDays, " +
                        "leaveStartDate, leaveEndDate, creditsUsed, statusId) " +
                        "values (@applicationNumber, @employeeId, @dateFile, (select typeId from tbl_leaveType where leaveType = @leaveType), " +
                        "(select formId from tbl_formType where formName = @formType), @leaveDetails, @numberOfDays, @leaveStartDate, " +
                        "@leaveEndDate, @creditsUsed, (select statusId from tbl_status where statusDescription = @status))";

                    using(cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@dateFile", dateFile);
                        cmd.Parameters.AddWithValue("@leaveType", leaveType);
                        cmd.Parameters.AddWithValue("@formType", formType);
                        cmd.Parameters.AddWithValue("@leaveDetails", leaveDetails);
                        cmd.Parameters.AddWithValue("@numberOfDays", numberOfDays);
                        cmd.Parameters.AddWithValue("@leaveStartDate", leaveStartDate);
                        cmd.Parameters.AddWithValue("@leaveEndDate", leaveEndDate);
                        cmd.Parameters.AddWithValue("@creditsUsed", creditsUsed);
                        cmd.Parameters.AddWithValue("@status", status);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding a new travel order request and saving it to the database
        public async Task<bool> AddTravelOrder(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture,
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks, string status,
            string formName, string createdBy, DateTime createdDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_travelOrder (orderControlNumber, employeeId, dateFiled, dateDeparture, departureTime, " +
                        "returnTime, destination, purpose, remarks, statusId, formId, createdBy, createdDate) " +
                        "values (@ordercontrolnumber, @employeeid, @datefiled, @datedeparture, @departuretime, @returntime, @destination, " +
                        "@purpose, @remarks, (select statusid from tbl_status where statusdescription = @status), " +
                        "(select formid from tbl_formType where formName = @formname), " +
                        "@createdby, @createddate)";
                    using (cmd = new SqlCommand(command, conn))
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
                            { "@createddate", createdDate }
                        };

                        foreach (var parameter in parameters)
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

        // This functiin is responsible for the adding a new form log if the request is already submitted and save to the database
        public async Task<bool> AddLeaveFormLog(DateTime logDate, string logDescription, int applicationNumber, string caption)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_formLog (logdate, logdescription, leaveid, logCaption) " +
                        "values (@logdate, @logdescription, (select leaveid from tbl_leave where applicationNumber = @applicationnumber), @caption)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logdate", logDate);
                        cmd.Parameters.AddWithValue("@logdescription", logDescription);
                        cmd.Parameters.AddWithValue("@applicationnumber", applicationNumber);
                        cmd.Parameters.AddWithValue("@caption", caption);

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

        // This function is responsible for the adding new form log when pass slip request is already submitted and added to the database
        public async Task<bool> AddSlipFormLog(DateTime logDate, string logDescription, int slipControlNumber, string caption)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_formLog (logdate, logdescription, slipId, logCaption) " +
                        "values (@logdate, @logdescription, (select slipId from tbl_passSlip where slipControlNumber = @slipcontrolnumber), @caption)";
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logdate", logDate);
                        cmd.Parameters.AddWithValue("@logdescription", logDescription);
                        cmd.Parameters.AddWithValue("@slipcontrolnumber", slipControlNumber);
                        cmd.Parameters.AddWithValue("@caption", caption);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql)
            {
                Console.WriteLine("SQL Error: " + sql.Message);
                return false; // Or handle the error as appropriate for your application
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Or handle the error as appropriate for your application
            }
        }

        // This function is responsible for adding a new logs when the travel order request is already submitted and saved to the database
        public async Task<bool> AddTravelFormLog(DateTime logDate, string logDescription, int orderControlNumber, string caption)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "insert into tbl_formLog (logdate, logdescription, travelOrderId, logCaption) " +
                        "values (@logdate, @logdescription, (select travelOrderId from tbl_travelOrder where orderControlNumber = @ordercontrolnumber), @caption)";
                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@logdate", logDate);
                        cmd.Parameters.AddWithValue("@logdescription", logDescription);
                        cmd.Parameters.AddWithValue("@ordercontrolnumber", orderControlNumber);
                        cmd.Parameters.AddWithValue("@caption", caption);

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

        // This function recommends the leave request
        public async Task<bool> RecommendLeaveRequest(int applicationNumber, bool isRecommended, string recommendedBy,
            DateTime dateRecommended)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_leave set " +
                        "isRecommended = @isRecommended, " +
                        "recommendedBy = @recommendedBy, " +
                        "dateRecommended = @dateRecommended " +
                        "where applicationNumber = @applicationNumber";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@isRecommended", isRecommended);
                        cmd.Parameters.AddWithValue("@recommendedBy", recommendedBy);
                        cmd.Parameters.AddWithValue("@dateRecommended", dateRecommended);
                        cmd.Parameters.AddWithValue("@applicationNumber", applicationNumber);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function notes the pass slip requests
        public async Task<bool> NotedPassSlipRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_passSlip set " +
                        "isNoted = @isNoted, " +
                        "slipNotedBy = @notedBy, " +
                        "slipNotedDate = @notedDate " +
                        "where slipControlNumber = @controlNumber";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@isNoted", isNoted);
                        cmd.Parameters.AddWithValue("@notedBy", notedBy);
                        cmd.Parameters.AddWithValue("@notedDate", notedDate);
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function notes the travel order request
        public async Task<bool> NotedTravelOrderRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_travelOrder set " +
                        "isNoted = @isNoted, " +
                        "notedBy = @notedBy, " +
                        "notedDate = @notedDate " +
                        "where orderControlNumber = @controlNumber";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@isNoted", isNoted);
                        cmd.Parameters.AddWithValue("@notedBy", notedBy);
                        cmd.Parameters.AddWithValue("@notedDate", notedDate);
                        cmd.Parameters.AddWithValue("@controlNumber", controlNumber);

                        object result = await cmd.ExecuteNonQueryAsync();

                        return (int)result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for updating the basic info of an employee
        public async Task<bool> UpdateBasicInformation(int employeeId, string password, string emailAddress, string mobileNumber, string zipCode, string province,
            string municipality, string barangay, string gender)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_employee set " +
                        "employeePassword = @password, " +
                        "employeeEmailAddress = @emailAddress, " +
                        "employeeContactNumber = @mobileNumber, " +
                        "zipCode = @zipCode, " +
                        "province = @province, " +
                        "municipality = @municipality, " +
                        "barangay = @barangay, " +
                        "employeeSex = @gender " +
                        "where employeeId = @employeeId";  // Fixed typo here (empployeeId -> employeeId)

                    using (SqlCommand cmd = new SqlCommand(command, conn))  // Declared SqlCommand cmd
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@emailAddress", emailAddress);
                        cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                        cmd.Parameters.AddWithValue("@zipCode", zipCode);
                        cmd.Parameters.AddWithValue("@province", province);
                        cmd.Parameters.AddWithValue("@municipality", municipality);
                        cmd.Parameters.AddWithValue("@barangay", barangay);
                        cmd.Parameters.AddWithValue("@gender", gender);

                        // Execute the update
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }
    }
}
