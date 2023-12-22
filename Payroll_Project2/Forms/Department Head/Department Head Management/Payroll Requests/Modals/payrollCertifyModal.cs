using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Department_Head_Management.Payroll_Requests.Pay_slip_list_sub_user_control;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Department_Head_Management.Payroll_Requests.Modals
{
    public partial class payrollCertifyModal : Form
    {
        private static int _userId;
        private static string _department;
        private static payslipUC _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly bool CertifyStatus = true;

        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalNetAmount { get; set; }
        public string DepartmentHeadName { get; set; }

        public payrollCertifyModal(int userId, string department, payslipUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _department = department;
            _parent = parent;
        }

        #region Functions connected to general functions class

        private async Task<string> GetEmployeeName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> CertifyPayslip(int payrollFormId, string name, DateTime certifyDate, bool certifyStatus)
        {
            try
            {
                bool certify = await generalFunctions.CertifyThePassSlip(payrollFormId, name, certifyDate, certifyStatus);
                return certify;
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
                DataTable details = await generalFunctions.GetPayrollRequestSummary(departmentName);

                if (details != null && details.Rows.Count > 0)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Custom functions

        public async Task DisplayPaySlip(string departmentName, int userId)
        {
            try
            {
                DataTable list = await GetRequestList(departmentName);
                employeeListPanel.Controls.Clear();

                if (list != null)
                {
                    employeeCertificationUC[] employeeData = new employeeCertificationUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        employeeData[i] = new employeeCertificationUC(userId, this, departmentName);
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
                            employeeData[i].PayrollFormId = payrollFormId;
                        }
                        else
                        {
                            employeeData[i].PayrollFormId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["netAmount"].ToString()) && decimal.TryParse(row["netAmount"].ToString(),
                            out decimal netPay))
                        {
                            employeeData[i].NetAmount = $"{netPay:C2}";
                        }
                        else
                        {
                            employeeData[i].NetAmount = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalDeduction"].ToString()) && decimal.TryParse(row["totalDeduction"].ToString(),
                            out decimal totalDeduction))
                        {
                            employeeData[i].Deductions = $"{totalDeduction:C2}";
                        }
                        else
                        {
                            employeeData[i].Deductions = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalEarnings"].ToString()) && decimal.TryParse(row["totalEarnings"].ToString(),
                            out decimal totalEarnings))
                        {
                            employeeData[i].Earnings = $"{totalEarnings:C2}";
                        }
                        else
                        {
                            employeeData[i].Earnings = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"]?.ToString()))
                        {
                            employeeData[i].JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            employeeData[i].JobDescription = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateValue"]?.ToString()) && decimal.TryParse(row["salaryRateValue"]?.ToString(), 
                            out decimal salaryRateValue))
                        {
                            employeeData[i].BasicSalary = $"{salaryRateValue:C2}";
                        }
                        else
                        {
                            employeeData[i].BasicSalary = $"{0:C2}";
                        }

                        employeeListPanel.Controls.Add(employeeData[i]);
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

        public async Task ParsePayrollRequestSummary(string department, int userId)
        {
            try
            {
                DataTable details = await GetSummary(department);
                string name = await GetEmployeeName(userId);
                totalEarnings.DataBindings.Clear();
                totalDeductions.DataBindings.Clear();
                totalNetAmount.DataBindings.Clear();

                if (details != null && name != null)
                {
                    DepartmentHeadName = name;
                    foreach (DataRow row in details.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["totalEarnings"]?.ToString()) && decimal.TryParse(row["totalEarnings"]?.ToString(), 
                            out decimal earnings))
                        {
                            TotalEarnings = $"{earnings:C2}";
                        }
                        else
                        {
                            TotalEarnings = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["totalDeductions"]?.ToString()) && decimal.TryParse(row["totalDeductions"]?.ToString(),
                            out decimal deduction))
                        {
                            TotalDeductions = $"{deduction:C2}";
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
                else
                {
                    DepartmentHeadName = name;
                    TotalEarnings = $"{0:C2}";
                    TotalDeductions = $"{0:C2}";
                    TotalNetAmount = $"{0:C2}";
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

        private void DataBinding()
        {
            totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
            totalDeductions.DataBindings.Add("Text", this, "TotalDeductions");
            totalNetAmount.DataBindings.Add("Text", this, "TotalNetAmount");
            departmentHeadName.DataBindings.Add("Text", this, "DepartmentHeadName");
            CenterDepartmentHead();
        }

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHeadName.Width) / 2;
            departmentHeadName.Location = new Point(departmentHeadX, departmentHeadName.Top);


            // Set the new position for departmentHead label
            departmentHeadName.Location = new Point(departmentHeadX, departmentHeadName.Location.Y);
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Event Handlers

        private async void payrollCertifyModal_Load(object sender, EventArgs e)
        {
            await ParsePayrollRequestSummary(_department, _userId);
            DataBinding();
            await DisplayPaySlip(_department, _userId);
        }

        private void payrollCertifyModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion

        #region Encapsulated functions

        private async Task<bool> SubmitCertification(int payrollFormId, string name, DateTime certifyDate, bool certifyStatus)
        {
            try
            {
                bool submit = await CertifyPayslip(payrollFormId, name, certifyDate, certifyStatus);

                if (submit)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error encountered certifying the Payslip with the transaction ID: {payrollFormId}. " +
                        $"Please contact the system admin for prompt resolution.", "Payslip Certification Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddSystemLog(DateTime logDate, string name, int userId, int employeeId, string employeeName)
        {
            try
            {
                string description = $"Payroll Certification for: ({employeeName} ID: {employeeId}) " +
                    $"|| Certified by: ({name} ID: {userId}) " +
                    $"|| Date and Time: {logDate:MMMM dd, yyyy} - {logDate:t}";
                string caption = $"Payroll Certification";
                bool insert = await InsertSystemLog(logDate, description, caption);

                if (insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered during the addition into the System Logs. As the Payroll is already " +
                        "certified and forwarded please await further approval and notice!", "System Log Insertion Error");
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
                string description = $"Payroll Certification for Employee {employeeName} ID: {employeeId}" +
                    $"|| Certified By: {name} ID: {userId} " +
                    $"|| Payroll Transaction Number: {payrollId}";
                bool insert = await InsertPayrollTransactionLog(logDate, description, payrollId);

                if (insert)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered during the addition into the Transaction Logs. As the Payroll is already " +
                        "certified and forwarded please await further approval and notice!", "Transaction Log Insertion Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable request = await GetRequestList(_department);

                if (request != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"By certifying, you confirm that the employee(s) listed in this roll have rendered the indicated service for the " +
                        $"specified time. You are certifying the accuracy of the information provided. Do you wish to proceed?",
                        "Confirmation: Certification of Employee Service",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < request.Rows.Count; i++)
                        {
                            DataRow row = request.Rows[i];

                            if (!string.IsNullOrEmpty(row["payrollFormId"]?.ToString()) && int.TryParse(row["payrollFormId"]?.ToString(), 
                                out int payrollFormId) && !string.IsNullOrEmpty(row["employeeName"]?.ToString()) &&
                                !string.IsNullOrEmpty(row["employeeId"]?.ToString()) && int.TryParse(row["employeeId"]?.ToString(), 
                                out int employeeId))
                            {
                                bool submitCertification = await SubmitCertification(payrollFormId, DepartmentHeadName, DateTime.Today, 
                                    CertifyStatus);
                                if (!submitCertification)
                                    return;

                                bool systemLog = await AddSystemLog(DateTime.Now, DepartmentHeadName, _userId, employeeId,
                                    $"{row["employeeName"]}");
                                if(!systemLog) 
                                    return;

                                bool transactionLog = await AddTransactionLog(DateTime.Now, _userId, payrollFormId, $"{row["employeeName"]}",
                                    employeeId, DepartmentHeadName);
                                if(!transactionLog) 
                                    return;
                            }
                        }

                        SuccessMessages($"The certification process has been completed successfully for {request.Rows.Count} payroll requests.",
                            "Certification Confirmation");
                        await DisplayPaySlip(_department, _userId);
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
