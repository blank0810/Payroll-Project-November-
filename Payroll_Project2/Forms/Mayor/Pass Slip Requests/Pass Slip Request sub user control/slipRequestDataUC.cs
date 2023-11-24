using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
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

namespace Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Pass_Slip_Request_sub_user_control
{
    public partial class slipRequestDataUC : UserControl
    {
        private static int _userId;
        private static passSlipRequestsUC _parent;
        private static string _userDepartment;
        private static bool IsNote = true;
        private static bool IsApprove = true;
        private static readonly int TotalHours = 4;
        private static readonly string FormStatus = ConfigurationManager.AppSettings.Get("ApproveStatus");
        private static readonly string SlipStatus = ConfigurationManager.AppSettings.Get("DefaultSlipStatus");
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public TimeSpan TimeUsed { get; set; }
        public bool IsNoteNull { get; set; }

        public slipRequestDataUC(int userId, passSlipRequestsUC parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = department;
        }

        private async Task<DataTable> GetSlipDetails(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetSlipDetailedView(controlNumber);

                if(details != null && details.Rows.Count > 0)
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

                if (!string.IsNullOrEmpty(name))
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

        private async Task<TimeSpan> GetEmployeeSlipHours(int employeeId, int month, int year)
        {
            try
            {
                TimeSpan hours = await generalFunctions.GetEmployeeSlipHours(employeeId, month, year);
                return hours;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NoteSlipRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool slipNote = await generalFunctions.NotedPassSlipRequest(controlNumber, isNoted, notedBy, notedDate);
                return slipNote;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> ApproveSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate, string status)
        {
            try
            {
                bool approveRequest = await formRequestClass.ApproveSlipRequest(controlNumber, isApproved, approvedBy, approvedDate, status);
                return approveRequest;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> DeductSlipHous(int employeeId, int month, int year, TimeSpan newHours)
        {
            try
            {
                bool deduct = await formRequestClass.UpdateEmployeeSlipHours(employeeId, month, year, newHours);
                return deduct;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void slipRequestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {

        }

        private async Task<string> RetrieveMayorName(int userId)
        {
            try
            {
                string name = await GetMayorName(userId);

                return string.IsNullOrEmpty(name) ? name : null;
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitNoteSlipRequest(int controlNumber, bool isNote, string notedBy, DateTime notedDate, bool isNoteNull)
        {
            try
            {
                if(!isNoteNull)
                {
                    SuccessMessage("Since the notation of this request is already done by the respective office head it will automatically proceed to " +
                        "approve the Pass Slip Request.", "Pass Slip Request Notation Notice");
                    return true;
                }
                else
                {
                    bool submitNote = await NoteSlipRequest(controlNumber, isNote, notedBy, notedDate);

                    if(submitNote)
                    {
                        return true;
                    }

                    ErrorMessages("There is an error encountered during the notation of pass slip request. The process is temporarily terminated " +
                        "please try again later and if the error persists please contact the system administrator for resolution", "Pass Slip Notation " +
                        "Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex;}
        }

        private async Task<bool> SubmitApprovalSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate, 
            string status)
        {
            try
            {
                bool approve = await ApproveSlipRequest(controlNumber, isApproved, approvedBy, approvedDate, status);

                if(approve)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"There is an error encoutered approving the payslip request with control number: {controlNumber}. Please " +
                        $"try again later and if error persists please contact the system administrator for resolution", "Pass Slip Request Approval " +
                        "Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitDeductionSlipHours(int employeeId, string dateFiled, TimeSpan hoursUsed)
        {
            try
            {
                if(!string.IsNullOrEmpty(dateFiled) && DateTime.TryParse(dateFiled, out DateTime parsedDate))
                {
                    TimeSpan balanceHour = await GetEmployeeSlipHours(employeeId, parsedDate.Month, parsedDate.Year);

                    if (balanceHour !=  TimeSpan.Zero)
                    {
                        TimeSpan newHour = balanceHour - hoursUsed;

                        bool updateHour = await DeductSlipHous(employeeId, parsedDate.Month, parsedDate.Year, newHour);

                        if(updateHour)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorMessages("There is an error encountered during the deduction of the employee's Pass Slip Hour balance. " +
                                "Please contact the system administrator to deduct the employee's slip hours and resolution", 
                                "Pass Slip Hours Deduction " +
                                "Error");
                            return false;
                        }
                            
                    }

                    ErrorMessages("There is an error in retrieving the Employee's Pass Slip hours. Please notify the system administrator for this " +
                        "error for quick resolution", "Employee Slip Hours Balance Retrieval Error");
                    return false;
                }
                else
                {
                    ErrorMessages("The chosen date filed is cannot be converted results into not be able to update the Employee's Slip Hours. " +
                        "Please contact the system administrator to deduct the employee's slip hours and resolution", "Pass Slip Hours Deduction " +
                        "Error");
                    return false;
                }

            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSlipFormLog(int controlNumber, int employeeId, int userId, DateTime logDate, string employeeName, 
            string mayorName)
        {
            try
            {

            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }
    }
}
