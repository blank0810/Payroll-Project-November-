using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel
{
    public class personnelProfile
    {
        public int userId;
        public string password;
        private readonly string connectionString;
        SqlCommand cmd = new SqlCommand();

        public personnelProfile()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }


    }
}
