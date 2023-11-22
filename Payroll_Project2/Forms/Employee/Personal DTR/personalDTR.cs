using Payroll_Project2.Forms.Employee.Dashboard;
using Payroll_Project2.Forms.Employee.Personal_DTR.DTR_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Personal_DTR
{
    public partial class personalDTR : UserControl
    {
        private static int _userId;
        private static employeeDashboard _parent;

        private static DateTime now = DateTime.Now;
        private static int month = now.Month;
        private static int year = now.Year;

        public int EmployeeID = 0; //{ get; set; }
        public string EmployeeName { get; set; }
        public string MorningShift { get; set; }
        public string AfternoonShift { get; set; }
        public int TotalHours { get; set; }

        public personalDTR()
        {
            InitializeComponent();
        }

        private void dtrUC_Load(object sender, EventArgs e)
        {
            DisplayLogs();
        }

        // This custom function is responsible for displaying Employee's Time Logs as well as the Total Hours in every month
        public async Task DisplayLogs()
        {
            try
            {
                DateTime dateTime = new DateTime(year, month, 1);

                logContent.Controls.Clear();

                monthName.Text = dateTime.ToString("MMMM");
                monthName.Location = new Point((panel1.Width - monthName.Width) / 2, monthName.Location.Y);
                int numberOfDays = DateTime.DaysInMonth(year, month);

                for (int i = 1; i <= numberOfDays; i++)
                {
                    dtrDataUC logUC = new dtrDataUC();
                    DateTime date = new DateTime(year, month, i);
                    logUC.Day = date.ToString("ddd");
                    logUC.Date = date.ToString("MM/dd/yyyy");
                    logUC.MorningStatus = "No Records";
                    logUC.AfternoonStatus = "No Records";

                    //DataTable logDetails = await GetLogs(EmployeeID, date);

                    /*if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
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
                    }*/
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
