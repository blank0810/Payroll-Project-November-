using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Travel_Order_Requests.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Travel_Order_Requests.Travel_Order_Requests_sub_user_control
{
    public partial class requestDataUC : UserControl
    {
        private static int _userId;
        private static travelRequestsUC _parent;
        private static string _userDepartment;
        private static bool IsNote = true;
        private static bool IsApprove = true;
        private static readonly int TotalHours = 8;
        private static readonly string FormStatus = ConfigurationManager.AppSettings.Get("ApproveStatus");
        private static readonly string TravelStatus = ConfigurationManager.AppSettings.Get("DefaultTravelStatus");
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string DateDeparture { get; set; }
        public bool IsNoteNull { get; set; }

        public requestDataUC(int userId, travelRequestsUC parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
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

        private async Task<bool> InsertTravelSpecialPrivilegeLog(int controlNumber, DateTime dateLog, string remarks,
            string description)
        {
            try
            {
                bool insertLog = await formRequestClass.AddTravelSpecialPrivilegeLog(controlNumber, dateLog, remarks, description);
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
                    bool update = await formRequestClass.UpdateExistingTravelDTRLog(controlNumber, dateLog, employeeId);
                    return update;
                }
                else
                {
                    bool insert = await formRequestClass.InsertNewTravelDTRLog(controlNumber, dateLog, employeeId);
                    return insert;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetTravelDetails(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetTravelDetailedView(controlNumber);

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

        private async Task<string> GetMayorName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);

                if(!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NoteTravelRequest(int controlNumber, bool isNote, string notedBy, DateTime notedDate)
        {
            try
            {
                bool noteRequest = await generalFunctions.NotedTravelOrderRequest(controlNumber, isNote, notedBy, notedDate);
                return noteRequest;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
        
        private async Task<bool> ApproveTravelRequest(int controlNumber, bool isApprove, string approvedBy, DateTime approvedDate, 
            string status)
        {
            try
            {
                bool approve = await formRequestClass.ApproveTravelRequest(controlNumber, isApprove, approvedBy, approvedDate, status);
                return approve;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not this for the form logs
        private async Task<bool> AddTravelFormLog(DateTime logDate, string logDescription, int travelControlNumber, string caption)
        {
            try
            {
                bool addNewLeaveFormLog = await generalFunctions.AddTravelFormLog(logDate, logDescription, travelControlNumber, caption);

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
            dateDeparture.DataBindings.Add("Text", this, "DateDeparture");
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

        private void requestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async Task DisplayTravelDetails(int employeeId, int controlNumber, string dateFiled, string dateDeparture, int userId,
            string department, bool isNoteNull)
        {
            try
            {
                DataTable details = await GetTravelDetails(controlNumber);
                string name = await GetMayorName(userId);

                if(details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        travelDetailedView travelDetails = TravelDetails(controlNumber, dateFiled, dateDeparture, isNoteNull, userId,
                            department, name, employeeId);

                        AssignValueIfNotEmpty(row, "employeeFname", value => travelDetails.FirstName = value, "---------");
                        AssignValueIfNotEmpty(row, "employeeLname", value => travelDetails.LastName = value, "---------");
                        AssignValueIfNotEmpty(row, "employeeMname", value => travelDetails.MiddleName = value, "---------");
                        ParseAndAssignTime(row, "departureTime", value => travelDetails.DepartureTime = value, "---------");
                        ParseAndAssignTime(row, "returnTime", value => travelDetails.ReturnTime = value, "--------");
                        AssignValueIfNotEmpty(row, "purpose", value => travelDetails.Purpose = value, "--------");
                        AssignValueIfNotEmpty(row, "destination", value => travelDetails.Destination = value, "---------");
                        AssignValueIfNotEmpty(row, "remarks", value => travelDetails.Remarks = value, "---------");
                        AssignValueIfNotEmpty(row, "notedBy", value => travelDetails.NotedBy = value, "--------");
                        ParseAndAssignDateTime(row, "notedDate", value => travelDetails.NotedDate = value, "-------");

                        travelDetails.ShowDialog();
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

        private travelDetailedView TravelDetails(int controlNumber, string dateFiled, string dateDeparture, bool isNoteNull, int userId, 
            string department, string mayorName, int employeeId)
        {
            return new travelDetailedView(userId, this, department)
            {
                ControlNumber = controlNumber,
                DateFiled = dateFiled,
                DepartureDate = dateDeparture,
                IsNoteNull = isNoteNull,
                MayorName = mayorName,
                EmployeeId = employeeId
            };
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayTravelDetails(EmployeeId, ControlNumber, DateFiled, DateDeparture, _userId, _userDepartment, IsNoteNull);
            await _parent.DisplayRequest(_userId, _userDepartment);
        }

        private async Task<string> RetrieveMayorName(int userId)
        {
            try
            {
                string name = await GetMayorName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    ErrorMessages("There is an error in retrieving personnel's name please contact the IT office to resolve " +
                        "the situation", "Personnel Name Error Retrieval");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitNoteTravelRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate, bool isNoteNull)
        {
            try
            {
                if (isNoteNull)
                {
                    bool note = await NoteTravelRequest(controlNumber, isNoted, notedBy, notedDate);

                    if (note)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages(
                            "Error: Notarization Process Encountered an Issue\n\nWe regret to inform you that an error occurred during the notarization " +
                            "of the leave request. Please kindly attempt the process again later or contact the system administrator for " +
                            "prompt resolution. Thank you for your understanding.", "Notarization Error");
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

        private async Task<bool> SubmitApprovalTravelRequest(int controlNumber, bool isApproved, string approvedBy, 
            DateTime approvedDate, string status)
        {
            try
            {
                bool submitApproval = await ApproveTravelRequest(controlNumber, isApproved, approvedBy, approvedDate, status);

                if (submitApproval)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error encountered during the approval of Travel Request Control number: {controlNumber}. " +
                        $"Process is temporarily suspended untill further resolution.", "Travel Request Approval Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertSpecialPrivilegeLog(DateTime logDate, int controlNumber, string dateFiled, string departure)
        {
            try
            {
                string description = $"Travel Order enforce in date: {dateDeparture}";
                string remarks = $"Travel Order Filed at {dateFiled}";
                bool specialPrivilege = await InsertTravelSpecialPrivilegeLog(controlNumber, logDate, remarks, description);

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

        private async Task<bool> SubmitTravelFormLog(DateTime logDate, int travelControlNumber, string name, int userId, int employeeID,
            string employeeName)
        {
            try
            {
                string formLogDescription = "Travel Order Request Notation and Approval:" +
                    "||Approval and Notation done by Municipal Mayor: " + name + "( ID: " + userId.ToString() + " )" +
                    "||Employee in Request: " + employeeName + " (Employee ID: " + employeeID.ToString() + " )" +
                    "||Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Travel Order Request Notation and Approval";

                bool addTravelFormLog = await AddTravelFormLog(logDate, formLogDescription, travelControlNumber, formLogCaption);

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSystemLog(DateTime logdate, string name, string employeename, int userId, int employeeId)
        {
            try
            {
                string systemLog = "Travel Order Request Notation and Approval:" +
                        "||Done By Municipal Mayor: " + name + "( ID: " + userId.ToString() + " )" +
                        "||Employee in Request: " + employeename + " (Employee ID: " + employeeId.ToString() + " )" +
                        "||Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Travel Order Request Notation and Approval";

                bool addSystemLog = await AddSystemLogs(logdate, systemLog, systemLogCaption);

                if (addSystemLog) { return true; } 
                else 
                {
                    ErrorMessages("Failed to update system logs due to technical difficulties. Notify the employee of the approval status. " +
                        "Contact System Administrator for assistance. Thank you.", "Technical Difficulty");
                    return false; 
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void approveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await RetrieveMayorName(_userId);
                if (name == null)
                    return;

                bool note = await SubmitNoteTravelRequest(ControlNumber, IsNote, name, DateTime.Today, IsNoteNull);
                if (!note)
                    return;

                bool approve = await SubmitApprovalTravelRequest(ControlNumber, IsApprove, name, DateTime.Today, FormStatus);
                if (!approve)
                    return;

                bool specialPrivilege = await InsertSpecialPrivilegeLog(DateTime.Today, ControlNumber, DateFiled, DateDeparture);
                if (!specialPrivilege)
                    return;

                bool dtr = await SubmitDTRLog(EmployeeId, DateDeparture, ControlNumber);
                if (!dtr)
                    return;

                bool formLog = await SubmitTravelFormLog(DateTime.Today, ControlNumber, name, _userId, EmployeeId, EmployeeName);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, name, EmployeeName, _userId, EmployeeId);
                if(!systemLog)
                    return;

                SuccessMessage($"Approval Successful: The travel order request with " +
                    $"control number {ControlNumber} has been successfully approved. Please await further review and approval. " +
                    $"Thank you for your cooperation.", "Travel Order Request Approval");

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
