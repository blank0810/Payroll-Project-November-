using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Dashboard;
using Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests
{
    public partial class payslipRequestsUC : UserControl
    {
        private static int _userId;
        private static MayorDashboard _parent;
        private static string _department;
        private static readonly payslipRequestClass payslipRequestClass = new payslipRequestClass();
        private static readonly string DefaultDepartmentImage = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly string DepartmentImagePath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");

        public payslipRequestsUC(int userId, MayorDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> DisplayDepartmentRequests(string department)
        {
            try
            {
                DataTable list = await payslipRequestClass.GetPayrollDepartmentRequestList(department);

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

        public async Task DisplayRequests(string department, int userId)
        {
            try
            {
                payrollRequestPanel.Controls.Clear();
                DataTable requests = await DisplayDepartmentRequests(department);

                if (requests != null)
                {
                    payslipRequestDataUC[] requestUC = new payslipRequestDataUC[requests.Rows.Count];

                    for (int i = 0; i < requests.Rows.Count; i++)
                    {
                        requestUC[i] = new payslipRequestDataUC(userId, this, department);
                        DataRow row = requests.Rows[i];

                        if (!string.IsNullOrEmpty(row["departmentLogo"]?.ToString()))
                        {
                            requestUC[i].DepartmentLogo = $"{DepartmentImagePath}{row["departmentLogo"]}";
                        }
                        else
                        {
                            requestUC[i].DepartmentLogo = DefaultDepartmentImage;
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"]?.ToString()))
                        {
                            requestUC[i].DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            requestUC[i].DepartmentName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["requestCount"]?.ToString()) && int.TryParse(row["requestCount"]?.ToString(), 
                            out int requestCount))
                        {
                            requestUC[i].RequestCount = requestCount;
                        }
                        else
                        {
                            requestUC[i].RequestCount = 0;
                        }

                        payrollRequestPanel.Controls.Add(requestUC[i]);
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async void payslipRequestsUC_Load(object sender, EventArgs e)
        {
            await DisplayRequests(_department, _userId);
        }
    }
}
