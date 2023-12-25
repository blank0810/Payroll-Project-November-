using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
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
using System.Web.Hosting;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Modals
{
    public partial class payrollApprovalModal : Form
    {
        private static int _userId;
        private static string _department;
        private static payslipRequestDataUC _parent;
        private static generalFunctions generalFunctions = new generalFunctions();  
        private static readonly payslipRequestClass payslipRequestClass = new payslipRequestClass();
        private static readonly bool ApprovalStatus = true;
        private static readonly string ApproveStatus = ConfigurationManager.AppSettings.Get("PayslipApproveStatus");

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

        private async Task<bool> ApprovePayslip(bool approveStatus, string name, DateTime date, int payrollId, string statusDescription)
        {
            try
            {
                bool approvePayroll = await payslipRequestClass.ApprovePayroll(approveStatus, name, date, payrollId, statusDescription);
                return approvePayroll;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> ApproveAndCertify(bool approveStatus, string name, DateTime date, int payrollFormId, string statusDescription)
        {
            try
            {
                bool approve = await payslipRequestClass.ApproveAndCertifyPayroll(approveStatus, name, date, payrollFormId, statusDescription);
                return approve;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertSystemLog(DateTime logDate, string description, string caption)
        {
            try
            {
                bool systemLog = await generalFunctions.AddSystemLogs(logDate, description, caption);
                return systemLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertPayrollTransactionLog(DateTime logDate, string description, int payrollId)
        {
            try
            {
                bool insert = await generalFunctions.AddCreationPayrollTransactionLog(logDate, description, payrollId);
                return insert;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
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

        public async Task DisplayEmployeeLists(string mayorDepartment, int userId)
        {
            try
            {
                employeeListPanel.Controls.Clear();
                await ParsedPayslipSummary(DepartmentName);
                DataBinding();
                DataTable employeeList = await GetRequestList(DepartmentName, mayorDepartment);

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
            totalEarnings.DataBindings.Clear();
            totalDeductions.DataBindings.Clear();
            totalNetAmount.DataBindings.Clear();
            mayorName.DataBindings.Clear();
            companyName.DataBindings.Clear();
            companyAddress.DataBindings.Clear();
            companyLogo.DataBindings.Clear();
            approvalCheck.Checked = false;

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
            await DisplayEmployeeLists(_department, _userId);
        }

        private void payrollApprovalModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private bool IsValid()
        {
            if(approvalCheck.Checked)
            {
                return true;
            }
            else
            {
                ErrorMessages("To proceed, please ensure that the approval checkbox is selected.", "Approval Check");
                return false;
            }
        }

        private async Task<bool> SubmitApproval(int payrollFormId, string name, DateTime date, bool status, 
            string employeeDepartment, string mayorDepartment, string statusDescription)
        {
            try
            {
                if (mayorDepartment == employeeDepartment)
                {
                    bool approve = await ApproveAndCertify(status, name, date, payrollFormId, statusDescription);

                    if (approve)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is an error encountered approving the Payslip with the transaction ID: {payrollFormId}. " +
                        $"Please contact the system admin for prompt resolution.", "Payslip Certification Error");
                        return false;
                    }
                }
                else
                {
                    bool approve = await ApprovePayslip(status, name, date, payrollFormId, statusDescription);
                    if (approve)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is an error encountered approving the Payslip with the transaction ID: {payrollFormId}. " +
                        $"Please contact the system admin for prompt resolution.", "Payslip Certification Error");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddSystemLog(DateTime logDate, string name, int userId, int employeeId, string employeeName)
        {
            try
            {
                string description = $"Payroll Approval for release: ({employeeName} ID: {employeeId}) " +
                    $"|| Approved by: ({name} ID: {userId}) " +
                    $"|| Date and Time: {logDate:MMMM dd, yyyy} - {logDate:t}";
                string caption = $"Payroll Approval";
                bool insert = await InsertSystemLog(logDate, description, caption);

                if (insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered during the addition into the System Logs. As the Payroll is already " +
                        "approved and forwarded for releasing please await further notice!", "System Log Insertion Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddTransactionLog(DateTime logDate, int userId, int payrollId, string employeeName, int employeeId, 
            string name)
        {
            try
            {
                string description = $"Payroll Approval for Release: {employeeName} ID: {employeeId}" +
                    $"|| Approved By: {name} ID: {userId} " +
                    $"|| Payroll Transaction Number: {payrollId}";
                bool insert = await InsertPayrollTransactionLog(logDate, description, payrollId);

                if (insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered during the addition into the Transaction Logs. As the Payroll is already " +
                        "approved and forwarded for releasing please await further notice!", "Transaction Log Insertion Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable list = await GetRequestList(DepartmentName, _department);

                if(list != null)
                {
                    DialogResult result = MessageBox.Show(
                        "As the MUNICIPAL MAYOR, you are hereby ENDORSING and APPROVING the disbursement of payment for the employee(s) listed in this payroll form. " +
                        "Do you wish to proceed?",
                        "Confirmation: Mayor's Endorsement and Approval",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        foreach(DataRow row in list.Rows)
                        {
                            if (!string.IsNullOrEmpty(row["payrollFormId"]?.ToString()) && int.TryParse(row["payrollFormId"]?.ToString(),
                                out int payrollFormId) && !string.IsNullOrEmpty(row["employeeName"]?.ToString()) &&
                                !string.IsNullOrEmpty(row["employeeId"]?.ToString()) && int.TryParse(row["employeeId"]?.ToString(),
                                out int employeeId))
                            {
                                if (!IsValid())
                                    return;

                                bool approval = await SubmitApproval(payrollFormId, MayorName, DateTime.Today, ApprovalStatus, DepartmentName,
                                    _department, ApproveStatus);
                                if (!approval)
                                    return;

                                bool transactionLog = await AddTransactionLog(DateTime.Today, _userId, payrollFormId, $"{row["employeeName"]}",
                                    employeeId, MayorName);
                                if (!transactionLog) 
                                    return;

                                bool systemLog = await AddSystemLog(DateTime.Today, MayorName, _userId, employeeId, $"{row["employeeName"]}");
                                if(!systemLog)
                                    return;
                            }
                        }

                        SuccessMessages($"The endorsement and approval process for {list.Rows.Count} payroll requests has been successfully " +
                            $"completed. The disbursement of payment is now authorized.",
                            "Endorsement and Approval Confirmation");
                        await DisplayEmployeeLists(_department, _userId);
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
    }
}
