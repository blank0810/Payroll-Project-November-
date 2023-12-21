using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests
{
    public partial class payslipUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static generalFunctions generalFunctions = new generalFunctions();

        public payslipUC(int userId, departmentHeadDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetRequestList(string departmentName)
        {
            try
            {
                DataTable list = await generalFunctions.GetPayrollRequestList(departmentName);

                if (list != null && list.Rows.Count > 0)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        public async Task DisplayPaySlip(string departmentName, int userId)
        {
            try
            {
                DataTable list = await GetRequestList(departmentName);
                payrollRequestPanel.Controls.Clear();

                if (list != null)
                {
                    employeeDataUC[] employeeData = new employeeDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        employeeData[i] = new employeeDataUC(userId, this, departmentName);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            employeeData[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employeeData[i].EmployeeName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), out 
                            int employeeId))
                        {
                            employeeData[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            employeeData[i].EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["payrollFormId"].ToString()) && int.TryParse(row["payrollFormId"].ToString(), 
                            out int payrollFormId))
                        {
                            employeeData[i].PayrollID = payrollFormId;
                        }
                        else
                        {
                            employeeData[i].PayrollID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["netAmount"].ToString()) && decimal.TryParse(row["netAmount"].ToString(), 
                            out decimal netPay))
                        {
                            employeeData[i].TotalSalary = $"{netPay:C2}";
                        }
                        else
                        {
                            employeeData[i].TotalSalary = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalDeduction"].ToString()) && decimal.TryParse(row["totalDeduction"].ToString(), 
                            out decimal totalDeduction))
                        {
                            employeeData[i].TotalDeductions = $"{totalDeduction:C2}";
                        }
                        else
                        {
                            employeeData[i].TotalDeductions = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalEarnings"].ToString()) && decimal.TryParse(row["totalEarnings"].ToString(), 
                            out decimal totalEarnings))
                        {
                            employeeData[i].TotalEarnings = $"{totalEarnings:C2}";
                        }
                        else
                        {
                            employeeData[i].TotalEarnings = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["dateCreated"]?.ToString()) && DateTime.TryParse(row["dateCreated"].ToString(),
                            out DateTime dateCreated))
                        {
                            employeeData[i].DateCreated = $"{dateCreated:MMM dd, yyyy}";
                        }
                        else
                        {
                            employeeData[i].DateCreated = "---------";
                        }

                        payrollRequestPanel.Controls.Add(employeeData[i]);
                    }
                }

            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void payslipUC_Load(object sender, EventArgs e)
        {
            await DisplayPaySlip(_department, _userId);
        }
    }
}
