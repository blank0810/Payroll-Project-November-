using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions
{
    public class payslipRequestClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public payslipRequestClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<DataTable> GetPayrollRequestList(string departmentName, string mayorDepartment)
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
                    pf.salaryRateValue,
	                pf.dateCreated,
	                e.employeeId,
                    e.employeeJobDesc
                FROM 
                    tbl_payrollForm pf
                    JOIN tbl_employee e ON pf.employeeId = e.employeeId
                    JOIN tbl_department d ON d.departmentId = e.departmentId
                WHERE 
                    (d.departmentName = @DepartmentName and pf.isApproveByMayor is null and pf.isCertifyByOfficeHead is not null) 
                OR 
                    (d.departmentName = @mayorDepartment and pf.isApproveByMayor is null and pf.isCertifyByOfficeHead is null)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                        cmd.Parameters.AddWithValue("@mayorDepartment", mayorDepartment);

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

        public async Task<DataTable> GetPayrollRequestSummary(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = @"
                SELECT 
                    SUM(totalDeduction) as totalDeductions,
                    SUM(totalEarnings) as totalEarnings,
                    SUM(netAmount) as totalNetAmount,
                    COUNT(*) as requestCount
                FROM 
                    tbl_payrollForm pf
                    JOIN tbl_employee e ON pf.employeeId = e.employeeId
                    JOIN tbl_department d ON d.departmentId = e.departmentId
                WHERE 
                    d.departmentName = @DepartmentName
                    AND pf.isApproveByMayor is null";

                    using (cmd = new SqlCommand(command, conn))
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task<DataTable> GetPayrollDepartmentRequestList(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                SELECT 
                    d.departmentName,
                    d.departmentLogo,
                    COUNT(*) AS requestCount
                FROM 
                    tbl_payrollForm pf
                    JOIN tbl_employee e ON pf.employeeId = e.employeeId
                    JOIN tbl_department d ON e.departmentId = d.departmentId
                WHERE 
                    (pf.isCertifyByOfficeHead IS NOT NULL AND pf.isApproveByMayor IS NULL) 
                    OR 
                    (pf.isCertifyByOfficeHead IS NULL AND pf.isApproveByMayor IS NULL AND departmentName = @DepartmentName)
                GROUP BY 
                    d.departmentName, d.departmentLogo";

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

        public async Task<bool> ApprovePayroll(bool certify, string name, DateTime date, int payrollId, string statusDescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                UPDATE tbl_payrollForm
                SET 
                    isApproveByMayor = @certify,
                    approvedByMayorName = @name,
                    approvedByMayorDate = @date,
                    statusId = (SELECT statusId FROM tbl_status WHERE statusDescription = @description)
                WHERE 
                    payrollFormId = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@certify", certify);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@id", payrollId);
                        cmd.Parameters.AddWithValue("@description", statusDescription);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0; // Returns true if any rows were affected
                    }
                }
            }
            catch (SqlException sql)
            {
                // Handle SQL exception
                throw sql;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }

        public async Task<bool> ApproveAndCertifyPayroll(bool approve, string name, DateTime date, int payrollId, string statusDescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                UPDATE tbl_payrollForm
                SET 
                    isCertifyByOfficeHead = @approve,
                    certifiedByOfficeHeadName = @name,
                    certifiedByOfficeHeadDate = @date,
                    isApproveByMayor = @approve,
                    approvedByMayorName = @name,
                    approvedByMayorDate = @date,
                    statusId = (SELECT statusId FROM tbl_status WHERE statusDescription = @description)
                WHERE 
                    payrollFormId = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@approve", approve);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@id", payrollId);
                        cmd.Parameters.AddWithValue("@description", statusDescription);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0; // Returns true if any rows were affected
                    }
                }
            }
            catch (SqlException sql)
            {
                // Handle SQL exception
                throw sql;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }
    }
}
