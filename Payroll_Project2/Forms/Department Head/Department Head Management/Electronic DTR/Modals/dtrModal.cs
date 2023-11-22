using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Electronic_DTR.DTR_Sub_User_Control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Electronic_DTR.Modals
{
    public partial class dtrModal : Form
    {
        private static int _userId;
        private static dtrSubUC _parent;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static dtrClass dtrClass = new dtrClass();

        private static DateTime now = DateTime.Now;
        private static int month = now.Month;
        private static int year = now.Year;

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string MorningShift { get; set; }
        public string AfternoonShift { get; set; }
        public int TotalHours { get; set; }

        public dtrModal(int userId, dtrSubUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for retrieving the Total Worked Hours
        private async Task<int> TotalHoursWorked(int year, int month, int employeeId)
        {
            try
            {
                int total = await generalFunctions.GetSumHoursWorked(year, month, employeeId);
                return total;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This custom function is responsible for retrieving the Time Logs of Employee
        private async Task<DataTable> GetLogs(int employeeID, DateTime date)
        {
            try
            {
                DataTable logs = await generalFunctions.GetEmployeeTimeLog(employeeID, date);

                if (logs != null && logs.Rows.Count > 0)
                {
                    return logs;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void dtrModal_Load(object sender, EventArgs e)
        {
            await DisplayLogs();
        }

        // This custom function is responsible for displaying Employee's Time Logs as well as the Total Hours in every month
        public async Task DisplayLogs()
        {
            try
            {
                DateTime dateTime = new DateTime(year, month, 1);

                TotalHours = await TotalHoursWorked(year, month, EmployeeID);

                employeeName.Text = EmployeeName;
                morningShift.Text = MorningShift;
                afternoonShift.Text = AfternoonShift;
                totalWorkedHours.Text = TotalHours.ToString(); 

                monthName.Text = dateTime.ToString("MMMM");
                monthName.Location = new Point((panel1.Width - monthName.Width) / 2, monthName.Location.Y);
                int numberOfDays = DateTime.DaysInMonth(year, month);

                for (int i = 1; i <= numberOfDays; i++)
                {
                    dtrDataUC logUC = new dtrDataUC(_userId, this, EmployeeID);
                    DateTime date = new DateTime(year, month, i);
                    logUC.Day = date.ToString("ddd");
                    logUC.Date = date.ToString("MM/dd/yyyy");
                    logUC.MorningStatus = "No Records";
                    logUC.AfternoonStatus = "No Records";

                    DataTable logDetails = await GetLogs(EmployeeID, date);

                    if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        logUC.Day = date.ToString("ddd");
                        logUC.Date = date.ToString("MM/dd/yyyy");
                        logUC.MorningStatus = date.DayOfWeek.ToString();
                        logUC.AfternoonStatus = date.DayOfWeek.ToString();
                    }
                    else if (logDetails != null && logDetails.Rows.Count > 0)
                    {
                        foreach (DataRow row in logDetails.Rows)
                        {
                            if (int.TryParse(row["timeLogId"].ToString(), out int logId))
                            {
                                logUC.LogID = logId;
                            }
                            else
                            {
                                MessageBox.Show("Log Id is cannot be convert " + row["timeLogId"].ToString());
                            }

                            logUC.Day = date.ToString("ddd");
                            logUC.Date = date.ToString("MM/dd/yyyy");

                            if (row["morningIn"] == null || row["morningIn"] == DBNull.Value)
                            {
                                logUC.MorningIn = "--:--:--";
                            }
                            else
                            {
                                DateTime morningIn = Convert.ToDateTime(row["morningIn"]);
                                logUC.MorningIn = morningIn.ToString("hh:mm tt");
                            }

                            if (row["morningOut"] == null || row["morningOut"] == DBNull.Value)
                            {
                                logUC.MorningOut = "--:--:--";
                            }
                            else
                            {
                                DateTime morningOut = Convert.ToDateTime(row["morningOut"]);
                                logUC.MorningOut = morningOut.ToString("hh:mm tt");
                            }

                            logUC.MorningStatus = $"{row["morningStatus"]}";

                            if (row["afternoonIn"] == null || row["afternoonIn"] == DBNull.Value)
                            {
                                logUC.AfternoonIn = "--:--:--";
                            }
                            else
                            {
                                DateTime afternoonIn = Convert.ToDateTime(row["afternoonIn"]);
                                logUC.AfternoonIn = afternoonIn.ToString("hh:mm tt");
                            }

                            if (row["afternoonOut"] == null || row["afternoonOut"] == DBNull.Value)
                            {
                                logUC.AfternoonOut = "--:--:--";
                            }
                            else
                            {
                                DateTime afternoonOut = Convert.ToDateTime(row["afternoonOut"]);
                                logUC.AfternoonOut = afternoonOut.ToString("hh:mm tt");
                            }

                            logUC.AfternoonStatus = $"{row["afternoonStatus"]}";

                            if (int.TryParse(row["totalHoursWorked"].ToString(), out int total))
                            {
                                logUC.TotalHours = total;
                            }
                            else
                            {
                                logUC.TotalHours = 0;
                            }
                        }
                    }
                    else
                    {
                        logUC.Day = date.ToString("ddd");
                        logUC.Date = date.ToString("MM/dd/yyyy");
                        logUC.MorningStatus = "No Records";
                        logUC.AfternoonStatus = "No Records";
                    }
                    logContent.Controls.Add(logUC);
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

        private async void nextBtn_Click(object sender, EventArgs e)
        {
            logContent.Controls.Clear();

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
    }
}
