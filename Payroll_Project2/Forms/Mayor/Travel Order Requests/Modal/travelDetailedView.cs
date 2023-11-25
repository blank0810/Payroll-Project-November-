using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Travel_Order_Requests.Travel_Order_Requests_sub_user_control;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
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
using System.Xml.Linq;

namespace Payroll_Project2.Forms.Mayor.Travel_Order_Requests.Modal
{
    public partial class travelDetailedView : Form
    {
        private static int _userId;
        private static requestDataUC _parent;
        private static string _userDepartment;
        private static bool IsApproved = true;
        private static bool IsNoted = true;
        private static readonly int TotalHours = 8;
        private static readonly string FormStatus = ConfigurationManager.AppSettings.Get("ApproveStatus");
        private static readonly string TravelStatus = ConfigurationManager.AppSettings.Get("DefaultTravelStatus");
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();

        public int ControlNumber { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateFiled { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string ReturnTime { get; set; }
        public string Purpose { get; set; }
        public string Destination { get; set; }
        public string Remarks { get; set; }
        public string NotedBy { get; set; }
        public string NotedDate { get; set; }
        public string MayorName { get; set; }
        public bool IsNoteNull { get; set; }

        public travelDetailedView(int userId, requestDataUC parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }

        private async Task<bool> NoteTravelRequest(int controlNumber, bool isNote, string notedBy, DateTime notedDate)
        {
            try
            {
                bool noteRequest = await generalFunctions.NotedTravelOrderRequest(controlNumber, isNote, notedBy, notedDate);
                return noteRequest;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> ApproveTravelRequest(int controlNumber, bool isApprove, string approvedBy, DateTime approvedDate, 
            string status)
        {
            try
            {
                bool approve = await formRequestClass.ApproveTravelRequest(controlNumber, isApprove, approvedBy, approvedDate, status);
                return approve;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertDTRLog(int employeeId, DateTime logDate, string status, int totalHours)
        {
            try
            {
                bool insertDtr = await formRequestClass.AddDTRLog(employeeId, logDate, status, totalHours);
                return insertDtr;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
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
            controlNum.DataBindings.Add("Text", this, "ControlNumber");
            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            departureDate.DataBindings.Add("Text", this, "DepartureDate");
            departureTime.DataBindings.Add("Text", this, "DepartureTime");
            returnTime.DataBindings.Add("Text", this, "ReturnTime");
            purpose.DataBindings.Add("Text", this, "Purpose");
            destination.DataBindings.Add("Text", this, "Destination");
            remarks.DataBindings.Add("Text", this, "Remarks");
            notedBy.DataBindings.Add("Text", this, "NotedBy");
            notedDate.DataBindings.Add("Text", this, "NotedDate");
            mayor.DataBindings.Add("Text", this, "MayorName");

            CenterMayorName();
        }

        // Custom function that centers the mayor name, line, and label
        private void CenterMayorName()
        {
            // Calculate the center position of mayor label
            int mayorX = mayorJobDescription.Left + (mayorJobDescription.Width - mayor.Width) / 2;

            // Set the new position for mayor label
            mayor.Location = new Point(mayorX, mayor.Top);

        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void travelDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void travelDetailedView_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Escape key
            if (e.KeyChar == (char)Keys.Escape)
            {
                // Close the form
                this.Close();
            }
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

        private async Task<bool> SubmitDTRLog(int employeeId, string status, DateTime logDate, int totalHours)
        {
            try
            {
                bool insertDtr = await InsertDTRLog(employeeId, logDate, status, totalHours);

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
                bool note = await SubmitNoteTravelRequest(ControlNumber, IsNoted, MayorName, DateTime.Today, IsNoteNull);
                if (!note)
                    return;

                bool approve = await SubmitApprovalTravelRequest(ControlNumber, IsApproved, MayorName, DateTime.Today, FormStatus);
                if (!approve)
                    return;

                bool dtr = await SubmitDTRLog(EmployeeId, TravelStatus, DateTime.Today, TotalHours);
                if (!dtr)
                    return;

                bool formLog = await SubmitTravelFormLog(DateTime.Today, ControlNumber, MayorName, _userId, EmployeeId,
                    $"{FirstName} {LastName}");
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, MayorName, $"{FirstName} {LastName}", _userId, EmployeeId);
                if (!systemLog)
                    return;

                SuccessMessage($"Approval Successful: The travel order request with " +
                    $"control number {ControlNumber} has been successfully approved. Please await further review and approval. " +
                    $"Thank you for your cooperation.", "Travel Order Request Approval");

                this.Close();
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
