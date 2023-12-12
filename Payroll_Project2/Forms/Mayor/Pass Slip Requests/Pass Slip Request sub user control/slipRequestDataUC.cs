using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Modals;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Pass_Slip_Request_sub_user_control
{
    public partial class slipRequestDataUC : UserControl
    {
        private static int _userId;
        private static passSlipRequestsUC _parent;
        private static string _userDepartment;
        private static bool IsNote = true;
        private static bool IsApprove = true;
        private static readonly int TotalHours = 4;
        private static readonly string FormStatus = ConfigurationManager.AppSettings.Get("ApproveStatus");
        private static readonly string SlipStatus = ConfigurationManager.AppSettings.Get("DefaultSlipStatus");
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string SlipDate { get; set; }
        public TimeSpan TimeUsed { get; set; }
        public bool IsNoteNull { get; set; }

        public slipRequestDataUC(int userId, passSlipRequestsUC parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = department;
        }

        private async Task<bool> CheckLog(DateTime dateLog, int employeeId)
        {
            try
            {
                bool checkLog = await formRequestClass.CheckIfEmployeeHasLog(dateLog, employeeId);

                if (!checkLog)
                {
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

        private async Task<bool> InsertSlipSpecialPrivilegeLog(int controlNumber, DateTime dateLog, string remarks,
            string description)
        {
            try
            {
                bool insertLog = await formRequestClass.AddSlipSpecialPrivilegeLog(controlNumber, dateLog, remarks, description);
                return insertLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertOrUpdateDTR(int controlNumber, DateTime dateLog, int employeeId, bool hasLogOrNot)
        {
            try
            {
                if (hasLogOrNot)
                {
                    bool update = await formRequestClass.UpdateExistingSlipDTRLog(controlNumber, dateLog, employeeId);
                    return update;
                }
                else
                {
                    bool insert = await formRequestClass.InsertNewSlipDTRLog(controlNumber, dateLog, employeeId);
                    return insert;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetSlipDetails(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetSlipDetailedView(controlNumber);

                if(details != null && details.Rows.Count > 0)
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

        private async Task<string> GetMayorName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);

                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<TimeSpan> GetEmployeeSlipHours(int employeeId, int month, int year)
        {
            try
            {
                TimeSpan hours = await generalFunctions.GetEmployeeSlipHours(employeeId, month, year);
                return hours;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NoteSlipRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool slipNote = await generalFunctions.NotedPassSlipRequest(controlNumber, isNoted, notedBy, notedDate);
                return slipNote;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> ApproveSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate, string status)
        {
            try
            {
                bool approveRequest = await formRequestClass.ApproveSlipRequest(controlNumber, isApproved, approvedBy, approvedDate, status);
                return approveRequest;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> DeductSlipHous(int employeeId, int month, int year, TimeSpan newHours)
        {
            try
            {
                bool deduct = await formRequestClass.UpdateEmployeeSlipHours(employeeId, month, year, newHours);
                return deduct;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not this for the form logs
        private async Task<bool> AddSlipFormLog(DateTime logDate, string logDescription, int slipControlNumber, string caption)
        {
            try
            {
                bool addNewLeaveFormLog = await generalFunctions.AddSlipFormLog(logDate, logDescription, slipControlNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not this is for the system logs
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

        private void DataBinding()
        {
            employeeId.DataBindings.Add("Text", this, "EmployeeId");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AssignValueIfNotEmpty(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            string value = row[columnName]?.ToString();
            assignAction(!string.IsNullOrEmpty(value) ? value : defaultValue);
        }

        private void ParseAndAssignDateTime(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            if (!string.IsNullOrEmpty(row[columnName]?.ToString()) && DateTime.TryParse(row[columnName]?.ToString(),
                out DateTime parsedDate))
            {
                assignAction($"{parsedDate: MMM dd, yyyy}");
            }
            else
            {
                assignAction(defaultValue);
            }
        }

        private void ParseAndAssignTime(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            if (!string.IsNullOrEmpty(row[columnName]?.ToString()) && DateTime.TryParse(row[columnName]?.ToString(), out
                DateTime parsedTime))
            {
                assignAction($"{parsedTime: hh:mm tt}");
            }
            else
            {
                assignAction(defaultValue);
            }
        }

        private async Task DisplaySlipDetails(int userId, string userDepartment, string dateFile, bool isNoteNull, string employeeName, int employeeId, 
            int controlNumber, TimeSpan hoursUsed, string slipDate)
        {
            try
            {
                DataTable details = await GetSlipDetails(controlNumber);
                string name = await GetMayorName(userId);
                DateTime parsedDate = DateTime.Parse(dateFile);
                TimeSpan balanceHour = await GetEmployeeSlipHours(employeeId, parsedDate.Month, parsedDate.Year);

                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        slipRequestDetailedView slipDetails = SlipRequest(controlNumber, name, employeeName, employeeId, isNoteNull, userId,
                            userDepartment, dateFile, slipDate);

                        ParseAndAssignTime(row, "slipStartingTime", value => slipDetails.StartingTime = value, "----------");
                        ParseAndAssignTime(row, "slipEndingTime", value => slipDetails.EndingTime = value, "------------");
                        AssignValueIfNotEmpty(row, "slipDestination", value => slipDetails.Destination = value, "----------");
                        AssignValueIfNotEmpty(row, "slipNotedBy", value => slipDetails.NotedBy = value, "----------");
                        ParseAndAssignDateTime(row, "slipNotedDate", value => slipDetails.NotedDate = value, "---------");
                        slipDetails.MonthName = $"{parsedDate: MMMM}";
                        slipDetails.BalanceHours = $"{(balanceHour == TimeSpan.Zero ? TimeSpan.Zero : balanceHour)}";
                        slipDetails.HoursUsed = $"{(hoursUsed == TimeSpan.Zero? TimeSpan.Zero : hoursUsed)}";
                        slipDetails.RemainingHours = $"{(balanceHour - hoursUsed <= TimeSpan.Zero ? TimeSpan.Zero : balanceHour - hoursUsed)}";

                        slipDetails.ShowDialog();
                    }
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

        private slipRequestDetailedView SlipRequest(int controlNumber, string mayorName, string employeeName, int employeeId, bool isNoteNull, 
            int userId, string userDepartment, string dateFiled, string slipDate)
        {
            return new slipRequestDetailedView(userId, this, userDepartment)
            {
                ControlNumber = controlNumber,
                EmployeeId = employeeId,
                EmployeeName = employeeName,
                MayorName = mayorName,
                IsNoteNull = isNoteNull,
                DateFiled = dateFiled,
                SlipDate = slipDate
            };
        }

        private void slipRequestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplaySlipDetails(_userId, _userDepartment, DateFiled, IsNoteNull, EmployeeName, EmployeeId, ControlNumber, TimeUsed, SlipDate);
            await _parent.DisplayRequest(_userId, _userDepartment);
        }

        private async Task<string> RetrieveMayorName(int userId)
        {
            try
            {
                string name = await GetMayorName(userId);

                if(name != null)
                {
                    return name;
                }
                else
                {
                    ErrorMessages("There is an error retrieving the Mayor's Name. The approval is temporarily terminated please try again later and " +
                        "if error persists please contact the system administrator for quick resolution", "Mayor Name Retrieval Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitNoteSlipRequest(int controlNumber, bool isNote, string notedBy, DateTime notedDate, bool isNoteNull)
        {
            try
            {
                if(!isNoteNull)
                {
                    SuccessMessage("Since the notation of this request is already done by the respective office head it will automatically proceed to " +
                        "approve the Pass Slip Request.", "Pass Slip Request Notation Notice");
                    return true;
                }
                else
                {
                    bool submitNote = await NoteSlipRequest(controlNumber, isNote, notedBy, notedDate);

                    if(submitNote)
                    {
                        return true;
                    }

                    ErrorMessages("There is an error encountered during the notation of pass slip request. The process is temporarily terminated " +
                        "please try again later and if the error persists please contact the system administrator for resolution", "Pass Slip Notation " +
                        "Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex;}
        }

        private async Task<bool> SubmitApprovalSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate, 
            string status)
        {
            try
            {
                bool approve = await ApproveSlipRequest(controlNumber, isApproved, approvedBy, approvedDate, status);

                if(approve)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error encoutered approving the payslip request with control number: {controlNumber}. Please " +
                        $"try again later and if error persists please contact the system administrator for resolution", "Pass Slip Request Approval " +
                        "Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitDeductionSlipHours(int employeeId, string slipDate, TimeSpan hoursUsed)
        {
            try
            {
                if(!string.IsNullOrEmpty(slipDate))
                {
                    DateTime parsedDate = DateTime.Parse(slipDate);
                    TimeSpan balanceHour = await GetEmployeeSlipHours(employeeId, parsedDate.Month, parsedDate.Year);

                    if (balanceHour !=  TimeSpan.Zero)
                    {
                        TimeSpan newHour = balanceHour - hoursUsed;
                        MessageBox.Show($"Hour used: {hoursUsed} Balance: {balanceHour} New Hour: {newHour}");

                        bool updateHour = await DeductSlipHous(employeeId, parsedDate.Month, parsedDate.Year, newHour);

                        if(updateHour)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorMessages("There is an error encountered during the deduction of the employee's Pass Slip Hour balance. " +
                                "Please contact the system administrator to deduct the employee's slip hours and resolution", 
                                "Pass Slip Hours Deduction " +
                                "Error");
                            return false;
                        }   
                    }
                    else
                    {
                        ErrorMessages("There is an error in retrieving the Employee's Pass Slip hours. Please notify the system administrator for this " +
                        "error for quick resolution", "Employee Slip Hours Balance Retrieval Error");
                        return false;
                    }
                }
                else
                {
                    ErrorMessages("The chosen date filed is cannot be converted results into not be able to update the Employee's Slip Hours. " +
                        "Please contact the system administrator to deduct the employee's slip hours and resolution", "Pass Slip Hours Deduction " +
                        "Error");
                    return false;
                }

            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertSpecialPrivilegeLog(DateTime logDate, int controlNumber, string startDate, TimeSpan timeUsed)
        {
            try
            {
                string description = $"Usage of pass slip at {startDate}";
                string remarks = $" Time Used in Pass Slip : {timeUsed}";
                bool specialPrivilege = await InsertSlipSpecialPrivilegeLog(controlNumber, logDate, remarks, description);

                if (specialPrivilege)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encountered when inserting to the Special Privilege Log. Process is terminated.",
                        "Special Privilege Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitDTRLog(int employeeId, string logDate, int controlNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(logDate))
                {
                    DateTime parsedDate = DateTime.Parse(logDate);
                    bool hasLog = await CheckLog(parsedDate, employeeId);

                    bool insertDtr = await InsertOrUpdateDTR(controlNumber, parsedDate, employeeId, hasLog);

                    if (insertDtr)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"An error occurred while integrating the travel order request into the Daily Time Record (DTR) on " +
                            $"{logDate: MMM dd, yyyy}. " +
                            $"The process has been terminated. Please contact the system administrator for prompt resolution.",
                            "Integration Error: Daily Time Record Log");
                        return false;
                    }
                }
                else
                {
                    ErrorMessages($"An error occurred while integrating the travel order request into the Daily Time Record (DTR) on " +
                        $"{logDate: MMM dd, yyyy}. " +
                        $"The process has been terminated. Please contact the system administrator for prompt resolution.",
                        "Integration Error: Daily Time Record Log");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipFormLog(int controlNumber, int employeeId, int userId, DateTime logDate, string employeeName, 
            string mayorName)
        {
            try
            {
                string formLogDescription = "Pass Slip Request Notation and Approval:" +
                    "||Approval and Notation done by Municipal Mayor: " + mayorName + "( ID: " + userId.ToString() + " )" +
                    "||Employee in Request: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                    "||Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Pass Slip Request Notation and Approval";

                bool addTravelFormLog = await AddSlipFormLog(logDate, formLogDescription, controlNumber, formLogCaption);

                if (addTravelFormLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("Failed to update form logs due to technical difficulties. Notify the employee of the approval status. " +
                        "Contact System Administrator for assistance. Thank you.", "Technical Difficulty");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSystemLog(DateTime logDate, string mayorName, string employeeName, int userId, int employeeId)
        {
            try
            {
                string systemLog = "Pass Slip Request Notation and Approval:" +
                        "||Done By Municipal Mayor: " + mayorName + "( ID: " + userId.ToString() + " )" +
                        "||Employee in Request: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                        "||Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Pass Slip Request Notation and Approval";

                bool addSystemLog = await AddSystemLogs(logDate, systemLog, systemLogCaption);

                if (addSystemLog) { return true; }
                else
                {
                    ErrorMessages("Failed to update system logs due to technical difficulties. Notify the employee of the approval status. " +
                        "Contact System Administrator for assistance. Thank you.", "Technical Difficulty");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async void approveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await RetrieveMayorName(_userId);
                if (name == null)
                    return;

                bool noteRequest = await SubmitNoteSlipRequest(ControlNumber, IsNote, name, DateTime.Now, IsNoteNull);
                if (!noteRequest)
                    return;

                bool approveRequest = await SubmitApprovalSlipRequest(ControlNumber, IsApprove, name, DateTime.Now, FormStatus);
                if(!approveRequest) 
                    return;

                bool deduct = await SubmitDeductionSlipHours(EmployeeId, SlipDate, TimeUsed);
                if (!deduct)
                    return;

                bool specialPrivilege = await InsertSpecialPrivilegeLog(DateTime.Today, ControlNumber, SlipDate, TimeUsed);
                if (!specialPrivilege)
                    return;

                bool dtr = await SubmitDTRLog(EmployeeId, SlipDate, ControlNumber);
                if (!dtr)
                    return;

                bool formLog = await SubmitSlipFormLog(ControlNumber, EmployeeId, _userId, DateTime.Now, EmployeeName, name);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Now, name, EmployeeName, _userId, EmployeeId);
                if (!systemLog)
                    return;

                SuccessMessage($"Approval Successful: The pass slip request with " +
                    $"control number {ControlNumber} has been successfully approved. Please await further review and approval. " +
                    $"Thank you for your cooperation.", "Pass Slip Request Approval");

                await _parent.DisplayRequest(_userId, _userDepartment);
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
