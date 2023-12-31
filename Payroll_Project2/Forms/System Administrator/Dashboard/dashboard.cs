using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.System_Administrator.Dashboard.Modal;
using Payroll_Project2.Forms.System_Administrator.Department_Management;
using Payroll_Project2.Forms.System_Administrator.Employee_Management;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Dashboard
{
    public partial class systemAdminDashboard : Form
    {
        private static int _userId;
        private static readonly dashboardClass dashboardClass = new dashboardClass();
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string CompanyLogoPath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");
        private static readonly string DefaultLogo = ConfigurationManager.AppSettings.Get("DefaultLogo");

        public string NameOfCompany { get; set; }
        public string CompanyType { get; set; }
        public int EmployeeCount { get; set; }
        public int DepartmentCount { get; set; }
        public string CompanyLogo { get; set; }
        public string MayorName { get; set; }
        public string ViceMayorName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyFacebook { get; set; }
        public string CompanyFacebookLink { get; set; }
        public string ContactNumber { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }

        public systemAdminDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<int> GetDepartmentCount()
        {
            try
            {
                int count = await generalFunctions.GetNumberOfDepartment();
                
                if (count > 0)
                {
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetEmployeeCount()
        {
            try
            {
                int count = await generalFunctions.GetNumberOfEmployee();

                if (count > 0)
                {
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetMayorName()
        {
            try
            {
                string name = await dashboardClass.GetMayorName();
                return name;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetViceMayorName()
        {
            try
            {
                string name = await dashboardClass.GetViceMayorName();
                return name;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetCompanyDetails()
        {
            try
            {
                DataTable details = await dashboardClass.GetCompanyDetails();

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

        private async Task ParsedDetails()
        {
            try
            {
                DataTable details = await GetCompanyDetails();
                string mayorName = await GetMayorName();
                string viceMayorName = await GetViceMayorName();
                int employeeCount = await GetEmployeeCount();
                int departmentCount = await GetDepartmentCount();

                if (details != null)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        if (!string.IsNullOrEmpty(mayorName))
                        {
                            MayorName = mayorName;
                        }
                        else
                        {
                            MayorName = $"Not Available";
                        }

                        if(!string.IsNullOrEmpty(viceMayorName))
                        {
                            ViceMayorName = viceMayorName;
                        }
                        else
                        {
                            ViceMayorName = "Not Available";
                        }

                        if (employeeCount > 0)
                        {
                            EmployeeCount = employeeCount;
                        }
                        else
                        {
                            EmployeeCount = 0;
                        }

                        if (departmentCount > 0)
                        {
                            DepartmentCount = departmentCount;
                        }
                        else
                        {
                            DepartmentCount = 0;
                        }

                        if (!string.IsNullOrEmpty(row["companyName"]?.ToString()))
                        {
                            NameOfCompany = $"{row["companyName"]}";
                        }
                        else
                        {
                            NameOfCompany = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["companyEmail"]?.ToString()))
                        {
                            CompanyEmail = $"{row["companyEmail"]}";
                        }
                        else
                        {
                            CompanyEmail = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["companyEmail"]?.ToString()))
                        {
                            CompanyEmail = $"{row["companyEmail"]}";
                        }
                        else
                        {
                            CompanyEmail = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["companyFacebookName"]?.ToString()))
                        {
                            CompanyFacebook = $"{row["companyFacebookName"]}";
                        }
                        else
                        {
                            CompanyFacebook = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["companyFacebookLink"]?.ToString()))
                        {
                            CompanyFacebookLink = $"{row["companyFacebookLink"]}";
                        }
                        else
                        {
                            CompanyFacebookLink = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["contactNumber"]?.ToString()))
                        {
                            ContactNumber = $"{row["contactNumber"]}";
                        }
                        else
                        {
                            ContactNumber = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["barangay"]?.ToString()))
                        {
                            Barangay = $"{row["barangay"]}";
                        }
                        else
                        {
                            Barangay = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["municipality"]?.ToString()))
                        {
                            Municipality = $"{row["municipality"]}";
                        }
                        else
                        {
                            Municipality = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["province"]?.ToString()))
                        {
                            Province = $"{row["province"]}";
                        }
                        else
                        {
                            Province = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["zipCode"]?.ToString()))
                        {
                            ZipCode = $"{row["zipCode"]}";
                        }
                        else
                        {
                            ZipCode = "Not Available";
                        }

                        if (!string.IsNullOrEmpty(row["companyLogo"]?.ToString()))
                        {
                            CompanyLogo = $"{CompanyLogoPath}{row["companyLogo"]}";
                        }
                        else
                        {
                            CompanyLogo = DefaultLogo;
                        }
                    }

                    DataBinding();
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

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ClearBinding()
        {
            companyName.DataBindings.Clear();
            companyType.DataBindings.Clear();
            employeeCount.DataBindings.Clear();
            departmentCount.DataBindings.Clear();
            mayorName.DataBindings.Clear();
            viceMayorName.DataBindings.Clear();
            companyEmail.DataBindings.Clear();
            companyFacebook.DataBindings.Clear();
            contactNumber.DataBindings.Clear();
            barangay.DataBindings.Clear();
            municipality.DataBindings.Clear();
            province.DataBindings.Clear();
            zipCode.DataBindings.Clear();
            companyLogo.DataBindings.Clear();
        }

        private void DataBinding()
        {
            ClearBinding();
            companyName.DataBindings.Add("Text", this, "NameOfCompany");
            companyType.DataBindings.Add("Text", this, "CompanyType");
            employeeCount.DataBindings.Add("Text", this, "EmployeeCount");
            departmentCount.DataBindings.Add("Text", this, "DepartmentCount");
            mayorName.DataBindings.Add("Text", this, "MayorName");
            viceMayorName.DataBindings.Add("Text", this, "ViceMayorName");
            companyEmail.DataBindings.Add("Text", this, "CompanyEmail");
            companyFacebook.DataBindings.Add("Text", this, "CompanyFacebook");
            contactNumber.DataBindings.Add("Text", this, "ContactNumber");
            barangay.DataBindings.Add("Text", this, "Barangay");
            municipality.DataBindings.Add("Text", this, "Municipality");
            province.DataBindings.Add("Text", this, "Province");
            zipCode.DataBindings.Add("Text", this, "ZipCode");
            companyLogo.DataBindings.Add("ImageLocation", this, "CompanyLogo");
        }

        private async void systemAdminDashboard_Load(object sender, EventArgs e)
        {
            await ParsedDetails();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {

        }

        private void departmentBtn_Click(object sender, EventArgs e)
        {
            
            departmentManagementUC departmentManagementUC = new departmentManagementUC();

            if (!contentPanel.Controls.Contains(departmentManagementUC))
            {
                contentPanel.Controls.Add(departmentManagementUC);
                departmentManagementUC.Dock = DockStyle.Fill;
                departmentManagementUC.BringToFront();
            }
            else
            {
                departmentManagementUC.BringToFront();
            }
        }

        private void employeeManagementBtn_Click(object sender, EventArgs e)
        {

        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            modifyForm modify = new modifyForm();
            modify.ShowDialog();
        }

        private void employeeListBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            
            employeeListUC employeeListUC = new employeeListUC();

            if (!contentPanel.Controls.Contains(employeeListUC))
            {
                contentPanel.Controls.Add(employeeListUC);
                employeeListUC.Dock = DockStyle.Fill;
                employeeListUC.BringToFront();
            }
            else
            {
                employeeListUC.BringToFront();
            }
        }

        private void appointmentBtn_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            
            appointmentUC appointmentUC = new appointmentUC();

            if (!contentPanel.Controls.Contains(appointmentUC))
            {
                contentPanel.Controls.Add(appointmentUC);
                appointmentUC.Dock = DockStyle.Fill;
                appointmentUC.BringToFront();
            }
            else
            {
                appointmentUC.BringToFront();
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
