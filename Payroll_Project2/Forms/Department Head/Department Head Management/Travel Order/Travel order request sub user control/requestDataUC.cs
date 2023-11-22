using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Department_Head.Travel_Order.Modals;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_order_request_sub_user_control
{
    public partial class requestDataUC : UserControl
    {
        private static int _userId;
        private static travelOrderRequestUC _parent;
        private static string _department;
        private static bool IsNoted = true;
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string DateDeparture { get; set; }

        public requestDataUC(int userId, travelOrderRequestUC parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetTravelDetailedView(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetTravelDetailedView(controlNumber);

                if (details != null)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetDepartmentHeadName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);
                
                if (name != null)
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

        private async Task<bool> SubmitNoteTravelRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool note = await generalFunctions.NotedTravelOrderRequest(controlNumber, isNoted, notedBy, notedDate);
                return note;
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
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            employeeId.DataBindings.Add("Text", this, "EmployeeID");
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            dateDeparture.DataBindings.Add("Text", this, "DateDeparture");
        }

        private async Task DisplayTravelDetails(int controlNumber, string dateFiled, string dateDeparture, int userId, int employeeId)
        {
            try
            {
                DataTable details = await GetTravelDetailedView(controlNumber);
                string name = await GetDepartmentHeadName(userId);
                travelOrderRequestDetailedView travel = new travelOrderRequestDetailedView(_userId, this);

                if (details != null && name != null)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        travel.ControlNumber = controlNumber;
                        travel.DateFiled = dateFiled;
                        travel.DateDeparture = dateDeparture;
                        travel.DepartmentHead = name;
                        travel.EmployeeID = employeeId;

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            travel.EmployeeFirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            travel.EmployeeFirstName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            travel.EmployeeLastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            travel.EmployeeLastName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeMname"].ToString()))
                        {
                            travel.EmployeeMiddleName = $"{row["employeeMname"]}";
                        }
                        else
                        {
                            travel.EmployeeMiddleName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["departureTime"].ToString()) && DateTime.TryParse(row["departureTime"].ToString(), 
                            out DateTime departureTime))
                        {
                            travel.DepartureTime = $"{departureTime: hh:mm tt}";
                        }
                        else
                        {
                            travel.DepartureTime = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["returnTime"].ToString()) && DateTime.TryParse(row["returnTime"].ToString(), 
                            out DateTime returnTime))
                        {
                            travel.ReturnTime = $"{returnTime: hh:mm tt}";
                        }
                        else
                        {
                            travel.ReturnTime = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["destination"].ToString()))
                        {
                            travel.Destination = $"{row["destination"]}";
                        }
                        else
                        {
                            travel.Destination = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["purpose"].ToString()))
                        {
                            travel.Purpose = $"{row["purpose"]}";
                        }
                        else
                        {
                            travel.Purpose = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["remarks"].ToString()))
                        {
                            travel.Remarks = $"{row["remarks"]}";
                        }
                        else
                        {
                            travel.Remarks = "---------";
                        }

                        travel.ShowDialog();
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

        private void requestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayTravelDetails(ControlNumber, DateFiled, DateDeparture, _userId, EmployeeID);
            await _parent.DisplayRequestList(_department, _userId);
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<string> RetrievePersonnelName(int userId)
        {
            try
            {
                string name = await GetDepartmentHeadName(userId);

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

        private async Task<bool> NoteTravelRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool note = await SubmitNoteTravelRequest(controlNumber, isNoted, notedBy, notedDate);

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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitTravelFormLog(DateTime logDate, int travelControlNumber, string name, int userId, int employeeID,
            string employeeName)
        {
            try
            {
                string formLogDescription = "Travel Order Request Notation:" +
                    "||Department Head Notation Done by: " + name + "( ID: " + userId.ToString() + " )" +
                    "||Employee in Request: " + employeeName + " (Employee ID: " + employeeID.ToString() + " )" +
                    "||Notation Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Travel Order Request Notation";

                bool addTravelFormLog = await AddTravelFormLog(logDate, formLogDescription, travelControlNumber, formLogCaption);

                if (addTravelFormLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("We have encountered a technical difficulty while attempting to add the request to the form logs. " +
                        "As your request has already been submitted, please await further approval and confirmation. " +
                        "Thank you for your understanding.", "Technical Difficulty: Adding Request to Form Logs");
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
                string systemLog = "Travel Order Request Notation:" +
                        "||Department Head Notation Done By: " + name + "( ID: " + userId.ToString() + " )" +
                        "||Employee in Request: " + employeename + " (Employee ID: " + employeeId.ToString() + " )" +
                        "||Notation Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Travel Order Request Notation";

                bool addSystemLog = await AddSystemLogs(logdate, systemLog, systemLogCaption);

                if (addSystemLog) { return true; } else { return false; }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void notedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await RetrievePersonnelName(_userId);
                if (name == null)
                    return;

                bool note = await NoteTravelRequest(ControlNumber, IsNoted, name, DateTime.Today);
                if (!note)
                    return;

                bool formLog = await SubmitTravelFormLog(DateTime.Today, ControlNumber, name, _userId, EmployeeID, EmployeeName);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, name, EmployeeName, _userId, EmployeeID);
                if (!systemLog)
                    return;

                SuccessMessage($"Notarization Successful: Travel Order Request Control Number {ControlNumber}. The travel order request with " +
                    $"control number {ControlNumber} has been successfully notarized. Please await further review and approval. " +
                    $"Thank you for your cooperation.", "Travel Order Request Notarization");

                await _parent.DisplayRequestList(_department, _userId);
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
