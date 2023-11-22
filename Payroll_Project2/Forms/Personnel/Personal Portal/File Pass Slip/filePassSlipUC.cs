using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Personal_Portal.File_Pass_Slip.File_Pass_Slip_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Pass_Slip
{
    public partial class filePassSlipUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static int numberOfYear = DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1;
        private static string formTitle = ConfigurationManager.AppSettings["DefaultSlipTitle"];
        private static string status = "Pending";
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        private DateTime SlipDate { get; set; }
        private TimeSpan SlipStartTime { get; set; }
        private TimeSpan SlipEndTime { get; set; }
        private string Destination { get; set; }

        public filePassSlipUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<bool> AddNewPassSlip(int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate,
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime)
        {
            try
            {
                bool submit = await generalFunctions.AddNewPassSlip(slipControlNumber, employeeId, dateFile, slipDate, slipDestination, createdBy,
                    formType, status, slipStartTime, slipEndTime);
                return submit;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }    
        }

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

        // This function is responsible for retrieving the employee name
        private async Task<string> GetEmployeeName(int employeeId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(employeeId);
                return name;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<TimeSpan> EmployeeSlipHours(int employeeId, int month, int year)
        {
            try
            {
                TimeSpan hours = await generalFunctions.GetEmployeeSlipHours(employeeId, month, year);
                return hours;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DisplaySlipHours()
        {
            try
            {
                listHoursPanel.Controls.Clear();

                for (int i = 1; i <= numberOfYear; i++)
                {
                    TimeSpan hours = await EmployeeSlipHours(_userId, i, DateTime.Now.Year);
                    passSlipDataUC slipData = new passSlipDataUC(_userId, this);
                    slipData.MonthYear = $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(i): MMM} - {DateTime.Now.Year}";

                    if (hours != TimeSpan.Zero && i >= DateTime.Today.Month)
                    {
                        slipData.NumberOfHours = $"{hours:hh\\:mm\\:ss}";
                        listHoursPanel.Controls.Add(slipData);
                    }
                    else if (hours == TimeSpan.Zero && i >= DateTime.Today.Month)
                    {
                        slipData.NumberOfHours = "00:00:00";
                        listHoursPanel.Controls.Add(slipData);
                    }
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

        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
        }

        private async void filePassSlipUC_Load(object sender, EventArgs e)
        {
            DataBinding();
            await DisplaySlipHours();
        }

        private void passSlipDate_ValueChanged(object sender, EventArgs e)
        {
            SlipDate = passSlipDate.Value;
        }

        private void slipStartingTime_ValueChanged(object sender, EventArgs e)
        {
            SlipStartTime = slipStartingTime.Value.TimeOfDay;
        }

        private void slipEndingTime_ValueChanged(object sender, EventArgs e)
        {
            SlipEndTime = slipEndingTime.Value.TimeOfDay;
        }

        private void destination__TextChanged(object sender, EventArgs e)
        {
            Destination = destination.Texts;
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValid()
        {
            if (SlipDate < DateTime.Now)
            {
                ErrorMessages($"Please ensure that the slip date is set to a future date, not earlier than {DateTime.Now: MMM dd, yyyy}.", "Invalid Slip Date");
                return false;
            }
            else if (SlipDate.DayOfWeek == DayOfWeek.Sunday || SlipDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ErrorMessages($"Please ensure that the date selected falls on a weekday and not on a weekend.", "Invalid Slip Date");
                return false;
            }
            else if (SlipStartTime < new TimeSpan(8, 0, 0) || SlipStartTime == new TimeSpan(12, 0, 0) || SlipStartTime > new TimeSpan(17, 0, 0))
            {
                ErrorMessages("Please ensure that the Slip Start time is within working hours, specifically between 8:00 AM and 5:00 PM.", "Invalid Slip Starting Time");
                return false;
            }
            else if (SlipEndTime < new TimeSpan(8, 0, 0) || SlipEndTime == new TimeSpan(12, 0, 0) || SlipEndTime > new TimeSpan(17, 0, 0))
            {
                ErrorMessages("Please ensure that the Slip Ending time is within working hours, specifically between 8:00 AM and 5:00 PM.", "Invalid Slip Ending Time");
                return false;
            }
            else if (SlipEndTime < SlipStartTime)
            {
                ErrorMessages("The slip ending time must be later than the starting time. Please review the details and try again.", "Invalid Slip Ending Time");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(destination.Texts))
            {
                ErrorMessages("Please provide the destination information.", "Missing Destination Information");
                return false;
            }
            else
            {
                return true;
            }
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

        private async Task<bool> ValidateHourBalance(int employeeId, int month, int year, string employeeName, TimeSpan slipStartingTime, 
            TimeSpan slipEndingTime)
        {
            try
            {
                TimeSpan hour = await GetNumberOfHours(employeeId, month, year);

                if (hour == TimeSpan.Zero)
                {
                    ErrorMessages($"Regrettably, employee {employeeName} is ineligible to submit a new pass slip request. " +
                        $"They have already utilized their allocated hours for this month.", "Insufficient Available Hours");
                    return false;
                }
                else if ((slipEndingTime - slipStartingTime) > hour)
                {
                    ErrorMessages($"The remaining available hours for employee {employeeName} is only {hour.TotalHours} hours. " +
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

        private async Task<string> EmployeeName(int employeeId)
        {
            try
            {
                string name = await GetEmployeeName(employeeId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    ErrorMessages("There is an error in retrieving the Employee's name", "Employee Name Retrieval Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipRequest(int slipControlNumber, int employeeId, DateTime dateFile, DateTime slipDate,
            string slipDestination, string createdBy, string formType, string status, TimeSpan slipStartTime, TimeSpan slipEndTime)
        {
            try
            {
                bool slipRequest = await AddNewPassSlip(slipControlNumber, employeeId, dateFile, slipDate, slipDestination, createdBy,
                    formType, status, slipStartTime, slipEndTime);

                if(slipRequest)
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipFormLog(DateTime logDate, int slipControlNumber, string employeeName, int employeeId)
        {
            try
            {
                string formLogDescription = "Pass Slip Request Submitted:" +
                    "||Employee who created the request: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
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

        private async Task<bool> SubmitSystemLog(DateTime logdate, string employeeName, int employeeId)
        {
            try
            {
                string systemLog = "Pass Slip Request Submitted:" +
                "||Employee who filed the request: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
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

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                    return;

                bool pending = await IsPending(_userId, status);
                if (!pending)
                    return;

                string employeeName = await EmployeeName(_userId);
                if (employeeName == null)
                    return;

                bool checkBalance = await ValidateHourBalance(_userId, SlipDate.Month, SlipDate.Year, employeeName, SlipStartTime, SlipEndTime);
                if (!checkBalance)
                    return;

                bool slipRequest = await SubmitSlipRequest(ControlNumber, _userId, DateTime.Now, SlipDate, Destination, employeeName, formTitle, 
                    status, SlipStartTime, SlipEndTime);
                if (!slipRequest)
                    return;

                bool formLog = await SubmitSlipFormLog(DateTime.Now, ControlNumber, employeeName, _userId);
                if (!formLog) 
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Now, employeeName, _userId);
                if (!systemLog) 
                    return;

                SuccessMessages($"The Pass Slip Request with Control Number {ControlNumber} has been successfully submitted and recorded. " +
                    "Please await further review and approval.", "Pass Slip Request Submission");
                await _parent.FilePassSlip();
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
