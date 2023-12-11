using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Department_Head_Management.Dashboard.Modals;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Department_Head_Profile_sub_user_control;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Modals;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile
{
    public partial class personalProfileUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string JobDescription { get; set; }
        public string EmailAddress { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string MobileNumber { get; set; }
        public string DepartmentName { get; set; }
        public string AccountStatus { get; set; }
        public string AccessLevel { get; set; }
        public string TelephoneNumber { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string EducationalAttainment { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Course { get; set; }
        public string SalaryRate { get; set; }
        public decimal SalaryValue { get; set; }
        public string PayrollSchedule { get; set; }
        public string EmploymentStatus { get; set; }
        public string DateHired { get; set; }
        public string DateResigned { get; set; }
        public string EmployeeSignature { get; set; }
        public string EmployeeImage { get; set; }
        public string Password { get; set; }

        public personalProfileUC(int userId, departmentHeadDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for retrieving the employee's Benefits
        private async Task<DataTable> GetEmployeeBenefit(int employeeId)
        {
            try
            {
                DataTable benefitList = await generalFunctions.GetEmployeeBenefits(employeeId);

                if (benefitList != null)
                {
                    return benefitList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the benefits contributions list
        private async Task<DataTable> GetBenefitContributions(int employeeId, int benefitsId)
        {
            try
            {
                DataTable contributions = await generalFunctions.GetBenefitRemmitance(employeeId, benefitsId);

                if (contributions != null && contributions.Rows.Count > 0)
                {
                    return contributions;
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
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            generalEmployeeName.DataBindings.Add("Text", this, "EmployeeName");
            emailAddress.DataBindings.Add("Text", this, "EmailAddress");
            generalEmailAddress.DataBindings.Add("Text", this, "EmailAddress");
            barangay.DataBindings.Add("Text", this, "Barangay");
            municipality.DataBindings.Add("Text", this, "Municipality");
            province.DataBindings.Add("Text", this, "Province");
            zipCode.DataBindings.Add("Text", this, "ZipCode");
            mobileNumber.DataBindings.Add("Text", this, "MobileNumber");
            generalMobileNumber.DataBindings.Add("Text", this, "MobileNumber");
            birthday.DataBindings.Add("Text", this, "Birthday");
            gender.DataBindings.Add("Text", this, "Gender");
            civilStatus.DataBindings.Add("Text", this, "CivilStatus");
            accessLevel.DataBindings.Add("Text", this, "AccessLevel");
            generalAccountStatus.DataBindings.Add("Text", this, "AccountStatus");
            educationalAttainment.DataBindings.Add("Text", this, "EducationalAttainment");
            schoolName.DataBindings.Add("Text", this, "SchoolName");
            schoolAddress.DataBindings.Add("Text", this, "SchoolAddress");
            course.DataBindings.Add("Text", this, "Course");
            employeeID.DataBindings.Add("Text", this, "EmployeeID");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            generalDepartmentName.DataBindings.Add("Text", this, "DepartmentName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            generalJobDescription.DataBindings.Add("Text", this, "JobDescription");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            salaryValue.DataBindings.Add("Text", this, "SalaryValue");
            payrollSchedule.DataBindings.Add("Text", this, "PayrollSchedule");
            employmentStatus.DataBindings.Add("Text", this, "EmploymentStatus");
            dateHired.DataBindings.Add("Text", this, "DateHired");
            dateResigned.DataBindings.Add("Text", this, "DateResigned");
            employeePicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");

            DisplayGeneral();
        }

        private void DisplayGeneral()
        {
            generalPanel.Visible = true;
            educationPanel.Visible = false;
            employmentPanel.Visible = false;

            generalBtn.BorderColor = Color.DodgerBlue;
            generalBtn.ForeColor = Color.DodgerBlue;
            educationBtn.BorderColor = Color.Transparent;
            educationBtn.ForeColor = Color.DimGray;
            employmentBtn.BorderColor = Color.Transparent;
            employmentBtn.ForeColor = Color.DimGray;
        }

        private void DisplayEducation()
        {
            generalPanel.Visible = false;
            educationPanel.Visible = true;
            employmentPanel.Visible = false;

            generalBtn.BorderColor = Color.Transparent;
            generalBtn.ForeColor = Color.DimGray;
            educationBtn.BorderColor = Color.DodgerBlue;
            educationBtn.ForeColor = Color.DodgerBlue;
            employmentBtn.BorderColor = Color.Transparent;
            employmentBtn.ForeColor = Color.DimGray;
        }

        private async Task UpdateModal()
        {
            updateModal update = new updateModal(_userId, this);

            update.EmailAddress = EmailAddress;
            update.MobileNumber = MobileNumber;
            update.ZipCode = ZipCode;
            update.Province = Province;
            update.Municipality = Municipality;
            update.Barangay = Barangay;
            update.Gender = Gender;
            update.Password = Password;
            update.ShowDialog();

            await _parent.UserDetails(_userId);
        }

        private async void DisplayEmployment()
        {
            generalPanel.Visible = false;
            educationPanel.Visible = false;
            employmentPanel.Visible = true;

            generalBtn.BorderColor = Color.Transparent;
            generalBtn.ForeColor = Color.DimGray;
            educationBtn.BorderColor = Color.Transparent;
            educationBtn.ForeColor = Color.DimGray;
            employmentBtn.BorderColor = Color.DodgerBlue;
            employmentBtn.ForeColor = Color.DodgerBlue;

            await DisplayBenefits(EmployeeID);
        }

        private async Task DisplayBenefits(int employeeId)
        {
            try
            {
                benefitListPanel.Controls.Clear();
                DataTable benefits = await GetEmployeeBenefit(employeeId);

                if (benefits != null & benefits.Rows.Count > 0)
                {
                    benefitDataUC[] benefitData = new benefitDataUC[benefits.Rows.Count];

                    for (int i = 0; i < benefits.Rows.Count; i++)
                    {
                        benefitData[i] = new benefitDataUC(_userId, this);
                        DataRow row = benefits.Rows[i];

                        if (!string.IsNullOrEmpty(row["detailsId"].ToString()) && int.TryParse(row["detailsId"].ToString(), 
                            out int detailsId))
                        {
                            benefitData[i].BenefitID = detailsId;
                        }
                        else
                        {
                            benefitData[i].BenefitID = 0;
                        }

                        if (!string.IsNullOrEmpty(row["benefits"].ToString()))
                        {
                            benefitData[i].BenefitName = $"{row["benefits"]}";
                        }
                        else
                        {
                            benefitData[i].BenefitName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["benefitsValue"].ToString()) && decimal.TryParse(row["benefitsValue"].ToString(), 
                            out decimal benefitsValue))
                        {
                            benefitData[i].BenefitValue = benefitsValue;
                        }
                        else
                        {
                            benefitData[i].BenefitValue = 0;
                        }

                        if (!string.IsNullOrEmpty(row["benefitStatus"].ToString()))
                        {
                            benefitData[i].BenefitStatus = $"{row["benefitStatus"]}";
                        }
                        else
                        {
                            benefitData[i].BenefitStatus = "--------";
                        }

                        benefitListPanel.Controls.Add(benefitData[i]);
                    }
                }
                else
                {
                    benefitListPanel.Controls.Clear();
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

        private async Task DisplayContributions(int employeeId, int benefitId, decimal TotalValue)
        {
            try
            {
                benefitListPanel.Controls.Clear();
                DataTable contributions = await GetBenefitContributions(employeeId, benefitId);

                if (contributions != null && contributions.Rows.Count > 0)
                {
                    benefitInformationUC[] contributionsList = new benefitInformationUC[contributions.Rows.Count];

                    for (int i = 0; i < contributions.Rows.Count; i++)
                    {
                        contributionsList[i] = new benefitInformationUC(_userId, this);
                        DataRow row = contributions.Rows[i];

                        if (!string.IsNullOrEmpty(row["dateCreated"].ToString()))
                        {
                            DateTime month = DateTime.Parse(row["dateCreated"].ToString());

                            contributionsList[i].Month = month.ToString("MMM, yyyy");
                        }
                        else
                        {
                            contributionsList[i].Month = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["payrollId"].ToString()))
                        {
                            int payrollId = int.Parse(row["payrollId"].ToString());

                            contributionsList[i].PayrollID = payrollId;
                        }
                        else
                        {
                            contributionsList[i].PayrollID = 0;
                        }

                        contributionsList[i].TotalValue = TotalValue;
                        benefitListPanel.Controls.Add(contributionsList[i]);
                    }

                    label22.Visible = true;
                    label24.Visible = true;
                    label26.Visible = true;
                    returnBtn.Visible = true;

                    label48.Visible = false;
                    label47.Visible = false;
                    label46.Visible = false;
                }
                else
                {
                    MessageBox.Show("No Records Found for Contributions Designated to This Specific Benefit", "No Contribution Records",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await DisplayBenefits(employeeId);
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

        // Custom function responsible for showing employee signature
        public void DisplaySignature()
        {
            try
            {
                employeeSignatureModal signatureModal = new employeeSignatureModal(_userId, this);

                signatureModal.EmployeeFullName = EmployeeName;
                signatureModal.EmployeeId = EmployeeID;
                signatureModal.EmployeeSignature = EmployeeSignature;
                signatureModal.ResponseText = EmployeeSignature;
                signatureModal.DateCaptured = DateHired;
                signatureModal.ShowDialog();
            }
            catch (SqlException sql) { ErrorMessage(sql.Message, "Sql Error"); }
            catch (Exception ex) { ErrorMessage(ex.Message, "Error"); }
        }

        // Custom function responsible for displaying an errorr messages when an exception/error is encountered
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Custom function responsible for displaying a success message after every sucessfull transaction
        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task ReturnBehaviour()
        {
            label22.Visible = false;
            label24.Visible = false;
            label26.Visible = false;
            returnBtn.Visible = false;

            label48.Visible = true;
            label47.Visible = true;
            label46.Visible = true;

            await DisplayBenefits(_userId);
        }

        public async Task ContributionsBehaviour(int benefitId, decimal value)
        {
            await DisplayContributions(_userId, benefitId, value);
        }

        private void personalProfileUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void generalBtn_Click(object sender, EventArgs e)
        {
            DisplayGeneral();
        }

        private void educationBtn_Click(object sender, EventArgs e)
        {
            DisplayEducation();
        }

        private void employmentBtn_Click(object sender, EventArgs e)
        {
            DisplayEmployment();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            await UpdateModal();
        }

        private async void returnBtn_Click(object sender, EventArgs e)
        {
            await ReturnBehaviour();
        }

        private void employeeSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplaySignature();
        }
    }
}
