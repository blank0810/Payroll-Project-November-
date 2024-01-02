using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator
{
    public class departmentManagementClass
    {
        private readonly string connectionString;
        SqlCommand cmd;

        public departmentManagementClass()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public async Task<bool> UpdateDepartmentInformation(int departmentId, string departmentName, string departmentInitial, 
            string departmentLogo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string command = "update tbl_department " +
                        "set " +
                        "departmentName = @departmentName, " +
                        "departmentInitial = @departmentInitial, " +
                        "departmentLogo = @departmentLogo " +
                        "where " +
                        "departmentId = @departmentId";

                    using (cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@departmentName", departmentName);
                        cmd.Parameters.AddWithValue("@departmentInitial", departmentInitial);
                        cmd.Parameters.AddWithValue("@departmentLogo", departmentLogo);
                        cmd.Parameters.AddWithValue("@departmentId", departmentId);

                        int result = await cmd.ExecuteNonQueryAsync();

                        return result > 0;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}
