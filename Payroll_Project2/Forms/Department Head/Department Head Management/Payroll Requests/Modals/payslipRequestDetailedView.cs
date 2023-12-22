using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals
{
    public partial class paySlipRequestDetailedView : Form
    {
        private static int _userId;
        private static employeeDataUC _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly bool CertifyStatus = true;

        public int PayrollId { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentHeadName { get; set; }
        public string DepartmentName { get; set; }
        public string NameOfCompany { get; set; }
        public string CompanyAddress { get; set; }
        public string SalaryDescription { get; set; }
        public string PayrollPeriod { get; set; }
        public string SalaryAmount { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string NetPay { get; set; }

        public paySlipRequestDetailedView(int userId, employeeDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        #region Get and Insert Functions

        private async Task<bool> CertifyPayslip(int payrollFormId, string name, DateTime certifyDate, bool certifyStatus)
        {
            try
            {
                bool certify = await generalFunctions.CertifyThePassSlip(payrollFormId, name, certifyDate, certifyStatus);
                return certify;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetEarningsList(int payrollId)
        {
            try
            {
                DataTable list = await generalFunctions.GetEarningsList(payrollId);

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

        private async Task<DataTable> GetDeductionsList(int payrollId)
        {
            try
            {
                DataTable list = await generalFunctions.GetDeductionsList(payrollId);

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

        #endregion

        #region Parsing Functions

        private async Task DisplayEarnings(int payrollId, int userId)
        {
            try
            {
                earningsListPanel.Controls.Clear();

                DataTable earningsList = await GetEarningsList(payrollId);

                if (earningsList != null)
                {
                    earningsDataUC[] earnings = new earningsDataUC[earningsList.Rows.Count];

                    for (int i = 0; i < earningsList.Rows.Count; i++)
                    {
                        earnings[i] = new earningsDataUC(userId, this);
                        DataRow row = earningsList.Rows[i];

                        if (!string.IsNullOrEmpty(row["earningsDescription"]?.ToString()))
                        {
                            earnings[i].EarningsDescription = $"{row["earningsDescription"]}";
                        }
                        else
                        {
                            earnings[i].EarningsDescription = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["earningsAmount"]?.ToString()) && decimal.TryParse(row["earningsAmount"]?.ToString(), 
                            out decimal earningsAmount))
                        {
                            earnings[i].EarningsAmount = $"{earningsAmount:C2}";
                        }
                        else
                        {
                            earnings[i].EarningsAmount = $"{0:C2}";
                        }

                        earningsListPanel.Controls.Add(earnings[i]);
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

        private async Task DisplayDeductions(int payrollId, int userId)
        {
            try
            {
                deductionsListPanel.Controls.Clear();
                DataTable deductionList = await GetDeductionsList(payrollId);

                if (deductionList != null)
                {
                    deductionDataUC[] deductions = new deductionDataUC[deductionList.Rows.Count];

                    for (int i = 0; i < deductionList.Rows.Count; i++)
                    {
                        deductions[i] = new deductionDataUC(userId, this);
                        DataRow row = deductionList.Rows[i];

                        if (!string.IsNullOrEmpty(row["deductionDescription"]?.ToString()))
                        {
                            deductions[i].DeductionDescription = $"{row["deductionDescription"]}";
                        }
                        else
                        {
                            deductions[i].DeductionDescription = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["deductionAmount"]?.ToString()) && decimal.TryParse(row["deductionAmount"]?.ToString(), 
                            out decimal deductionAmount))
                        {
                            deductions[i].DeductionAmount = $"{deductionAmount:C2}";
                        }
                        else
                        {
                            deductions[i].DeductionAmount = $"{0:C2}";
                        }

                        deductionsListPanel.Controls.Add(deductions[i]);
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

        #endregion

        #region Custom Functions

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearBindings()
        {
            employeeId.DataBindings.Clear();
            employeeName.DataBindings.Clear();
            companyName.DataBindings.Clear();
            companyAddress.DataBindings.Clear();
            departmentName.DataBindings.Clear();
            salaryDescription.DataBindings.Clear();
            payrollPeriod.DataBindings.Clear();
            basicSalaryAmount.DataBindings.Clear();
            totalEarnings.DataBindings.Clear();
            totalDeductions.DataBindings.Clear();
            netPay.DataBindings.Clear();
            payrollId.DataBindings.Clear();
        }

        private async Task DataBinding(int payrollFormId, int userId)
        {
            try
            {
                ClearBindings();
                earningsListPanel.Controls.Clear();
                deductionsListPanel.Controls.Clear();

                payrollId.DataBindings.Add("Text", this, "PayrollId");
                employeeId.DataBindings.Add("Text", this, "EmployeeID");
                employeeName.DataBindings.Add("Text", this, "EmployeeName");
                companyName.DataBindings.Add("Text", this, "NameOfCompany");
                companyAddress.DataBindings.Add("Text", this, "CompanyAddress");
                departmentName.DataBindings.Add("Text", this, "DepartmentName");
                salaryDescription.DataBindings.Add("Text", this, "SalaryDescription");
                payrollPeriod.DataBindings.Add("Text", this, "PayrollPeriod");
                basicSalaryAmount.DataBindings.Add("Text", this, "SalaryAmount");
                totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
                totalDeductions.DataBindings.Add("Text", this, "TotalDeductions");
                netPay.DataBindings.Add("Text", this, "NetPay");
                departmentHeadName.DataBindings.Add("Text", this, "DepartmentHeadName");
                CenterDepartmentHead();

                await DisplayDeductions(payrollFormId, userId);
                await DisplayEarnings(payrollFormId, userId);
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

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHeadName.Width) / 2;
            departmentHeadName.Location = new Point(departmentHeadX, departmentHeadName.Top);


            // Set the new position for departmentHead label
            departmentHeadName.Location = new Point(departmentHeadX, departmentHeadName.Location.Y);
        }

        #endregion

        #region Event Handlers

        private async void payslip_Load(object sender, EventArgs e)
        {
            await DataBinding(PayrollId, _userId);
        }

        private void paySlipRequestDetailedView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion

        #region Encapsulated Functions

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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

        private async Task<bool> AddTransactionLog(DateTime logDate, int userId, int payrollId, string employeeName,
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
                bool certify = await SubmitCertification(PayrollId, DepartmentHeadName, DateTime.Today, CertifyStatus);
                if (!certify)
                    return;

                bool payrollTransactionLog = await AddTransactionLog(DateTime.Today, _userId, PayrollId, EmployeeName, DepartmentHeadName);
                if (!payrollTransactionLog)
                    return;

                bool systemLog = await AddSystemLog(DateTime.Today, DepartmentHeadName, _userId, EmployeeID, EmployeeName);
                if (!systemLog)
                    return;

                SuccessMessages($"The payroll form with the transaction number {PayrollId} is on the process and is pending for " +
                    $"proper review and approval.", "Payroll Form Generation Done");
                this.Close();
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
