using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_order_request_sub_user_control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Travel_Order
{
    public partial class travelOrderRequestUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static formManagementClass formManagementClass = new formManagementClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        public travelOrderRequestUC(int userId, departmentHeadDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetRequestList(string department)
        {
            try
            {
                DataTable list = await formManagementClass.GetTravelRequestList(department);

                if(list != null)
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

        public async Task DisplayRequestList(string department, int userId)
        {
            try
            {
                requestListPanel.Controls.Clear();
                DataTable list = await GetRequestList(department);

                if(list != null)
                {
                    requestDataUC[] requestList = new requestDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        requestList[i] = new requestDataUC(userId, this, department);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            requestList[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            requestList[i].EmployeeName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                            out int employeeId))
                        {
                            requestList[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            requestList[i].EmployeeID= 0;
                        }

                        if (!string.IsNullOrEmpty(row["orderControlNumber"].ToString()) && int.TryParse(row["orderControlNumber"].ToString(), 
                            out int controlNumber))
                        {
                            requestList[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            requestList[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFiled"].ToString()) && DateTime.TryParse(row["dateFiled"].ToString(), 
                            out DateTime dateFiled))
                        {
                            requestList[i].DateFiled = $"{dateFiled: MMM dd, yyyy}";
                        }
                        else
                        {
                            requestList[i].DateFiled = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["dateDeparture"].ToString()) && DateTime.TryParse(row["dateDeparture"].ToString(), 
                            out DateTime dateDeparture))
                        {
                            requestList[i].DateDeparture = $"{dateDeparture: MMM dd, yyyy}";
                        }
                        else
                        {
                            requestList[i].DateDeparture = "--------";
                        }

                        requestListPanel.Controls.Add(requestList[i]);
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

        private async void travelRequestUC_Load(object sender, EventArgs e)
        {
            await DisplayRequestList(_department, _userId);
        }
    }
}
