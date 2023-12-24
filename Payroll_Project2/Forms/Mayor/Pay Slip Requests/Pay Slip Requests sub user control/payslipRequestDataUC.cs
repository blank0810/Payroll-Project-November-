using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Modals;
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

namespace Payroll_Project2.Forms.Mayor.Pay_Slip_Requests.Pay_Slip_Requests_sub_user_control
{
    public partial class payslipRequestDataUC : UserControl
    {
        private int _userId;
        private static string _department;
        private static payslipRequestsUC _parent;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string NameOfCompany = ConfigurationManager.AppSettings.Get("DefaultNameOfCompany");
        private static readonly string CompanyLogo = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly string CompanyAddress = ConfigurationManager.AppSettings.Get("DefaultAddress");

        public string DepartmentLogo { get; set; }
        public string DepartmentName {  get; set; }
        public int RequestCount { get; set; }

        public payslipRequestDataUC(int userId, payslipRequestsUC parent, string department)
        {
            InitializeComponent();
            _parent = parent;
            _userId = userId;
            _department = department;
        }

        private async Task<string> GetEmployeeName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);

                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DisplayEmployeeList(int userId, string department, string departmentName, string companyName, string companyLogo, 
            string companyAddress)
        {
            try
            {
                string name = await GetEmployeeName(userId);
                payrollApprovalModal payrollApproval = new payrollApprovalModal(userId, this, department);

                if (!string.IsNullOrEmpty(name))
                {
                    payrollApproval.NameOfCompany = companyName;
                    payrollApproval.CompanyAddress = companyAddress;
                    payrollApproval.CompanyLogo = companyLogo;
                    payrollApproval.MayorName = name;
                    payrollApproval.DepartmentName = departmentName;
                    payrollApproval.ShowDialog();
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error");
            }
        }

        private void DataBinding()
        {
            departmentLogo.DataBindings.Add("ImageLocation", this, "DepartmentLogo");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            requestCount.DataBindings.Add("Text", this, "RequestCount");
        }

        private void payslipRequestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayEmployeeList(_userId, _department, DepartmentName, NameOfCompany, CompanyLogo, CompanyAddress);
            await _parent.DisplayRequests(_department, _userId);
        }
    }
}
