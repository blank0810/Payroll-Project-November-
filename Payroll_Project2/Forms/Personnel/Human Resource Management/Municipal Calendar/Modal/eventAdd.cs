using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Municipal_Calendar.Calendar_Sub_User_Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Municipal_Calendar.Modal
{
    public partial class eventAdd : Form
    {
        private static int _userId;
        private static daysUC _parent;
        private static calendarClass calendarClass = new calendarClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formClass formClass = new formClass();

        public string EventStartDate { get; set; }
        private string EventName { get; set; }
        private string EventDescription { get; set; }
        public DateTime EventEndDate { get; set; }
        private DateTime EventStartTime { get; set; }
        private DateTime EventEndTime { get; set; }
        private String MemorandumNumber { get; set; }

        public eventAdd(int userId, daysUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for forwarding and adding the event
        private async Task<bool> AddEvent(DateTime eventDateAdded, string eventName, string eventDescription, DateTime eventStartDate, DateTime eventEndDate, string memorandumNumber, string eventAddedBy)
        {
            try
            {
                bool addEvent = await calendarClass.AddEvent(eventDateAdded, eventName, eventDescription, eventStartDate, eventEndDate, memorandumNumber, eventAddedBy);
                return addEvent;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving personnel name
        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                string name = await formClass.GetPersonnelName(userId);

                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                else
                {
                    ErrorMessages("There is an error in Retrieving the user name. Please Refer this error to the System Administrator",
                        "Error Name: Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsbile for adding this into the system logs
        private async Task<bool> AddSystemLog(DateTime logDate, string logDescription, string caption)
        {
            try
            {
                bool addSystemLog = await generalFunctions.AddSystemLogs(logDate, logDescription, caption);
                return addSystemLog;
            }
            catch (SqlException sql) { throw sql;} catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving all employeeId
        private async Task<DataTable> GetAllEmployeeID()
        {
            try
            {
                DataTable id = await calendarClass.GetEmployeeId();

                if (id != null)
                {
                    return id;
                }
                else
                {
                    ErrorMessages("There is an error in retrieving the Employees ID. Please input manually the Event into the Employee Electronic " +
                        "DTR", "Employees ID Retrieval Error");
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function for adding a new dtr log to every employee if there is new event 
        private async Task<bool> AddDTRLog(int employeeId, DateTime dateLog, string status)
        {
            try
            {
                bool dtrLog = await calendarClass.InsertNewLog(employeeId, dateLog, status);
                return dtrLog;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Event handler that handles if this user control is loaded into the system
        private void eventAdd_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        // Event handler that handles if the whole day check box is checked
        private void dayCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(dayCheck.Checked)
            {
                afternoonCheck.Checked = false;
                morningCheck.Checked = false;

                fromTime.Value = Convert.ToDateTime("8:00 am");
                toTime.Value = Convert.ToDateTime("5:00 pm");
            }
        }

        // Event handler that handles if the morning check box is  checked
        private void morningCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(morningCheck.Checked)
            {
                afternoonCheck.Checked = false;
                dayCheck.Checked = false;

                fromTime.Value = Convert.ToDateTime("8:00 am");
                toTime.Value = Convert.ToDateTime("12:00 pm");
            }
        }

        // Event handler that handles if the afternoon check box is checked
        private void afternoonCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(afternoonCheck.Checked)
            {
                morningCheck.Checked = false;
                dayCheck.Checked = false;
                fromTime.Enabled = false;
                toTime.Enabled = false;

                fromTime.Value = Convert.ToDateTime("1:00 pm");
                toTime.Value = Convert.ToDateTime("5:00 pm");
            }
        }

        // Event handler that handles if the event name text box is changed
        private void eventName__TextChanged(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(eventName.Texts))
            {
                eventName.BorderColor = Color.Gray;
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                EventName = capitalizedText;
            }
        }

        // Event handler that handles the user's key press where it suppress if its not numerical input
        private void numberOfDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9), backspace, and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the non-numeric key
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true; // Suppress the second decimal point
            }
        }

        // Event handler that handles if the ending date value is change
        private void endingDate_ValueChanged(object sender, EventArgs e)
        {
            if(endingDate.Value.Date > Convert.ToDateTime(startingDate.Text).Date)
            {
                EventEndDate = endingDate.Value.Date;
                dayCheck.Checked = true;
                morningCheck.Enabled = false;
                afternoonCheck.Enabled = false;
            }
            else if (endingDate.Value.Date < Convert.ToDateTime(startingDate.Text).Date)
            {
                MessageBox.Show("The ending date must be greater than or equal to " + Convert.ToDateTime(startingDate.Text).ToString("MMMM d, yyyy"), 
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler that handles if the event description text is change
        private void eventDescription__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(eventDescription.Texts))
            {
                eventDescription.BorderColor = Color.Gray;
                EventDescription = eventDescription.Texts;
            }
            else
            {
                EventDescription = null;
            }
        }

        // Event handler that handles if from time changes
        private void fromTime_ValueChanged(object sender, EventArgs e)
        {
            EventStartTime = fromTime.Value;
        }

        // Event handler that handles if the to time changes
        private void toTime_ValueChanged(object sender, EventArgs e)
        {
            EventEndTime = toTime.Value;
        }

        // Event handler that handles if the memorandum number text box is changes
        private void memoNumber__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(memoNumber.Texts))
            {
                memoNumber.BorderColor = Color.Gray;
                MemorandumNumber = memoNumber.Texts;
            }
        }

        // Custom function for binding values into the UI Controls
        private void DataBind()
        {
            startingDate.DataBindings.Add("Text", this, "EventStartDate");
            endingDate.DataBindings.Add("Value", this, "EventEndDate");
        }

        // custom function that handles the validation of every user input
        private bool IsValidate()
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrEmpty(eventName.Texts))
            {
                errorMessages.Add("Event Name is required.");
                eventName.BorderColor = Color.Red;
                eventName.Focus();
            }

            if (!dayCheck.Checked && !morningCheck.Checked && !afternoonCheck.Checked)
            {
                errorMessages.Add("Acknowledgment is required.");
            }

            if (string.IsNullOrEmpty(memoNumber.Texts))
            {
                errorMessages.Add("Memorandum Number is required.");
                memoNumber.BorderColor = Color.Red;
                memoNumber.Focus();
            }

            if (errorMessages.Count > 0)
            {
                string errorMessage = string.Join("\n", errorMessages);
                ErrorMessages(errorMessage, "Validation Error");
                return false;
            }

            return true;
        }

        // custom function that adds the new event
        private async Task<bool> AddNewEvent(string name)
        {
            try
            {
                if (!DateTime.TryParseExact(EventStartDate + " " + EventStartTime.ToString("t"), "MMMM dd, yyyy h:mm tt", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDateTime))
                {
                    ErrorMessages("Both Start Date and Time is cannot be converted into a proper Starting Date. Please review details or " +
                        "contact the System Administrator for resolution",
                        "Error in Event Start Date");
                    return false;
                }
                else
                {
                    EventEndDate = EventEndDate.Add(EventEndTime.TimeOfDay);
                    bool addEvent = await AddEvent(DateTime.Now, EventName, EventDescription, startDateTime, EventEndDate, MemorandumNumber, name);

                    return addEvent;
                }
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

        // custom function that add new dtr logs to every employee
        private async Task<bool> AddNewDtrLog(DataTable idList)
        {
            try
            {
                for (int i = 0; i < idList.Rows.Count; i++)
                {
                    DataRow row = idList.Rows[i];

                    if (DateTime.TryParseExact(EventStartDate, "MMMM d, yyyy", CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, out DateTime eventDate) && int.TryParse(row["employeeId"].ToString(), out int id))
                    {
                        bool addDtr = await AddDTRLog(id, eventDate, EventName);

                        if(!addDtr)
                        {
                            return false;
                            throw new Exception("Error in adding new Logs in Employee DTR. Contact the system administrator for a support");
                        }
                    }
                    else
                    {
                        ErrorMessages("Both Start Date and Time cannot be converted into a proper Starting Date. Please review details or " +
                            "contact the System Administrator for resolution", "Error in Employee ID and Start Date");
                        return false;
                    }
                }
                return true;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // custom function that add new system logs
        private async Task<bool> AddNewSystemLog(string name)
        {
            try
            {
                string logDescription = "Event Added by: " + name + " " +
                    "|| Date and Time added into the log: " + DateTime.Now.ToString("f");
                string caption = "New Event Added";
                bool addLog = await AddSystemLog(DateTime.Today, logDescription, caption);
                
                if(!addLog)
                {
                    ErrorMessages("The event has already been added, but there was an error inserting it into the system logs. " +
                        "Please contact the administrator for further assistance.", "Event Already Added with Error");
                    return addLog;
                }
                else
                {
                    return addLog;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // custom function that display error messages
        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // custom function that display success messages
        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidate())
                    return;

                string name = await GetPersonnelName(_userId);
                if (string.IsNullOrEmpty(name))
                    return;

                bool addEvent = await AddNewEvent(name);
                if (!addEvent)
                    return;

                DataTable idList = await GetAllEmployeeID();
                if (idList == null || idList.Rows.Count <= 0)
                    return;

                bool addDtr = await AddNewDtrLog(idList);
                if (!addDtr)
                    return;

                bool addSystemLog = await AddNewSystemLog(name);
                if (!addSystemLog)
                    return;

                SuccessMessages("The event you are trying to add has already been successfully added to the database. " +
                    "Please review the calendar to ensure there are no duplicates. If you have any concerns, please contact the " +
                    "administrator.", "Event Already Added");
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, sql.TargetSite.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.ToString());
            }
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
