using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Pass_Slip.Pass_Slip_List_sub_user_control;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Pass_Slip
{
    public partial class slipListUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static int _year = DateTime.Now.Year;
        private static readonly string defaultImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formManagementClass formManagementClass = new formManagementClass();

        public slipListUC(int userId, departmentHeadDashboard parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetEmployeeList(string department)
        {
            try
            {
                DataTable list = await formManagementClass.GetSlipEmployeeList(department);

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

        private async Task<DataTable> GetSlipList(int employeeId, int year)
        {
            try
            {
                DataTable list = await generalFunctions.GetSlipList(employeeId, year);

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

        private async Task DisplayEmployee(string department)
        {
            try
            {
                label6.Visible = false;
                label8.Visible = false;
                label2.Visible = false;
                label9.Visible = false;
                returnBtn.Visible = false;

                label1.Visible = true;
                label7.Visible = true;
                label4.Visible = true;

                passSlipListPanel.Controls.Clear();
                DataTable list = await GetEmployeeList(department);

                if (list != null)
                {
                    employeeListUC[] employeeList = new employeeListUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        employeeList[i] = new employeeListUC(_userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            employeeList[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeeName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                            out int employeeId))
                        {
                            employeeList[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            employeeList[i].EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["total"].ToString()) && int.TryParse(row["total"].ToString(), 
                            out int total))
                        {
                            employeeList[i].TotalNumber = total;
                        }
                        else
                        {
                            employeeList[i].TotalNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            employeeList[i].EmployeeImage = $"{row["employeePicture"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeeImage = defaultImage;
                        }

                        passSlipListPanel.Controls.Add(employeeList[i]);
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

        public async Task DisplaySlipList(int employeeId)
        {
            try
            {
                label6.Visible = true;
                label8.Visible = true;
                label2.Visible = true;
                label9.Visible = true;
                returnBtn.Visible = true;

                label1.Visible = false;
                label7.Visible = false;
                label4.Visible = false;

                passSlipListPanel.Controls.Clear();
                DataTable list = await GetSlipList(employeeId, _year);

                if(list != null)
                {
                    slipListDataUC[] slipList = new slipListDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        slipList[i] = new slipListDataUC(_userId, this, employeeId);
                        DataRow row = list.Rows[i];

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

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            slipList[i].Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            slipList[i].Status = "-------";
                        }

                        passSlipListPanel.Controls.Add(slipList[i]);
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

        private async void slipListUC_Load(object sender, EventArgs e)
        {
            await DisplayEmployee(_department);
        }

        private async void returnBtn_Click(object sender, EventArgs e)
        {
            await DisplayEmployee(_department);
        }
    }
}
