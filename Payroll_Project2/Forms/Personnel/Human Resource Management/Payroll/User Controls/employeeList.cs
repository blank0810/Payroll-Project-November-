using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.User_Controls
{
    public partial class employeeList : UserControl
    {
        private static int _userId;
        private static payroll _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly payrollClass payrollClass = new payrollClass();
        private static readonly string DefaultName = ConfigurationManager.AppSettings.Get("DefaultNameOfCompany");
        private static readonly string DefaultAddress = ConfigurationManager.AppSettings.Get("DefaultAddress");

        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeePicture { get; set; }
        public string Department { get; set; }
        public string SalarySchedule { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public employeeList(int userId, payroll parent)
        {
            _userId = userId;
            _parent = parent;
            InitializeComponent();
        }

        private async Task<int> GetPayrollId()
        {
            try
            {
                int payrollId = await payrollClass.GetPayrollId();

                if (payrollId > 0)
                {
                    return payrollId;
                }
                else
                {
                    return 1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetEmployeeDetails(int employeeId)
        {
            try
            {
                DataTable details = await generalFunctions.GetEmployeeDetails(employeeId);

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

        private async Task ParsedEmployeeDetails(string employeeName, int employeeId, string department, string schedule, int userId, 
            DateTime fromDate, DateTime toDate, string address, string companyName)
        {
            try
            {
                DataTable details = await GetEmployeeDetails(employeeId);
                payslip payslip = new payslip(userId, this);
                int payrollId = await GetPayrollId();

                if(details != null && payrollId > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        payslip.EmployeeName = employeeName;
                        payslip.EmployeeID = employeeId;
                        payslip.EmployeeDepartment = department;
                        payslip.SalarySchedule = schedule;
                        payslip.FromDate = fromDate;
                        payslip.ToDate = toDate;
                        payslip.NumberOfDays = (toDate - fromDate).Days;
                        payslip.CompanyAddress = address;
                        payslip.NameOfCompany = companyName;
                        payslip.PayrollPeriod = $"{fromDate:MMM dd, yyyy} - {toDate:MMM dd, yyyy}";
                        payslip.PayrollId = payrollId;

                        if (!string.IsNullOrEmpty(row["salaryRateDescription"]?.ToString()))
                        {
                            payslip.SalaryDescription = $"{row["salaryRateDescription"]}";
                        }
                        else
                        {
                            payslip.SalaryDescription = "-----------";
                        }

                        if (!string.IsNullOrEmpty(row["amount"]?.ToString()) && decimal.TryParse(row["amount"].ToString(), 
                            out decimal amount))
                        {
                            payslip.SalaryAmount = $"{amount:C2}";
                        }
                        else
                        {
                            payslip.SalaryAmount = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["employmentStatus"]?.ToString()))
                        {
                            payslip.EmploymentStatus = $"{row["employmentStatus"]}";
                        }
                        else
                        {
                            payslip.EmploymentStatus = "--------";
                        }
                    }

                    payslip.ShowDialog();
                }
                else
                {
                    ErrorMessages("There is no details found in the database please contact the System Admnistrators for quick resolution.",
                        "Employee Details Retrieval Error");
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void DataBinding()
        {
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empid.DataBindings.Add("Text", this, "EmployeeId");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeePicture");
            departmentLabel.DataBindings.Add("Text", this, "Department");
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void employeeList_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void generateBtn_Click(object sender, EventArgs e)
        {
            await ParsedEmployeeDetails(EmployeeName, EmployeeId, Department, SalarySchedule, _userId, FromDate, ToDate, DefaultAddress, 
                DefaultName);
            await _parent.DisplayEmployeeBehaviour();
        }
    }
}
