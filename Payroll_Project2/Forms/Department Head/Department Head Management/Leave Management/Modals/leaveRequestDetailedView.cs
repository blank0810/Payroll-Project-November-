using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_Request_Sub_User_Control;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Modals
{
    public partial class leaveRequestDetailedView : Form
    {
        private static int _userId;
        private static leaveDataUC _parent;
        private static bool IsRecommended = true;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formManagementClass leaveManagement = new formManagementClass();

        public int EmployeeId { get; set; }
        public int ApplicationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentHead { get; set; }
        public string Department { get; set; }
        public string DateFiled { get; set; }
        public string SalaryRate { get; set; }
        public string JobDescription { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDetails { get; set; }
        public string LeaveStartDate { get; set; }
        public string LeaveEndDate { get; set; }

        public leaveRequestDetailedView(int userId, leaveDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            departmentHead.DataBindings.Add("Text", this, "DepartmentHead");
            departmentLabel.DataBindings.Add("Text", this, "Department");
            departmentName.DataBindings.Add("Text", this, "Department");
            dateFile.DataBindings.Add("Text", this, "DateFiled");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            descriptionLabel.DataBindings.Add("Text", this, "JobDescription");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            startingDate.DataBindings.Add("Text", this, "LeaveStartDate");
            endingDate.DataBindings.Add("Text", this, "LeaveEndDate");

            CenterDepartmentHead();
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

        private void leaveRequestDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Custom function that centers the department head name
        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = departmentName.Left + (departmentName.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
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
        private bool IsAuthorized()
        {
            if(!approveBtn.Checked && !disapproveBtn.Checked)
            {
                ErrorMessage("Please ensure to choose one option for the leave recommendation", "Leave Recommendation Options");
                return false;
            }
            else

            {
                return true;
            }
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
                    ErrorMessage("We are encountering an issue while attempting to submit the recommendation for the leave request. " +
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
                string logDescription = "Department Head who Recommend the Request: " + name + " ( ID: " + userId.ToString() + " )" +
                            "||Employee: " + nameEmployee + " (Employee ID: " + employeeId.ToString() + " )" +
                            "||Leave Application Number: " + applicationNumber.ToString() +
                            "||Recommendation Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = $"Recommended by {department} for the Application for Leave";

                bool newLog = await AddLeaveFormLog(DateTime.Today, logDescription, applicationNumber, logCaption);

                if (newLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We have encountered a technical difficulty while attempting to add the request to the form logs. " +
                                "As the recommendation has already been done, please await further approval. " +
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
                string systemLogDescription = "Department Head who Recommend the Request: " + name + "( ID: " + userId.ToString() + " )" +
                            "||Employee: " + employeeName + " (Employee ID: " + employeeId.ToString() + " )" +
                            "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string systemLogCaption = $"Recommendation by {department} for the Application for Leave";

                bool addLog = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("System log insertion encountered an issue. We sincerely apologize for any inconvenience caused. " +
                                    "We kindly request your patience while our team resolves this matter. " +
                                    "As the recommendation has already been done, please await for further approval. " +
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
                if (!IsAuthorized())
                    return;

                bool isRecommendNeed = await IsRecommendation(DepartmentHead, ApplicationNumber, IsRecommended, DateTime.Now);
                if (!isRecommendNeed)
                    return;

                bool formLog = await AddNewFormLog(DepartmentHead, EmployeeId, $"{FirstName} {LastName}", _userId, Department, ApplicationNumber);
                if (!formLog)
                    return;

                bool systemLog = await AddNewSystemLog(DepartmentHead, $"{FirstName} {LastName}", EmployeeId, _userId, Department);
                if (!systemLog)
                    return;

                SuccessMessage("The recommendation is already done. Please await further approval to be done by the Municipal Mayor.",
                                    "Notarization for Application for Leave Submitted: Pending Approval from the Municipal Mayor");
                this.Close();
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
