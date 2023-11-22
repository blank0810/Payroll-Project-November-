using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal;
using Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Pass_Slip_Management;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data
{
    public partial class passSlipData : UserControl
    {
        private static int _userId;
        private static slipApproveUC _parent;
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static bool IsNoted = true;

        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeePicture { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }

        public passSlipData(int userId, slipApproveUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NotePassSlip(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool notePassSlip = await generalFunctions.NotedPassSlipRequest(controlNumber, isNoted, notedBy, notedDate);
                return notePassSlip;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                string name = await formClass.GetPersonnelName(userId);
                return name;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            empid.DataBindings.Add("Text", this, "EmployeeId");
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeePicture");
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
        }

        public async Task ShowPassSlip(int controlNumber)
        {
            viewSlipModal slip = new viewSlipModal(_userId, this);
            DataTable slipDetails = await GetSlipDetailedView(controlNumber);
            string name = await GetPersonnelName(_userId);

            if (slipDetails != null && name != null)
            {
                foreach (DataRow row in slipDetails.Rows)
                {
                    slip.ControlNumber = controlNumber;
                    slip.EmployeeName = EmployeeName;
                    slip.EmployeeId = EmployeeId;
                    slip.PersonnelName = name;

                    if (!string.IsNullOrEmpty(row["slipDate"].ToString()) && DateTime.TryParse(row["slipDate"].ToString(), 
                        out DateTime slipDate))
                    {
                        slip.SlipDate = $"{slipDate: MMMM dd, yyyy}";
                    }
                    else
                    {
                        slip.SlipDate = "--------";
                    }

                    if (!string.IsNullOrEmpty(row["slipStartingTime"].ToString()))
                    {
                        slip.SlipStartingTime = $"{row["slipStartingTime"]: hh:mm tt}";
                    }
                    else
                    {
                        slip.SlipStartingTime = "--------";
                    }

                    if (!string.IsNullOrEmpty(row["slipEndingTime"].ToString()))
                    {
                        slip.SlipEndingTime = $"{row["slipEndingTime"]: hh:mm tt}";
                    }
                    else
                    {
                        slip.SlipEndingTime = "---------";
                    }

                    if (!string.IsNullOrEmpty(row["slipDestination"].ToString()))
                    {
                        slip.Destination = $"{row["slipDestination"]}";
                    }
                    else
                    {
                        slip.Destination = "--------";
                    }
                }

                slip.ShowDialog();
            }
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await ShowPassSlip(ControlNumber);
            await _parent.DisplaySlipList();
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

        private async Task<string> PersonnelName(int userId)
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
                    ErrorMessages("We regret to inform you that an error occurred while attempting to retrieve the personnel name. " +
                        "Please accept our apologies for any inconvenience caused.", "Personnel Name Retrieval Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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

        private async void proceedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = await PersonnelName(_userId);
                if (name == null)
                    return;

                bool noteSlip = await NoteSlipRequest(ControlNumber, IsNoted, name, DateTime.Now);
                if (!noteSlip)
                    return;

                bool formLog = await SubmitSlipFormLog(DateTime.Now, ControlNumber, EmployeeName, name, EmployeeId, _userId);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Now, EmployeeName, EmployeeId, _userId, name);
                if (!systemLog)
                    return;

                SuccessMessages($"The Pass Slip Request with Control Number {ControlNumber} has been successfully notarized and recorded. " +
                    "Please await further review and approval.", "Pass Slip Notation Submission");
               await _parent.DisplaySlipList();
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
