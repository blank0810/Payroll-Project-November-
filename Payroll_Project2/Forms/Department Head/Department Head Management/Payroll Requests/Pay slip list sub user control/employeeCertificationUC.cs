using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Department_Head_Management.Payroll_Requests.Modals;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals;
using Payroll_Project2.Forms.Personnel.Payroll;
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

namespace Payroll_Project2.Forms.Department_Head.Department_Head_Management.Payroll_Requests.Pay_slip_list_sub_user_control
{
    public partial class employeeCertificationUC : UserControl
    {
        private static int _userId;
        private static payrollCertifyModal _parent;
        private static string _department;
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public int PayrollFormId { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string BasicSalary { get; set; }
        public string Earnings { get; set; }
        public string Deductions { get; set; }
        public string NetAmount { get; set; }

        public employeeCertificationUC(int userId, payrollCertifyModal parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }
        private async Task<DataTable> GetPayrollDetails(int payrollId)
        {
            try
            {
                DataTable details = await generalFunctions.GetPayrollDetails(payrollId);

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

        private void DataBinding()
        {
            employeeId.DataBindings.Add("Text", this, "EmployeeID");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            basicSalary.DataBindings.Add("Text", this, "BasicSalary");
            earnings.DataBindings.Add("Text", this, "Earnings");
            deductions.DataBindings.Add("Text", this, "Deductions");
            netAmount.DataBindings.Add("Text", this, "NetAmount");
        }

        private async Task DisplayPayrollDetails(int userId, int payrollId, string department, int employeeId, string employeeName,
            string totalDeductions, string totalEarnings, string netPay)
        {
            try
            {
                DataTable details = await GetPayrollDetails(payrollId);
                string name = await GetEmployeeName(userId);
                paySlipRequestDetailedView payslip = new paySlipRequestDetailedView(userId);

                if (details != null && name != null)
                {
                    payslip.EmployeeID = employeeId;
                    payslip.EmployeeName = employeeName;
                    payslip.DepartmentName = department;
                    payslip.DepartmentHeadName = name;
                    payslip.CompanyAddress = $"Jampason, Initao, Misamis Oriental 9022";
                    payslip.NameOfCompany = $"Local Government Unit of Initao";
                    payslip.TotalDeductions = totalDeductions;
                    payslip.TotalEarnings = totalEarnings;
                    payslip.NetPay = netPay;
                    payslip.PayrollId = payrollId;

                    foreach (DataRow row in details.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["payrollStartingDate"].ToString()) && !string.IsNullOrEmpty(row["payrollEndingDate"].ToString())
                            && DateTime.TryParse(row["payrollStartingDate"].ToString(), out DateTime startingDate) &&
                            DateTime.TryParse(row["payrollEndingDate"].ToString(), out DateTime endingDate))
                        {
                            payslip.PayrollPeriod = $"{startingDate:MMM dd, yyyy} - {endingDate:MMM dd, yyyy}";
                        }
                        else
                        {
                            payslip.PayrollPeriod = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateValue"].ToString()) && decimal.TryParse(row["salaryRateValue"].ToString(),
                            out decimal salaryRateValue))
                        {
                            payslip.SalaryAmount = $"{salaryRateValue:C2}";
                        }
                        else
                        {
                            payslip.SalaryAmount = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateDescription"]?.ToString()))
                        {
                            payslip.SalaryDescription = $"{row["salaryRateDescription"]}";
                        }
                        else
                        {
                            payslip.SalaryDescription = "---------";
                        }

                        payslip.ShowDialog();
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

        private void employeeCertificationUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayPayrollDetails(_userId, PayrollFormId, _department, EmployeeID, EmployeeName, Deductions, Earnings, NetAmount);
            await _parent.DisplayPaySlip(_department, _userId);
        }
    }
}
