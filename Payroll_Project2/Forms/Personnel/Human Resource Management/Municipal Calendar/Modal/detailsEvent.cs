using Payroll_Project2.Forms.Personnel.Municipal_Calendar.Calendar_Sub_User_Control;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Municipal_Calendar.Modal
{
    public partial class detailsEvent : Form
    {
        private static int _userId;
        private static daysUC _parent;

        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventDate { get; set; }
        public string EventReference { get; set; }

        public detailsEvent(int userId, daysUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Custom functions that bind the values into the UI controls
        private void DataBinding()
        {
            eventName.DataBindings.Add("Text", this, "EventName");
            eventDescription.DataBindings.Add("Text", this, "EventDescription");
            eventDate.DataBindings.Add("Text", this, "EventDate");
            eventReference.DataBindings.Add("Text", this, "EventReference");
        }

        // Event handler that handles when this form is loaded into the system
        private void detailsEvent_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
