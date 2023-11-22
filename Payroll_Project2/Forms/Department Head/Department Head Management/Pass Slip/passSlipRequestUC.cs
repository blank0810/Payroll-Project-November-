using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Pass_Slip.Pass_Slip_Request_sub_user_control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Pass_Slip
{
    public partial class passSlipRequestUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formManagementClass formManagementClass = new formManagementClass();

        public passSlipRequestUC(int userId, departmentHeadDashboard parent, string department)
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
                DataTable list = await formManagementClass.GetSlipRequestList(department);

                if (list != null)
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
                DataTable list = await GetRequestList(department);
                requestListPanel.Controls.Clear();

                if(list != null)
                {
                    slipRequestDataUC[] slipList = new slipRequestDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        slipList[i] = new slipRequestDataUC(userId, this, department);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            slipList[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            slipList[i].EmployeeName = "------------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                            out int employeeId))
                        {
                            slipList[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            slipList[i].EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["slipControlNumber"].ToString()) && int.TryParse(row["slipControlNumber"].ToString(), 
                            out int controlNumber))
                        {
                            slipList[i].ControlNumber = controlNumber;  
                        }
                        else
                        {
                            slipList[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), 
                            out DateTime dateFile))
                        {
                            slipList[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            slipList[i].DateFiled = "--------";
                        }

                        requestListPanel.Controls.Add(slipList[i]);
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

        private async void passSlipRequestUC_Load(object sender, EventArgs e)
        {
            await DisplayRequestList(_department, _userId);
        }
    }
}
