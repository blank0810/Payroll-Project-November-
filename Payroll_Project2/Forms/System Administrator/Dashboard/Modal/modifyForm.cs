using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Dashboard.Modal
{
    public partial class modifyForm : Form
    {
        private static int _userId;
        private static readonly dashboardClass dashboardClass = new dashboardClass();
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly string CompanyLogoPath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");

        public string NameOfCompany { get; set; }
        public string CompanyType { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyFacebook { get; set; }
        public string CompanyFacebookLink { get; set; }
        public string ContactNumber { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }

        public modifyForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<bool> UpdateCompanyDetails(string companyName, string companyType, string companyEmail,
            string facebookName, string facebookLink, string barangay, string municipality, string province,
            string zipCode, string contactNumber, string companyLogo)
        {
            try
            {
                bool update = await dashboardClass.UpdateCompanyDetails(companyName, companyType, companyEmail, facebookName,
                    facebookLink, barangay, municipality, province, zipCode, contactNumber, companyLogo);
                return update;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DefaultValueAssignment()
        {
            ClearValues();
            companyNameBox.Texts = NameOfCompany;
            companyTypeBox.Texts = CompanyType;
            companyLogo.ImageLocation = CompanyLogo;
            companyLogoBox.Texts = CompanyLogo;
            emailAddressBox.Texts = CompanyEmail;
            facebookPageBox.Texts = CompanyFacebook;
            facebookLinkBox.Texts = CompanyFacebookLink;
            contactNumberBox.Texts = ContactNumber;
            barangayBox.Texts = Barangay;
            municipalityBox.Texts = Municipality;
            provinceBox.Texts = Province;
            zipCodeBox.Texts = ZipCode;
        }

        private void ClearValues()
        {
            companyNameBox.Texts = string.Empty;
            companyTypeBox.Texts = string.Empty;
            companyLogo.ImageLocation = string.Empty;
            companyLogoBox.Texts = string.Empty;
            emailAddressBox.Texts = string.Empty;
            facebookPageBox.Texts = string.Empty;
            facebookLinkBox.Texts = string.Empty;
            contactNumberBox.Texts = string.Empty;
            barangayBox.Texts = string.Empty;
            municipalityBox.Texts = string.Empty;
            provinceBox.Texts = string.Empty;
            zipCodeBox.Texts = string.Empty;
        }

        private void modifyForm_Load(object sender, System.EventArgs e)
        {
            DefaultValueAssignment();
        }

        private void barangayBox__TextChanged(object sender, EventArgs e)
        {
            Barangay = barangayBox.Texts;
        }

        private void municipalityBox__TextChanged(object sender, EventArgs e)
        {
            Municipality = municipalityBox.Texts;
        }

        private void provinceBox__TextChanged(object sender, EventArgs e)
        {
            Province = provinceBox.Texts;
        }

        private void zipCodeBox__TextChanged(object sender, EventArgs e)
        {
            ZipCode = zipCodeBox.Texts;
        }

        private void contactNumberBox__TextChanged(object sender, EventArgs e)
        {
            ContactNumber = contactNumberBox.Texts;
        }

        private void emailAddressBox__TextChanged(object sender, EventArgs e)
        {
            CompanyEmail = emailAddressBox.Texts;
        }

        private void facebookPageBox__TextChanged(object sender, EventArgs e)
        {
            CompanyFacebook = facebookPageBox.Texts;
        }

        private void facebookLinkBox__TextChanged(object sender, EventArgs e)
        {
            CompanyFacebookLink = facebookLinkBox.Texts;
        }

        private void companyNameBox__TextChanged(object sender, EventArgs e)
        {
            NameOfCompany = companyNameBox.Texts;
        }

        private void companyTypeBox__TextChanged(object sender, EventArgs e)
        {
            CompanyType = companyTypeBox.Texts;
        }

        private void employeeImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog employeefile = new OpenFileDialog();
            employeefile.Filter = "Image Files (*.jpg; *jpeg; *.png;) | *.jpg; *jpeg; *.png;";
            employeefile.Title = "Select an Image";

            if (employeefile.ShowDialog() == DialogResult.OK)
            {
                companyLogoBox.Texts = employeefile.FileName;
                Bitmap originalImage = new Bitmap(employeefile.FileName);

                float resolution = originalImage.HorizontalResolution;

                int newHeight = 500;
                int newWidth = 500;
                Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
                companyLogo.Image = newImage;
                originalImage.Dispose();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Function responsible for updating the Employee Image
        private void UploadCompanyLogo(string companyName, string logo, string logoPath, string newCompanyLogo)
        {
            newCompanyLogo = $"{companyName.Replace(" ", "")}{Path.GetExtension(logo)}";
            File.Copy(logo, $"{logoPath}{newCompanyLogo}", true);
        }

        private async Task<bool> SubmitInformationUpdate(string companyName, string companyType, string companyEmail,
            string facebookName, string facebookLink, string barangay, string municipality, string province,
            string zipCode, string contactNumber, string companyLogo)
        {
            try
            {
                bool update = await UpdateCompanyDetails(companyName, companyType, companyEmail, facebookName,
                    facebookLink, barangay, municipality, province, zipCode, contactNumber, companyLogo);

                if (update)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error updating the Company's Information. Please contact the IT office for quick " +
                        "resolution!", "Information Update Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UploadCompanyLogo(NameOfCompany, companyLogoBox.Texts, CompanyLogoPath, CompanyLogo);

                bool update = await SubmitInformationUpdate(NameOfCompany, CompanyType, CompanyEmail, CompanyFacebook, CompanyFacebookLink, Barangay, 
                    Municipality, Province, ZipCode, ContactNumber, CompanyLogo);
                if (!update)
                    return;

                SuccessMessages("Company Information Update has been done please review the details at the company profile",
                    "Information Update");
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
