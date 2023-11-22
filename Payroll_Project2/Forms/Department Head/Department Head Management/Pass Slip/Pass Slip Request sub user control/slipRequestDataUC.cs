using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Department_Head.Pass_Slip.Modals;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Pass_Slip.Pass_Slip_Request_sub_user_control
{
    public partial class slipRequestDataUC : UserControl
    {
        private static int _userId;
        private static passSlipRequestUC _parent;
        private static string _department;
        private static bool IsNoted = true;
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }

        public slipRequestDataUC(int userId, passSlipRequestUC parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        private async Task<DataTable> GetSlipDetailedView(int controlNumber)
        {
            try
            {
                DataTable slipDetails = await generalFunctions.GetSlipDetailedView(controlNumber);

                if (slipDetails != null)
                {
                    return slipDetails;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NotePassSlip(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool notePassSlip = await generalFunctions.NotedPassSlipRequest(controlNumber, isNoted, notedBy, notedDate);
                return notePassSlip;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetDepartmentHeadName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);
                return name;
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
        }

        private async Task DisplaySlipDetails(int controlNumber, int userId, string employeeName, int employeeId)
        {
            try
            {
                DataTable details = await GetSlipDetailedView(controlNumber);
                string name = await GetDepartmentHeadName(userId);
                slipRequestView slipRequest = new slipRequestView(userId, this);

                if (details != null && name != null)
                {
                    foreach(DataRow row in  details.Rows)
                    {
                        slipRequest.EmployeeName = employeeName;
                        slipRequest.EmployeeId = employeeId;
                        slipRequest.DepartmentHead = name;
                        slipRequest.ControlNumber = controlNumber;

                        if (!string.IsNullOrEmpty(row["slipDate"].ToString()) && DateTime.TryParse(row["slipDate"].ToString(), 
                            out DateTime slipDate))
                        {
                            slipRequest.SlipDate = $"{slipDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            slipRequest.SlipDate = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["slipStartingTime"].ToString()) && DateTime.TryParse(row["slipStartingTime"].ToString(), 
                            out DateTime startingTime))
                        {
                            slipRequest.SlipStartingTime = $"{startingTime: hh:mm tt}";
                        }
                        else
                        {
                            slipRequest.SlipStartingTime = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["slipEndingTime"].ToString()) && DateTime.TryParse(row["slipEndingTime"].ToString(), 
                            out DateTime endingTime))
                        {
                            slipRequest.SlipEndingTime = $"{endingTime: hh:mm tt}";
                        }
                        else
                        {
                            slipRequest.SlipEndingTime = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["slipDestination"].ToString()))
                        {
                            slipRequest.Destination = $"{row["slipDestination"]}";
                        }

                        slipRequest.ShowDialog();
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

        private void slipRequestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void passSlipData_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }

        private async Task<string> DepartmentHeadName(int userId)
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
                    ErrorMessages("We regret to inform you that an error occurred while attempting to retrieve the personnel name. " +
                        "Please accept our apologies for any inconvenience caused.", "Personnel Name Retrieval Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NoteSlipRequest(int controlNumber, bool isNoted, string name, DateTime notedDate)
        {
            try
            {
                bool noteRequest = await NotePassSlip(controlNumber, isNoted, name, notedDate);

                if (noteRequest)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("We regret to inform you that an error occurred while submitting the notation for the Pass Slip Request. " +
                            "Please contact the IT Office for prompt resolution.", "Notation Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipFormLog(DateTime logDate, int slipControlNumber, string employeeName, string name, int employeeId,
            int userId)
        {
            try
            {
                string formLogDescription = "Pass Slip Notation Submitted:" +
                    "||Department Head who Noted: " + name + "( ID: " + userId.ToString() + " )" +
                    "||Employee: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                    "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Pass Slip Notation Submission";

                bool submitFormLog = await AddSlipFormLog(logDate, formLogDescription, slipControlNumber, formLogCaption);

                if (submitFormLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("We regret to inform you that a technical issue has arisen while attempting to add the notation your request to the " +
                        "form logs. Since the notation has already been submitted, kindly await further approval and confirmation. " +
                        "We appreciate your patience and understanding.", "Technical Difficulty: Adding Notation to Form Logs");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSystemLog(DateTime logDate, string employeeName, int employeeId, int userId, string name)
        {
            try
            {
                string systemLog = "Pass Slip Request Submitted:" +
                "||Department Head who Noted: " + name + "( ID: " + userId.ToString() + " )" +
                "||Employee: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Pass Slip Notation Submission";

                bool submitSystemLog = await AddSystemLogs(logDate, systemLog, systemLogCaption);

                if (submitSystemLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("We regret to inform you that an issue occurred while inserting the system log. " +
                        "We apologize for any inconvenience this may cause. Our team is actively working to resolve this matter. " +
                        "As your notation has already been submitted, please await further approval and confirmation. " +
                        "Thank you for your understanding.", "System Log Insertion Issue");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplaySlipDetails(ControlNumber, _userId, EmployeeName, EmployeeID);
            await _parent.DisplayRequestList(_department, _userId);
        }

        private async void notedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await DepartmentHeadName(_userId);
                if (name == null)
                    return;

                bool noteSlip = await NoteSlipRequest(ControlNumber, IsNoted, name, DateTime.Now);
                if (!noteSlip)
                    return;

                bool formLog = await SubmitSlipFormLog(DateTime.Now, ControlNumber, EmployeeName, name, EmployeeID, _userId);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Now, EmployeeName, EmployeeID, _userId, name);
                if (!systemLog)
                    return;

                SuccessMessages($"The Pass Slip Request with Control Number {ControlNumber} has been successfully notarized and recorded. " +
                    "Please await further review and approval.", "Pass Slip Notation Submission");
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
