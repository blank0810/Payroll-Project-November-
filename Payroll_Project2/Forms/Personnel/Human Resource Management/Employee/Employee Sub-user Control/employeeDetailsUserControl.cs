using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal;
using Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal_Sub_User_Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control
{
    public partial class employeeDetailsUserControl : UserControl
    {
        #region Private and Public variables

        private static int _userId;
        private static employeeDataUC _parent;
        private static int _year = DateTime.Now.Year;
        private static employeeClass employeeClass = new employeeClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        public int EmployeeId { get; set; }
        public string EmployeeFname { get; set; }
        public string EmployeeLname { get; set; }
        public string EmployeeMname { get; set; }
        public string EmployeeJobDescription { get; set; }
        public string ContactNumber { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string Nationality { get; set; }
        public string Birthday { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeeBarangay { get; set; }
        public string EmployeeMunicipality { get; set; }
        public string EmployeeProvince { get; set; }
        public string EmployeeZipCode { get; set; }
        public string EducationalAttainment { get; set; }
        public string Course { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string EmployeeDateHired { get; set; }
        public string EmployeeEmploymentStatus { get; set; }
        public string EmployeeDateRetired { get; set; }
        public string EmployeeDepartmentName { get; set; }
        public string EmployeeUserRole { get; set; }
        public string EmployeeAccountStatus { get; set; }
        public string EmployeeImage { get; set; }
        public string EmployeeSalaryRate { get; set; }
        public string EmployeeSalaryValue { get; set; }
        public string EmployeeSchedule { get; set; }
        public string EmployeeSignature { get; set; }

        private static string employeeImageDestination = ConfigurationManager.AppSettings["DestinationEmployeeImagePath"];

        #endregion

        public employeeDetailsUserControl(int userId, employeeDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        #region Functions responsible for communicating with the Employee Class

        // Function responsible for retrieving the Leave list
        private async Task<DataTable> GetLeaveList(int employeeId, int year)
        {
            try
            {
                DataTable leaveList = await employeeClass.GetLeaveList(employeeId, year);

                if (leaveList != null && leaveList.Rows.Count > 0)
                {
                    return leaveList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the Travel Order list
        private async Task<DataTable> GetTravelList(int employeeId, int year)
        {
            try
            {
                DataTable traveList = await employeeClass.GetTravelList(employeeId, year);

                if (traveList != null && traveList.Rows.Count > 0)
                {
                    return traveList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; } 
        }

        // Function responsible for retrieving the Pass Slip list
        private async Task<DataTable> GetSlipList(int employeeId, int year)
        {
            try
            {
                DataTable slipList = await employeeClass.GetSlipList(employeeId, year);

                if(slipList != null && slipList.Rows.Count > 0)
                {
                    return slipList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for updating the Employee Image
        private async Task<bool> UploadNewEmployeeImage(int id, string newImage, string oldImage)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();

                if (File.Exists(oldImage))
                {
                    File.Delete(oldImage);
                    string extension = Path.GetExtension(newImage);
                    string newImageName = EmployeeFname.Replace(" ", "") + EmployeeLname + EmployeeMname + extension;
                    string newImageSource = Path.Combine(employeeImageDestination, newImageName);
                    File.Copy(newImage, newImageSource, true);

                    bool updateEmployeePicture = await employeeClass.UpdateEmployeePicture(id, newImageSource);
                    if (updateEmployeePicture)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    string extension = Path.GetExtension(newImage);
                    string newImageName = EmployeeFname.Replace(" ", "") + EmployeeLname + EmployeeMname + extension;
                    string newImageSource = Path.Combine(employeeImageDestination, newImageName);
                    File.Copy(newImage, newImageSource, true);

                    bool updateEmployeePicture = await employeeClass.UpdateEmployeePicture(id, newImageSource);
                    if (updateEmployeePicture)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the employee's Benefits
        private async Task<DataTable> GetEmployeeBenefit(int formId)
        {
            try
            {
                DataTable benefitList = await generalFunctions.GetEmployeeBenefits(formId);
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

        #endregion

        #region Custom Functions for User Interface functionality

        // Custom function that binds the value into the UI controls
        private void DataBinding()
        {
            #region Functions for Databinding the values
            // Bind the labels on your details form to the properties using the "DataBindings" property
            empId.DataBindings.Add("Text", this, "EmployeeId");
            empFirstName.DataBindings.Add("Text", this, "EmployeeFname");
            empLastName.DataBindings.Add("Text", this, "EmployeeLname");
            empMiddleName.DataBindings.Add("Text", this, "EmployeeMname");
            empJobDescription.DataBindings.Add("Text", this, "EmployeeJobDescription");
            contactNumber.DataBindings.Add("Text", this, "ContactNumber");
            sex.DataBindings.Add("Text", this, "Sex");
            civilStatus.DataBindings.Add("Text", this, "CivilStatus");
            nationality.DataBindings.Add("Text", this, "Nationality");
            birthday.DataBindings.Add("Text", this, "Birthday");
            emailAddress.DataBindings.Add("Text", this, "EmailAddress");
            barangay.DataBindings.Add("Text", this, "EmployeeBarangay");
            municipality.DataBindings.Add("Text", this, "EmployeeMunicipality");
            province.DataBindings.Add("Text", this, "EmployeeProvince");
            zipCode.DataBindings.Add("Text", this, "EmployeeZipCode");
            educationalAttainment.DataBindings.Add("Text", this, "EducationalAttainment");
            course.DataBindings.Add("Text", this, "Course");
            schoolName.DataBindings.Add("Text", this, "SchoolName");
            schoolAddress.DataBindings.Add("Text", this, "SchoolAddress");
            empDateHired.DataBindings.Add("Text", this, "EmployeeDateHired");
            empAccountStatus.DataBindings.Add("Text", this, "EmployeeAccountStatus");
            empDateResigned.DataBindings.Add("Text", this, "EmployeeDateRetired");
            empDepartmentName.DataBindings.Add("Text", this, "EmployeeDepartmentName");
            empUserRole.DataBindings.Add("Text", this, "EmployeeUserRole");
            salaryRateDescription.DataBindings.Add("Text", this, "EmployeeSalaryRate");
            salaryRateValue.DataBindings.Add("Text", this, "EmployeeSalaryValue");
            salarySchedule.DataBindings.Add("Text", this, "EmployeeSchedule");
            empEmploymentStatus.DataBindings.Add("Text", this, "EmployeeEmploymentStatus");
            empImage.DataBindings.Add("ImageLocation", this, "EmployeeImage");

            #endregion for the databinding
        }

        // Custom Function responsbile for displaying the Leave List
        public async Task DisplayLeaveList(int employeeId, int userId, int year)
        {
            try
            {
                formContent.Controls.Clear();
                leaveBtn.TextColor = Color.Gray;
                travelBtn.TextColor = Color.DarkGray;
                passBtn.TextColor = Color.DarkGray;
                indicatorPanel.Location = new Point(leaveBtn.Location.X, indicatorPanel.Location.Y);

                leavePanel.Visible = true;
                slipPanel.Visible = false;
                travelPanel.Visible = false;

                formContent.Controls.Add(leavePanel);

                leaveContent.Controls.Clear();
                DataTable leaveList = await GetLeaveList(employeeId, year);

                if (leaveList != null && leaveList.Rows.Count != 0)
                {
                    leaveUC[] leaveUC = new leaveUC[leaveList.Rows.Count];
                    for (int i = 0; i < leaveList.Rows.Count; i++)
                    {
                        DataRow row = leaveList.Rows[i];

                        leaveUC[i] = new leaveUC(this, userId, employeeId);

                        if (int.TryParse(row["applicationNumber"].ToString(), out int number))
                        {
                            leaveUC[i].ApplicationNumber = number;
                        }
                        else
                        {
                            leaveUC[i].ApplicationNumber = 0;
                        }

                        DateTime date = Convert.ToDateTime(row["datefile"]);
                        leaveUC[i].DateSubmitted = date.ToString("MMMM d, yyyy");

                        leaveUC[i].FormStatus = row["statusdescription"].ToString();
                        leaveContent.Controls.Add(leaveUC[i]);
                    }
                }
                else
                {
                    ErrorMessage("No recorded information found for Application for Leave in the database. " +
                        "Please verify and ensure proper data entry. For further assistance, kindly contact the relevant personnel.",
                        "Record Not Found: Application for Leave");
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Error");
            }
        }

        // Custom function responsible for displaying the Travel Order list
        public async Task DisplayTravelList(int employeeId, int userId, int year)
        {
            try
            {
                formContent.Controls.Clear();
                leaveBtn.TextColor = Color.DarkGray;
                travelBtn.TextColor = Color.Gray;
                passBtn.TextColor = Color.DarkGray;
                indicatorPanel.Location = new Point(travelBtn.Location.X, indicatorPanel.Location.Y);

                leavePanel.Visible = false;
                slipPanel.Visible = false;
                travelPanel.Visible = true;

                formContent.Controls.Add(travelPanel);

                travelContent.Controls.Clear();
                DataTable getTravelList = await GetTravelList(employeeId, year);

                if (getTravelList != null && getTravelList.Rows.Count != 0)
                {
                    travelOrderUC[] travelOrderUC = new travelOrderUC[getTravelList.Rows.Count];

                    for (int i = 0; i < getTravelList.Rows.Count; i++)
                    {
                        DataRow row = getTravelList.Rows[i];
                        travelOrderUC[i] = new travelOrderUC(this, userId, employeeId);

                        if (int.TryParse(row["orderControlNumber"].ToString(), out int number))
                        {
                            travelOrderUC[i].ControlNumber = number;
                        }

                        DateTime date = Convert.ToDateTime(row["datefiled"]);
                        travelOrderUC[i].DateSubmitted = date.ToString("MMMM dd, yyyy");

                        travelOrderUC[i].FormStatus = row["statusdescription"].ToString();
                        travelContent.Controls.Add(travelOrderUC[i]);
                    }
                }
                else
                {
                    ErrorMessage("Sorry, no recorded information for Travel Order was found in the database. " +
                        "Please ensure that the necessary details have been properly entered. If you require further assistance, " +
                        "kindly contact the relevant personnel.", "Travel Order not found");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Custom function responsible for displaying the Pass Slip list
        public async Task DisplaySlipList(int employeeId, int userId, int year)
        {
            try
            {
                formContent.Controls.Clear();
                leaveBtn.TextColor = Color.DarkGray;
                travelBtn.TextColor = Color.DarkGray;
                passBtn.TextColor = Color.Gray;
                indicatorPanel.Location = new Point(passBtn.Location.X, indicatorPanel.Location.Y);

                leavePanel.Visible = false;
                slipPanel.Visible = true;
                travelPanel.Visible = false;

                formContent.Controls.Add(slipPanel);

                slipContent.Controls.Clear();
                DataTable getSlipList = await GetSlipList(employeeId, year);

                if (getSlipList != null && getSlipList.Rows.Count != 0)
                {
                    passSlipUC[] passSlipUC = new passSlipUC[getSlipList.Rows.Count];

                    for (int i = 0; i < getSlipList.Rows.Count; i++)
                    {
                        DataRow row = getSlipList.Rows[i];
                        passSlipUC[i] = new passSlipUC(this, userId, employeeId);

                        if (int.TryParse(row["slipControlNumber"].ToString(), out int number))
                        {
                            passSlipUC[i].ControlNumber = number;
                        }

                        DateTime date = Convert.ToDateTime(row["datefile"]);
                        passSlipUC[i].DateSubmitted = date.ToString("MMMM d, yyyy");

                        passSlipUC[i].FormStatus = row["statusDescription"].ToString();

                        slipContent.Controls.Add(passSlipUC[i]);
                    }
                }
                else
                {
                    ErrorMessage("Sorry, no recorded information for Pass Slip was found in the database. Please ensure that the necessary " +
                        "details have been properly entered. If you require further assistance, kindly contact the relevant personnel.",
                        "Pass Slip Not Found");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Custom function responsible for displaying the General Information
        private void DisplayGeneralInformation()
        {
            content.Controls.Clear();
            generalBtn.BackColor = Color.DodgerBlue;
            generalBtn.TextColor = Color.White;
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            formsBtn.BackColor = Color.White;
            formsBtn.TextColor = Color.DodgerBlue;

            generalPanel.Visible = true;
            employmentPanel.Visible = false;
            formPanel.Visible = false;

            content.Controls.Add(generalPanel);
        }

        // Custom function responsible for displaying the Employment Information
        private void DisplayEmploymentInformation()
        {
            content.Controls.Clear();

            generalBtn.BackColor = Color.White;
            generalBtn.TextColor = Color.DodgerBlue;
            employmentBtn.BackColor = Color.DodgerBlue;
            employmentBtn.TextColor = Color.White;
            formsBtn.BackColor = Color.White;
            formsBtn.TextColor = Color.DodgerBlue;

            generalPanel.Visible = false;
            employmentPanel.Visible = true;
            formPanel.Visible = false;

            content.Controls.Add(employmentPanel);
        }

        // Custom function responsible for displaying the Form Logs
        private async Task DisplayFormLogs()
        {
            content.Controls.Clear();

            generalBtn.BackColor = Color.White;
            generalBtn.TextColor = Color.DodgerBlue;
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            formsBtn.BackColor = Color.DodgerBlue;
            formsBtn.TextColor = Color.White;

            generalPanel.Visible = false;
            employmentPanel.Visible = false;
            formPanel.Visible = true;

            content.Controls.Add(formPanel);
            await DisplayLeaveList(EmployeeId, _userId, _year);
        }

        // Custom function responsible for displaying the Employee Benefits
        public async Task DisplayBenefit()
        {
            try
            {
                benefitsContent.Controls.Clear();

                DataTable benefitList = await GetEmployeeBenefit(EmployeeId);

                if (benefitList != null && benefitList.Rows.Count > 0)
                {
                    for (int i = 0; i < benefitList.Rows.Count; i++)
                    {
                        benefitsDetailsUC[] details = new benefitsDetailsUC[benefitList.Rows.Count];
                        DataRow row = benefitList.Rows[i];
                        details[i] = new benefitsDetailsUC(this, _userId);

                        if (int.TryParse(row["detailsId"].ToString(), out int id))
                        {
                            details[i].DetailsId = id;
                        }
                        else
                        {
                            details[i].DetailsId = 0;
                        }

                        if (row["benefits"] != null)
                        {
                            details[i].BenefitName = row["benefits"].ToString();
                        }
                        else
                        {
                            details[i].BenefitName = "Not Set";
                        }

                        if (row["benefitStatus"] != null)
                        {
                            details[i].BenefitStatus = row["benefitStatus"].ToString();
                        }
                        else
                        {
                            details[i].BenefitStatus = "Not Set";
                        }

                        if (row["benefitsValue"] != null && decimal.TryParse(row["benefitsValue"].ToString(), out decimal value))
                        {
                            details[i].BenefitValue = value;
                        }
                        else
                        {
                            details[i].BenefitValue = 0;
                        }
                        benefitsContent.Controls.Add(details[i]);
                    }
                }
                else
                {
                    ErrorMessage("No benefits have been designated for the employee. Please ensure that at least one benefit is " +
                    "assigned to the employee before proceeding.", "No Designated Benefits");
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "Sql Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        // Custom function responsible for showing employee signature
        public void DisplaySignature()
        {
            try
            {
                employeeSignatureModal signatureModal = new employeeSignatureModal(_userId, this);

                signatureModal.EmployeeFullName = $"{EmployeeFname} {EmployeeLname}";
                signatureModal.EmployeeId = EmployeeId;
                signatureModal.EmployeeSignature = EmployeeSignature;
                signatureModal.ResponseText = EmployeeSignature;
                signatureModal.DateCaptured = EmployeeDateHired;
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

        #endregion

        #region Event Handlers that handles User Interfaces behaviours

        // Event handler that handles if this user control is loaded into the system
        private void employeeDetailsUserControl_Load(object sender, EventArgs e)
        {
            DataBinding();
            DisplayGeneralInformation();
        }

        // Event handler that handles if the general button is clicked
        private void generalBtn_Click(object sender, EventArgs e)
        {
            DisplayGeneralInformation();
        }

        // Event handler that handles if the employment button is clicked
        private async void employmentBtn_Click(object sender, EventArgs e)
        {
            DisplayEmploymentInformation();
            await DisplayBenefit();
        }

        // Event handler that handles if the form logs button is clicked
        private async void formsBtn_Click(object sender, EventArgs e)
        {
            await DisplayFormLogs();
        }

        // Event handler that handles if the leave button is clicked inside the form logs
        private async void leaveBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeaveList(EmployeeId, _userId, _year);
        }

        // Event handler that handles if the Travel Order button is clicked inside the form logs
        private async void travelBtn_Click(object sender, EventArgs e)
        {
            await DisplayTravelList(EmployeeId, _userId, _year);
        }

        // Event handler that handles if the Pass Slip button is clicked inside the form logs
        private async void passBtn_Click(object sender, EventArgs e)
        {
            await DisplaySlipList(EmployeeId, _userId, _year);
        }

        // Event handler that handles if the upload button
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
                    bool uploadNewEmployeeImage = await UploadNewEmployeeImage(EmployeeId, newImage, EmployeeImage);

                    if (uploadNewEmployeeImage)
                    {
                        await _parent.EmployeeDetails(EmployeeId);
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "Sql Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        // Event handler that handles if the add benefit button is clicked
        private async void addBtn_Click(object sender, EventArgs e)
        {
            addBenefitModal addBenefitModal = new addBenefitModal(_userId, this);
            addBenefitModal.EmployeeID = EmployeeId;
            addBenefitModal.ShowDialog();
            await DisplayBenefit();
        }

        private void employeeSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplaySignature();
        }

        #endregion
    }
}
