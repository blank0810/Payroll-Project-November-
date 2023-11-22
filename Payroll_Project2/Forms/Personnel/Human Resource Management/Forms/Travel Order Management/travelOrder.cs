using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents.Modal;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents
{
    public partial class travelOrder : UserControl
    {
        #region The variables inside are the one needed for the controls in User Interface in order to change the values dynamically

        private static newDashboard _parent;
        private static int _userId;
        private static formClass formClass;
        private static readonly string formTitle = ConfigurationManager.AppSettings["DefaultTravelTitle"];
        private static string formStatus = "Pending";
        private static appForLeave appForLeave;
        private static personnelPassSlipUC passSlipUC;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        public string Mayor { get; set; }
        private int EmployeeID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public string PersonnelDepartment { get; set; }
        private string EmployeeDepartment { get; set; }
        private string DepartmentHead { get; set; }
        private bool IsNoted { get; set; }
        private string MiddleName { get; set; }
        public DateTime DateFiled { get; set; }
        private DateTime DateDeparture { get; set; }
        private TimeSpan DepartureTime { get; set; }
        private TimeSpan ReturnTime { get; set; }
        private string Destination { get; set; }
        private string Purpose { get; set; }
        private string Remarks { get; set; }

        #endregion

        public travelOrder(newDashboard parent, int userId)
        {
            InitializeComponent();
            _parent = parent;
            _userId = userId;
        }

        #region The functions inside is the one responsible for the communicating of the formclass and forwarding the values to the User Interface dynamically

        // This function serves as an indicator if the employee is allowed to file a request or not
        // It will forward values only true or false
        private async Task<bool> GetPendingCount(int employeeId, string status)
        {
            try
            {
                formClass = new formClass();
                bool count = await generalFunctions.GetTravelPendingCount(employeeId, status);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the request is been submitted or not
        // Specifically this function forward the request with notation from the HR officer if the requested employee is from HR
        private async Task<bool> AddTravel(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture, 
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks, 
            string status, string formName, string createdBy, DateTime createdDate, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                formClass = new formClass();
                bool addTravel = await formClass.AddPersonnelTravelOrder(orderControlNumber, employeeId, dateFiled, dateDeparture, 
                    departureTime, returnTime, destination, purpose, remarks, status, formName, createdBy, createdDate, isNoted, notedBy, 
                    notedDate);

                return addTravel;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the request is been submitted or not
        // Only forwards the values true or false
        private async Task<bool> NewTravelRequest(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture,
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks,
            string status, string formName, string createdBy, DateTime createdDate)
        {
            try
            {
                formClass = new formClass();
                bool addTravel = await generalFunctions.AddTravelOrder(orderControlNumber, employeeId, dateFiled, dateDeparture,
                    departureTime, returnTime, destination, purpose, remarks, status, formName, createdBy, createdDate);

                return addTravel;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not
        // Only forwards true or false
        private async Task<bool> AddTravelFormLog(DateTime logDate, string logDescription, int travelControlNumber, string caption)
        {
            try
            {
                formClass = new formClass();
                bool addNewLeaveFormLog = await generalFunctions.AddTravelFormLog(logDate, logDescription, travelControlNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not
        // Only forwards true or false
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

        // This function responsible for forwarding the Personnel Name
        // It returns the name in the form of string value
        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                formClass = new formClass();
                string personnelName = await formClass.GetPersonnelName(userId);
                return personnelName;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region This function and event handlers inside responsible for Dynamic Behaviours of User Interface

        private void CenterMayor()
        {
            // Calculate the center positions of departmentName label
            int mayorX = label6.Left + (label6.Width - mayor.Width) / 2;
            mayor.Location = new Point(mayorX, mayor.Top);


            // Set the new position for departmentHead label
            mayor.Location = new Point(mayorX, mayor.Location.Y);
        }

        private void CenterDepartmentHead()
        {
            // Calculate the center positions of departmentName label
            int departmentHeadX = label18.Left + (label18.Width - departmentHead.Width) / 2;
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Top);


            // Set the new position for departmentHead label
            departmentHead.Location = new Point(departmentHeadX, departmentHead.Location.Y);
        }

        private void DataBinding()
        {
            controlNum.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Value", this, "DateFiled");
            mayor.DataBindings.Add("Text", this, "Mayor");
            CenterMayor();
        }

        public bool PanelContent()
        {
            if (_parent.Controls.ContainsKey("mainPanel"))
            {
                Panel parentMainPanel = _parent.Controls["mainPanel"] as Panel;

                if (parentMainPanel.Controls.ContainsKey("contentPanel"))
                {
                    Panel panel = parentMainPanel.Controls["contentPanel"] as Panel;

                    if (panel.Controls.Contains(this))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async void ChosenEmployee(int employeeId, string firstName, string lastName, string middleName, string departmentHead, string department)
        {
            this.employeeId.Text = employeeId.ToString();
            firstNameTextBox.Texts = firstName;
            lastNameTextBox.Texts = lastName;
            this.middleName.Texts = middleName;
            EmployeeDepartment = department;

            if (EmployeeDepartment == PersonnelDepartment)
            {
                string personnelName = await GetPersonnelName(_userId);
                this.departmentHead.Text = personnelName;
            }
            else
            {
                this.departmentHead.Text = departmentHead;
            }

            CenterDepartmentHead();
        }

        private void travelOrder_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void firstNameTextBox_Click(object sender, EventArgs e)
        {
            appForLeave = new appForLeave(_parent, _userId);
            passSlipUC = new personnelPassSlipUC(_parent, _userId);

            employeeList employeeList = new employeeList(appForLeave, passSlipUC, this);
            employeeList.ShowDialog();

        }

        private void lastNameTextBox_Click(object sender, EventArgs e)
        {
            appForLeave = new appForLeave(_parent, _userId);
            passSlipUC = new personnelPassSlipUC(_parent, _userId);

            employeeList employeeList = new employeeList(appForLeave, passSlipUC, this);
            employeeList.ShowDialog();
        }

        private void middleName_Click(object sender, EventArgs e)
        {
            appForLeave = new appForLeave(_parent, _userId);
            passSlipUC = new personnelPassSlipUC(_parent, _userId);

            employeeList employeeList = new employeeList(appForLeave, passSlipUC, this);
            employeeList.ShowDialog();
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            appForLeave = new appForLeave(_parent, _userId);
            passSlipUC = new personnelPassSlipUC(_parent, _userId);

            employeeList employeeList = new employeeList(appForLeave, passSlipUC, this);
            employeeList.ShowDialog();
        }

        private void employeeId_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(employeeId.Text, out _))
            {
                EmployeeID = Convert.ToInt32(employeeId.Text);
            }
        }

        private void firstNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Texts))
            {
                FirstName = firstNameTextBox.Texts;
            }
        }

        private void lastNameTextBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Texts))
            {
                LastName = lastNameTextBox.Texts;
            }
        }

        private void middleName__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(middleName.Texts))
            {
                MiddleName = middleName.Texts;
            }
        }

        private void dateFiled_ValueChanged(object sender, EventArgs e)
        {
            DateFiled = dateFiled.Value;
        }

        private void departureDate_ValueChanged(object sender, EventArgs e)
        {
            DateDeparture = departureDate.Value;
        }

        private void departureTime_ValueChanged(object sender, EventArgs e)
        {
            DepartureTime = departureTime.Value.TimeOfDay;
        }

        private void returnTime_ValueChanged(object sender, EventArgs e)
        {
            ReturnTime = returnTime.Value.TimeOfDay;
        }

        private void destinationBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(destinationBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                Destination = capitalizedText;
            }
        }

        private void purpose__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(purpose.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                Purpose = capitalizedText;
            }
        }

        private void remarksBox__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(remarksBox.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                Remarks = capitalizedText;
            }
        }

        private void departmentHeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (departmentHeadCheck.Checked && PersonnelDepartment != EmployeeDepartment)
            {
                MessageBox.Show("Only the Department Head is authorized to note the Travel Order for approval.", 
                    "Restricted to Department Head:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                departmentHeadCheck.Checked = false;
            }
            else if (departmentHeadCheck.Checked && PersonnelDepartment ==  EmployeeDepartment)
            {
                MessageBox.Show($"Since the employee requesting is in the department of {PersonnelDepartment} the human resource officer is the " +
                    $"one will note the said Travel Order Request", "Notation of Travel Order Request", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                departmentHeadCheck.Checked = true;
                IsNoted = true;
            }
        }

        private void mayorCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (mayorCheck.Checked)
            {
                MessageBox.Show("Only the Mayor is authorized to make an approval for the Travel Order request.", 
                    "Restricted to Mayor:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mayorCheck.Checked = false;
            }
        }

        private void departmentHead_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(departmentHead.Text))
            {
                DepartmentHead = departmentHead.Text;
            }
        }

        private void mayor_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(mayor.Text))
            {
                Mayor = mayor.Text;
            }
        }

        #endregion

        #region Encapsulated Functions

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
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Texts) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Texts) ||
                string.IsNullOrWhiteSpace(middleName.Texts))
            {
                ErrorMessages("Please ensure that all name details of the employee are properly completed",
                    "Incomplete Name Details");
                return false;
            }
            else if (dateFiled.Value.Date != DateTime.Today)
            {
                ErrorMessages("Please ensure that the Date Filed is today's date",
                    "Date Field Verification Required");
                dateFiled.Value = DateTime.Today;
                return false;
            }
            else if (DateDeparture < DateTime.Today ||
                     departureDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                     departureDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                ErrorMessages("Kindly ensure that the Departure Date is set to a future date, specifically after " +
                    DateTime.Today.ToString("D") + ", and that it corresponds to a weekday rather than a weekend.",
                    "Departure Date Validation: Please Verify");
                return false;
            }
            else if (departureTime.Value.TimeOfDay < new TimeSpan(8, 0, 0) ||
                     (departureTime.Value.TimeOfDay == new TimeSpan(12, 0, 0) &&
                     departureTime.Value.TimeOfDay < new TimeSpan(13, 0, 0)) ||
                     departureTime.Value.TimeOfDay > new TimeSpan(17, 0, 0))
            {
                ErrorMessages("The selected departure time is not valid. Please make sure that the departure time is between 8:00 AM and 12:00 PM, " +
                    "excluding 12:00 PM to 1:00 PM, and should not be after 5:00 PM.",
                    "Invalid Departure Time");
                return false;
            }
            else if (returnTime.Value.TimeOfDay < new TimeSpan(8, 0, 0) ||
                     (returnTime.Value.TimeOfDay == new TimeSpan(12, 0, 0) &&
                     returnTime.Value.TimeOfDay < new TimeSpan(13, 0, 0)) ||
                     returnTime.Value.TimeOfDay > new TimeSpan(17, 0, 0))
            {
                ErrorMessages("The selected return time is not valid. Please make sure that the return time is between 8:00 AM and 12:00 PM, " +
                    "excluding 12:00 PM to 1:00 PM, and not after 5:00 PM.",
                    "Invalid Return Time");
                return false;
            }
            else if (ReturnTime <= DepartureTime || ReturnTime - DepartureTime < TimeSpan.FromHours(1))
            {
                ErrorMessages("The return time must be later than the departure time and have a minimum of 1 hour after the departure time. " +
                    "The return time has been adjusted.", "Return Time Error");
                returnTime.Value = departureTime.Value.AddHours(1);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(destinationBox.Texts) ||
                     string.IsNullOrWhiteSpace(purpose.Texts) ||
                     string.IsNullOrWhiteSpace(remarksBox.Texts))
            {
                ErrorMessages("Please ensure that all fields are filled in. Destination, purpose, and remarks are required.",
                    "Incomplete Information");
                return false;
            }
            else if (PersonnelDepartment == EmployeeDepartment && !departmentHeadCheck.Checked)
            {
                ErrorMessages($"Since the employee who requested the Travel Order is from {PersonnelDepartment} the Human Resource Officer " +
                    $"is entitled to note the said Request", "Notation of Travel Order Request");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<string> RetrievePersonnelName(int userId)
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
                    ErrorMessages("There is an error in retrieving personnel's name please contact the IT office to resolve " +
                        "the situation", "Personnel Name Error Retrieval");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> CheckPending(int employeeId, string status, string firstName, string lastName)
        {
            try
            {
                bool isAllowed = await GetPendingCount(employeeId, status);

                if (isAllowed)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("The employee " + firstName + " " + lastName + " is not currently allowed to submit a travel order request. " +
                        "They have a pending request that needs to be resolved first.","Pending Travel Request");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitTravel(int orderControlNumber, int employeeId, DateTime dateFiled, DateTime dateDeparture,
            TimeSpan departureTime, TimeSpan returnTime, string destination, string purpose, string remarks, 
            string status, string formName, string createdBy, DateTime createdDate, bool isNoted, string notedBy, DateTime notedDate, 
            string personnelDepartment, string employeeDepartment)
        {
            try
            {
                if (personnelDepartment == employeeDepartment)
                {
                    bool addTravel = await AddTravel(orderControlNumber, employeeId, dateFiled, dateDeparture, departureTime, returnTime,
                        destination, purpose, remarks, status, formName, createdBy, createdDate, isNoted, notedBy, notedDate);

                    if (addTravel)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is an error in submitting the Travel Order Request. Please contact the system administrators " +
                            $"for quick resolution", "Request Submission Error");
                        return false;
                    }
                }
                else
                {
                    bool addTravel = await NewTravelRequest(orderControlNumber, employeeId, dateFiled, dateDeparture, departureTime, returnTime,
                         destination, purpose, remarks, status, formName, createdBy, createdDate);

                    if (addTravel)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessages($"There is an error in submitting the Travel Order Request. Please contact the system administrators " +
                            $"for quick resolution", "Request Submission Error");
                        return false;
                    }
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitTravelFormLog(DateTime logDate, int travelControlNumber, string name, int userId, int employeeID, 
            string firstName, string lastName)
        {
            try
            {
                string formLogDescription = "Travel Order Request Submitted:" +
                    "||Personnel who Submitted: " + name + "( ID: " + userId.ToString() + " )" +
                    "||Employee: " + firstName + " " + lastName + " (Employee ID: " + employeeID.ToString() + " )" +
                    "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string formLogCaption = "Travel Order Request Submission";

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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> SubmitSystemLog(DateTime logdate, string name, string firstName, string lastName, int userId)
        {
            try
            {
                string systemLog = "Travel Order Request Submitted:" +
                        "||Personnel who Submitted: " + name + "( ID: " + userId.ToString() + " )" +
                        "||Employee: " + firstName + " " + lastName + " (Employee ID: " + employeeId.ToString() + " )" +
                        "||Submission Date and Time: " + DateTime.Now.ToString("f");
                string systemLogCaption = "Travel Order Request Submission";

                bool addSystemLog = await AddSystemLogs(logdate, systemLog, systemLogCaption);

                if (addSystemLog) { return true; } else { return false; }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                    return;

                bool checkPending = await CheckPending(EmployeeID, formStatus, FirstName, LastName);
                if (!checkPending)
                    return;

                string name = await RetrievePersonnelName(_userId);
                if (name == null)
                    return;

                bool submitTravel = await SubmitTravel(ControlNumber, EmployeeID, DateFiled, DateDeparture, DepartureTime, ReturnTime,
                    Destination, Purpose, Remarks, formStatus, formTitle, name, DateTime.Today, IsNoted, DepartmentHead, DateTime.Today,
                    PersonnelDepartment, EmployeeDepartment);
                if (!submitTravel)
                    return;

                bool submitFormLog = await SubmitTravelFormLog(DateTime.Today, ControlNumber, name, _userId, EmployeeID,
                    FirstName, LastName);
                if (!submitFormLog)
                    return;

                bool submitSystemLog = await SubmitSystemLog(DateTime.Today, name, FirstName, LastName, _userId);
                if(!submitSystemLog) 
                    return;

                SuccessMessage($"The Travel Order with the control number {ControlNumber} is already filed and submitted. Please wait " +
                    $"for further review and approval", "Travel Order Request Submission");
                
                await _parent.TravelDetails();
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQl Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Error");
            }
        }
    }
}
