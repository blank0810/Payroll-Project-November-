using log4net;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents.Modal;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents
{
    public partial class personnelPassSlipUC : UserControl
    {
        #region Variables inside is the one needs for this User Control to make the User Controls value can be changed dynamically

        private static int _userId;
        private static newDashboard _parent;
        private static appForLeave appForLeave;
        private static travelOrder travelOrder;
        private static string formTitle = ConfigurationManager.AppSettings["DefaultSlipTitle"];
        private static readonly string statusDescription = "Pending";
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        private int EmployeeID { get; set; }
        public string MayorName { get; set; }
        public string PersonnelDepartment { get; set; }
        private string EmployeeDepartment { get; set; }
        private string DepartmentHead { get; set; }
        private bool IsNoted { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string MiddleName { get; set; }
        public DateTime DateFiled { get; set; }
        private DateTime SlipDate { get; set; }
        private TimeSpan SlipStartingTime { get; set; }
        private TimeSpan SlipEndingTime { get; set; }
        private string Destination { get; set; }

        #endregion

        public personnelPassSlipUC(newDashboard parent, int userId)
        {
            InitializeComponent();
            _parent = parent;
            _userId = userId;
        }

        #region This function inside is the one responsible for communicating in formClass and also the one who forwarded the values retrieved from formClass to the User Interface dynamically

        // This function is responsible for retrieving and forwarding if the employee is allowed to file a request
        // This function will return only true or false
        private async Task<bool> GetSlipPending(int employeeId, string status)
        {
            try
            {
                bool count = await generalFunctions.GetSlipPendingCount(employeeId, status);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for adding new pass slip request if the employee is outside the Human Resources Office
        private async Task<bool> AddPassSlip(int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate,
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime)
        {
            try
            {
                bool addPassSlip = await generalFunctions.AddNewPassSlip(slipControlNumber, employeeId, dateFile, slipDate, slipDestination, 
                    createdBy, formType, status, slipStartTime, slipEndTime);

                return addPassSlip;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as the function for submitting a pass slip request where it is already noted by the HR officer because 
        // the employee in the request is from Human Resource office
        private async Task<bool> SubmitPassSlip(int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate,
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime,
            bool isNoted, string slipNotedBy, DateTime slipNotedDate)
        {
            try
            {
                bool addPassSlip = await formClass.AddPassSlip(slipControlNumber, employeeId, dateFile, slipDate, slipDestination, createdBy,
                    formType, status, slipStartTime, slipEndTime, isNoted, slipNotedBy, slipNotedDate);

                return addPassSlip;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function retrieves the employee's balance or available number of Hours to determine if the employee is allowed to submit the 
        // pass slip request
        private async Task<TimeSpan> GetNumberOfHours(int employeeId, int month, int year)
        {
            try
            {
                TimeSpan numberOfHours = await generalFunctions.GetEmployeeSlipHours(employeeId, month, year);
                
                return numberOfHours;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is serves as an indicator if the log is added or not
        // Will only return true or false
        private async Task<bool> AddSlipFormLog(DateTime logDate, string logDescription, int slipControlNumber, string caption)
        {
            try
            {
                formClass = new formClass();
                bool addNewLeaveFormLog = await generalFunctions.AddSlipFormLog(logDate, logDescription, slipControlNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is serves as an indicator if the log is added or not
        // Will only return true or false
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

        // This function is responsible for retrieving the Personnel Name of the User
        // Will return the name of the personnel as a string value
        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                formClass = new formClass();
                string personnelName = await formClass.GetPersonnelName(userId);
                return personnelName;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region The functions below is user for Dynamic Behaviour of the User Interface

        private void CenterLabel()
        {
            // Calculate the center positions of departmentName label
            int mayorLabelX = mayorLabel.Left + (mayorLabel.Width - mayor.Width) / 2;
            mayor.Location = new Point(mayorLabelX, mayor.Top);


            // Set the new position for departmentHead label
            mayor.Location = new Point(mayorLabelX, mayor.Location.Y);
        }

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        public async void ChosenName(int employeeId, string firstName, string lastName, string middleName, string departmentHead, string department)
        {
            this.employeeId.Text = employeeId.ToString();
            firstNameTextBox.Texts = firstName;
            lastNameTextBox.Texts = lastName;
            this.middleName.Texts = middleName;
            EmployeeDepartment = department;

            if (PersonnelDepartment == EmployeeDepartment)
            {
                string personnelName = await GetPersonnelName(_userId);
                this.departmentHead.Text = personnelName;
            }
            else
            {
                this.departmentHead.Text = departmentHead;
            }

            CenterDepartmentHead();
        }

        public bool PanelContent()
        {
            if (_parent.Controls.ContainsKey("mainPanel"))
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

        private void DataBinding()
        {
            controlNum.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Value", this, "DateFiled");
            mayor.DataBindings.Add("Text", this, "MayorName");
        }

        private void personnelPassSlipUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void firstNameTextBox_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(firstNameTextBox.Texts))
            {
                appForLeave = new appForLeave(_parent, _userId);
                travelOrder = new travelOrder(_parent, _userId);
                employeeList employeeList = new employeeList(appForLeave, this, travelOrder);
                employeeList.ShowDialog();
            }
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            appForLeave = new appForLeave(_parent, _userId);
            travelOrder = new travelOrder(_parent, _userId);
            employeeList employeeList = new employeeList(appForLeave, this, travelOrder);
            employeeList.ShowDialog();
        }

        private void mayor_TextChanged(object sender, EventArgs e)
        {
            CenterLabel();
        }

        private void departmentHead_TextChanged(object sender, EventArgs e)
        {
            DepartmentHead = departmentHead.Text;
        }

        private void employeeId_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(employeeId.Text))
            {
                EmployeeID = Convert.ToInt32(employeeId.Text);
            }
        }

        private void firstNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(firstNameTextBox.Texts))
            {
                FirstName = firstNameTextBox.Texts;
            }
        }

        private void lastNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(lastNameTextBox.Texts))
            {
                LastName = lastNameTextBox.Texts;
            }
        }

        private void middleName__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(middleName.Texts))
            {
                MiddleName = middleName.Texts;
            }
        }

        private void dateFiled_ValueChanged(object sender, EventArgs e)
        {
            DateFiled = dateFiled.Value;
        }

        private void slipDate_ValueChanged(object sender, EventArgs e)
        {
            SlipDate = slipDate.Value;
        }

        private void destinationBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(destinationBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                Destination = capitalizedText;
            }
        }

        private void departmentHeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (departmentHeadCheck.Checked && PersonnelDepartment == EmployeeDepartment)
            {
                SuccessMessages($"Note: Since the requested employee is from {PersonnelDepartment} the Human Resource Officer is entitled " +
                    $"to note the said Pass Slip Request", "Pass Slip Request Notation");
                IsNoted = true;
            }
            else if (departmentHeadCheck.Checked && PersonnelDepartment != EmployeeDepartment)
            {
                ErrorMessages($"Warning: Only the designated department head of {EmployeeDepartment} is allowed to note the Pass Slip Request",
                    "Invalid Action");
                departmentHeadCheck.Checked = false;   
            }
        }

        private void mayorCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (mayorCheck.Checked)
            {
                MessageBox.Show("Only the Mayor is authorized to make an approval for the Pass Slip request.", "Restricted to Mayor:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mayorCheck.Checked = false;
            }
        }

        private void slipStartingTime_ValueChanged(object sender, EventArgs e)
        {
            SlipStartingTime = slipStartingTime.Value.TimeOfDay;
        }

        private void slipEndingTime_ValueChanged(object sender, EventArgs e)
        {
            SlipEndingTime = slipEndingTime.Value.TimeOfDay;
        }

        #endregion

        #region Encapsulated Functions

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValid(string personnelDepartment, string employeeDepartment)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Texts) || string.IsNullOrWhiteSpace(lastNameTextBox.Texts))
            {
                ErrorMessages("Please provide the complete name of the employee.", "Incomplete Name");
                return false;
            }
            else if (slipDate.Value <= DateTime.Now)
            {
                ErrorMessages("The slip date must be a future date.", "Invalid Slip Date");
                return false;
            }
            else if (slipEndingTime.Value.TimeOfDay <= slipStartingTime.Value.TimeOfDay ||
                     (slipEndingTime.Value.TimeOfDay - slipStartingTime.Value.TimeOfDay).TotalHours < 1)
            {
                ErrorMessages("The slip ending time must be later than the starting time and there should be at least 1 hour of discrepancy.",
                              "Invalid Slip Time");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(destinationBox.Texts))
            {
                ErrorMessages("Please specify the destination.", "Missing Destination");
                return false;
            }
            else if (personnelDepartment == employeeDepartment && !departmentHeadCheck.Checked)
            {
                ErrorMessages($"Since the employee is from {PersonnelDepartment} the Humnan Resource Officer must notarized the " +
                    $"Pass Slip Request", "Notary of Pass Slip Request");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> ValidateHourBalance(int employeeId, int month, int year, string firstName, string lastName,
            TimeSpan slipStartingTime, TimeSpan slipEndingTime)
        {
            try
            {
                TimeSpan hour = await GetNumberOfHours(employeeId, month, year);

                if (hour == TimeSpan.Zero)
                {
                    ErrorMessages($"Regrettably, employee {firstName} {lastName} is ineligible to submit a new pass slip request. " +
                        $"They have already utilized their allocated hours for this month.", "Insufficient Available Hours");
                    return false;
                }
                else if ((slipEndingTime - slipStartingTime) > hour)
                {
                    ErrorMessages($"The remaining available hours for employee {firstName} {lastName} is only {hour.TotalHours} hours. " +
                        $"Please adjust the designated time to ensure it is less than {hour.TotalHours} hours.", "Invalid Time Input");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> IsPending(int employeeId, string status)
        {
            try
            {
                bool checkPending = await GetSlipPending(employeeId, status);

                if (checkPending)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("Regrettably, the employee is currently ineligible to submit a new slip request as there is an ongoing pending " +
                        "slip request awaiting approval.", "Pending Slip Request");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> PersonnelName(int userId)
        {
            try
            {
                string name = await GetPersonnelName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    ErrorMessages("We regret to inform you that an error occurred while attempting to retrieve the personnel name. " +
                        "Please accept our apologies for any inconvenience caused.", "Personnel Name Retrieval Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipRequest(int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate,
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime,
            bool isNoted, string slipNotedBy, DateTime slipNotedDate, string personnelDepartment, string employeeDepartment)
        {
            try
            {
                if (personnelDepartment == employeeDepartment)
                {
                    bool submitSlipRequest = await SubmitPassSlip(slipControlNumber, employeeId, dateFile, slipDate, slipDestination,
                        createdBy, formType, status, slipStartTime, slipEndTime, isNoted, slipNotedBy, slipNotedDate);

                    if (submitSlipRequest)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages("We regret to inform you that an error occurred while submitting the Pass Slip Request. " +
                            "Please contact the IT Office for prompt resolution.", "Submission Error");
                        return false;
                    }
                }
                else
                {
                    bool submitSlipRequest = await AddPassSlip(slipControlNumber, employeeId, dateFile, slipDate, slipDestination, createdBy,
                        formType, status, slipStartTime, slipEndTime);

                    if (submitSlipRequest)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages("We regret to inform you that an error occurred while submitting the Pass Slip Request. " +
                            "Please contact the IT Office for prompt resolution.", "Submission Error");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipFormLog(DateTime logDate, int slipControlNumber, int userId, string name, string firstName, 
            string lastName, int employeeId)
        {
            try
            {
                string formLogDescription = "Pass Slip Request Submitted:" +
                    "||Personnel who Submitted: " + name + "( ID: " + userId.ToString() + " )" +
                    "||Employee: " + firstName + " " + lastName + " (Employee ID: " + employeeId.ToString() + " )" +
                    "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Pass Slip Request Submission";

                bool addFormLog = await AddSlipFormLog(logDate, formLogDescription, slipControlNumber, formLogCaption);

                if (addFormLog)
                {
                    return true;
                }    
                else
                {
                    ErrorMessages("We regret to inform you that a technical issue has arisen while attempting to add your request to the form logs. " +
                        "Since your request has already been submitted, kindly await further approval and confirmation. " +
                        "We appreciate your patience and understanding.", "Technical Difficulty: Adding Request to Form Logs");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSystemLog(DateTime logdate, string name, string firstName, string lastName, int userId, int employeeId)
        {
            try
            {
                string systemLog = "Pass Slip Request Submitted:" +
                "||Personnel who Submitted: " + name + "( ID: " + userId.ToString() + " )" +
                "||Employee: " + firstName + " " + lastName + " (Employee ID: " + employeeId.ToString() + " )" +
                "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Pass Slip Request Submission";

                bool addSystemLog = await AddSystemLogs(logdate, systemLog, systemLogCaption);

                if (addSystemLog) 
                {
                    return true;
                }
                else
                {
                    ErrorMessages("We regret to inform you that an issue occurred while inserting the system log. " +
                        "We apologize for any inconvenience this may cause. Our team is actively working to resolve this matter. " +
                        "As your request has already been submitted, please await further approval and confirmation. " +
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
                if (!IsValid(PersonnelDepartment, EmployeeDepartment))
                    return;

                bool validate = await ValidateHourBalance(EmployeeID, DateTime.Now.Month, DateTime.Now.Year, FirstName, LastName,
                    SlipStartingTime, SlipEndingTime);
                if (!validate)
                    return;

                bool checkPending = await IsPending(EmployeeID, statusDescription);
                if (!checkPending) 
                    return;

                string name = await PersonnelName(_userId);
                if (name == null)
                    return;

                bool submitRequest = await SubmitSlipRequest(ControlNumber, EmployeeID, DateFiled, SlipDate, Destination, name, formTitle, 
                    statusDescription, SlipStartingTime, SlipEndingTime, IsNoted, name, DateTime.Today, PersonnelDepartment, EmployeeDepartment);
                if(!submitRequest) 
                    return;

                bool submitFormLog = await SubmitSlipFormLog(DateTime.Today, ControlNumber, _userId, name, FirstName, LastName, EmployeeID);
                if (!submitFormLog)
                    return;

                bool submitSystemLog = await SubmitSystemLog(DateTime.Today, name, FirstName, LastName, _userId, EmployeeID);
                if (submitSystemLog)
                    return;

                SuccessMessages($"The Pass Slip Request with Control Number {ControlNumber} has been successfully submitted and recorded. " +
                    "Please await further review and approval.", "Pass Slip Request Submission");
                await _parent.SlipDetails();
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQl Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
