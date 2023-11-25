using Newtonsoft.Json.Bson;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Pass_Slip_Request_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Modals
{
    public partial class slipRequestDetailedView : Form
    {
        private static int _userId;
        private static slipRequestDataUC _parent;
        private static string _userDepartment;
        private static bool IsNote = true;
        private static bool IsApprove = true;
        private static readonly int TotalHours = 4;
        private static readonly string FormStatus = ConfigurationManager.AppSettings.Get("ApproveStatus");
        private static readonly string SlipStatus = ConfigurationManager.AppSettings.Get("DefaultSlipStatus");
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formRequestClass formRequestClass = new formRequestClass();

        public int ControlNumber { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string SlipDate { get; set; }
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
        public string Destination { get; set; }
        public string NotedBy { get; set; }
        public string NotedDate { get; set; }
        public string MonthName { get; set; }
        public string BalanceHours {  get; set; }
        public string HoursUsed { get; set; }
        public string RemainingHours { get; set; }
        public string MayorName { get; set; }
        public bool IsNoteNull { get; set; }

        public slipRequestDetailedView(int userId, slipRequestDataUC parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }

        private async Task<TimeSpan> GetEmployeeSlipHours(int employeeId, int month, int year)
        {
            try
            {
                TimeSpan hours = await generalFunctions.GetEmployeeSlipHours(employeeId, month, year);
                return hours;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> NoteSlipRequest(int controlNumber, bool isNoted, string notedBy, DateTime notedDate)
        {
            try
            {
                bool slipNote = await generalFunctions.NotedPassSlipRequest(controlNumber, isNoted, notedBy, notedDate);
                return slipNote;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> ApproveSlipRequest(int controlNumber, bool isApproved, string approvedBy, DateTime approvedDate, string status)
        {
            try
            {
                bool approveRequest = await formRequestClass.ApproveSlipRequest(controlNumber, isApproved, approvedBy, approvedDate, status);
                return approveRequest;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> DeductSlipHous(int employeeId, int month, int year, TimeSpan newHours)
        {
            try
            {
                bool deduct = await formRequestClass.UpdateEmployeeSlipHours(employeeId, month, year, newHours);
                return deduct;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> InsertDTRLog(int employeeId, DateTime logDate, string status, int totalHours)
        {
            try
            {
                bool insertDtr = await formRequestClass.AddDTRLog(employeeId, logDate, status, totalHours);
                return insertDtr;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not this for the form logs
        private async Task<bool> AddSlipFormLog(DateTime logDate, string logDescription, int slipControlNumber, string caption)
        {
            try
            {
                bool addNewLeaveFormLog = await generalFunctions.AddSlipFormLog(logDate, logDescription, slipControlNumber, caption);

                return addNewLeaveFormLog;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function serves as an indicator if the logs are recorded or not this is for the system logs
        private async Task<bool> AddSystemLogs(DateTime logdate, string logdescription, string caption)
        {
            try
            {
                bool addSystemLogs = await generalFunctions.AddSystemLogs(logdate, logdescription, caption);

                return addSystemLogs;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void DataBinding()
        {
            controlNum.DataBindings.Add("Text", this, "ControlNumber");
            slipDate.DataBindings.Add("Text", this, "SlipDate");
            slipStartingTime.DataBindings.Add("Text", this, "StartingTime");
            slipEndingTime.DataBindings.Add("Text", this, "EndingTime");
            destination.DataBindings.Add("Text", this, "Destination");
            notedBy.DataBindings.Add("Text", this, "NotedBy");
            dateNoted.DataBindings.Add("Text", this, "NotedDate");
            monthName.DataBindings.Add("Text", this, "MonthName");
            balanceHour.DataBindings.Add("Text", this, "BalanceHours");
            usedHour.DataBindings.Add("Text", this, "HoursUsed");
            remainingHour.DataBindings.Add("Text", this, "RemainingHours");
            mayor.DataBindings.Add("Text", this, "MayorName");

            CenterMayorName();
            CenterLabels();
        }

        private void CenterMayorName()
        {
            // Calculate the center position of mayor label
            int mayorX = mayorJobDescription.Left + (mayorJobDescription.Width - mayor.Width) / 2;

            // Set the new position for mayor label
            mayor.Location = new Point(mayorX, mayor.Top);

        }

        private void CenterLabels()
        {
            int monthNameX = label11.Left + (label11.Width - monthName.Width) / 2;
            monthName.Location = new Point(monthNameX, monthName.Top);

            int balanceHourX = label30.Left + (label30.Width - balanceHour.Width) / 2;
            balanceHour.Location = new Point(balanceHourX, balanceHour.Top);

            int usedHourX = label31.Left + (label31.Width - usedHour.Width) / 2;
            usedHour.Location = new Point(usedHourX, usedHour.Top);

            int remainingHourX = label14.Left + (label14.Width - remainingHour.Width) / 2;
            remainingHour.Location = new Point(remainingHourX, remainingHour.Top);
        }

        private void slipRequestDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
