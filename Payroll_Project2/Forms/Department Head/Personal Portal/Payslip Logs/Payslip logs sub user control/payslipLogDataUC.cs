using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Modal;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control
{
    public partial class payslipLogDataUC : UserControl
    {
        private static int _userId;
        private static payslipLogsUC _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public int PayrollID { get; set; }
        public string DateCreated { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalSalary { get; set; }

        public payslipLogDataUC(int userId, payslipLogsUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetPayslipDetails(int payrollId)
        {
            try
            {
                DataTable details = await generalFunctions.GetPayrollDetails(payrollId);

                if (details.Rows.Count > 0)
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

        private void DataBinding()
        {
            payrollFormId.DataBindings.Add("Text", this, "PayrollID");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
            totalDeductions.DataBindings.Add("Text", this, "TotalDeductions");
            totalSalary.DataBindings.Add("Text", this, "TotalSalary");
        }

        private async Task ParsedPayslipDetails(int payrollId, int userId, string totalEarnings, string totalDeduction, string totalSalary)
        {
            try
            {
                DataTable details = await GetPayslipDetails(payrollId);

                if (details != null)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        personalPayslipDetailedView payslip = new personalPayslipDetailedView(userId, this);

                        payslip.TransactionNumber = payrollId;
                        payslip.TotalDeductions = totalDeduction;
                        payslip.TotalEarnings = totalEarnings;
                        payslip.TotalSalary = totalSalary;

                        if (!string.IsNullOrEmpty(row["payrollStartingDate"].ToString()) &&
                            DateTime.TryParse(row["payrollStartingDate"].ToString(), out DateTime startDate) &&
                            !string.IsNullOrEmpty(row["payrollEndingDate"]?.ToString()) &&
                            DateTime.TryParse(row["payrollEndingDate"].ToString(), out DateTime endDate))
                        {
                            payslip.PayslipPeriod = $"{startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}";
                        }
                        else
                        {
                            payslip.PayslipPeriod = "-----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeId"]?.ToString()) && int.TryParse(row["employeeId"].ToString(),
                            out int employeeId))
                        {
                            payslip.EmployeeID = employeeId;
                        }
                        else
                        {
                            payslip.EmployeeID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateDescription"]?.ToString()))
                        {
                            payslip.SalaryRateDescription = $"{row["salaryRateDescription"]}";
                        }
                        else
                        {
                            payslip.SalaryRateDescription = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateValue"]?.ToString()) &&
                            decimal.TryParse(row["salaryRateValue"]?.ToString(), out decimal value))
                        {
                            payslip.SalaryRate = $"{value:C2}";
                        }
                        else
                        {
                            payslip.SalaryRate = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            payslip.EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            payslip.EmployeeName = "---------";
                        }

                        if (row["employmentStatus"] != null)
                        {
                            payslip.EmploymentStatus = $"{row["employmentStatus"]}";
                        }
                        else
                        {
                            payslip.EmploymentStatus = "----------";
                        }

                        if (row["employeeJobDesc"] != null)
                        {
                            payslip.JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            payslip.JobDescription = "----------";
                        }

                        if (row["createdBy"] != null)
                        {
                            payslip.CreatedBy = $"{row["createdBy"]}";
                        }
                        else
                        {
                            payslip.CreatedBy = "---------";
                        }

                        if (row["dateCreated"] != null && DateTime.TryParse(row["dateCreated"].ToString(), out DateTime dateCreated))
                        {
                            payslip.DateCreated = $"{dateCreated:MMM dd, yyyy}";
                        }
                        else
                        {
                            payslip.DateCreated = "----------";
                        }

                        if (row["isCertifyByOfficeHeadName"] != null && row["isCertifyByOfficeHeadDate"] != null &&
                            DateTime.TryParse(row["isCertifyByOfficeHeadDate"]?.ToString(), out DateTime certifyDate))
                        {
                            payslip.CertifyDetails = $"{row["isCertifyByOfficeHeadName"]} - {certifyDate:MM/dd/yyyy}";
                        }
                        else
                        {
                            payslip.CertifyDetails = "--------";
                        }

                        if (row["approveByMayorName"] != null && row["approveByMayorDate"] != null &&
                            DateTime.TryParse(row["approveByMayorDate"].ToString(), out DateTime approvedDate))
                        {
                            payslip.ApproveDetails = $"{row["approveByMayorName"]} - {approvedDate:MM/dd/yyyy}";
                        }
                        else
                        {
                            payslip.ApproveDetails = "---------";
                        }

                        if (row["certifiedByTreasurerName"] != null && row["certifiedByTreasurerDate"] != null &&
                            DateTime.TryParse(row["certifiedByTreasurerDate"].ToString(), out DateTime treasurerDate))
                        {
                            payslip.PaymentCertifyDetails = $"{row["certifiedByTreasurerName"]} - {treasurerDate:MM/dd/yyyy}";
                        }
                        else
                        {
                            payslip.PaymentCertifyDetails = "----------";
                        }

                        payslip.ShowDialog();
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await ParsedPayslipDetails(PayrollID, _userId, TotalEarnings, TotalDeductions, TotalSalary);
            await _parent.DisplayLog(_userId);
        }

        private void payslipLogDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
