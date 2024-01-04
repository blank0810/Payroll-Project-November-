using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs
{
    public partial class payslipLogsUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public payslipLogsUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetPayslipList(int employeeId)
        {
            try
            {
                DataTable payslipList = await generalFunctions.GetPayrollList(employeeId);

                if (payslipList.Rows.Count > 0)
                {
                    return payslipList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task DisplayLog(int employeeId)
        {
            payslipContentPanel.Controls.Clear();
            DataTable payslipLog = await GetPayslipList(employeeId);

            if (payslipLog != null)
            {
                payslipLogDataUC[] logDataUC = new payslipLogDataUC[payslipLog.Rows.Count];

                for (int i = 0; i < payslipLog.Rows.Count; i++)
                {
                    logDataUC[i] = new payslipLogDataUC(employeeId, this);
                    DataRow row = payslipLog.Rows[i];

                    if (!string.IsNullOrEmpty(row["payrollFormId"]?.ToString()) &&
                        int.TryParse(row["payrollFormId"].ToString(), out int payrollId))
                    {
                        logDataUC[i].PayrollID = payrollId;
                    }
                    else
                    {
                        logDataUC[i].PayrollID = 0;
                    }

                    if (!string.IsNullOrEmpty(row["dateCreated"].ToString()) && DateTime.TryParse(row["dateCreated"]?.ToString(), 
                        out DateTime dateCreated))
                    {
                        logDataUC[i].DateCreated = $"{dateCreated:MMM dd, yyyy}";
                    }
                    else
                    {
                        logDataUC[i].DateCreated = "---------";
                    }

                    if (!string.IsNullOrEmpty(row["totalEarnings"]?.ToString()) && decimal.TryParse(row["totalEarnings"].ToString(), 
                        out decimal earnings))
                    {
                        logDataUC[i].TotalEarnings = $"{earnings:C2}";
                    }
                    else
                    {
                        logDataUC[i].TotalEarnings = $"{0:C2}";
                    }

                    if (!string.IsNullOrEmpty(row["totalDeduction"]?.ToString()) && decimal.TryParse(row["totalDeduction"].ToString(), 
                        out decimal deduction))
                    {
                        logDataUC[i].TotalDeductions = $"{deduction:C2}";
                    }
                    else
                    {
                        logDataUC[i].TotalDeductions = $"{0:C2}";
                    }

                    if (!string.IsNullOrEmpty(row["netAmount"]?.ToString()) && decimal.TryParse(row["netAmount"].ToString(), 
                        out decimal amount))
                    {
                        logDataUC[i].TotalSalary = $"{amount:C2}";
                    }
                    else
                    {
                        logDataUC[i].TotalSalary = $"{0:C2}";
                    }

                    payslipContentPanel.Controls.Add(logDataUC[i]);
                }
            }
        }

        private async void payslipLogsUC_Load(object sender, EventArgs e)
        {
            await DisplayLog(_userId);
        }
    }
}
