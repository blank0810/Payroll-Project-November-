using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data
{
    public partial class applicationForLeaveData : UserControl
    {

        private static leaveApproveUC _parent;
        private static int _userId;
        private static formClass formClass = new formClass();
        private static readonly string mayorRole = "Mayor";
        private static bool IsCertified = true;
        private static bool IsRecommended = true;
        private static int _numberOfDays = 15;
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmployeeImage { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public int ApplicationNumber { get; set; }
        public string Department { get; set; }
        public string LeaveType { get; set; }
        public string DateFiled { get; set; }
        public bool IsSameDepartment { get; set; }

        public applicationForLeaveData(int userId, leaveApproveUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        //This function will be responsible for retrieving the Mayor Name
        private async Task<string> GetMayorName(string mayorRole)
        {
            try
            {
                formClass = new formClass();
                string mayorName = await formClass.GetMayorName(mayorRole);

                if (!string.IsNullOrEmpty(mayorName))
                {
                    return mayorName;
                }
                else
                {
                    return "No Mayor Available";
                }
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
                bool approveRequest = await formClass.RecommendLeaveRequest(applicationNumber, isRecommended, recommendedBy, dateRecommended);
                return approveRequest;
            }
            catch 
            (SqlException sql)
            { throw sql; } catch (Exception ex) { throw ex; }   
        }

        // This function is responsible for retrieving the Personnel Name of the one currently logged in
        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                formClass = new formClass();
                string name = await generalFunctions.GetPersonnelName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    return "-----";
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible for updating the leave request so that it will be certified
        private async Task<bool> UpdateLeave(int applicationNumber, string certifiedBy, DateTime certifiedDate, bool isCertify)
        {
            try
            {
                formClass = new formClass();
                bool result = await formClass.UpdateLeaveRequest(applicationNumber, certifiedBy, certifiedDate, isCertify);

                return result;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function responsible as an indicator if the logs is being added or not
        // It will forward true or false
        private async Task<bool> AddLeaveFormLog(DateTime logDate, string logDescription, int applicationNumber, string caption)
        {
            try
            {
                formClass = new formClass();
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
                formClass = new formClass();
                bool addSystemLogs = await generalFunctions.AddSystemLogs(logdate, logdescription, caption);

                return addSystemLogs;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible to forward application details to view form
        private async void LeaveDetails(int applicationNumber)
        {
            try
            {
                viewLeaveModal leave = new viewLeaveModal(_userId, this);
                formClass = new formClass();
                DataTable leaveDetails = await generalFunctions.GetLeaveDetailedView(applicationNumber);
                string personnelName = await GetPersonnelName(_userId);
                string mayorName = await GetMayorName(mayorRole);

                if (leaveDetails != null && leaveDetails.Rows.Count > 0)
                {
                    foreach(DataRow row in leaveDetails.Rows)
                    {
                        leave.ApplicationNumber = applicationNumber;

                        if (decimal.TryParse(row["CreditsUsed"].ToString(), out decimal sickCredits))
                        {
                            leave.CreditsUsed = sickCredits;
                        }
                        else
                        {
                            leave.CreditsUsed = 0;
                        }

                        if (DateTime.TryParse(row["dateFile"].ToString(), out DateTime dateFiled))
                        {
                            leave.DateFiled = dateFiled;
                        }

                        if (DateTime.TryParse(row["leaveStartDate"].ToString(), out DateTime startDate))
                        {
                            leave.LeaveStartDate = startDate;
                        }

                        if (DateTime.TryParse(row["leaveEndDate"].ToString(), out DateTime endDate))
                        {
                            leave.LeaveEndDate = endDate;
                        }

                        if (!string.IsNullOrEmpty(row["isRecommended"].ToString()) && bool.TryParse(row["isRecommended"].ToString(), 
                            out bool recommendation))
                        {
                            leave.IsRecommended = recommendation;
                        }

                        leave.EmployeeID = EmployeeID;
                        leave.CertifiedDate = DateTime.Now;
                        leave.FirstName = row["employeeFname"].ToString();
                        leave.LastName = row["employeeLname"].ToString();
                        leave.MiddleName = row["employeeMname"].ToString();
                        leave.MayorName = mayorName;
                        leave.PersonnelName = personnelName;
                        leave.Department = row["departmentName"].ToString();
                        leave.DepartmentHead = row["recommendedBy"].ToString();
                        leave.SalaryRate = row["salaryRateDescription"].ToString();
                        leave.JobDescription = row["employeeJobDesc"].ToString();
                        leave.LeaveType = row["leaveType"].ToString();
                        leave.LeaveDetails = row["leaveDetails"].ToString();
                        leave.IsSameDepartment = IsSameDepartment;
                    }

                    MessageBox.Show($"{EmployeeID}");
                    leave.ShowDialog();
                    await _parent.LeaveList(DateTime.Now, _userId, _numberOfDays);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler that handles if the view button is clicked
        private async void viewBtn_Click(object sender, EventArgs e)
        {
            LeaveDetails(ApplicationNumber);
            await _parent.LeaveList(DateTime.Today, _userId, _numberOfDays);
        }

        // Event handler that handles if this user control is loaded into the system
        private void applicationForLeaveData_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Custom function for binding the values into the UI controls
        private void DataBinding()
        {
            Binding nameBinding = new Binding("Text", this, "EmployeeName");
            nameBinding.Format += new ConvertEventHandler(NameBinding_Format);
            empName.DataBindings.Add(nameBinding);

            Binding departmentBinding = new Binding("Text", this, "Department");
            departmentBinding.Format += new ConvertEventHandler(DepartmentBinding_Format);
            departmentLabel.DataBindings.Add(departmentBinding);

            Binding application = new Binding("Text", this, "ApplicationNumber");
            application.Format += new ConvertEventHandler(ApplicationBinding_Format);
            applicationNumber.DataBindings.Add(application);

            Binding employeeId = new Binding("Text", this, "EmployeeID");
            employeeId.Format += new ConvertEventHandler(EmployeeId_Format);
            empid.DataBindings.Add(employeeId);

            empPicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
        }

        // Custom function for formatting the employee name
        private void NameBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "No Data to Show!")
            {
                proceedBtn.Visible = false;
                viewBtn.Visible = false;
                empName.ForeColor = Color.Red;
            }
            else
            {
                empName.ForeColor = Color.Black;
            }
        }

        // Custom function for formatting the department name
        private void DepartmentBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "No Data to Show!")
            {
                departmentLabel.ForeColor = Color.Red;
            }
            else
            {
                departmentLabel.ForeColor = Color.Black;
            }
        }

        // Custom function for formatting application number
        private void ApplicationBinding_Format(object sender, ConvertEventArgs e)
        {
            if (int.TryParse(e.ToString(), out int id))
            {
                if (id == 0)
                {
                    applicationNumber.ForeColor = Color.Red;
                }
                else
                {
                    applicationNumber.ForeColor = Color.Black;
                }
            }
            else
            {
                applicationNumber.ForeColor = Color.Black;
            }
        }

        // Custom function for formatting employee Id 
        private void EmployeeId_Format(object sender, ConvertEventArgs e)
        {
            if (int.Parse(e.Value.ToString()) == 0)
            {
                empid.ForeColor = Color.Red;
            }
            else
            {
                empid.ForeColor = Color.Black;
            }
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
                string personnelName = await GetPersonnelName(userId);

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function that check if the requests need recommendation or not
        private async Task<bool> IsRecommendationNeed(string name)
        {
            try
            {
                if (IsSameDepartment)
                {
                    DialogResult result = MessageBox.Show(
                        "Do note that as the employee in question belongs to the Human Resources Office, " +
                        "it is the designated personnel who will handle the recommendation. " +
                        "Would the personnel like to recommend this request?",
                        "Leave Request Recommendation", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

                    if (result == DialogResult.Yes)
                    {
                        bool recommendRequest = await RecommendLeaveRequest(ApplicationNumber, IsRecommended, name, DateTime.Now);

                        if (recommendRequest)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorMessage("We are encountering an issue while attempting to submit the certification for the leave request. " +
                                "Please contact the IT officers in regarding to this situation! As the situation is still not resolve we will " +
                                "temporarily halt the certification.", " Issues with Leave Certification");
                            return false;
                        }
                    }
                    else
                    {
                        IsRecommended = false;
                        bool recommendRequest = await RecommendLeaveRequest(ApplicationNumber, IsRecommended, name, DateTime.Now);

                        if (recommendRequest)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorMessage("We are encountering an issue while attempting to submit the certification for the leave request. " +
                                "Please contact the IT officers in regarding to this situation! As the situation is still not resolve we will " +
                                "temporarily halt the certification.", " Issues with Leave Certification");
                            return false;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function that handles the certification of leave requests
        private async Task<bool> CertifyLeave(string name)
        {
            try
            {
                bool updateLeave = await UpdateLeave(ApplicationNumber, name, DateTime.Today, IsCertified);

                if (updateLeave)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We are encountering an issue while attempting to submit the certification for the leave request." +
                            " Please contact the IT officers in regarding to this situation! As the situation is still not resolve we will " +
                            "temporarily halt the certification.",
                            " Issues with Leave Certification");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function that handles to add new System Logs
        private async Task<bool> AddNewFormLog(string name)
        {
            try
            {
                string logDescription = "Human Resource Officer who Certified the Request: " + name + " ( ID: " + _userId.ToString() + " )" +
                            "||Employee: " + EmployeeName + " (Employee ID: " + EmployeeID.ToString() + " )" +
                            "||Leave Application Number: " + ApplicationNumber.ToString() +
                            "||Certification Date and Time: " + DateTime.Now.ToString("f");

                string logCaption = "Certification by Human Resource Office for the Application for Leave";

                bool newLog = await AddLeaveFormLog(DateTime.Today, logDescription, ApplicationNumber, logCaption);

                if (newLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("We have encountered a technical difficulty while attempting to add the request to the form logs. " +
                                "As the certification has already been done, please await further approval. " +
                                "Thank you for your understanding.", "Technical Difficulty: Adding the Certification to Form Logs");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        //Custom function responsible for adding new system log
        private async Task<bool> AddNewSystemLog(string name)
        {
            try
            {
                string systemLogDescription = "Human Resource Officer who Certified: " + name + "( ID: " + _userId.ToString() + " )" +
                            "||Employee: " + EmployeeName + " (Employee ID: " + EmployeeID.ToString() + " )" +
                            "||Submission Date and Time: " + DateTime.Now.ToString("f");

                string systemLogCaption = "Certification by Human Resource Office for the Application for Leave";

                bool addLog = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessage("System log insertion encountered an issue. We sincerely apologize for any inconvenience caused. " +
                                    "We kindly request your patience while our team resolves this matter. " +
                                    "As the certification has already been done, please await for further approval. " +
                                    "Thank you for your understanding.", "System Log Insertion Issue");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Event handler if the proceed button is clicked
        private async void proceedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // IMPORTANT NOTE: TO PUT A VERIFICATION BEFORE PROCEEDING INTO SUBMITTING THE CERTIFICATION
                string name = await IsAuthorized(_userId);
                if (string.IsNullOrEmpty(name))
                    return;

                bool isRecommendNeed = await IsRecommendationNeed(name);
                if (!isRecommendNeed)
                    return;

                bool certify = await CertifyLeave(name);
                if (!certify)
                    return;

                bool formLog = await AddNewFormLog(name);
                if (!formLog)
                    return;

                bool systemLog = await AddNewSystemLog(name);
                if (!systemLog)
                    return;

                SuccessMessage("The certification is already done. Please await further approval to be done by the Municipal Mayor.",
                                    "Certification for Application for Leave Submitted: Pending Approval from the Municipal Mayor");

                await _parent.LeaveList(DateTime.Now, _userId, _numberOfDays);
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
