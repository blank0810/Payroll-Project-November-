using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll
{
    public partial class payroll : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly payrollClass payrollClass = new payrollClass();
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string EmployeeSignaturePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeSignaturePath");

        public payroll()
        {
            InitializeComponent();
        }

        private async Task<DataTable> GetEmployeeList(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable employeeList = await payrollClass.GetEmployeeList(fromDate, toDate);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void payroll_Load(object sender, EventArgs e)
        {

        }
    }
}
