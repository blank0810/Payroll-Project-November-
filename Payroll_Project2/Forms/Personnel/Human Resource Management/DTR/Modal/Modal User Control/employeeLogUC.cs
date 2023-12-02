using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.DTR.Modal.Modal_User_Control
{
    public partial class employeeLogUC : UserControl
    {
        private static int _userId;
        private static dtrDetails _parent;
        private static int _employeeId;
        private static dtrClass dtrClass = new dtrClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        public int LogID { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public string MorningIn { get; set; }
        public string MorningOut { get; set; }
        public string MorningStatus { get; set; }
        public string AfternoonIn { get; set; }
        public string AfternoonOut { get; set; }
        public string AfternoonStatus { get; set; }
        public string SpecialPrivilege { get; set; }
        public int TotalHours { get; set; }

        private DateTime UpdateMorningIn { get; set; }
        private DateTime? UpdateMorningOut { get; set; }
        private DateTime? UpdateAfternoonIn { get; set; }
        private DateTime? UpdateAfternoonOut { get; set; }

        public employeeLogUC(int userId, int employeeId, dtrDetails parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        #region Functions below responsible for retrieval and forwarding every actions

        // Function responsible for adding new System Logs every transaction
        private async Task<bool> AddSystemLog(DateTime date, string description, string caption)
        {
            try
            {
                bool addSystemLog = await generalFunctions.AddSystemLogs(date, description, caption);
                return addSystemLog;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for authorization
        private async Task<string> GetValidation(int userId)
        {
            try
            {
                bool authorization = await generalFunctions.GetValidation(userId);

                if (authorization)
                {
                    return "Personnel";
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        // Function responsible for updating a DTR Logs of the employee
        private async Task<bool> UpdateDTRLog(int timeLogId, DateTime UpdateMorningIn, DateTime? UpdateMorningOut, string UpdateMorningStatus, DateTime? UpdateAfternoonIn, DateTime? UpdateAfternoonOut, string UpdateAfternoonStatus, int TotalHoursWorked)
        {
            try
            {
                bool updateLog = await dtrClass.UpdateTimeLog(timeLogId, UpdateMorningIn, UpdateMorningOut, UpdateMorningStatus, UpdateAfternoonIn, UpdateAfternoonOut, UpdateAfternoonStatus, TotalHoursWorked);

                return updateLog;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for Inserting new DTR Log
        private async Task<bool> InsertNewLog(int EmployeeId, DateTime DateLog, DateTime? MorningIn, DateTime? MorningOut, string MorningStatus, DateTime? AfternoonIn, DateTime? AfternoonOut, string AfternoonStatus, int TotalHoursWorked)
        {
            try
            {
                bool insertLog = await dtrClass.InsertNewLog(EmployeeId, DateLog, MorningIn, MorningOut, MorningStatus, AfternoonIn, AfternoonOut, AfternoonStatus, TotalHoursWorked);
                return insertLog;
            }
            catch (SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }
        
        // Function Responsible for Retrieving the Morning In time basis
        private async Task<TimeSpan> GetMorningIn()
        {
            try
            {
                TimeSpan morningTime = await dtrClass.GetMorningInBasis();

                return morningTime;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieiving the Morning Out Time basis
        private async Task<TimeSpan> GetMorningOut()
        {
            try
            {
                TimeSpan morningTime = await dtrClass.GetMorningOutBasis();

                return morningTime;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the Afternoon In basis
        private async Task<TimeSpan> GetAfternoonIn()
        {
            try
            {
                TimeSpan afternoonTime = await dtrClass.GetAfternoonInBasis();

                return afternoonTime;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving  the Afternoon Out Basis
        private async Task<TimeSpan> GetAfternoonOut()
        {
            try
            {
                TimeSpan afternoonTime = await dtrClass.GetAfternoonOutBasis();

                return afternoonTime;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> GetAuthorization(int userId)
        {
            try
            {
                string authorization = await GetValidation(userId);

                if (!string.IsNullOrEmpty(authorization) && authorization == "Personnel")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Event Handlers for UI Interactions

        // Event Handler responsible or Loading the Employee DTR User Control
        private void employeeDTRUC_Load(object sender, EventArgs e)
        {
            morningInUpdate.Visible = false;
            morningOutUpdate.Visible = false;
            afternoonInUpdate.Visible = false;
            afternoonOutUpdate.Visible = false;
            submitBtn.Visible = false;
            cancelBtn.Visible = false;
            DataBinding();
        }

        // Event Handler responsible if User Click the change button
        private void changeBtn_Click(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            if (DateTime.TryParseExact(Date, "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime date))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    MessageBox.Show("Apologies, but you cannot modify or add new time logs in the Daily Time Record (DTR) on weekends.",
                        "Weekend", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (string.IsNullOrEmpty(morningIn.Text) || morningIn.Text == "--:--:--")
                    {
                        DateTime morningInTime = DateTime.Today.Add(TimeSpan.Zero);
                        morningInUpdate.Value = morningInTime;
                    }
                    else
                    {
                        DateTime morningInTime = DateTime.ParseExact(morningIn.Text, "hh:mm tt", CultureInfo.InvariantCulture);
                        morningInUpdate.Value = morningInTime;
                    }

                    if (string.IsNullOrEmpty(morningOut.Text) || morningOut.Text == "--:--:--")
                    {
                        DateTime morningOutTime = DateTime.Today.Add(TimeSpan.Zero);
                        morningOutUpdate.Value = morningOutTime;
                    }
                    else
                    {
                        DateTime morningOutTime = DateTime.ParseExact(morningOut.Text, "hh:mm tt", CultureInfo.InvariantCulture);
                        morningOutUpdate.Value = morningOutTime;
                    }

                    if (string.IsNullOrEmpty(this.afternoonIn.Text) || afternoonIn.Text == "--:--:--")
                    {
                        DateTime afternoonIn = DateTime.Today.Add(TimeSpan.Zero);
                        afternoonInUpdate.Value = afternoonIn;
                    }
                    else
                    {
                        DateTime afternoonIn = DateTime.ParseExact(this.afternoonIn.Text, "hh:mm tt", CultureInfo.InvariantCulture);
                        afternoonInUpdate.Value = afternoonIn;
                    }

                    if (string.IsNullOrEmpty(this.afternoonOut.Text) || afternoonOut.Text == "--:--:--")
                    {
                        DateTime afternoonOut = DateTime.Today.Add(TimeSpan.Zero);
                        afternoonOutUpdate.Value = afternoonOut;
                    }
                    else
                    {
                        DateTime afternoonOut = DateTime.ParseExact(this.afternoonOut.Text, "hh:mm tt", CultureInfo.InvariantCulture);
                        afternoonOutUpdate.Value = afternoonOut;
                    }

                    morningInUpdate.Visible = true;
                    morningOutUpdate.Visible = true;
                    afternoonInUpdate.Visible = true;
                    afternoonOutUpdate.Visible = true;
                    submitBtn.Visible = true;
                    cancelBtn.Visible = true;

                    morningIn.Visible = false;
                    morningOut.Visible = false;
                    this.afternoonIn.Visible = false;
                    this.afternoonOut.Visible = false;
                    changeBtn.Visible = false;
                    absentBtn.Visible = false;
                }
            }
        }

        // Event Handler for the cancel button being clicked
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            morningInUpdate.Visible = false;
            morningOutUpdate.Visible = false;
            afternoonInUpdate.Visible = false;
            afternoonOutUpdate.Visible = false;
            submitBtn.Visible = false;
            cancelBtn.Visible = false;

            morningIn.Visible = true;
            morningOut.Visible = true;
            afternoonIn.Visible = true;
            afternoonOut.Visible = true;
            changeBtn.Visible = true;
            absentBtn.Visible = true;

            if (MorningStatus != "No Records" && AfternoonStatus != "No Records")
            {
                morningStatus.Text = MorningStatus;
                afternoonStatus.Text = AfternoonStatus;
            }
            else
            {
                morningStatus.Text = "No Records";
                afternoonStatus.Text = "No Records";
            }
        }

        // Event Handler responsible for the Morning status
        private void morningStatus_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(morningStatus.Text))
            {
                MorningStatus = morningStatus.Text;
            }
        }

        // Event Handler responsible for afternoon status if the text changes
        private void afternoonStatus_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(afternoonStatus.Text))
            {
                AfternoonStatus = afternoonStatus.Text;
            }
        }

        // Event Handler responsible for morning Update Time value
        private async void morningInUpdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan morningOut = await GetMorningOut();
                TimeSpan morningIn = await GetMorningIn();
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (DateTime.TryParseExact(Date, "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime date))
                {
                    if (morningIn != TimeSpan.Zero)
                    {
                        if (morningInUpdate.Value.TimeOfDay > morningIn && morningInUpdate.Value.TimeOfDay < morningOut)
                        {
                            morningStatus.Text = "Late";
                            UpdateMorningIn = date.Add(morningInUpdate.Value.TimeOfDay);
                        }
                        else
                        {
                            UpdateMorningIn = date.Add(morningInUpdate.Value.TimeOfDay);
                            morningStatus.Text = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while retrieving the time. The extracted Morning In time is invalid. " +
                            "Please contact the system administrator to resolve this issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The extracted date is invalid. Please contact the System Administrator immediately.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Event Handler responsible for morning out update time value
        private async void morningOutUpdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan morningOut = await GetMorningOut();
                TimeSpan morningIn = await GetMorningIn();
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (DateTime.TryParseExact(Date, "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime date))
                {
                    if (morningOut != TimeSpan.Zero)
                    {
                        if (morningInUpdate.Value.TimeOfDay > morningIn && morningInUpdate.Value.TimeOfDay < morningOut)
                        {
                            morningStatus.Text = "Late";
                            UpdateMorningIn = date.Add(morningInUpdate.Value.TimeOfDay);
                        }
                        else if (morningOutUpdate.Value.TimeOfDay < morningOut)
                        {
                            morningStatus.Text = "Undertime";
                            UpdateMorningOut = date.Add(morningOutUpdate.Value.TimeOfDay);
                        }
                        else if (morningInUpdate.Value.TimeOfDay <= morningIn && (morningOutUpdate.Value.TimeOfDay >= morningOut && morningOutUpdate.Value.TimeOfDay < morningOut.Add(new TimeSpan(0, 30, 0))))
                        {
                            morningStatus.Text = "On Time";
                            UpdateMorningOut = date.Add(morningOutUpdate.Value.TimeOfDay);
                        }
                        else if (morningOutUpdate.Value.TimeOfDay == TimeSpan.Zero)
                        {
                            UpdateMorningOut = null;
                            morningStatus.Text = null;
                        }
                        else
                        {
                            UpdateMorningOut = date.Add(morningOutUpdate.Value.TimeOfDay);
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while retrieving the time. The extracted Morning Out time is invalid. " +
                            "Please contact the system administrator to resolve this issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The extracted date is invalid. Please contact the System Administrator immediately.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Event Handler responsiblle for afternoon in update time value
        private async void afternoonInUpdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan afternoonIn = await GetAfternoonIn();
                TimeSpan afternoonOut = await GetAfternoonOut();
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (DateTime.TryParseExact(Date, "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime date))
                {
                    if (afternoonIn != TimeSpan.Zero)
                    {
                        if (afternoonInUpdate.Value.TimeOfDay > afternoonIn && afternoonInUpdate.Value.TimeOfDay < afternoonOut)
                        {
                            afternoonStatus.Text = "Late";
                            UpdateAfternoonIn = date.Add(afternoonInUpdate.Value.TimeOfDay);
                        }
                        else if ((afternoonInUpdate.Value.TimeOfDay <= afternoonIn && afternoonInUpdate.Value.TimeOfDay >= afternoonIn.Subtract(new TimeSpan(0, 30, 0))) && (afternoonOutUpdate.Value.TimeOfDay >= afternoonOut && afternoonOutUpdate.Value.TimeOfDay <= afternoonOut.Add(new TimeSpan(1, 0, 0))))
                        {
                            afternoonStatus.Text = "On Time";
                            UpdateAfternoonOut = date.Add(afternoonOutUpdate.Value.TimeOfDay);
                            UpdateAfternoonIn = date.Add(afternoonInUpdate.Value.TimeOfDay);
                        }
                        else if (afternoonInUpdate.Value.TimeOfDay == TimeSpan.Zero)
                        {
                            UpdateAfternoonIn = null;
                            afternoonStatus.Text = null;
                        }
                        else
                        {
                            UpdateAfternoonIn = date.Add(afternoonInUpdate.Value.TimeOfDay);
                            afternoonStatus.Text = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occurred due to an invalid time supplied for the afternoon In. Kindly reach out to the system " +
                            "administrator for prompt resolution.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The extracted date is invalid. Please contact the System Administrator immediately.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Event handler responsible for afternoon out time value
        private async void afternoonOutUpdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan afternoonOut = await GetAfternoonOut();
                TimeSpan afternoonIn = await GetAfternoonIn();
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (DateTime.TryParseExact(Date, "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime date))
                {
                    if ((afternoonInUpdate.Value.TimeOfDay <= afternoonIn && afternoonInUpdate.Value.TimeOfDay >= afternoonIn.Subtract(new TimeSpan(0, 30, 0))) && (afternoonOutUpdate.Value.TimeOfDay >= afternoonOut && afternoonOutUpdate.Value.TimeOfDay <= afternoonOut.Add(new TimeSpan(1, 0, 0))))
                    {
                        afternoonStatus.Text = "On Time";
                        UpdateAfternoonOut = date.Add(afternoonOutUpdate.Value.TimeOfDay);
                    }
                    else if (afternoonOutUpdate.Value.TimeOfDay >= afternoonOut.Add(new TimeSpan(1, 0, 0)))
                    {
                        afternoonStatus.Text = "Overtime";
                        UpdateAfternoonOut = date.Add(afternoonOutUpdate.Value.TimeOfDay);
                    }
                    else if (afternoonOutUpdate.Value.TimeOfDay < afternoonOut)
                    {
                        afternoonStatus.Text = "Undertime";
                        UpdateAfternoonOut = date.Add(afternoonOutUpdate.Value.TimeOfDay);
                    }
                    else if (afternoonOutUpdate.Value.TimeOfDay == TimeSpan.Zero)
                    {
                        UpdateAfternoonOut = null;
                        afternoonStatus.Text = null;
                    }                   
                    else
                    {
                        UpdateAfternoonOut = date.Add(afternoonOutUpdate.Value.TimeOfDay);
                    }
                }
                else
                {
                    MessageBox.Show("The extracted date is invalid. Please contact the System Administrator immediately.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Event handler responsible if the total hours text change
        private void total_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.specialPrivilege.Text, out int total))
            {
                TotalHours = total;
            }
        }

        #endregion

        #region Custom function on every actions/transactions

        // Custom Function responsible for validating user input
        private async Task<bool> IsValidated()
        {
            try
            {
                TimeSpan morningOut = await GetMorningOut();
                TimeSpan morningIn = await GetMorningIn();
                TimeSpan afternoonIn = await GetAfternoonIn();
                TimeSpan afternoonOut = await GetAfternoonOut();

                if (morningInUpdate.Value.TimeOfDay >= morningOut)
                {
                    ErrorMessages("Please input a proper Time In values for the Morning In", "Proper Time In Input");
                    return false;
                }
                else if (morningOutUpdate.Value.TimeOfDay > morningOut.Add(new TimeSpan(0, 30, 0)))
                {
                    ErrorMessages("Please input a valid Time Out Input in the Morning", "Morning Out Input Invalid");
                    return false;
                }
                else if (afternoonInUpdate.Value.TimeOfDay >= afternoonOut || 
                    afternoonInUpdate.Value.TimeOfDay < afternoonIn.Subtract(new TimeSpan(0,30,0)))
                {
                    ErrorMessages("Please input a proper Time In values for the Afternoon In", "Proper Time In Input");
                    return false;
                }
                else if (afternoonOutUpdate.Value.TimeOfDay < afternoonInUpdate.Value.TimeOfDay)
                {
                    ErrorMessages("Please input a valid Time Out Input in the Afternoon.", "Afternoon Out Input Invalid");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // Custom Function for computing the Total Hours of Employee Work load
        private void ComputeTotalHours()
        {
            if(morningInUpdate.Value.TimeOfDay != TimeSpan.Zero && morningOutUpdate.Value.TimeOfDay != TimeSpan.Zero && 
                afternoonInUpdate.Value.TimeOfDay != TimeSpan.Zero && afternoonOutUpdate.Value.TimeOfDay != TimeSpan.Zero)
            {
                double timeDiff = ((morningOutUpdate.Value.TimeOfDay - morningInUpdate.Value.TimeOfDay).TotalHours 
                    + (afternoonOutUpdate.Value.TimeOfDay - afternoonInUpdate.Value.TimeOfDay).TotalHours);
                int time = (int)Math.Floor(timeDiff);
                specialPrivilege.Text = time.ToString();
            }
            else if (morningInUpdate.Value.TimeOfDay != TimeSpan.Zero && morningOutUpdate.Value.TimeOfDay != TimeSpan.Zero && 
                afternoonInUpdate.Value.TimeOfDay == TimeSpan.Zero && afternoonOutUpdate.Value.TimeOfDay == TimeSpan.Zero)
            {
                double timeDiff = ((morningOutUpdate.Value.TimeOfDay - morningInUpdate.Value.TimeOfDay).TotalHours
                    + (afternoonOutUpdate.Value.TimeOfDay - afternoonInUpdate.Value.TimeOfDay).TotalHours);
                int time = (int)Math.Floor(timeDiff);
                specialPrivilege.Text = time.ToString();
            }
            else if (morningInUpdate.Value.TimeOfDay == TimeSpan.Zero && morningOutUpdate.Value.TimeOfDay == TimeSpan.Zero &&
                afternoonInUpdate.Value.TimeOfDay != TimeSpan.Zero && afternoonOutUpdate.Value.TimeOfDay != TimeSpan.Zero)
            {
                double timeDiff = ((morningOutUpdate.Value.TimeOfDay - morningInUpdate.Value.TimeOfDay).TotalHours
                    + (afternoonOutUpdate.Value.TimeOfDay - afternoonInUpdate.Value.TimeOfDay).TotalHours);
                int time = (int)Math.Floor(timeDiff);
                specialPrivilege.Text = time.ToString();
            }
        }

        // Custom Functions that binds the value from a variable to controls in User Interface
        private void DataBinding()
        {
            day.DataBindings.Add("Text", this, "Day");
            dateLog.DataBindings.Add("Text", this, "Date");
            morningIn.DataBindings.Add("Text", this, "MorningIn");
            morningOut.DataBindings.Add("Text", this, "MorningOut");
            afternoonIn.DataBindings.Add("Text", this, "AfternoonIn");
            afternoonOut.DataBindings.Add("Text", this, "AfternoonOut");
            specialPrivilege.DataBindings.Add("Text", this, "SpecialPrivilege");
            total.DataBindings.Add("Text", this, "TotalHours");

            Binding morningStatusBinding = new Binding("Text", this, "MorningStatus");
            morningStatusBinding.Format += new ConvertEventHandler(MorningStatus_Format);
            morningStatus.DataBindings.Add(morningStatusBinding);

            Binding afternoonStatusBinding = new Binding("Text", this, "AfternoonStatus");
            afternoonStatusBinding.Format += new ConvertEventHandler(AfternoonStatus_Format);
            afternoonStatus.DataBindings.Add(afternoonStatusBinding);

            day.Location = new Point((dayPanel.Width - day.Width) / 2, (dayPanel.Height - day.Height) / 2);
            dateLog.Location = new Point((datePanel.Width - dateLog.Width)/2, (datePanel.Height - dateLog.Height) / 2);
            morningIn.Location = new Point((morningInPanel.Width - morningIn.Width) / 2, (morningInPanel.Height - morningIn.Height) / 2);
            morningOut.Location = new Point((morningOutPanel.Width - morningOut.Width) / 2, (morningOutPanel.Height - morningOut.Height) / 2);
            morningStatus.Location = new Point((morningStatusPanel.Width - morningStatus.Width) / 2, (morningStatusPanel.Height - morningStatus.Height) / 2);
            afternoonIn.Location = new Point((afternoonInPanel.Width - afternoonIn.Width) / 2, (afternoonInPanel.Height - afternoonIn.Height) / 2);
            afternoonOut.Location = new Point((afternoonOutPanel.Width - afternoonOut.Width) / 2, (afternoonOutPanel.Height - afternoonOut.Height) / 2);
            afternoonStatus.Location = new Point((afternoonStatusPanel.Width - afternoonStatus.Width) / 2, (afternoonStatusPanel.Height - afternoonStatus.Height) / 2);
            specialPrivilege.Location = new Point((totalPanel.Width - specialPrivilege.Width) / 2, (totalPanel.Height - specialPrivilege.Height) / 2);
            total.Location = new Point((panel1.Width - total.Width) / 2, (panel1.Height - total.Height) / 2);
        }

        private void MorningStatus_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Saturday" || e.Value.ToString() == "Sunday")
            {
                morningStatus.ForeColor = Color.DarkOrange;
            }
            else if (e.Value.ToString() == "No Records" || e.Value.ToString() == "No Records")
            {
                morningStatus.ForeColor = Color.DimGray;
            }
            else if (e.Value.ToString() == "Late" || e.Value.ToString() == "Absent")
            {
                morningStatus.ForeColor = Color.Red;
            }
            else if (e.Value.ToString() == "On Leave" || e.Value.ToString() == "Pass Slip" || e.Value.ToString() == "Travel Order")
            {
                morningStatus.ForeColor = Color.DarkCyan;
            }
            else
            {
                morningStatus.ForeColor = Color.ForestGreen;
            }
        }

        private void AfternoonStatus_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Saturday" || e.Value.ToString() == "Sunday")
            {
                afternoonStatus.ForeColor = Color.DarkOrange;
            }
            else if (e.Value.ToString() == "No Records" || e.Value.ToString() == "No Records")
            {
                afternoonStatus.ForeColor = Color.DimGray;
            }
            else if (e.Value.ToString() == "Late" || e.Value.ToString() == "Absent")
            {
                afternoonStatus.ForeColor = Color.Red;
            }
            else if (e.Value.ToString() == "On Leave" || e.Value.ToString() == "Pass Slip" || e.Value.ToString() == "Travel Order")
            {
                afternoonStatus.ForeColor = Color.DarkCyan;
            }
            else
            {
                afternoonStatus.ForeColor = Color.ForestGreen;
            }
        }

        // Custom Function responsible for checking if user is authorized or not
        private async Task<bool> IsAuthorized (int userId)
        {
            try
            {
                bool authorized = await GetAuthorization(userId);
                
                if(!authorized)
                {
                    ErrorMessages("You are not authorized to this action", "Restricted Action");
                    return false;
                }
                else
                {
                    return authorized;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex ) { throw ex; }
        }

        // Custom function responsible for adding new DTR Log
        private async Task<bool> AddNewLog (string stringDate)
        {
            try
            {
                if (DateTime.TryParseExact(stringDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime date))
                {
                    if (LogID <= 0)
                    {
                        bool insertLog = await InsertNewLog(_employeeId, date, UpdateMorningIn, UpdateMorningOut, 
                            MorningStatus, UpdateAfternoonIn, UpdateAfternoonOut, AfternoonStatus, TotalHours);

                        if (insertLog)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorMessages("There is an error in adding the new DTR Log into Employee DTR", "Error DTR Logs");
                            return false;
                        }
                    }
                    else
                    {
                        bool updateLog = await UpdateDTRLog(LogID, UpdateMorningIn, UpdateMorningOut, MorningStatus, UpdateAfternoonIn, 
                            UpdateAfternoonOut, AfternoonStatus, TotalHours);

                        if (updateLog)
                        {
                            return true;
                        }
                        else
                        {
                            ErrorMessages($"Error in updating the Log Id {LogID}", "Error Update Log");
                            return false;
                        }
                    }
                }
                ErrorMessages($"Error in converting {Date}", "Date Error");
                return false;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for adding system logs
        private async Task<bool> AddNewSystemLog ()
        {
            try
            {
                string description = $"User {_userId} has made additions or modifications to Daily Time Record (DTR) logs. " +
                                        $"Employee ID: {_employeeId}.";
                string caption = "User Activity: Addition and Modification of Daily Time Record (DTR) Logs";

                bool addLog = await AddSystemLog(DateTime.Today, description, caption);

                if (addLog)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("The DTR Log is already added but there is an issue adding the transaction into the System Log. " +
                        "Please Conctact System Administrators to resolve the issue immediately", "System Log Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
        }

        private void ErrorMessages (string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages (string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ComputeTotalHours();

                bool isValidated = await IsValidated();
                if (!isValidated)
                    return;

                bool isAuthorized = await IsAuthorized(_userId);
                if (!isAuthorized)
                    return;

                bool addLog = await AddNewLog(Date);
                if (!addLog)
                    return;

                bool addSystemLog = await AddNewSystemLog();
                if (!addSystemLog)
                    return;

                SuccessMessages("A new entry has been successfully added to the Daily Time Record(DTR) log", "Success");
                await _parent.DisplayLogs();
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
    }
}
