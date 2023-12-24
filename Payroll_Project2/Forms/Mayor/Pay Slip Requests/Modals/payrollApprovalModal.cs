using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Modals
{
    public partial class payrollApprovalModal : Form
    {
        private static int _userId;
        private static string _department;
        private static payslipRequestDataUC _parent;
        private static readonly payslipRequestClass payslipRequestClass = new payslipRequestClass();
        private static readonly bool ApprovalStatus = true;

        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalNetAmount { get; set; }
        public string MayorName { get; set; }
        public string NameOfCompany { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyLogo { get; set; }
        public string DepartmentName { get; set; }

        public payrollApprovalModal(int userId, payslipRequestDataUC parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetSummary(string departmentName)
        {
            try
            {
                DataTable details = await payslipRequestClass.GetPayrollRequestSummary(departmentName);

                if (details != null && details.Rows.Count > 0)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetRequestList(string departmentName, string mayorDepartment)
        {
            try
            {
                DataTable list = await payslipRequestClass.GetPayrollRequestList(departmentName, mayorDepartment);

                if (list != null && list.Rows.Count > 0)
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

        private async Task ParsedPayslipSummary(string departmentName)
        {
            try
            {
                DataTable summary = await GetSummary(departmentName);

                if (summary != null)
                {
                    foreach (DataRow row in summary.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["totalEarnings"]?.ToString()) && decimal.TryParse(row["totalEarnings"]?.ToString(), 
                            out decimal totalEarnings))
                        {
                            TotalEarnings = $"{totalEarnings:C2}";
                        }
                        else
                        {
                            TotalEarnings = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalDeductions"]?.ToString()) && decimal.TryParse(row["totalDeductions"]?.ToString(), 
                            out decimal totalDeductions))
                        {
                            TotalDeductions = $"{totalDeductions:C2}";
                        }
                        else
                        {
                            TotalDeductions = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalNetAmount"]?.ToString()) && decimal.TryParse(row["totalNetAmount"]?.ToString(), 
                            out decimal totalNetAmount))
                        {
                            TotalNetAmount = $"{totalNetAmount:C2}";
                        }
                        else
                        {
                            TotalNetAmount = $"{0:C2}";
                        }
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private async Task DisplayEmployeeLists(string departmentName, string mayorDepartment, int userId)
        {
            try
            {
                employeeListPanel.Controls.Clear();
                DataTable employeeList = await GetRequestList(departmentName, mayorDepartment);

                if (employeeList != null)
                {
                    employeeAppprovalUC[] employeeUC = new employeeAppprovalUC[employeeList.Rows.Count];

                    for (int i = 0; i < employeeList.Rows.Count; i++)
                    {
                        employeeUC[i] = new employeeAppprovalUC(userId, mayorDepartment, this);
                        DataRow row = employeeList.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"]?.ToString()))
                        {
                            employeeUC[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            employeeUC[i].EmployeeName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"]?.ToString()) && int.TryParse(row["employeeId"]?.ToString(), 
                            out int employeeId))
                        {
                            employeeUC[i].EmployeeID = employeeId;
                        }
                        else
                        {
                            employeeUC[i].EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["payrollFormId"]?.ToString()) && int.TryParse(row["payrollFormId"]?.ToString(), 
                            out int payrollFormId))
                        {
                            employeeUC[i].PayrollFormId = payrollFormId;
                        }
                        else
                        {
                            employeeUC[i].PayrollFormId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"]?.ToString()))
                        {
                            employeeUC[i].JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            employeeUC[i].JobDescription = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateValue"]?.ToString()) && decimal.TryParse(row["salaryRateValue"]?.ToString(), 
                            out decimal basicSalary))
                        {
                            employeeUC[i].BasicSalary = $"{basicSalary:C2}";
                        }
                        else
                        {
                            employeeUC[i].BasicSalary = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalEarnings"]?.ToString()) && decimal.TryParse(row["totalEarnings"]?.ToString(), 
                            out decimal totalEarnings))
                        {
                            employeeUC[i].Earnings = $"{totalEarnings:C2}";
                        }
                        else
                        {
                            employeeUC[i].Earnings = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalDeduction"]?.ToString()) && decimal.TryParse(row["totalDeduction"]?.ToString(), 
                            out decimal totalDeduction))
                        {
                            employeeUC[i].Deductions = $"{totalDeduction:C2}";
                        }
                        else
                        {
                            employeeUC[i].Deductions = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["netAmount"]?.ToString()) && decimal.TryParse(row["netAmount"]?.ToString(), 
                            out decimal netAmount))
                        {
                            employeeUC[i].NetAmount = $"{netAmount:C2}";
                        }
                        else
                        {
                            employeeUC[i].NetAmount = $"{0:C2}";
                        }

                        employeeListPanel.Controls.Add(employeeUC[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private void DataBinding()
        {
            totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
            totalDeductions.DataBindings.Add("Text", this, "TotalDeductions");
            totalNetAmount.DataBindings.Add("Text", this, "TotalNetAmount");
            mayorName.DataBindings.Add("Text", this, "MayorName");
            companyName.DataBindings.Add("Text", this, "NameOfCompany");
            companyAddress.DataBindings.Add("Text", this, "CompanyAddress");
            companyLogo.DataBindings.Add("ImageLocation", this, "CompanyLogo");
            CenterDepartmentHead();
        }

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - mayorName.Width) / 2;
            mayorName.Location = new Point(departmentHeadX, mayorName.Top);


            // Set the new position for departmentHead label
            mayorName.Location = new Point(departmentHeadX, mayorName.Location.Y);
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void payrollApprovalModal_Load(object sender, EventArgs e)
        {
            await ParsedPayslipSummary(DepartmentName);
            DataBinding();
            await DisplayEmployeeLists(DepartmentName, _department, _userId);
        }

        private void payrollApprovalModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
