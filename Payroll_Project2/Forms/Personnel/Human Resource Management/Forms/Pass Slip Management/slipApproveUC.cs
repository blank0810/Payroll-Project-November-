using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data;
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

namespace Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Pass_Slip_Management
{
    public partial class slipApproveUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static readonly string defaultImage = ConfigurationManager.AppSettings["DefaultLogo"];
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");

        public slipApproveUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<string> GetPersonnelDepartment(int employeeId)
        {
            try
            {
                string department = await generalFunctions.GetPersonnelDepartment(employeeId);
                return department;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetSlipList(string department)
        {
            try
            {
                DataTable slip = await formClass.GetSlipList(department);

                if (slip != null)
                {
                    return slip;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetSearchSlipList(string department, string search)
        {
            try
            {
                DataTable slip = await formClass.GetSearchSlipList(department, search);

                if (slip != null)
                {
                    return slip;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task DisplaySlipList()
        {
            approveList.Controls.Clear();
            string department = await GetPersonnelDepartment(_userId);
            
            if (department != null)
            {
                DataTable slipList = await GetSlipList(department);

                if (slipList != null)
                {
                    passSlipData[] slipDate = new passSlipData[slipList.Rows.Count];

                    for (int i = 0; i < slipList.Rows.Count; i++)
                    {
                        slipDate[i] = new passSlipData(_userId, this);
                        DataRow row = slipList.Rows[i];

                        if (!string.IsNullOrEmpty(row["slipControlNumber"].ToString()) && int.TryParse(row["slipControlNumber"].ToString(), 
                            out int controlNumber))
                        {
                            slipDate[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            slipDate[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            slipDate[i].EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                        }
                        else
                        {
                            slipDate[i].EmployeeName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(), 
                            out int employeeId))
                        {
                            slipDate[i].EmployeeId = employeeId;
                        }
                        else
                        {
                            slipDate[i].EmployeeId= 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            slipDate[i].EmployeePicture = $"{employeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            slipDate[i].EmployeePicture = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), 
                            out DateTime dateFile))
                        {
                            slipDate[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            slipDate[i].DateFiled = "----------";
                        }

                        approveList.Controls.Add(slipDate[i]);
                    }
                }
            }
        }

        private async Task DisplaySearchList(string search)
        {
            try
            {
                string department = await GetPersonnelDepartment(_userId);
                DataTable slipList = await GetSearchSlipList(department, search);

                if (slipList != null)
                {
                    passSlipData[] slipDate = new passSlipData[slipList.Rows.Count];

                    for (int i = 0; i < slipList.Rows.Count; i++)
                    {
                        slipDate[i] = new passSlipData(_userId, this);
                        DataRow row = slipList.Rows[i];

                        if (!string.IsNullOrEmpty(row["slipControlNumber"].ToString()) && int.TryParse(row["slipControlNumber"].ToString(),
                            out int controlNumber))
                        {
                            slipDate[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            slipDate[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            slipDate[i].EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                        }
                        else
                        {
                            slipDate[i].EmployeeName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"].ToString()) && int.TryParse(row["employeeId"].ToString(),
                            out int employeeId))
                        {
                            slipDate[i].EmployeeId = employeeId;
                        }
                        else
                        {
                            slipDate[i].EmployeeId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            slipDate[i].EmployeePicture = $"{employeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            slipDate[i].EmployeePicture = defaultImage;
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(),
                            out DateTime dateFile))
                        {
                            slipDate[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            slipDate[i].DateFiled = "----------";
                        }

                        approveList.Controls.Add(slipDate[i]);
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async void slipApproveUC_Load(object sender, EventArgs e)
        {
            await DisplaySlipList();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(searchEmployee.Texts))
            {
                await DisplaySearchList(searchEmployee.Texts);
            }
            else
            {
                await DisplaySlipList();
            }
        }
    }
}
