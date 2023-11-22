using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_order_request_sub_user_control;
using System;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Travel_Order.Modals
{
    public partial class travelOrderRequestDetailedView : Form
    {
        private static int _userId;
        private static requestDataUC _parent;
        private static bool IsNoted = true;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string DateFiled { get; set; }
        public string DateDeparture { get; set; }
        public string DepartureTime { get; set; }
        public string ReturnTime { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public string Remarks { get; set; }
        public string DepartmentHead {  get; set; }

        public travelOrderRequestDetailedView(int userId, requestDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
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
            controlNum.DataBindings.Add("Text", this, "ControlNumber");
            firstName.DataBindings.Add("Text", this, "EmployeeFirstName");
            lastName.DataBindings.Add("Text", this, "EmployeeLastName");
            middleName.DataBindings.Add("Text", this, "EmployeeMiddleName");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            departureDate.DataBindings.Add("Text", this, "DateDeparture");
            departureTime.DataBindings.Add("Text", this, "DepartureTime");
            returnTime.DataBindings.Add("Text", this, "ReturnTime");
            destination.DataBindings.Add("Text", this, "Destination");
            purpose.DataBindings.Add("Text", this, "Purpose");
            remarks.DataBindings.Add("Text", this, "Remarks");
            departmentHead.DataBindings.Add("Text", this, "DepartmentHead");
            CenterDepartmentHead();
        }

        // Custom function that centers the department head name
        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        private void travelOrderRequestDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
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
            if(!departmentHeadCheck.Checked)
            {
                ErrorMessages("Please check the checkbox to confirm the notation of the Travel Order Request.", "Travel Order Request Notation");
                departmentHeadCheck.Focus();
                departmentHeadCheck.Checked = true;
                return false;
            }
            else
            {
                return true;
            }
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

        private async void endorseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                    return;

                bool note = await NoteTravelRequest(ControlNumber, IsNoted, DepartmentHead, DateTime.Today);
                if (!note)
                    return;

                bool formLog = await SubmitTravelFormLog(DateTime.Today, ControlNumber, DepartmentHead, _userId, EmployeeID, 
                    $"{EmployeeFirstName} {EmployeeLastName}");
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, DepartmentHead, $"{EmployeeFirstName} {EmployeeLastName}", _userId, 
                    EmployeeID);
                if (!systemLog)
                    return;

                SuccessMessage($"Notarization Successful: Travel Order Request Control Number {ControlNumber}. The travel order request with " +
                    $"control number {ControlNumber} has been successfully notarized. Please await further review and approval. " +
                    $"Thank you for your cooperation.", "Travel Order Request Notarization");
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
