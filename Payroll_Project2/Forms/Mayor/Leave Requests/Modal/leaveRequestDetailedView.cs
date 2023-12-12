using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Mayor.Leave_Requests.Leave_Request_Sub_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Payroll_Project2.Forms.Mayor.Leave_Requests.Modal
{
    public partial class leaveRequestDetailedView : Form
    {
        #region Private, Public, and Static Variables

        private static int _userId;
        private static requestDataUC _parent;
        private static string _userDepartment;
        private static bool IsRecommend = true;
        private static bool IsApproved = true;
        private static bool IsWithPay = true;
        private static readonly int TotalHours = 8;
        private static string FormStatus;
        private static readonly string ApprovedStatus = ConfigurationManager.AppSettings.Get("ApproveStatus");
        private static readonly string DeniedStatus = ConfigurationManager.AppSettings.Get("DeniedStatus");
        private static readonly string LeaveStatus = ConfigurationManager.AppSettings.Get("DefaultLeaveStatus");
        private static string DeniedReason = "Not Applicable";
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();

        public int ApplicationNumber { get; set; }
        public int EmployeeID { get; set; }
        public string MayorName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Department { get; set; }
        public string DateFiled { get; set; }
        public string SalaryRate { get; set; }
        public string JobDescription { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDetails { get; set; }
        public string LeaveStartDate { get; set; }
        public string LeaveEndDate { get; set; }
        public string IsRecommended { get; set; }
        public string RecommendedBy { get; set; }
        public string CertifiedBy { get; set; }
        public string CertificationDate { get; set; }
        public decimal SickLeaveCreditsUsed { get; set; }
        public decimal VacationLeaveCreditsUsed { get; set; }
        public decimal SickLeaveCredits { get; set; }
        public decimal VacationLeaveCredits { get; set; }
        public decimal SickLeaveBalance { get; set; }
        public decimal VacationLeaveBalance { get; set; }
        public int NumberOfDays { get; set; }
        public bool IsSameDepartment { get; set; }
        public bool IsRecommendedNull { get; set; }

        #endregion

        public leaveRequestDetailedView(int userId, requestDataUC parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }

        #region Function for getters and add

        private async Task<bool> CheckLog(DateTime dateLog, int employeeId)
        {
            try
            {
                bool checkLog = await formRequestClass.CheckIfEmployeeHasLog(dateLog, employeeId);

                if (!checkLog)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertLeaveSpecialPrivilegeLog(int applicationNumber, DateTime dateLog, string remarks, 
            string description)
        {
            try
            {
                bool insertLog = await formRequestClass.AddLeaveSpecialPrivilegeLog(applicationNumber, dateLog, remarks, description);
                return insertLog;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertOrUpdateDTR(int applicationNumber, DateTime dateLog, int employeeId, bool hasLogOrNot)
        {
            try
            {
                if (hasLogOrNot)
                {
                    bool update = await formRequestClass.UpdateExistingLeaveDTRLog(applicationNumber, dateLog, employeeId);
                    return update;
                }
                else
                {
                    bool insert = await formRequestClass.InsertNewLeaveDTRLog(applicationNumber, dateLog, employeeId);
                    return insert;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> RecommendLeaveRequest(int applicationNumber, bool isRecommend, string recommendedBy, DateTime dateRecommended)
        {
            try
            {
                bool recommend = await generalFunctions.RecommendLeaveRequest(applicationNumber, isRecommend, recommendedBy, dateRecommended);
                return recommend;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> ApproveLeaveRequest(int applicationNumber, bool isApproved, string approvedBy, DateTime approvedDate, 
            bool isWithPay, int approvedNumberOfDays, string status, string reason)
        {
            try
            {
                bool approve = await formRequestClass.ApproveLeaveRequest(applicationNumber, isApproved, approvedBy, approvedDate, 
                    isWithPay, approvedNumberOfDays, status, reason);
                return approve;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> DeductLeaveCredits(int employeeId, string leaveType, decimal newCredits)
        {
            try
            {
                bool updateCredits = await formRequestClass.UpdateEmployeeLeaveCredits(employeeId, leaveType, newCredits);
                return updateCredits;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function responsible as an indicator if the logs is being added or not
        // It will forward true or false
        private async Task<bool> AddLeaveFormLog(DateTime logDate, string logDescription, int applicationNumber, string caption)
        {
            try
            {
                bool addNewLeaveFormLog = await generalFunctions.AddLeaveFormLog(logDate, logDescription, applicationNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible as an indicator if the logs is being added or not
        // It will forward true or false
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

        #endregion

        #region Custom Functions

        // Custom function that centers the mayor name, line, and label
        private void CenterMayorName()
        {
            // Calculate the center position of mayor label
            int mayorX = mayorJobDescription.Left + (mayorJobDescription.Width - mayor.Width) / 2;

            // Set the new position for mayor label
            mayor.Location = new Point(mayorX, mayor.Top);

        }

        // Custom function that displays error messages
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Custom function display successful transactions
        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Custom function for binding values into the UI controls
        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            mayor.DataBindings.Add("Text", this, "MayorName");
            firstName.DataBindings.Add("Text", this, "FirstName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            lastName.DataBindings.Add("Text", this, "LastName");
            departmentLabel.DataBindings.Add("Text", this, "Department");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            descriptionLabel.DataBindings.Add("Text", this, "JobDescription");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            leaveDetails.DataBindings.Add("Text", this, "LeaveDetails");
            leaveStartDate.DataBindings.Add("Text", this, "LeaveStartDate");
            leaveEndDate.DataBindings.Add("Text", this, "LeaveEndDate");
            recommendation.DataBindings.Add("Text", this, "IsRecommended");
            recommendedBy.DataBindings.Add("Text", this, "RecommendedBy");
            certifiedBy.DataBindings.Add("Text", this, "CertifiedBy");
            certificationDate.DataBindings.Add("Text", this, "CertificationDate");
            sickLeaveDeduct.DataBindings.Add("Text", this, "SickLeaveCreditsUsed");
            vacationLeaveDeduct.DataBindings.Add("Text", this, "VacationLeaveCreditsUsed");
            sickLeaveCredits.DataBindings.Add("Text", this, "SickLeaveCredits");
            vacationLeaveCredits.DataBindings.Add("Text", this, "VacationLeaveCredits");
            sickLeaveBalance.DataBindings.Add("Text", this, "SickLeaveBalance");
            vacationLeaveBalance.DataBindings.Add("Text", this, "VacationLeaveBalance");

            CenterMayorName();
        }

        #endregion

        #region Event Handlers

        private void leaveRequestDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void approveWithPay_CheckedChanged(object sender, EventArgs e)
        {
            if(approveWithPay.Checked)
            {
                approveWithoutPay.Checked = false;
                disapprove.Checked = false;
                IsApproved = true;
                IsWithPay = true;
                FormStatus = ApprovedStatus;
            }
        }

        private void approveWithoutPay_CheckedChanged(object sender, EventArgs e)
        {
            if(approveWithoutPay.Checked)
            {
                approveWithPay.Checked = false;
                disapprove.Checked = false;
                IsApproved = true;
                IsWithPay = false;
                FormStatus = ApprovedStatus;
            }
        }

        private void disapprove_CheckedChanged(object sender, EventArgs e)
        {
            if(disapprove.Checked)
            {
                approveWithoutPay.Checked = false;
                approveWithPay.Checked = false;
                IsApproved = false;
                IsWithPay = false;
                FormStatus = DeniedStatus;
                deniedReasonBox.Focus();
            }
        }

        private void deniedReasonBox__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(deniedReasonBox.Texts))
            {
                DeniedReason = deniedReasonBox.Texts;
            }
        }

        #endregion

        #region Encapsulated Functions

        private bool IsValid()
        {
            if(!approveWithPay.Checked && !approveWithoutPay.Checked && !disapprove.Checked)
            {
                ErrorMessage("Kindly ensure to select the appropriate type of approval required for this leave request.", 
                    "Approval/Disapproval Check Box");
                return false;
            }
            else if (disapprove.Checked && string.IsNullOrWhiteSpace(deniedReasonBox.Texts))
            {
                ErrorMessage("Please provide a reason for rejecting the leave request.", "Denied Reason");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> IsRecommendNeeded(string name, int applicationNumber, bool isRecommend, DateTime date, 
            bool isRecommendNull, bool isSameDepartment)
        {
            try
            {
                if(isRecommendNull && isSameDepartment)
                {
                    bool recommendLeave = await RecommendLeaveRequest(applicationNumber, isRecommend, name, date);

                    if(recommendLeave)
                    {
                        return true;
                    }

                    return false;
                }
                else if(isRecommendNull && !isSameDepartment)
                {
                    ErrorMessage("Due to the absence of a recommendation recorded for the request, the approval process is automatically suspended " +
                        "until a recommendation from the designated officer is provided.", "Recommendation Missing");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitApproval(string name, int applicationNumber, bool isApproved, bool isWithPay, int numberOfDays, 
            string deniedReason, DateTime approvedDate, string status, string reason)
        {
            try
            {
                bool approveRequest = await ApproveLeaveRequest(applicationNumber, isApproved, name, approvedDate, isWithPay, numberOfDays, 
                    status, reason);

                if(approveRequest)
                {
                    return true;
                }
                else
                {
                    ErrorMessage($"An error occurred during the approval process for the leave request with application number {applicationNumber}. " +
                        "Please attempt the operation again later. If the issue persists, kindly contact the System Administrator for resolution.",
                        "Leave Request Approval Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitLeaveCreditsDeduction(int employeeId, string leaveType, decimal vacationBalance, decimal sickBalance, 
            bool isApproved)
        {
            try
            {
                if(!isApproved)
                {
                    ErrorMessage("As the leave request has been denied, there is no requirement to deduct leave credits for this particular instance.", 
                        "Leave Denied Request");
                    return true;
                }
                else if(leaveType == "Sick Leave")
                {
                    bool deductCredits = await DeductLeaveCredits(employeeId, leaveType, sickBalance);
                    if (deductCredits)
                    {
                        MessageBox.Show("Sick Leave deduct");
                        return true;
                    }
                    else
                    {
                        ErrorMessage("An error has been encountered while deducting the leave credits. Although the approval process has been " +
                            "completed and the request is signed, the system faces challenges in deducting the appropriate leave credits. " +
                            "To rectify this issue, we kindly ask you to contact the system administrator promptly for the proper deduction of " +
                            "leave credits and resolution of the problem.", "Leave Credits Deduction Error");
                        return false;
                    }
                }
                else
                {
                    bool deductCredits = await DeductLeaveCredits(employeeId, leaveType, vacationBalance);
                    if (deductCredits)
                    {
                        MessageBox.Show("Vacation Leave deduct");
                        return true;
                    }
                    else
                    {
                        ErrorMessage("An error has been encountered while deducting the leave credits. Although the approval process has been " +
                            "completed and the request is signed, the system faces challenges in deducting the appropriate leave credits. " +
                            "To rectify this issue, we kindly ask you to contact the system administrator promptly for the proper deduction of " +
                            "leave credits and resolution of the problem.", "Leave Credits Deduction Error");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertSpecialPrivilegeLog(DateTime logDate, int applicationNumber, string startDate, string endDate, 
            string leaveType)
        {
            try
            {
                string description = $"{leaveType} starting from {startDate} to {endDate}";
                string remarks = $"{leaveType} Effective from {startDate} - {endDate}";
                bool specialPrivilege = await InsertLeaveSpecialPrivilegeLog(applicationNumber, logDate, remarks, description);

                if (specialPrivilege)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("There is an error encountered when inserting to the Special Privilege Log. Process is terminated.",
                        "Special Privilege Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitDTRLog(int employeeId, int applicationNumber, string startDate, string endDate, bool isApproved)
        {
            try
            {
                if(!isApproved)
                {
                    ErrorMessage("As the leave request has been denied, there is no requirement to integrate leave request for this particular " +
                        "instance to the DTR.", "DTR Integration");
                    return true;
                }
                else if(DateTime.TryParse(startDate, out DateTime startingDate) && DateTime.TryParse(endDate, out DateTime endingDate))
                {
                    for (DateTime logDate = startingDate; logDate <= endingDate; logDate = endingDate.AddDays(1))
                    {
                        bool hasLog = await CheckLog(logDate, employeeId);

                        bool insertDtr = await InsertOrUpdateDTR(applicationNumber, logDate, employeeId, hasLog);

                        if (!insertDtr)
                        {
                            ErrorMessage($"An error occurred while integrating the leave request into the Daily Time Record (DTR) on " +
                                $"{logDate: MMM dd, yyyy}. " +
                                $"The process has been terminated. Please contact the system administrator for prompt resolution.",
                                "Integration Error: Daily Time Record Log");
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    ErrorMessage($"An error occurred while integrating the leave request into the Daily Time Record (DTR) " +
                        $"specifically in the conversion of Leave Date Coverages. " +
                        $"The process has been terminated. Please contact the system administrator for prompt resolution.",
                        "Integration Error: Daily Time Record Log");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitLeaveFormLog(DateTime logDate, string name, int userId, string employeeName, int employeeId, 
            int applicationNumber)
        {
            try
            {
                string logDescription = "Municipal Mayor who approve the Request: " + name + " ( ID: " + userId.ToString() + " )" +
                            "||Employee: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                            "||Leave Application Number: " + applicationNumber.ToString() +
                            "||Approval Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = $"Leave Request Approval By Municipal Mayor";

                bool submitFormLog = await AddLeaveFormLog(logDate, logDescription, applicationNumber, logCaption);

                if(submitFormLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage($"An error occurred while attempting to add the approval of the leave request with application number " +
                        $"{applicationNumber} to the Form Logs. Since the approval has been completed, please notify the employee to review " +
                        $"the updated status. If this issue persists, kindly contact the System Administrator for further assistance.", 
                        "Form Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSystemLog(DateTime logDate, string name, string employeeName, int employeeId, int userId)
        {
            try
            {
                string systemLogDescription = "Municipal Mayor who Approve the Request: " + name + "( ID: " + userId.ToString() + " )" +
                            "||Employee: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                            "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string systemLogCaption = $"Approval for the Application for Leave";

                bool submitLog = await AddSystemLogs(logDate, systemLogDescription, systemLogCaption);

                if(submitLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage($"An error occurred while attempting to add the approval of the leave request with application number " +
                        $"to the Form Logs. Since the approval has been completed, please notify the employee to review " +
                        $"the updated status. If this issue persists, kindly contact the System Administrator for further assistance.",
                        "System Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                    return;

                bool recommend = await IsRecommendNeeded(MayorName, ApplicationNumber, IsRecommend, DateTime.Today,
                    IsRecommendedNull, IsSameDepartment);
                if (!recommend)
                    return;

                bool approved = await SubmitApproval(MayorName, ApplicationNumber, IsApproved, IsWithPay, NumberOfDays, DeniedReason, DateTime.Today,
                    FormStatus, DeniedReason);
                if (!approved)
                    return;

                bool deductCredit = await SubmitLeaveCreditsDeduction(EmployeeID, LeaveType, VacationLeaveBalance, SickLeaveBalance, IsApproved);
                if (!deductCredit)
                    return;

                bool specialPrivilege = await InsertSpecialPrivilegeLog(DateTime.Today, ApplicationNumber, LeaveStartDate, LeaveEndDate, LeaveType);
                if (!specialPrivilege)
                    return;

                bool dtrLog = await SubmitDTRLog(EmployeeID,ApplicationNumber, LeaveStartDate, LeaveEndDate, IsApproved);
                if (!dtrLog)
                    return;

                bool formLog = await SubmitLeaveFormLog(DateTime.Today, MayorName, _userId, $"{FirstName} {LastName}", EmployeeID, ApplicationNumber);
                if (!formLog)
                    return;

                bool systemLog = await SubmitSystemLog(DateTime.Today, MayorName, $"{FirstName} {LastName}", EmployeeID, _userId);
                if (!systemLog)
                    return;

                SuccessMessage($"The approval for leave request application number {ApplicationNumber} has been successfully processed. " +
                    "Kindly notify the employee to review the updated status of the request.", "Leave Request Approval");
                this.Close();
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
