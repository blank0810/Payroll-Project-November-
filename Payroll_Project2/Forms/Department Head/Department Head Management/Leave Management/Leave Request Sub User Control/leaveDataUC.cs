using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Department_Head.Leave_Management.Modals;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_Request_Sub_User_Control
{
    public partial class leaveDataUC : UserControl
    {
        private static int _userId;
        private static leaveRequestsUC _parent;
        private static string _department;
        private static bool IsRecommended = true;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formManagementClass leaveManagementClass = new formManagementClass();

        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public int ApplicationNumber { get; set; }
        public string DateFiled { get; set; }
        public string LeaveType { get; set; }
        public string DateCoverage { get; set; }

        public leaveDataUC(int userId, leaveRequestsUC parent, string department)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _department = department;
        }

        // This function is responsible for recommendation of the leave request
        private async Task<bool> RecommendLeaveRequest(int applicationNumber, bool isRecommended, string recommendedBy,
            DateTime dateRecommended)
        {
            try
            {
                bool approveRequest = await generalFunctions.RecommendLeaveRequest(applicationNumber, isRecommended, recommendedBy, dateRecommended);
                return approveRequest;
            }
            catch
            (SqlException sql)
            { throw sql; }
            catch (Exception ex) { throw ex; }
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

        private async Task<DataTable> GetLeaveDetails(int applicationNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetLeaveDetailedView(applicationNumber);

                if(details != null)
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

        private async Task<string> GetDepartmentHeadName(int employeeId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(employeeId);

                if(name != null)
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DisplayLeaveDetails(int applicationNumber, string dateFiled, string leaveType, int userId, int employeeId)
        {
            try
            {
                DataTable details = await GetLeaveDetails(applicationNumber);
                string name = await GetDepartmentHeadName(userId);
                leaveRequestDetailedView leave = new leaveRequestDetailedView(_userId, this);

                if (details != null && name != null)
                {
                    foreach (DataRow row in  details.Rows)
                    {
                        leave.ApplicationNumber = applicationNumber;
                        leave.DateFiled = dateFiled;
                        leave.LeaveType = leaveType;
                        leave.DepartmentHead = name;
                        leave.EmployeeId = employeeId;

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            leave.FirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            leave.FirstName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            leave.LastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            leave.LastName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            leave.Department = $"{row["departmentName"]}";
                        }
                        else
                        {
                            leave.Department = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateDescription"].ToString()))
                        {
                            leave.SalaryRate = $"{row["salaryRateDescription"]}";
                        }
                        else
                        {
                            leave.SalaryRate = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {
                            leave.JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            leave.JobDescription = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                        {
                            leave.LeaveType = $"{row["leaveType"]}";
                        }
                        else
                        {
                            leave.LeaveType = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveDetails"].ToString()))
                        {
                            leave.LeaveDetails = $"{row["leaveDetails"]}";
                        }
                        else
                        {
                            leave.LeaveDetails = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveStartDate"].ToString()))
                        {
                            leave.LeaveStartDate = $"{row["leaveStartDate"]}";
                        }
                        else
                        {
                            leave.LeaveStartDate = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveEndDate"].ToString()))
                        {
                            leave.LeaveEndDate = $"{row["leaveEndDate"]}";
                        }
                        else
                        {
                            leave.LeaveEndDate = "--------";
                        }

                        leave.ShowDialog();
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBinding()
        {
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            employeeId.DataBindings.Add("Text", this, "EmployeeId");
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            dateCoverage.DataBindings.Add("Text", this, "DateCoverage");
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeaveDetails(ApplicationNumber, DateFiled, LeaveType, _userId, EmployeeId);
            await _parent.DisplayRequest();
        }

        private void leaveDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
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

        // Custom function that handles authorization
        private async Task<string> IsAuthorized(int userId)
        {
            try
            {
                string personnelName = await GetDepartmentHeadName(userId);

                if (!string.IsNullOrEmpty(personnelName))
                {
                    return personnelName;
                }
                else
                {
                    ErrorMessage("There is no retrieved Personnel Name", "Invalid name");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function that check if the requests need recommendation or not
        private async Task<bool> IsRecommendation(string name, int applicationNumber, bool isRecommended, DateTime date)
        {
            try
            {
                bool recommendRequest = await RecommendLeaveRequest(applicationNumber, isRecommended, name, date);

                if (recommendRequest)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We are encountering an issue while attempting to submit the certification for the leave request. " +
                        "Please contact the IT officers in regarding to this situation! As the situation is still not resolve we will " +
                        "temporarily halt the notarization.", " Issues with Leave Notarization");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function that handles to add new System Logs
        private async Task<bool> AddNewFormLog(string name, int employeeId, string nameEmployee, int userId, string department, int applicationNumber)
        {
            try
            {
                string logDescription = "Department Head who Notarized the Request: " + name + " ( ID: " + userId.ToString() + " )" +
                            "||Employee: " + nameEmployee + " (Employee ID: " + employeeId.ToString() + " )" +
                            "||Leave Application Number: " + applicationNumber.ToString() +
                            "||Notarization Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = $"Notarization by {department} for the Application for Leave";

                bool newLog = await AddLeaveFormLog(DateTime.Today, logDescription, applicationNumber, logCaption);

                if (newLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We have encountered a technical difficulty while attempting to add the request to the form logs. " +
                                "As the notarization has already been done, please await further approval. " +
                                "Thank you for your understanding.", "Technical Difficulty: Recording the Notarization to Form Logs");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        //Custom function responsible for adding new system log
        private async Task<bool> AddNewSystemLog(string name, string employeeName, int employeeId, int userId, string department)
        {
            try
            {
                string systemLogDescription = "Human Resource Officer who Certified: " + name + "( ID: " + userId.ToString() + " )" +
                            "||Employee: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                            "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string systemLogCaption = $"Notarization by {department} for the Application for Leave";

                bool addLog = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("System log insertion encountered an issue. We sincerely apologize for any inconvenience caused. " +
                                    "We kindly request your patience while our team resolves this matter. " +
                                    "As the notarization has already been done, please await for further approval. " +
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
                // IMPORTANT NOTE: TO PUT A VERIFICATION BEFORE PROCEEDING INTO SUBMITTING THE CERTIFICATION
                string name = await IsAuthorized(_userId);
                if (string.IsNullOrEmpty(name))
                    return;

                bool isRecommendNeed = await IsRecommendation(name, ApplicationNumber, IsRecommended, DateTime.Now);
                if (!isRecommendNeed)
                    return;

                bool formLog = await AddNewFormLog(name, EmployeeId, EmployeeName, _userId, _department, ApplicationNumber);
                if (!formLog)
                    return;

                bool systemLog = await AddNewSystemLog(name, EmployeeName, EmployeeId, _userId, _department);
                if (!systemLog)
                    return;

                SuccessMessage("The notarization is already done. Please await further approval to be done by the Municipal Mayor.",
                                    "Notarization for Application for Leave Submitted: Pending Approval from the Municipal Mayor");

                await _parent.DisplayRequest();
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
