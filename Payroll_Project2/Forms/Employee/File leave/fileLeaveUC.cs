using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Employee.File_leave.File_leave_sub_user_control;
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

namespace Payroll_Project2.Forms.Employee.File_leave
{
    public partial class fileLeaveUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static string _department;
        private static int year = DateTime.Now.Year;
        private static readonly string status = "Pending";
        private static readonly string formType = ConfigurationManager.AppSettings["DefaultLeaveTitle"];
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ApplicationNumber { get; set; }
        private string LeaveType { get; set; }
        private DateTime StartingDate { get; set; }
        private DateTime EndingDate { get; set; }
        private string LeaveDetails { get; set; }
        private int NumberOfDays { get; set; }
        private float CreditsUsed { get; set; }


        public fileLeaveUC()
        {
            InitializeComponent();
        }

        #region Functions responsible for communicating with the general functions class

        private async Task<bool> AddleaveRequest(int applicationNumber, int employeeId, DateTime dateFile, string leaveType, string formType,
            string leaveDetails, int numberOfDays, DateTime leaveStartDate, DateTime leaveEndDate, float creditsUsed, string status)
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

        private async Task<DataTable> GetLeaveCredits(int employeeId, int year)
        {
            try
            {
                DataTable leaveCredits = await generalFunctions.GetLeaveCredits(employeeId, year);

                if (leaveCredits != null)
                {
                    return leaveCredits;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<float> GetDefaultCredits(string leaveType)
        {
            try
            {
                float credits = await generalFunctions.GetDefaultCredits(leaveType);

                if (credits >= 0)
                {
                    return credits;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<float> GetLeaveCredits(int employeeId, string leaveType, int year)
        {
            try
            {
                float getLeaveCredits = await generalFunctions.GetLeaveCredits(employeeId, leaveType, year);

                return getLeaveCredits;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetLeaveTypes()
        {
            try
            {
                DataTable leaveTypes = await generalFunctions.GetLeaveTypes();

                if (leaveTypes != null && leaveTypes.Rows.Count > 0)
                {
                    return leaveTypes;
                }
                else
                {
                    return null;
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
                bool addSystemLogs = await generalFunctions.AddSystemLogs(logdate, logdescription, caption);

                return addSystemLogs;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function will retrieve and forward the value from the formClass
        // The value inside is the one who will determine if the employee does have a pending request or not
        private async Task<bool> GetLeavePending(int employeeId, string status)
        {
            try
            {
                bool count = await generalFunctions.GetLeavePendingCount(employeeId, status);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Custom functions used for functionality

        private float ComputeUsedCredits(float defaultCredits, float employeeCredits)
        {
            return defaultCredits - employeeCredits;
        }

        private int ComputeNumberOfDays(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            CreditsUsed = difference.Days;

            if (difference.Days > 0)
            {
                return difference.Days;
            }
            else
            {
                ErrorMessages("There is an error in the computation of Number of Days. Please review the " +
                    "respective dates", "Number of Days Invalid");
                return 0;
            }
        }

        private async void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            DataTable leaveType = await GetLeaveTypes();

            if (leaveType != null)
            {
                List<string> leaveTypeCollection = new List<string>();

                foreach (DataRow row in leaveType.Rows)
                {
                    leaveTypeCollection.Add($"{row["leaveType"]}");
                }

                this.leaveType.DataSource = leaveTypeCollection;
                this.leaveType.SelectedIndex = -1;
            }
        }

        private async Task DisplayLeaveCredits(int employeeId, int year)
        {
            leaveCreditsListPanel.Controls.Clear();
            DataTable employeeCredits = await GetLeaveCredits(employeeId, year);
            leaveCreditsDataUC leaveCredits = new leaveCreditsDataUC();
            leaveCreditsListPanel.Controls.Add(leaveCredits);

            /*if (employeeCredits != null)
            {
                leaveCreditsDataUC[] leaveCredits = new leaveCreditsDataUC[employeeCredits.Rows.Count];

                for (int i = 0; i < employeeCredits.Rows.Count; i++)
                {
                    leaveCredits[i] = new leaveCreditsDataUC(_userId, this);
                    DataRow row = employeeCredits.Rows[i];

                    float totalCredits = await GetDefaultCredits($"{row["leaveType"]}");
                    float balance = float.Parse(row["numberOfCredits"].ToString());
                    float usedCredits = ComputeUsedCredits(totalCredits, balance);

                    if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                    {
                        leaveCredits[i].LeaveType = $"{row["leaveType"]}";
                    }
                    else
                    {
                        leaveCredits[i].LeaveType = "--------";
                    }

                    if (totalCredits >= 0)
                    {
                        leaveCredits[i].TotalCredits = totalCredits;
                    }
                    else
                    {
                        leaveCredits[i].TotalCredits = -1;
                    }

                    if (!string.IsNullOrEmpty(row["numberOfCredits"].ToString()))
                    {
                        leaveCredits[i].Balance = balance;
                    }
                    else
                    {
                        leaveCredits[i].Balance = -1;
                    }

                    if (usedCredits >= 0)
                    {
                        leaveCredits[i].UsedCredits = usedCredits;
                    }
                    else
                    {
                        leaveCredits[i].UsedCredits = -1;
                    }

                    if (!string.IsNullOrEmpty(row["leaveCreditYear"].ToString()) && int.TryParse(row["leaveCreditYear"].ToString(),
                        out int creditsYear))
                    {
                        leaveCredits[i].Year = creditsYear;
                    }
                    else
                    {
                        leaveCredits[i].Year = 0;
                    }

                    leaveCreditsListPanel.Controls.Add(leaveCredits[i]);
                }
            }*/
        }

        #endregion

        #region User interfaces event handlers

        private async void fileLeaveUC_Load(object sender, EventArgs e)
        {
            DataBinding();
            await DisplayLeaveCredits(_userId, year);
        }

        private void applicationNumber_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(applicationNumber.Text) && int.TryParse(applicationNumber.Text, out int number))
            {
                ApplicationNumber = number;
            }
        }

        private void leaveType_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(leaveType.Text))
            {
                LeaveType = leaveType.Text;
            }
        }

        private void startingDate_ValueChanged(object sender, EventArgs e)
        {
            if (startingDate.Value >= DateTime.Now)
            {
                StartingDate = startingDate.Value;
            }
        }

        private void endingDate_ValueChanged(object sender, EventArgs e)
        {
            if (endingDate.Value >= StartingDate)
            {
                EndingDate = endingDate.Value;
            }
        }

        private void leaveDetails__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(leaveDetails.Texts))
            {
                LeaveDetails = leaveDetails.Texts;
            }
        }

        private void yearInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress non-digit input
            }
        }

        private void yearInput__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(yearInput.Texts) && int.TryParse(yearInput.Texts, out int yearFilter))
            {
                year = yearFilter;
            }
            else
            {
                year = DateTime.Now.Year;
            }
        }

        private async void applyBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeaveCredits(_userId, year);
            yearInput.Texts = string.Empty;
        }

        #endregion

        #region Encapsulated functions responsible for the step-by-step for filing leave requests

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(leaveType.Text))
            {
                ErrorMessages("Please select a type of leave.", "Leave Type Selection");
                return false;
            }
            else if ((startingDate.Value - DateTime.Now).TotalDays < 15)
            {
                ErrorMessages($"The selected starting date must be greater than or equal to {DateTime.Now: MMM dd, yyyy} and " +
                    $"the leave date must be 15 days prior to its filing.", "Invalid Starting Date");
                return false;
            }
            else if (startingDate.Value < DateTime.Now)
            {
                ErrorMessages($"The selected starting date must be greater than or equal to {DateTime.Now: MMM dd, yyyy}.",
                    "Invalid Starting Date");
                return false;
            }
            else if (endingDate.Value < startingDate.Value)
            {
                ErrorMessages($"The selected ending date must be greater than or equal to the starting date ({startingDate.Value: MMM dd, yyyy})" +
                    $".", "Invalid Ending Date");
                return false;
            }
            else if (string.IsNullOrEmpty(leaveDetails.Texts))
            {
                ErrorMessages("Please provide details for the leave request.", "Leave Details");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> IsAllowed(int employeeId, string leaveType, int year, float numberOfCredits)
        {
            try
            {
                float getCredits = await GetLeaveCredits(employeeId, leaveType, year);

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

        private async Task<bool> CheckPending(int employeeId, string status)
        {
            try
            {
                bool pending = await GetLeavePending(employeeId, status);

                if (pending)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("Please be informed that the employee is currently unable to submit a new leave request due to an " +
                        "existing pending request on record.", "Pending Request");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitLeaveRequest(int employeeId, string status, DateTime dateFiled, string formType)
        {
            try
            {
                bool addLeave = await AddleaveRequest(ApplicationNumber, employeeId, dateFiled, LeaveType, formType, LeaveDetails,
                    NumberOfDays, StartingDate, EndingDate, CreditsUsed, status);

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddNewFormLog(int employeeId)
        {
            try
            {
                string logDescription = "Leave Request Submitted:" +
                                        "||Employee ID who Submitted:  ( ID: " + employeeId.ToString() + " )" +
                                        "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = "Application for Leave Request Submission";
                bool addLeaveFormLog = await AddLeaveFormLog(DateTime.Now, logDescription, ApplicationNumber, logCaption);

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

        private async Task<bool> AddNewSystemLog(int employeeId)
        {
            try
            {
                string systemLogDescription = "Leave Request Submitted:" +
                                        "||Employee ID Wwho Submitted the request: (Employee ID: " + employeeId.ToString() + " )" +
                                        "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Application for Leave Request Submission";
                bool addSystemLogs = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

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
                if (!IsValid())
                    return;

                NumberOfDays = ComputeNumberOfDays(StartingDate, EndingDate);
                if (NumberOfDays == 0)
                    return;

                bool isAllowed = await IsAllowed(_userId, LeaveType, year, CreditsUsed);
                if (!isAllowed)
                    return;

                bool checkPending = await CheckPending(_userId, status);
                if (!checkPending)
                    return;

                bool submitLeave = await SubmitLeaveRequest(_userId, status, DateTime.Now, formType);
                if (!submitLeave)
                    return;

                bool addFormLog = await AddNewFormLog(_userId);
                if (!addFormLog)
                    return;

                bool addSystemLog = await AddNewSystemLog(_userId);
                if (!addSystemLog)
                    return;

                SuccessMessage($"The leave request with the application number: {ApplicationNumber} is already submitted. Please wait for " +
                    $"further review and approval.", "Leave Request Submission");
                await _parent.DisplayFileLeave();
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
