using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Travel_Order_Management.Travel_Management_sub_user_control;
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

namespace Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Travel_Order_Management
{
    public partial class travelApproveUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static readonly string defaultImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        public travelApproveUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetTravelList(string department)
        {
            try
            {
                DataTable list = await formClass.GetTravelList(department);

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

        private async Task<DataTable> GetSearchTravelList(string search, string department)
        {
            try
            {
                DataTable list = await formClass.GetSearchTravelList(department, search);

                if(list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetDepartment(int employeeId)
        {
            try
            {
                string department = await generalFunctions.GetPersonnelDepartment(employeeId);

                if (department != null)
                {
                    return department;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task DisplayTravelList()
        {
            approveList.Controls.Clear();
            string department = await GetDepartment(_userId);
            DataTable list = await GetTravelList(department);

            if(list != null && department != null)
            {
                travelDataUC[] travelList = new travelDataUC[list.Rows.Count];

                for(int i = 0; i < list.Rows.Count; i++)
                {
                    travelList[i] = new travelDataUC(_userId, this);
                    DataRow row = list.Rows[i];

                    if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                    {
                        travelList[i].EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                    }
                    else
                    {
                        travelList[i].EmployeeName = "----------";
                    }

                    if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                        out int employeeId))
                    {
                        travelList[i].EmployeeId = employeeId;
                    }
                    else
                    {
                        travelList[i].EmployeeId = 0;
                    }

                    if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                    {
                        travelList[i].EmployeePicture = $"{employeeImagePath}{row["employeePicture"]}";
                    }
                    else
                    {
                        travelList[i].EmployeePicture = defaultImage;
                    }

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

                    approveList.Controls.Add(travelList[i]);
                }
            }
        }

        private async Task DisplaySearchTravelList(string search)
        {
            try
            {
                approveList.Controls.Clear();
                string department = await GetDepartment(_userId);
                DataTable list = await GetSearchTravelList(search, department);

                if (list != null && department != null)
                {
                    travelDataUC[] travelList = new travelDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        travelList[i] = new travelDataUC(_userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            travelList[i].EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                        }
                        else
                        {
                            travelList[i].EmployeeName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(),
                            out int employeeId))
                        {
                            travelList[i].EmployeeId = employeeId;
                        }
                        else
                        {
                            travelList[i].EmployeeId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            travelList[i].EmployeePicture = $"{employeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            travelList[i].EmployeePicture = defaultImage;
                        }

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

                        approveList.Controls.Add(travelList[i]);
                    }
                }
                else
                {
                    MessageBox.Show($"There are no record/s found about {search} in the database. Please ensure to review the details and try " +
                        $"again", "No Record Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await DisplayTravelList();
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void travelApproveUC_Load(object sender, EventArgs e)
        {
            await DisplayTravelList();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(searchEmployee.Texts))
            {
                await DisplaySearchTravelList(searchEmployee.Texts);
                searchEmployee.Texts = string.Empty;
            }
            else
            {
                await DisplayTravelList();
            }
        }
    }
}
