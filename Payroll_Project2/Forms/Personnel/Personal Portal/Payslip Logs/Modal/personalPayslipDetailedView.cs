using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Modal
{
    public partial class personalPayslipDetailedView : Form
    {
        private static int _userId;
        private static payslipLogDataUC _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int TransactionNumber { get; set; }
        public string PayslipPeriod { get; set; }
        public int EmployeeID { get; set; }
        public string SalaryRateDescription { get; set; }
        public string SalaryRate { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string EmploymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string CertifyDetails { get; set; }
        public string ApproveDetails { get; set; }
        public string PaymentCertifyDetails { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalSalary { get; set; }

        public personalPayslipDetailedView(int userId, payslipLogDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetEarnings(int payrollId)
        {
            try
            {
                DataTable earnings = await generalFunctions.GetEarningsList(payrollId);

                if(earnings.Rows .Count > 0)
                {
                    return earnings;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetDeductions(int payrollId)
        {
            try
            {
                DataTable deductions = await generalFunctions.GetDeductionsList(payrollId);

                if(deductions.Rows.Count > 0)
                {
                    return deductions;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task ParsedDeduction(int payrollId, int userId)
        {
            try
            {
                deductionsContent.Controls.Clear();
                DataTable deductions = await GetDeductions(payrollId);

                if (deductions != null)
                {
                    payslipDeductionsUC[] deductionsUC = new payslipDeductionsUC[deductions.Rows.Count];

                    for (int i = 0; i < deductions.Rows.Count; i++)
                    {
                        deductionsUC[i] = new payslipDeductionsUC(userId, this);
                        DataRow row = deductions.Rows[i];

                        if (row["deductionDescription"] != null)
                        {
                            deductionsUC[i].DeductionDescription = $"{row["deductionDescription"]}";
                        }
                        else
                        {
                            deductionsUC[i].DeductionDescription = "----------";
                        }

                        if (row["deductionAmount"] != null && decimal.TryParse(row["deductionAmount"]?.ToString(),
                            out decimal deductionAmount))
                        {
                            deductionsUC[i].DeductionAmount = $"{deductionAmount:C2}";
                        }
                        else
                        {
                            deductionsUC[i].DeductionAmount = $"{0:C2}";
                        }

                        deductionsContent.Controls.Add(deductionsUC[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ParsedEarnings(int payrollId, int userId)
        {
            try
            {
                earningsContent.Controls.Clear();
                DataTable earnings = await GetEarnings(payrollId);

                if (earnings != null)
                {
                    payslipEarningsUC[] earningsUC = new payslipEarningsUC[earnings.Rows.Count];

                    for (int i = 0; i < earnings.Rows.Count; i++)
                    {
                        earningsUC[i] = new payslipEarningsUC(userId, this);
                        DataRow row = earnings.Rows[i];

                        if (row["earningsDescription"] != null)
                        {
                            earningsUC[i].EarningsDescription = $"{row["earningsDescription"]}";
                        }
                        else
                        {
                            earningsUC[i].EarningsDescription = "----------";
                        }

                        if (row["earningsAmount"] != null && decimal.TryParse(row["earningsAmount"]?.ToString(), 
                            out decimal earningsAmount))
                        {
                            earningsUC[i].EarningsAmount = $"{earnings:C2}";
                        }
                        else
                        {
                            earningsUC[i].EarningsAmount = $"{0:C2}";
                        }

                        earningsContent.Controls.Add(earningsUC[i]);
                    }
                }
            }
            catch (SqlException sql) 
            {
                MessageBox.Show(sql.Message);
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataBinding()
        {
            // Assuming you have controls with the same name but starting with a lowercase letter
            transactionNumber.DataBindings.Add("Text", this, "TransactionNumber");
            payslipPeriod.DataBindings.Add("Text", this, "PayslipPeriod");
            employeeId.DataBindings.Add("Text", this, "EmployeeID");
            salaryRateDescription.DataBindings.Add("Text", this, "SalaryRateDescription");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            status.DataBindings.Add("Text", this, "EmploymentStatus");
            createdBy.DataBindings.Add("Text", this, "CreatedBy");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            certifyDetails.DataBindings.Add("Text", this, "CertifyDetails");
            approveDetails.DataBindings.Add("Text", this, "ApproveDetails");
            paymentCertifiedDetails.DataBindings.Add("Text", this, "PaymentCertifyDetails");
            deductionsTotal.DataBindings.Add("Text", this, "TotalDeductions");
            totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
            totalAmount.DataBindings.Add("Text", this, "TotalSalary");
        }

        private async void personalPayslipDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
            await ParsedEarnings(TransactionNumber, _userId);
            await ParsedDeduction(TransactionNumber, _userId);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
