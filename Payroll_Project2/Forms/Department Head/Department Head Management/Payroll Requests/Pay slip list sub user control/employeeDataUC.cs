﻿using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests.Modals;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Payroll_Requests.Pay_slip_list_sub_user_control
{
    public partial class employeeDataUC : UserControl
    {
        private static int _userId;
        private static payslipUC _parent;
        private static string _department;
        private static readonly generalFunctions generalFunctions = new generalFunctions(); 

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int PayrollID { get; set; }
        public string DateCreated { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalDeductions { get; set; }
        public string TotalSalary { get; set; }

        public employeeDataUC(int userId, payslipUC parent, string department)
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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

        private async Task DisplayPayrollDetails(int userId, int payrollId, string department, int employeeId, string employeeName,
            string totalDeductions, string totalEarnings, string netPay)
        {
            try
            {
                DataTable details = await GetPayrollDetails(payrollId);
                string name = await GetEmployeeName(userId);
                paySlipRequestDetailedView payslip = new paySlipRequestDetailedView(userId, this);

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

        private void DataBinding()
        {
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            employeeId.DataBindings.Add("Text", this, "EmployeeID");
            payrollFormId.DataBindings.Add("Text", this, "PayrollID");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            totalEarnings.DataBindings.Add("Text", this, "TotalEarnings");
            totalDeductions.DataBindings.Add("Text", this, "TotalDeductions");
            totalSalary.DataBindings.Add("Text", this, "TotalSalary");
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayPayrollDetails(_userId, PayrollID, _department, EmployeeID, EmployeeName, TotalDeductions, TotalEarnings, TotalSalary);
            await _parent.DisplayPaySlip(_department, _userId);
        }

        private void employeeDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
