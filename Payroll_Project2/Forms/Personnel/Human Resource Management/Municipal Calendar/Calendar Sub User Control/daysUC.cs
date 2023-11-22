using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Municipal_Calendar.Modal;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Municipal_Calendar.Calendar_Sub_User_Control
{
    public partial class daysUC : UserControl
    {
        private static int _userId;
        private static calendarUC _parent;
        private static calendarClass calendarClass = new calendarClass();

        public int Day { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string EventDesc { get; set; }

        public daysUC(int userId, calendarUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for retrieving the event details
        private async Task<DataTable> GetEventDetails(string eventName)
        {
            try
            {
                DataTable details = await calendarClass.GetEventDetails(eventName);
                
                if (details.Rows.Count > 0 || details != null)
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

        // Custom function for binding values into the UI controls
        private void DataBinding()
        {
            day.DataBindings.Add("Text", this, "Day");
            eventDesc.DataBindings.Add("Text", this, "EventDesc");

            if (string.IsNullOrEmpty(eventDesc.Text))
            {
                status.Visible = false;

                addEvent.Visible = true;
                addEvent.BringToFront();
                detailsBtn.Hide();
            }
            else if (eventDesc.Text == "Saturday" || eventDesc.Text == "Sunday")
            {
                eventDesc.ForeColor = Color.Red;
                status.Visible = false;

                addEvent.Visible = true;
                addEvent.Enabled = false;
                addEvent.BringToFront();
                detailsBtn.Hide();
            }
            else
            {
                eventDesc.ForeColor = Color.Green;
                status.Visible = true;

                addEvent.Visible = false;
                addEvent.Hide();

                detailsBtn.Visible = true;
                detailsBtn.BringToFront();
            }
        }

        // Custom function responsible for forwarding event details
        private async Task EventDetails(string eventName)
        {
            try
            {
                DataTable details = await GetEventDetails(eventName);
                detailsEvent detailsEvent = new detailsEvent(_userId, this);

                if (details != null || details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        detailsEvent.EventName = EventDesc;
                        detailsEvent.EventDescription = row["eventDescription"].ToString();

                        DateTime startDate = Convert.ToDateTime(row["eventStartDate"]);
                        DateTime endDate = Convert.ToDateTime(row["eventEndDate"]);
                        detailsEvent.EventDate = "The event is scheduled to take place from " + startDate.ToString("MMM d, yyyy") + "-" +
                            endDate.ToString("MMM d, yyyy") + Environment.NewLine + " with timings from " + startDate.ToString("t") +
                            "-" + endDate.ToString("t");
                        detailsEvent.EventReference = "The event is associated with Memorandum Number " + Environment.NewLine +
                            row["memorandumNumber"].ToString() + " and was added by " + row["eventAddedBy"].ToString();

                        detailsEvent.ShowDialog();
                    }
                }
            }
            catch(SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Custom function responsible for showing add event form
        private async Task AddEvent()
        {
            eventAdd newEvent = new eventAdd(_userId, this);
            newEvent.EventStartDate = new DateTime(Year, Month, Day).ToString("MMMM dd, yyyy");
            newEvent.EventEndDate = new DateTime(Year, Month, Day);
            newEvent.ShowDialog();

            await _parent.displayDays();
        }

        // Event handler that handles if this user control is loaded into the system
        private void daysUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler handles if the add event is clicked
        private async void addEvent_Click(object sender, EventArgs e)
        {
            await AddEvent();
        }

        // Event handler that handles if the event details button is clicked
        private async void detailsBtn_Click(object sender, EventArgs e)
        {
            await EventDetails(EventDesc);
        }
    }
}
