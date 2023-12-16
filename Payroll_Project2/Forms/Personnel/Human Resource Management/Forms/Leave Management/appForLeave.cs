using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents.Modal;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents
{
    public partial class appForLeave : UserControl
    {
        #region The variables below is the variables needed for the User Control

        private static int _userId;
        private static newDashboard _parent;
        private static int _year = DateTime.Now.Year;
        private static personnelPassSlipUC passSlipUC;
        private static travelOrder travelOrder;
        private static readonly string formTitle = ConfigurationManager.AppSettings["DefaultLeaveTitle"];
        private static readonly string statusDescription = "Pending";
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static employeeClass employeeClass = new employeeClass();

        public int ApplicationNumber { get; set; }
        public string PersonnelDepartment { get; set; }
        private int EmployeeID { get; set; }
        public string MayorName { get; set; }
        public string PersonnelName { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string MiddleName { get; set; }
        private string DepartmentHead { get; set; }
        private string Department { get; set; }
        public DateTime DateFiled { get; set; }
        private string SalaryRate { get; set; }
        private string JobDescription { get; set; }
        private string LeaveType { get; set; }
        private string LeaveDetails { get; set; }
        private static bool IsRecommended { get; set; }
        private static bool IsCertified { get; set; }
        public DateTime CertifiedDate { get; set; }
        private string CertifiedBy { get; set; }
        private decimal VacationLeaveCreditsNumber { get; set; }
        private decimal SickLeaveCreditsNumber { get; set; }
        private int NumberOfDaysLeave { get; set; }
        private decimal CreditsUsed { get; set; }
        private DateTime StartingLeaveDate { get; set; }
        private DateTime EndingLeaveDate { get; set; }

        #endregion

        public appForLeave(newDashboard parent, int userId)
        {
            InitializeComponent();
            _parent = parent;
            _userId = userId;
        }

        #region Functions inside is the one responsible for communicating with the formClass and also the one who forwards the value retrieved from the formClass into User Interface

        // This function will retrieve and forward the value from the formClass
        // The value inside is the one who will determine if the employee does have a pending request or not
        private async Task<bool> GetLeavePending(int employeeId, string status)
        {
            try
            {
                formClass = new formClass();
                bool count = await generalFunctions.GetLeavePendingCount(employeeId, status);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving the indicator if the leave request is being submitted or not
        // By forwarding true or false
        private async Task<bool> AddNewLeave(int applicationNumber, int employeeId, DateTime dateFile, string leaveType, string formType,
            string leaveDetails, bool isRecommended, string recommendedBy, DateTime dateRecommended,
            bool isCertified, string certifiedBy, DateTime certificationDate, string statusDescription, DateTime leaveStartDate,
            DateTime leaveEndDate, int numberOfDays, decimal creditsUsed)
        {
            try
            {
                formClass = new formClass();
                bool addNewLeave = await formClass.AddLeave(applicationNumber, employeeId, dateFile, leaveType, formType, leaveDetails, 
                    isRecommended, recommendedBy, dateRecommended, isCertified, certifiedBy, certificationDate, statusDescription, 
                    leaveStartDate, leaveEndDate, numberOfDays, creditsUsed);

                if (addNewLeave)
                {
                    return addNewLeave;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible as an indicator if the logs is being added or not
        // It will forward true or false
        private async Task<bool> AddLeaveFormLog(DateTime logDate, string logDescription, int applicationNumber, string caption)
        {
            try
            {
                formClass = new formClass();
                bool addNewLeaveFormLog = await generalFunctions.AddLeaveFormLog(logDate, logDescription, applicationNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible as an indicator if the logs is being added or not
        // It will forward true or false
        private async Task<bool> AddSystemLogs(DateTime logdate, string logdescription, string caption)
        {
            try
            {
                formClass = new formClass();
                bool addSystemLogs = await generalFunctions.AddSystemLogs(logdate, logdescription, caption);

                return addSystemLogs;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving the employee's leave credits
        private async Task<decimal> GetLeaveCredits(int employeeId, string leaveType)
        {
            try
            {
                decimal numberOfCredits = await generalFunctions.GetEmployeeLeaveCredits(employeeId, leaveType);
                return numberOfCredits;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<decimal> CheckLeaveCredits(int employeeId, string leaveType, int year)
        {
            try
            {
                decimal getLeaveCredits = await generalFunctions.GetLeaveCredits(employeeId, leaveType, year);

                return getLeaveCredits;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddleaveRequest(int applicationNumber, int employeeId, DateTime dateFile, string leaveType, string formType,
            string leaveDetails, int numberOfDays, DateTime leaveStartDate, DateTime leaveEndDate, decimal creditsUsed, string status)
        {
            try
            {
                bool addLeave = await generalFunctions.AddLeaveRequest(applicationNumber, employeeId, dateFile, leaveType, formType, leaveDetails,
                    numberOfDays, leaveStartDate, leaveEndDate, creditsUsed, status);

                if (addLeave)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region The functions inside is the one responsible for Dynamic behaviours of the User Interface

        private async void DataBinding()
        {
            try
            {
                formClass = new formClass();
                DataTable leaveTypes = await generalFunctions.GetLeaveTypes();

                typeOfLeave.AutoCompleteMode = AutoCompleteMode.Suggest;
                typeOfLeave.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection leaveTypeCollection = new AutoCompleteStringCollection();

                foreach(DataRow row in leaveTypes.Rows)
                {
                    leaveTypeCollection.Add(row["leavetype"].ToString());
                }

                typeOfLeave.DataSource = leaveTypeCollection;
                typeOfLeave.SelectedIndex = -1;

                startingDate.Value = DateTime.Today;
                endingDate.Value = DateTime.Today;
                personnel.DataBindings.Add("Text", this, "PersonnelName");
                applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
                dateFiled.DataBindings.Add("Value", this, "DateFiled");
                dateCertified.DataBindings.Add("Value", this, "CertifiedDate");
                CenterPersonnel();
            }
            catch(SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = departmentName.Left + (departmentName.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        private void CenterPersonnel()
        {
            // Calculate the center positions of departmentName label
            int personnelX = jobDescOfPersonnel.Left + (jobDescOfPersonnel.Width - personnel.Width) / 2;
            personnel.Location = new Point(personnelX, personnel.Top);


            // Set the new position for departmentHead label
            personnel.Location = new Point(personnelX, personnel.Location.Y);
        }

        public bool PanelContent()
        {
            if(_parent.Controls.ContainsKey("mainPanel"))
            {
                Panel parentMainPanel = _parent.Controls["mainPanel"] as Panel;
                
                if (parentMainPanel.Controls.ContainsKey("contentPanel"))
                {
                    Panel panel = parentMainPanel.Controls["contentPanel"] as Panel;

                    if (panel.Controls.Contains(this))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async void EmployeeDetails(int employeeID, string fname, string lname, string mname, string department, string salaryDescription, string jobDescription, string departmenthead)    
        {
            firstNameTextBox.Texts = fname;
            lastNameTextBox.Texts = lname;
            middleName.Texts = mname;
            dateFiled.Value = DateTime.Now;
            salaryBox.Texts = salaryDescription;
            departmentBox.Texts = department;
            departmentName.Text = department;
            descriptionBox.Texts = jobDescription;
            EmployeeID = employeeID;
            await InputLeaveCredits(EmployeeID);

            if (Department == PersonnelDepartment)
            {
                departmentHead.Text = PersonnelName;
            }
            else
            {
                departmentHead.Text = departmenthead;
            }

            CenterDepartmentHead();
        }

        public async Task InputLeaveCredits(int employeeId)
        {
            try
            {
                foreach (var item in typeOfLeave.Items)
                {
                    string currentItem = item.ToString();
                    decimal numberOfCredits = await GetLeaveCredits(employeeId, currentItem);
                    MessageBox.Show($"{currentItem} {numberOfCredits}");

                    if (currentItem == "Vacation Leave")
                    {
                        vacationLeaveCredits.Text = $"{numberOfCredits}";;
                    }
                    else
                    {
                        sickLeaveCredits.Text = $"{numberOfCredits}";
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Exception");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        public void ShowModal()
        {
            passSlipUC = new personnelPassSlipUC(_parent, _userId);
            travelOrder = new travelOrder(_parent, _userId);
            employeeList employeeList = new employeeList(this, passSlipUC, travelOrder);
            employeeList.ShowDialog();
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            ShowModal();
        }

        private void appForLeave_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void firstNameTextBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Texts))
            {
                ShowModal();
            }
        }

        private void lastNameTextBox_Click(object sender, EventArgs e)
        {
            ShowModal();
        }

        private void middleName_Click(object sender, EventArgs e)
        {
            ShowModal();
        }

        private void departmentHead_TextChanged(object sender, EventArgs e)
        {
            if (Department == "Human Resources Office")
            {
                departmentHead.Text = personnel.Text;
                DepartmentHead = departmentHead.Text;
            }
            else
            {
                DepartmentHead = departmentHead.Text;
            }
        }

        private void firstNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Texts))
            {
                FirstName = firstNameTextBox.Texts;
            }
        }

        private void lastNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(middleName.Texts))
            {
                LastName = middleName.Texts;
            }
        }

        private void middleName__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(middleName.Texts))
            {
                MiddleName = middleName.Texts;
            }
        }

        private void departmentBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(departmentBox.Texts))
            {
                Department = departmentBox.Texts;
                if (Department == "Human Resources Office")
                {
                    departmentHead.Text = personnel.Text;
                    CenterDepartmentHead();
                }
            }
        }

        private void dateFiled_ValueChanged(object sender, EventArgs e)
        {
            if (dateFiled.Value == DateTime.Now)
            {
                DateFiled = dateFiled.Value;
            }
            else
            {
                DateFiled = dateFiled.Value;
            }
        }

        private void salaryBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(salaryBox.Texts))
            {
                SalaryRate = salaryBox.Texts;
            }
        }

        private void descriptionBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty (descriptionBox.Texts))
            {
                JobDescription = descriptionBox.Texts;
            }
        }

        private void typeOfLeave_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(typeOfLeave.Text) || typeOfLeave.Text != "Select")
            {
                LeaveType = typeOfLeave.Text;
            }
        }

        private void leaveDetails__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(leaveDetails.Texts))
            {
                System.Windows.Forms.TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                LeaveDetails = capitalizedText;
            }
        }

        private void approveBtn_CheckedChanged(object sender, EventArgs e)
        {
            if(approveBtn.Checked && Department == PersonnelDepartment && !string.IsNullOrEmpty(Department))
            {
                SuccessMessage($"Note: Since the employee is from {Department} the Human Resource Officer is allowed to put a recommendation",
                    "Leave Recommendation");
                IsRecommended = true;
            }
            else if (approveBtn.Checked && Department != PersonnelDepartment && !string.IsNullOrEmpty(Department))
            {
                ErrorMessages($"Note: The designated department head only of {Department} is allowed to put a recommendation of the leave " +
                    $"request", "Restricted Actions");
                approveBtn.Checked = false;
            }
        }

        private void disapproveBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (disapproveBtn.Checked && Department == PersonnelDepartment && !string.IsNullOrEmpty(Department))
            {
                SuccessMessage($"Note: Since the employee is from {Department} the Human Resource Officer is allowed to put a recommendation",
                    "Leave Recommendation");
                IsRecommended = false;
            }
            else if (disapproveBtn.Checked && Department != PersonnelDepartment && !string.IsNullOrEmpty(Department))
            {
                ErrorMessages($"Note: The designated department head only of {Department} is allowed to put a recommendation of the leave " +
                    $"request", "Restricted Actions");
                disapproveBtn.Checked = false;
            }
        }

        private void dateCertified_ValueChanged(object sender, EventArgs e)
        {
            if(dateCertified.Value == DateTime.Now)
            {
                CertifiedDate = dateCertified.Value;
            }
        }

        private void personnel_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(personnel.Text))
            {
                CertifiedBy = personnel.Text;
            }
        }

        private void humanResourceCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (humanResourceCheck.Checked)
            {
                IsCertified = true;
            }
            else
            {
                IsCertified = false;
            }
        }

        private void sickLeaveCredits_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(sickLeaveCredits.Text, out decimal sickLeave))
            {
                SickLeaveCreditsNumber = sickLeave;
            }
        }

        private void vacationLeaveCredits_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(vacationLeaveCredits.Text, out decimal vacationLeave))
            {
                VacationLeaveCreditsNumber = vacationLeave;
            }
        }

        private void startingDate_ValueChanged(object sender, EventArgs e)
        {
            if (startingDate.Value > DateTime.Today)
            {
                StartingLeaveDate = startingDate.Value;
            }
        }

        private void endingDate_ValueChanged(object sender, EventArgs e)
        {
            if (endingDate.Value > startingDate.Value)
            {
                CalculateNumberOfDays(startingDate.Value, endingDate.Value);
                EndingLeaveDate = endingDate.Value;
            }
        }

        private void sickLeaveDeduct_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(sickLeaveDeduct.Text, out decimal sickLeaveDeduction) && sickLeaveDeduct.Text != "0")
            {
                CreditsUsed = sickLeaveDeduction;
            }
        }

        private void vacationLeaveDeduct_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(vacationLeaveDeduct.Text, out decimal vacationLeave) && vacationLeaveDeduct.Text != "0")
            {
                CreditsUsed = vacationLeave;
            }
        }

        #endregion

        #region Custom functions used for functionalities

        private void CalculateNumberOfDays(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            NumberOfDaysLeave = difference.Days;
            CreditsUsed = difference.Days;

            if (LeaveType == "Sick Leave")
            {
                sickLeaveDeduct.Text = $"{NumberOfDaysLeave}";
                vacationLeaveDeduct.Text = $"0";
            }
            else
            {
                vacationLeaveDeduct.Text = $"{NumberOfDaysLeave}";
                sickLeaveDeduct.Text = $"0";
            }

            CalculateTheBalanceCredits();
        }

        private void CalculateTheBalanceCredits()
        {
            if (LeaveType == "Sick Leave")
            {
                decimal newSickLeave = SickLeaveCreditsNumber - CreditsUsed;
                decimal newVacationLeave = VacationLeaveCreditsNumber - 0;

                vacationLeaveBalance.Text = $"{newVacationLeave}";
                sickLeaveBalance.Text = $"{newSickLeave}";
            }
            else
            {
                decimal newSickLeave = SickLeaveCreditsNumber - 0;
                decimal newVacationLeave = VacationLeaveCreditsNumber - CreditsUsed;

                vacationLeaveBalance.Text = $"{newVacationLeave}";
                sickLeaveBalance.Text = $"{newSickLeave}";
            }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValidate()
        {
            try
            {
                if (string.IsNullOrEmpty(firstNameTextBox.Texts) || string.IsNullOrEmpty(lastNameTextBox.Texts))
                {
                    MessageBox.Show("Please input the name of the employee");
                    return false;
                }
                else if (string.IsNullOrEmpty(departmentBox.Texts))
                {
                    MessageBox.Show("The Department Name is Empty");
                    return false;
                }
                else if (string.IsNullOrEmpty(salaryBox.Texts) || string.IsNullOrEmpty(descriptionBox.Texts))
                {
                    MessageBox.Show("Salary Rate and Job Description is Empty");
                    return false;
                }
                else if (string.IsNullOrEmpty(typeOfLeave.Text) || typeOfLeave.Text == "Select")
                {
                    MessageBox.Show("Select a type of Leave");
                    return false;
                }
                else if ((startingDate.Value - DateTime.Now).TotalDays < 15)
                {
                    ErrorMessages($"The selected starting date must be greater than or equal to {DateTime.Now: MMM dd, yyyy} and " +
                        $"the leave date must be 15 days prior to its filing.", "Invalid Starting Date");
                    return false;
                }
                else if (string.IsNullOrEmpty(leaveDetails.Texts) || startingDate.Value < DateTime.Today || startingDate.Value.DayOfWeek.ToString() == "Saturday" 
                    || startingDate.Value.DayOfWeek.ToString() == "Sunday" || endingDate.Value < startingDate.Value || endingDate.Value.DayOfWeek == DayOfWeek.Sunday 
                    || endingDate.Value.DayOfWeek == DayOfWeek.Saturday)
                {
                    MessageBox.Show("Starting Date must be greater than " + DateTime.Today.ToString("f") + " and indicate the details of the leave or the date is only allowed in Weekdays!");
                    return false;
                }
                else if ((approveBtn.Checked == false && disapproveBtn.Checked == false) && Department == PersonnelDepartment)
                {
                    MessageBox.Show("Please choose one recommendation for the request");
                    return false;
                }
                else if (dateCertified.Value != DateTime.Today)
                {
                    MessageBox.Show("Please ensure that the Date of Certification matches today's date.");
                    dateCertified.Value = DateTime.Today;
                    return false;
                }
                else if (!humanResourceCheck.Checked && Department == PersonnelDepartment)
                {
                    ErrorMessages("Please ensure to check the certification check box", "Certification Box");
                    humanResourceCheck.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> IsAllowed(int employeeId, string description)
        {
            try
            {
                bool isAllowed = await GetLeavePending(employeeId, description);

                if (isAllowed)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"The employee {FirstName} {LastName} is not currently allowed to submit a leave request. " +
                        $"They have a pending request that needs to be resolved first.", $"Pending Leave Request");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> CheckCredits(int employeeId, string leaveType, int year, decimal numberOfCredits)
        {
            try
            {
                decimal getCredits = await CheckLeaveCredits(employeeId, leaveType, year);

                if (getCredits > 0 && numberOfCredits <= getCredits)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("The leave credits is insufficient please refer to your balance that is being shown in the right " +
                        "side of the screen", "Insufficient Leave Credits");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }
        
        private async Task<bool> AddNewLeave()
        {
            try
            {
                if (PersonnelDepartment == Department)
                {
                    bool addLeave = await AddNewLeave(ApplicationNumber, EmployeeID, DateFiled, LeaveType, formTitle, LeaveDetails,
                    IsRecommended, DepartmentHead, DateTime.Now, IsCertified, CertifiedBy, CertifiedDate, statusDescription,
                    StartingLeaveDate, EndingLeaveDate, NumberOfDaysLeave, CreditsUsed);

                    if (addLeave)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages("We are encountering an issue while attempting to submit the leave request.",
                            "Issues with Leave Request Submission");
                        return false;
                    }
                }
                else
                {
                    bool addLeave = await AddleaveRequest(ApplicationNumber, EmployeeID, DateFiled, LeaveType, formTitle, LeaveDetails,
                    NumberOfDaysLeave, StartingLeaveDate, EndingLeaveDate, CreditsUsed, statusDescription);

                    if (addLeave)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages("There is an error in submitting the Leave Request please double check the details before submitting. " +
                            "If the issue persist please notify  the System Administrators for quick Resolution", "Leave Request Error");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddNewFormLog()
        {
            try
            {
                string logDescription = "Leave Request Submitted:" +
                                        "||Personnel who Submitted: " + PersonnelName + " ( ID: " + _userId.ToString() + " )" +
                                        "||Employee: " + FirstName + " " + LastName + " (Employee ID: " + EmployeeID.ToString() + " )" +
                                        "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = "Application for Leave Request Submission";
                bool addLeaveFormLog = await AddLeaveFormLog(DateFiled, logDescription, ApplicationNumber, logCaption);

                if (addLeaveFormLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("We have encountered a technical difficulty while attempting to add the request to the form logs. As your " +
                        "request has already been submitted, please await further approval and confirmation. Thank you for your understanding.",
                        "Technical Difficulty: Adding Request to Form Logs");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddNewSystemLog()
        {
            try
            {
                string systemLogDescription = "Leave Request Submitted:" +
                                        "||Personnel who Submitted: " + PersonnelName + "( ID: " + _userId.ToString() + " )" +
                                        "||Employee: " + FirstName + " " + LastName + " (Employee ID: " + EmployeeID.ToString() + " )" +
                                        "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Application for Leave Request Submission";
                bool addSystemLogs = await AddSystemLogs(DateFiled, systemLogDescription, systemLogCaption);

                if (addSystemLogs)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("System log insertion encountered an issue. We sincerely apologize for any inconvenience caused. We kindly request your patience while our team resolves this matter. " +
                        "As your request has already been submitted, please await further approval and confirmation. Thank you for your understanding.",
                        "System Log Insertion Issue");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidate())
                    return;

                bool checkCredits = await CheckCredits(_userId, LeaveType, _year, CreditsUsed);
                if (!checkCredits)
                    return;

                bool isAllowed = await IsAllowed(EmployeeID, statusDescription);
                if (!isAllowed)
                    return;

                bool addNewLeave = await AddNewLeave();
                if (!addNewLeave)
                    return;

                bool formLog = await AddNewFormLog();
                if (!formLog)
                    return;

                bool systemLog = await AddNewSystemLog();
                if (!systemLog)
                    return;

                SuccessMessage($"The Leave Request with the Application Number: {ApplicationNumber} has already been submitted. " +
                    $"Please await further approval and confirmation", "Leave Request Submitted: Pending Approval and Confirmation");

                await _parent.LeaveDetails();
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
