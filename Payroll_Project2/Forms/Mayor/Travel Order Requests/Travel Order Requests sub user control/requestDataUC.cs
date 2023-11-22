﻿using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        
        private async Task<bool> ApproveTravelRequest(int controlNumber, bool isApprove, string approvedBy, DateTime approvedDate)
        {
            try
            {
                bool approve = await formRequestClass.ApproveTravelRequest(controlNumber, isApprove, approvedBy, approvedDate);
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

        }

        private void requestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async Task DisplayTravelDetails(int employeeId, int controlNumber, string dateFiled, string dateDeparture, int userId,
            bool isNoteNull)
        {
            try
            {

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

        private void viewBtn_Click(object sender, EventArgs e)
        {

        }

        private async Task<string> RetrievePersonnelName(int userId)
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

        private async Task<bool> SubmitApprovalTravelRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate)
        {
            try
            {
                bool submitApproval = await ApproveTravelRequest(controlNumber, isApproved, approvedBy, approvedDate);

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
                string name = await RetrievePersonnelName(_userId);
                if (name == null)
                    return;

                bool note = await SubmitNoteTravelRequest(ControlNumber, IsNote, name, DateTime.Today, IsNoteNull);
                if (!note)
                    return;

                bool approve = await SubmitApprovalTravelRequest(ControlNumber, IsApprove, name, DateTime.Today);
                if (!approve)
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
