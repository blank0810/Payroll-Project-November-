using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal
{
    public partial class viewSlipModal : Form
    {
        private static int _userId;
        private static passSlipData _parent;
        public static formClass formClass = new formClass();
        public static generalFunctions generalFunctions = new generalFunctions();
        private static bool IsNoted = true;

        public int ControlNumber { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PersonnelName { get; set; }
        public string SlipDate {  get; set; }
        public string SlipStartingTime { get; set; }
        public string SlipEndingTime { get; set; }
        public string Destination {  get; set; }

        public viewSlipModal(int userId, passSlipData parent)
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
                formClass = new formClass();
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
                formClass = new formClass();
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
            departmentHead.DataBindings.Add("Text", this, "PersonnelName");
        }

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        private void viewSlipModal_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void departmentHeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(departmentHeadCheck.Checked)
            {
                IsNoted = true;
            }
            else
            {
                IsNoted = false;
            }
        }

        private void departmentHead_TextChanged(object sender, EventArgs e)
        {
            CenterDepartmentHead();
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValid()
        {
            if(!departmentHeadCheck.Checked)
            {
                ErrorMessages("Kindly ensure the checkbox is selected to proceed with the notation of the pass slip request. " +
                    "Thank you for your attention.", "Checkbox Selection Required for Pass Slip Notation");
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
                    "||Personnel who Noted: " + name + "( ID: " + userId.ToString() + " )" +
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
                "||Personnel who Submitted: " + name + "( ID: " + userId.ToString() + " )" +
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

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                    return;

                bool noteRequest = await NoteSlipRequest(ControlNumber, IsNoted, PersonnelName, DateTime.Today);
                if (!noteRequest)
                    return;

                bool slipFormLog = await SubmitSlipFormLog(DateTime.Today, ControlNumber, EmployeeName, PersonnelName, EmployeeId, _userId);
                if (!slipFormLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, EmployeeName, EmployeeId, _userId, PersonnelName);
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
                MessageBox.Show(ex.Message, "Exception Error");
            }
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
