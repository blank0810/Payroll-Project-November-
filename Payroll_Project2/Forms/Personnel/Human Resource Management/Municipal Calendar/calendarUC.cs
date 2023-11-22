using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Municipal_Calendar.Calendar_Sub_User_Control;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Municipal_Calendar
{
    public partial class calendarUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static calendarClass calendarClass = new calendarClass();

        static DateTime now = DateTime.Now;
        int month = now.Month;
        int year = now.Year;

        public calendarUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for retrieving the Event Name
        private async Task<string> GetEventName(DateTime date)
        {
            try
            {
                string eventName = await calendarClass.GetEventName(date);

                if(!string.IsNullOrEmpty(eventName))
                {
                    return eventName;
                }
                else
                {
                    return null;
                }
            }
            catch(SqlException sql) { throw sql; } catch(Exception ex) { throw ex; }
        }

        // Custom function responsible for displaying days into the calendar
        public async Task displayDays()
        {
            try
            {
                DateTime dateTime = new DateTime(year, month, 1);

                string monthName = dateTime.ToString("MMMM");

                monthLabel.Text = monthName;

                yearLabel.Text = Convert.ToString(year);

                DateTime startOfMonth = new DateTime(year, month, 1);

                int numberOfDays = DateTime.DaysInMonth(year, month);

                int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));

                for (int i = 1; i <= dayOfWeek; i++)
                {
                    blankDaysUC blank = new blankDaysUC();
                    calendarContent.Controls.Add(blank);
                }

                for (int i = 1; i <= numberOfDays; i++)
                {
                    daysUC days = new daysUC(_userId, this);
                    days.Day = i;
                    days.Year = year;
                    days.Month = month;

                    if (new DateTime(year, month, i).DayOfWeek == DayOfWeek.Sunday || new DateTime(year, month, i).DayOfWeek == DayOfWeek.Saturday)
                    {
                        days.EventDesc = new DateTime(year, month, i).DayOfWeek.ToString();
                    }
                    else
                    {
                        string eventName = await GetEventName(new DateTime(year, month, i));
                        days.EventDesc = eventName;
                    }

                    calendarContent.Controls.Add(days);
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

        // Event handler that handles if this user control is loaded into the system
        private async void calendarUC_Load(object sender, EventArgs e)
        {
            await displayDays();
        }

        // Event handler that handles if the next button is clicked
        private async void nextBtn_Click(object sender, EventArgs e)
        {
            calendarContent.Controls.Clear();

            if (month == 12)
            {
                month = 1;
                year++;
                await displayDays();
            }
            else
            {
                month++;
                await displayDays();
            }
        }

        // Event handler that handles if the previous button is clicked
        private async void previousBtn_Click(object sender, EventArgs e)
        {
            calendarContent.Controls.Clear();

            if (month == 1)
            {
                month = 12;
                year--;
                await displayDays();
            }
            else
            {
                month--;
                await displayDays();
            }
        }

        // Event handler if the year text box is clicked
        private void yearBox_Click(object sender, EventArgs e)
        {
            if (yearBox.Text == "e.g 2021")
            {
                yearBox.Text = "";
                yearBox.ForeColor = Color.Black;
            }
        }

        // Event handler that handles if the go button is clicked
        private async void goToMonth_Click(object sender, EventArgs e)
        {
            if (yearBox.Text == "e.g 2021" || monthChanger.Text == "Choose Month")
            {
                MessageBox.Show("Enter the month and year");
            }
            else if(int.TryParse(yearBox.Text, out int selectedYear) && monthChanger.SelectedIndex >= 0)
            {
                calendarContent.Controls.Clear();
                year = selectedYear;
                month = monthChanger.SelectedIndex;
                await displayDays();
            }
        }
    }
}
