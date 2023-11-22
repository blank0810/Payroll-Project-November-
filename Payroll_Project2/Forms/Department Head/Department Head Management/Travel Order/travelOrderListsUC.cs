using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_Order_list_sub_user_control;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Travel_Order
{
    public partial class travelOrderListsUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static readonly string defaultImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static int _year = DateTime.Now.Year;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formManagementClass formManagementClass = new formManagementClass();

        public travelOrderListsUC(int userId, departmentHeadDashboard parent, string department)
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
                DataTable list = await formManagementClass.GetTravelEmployeeList(department);

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

        private async Task<DataTable> GetTravelList(int employeeId, int year)
        {
            try
            {
                DataTable list = await generalFunctions.GetTravelList(employeeId, year);

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

        private async Task DisplayEmployeeList()
        {
            try
            {
                label6.Visible = false;
                label8.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label9.Visible = false;
                returnBtn.Visible = false;

                label1.Visible = true;
                label7.Visible = true;
                label4.Visible = true;

                travelOrderListPanel.Controls.Clear();
                DataTable list = await GetEmployeeList(_department);

                if(list != null )
                {
                    employeeListTravelOrder[] employeeList = new employeeListTravelOrder[list.Rows.Count];

                    for (int i = 0; i <  list.Rows.Count; i++)
                    {
                        employeeList[i] = new employeeListTravelOrder(_userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            employeeList[i].EmployeeImage = $"{row["employeePicture"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeeImage = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            employeeList[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employeeList[i].EmployeeName = "----------";
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

                        travelOrderListPanel.Controls.Add(employeeList[i]);
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

        public async Task DisplayTravelLogs(int employeeId)
        {
            try
            {
                label6.Visible = true;
                label8.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label9.Visible = true;
                returnBtn.Visible = true;

                label1.Visible = false;
                label7.Visible = false;
                label4.Visible = false;
                DataTable list = await GetTravelList(employeeId, _year);
                travelOrderListPanel.Controls.Clear();

                if(list != null)
                {
                    travelOrderDataUC[] travelList= new travelOrderDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        travelList[i] = new travelOrderDataUC(_userId, this, employeeId);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["orderControlNumber"].ToString()) && int.TryParse(row["orderControlNumber"].ToString(), 
                            out int controlNumber))
                        {
                            travelList[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            travelList[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFiled"].ToString()) && DateTime.TryParse(row["dateFiled"].ToString(), 
                            out DateTime dateFiled))
                        {
                            travelList[i].DateFiled = $"{dateFiled: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelList[i].DateFiled = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["dateDeparture"].ToString()) && DateTime.TryParse(row["dateDeparture"].ToString(), 
                            out DateTime dateDeparture))
                        {
                            travelList[i].DateDeparture = $"{dateDeparture: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelList[i].DateDeparture = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            travelList[i].Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            travelList[i].Status = "--------";
                        }

                        travelOrderListPanel.Controls.Add(travelList[i]);
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

        private async void travelOrderListsUC_Load(object sender, EventArgs e)
        {
            await DisplayEmployeeList();
        }

        private async void returnBtn_Click(object sender, EventArgs e)
        {
            await DisplayEmployeeList();
        }
    }
}
