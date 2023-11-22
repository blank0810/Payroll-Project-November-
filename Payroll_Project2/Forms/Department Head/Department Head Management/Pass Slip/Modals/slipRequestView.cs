using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Pass_Slip.Pass_Slip_Request_sub_user_control;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Pass_Slip.Modals
{
    public partial class slipRequestView : Form
    {
        private static int _userId;
        private static slipRequestDataUC _parent;
        private static bool IsNoted = true;
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; } 
        public string DepartmentHead { get; set; }
        public int ControlNumber { get; set; }
        public string SlipDate { get; set; }
        public string SlipStartingTime { get; set; }
        public string SlipEndingTime { get; set; }
        public string Destination { get; set; }

        public slipRequestView(int userId, slipRequestDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
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
            slipDate.DataBindings.Add("Text", this, "SlipDate");
            controlNum.DataBindings.Add("Text", this, "ControlNumber");
            slipStartingTime.DataBindings.Add("Text", this, "SlipStartingTime");
            slipEndingTime.DataBindings.Add("Text", this, "SlipEndingTime");
            destination.DataBindings.Add("Text", this, "Destination");
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

        private void slipRequestView_Load(object sender, EventArgs e)
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

        private bool IsValid()
        {
            if(!departmentHeadCheck.Checked)
            {
                ErrorMessages("Please check the checkbox to confirm the notation of the Pass Slip Request.", "Pass Slip Request Notation");
                return false;
            }
            else
            {
                return true;
            }
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

        private async void endorseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                    return;

                bool noteSlip = await NoteSlipRequest(ControlNumber, IsNoted, DepartmentHead, DateTime.Now);
                if (!noteSlip)
                    return;

                bool formLog = await SubmitSlipFormLog(DateTime.Now, ControlNumber, EmployeeName, DepartmentHead, EmployeeId, _userId);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Now, EmployeeName, EmployeeId, _userId, DepartmentHead);
                if (!systemLog)
                    return;

                SuccessMessages($"The Pass Slip Request with Control Number {ControlNumber} has been successfully notarized and recorded. " +
                    "Please await further review and approval.", "Pass Slip Notation Submission");
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
