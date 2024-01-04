using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using Payroll_Project2.Forms.System_Administrator.Benefits_and_Deduction_Management;
using Payroll_Project2.Forms.System_Administrator.Dashboard.Modal;
using Payroll_Project2.Forms.System_Administrator.Department_Management;
using Payroll_Project2.Forms.System_Administrator.Employee_Management;
using Payroll_Project2.Forms.System_Administrator.Log_Management;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

                        if (!string.IsNullOrEmpty(row["companyType"]?.ToString()))
                        {
                            CompanyType = $"{row["companyType"]}";
                        }
                        else
                        {
                            CompanyType = "Not Available";
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

        private void ForwardDetails(string companyName, string companyType, string companyEmail,
            string facebookName, string facebookLink, string barangay, string municipality, string province,
            string zipCode, string contactNumber, string companyLogo)
        {
            modifyForm modify = new modifyForm(_userId);

            modify.NameOfCompany = companyName;
            modify.CompanyType = companyType;
            modify.CompanyEmail = companyEmail;
            modify.CompanyLogo = companyLogo;
            modify.CompanyFacebook = facebookName;
            modify.CompanyFacebookLink = facebookLink;
            modify.Barangay = barangay;
            modify.Municipality = municipality;
            modify.Province = province;
            modify.ZipCode = zipCode;
            modify.ContactNumber = contactNumber;

            modify.ShowDialog();
        }

        // Function responsible for updating the Employee Image
        private async Task<bool> UploadNewCompanyLogo(string newImage, string oldImage)
        {
            try
            {

                string extension = Path.GetExtension(newImage);
                string newImageName = NameOfCompany.Replace(" ", "") + extension;
                string newImageSource = Path.Combine(CompanyLogoPath, newImageName);
                File.Copy(newImage, newImageSource, true);

                bool updateCompanyLogo = await dashboardClass.UpdateCompanyLogo(newImageName);
                if (updateCompanyLogo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex)
            {
                throw ex;
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
            DataBinding();
            if (!contentPanel.Controls.Contains(dashboardPanel))
            {
                contentPanel.Controls.Add(dashboardPanel);
                dashboardPanel.Dock = DockStyle.Fill;
                dashboardPanel.BringToFront();
            }
            else
            {
                dashboardPanel.BringToFront();
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            ForwardDetails(NameOfCompany, CompanyType, CompanyEmail, CompanyFacebook, CompanyFacebookLink, Barangay,
                Municipality, Province, ZipCode, ContactNumber, CompanyLogo);
            DataBinding();
        }

        private async void uploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string newImage;

                OpenFileDialog employeefile = new OpenFileDialog();
                employeefile.Filter = "Image Files (*.jpg; *jpeg; *.png;) | *.jpg; *jpeg; *.png;";
                employeefile.Title = "Select an Image";

                if (employeefile.ShowDialog() == DialogResult.OK)
                {
                    newImage = employeefile.FileName;
                    bool uploadNewEmployeeImage = await UploadNewCompanyLogo(newImage, $"{CompanyLogoPath}{CompanyLogo}");

                    if (uploadNewEmployeeImage)
                    {
                        DataBinding();
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "Sql Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private void companyEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string gmailUrl = $"https://mail.google.com/mail/u/0/?view=cm&fs=1&to={CompanyEmail}";

                System.Diagnostics.Process.Start(gmailUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void companyFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string fbUrl = $"{CompanyFacebookLink}";

                System.Diagnostics.Process.Start(fbUrl);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void departmentManagementBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = departmentManagementBtn.Text;
            departmentManagementUC departmentManagementUC = new departmentManagementUC(_userId);

            if(!contentPanel.Controls.Contains(departmentManagementUC))
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

        private void benefitBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = benefitBtn.Text;
            benefitAndDeductionUC benefitAndDeductionUC = new benefitAndDeductionUC(_userId);

            if (!contentPanel.Controls.Contains(benefitAndDeductionUC))
            {
                contentPanel.Controls.Add(benefitAndDeductionUC);
                benefitAndDeductionUC.Dock = DockStyle.Fill;
                benefitAndDeductionUC.BringToFront();
            }
            else
            {
                benefitAndDeductionUC.BringToFront();
            }
        }

        private void personnelAppointment_Click(object sender, EventArgs e)
        {
            titleLabel.Text = personnelAppointment.Text;
            appointmentListUC appointmentListUC = new appointmentListUC(_userId);
            appointmentListUC.DefaultRole = "Personnel";

            if(!contentPanel.Controls.Contains(appointmentListUC))
            {
                contentPanel.Controls.Add(appointmentListUC);
                appointmentListUC.Dock = DockStyle.Fill;
                appointmentListUC.BringToFront();
            }
            else
            {
                appointmentListUC.BringToFront();
            }
        }

        private void buttonDesign1_Click(object sender, EventArgs e)
        {

        }

        private void mayorAppointment_Click(object sender, EventArgs e)
        {
            titleLabel.Text = mayorAppointment.Text;
            appointmentListUC appointmentListUC = new appointmentListUC(_userId);
            appointmentListUC.DefaultRole = "Mayor";

            if (!contentPanel.Controls.Contains(appointmentListUC))
            {
                contentPanel.Controls.Add(appointmentListUC);
                appointmentListUC.Dock = DockStyle.Fill;
                appointmentListUC.BringToFront();
            }
            else
            {
                appointmentListUC.BringToFront();
            }
        }

        private void systemLogBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = systemLogBtn.Text;
            systemLogManagementUC systemLogManagementUC = new systemLogManagementUC(_userId);

            if(!contentPanel.Controls.Contains(systemLogManagementUC))
            {
                contentPanel.Controls.Add(systemLogManagementUC);
                systemLogManagementUC.Dock = DockStyle.Fill;
                systemLogManagementUC.BringToFront();
            }
            else
            {
                systemLogManagementUC.BringToFront();
            }
        }
    }
}
