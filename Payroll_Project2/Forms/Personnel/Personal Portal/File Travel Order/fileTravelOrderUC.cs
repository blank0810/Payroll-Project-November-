using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Personal_Portal.File_Travel_Order.File_Travel_Order_sub_user_control;
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

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Travel_Order
{
    public partial class fileTravelOrderUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formClass formClass = new formClass();
        private static readonly string formTitle = ConfigurationManager.AppSettings["DefaultTravelTitle"];
        private static string formStatus = "Pending";

        public int ControlNumber { get ; set; }
        private DateTime DepartureDate { get; set; }
        private TimeSpan DepartureTime { get; set; }
        private TimeSpan ReturnTime { get; set; }
        private string Destination { get; set; }
        private string Purpose { get; set; }
        private string Remarks { get; set; }

        public fileTravelOrderUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<bool> SubmitTravelRequest(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture,
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks, string status,
            string formName, string createdBy, DateTime createdDate)

        {
            try
            {
                bool submit = await generalFunctions.AddTravelOrder(orderControlNumber, employeeId, dateFiled, dateDeparture, departureTime,
                    returnTime, destination, purpose, remarks, status, formName, createdBy, createdDate);
                return submit;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the employee is allowed to file a request or not
        // It will forward values only true or false
        private async Task<bool> GetPendingCount(int employeeId, string status)
        {
            try
            {
                bool count = await generalFunctions.GetTravelPendingCount(employeeId, status);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not
        // Only forwards true or false
        private async Task<bool> AddTravelFormLog(DateTime logDate, string logDescription, int travelControlNumber, string caption)
        {
            try
            {
                formClass = new formClass();
                bool addNewLeaveFormLog = await generalFunctions.AddTravelFormLog(logDate, logDescription, travelControlNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not
        // Only forwards true or false
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the Recently submitted travel order
        private async Task<DataTable> GetRecentTravelOrder(int employeeId, int month, int year)
        {
            try
            {
                DataTable list = await generalFunctions.GetRecentTravelList(employeeId, month, year);
                return list;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task DataBinding(int userId, int month, int year)
        {
            try
            {
                controlNumber.DataBindings.Add("Text", this, "ControlNumber");
                await DisplayRecentTravel(userId, month, year);
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Error");
            }
        }

        private async Task DisplayRecentTravel(int employeeId, int month, int year)
        {
            try
            {
                recentListPanel.Controls.Clear();
                DataTable list = await GetRecentTravelOrder(employeeId, month, year);

                if(list != null)
                {
                    travelOrderDataUC[] travel = new travelOrderDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        travel[i] = new travelOrderDataUC();
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["orderControlNumber"].ToString()) && int.TryParse(row["orderControlNumber"].ToString(), 
                            out int controlNumber))
                        {
                            travel[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            travel[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateDeparture"].ToString()) && DateTime.TryParse(row["dateDeparture"].ToString(), 
                            out DateTime dateDeparture))
                        {
                            travel[i].DepartureDate = $"{dateDeparture: MMM dd, yyyy}";
                        }
                        else
                        {
                            travel[i].DepartureDate = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["reason"].ToString()))
                        {
                            travel[i].Purpose = $"{row["reason"]}";
                        }
                        else
                        {
                            travel[i].Purpose = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["destination"].ToString()))
                        {
                            travel[i].Destination = $"{row["destination"]}";
                        }
                        else
                        {
                            travel[i].Destination = "-------";
                        }

                        recentListPanel.Controls.Add(travel[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQl Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Error");
            }
        }

        private async void fileTravelOrderUC_Load(object sender, EventArgs e)
        {
            await DataBinding(_userId, DateTime.Now.Month, DateTime.Now.Year);
        }

        private void departureDate_ValueChanged(object sender, EventArgs e)
        {
            DepartureDate = departureDate.Value;
        }

        private void departureTime_ValueChanged(object sender, EventArgs e)
        {
            DepartureTime = departureTime.Value.TimeOfDay;
        }

        private void returnTime_ValueChanged(object sender, EventArgs e)
        {
            ReturnTime = returnTime.Value.TimeOfDay;
        }

        private void destination__TextChanged(object sender, EventArgs e)
        {
            Destination = destination.Texts;
        }

        private void purpose__TextChanged(object sender, EventArgs e)
        {
            Purpose = purpose.Texts;
        }

        private void remarks__TextChanged(object sender, EventArgs e)
        {
            Remarks = remarks.Texts;
        }

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

            if (DepartureDate < DateTime.Today ||
                     departureDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                     departureDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                ErrorMessages("Kindly ensure that the Departure Date is set to a future date, specifically after " +
                    DateTime.Today.ToString("D") + ", and that it corresponds to a weekday rather than a weekend.",
                    "Departure Date Validation: Please Verify");
                return false;
            }
            else if (departureTime.Value.TimeOfDay < new TimeSpan(8, 0, 0) ||
                (departureTime.Value.TimeOfDay >= new TimeSpan(12, 0, 0) && departureTime.Value.TimeOfDay <= new TimeSpan(13, 0, 0)) ||
                departureTime.Value.TimeOfDay > new TimeSpan(17, 0, 0))
            {
                ErrorMessages("The selected departure time is not valid. Please make sure that the departure time is between 8:00 AM and 12:00 PM, " +
                    "excluding 12:00 PM to 1:00 PM, and should not be after 5:00 PM.",
                    "Invalid Departure Time");
                return false;
            }
            else if (returnTime.Value.TimeOfDay < new TimeSpan(8, 0, 0) ||
                     (returnTime.Value.TimeOfDay >= new TimeSpan(12, 0, 0) && returnTime.Value.TimeOfDay <= new TimeSpan(13, 0, 0)) ||
                     returnTime.Value.TimeOfDay > new TimeSpan(17, 0, 0))
            {
                ErrorMessages("The selected return time is not valid. Please make sure that the return time is between 8:00 AM and 12:00 PM, " +
                    "excluding 12:00 PM to 1:00 PM, and not after 5:00 PM.",
                    "Invalid Return Time");
                return false;
            }
            else if (ReturnTime <= DepartureTime || ReturnTime - DepartureTime < TimeSpan.FromHours(1))
            {
                ErrorMessages("The return time must be later than the departure time and have a minimum of 1 hour after the departure time. " +
                    "The return time has been adjusted.", "Return Time Error");
                returnTime.Value = departureTime.Value.AddHours(1);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(destination.Texts) ||
                     string.IsNullOrWhiteSpace(purpose.Texts) ||
                     string.IsNullOrWhiteSpace(remarks.Texts))
            {
                ErrorMessages("Please ensure that all fields are filled in. Destination, purpose, and remarks are required.",
                    "Incomplete Information");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<string> RetrieveEmployeeName(int employeeId)
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
                    ErrorMessages("There is an error in retrieving personnel's name please contact the IT office to resolve " +
                        "the situation", "Personnel Name Error Retrieval");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> CheckPending(int employeeId, string status, string name)
        {
            try
            {
                bool isAllowed = await GetPendingCount(employeeId, status);

                if (isAllowed)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("The employee " + name + " is not currently allowed to submit a travel order request. " +
                        "They have a pending request that needs to be resolved first.", "Pending Travel Request");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitRequest(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture,
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks, string status,
            string formName, string createdBy, DateTime createdDate)
        {
            try
            {
                bool submit = await SubmitTravelRequest(orderControlNumber, employeeId, dateFiled, dateDeparture, departureTime, returnTime,
                    destination, purpose, remarks, status, formName, createdBy, createdDate);

                if (submit)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error in submitting the Travel Order Request. Please contact the system administrators " +
                            $"for quick resolution", "Request Submission Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitTravelFormLog(DateTime logDate, int travelControlNumber, string name, int employeeID)
        {
            try
            {
                string formLogDescription = "Travel Order Request Submitted:" +
                    "||Employee who filed the request: " + name + " (Employee ID: " + employeeID.ToString() + " )" +
                    "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Travel Order Request Submission";

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

        private async Task<bool> SubmitSystemLog(DateTime logdate, string name, int employeeId)
        {
            try
            {
                string systemLog = "Travel Order Request Submitted:" +
                        "||Employee who filed the request: " + name + " (Employee ID: " + employeeId.ToString() + " )" +
                        "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Travel Order Request Submission";

                bool addSystemLog = await AddSystemLogs(logdate, systemLog, systemLogCaption);

                if (addSystemLog) { return true; } else { return false; }
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

                string name = await RetrieveEmployeeName(_userId);
                if (name == null)
                    return;

                bool pending = await CheckPending(_userId, formStatus, name);
                if (!pending)
                    return;

                bool submit = await SubmitRequest(ControlNumber, _userId, DateTime.Now, DepartureDate, DepartureTime, ReturnTime, Destination,
                    Purpose, Remarks, formStatus, formTitle, name, DateTime.Now);
                if (!submit)
                    return;

                bool formLog = await SubmitTravelFormLog(DateTime.Now, ControlNumber, name, _userId);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Now, name, _userId);
                if (!systemLog)
                    return;

                SuccessMessage($"The Travel Order with the control number {ControlNumber} is already filed and submitted. Please wait " +
                    $"for further review and approval", "Travel Order Request Submission");
                await _parent.FileTravelOrder();
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQl Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Error");
            }
        }
    }
}
