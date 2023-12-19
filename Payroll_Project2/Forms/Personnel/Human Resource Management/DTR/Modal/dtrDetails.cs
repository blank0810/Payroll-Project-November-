using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.DTR.DTR_User_Controls;
using Payroll_Project2.Forms.Personnel.DTR.Modal.Modal_User_Control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static log4net.Appender.RollingFileAppender;

namespace Payroll_Project2.Forms.Personnel.DTR.Modal
{
    public partial class dtrDetails : Form
    {
        private static int _userId;
        private static employeeDTRUC _parent;
        private static dtrClass dtrClass = new dtrClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        private static DateTime now = DateTime.Now;
        private static int month = now.Month;
        private static int year = now.Year;

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string MonthName { get; set; }
        public string LateNumberMinutes { get; set; }
        public string UndertimeNumberMinutes { get; set; }
        public string OvertimeNumberMinutes { get; set; }
        public string AbsentNumberDays { get; set; }
        public string LeaveNumberDays { get; set; }
        public string TravelOrderNumberDays { get; set; }
        public string PassSlipNumberDays { get; set; }

        public dtrDetails(int userId, employeeDTRUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // This function is responsible for retrieving the Time Log Status
        private async Task<string> GetTimeLogStatus(int timeLogId)
        {
            try
            {
                string status = await generalFunctions.GetTimeLogStatus(timeLogId);
                return status;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function checks the blank logs that depicts absent
        private async Task<bool> CheckAbsentLog(int employeeId, DateTime date)
        {
            try
            {
                bool check = await generalFunctions.CheckAbsentLogs(employeeId, date);
                return check;
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This function retrieves the number of minutes employee is overtime
        private async Task<int> GetOvertime(int employeeId, int month, DateTime date)
        {
            try
            {
                int count = await generalFunctions.GetOvertimeCount(employeeId, month, date);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for retrieving the numbr of minutes employee is undertime
        private async Task<int> GetUndertime(int employeeId, int month, DateTime date)
        {
            try
            {
                int count = await generalFunctions.GetUndertimeCount(employeeId, month, date);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function retrieves the number of minutes employee is late
        private async Task<int> GetLate(int employeeId, int month, DateTime date)
        {
            try
            {
                int count = await generalFunctions.GetLateCount(employeeId, month, date);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function retrieves the number of leave
        private async Task<int> GetLeave(int employeeId, int month, DateTime date)
        {
            try
            {
                int count = await generalFunctions.GetLeaveCount(employeeId, month, date);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This is for retrieving the travel order count
        private async Task<int> GetTravelOrder(int employeeId, int month, DateTime date)
        {
            try
            {
                int count = await generalFunctions.GetTravelOrderCount(employeeId, month, date);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This is for retrieving the pass slip count
        private async Task<int> GetPassSlip(int employeeId, int month, DateTime date)
        {
            try
            {
                int count = await generalFunctions.GetPassSlipCount(employeeId, month, date);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This custom function is responsible for retrieving the Time Logs of Employee
        private async Task<DataTable> GetLogs(int employeeID, DateTime date)
        {
            try
            {
                DataTable logs = await generalFunctions.GetEmployeeTimeLog(employeeID, date);

                if(logs != null && logs.Rows.Count > 0)
                {
                    return logs;
                }
                else
                {
                    return null;
                }
            }
            catch(SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }

        // This custom function is responsible for displaying Employee's Time Logs as well as the Total Hours in every month
        public async Task DisplayLogs()
        {
            try
            {
                DateTime dateTime = new DateTime(year, month, 1);

                logContent.Controls.Clear();
                ClearBinding();
                await DataBinding(dateTime, EmployeeID);

                int numberOfDays = DateTime.DaysInMonth(year, month);

                for(int i = 1; i <= numberOfDays; i++)
                {
                    employeeLogUC logUC = new employeeLogUC(_userId, EmployeeID, this);
                    DateTime date = new DateTime(year, month, i);
                    DataTable logDetails = await GetLogs(EmployeeID, date);
                    logUC.Day = $"{date:ddd}".ToUpper();
                    logUC.Date = $"{date:MM/dd}";
                    logUC.Year = date.Year;

                    if (logDetails != null)
                    {
                        foreach (DataRow row in logDetails.Rows)
                        {
                            string morningInStatus;
                            string morningOutStatus;
                            string afternoonInStatus;
                            string afternoonOutStatus;
                            logUC.IsLogExist = true;

                            if (!string.IsNullOrEmpty(row["MorningInLogId"].ToString()) && int.TryParse(row["MorningInLogId"].ToString(),
                                out int morningInLogId))
                            {
                                logUC.MorningInLogId = morningInLogId;
                            }
                            else
                            {
                                logUC.MorningInLogId = 0;
                            }

                            if (!string.IsNullOrEmpty(row["morningOutLogId"].ToString()) && int.TryParse(row["morningOutLogId"].ToString(),
                                out int morningOutLogId))
                            {
                                logUC.MorningOutLogId = morningOutLogId;
                            }
                            else
                            {
                                logUC.MorningOutLogId = 0;
                            }

                            if (!string.IsNullOrEmpty(row["afternoonInLogId"].ToString()) && int.TryParse(row["afternoonInLogId"].ToString(),
                                out int afternoonInLogId))
                            {
                                logUC.AfternoonInLogId = afternoonInLogId;
                            }
                            else
                            {
                                logUC.AfternoonInLogId = 0;
                            }

                            if (!string.IsNullOrEmpty(row["afternoonOutLogId"].ToString()) && int.TryParse(row["afternoonOutLogId"].ToString(),
                                out int afternoonOutLogId))
                            {
                                logUC.AfternoonOutLogId = afternoonOutLogId;
                            }
                            else
                            {
                                logUC.AfternoonOutLogId = 0;
                            }

                            if (!string.IsNullOrEmpty(row["morningIn"].ToString()) && DateTime.TryParse(row["morningIn"].ToString(),
                                out DateTime morningIn))
                            {
                                logUC.MorningIn = $"{morningIn:hh:mm tt}".ToUpper();
                            }
                            else
                            {
                                logUC.MorningIn = "--:--:--";
                            }

                            if (!string.IsNullOrEmpty(row["morningOut"].ToString()) && DateTime.TryParse(row["morningOut"].ToString(),
                                out DateTime morningOut))
                            {
                                logUC.MorningOut = $"{morningOut:hh:mm tt}".ToUpper();
                            }
                            else
                            {
                                logUC.MorningOut = "--:--:--";
                            }

                            if (logUC.MorningInLogId != 0)
                            {
                                morningInStatus = await GetTimeLogStatus(logUC.MorningInLogId);
                            }
                            else
                            {
                                morningInStatus = string.Empty;
                            }

                            if (logUC.MorningOutLogId != 0)
                            {
                                morningOutStatus = await GetTimeLogStatus(logUC.MorningOutLogId);
                            }
                            else
                            {
                                morningOutStatus = string.Empty;
                            }

                            if (!string.IsNullOrEmpty(morningInStatus) && !string.IsNullOrEmpty(morningOutStatus))
                            {
                                if (morningInStatus == morningOutStatus)
                                {
                                    logUC.MorningStatus = morningInStatus;
                                }
                                else
                                {
                                    logUC.MorningStatus = $"{morningInStatus}\n {morningOutStatus}";
                                }
                            }
                            else
                            {
                                logUC.MorningStatus = string.Empty;
                            }

                            if (!string.IsNullOrEmpty(row["afternoonIn"].ToString()) && DateTime.TryParse(row["afternoonIn"].ToString(),
                                out DateTime afternoonIn))
                            {
                                logUC.AfternoonIn = $"{afternoonIn:hh:mm tt}".ToUpper();
                            }
                            else
                            {
                                logUC.AfternoonIn = "--:--:--";
                            }

                            if (!string.IsNullOrEmpty(row["afternoonOut"].ToString()) && DateTime.TryParse(row["afternoonOut"].ToString(),
                                out DateTime afternoonOut))
                            {
                                logUC.AfternoonOut = $"{afternoonOut:hh:mm tt}".ToUpper();
                            }
                            else
                            {
                                logUC.AfternoonOut = "--:--:--";
                            }

                            if (logUC.AfternoonInLogId != 0)
                            {
                                afternoonInStatus = await GetTimeLogStatus(logUC.AfternoonInLogId);
                            }
                            else
                            {
                                afternoonInStatus = string.Empty;
                            }

                            if (logUC.AfternoonOutLogId != 0)
                            {
                                afternoonOutStatus = await GetTimeLogStatus(logUC.AfternoonOutLogId);
                            }
                            else
                            {
                                afternoonOutStatus = string.Empty;
                            }

                            if (!string.IsNullOrEmpty(afternoonInStatus) && !string.IsNullOrEmpty(afternoonOutStatus))
                            {
                                if (afternoonOutStatus == afternoonInStatus)
                                {
                                    logUC.AfternoonStatus = afternoonOutStatus;
                                }
                                else
                                {
                                    logUC.AfternoonStatus = $"{afternoonInStatus}\n {afternoonOutStatus}";
                                }
                            }
                            else
                            {

                                logUC.AfternoonStatus = string.Empty;
                            }

                            if (!string.IsNullOrEmpty(row["specialPrivilegeDescription"].ToString()))
                            {
                                logUC.SpecialPrivilege = $"{row["specialPrivilegeDescription"]}";
                            }
                            else
                            {
                                logUC.SpecialPrivilege = string.Empty;
                            }

                            if (!string.IsNullOrEmpty(row["lateMinutes"].ToString()) && int.TryParse(row["lateMinutes"].ToString(),
                                out int lateMinutes))
                            {
                                TimeSpan minutes = TimeSpan.FromMinutes(lateMinutes);

                                logUC.LateNumberOfMinutes = $"{minutes}";
                            }
                            else
                            {
                                logUC.LateNumberOfMinutes = "00:00:00";
                            }

                            if (!string.IsNullOrEmpty(row["undertimeMinutes"].ToString()) && int.TryParse(row["undertimeMinutes"].ToString(),
                                out int undertimeMinutes))
                            {
                                TimeSpan minutes = TimeSpan.FromMinutes(undertimeMinutes);

                                logUC.UndertimeNumberOfMinutes = $"{minutes}";
                            }
                            else
                            {
                                logUC.UndertimeNumberOfMinutes = "00:00:00";
                            }

                            if (!string.IsNullOrEmpty(row["overtimeMinutes"].ToString()) && int.TryParse(row["overtimeMinutes"].ToString(),
                                out int overtimeMinutes))
                            {
                                TimeSpan minutes = TimeSpan.FromMinutes(overtimeMinutes);

                                logUC.OvertimeNumberOfMinutes = $"{minutes}";
                            }
                            else
                            {
                                logUC.OvertimeNumberOfMinutes = "00:00:00";
                            }
                        }
                    }
                    else
                    {
                        logUC.IsLogExist = false;
                        logUC.MorningIn = "--:--:--";
                        logUC.MorningOut = "--:--:--";
                        logUC.AfternoonIn = "--:--:--";
                        logUC.AfternoonOut = "--:--:--";
                        logUC.MorningStatus = string.Empty;
                        logUC.AfternoonStatus = string.Empty;
                        logUC.SpecialPrivilege = string.Empty;
                        logUC.LateNumberOfMinutes = "--:--:--";
                        logUC.UndertimeNumberOfMinutes = "--:--:--";
                        logUC.OvertimeNumberOfMinutes = "--:--:--";
                    }

                    logContent.Controls.Add(logUC);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearBinding()
        {
            monthName.DataBindings.Clear();
            employeeName.DataBindings.Clear();
            lateCountLabel.DataBindings.Clear();
            undertimeCountLabel.DataBindings.Clear();
            overtimeCountLabel.DataBindings.Clear();
            absentCountLabel.DataBindings.Clear();
            leaveCountLabel.DataBindings.Clear();
            travelOrderCountLabel.DataBindings.Clear();
            passSlipCountLabel.DataBindings.Clear();
        }

        private async Task<int> GetAbsentCount(int employeeId, DateTime date)
        {
            try
            {
                int count = 0;
                int numberOfDays = DateTime.DaysInMonth(date.Year, date.Month);

                for (int i = 1; i <= numberOfDays; i++)
                {
                    DateTime newDate = new DateTime(date.Year, date.Month, i);

                    if ((newDate.DayOfWeek != DayOfWeek.Sunday && newDate.DayOfWeek != DayOfWeek.Saturday) && newDate < DateTime.Today)
                    {
                        bool exist = await CheckAbsentLog(employeeId, newDate);

                        if (!exist)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DataBinding(DateTime dateTime, int employeeId)
        {
            try
            {
                int lateCount = await GetLate(employeeId, dateTime.Month, dateTime);
                int undertimeCount = await GetUndertime(employeeId, dateTime.Month, dateTime);
                int overtimeCount = await GetOvertime(employeeId, dateTime.Month, dateTime);
                int leaveCount = await GetLeave(employeeId, dateTime.Month, dateTime);
                int travelOrderCount = await GetTravelOrder(employeeId, dateTime.Month, dateTime);
                int passSlipCount = await GetPassSlip(employeeId, dateTime.Month, dateTime);
                int absentCount = await GetAbsentCount(employeeId, dateTime);

                TimeSpan lateMinutes = TimeSpan.FromMinutes(lateCount);
                TimeSpan undertimeMinutes = TimeSpan.FromMinutes(undertimeCount);
                TimeSpan overtimeMinutes = TimeSpan.FromMinutes(overtimeCount);

                LateNumberMinutes = $"{lateMinutes}";
                UndertimeNumberMinutes = $"{undertimeMinutes}";
                OvertimeNumberMinutes = $"{overtimeMinutes}";
                LeaveNumberDays = $"{leaveCount} day/s";
                TravelOrderNumberDays = $"{travelOrderCount} day/s";
                PassSlipNumberDays = $"{passSlipCount} day/s";
                AbsentNumberDays = $"{absentCount} day/s";
                MonthName = $"{dateTime: MMMM} - {dateTime:yyyy}";

                monthName.DataBindings.Add("Text", this, "MonthName");
                employeeName.DataBindings.Add("Text", this, "EmployeeName");
                lateCountLabel.DataBindings.Add("Text", this, "LateNumberMinutes");
                undertimeCountLabel.DataBindings.Add("Text", this, "UndertimeNumberMinutes");
                overtimeCountLabel.DataBindings.Add("Text", this, "OvertimeNumberMinutes");
                leaveCountLabel.DataBindings.Add("Text", this, "LeaveNumberDays");
                travelOrderCountLabel.DataBindings.Add("Text", this, "TravelOrderNUmberDays");
                passSlipCountLabel.DataBindings.Add("Text", this, "PassSlipNumberDays");
                absentCountLabel.DataBindings.Add("Text", this, "AbsentNumberDays");
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event Handler that handles if the DTR is loaded into the application
        private async void dtrDetails_Load(object sender, EventArgs e)
        {
            await DisplayLogs();
        }

        private void dtrDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Esc key
            if (e.KeyChar == (char)27) // 27 is the ASCII code for the Esc key
            {
                // Close the form
                Close();
            }
        }

        // Event handler that handles the key press event of Year Text box ensuring that the user input is only numbers
        private void yearBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits and control characters (backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        // Event handler that handles if the next button is clicked
        private async void nextBtn_Click(object sender, EventArgs e)
        {

            if (month == 12)
            {
                month = 1;
                year++;
                await DisplayLogs();
            }
            else
            {
                month++;
                await DisplayLogs();
            }
        }

        // Event handler that handles if the previous button is clicked
        private async void previousBtn_Click(object sender, EventArgs e)
        {
            logContent.Controls.Clear();

            if (month == 1)
            {
                month = 12;
                year--;
                await DisplayLogs();
            }
            else
            {
                month--;
                await DisplayLogs();
            }
        }

        // Event handler that handles if go button is clicked
        private async void goBtn_Click(object sender, EventArgs e)
        {
            logContent.Controls.Clear();

            if(string.IsNullOrEmpty(yearBox.Texts))
            {
                month = monthBox.SelectedIndex + 1;
                await DisplayLogs();
            }
            else if(int.TryParse(yearBox.Texts, out int newYear))
            {
                month = monthBox.SelectedIndex + 1;
                year = newYear;
                await DisplayLogs();
                
            }
        }
    }
}
