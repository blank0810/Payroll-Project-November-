using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Travel_Order_Management.Travel_Management_sub_user_control
{
    public partial class travelDataUC : UserControl
    {
        private static int _userId;
        private static travelApproveUC _parent;
        private static bool IsNoted = true;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formClass formClass = new formClass();

        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeePicture { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }

        public travelDataUC(int userId, travelApproveUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
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
                formClass = new formClass();
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
                formClass = new formClass();
                bool addSystemLogs = await generalFunctions.AddSystemLogs(logdate, logdescription, caption);

                return addSystemLogs;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for forwarding the Personnel Name
        // It returns the name in the form of string value
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

        private async Task TravelDetailedView(int controlNumber, int userId)
        {
            try
            {
                DataTable details = await GetTravelDetailedView(controlNumber);
                string personnelName = await RetrievePersonnelName(userId);
                viewTravelModal travel = new viewTravelModal(userId, this);

                if(details != null && personnelName != null)
                {
                    foreach (DataRow row in  details.Rows)
                    {
                        travel.EmployeeName = EmployeeName;
                        travel.EmployeeId = EmployeeId;
                        travel.PersonnelName = personnelName;

                        if (!string.IsNullOrEmpty(row["orderControlNumber"].ToString()) && int.TryParse(row["orderControlNumber"].ToString(), 
                            out int orderControlNumber))
                        {
                            travel.ControlNumber = orderControlNumber;
                        }
                        else
                        {
                            travel.ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFiled"].ToString()) && DateTime.TryParse(row["dateFiled"].ToString(), 
                            out DateTime dateFiled))
                        {
                            travel.DateFiled = $"{dateFiled: MMM dd, yyyy}";
                        }
                        else
                        {
                            travel.DateFiled = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["dateDeparture"].ToString()) && DateTime.TryParse(row["dateDeparture"].ToString(), 
                            out DateTime departureDate))
                        {
                            travel.DepartureDate = $"{departureDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            travel.DepartureDate = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["departureTime"].ToString()) && DateTime.TryParse(row["departureTime"].ToString(), 
                            out DateTime departureTime))
                        {
                            travel.DepartureTime = $"{departureTime: hh:mm tt}";
                        }
                        else
                        {
                            travel.DepartureTime = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["returnTime"].ToString()) && DateTime.TryParse(row["returnTime"].ToString(), 
                            out DateTime returnTime))
                        {
                            travel.ReturnTime = $"{returnTime: hh:mm tt}";
                        }
                        else
                        {
                            travel.ReturnTime = "---------";


                        }

                        if (!string.IsNullOrEmpty(row["destination"].ToString()))
                        {
                            travel.Destination = $"{row["destination"]}";
                        }
                        else
                        {
                            travel.Destination = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["purpose"].ToString()))
                        {
                            travel.Purpose = $"{row["purpose"]}";
                        }
                        else
                        {
                            travel.Purpose = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["remarks"].ToString()))
                        {
                            travel.Remarks = $"{row["remarks"]}";
                        }
                        else
                        {
                            travel.Remarks = "--------";
                        }
                    }

                    travel.ShowDialog();
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

        private void DataBinding()
        {
            empid.DataBindings.Add("Text", this, "EmployeeId");
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeePicture");
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
        }

        private void travelDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await TravelDetailedView(ControlNumber, _userId);
            await _parent.DisplayTravelList();
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
                string name = await GetPersonnelName(userId);

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
                        "prompt resolution. Thank you for your understanding.","Notarization Error");
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

        private async void proceedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await RetrievePersonnelName(_userId);
                if (name == null)
                    return;

                bool note = await NoteTravelRequest(ControlNumber, IsNoted, name, DateTime.Today);
                if (!note)
                    return;

                bool formLog = await SubmitTravelFormLog(DateTime.Today, ControlNumber, name, _userId, EmployeeId, EmployeeName);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, name, EmployeeName, _userId, EmployeeId);
                if (!systemLog)
                    return;

                SuccessMessage($"Notarization Successful: Travel Order Request Control Number {ControlNumber}. The travel order request with " +
                    $"control number {ControlNumber} has been successfully notarized. Please await further review and approval. " +
                    $"Thank you for your cooperation.","Travel Order Request Notarization");
                await _parent.DisplayTravelList();
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
