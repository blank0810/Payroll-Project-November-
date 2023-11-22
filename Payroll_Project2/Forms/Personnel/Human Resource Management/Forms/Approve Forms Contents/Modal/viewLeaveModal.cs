using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal
{
    public partial class viewLeaveModal : Form
    {
        #region Public and Private variables

        private static applicationForLeaveData _parent;
        private static int _userId;
        private static formClass formClass = new formClass();
        private static bool IsCertified = true;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ApplicationNumber { get; set; }
        public int EmployeeID { get; set; }
        public string MayorName { get; set; }
        public string PersonnelName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DepartmentHead { get; set; }
        public string Department { get; set; }
        public DateTime DateFiled { get; set; }
        public string SalaryRate { get; set; }
        public string JobDescription { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDetails { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public bool IsRecommended { get; set; }
        public DateTime CertifiedDate { get; set; }
        public decimal CreditsUsed { get; set; }
        private decimal SickLeaveCredits { get; set; }
        private decimal VacationLeaveCredits { get; set; }
        public bool IsSameDepartment { get; set; }

        #endregion

        public viewLeaveModal(int userId, applicationForLeaveData parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        #region Functions responsible for forwarding to form class

        // This function will update the leave request indicating that it is already certified
        private async Task<bool> UpdateLeave(int applicationNumber, string certifiedBy, DateTime certifiedDate, bool isCertify)
        {
            try
            {
                formClass = new formClass();
                bool result = await formClass.UpdateLeaveRequest(applicationNumber, certifiedBy, certifiedDate, isCertify);

                return result;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
        private async Task<float> GetLeaveCredits(int employeeId, string leaveType)
        {
            try
            {
                float numberOfCredits = await formClass.GetLeaveCredits(employeeId, leaveType);
                return numberOfCredits;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for retrieving personnel department
        private async Task<string> GetPersonnelDepartment(int employeeId)
        {
            try
            {
                string departmentName = await formClass.GetPersonnelDepartment(employeeId);

                return departmentName;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for recommendation of the leave request
        private async Task<bool> RecommendLeaveRequest(int applicationNumber, bool isRecommended, string recommendedBy,
            DateTime dateRecommended)
        {
            try
            {
                bool approveRequest = await formClass.RecommendLeaveRequest(applicationNumber, isRecommended, recommendedBy, dateRecommended);
                return approveRequest;
            }
            catch
            (SqlException sql)
            { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Event Handlers for UI behaviours

        // Event handler that handles the if this form is loaded into the system
        private void viewLeaveModal_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler if the approved button is being checked
        private void approveBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (IsRecommended && !approveBtn.Checked && !IsSameDepartment)
            {
                MessageBox.Show("Only the Department Head is authorized to make a modification for the leave request.",
                    "Restricted to Department Head:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                approveBtn.Checked = true;
                disapproveBtn.Checked = false;
            }
            else
            {
                IsRecommended = true;
            }
        }

        // Event handler that handles if the disapprove button is being checked
        private void disapproveBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsRecommended && !disapproveBtn.Checked && !IsSameDepartment)
            {
                MessageBox.Show("Only the Department Head is authorized to make a modification for the leave request.",
                    "Restricted to Department Head:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                disapproveBtn.Checked = true;
                approveBtn.Checked = false;
            }
            else
            {
                IsRecommended = false;
            }
        }

        // Evevnt handler that handles the certification date
        private void dateCertified_ValueChanged(object sender, EventArgs e)
        {
            if(dateCertified.Value.Date == DateTime.Today)
            {
                CertifiedDate = dateCertified.Value.Date;
            }
            else
            {
                MessageBox.Show("The file date should not exceed today's date. Please verify the file date and try again.",
                    "Invalid File Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sickLeaveCredits_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(sickLeaveCredits.Text, out decimal credits))
            {
                SickLeaveCredits = credits;
            }
        }

        private void vacationLeaveCredits_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(vacationLeaveCredits.Text, out decimal credits))
            {
                VacationLeaveCredits = credits;
            }
        }

        #endregion

        #region Custom Functions

        // Custom function that centers the department head name
        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = departmentName.Left + (departmentName.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        // Custom Function that centers the personnel name
        private void CenterPersonnel()
        {
            // Calculate the center positions of departmentName label
            int personnelX = jobDescOfPersonnel.Left + (jobDescOfPersonnel.Width - personnel.Width) / 2;
            personnel.Location = new Point(personnelX, personnel.Top);


            // Set the new position for departmentHead label
            personnel.Location = new Point(personnelX, personnel.Location.Y);
        }

        // Custom function for binding values into the UI controls
        private async void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            firstName.DataBindings.Add("Text", this, "FirstName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            lastName.DataBindings.Add("Text", this, "LastName");
            departmentLabel.DataBindings.Add("Text", this, "Department");
            dateFiled.DataBindings.Add("Value", this, "DateFiled");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            descriptionLabel.DataBindings.Add("Text", this, "JobDescription");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            leaveDetails.DataBindings.Add("Text", this, "LeaveDetails");
            departmentHead.DataBindings.Add("Text", this, "DepartmentHead");
            dateCertified.DataBindings.Add("Value", this, "CertifiedDate");
            personnel.DataBindings.Add("Text", this, "PersonnelName");
            departmentName.DataBindings.Add("Text", this, "Department");


            if (IsRecommended)
            {
                approveBtn.Checked = true;
            }
            else if(!IsRecommended)
            {
                disapproveBtn.Checked = true;
            }
            else
            {
                approveBtn.Checked = false;
                disapproveBtn.Checked = false;
            }


            CenterDepartmentHead();
            CenterPersonnel();
            await InputLeaveCredits(EmployeeID);
        }

        public async Task InputLeaveCredits(int employeeId)
        {
            try
            {
                DataTable leaveTypes = await generalFunctions.GetLeaveTypes();

                foreach (DataRow row in leaveTypes.Rows)
                {
                    string type = $"{row["leaveType"]}";
                    float numberOfCredits = await GetLeaveCredits(employeeId, type);
                    MessageBox.Show($"{EmployeeID} {numberOfCredits}");

                    if (type == "Voluntary Leave")
                    {
                        vacationLeaveCredits.Text = $"{numberOfCredits}";
                    }
                    else
                    {
                        sickLeaveCredits.Text = $"{numberOfCredits}";
                    }
                }
                CalculateTheBalanceCredits();
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Exception");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        private void CalculateTheBalanceCredits()
        {
            if (LeaveType == "Sick Leave")
            {
                decimal newSickLeave = SickLeaveCredits - CreditsUsed;
                decimal newVacationLeave = VacationLeaveCredits - 0;
                vacationLeaveBalance.Text = $"{newVacationLeave}";
                sickLeaveBalance.Text = $"{newSickLeave}";
                vacationLeaveDeduct.Text = $"{0}";
                sickLeaveDeduct.Text = $"{CreditsUsed}";
            }
            else
            {
                decimal newSickLeave = SickLeaveCredits - 0;
                decimal newVacationLeave = VacationLeaveCredits - CreditsUsed;
                vacationLeaveBalance.Text = $"{newVacationLeave}";
                sickLeaveBalance.Text = $"{newSickLeave}";
                vacationLeaveDeduct.Text = $"{CreditsUsed}";
                sickLeaveDeduct.Text = $"{0}";
            }
        }

        // Custom function that displays error messages
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Custom function display successful transactions
        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Custom Function for validating
        private bool IsValidated()
        {
            if (!humanResourceCheck.Checked)
            {
                ErrorMessage("Please ensure to check the certification checkbox for the leave request to proceed.",
                    "Certification Required");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Custom function that handles authorization
        private string IsAuthorized()
        {
            try
            {
                string personnelName = PersonnelName;

                if (!string.IsNullOrEmpty(personnelName))
                {
                    return personnelName;
                }
                else
                {
                    ErrorMessage("There is no retrieved Personnel Name", "Invalid name");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function that check if the requests need recommendation or not
        private async Task<bool> IsRecommendationNeed(string name)
        {
            try
            {
                if (IsSameDepartment)
                {
                    bool recommendRequest = await RecommendLeaveRequest(ApplicationNumber, IsRecommended, name, DateTime.Now);

                    if (recommendRequest)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage("We are encountering an issue while attempting to submit the recommendation for the leave request. " +
                            "Please contact the IT officers in regarding to this situation! As the situation is still not resolve we will " +
                            "temporarily halt the certification.", " Issues with Leave Certification");
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function that handles the certification of leave requests
        private async Task<bool> CertifyLeave(string name)
        {
            try
            {
                bool updateLeave = await UpdateLeave(ApplicationNumber, name, DateTime.Today, IsCertified);

                if (updateLeave)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We are encountering an issue while attempting to submit the certification for the leave request." +
                            " Please contact the IT officers in regarding to this situation! As the situation is still not resolve we will " +
                            "temporarily halt the certification.",
                            " Issues with Leave Certification");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function that handles to add new System Logs
        private async Task<bool> AddNewFormLog(string name)
        {
            try
            {
                string logDescription = "Human Resource Officer who Certified the Request: " + name + " ( ID: " + _userId.ToString() + " )" +
                            "||Employee: " + FirstName + " " + LastName + " (Employee ID: " + EmployeeID.ToString() + " )" +
                            "||Leave Application Number: " + ApplicationNumber.ToString() +
                            "||Certification Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = "Certification by Human Resource Office for the Application for Leave";

                bool newLog = await AddLeaveFormLog(DateTime.Today, logDescription, ApplicationNumber, logCaption);

                if (newLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We have encountered a technical difficulty while attempting to add the request to the form logs. " +
                                "As the certification has already been done, please await further approval. " +
                                "Thank you for your understanding.", "Technical Difficulty: Adding the Certification to Form Logs");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //Custom function responsible for adding new system log
        private async Task<bool> AddNewSystemLog(string name)
        {
            try
            {
                string systemLogDescription = "Human Resource Officer who Certified: " + name + "( ID: " + _userId.ToString() + " )" +
                            "||Employee: " + FirstName + " " + LastName + " (Employee ID: " + EmployeeID.ToString() + " )" +
                            "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string systemLogCaption = "Certification by Human Resource Office for the Application for Leave";

                bool addLog = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("System log insertion encountered an issue. We sincerely apologize for any inconvenience caused. " +
                                    "We kindly request your patience while our team resolves this matter. " +
                                    "As the certification has already been done, please await for further approval. " +
                                    "Thank you for your understanding.", "System Log Insertion Issue");
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
                if (!IsValidated())
                    return;

                string name = IsAuthorized();
                if (string.IsNullOrEmpty(name))
                    return;

                bool recommendation = await IsRecommendationNeed(name);
                if (!recommendation)
                    return;

                bool certify = await CertifyLeave(name);
                if (!certify)
                    return;

                bool formLog = await AddNewFormLog(name);
                if (!formLog)
                    return;

                bool systemLog = await AddNewSystemLog(name);
                if (!systemLog)
                    return;

                SuccessMessage("The certification is already done. Please await further approval to be done by the Municipal Mayor.",
                                    "Certification for Application for Leave Submitted: Pending Approval from the Municipal Mayor");
                this.Close();
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
