using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control.Modal.User_Controls;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
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

        public int Year { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public int MorningInLogId { get; set; }
        public int MorningOutLogId { get; set; }
        public int AfternoonInLogId { get; set; }
        public int AfternoonOutLogId { get; set; }
        public string MorningIn { get; set; }
        public string MorningOut { get; set; }
        public string MorningStatus { get; set; }
        public string AfternoonIn { get; set; }
        public string AfternoonOut { get; set; }
        public string AfternoonStatus { get; set; }
        public string SpecialPrivilege { get; set; }
        public string LateNumberOfMinutes { get; set; }
        public string UndertimeNumberOfMinutes { get; set; }
        public string OvertimeNumberOfMinutes { get; set; }
        public bool IsLogExist { get; set; }

        public employeeLogUC(int userId, int employeeId, dtrDetails parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        #region Functions below responsible for retrieval and forwarding every actions

        private async Task<bool> InsertNewMorningInLog(int employeeId, DateTime dateLog, DateTime morningInTime)
        {
            try
            {
                bool insert = await dtrClass.InsertNewMorningIn(employeeId, dateLog, morningInTime);
                return insert;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertNewMorningOutLog(int employeeId, DateTime dateLog, DateTime morningOutTime)
        {
            try
            {
                bool insert = await dtrClass.InsertNewMorningOut(employeeId, dateLog, morningOutTime);
                return insert;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertNewAfternoonInLog(int employeeId, DateTime dateLog, DateTime afternoonInTime)
        {
            try
            {
                bool insert = await dtrClass.InsertNewAfternoonIn(employeeId, dateLog, afternoonInTime);
                return insert;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertNewAfternoonOutLog(int employeeId, DateTime dateLog, DateTime afternoonOutTime)
        {
            try
            {
                bool insert = await dtrClass.InsertNewAfternoonOut(employeeId, dateLog, afternoonOutTime);
                return insert;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> UpdateMorningInLog(int timeLogId, DateTime updateMorningIn)
        {
            try
            {
                bool update = await dtrClass.UpdateMorningInTimeLog(timeLogId, updateMorningIn);
                return update;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> UpdateMorningOutLog(int timeLogId, DateTime updateMorningOut)
        {
            try
            {
                bool update = await dtrClass.UpdateMorningOutTimeLog(timeLogId, updateMorningOut);
                return update;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> UpdateAfternoonInLog(int timeLogId, DateTime updateAfternoonIn)
        {
            try
            {
                bool update = await dtrClass.UpdateAfternoonInTimeLog(timeLogId, updateAfternoonIn);
                return update;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> UpdateAfternoonOutLog(int timeLogId, DateTime updateAfternoonOut)
        {
            try
            {
                bool update = await dtrClass.UpdateAfternoonOutTimeLog(timeLogId, updateAfternoonOut);
                return update;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

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
            submitBtn.Visible = true;
            cancelBtn.Visible = true;
            changeBtn.Visible = false;
            morningIn.Visible = false;
            morningOut.Visible = false;
            afternoonIn.Visible = false;
            afternoonOut.Visible = false;

            if (DateTime.TryParseExact($"{Date} {Year}", "MM/dd yyyy", culture, DateTimeStyles.None, out DateTime date))
            {
                if (!string.IsNullOrEmpty(morningIn.Text) && DateTime.TryParseExact(morningIn.Text, "hh:mm tt", culture, DateTimeStyles.None, 
                    out DateTime morningInTime))
                {
                    morningInUpdate.Value = morningInTime;
                }
                else
                {
                    morningInUpdate.Value = date.Add(TimeSpan.Zero);
                }

                if (!string.IsNullOrEmpty(morningOut.Text) && DateTime.TryParseExact(morningOut.Text, "hh:mm tt", culture, DateTimeStyles.None, 
                    out DateTime morningOutTime))
                {
                    morningOutUpdate.Value = morningOutTime;
                }
                else
                {
                    morningOutUpdate.Value = date.Add(TimeSpan.Zero);
                }

                if (!string.IsNullOrEmpty(afternoonIn.Text) && DateTime.TryParseExact(afternoonIn.Text, "hh:mm tt", culture, DateTimeStyles.None, 
                    out DateTime afternoonInTime))
                {
                    afternoonInUpdate.Value = afternoonInTime;
                }
                else
                {
                    afternoonInUpdate.Value = date.Add(TimeSpan.Zero);
                }

                if (!string.IsNullOrEmpty(afternoonOut.Text) && DateTime.TryParseExact(afternoonOut.Text, "hh:mm tt", culture, DateTimeStyles.None, 
                    out DateTime afternoonOutTime))
                {
                    afternoonOutUpdate.Value = afternoonOutTime;
                }
                else
                {
                    afternoonOutUpdate.Value = date.Add(TimeSpan.Zero);
                }

                morningInUpdate.Visible = true;
                morningOutUpdate.Visible = true;
                afternoonInUpdate.Visible = true;
                afternoonOutUpdate.Visible = true;
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
        }

        #endregion

        #region Custom function on every actions/transactions

        // Custom Functions that binds the value from a variable to controls in User Interface
        private void DataBinding()
        {
            dateLog.DataBindings.Add("Text", this, "Date");
            morningIn.DataBindings.Add("Text", this, "MorningIn");
            morningOut.DataBindings.Add("Text", this, "MorningOut");
            afternoonIn.DataBindings.Add("Text", this, "AfternoonIn");
            afternoonOut.DataBindings.Add("Text", this, "AfternoonOut");
            specialPrivilege.DataBindings.Add("Text", this, "SpecialPrivilege");
            lateCountNumberOfMinutes.DataBindings.Add("Text", this, "LateNumberOfMinutes");
            undertimeCountNumberOfMinutes.DataBindings.Add("Text", this, "UndertimeNumberofMinutes");
            overtimeCountNumberOfMinutes.DataBindings.Add("Text", this, "OvertimeNumberOfMinutes");

            Binding dayBinding = new Binding("Text", this, "Day");
            dayBinding.Format += new ConvertEventHandler(Day_Format);
            day.DataBindings.Add(dayBinding);

            Binding morningStatusBinding = new Binding("Text", this, "MorningStatus");
            morningStatusBinding.Format += new ConvertEventHandler(MorningStatus_Format);
            morningStatus.DataBindings.Add(morningStatusBinding);

            Binding afternoonStatusBinding = new Binding("Text", this, "AfternoonStatus");
            afternoonStatusBinding.Format += new ConvertEventHandler(AfternoonStatus_Format);
            afternoonStatus.DataBindings.Add(afternoonStatusBinding);
        }

        private void Day_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "SAT" || e.Value.ToString() == "SUN")
            {
                day.ForeColor = Color.Red;
                changeBtn.Visible = false;
                submitBtn.Visible = false;
                cancelBtn.Visible = false;
            }
            else
            {
                day.ForeColor = Color.Black;
                changeBtn.Visible = true;
            }
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
        private async Task<bool> AddNewLog()
        {
            try
            {
                bool morningInChanges;
                bool morningOutChanges;
                bool afternoonInChanges;
                bool afternoonOutChanges;

                if (DateTime.TryParseExact($"{Date} {Year}", "MM/dd yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    if (IsLogExist)
                    {
                        if (MorningInLogId > 0)
                        {
                            morningInChanges = await UpdateMorningInLog(MorningInLogId, morningInUpdate.Value);
                        }
                        else if (morningInUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            morningInChanges = await InsertNewMorningInLog(_employeeId, date, morningInUpdate.Value);
                        }
                        else
                        {
                            morningInChanges = true;
                        }

                        if (MorningOutLogId > 0)
                        {
                            morningOutChanges = await UpdateMorningOutLog(MorningOutLogId, morningOutUpdate.Value);
                        }
                        else if (morningOutUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            morningOutChanges = await InsertNewMorningOutLog(_employeeId, date, morningOutUpdate.Value);
                        }
                        else
                        {
                            morningOutChanges = true;
                        }

                        if (AfternoonInLogId > 0)
                        {
                            afternoonInChanges = await UpdateAfternoonInLog(AfternoonInLogId, afternoonInUpdate.Value);
                        }
                        else if (afternoonInUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            afternoonInChanges = await InsertNewAfternoonInLog(_employeeId, date, afternoonInUpdate.Value);
                        }
                        else
                        {
                            afternoonInChanges = true;
                        }

                        if (AfternoonOutLogId > 0)
                        {
                            afternoonOutChanges = await UpdateAfternoonOutLog(AfternoonOutLogId, afternoonOutUpdate.Value);
                        }
                        else if (afternoonOutUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            afternoonOutChanges = await InsertNewAfternoonOutLog(_employeeId, date, afternoonOutUpdate.Value);
                        }
                        else
                        {
                            afternoonOutChanges = true;
                        }
                    }
                    else
                    {
                        if (morningInUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            morningInChanges = await InsertNewMorningInLog(_employeeId, date, morningInUpdate.Value);
                        }
                        else
                        {
                            morningInChanges = true;
                        }

                        if (morningOutUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            morningOutChanges = await InsertNewMorningOutLog(_employeeId, date, morningOutUpdate.Value);
                        }
                        else
                        {
                            morningOutChanges = true;
                        }

                        if (afternoonInUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            afternoonInChanges = await InsertNewAfternoonInLog(_employeeId, date, afternoonInUpdate.Value);
                        }
                        else
                        {
                            afternoonInChanges = true;
                        }

                        if (afternoonOutUpdate.Value.TimeOfDay != TimeSpan.Zero)
                        {
                            afternoonOutChanges = await InsertNewAfternoonOutLog(_employeeId, date, afternoonOutUpdate.Value);
                        }
                        else
                        {
                            afternoonOutChanges = true;
                        }
                    }
                }
                else
                {
                    ErrorMessages($"There is an error converting the Date", "Date Conversion Error");
                    return false;
                }

                if (morningInUpdate.Value.TimeOfDay == TimeSpan.Zero && morningOutUpdate.Value.TimeOfDay == TimeSpan.Zero &&
                    afternoonInUpdate.Value.TimeOfDay == TimeSpan.Zero && afternoonOutUpdate.Value.TimeOfDay == TimeSpan.Zero)
                {
                    ErrorMessages("There is no changes reflected in the DTR please input a proper time value!", "Invalid Input");
                    return false;
                }
                else if (morningInChanges && morningOutChanges && afternoonInChanges && afternoonOutChanges)
                {
                    return true;
                }
                else
                {
                    ErrorMessages($"One of the Logs failed to update or insert into the DTR. Please contact system administrator for " +
                        $"resolution", "Failure to Update or Insert new Logs");
                    return false;
                }
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
                bool isAuthorized = await IsAuthorized(_userId);
                if (!isAuthorized)
                    return;

                bool addLog = await AddNewLog();
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
