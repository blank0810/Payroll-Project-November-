using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Electronic_DTR.Modals;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Electronic_DTR.DTR_Sub_User_Control
{
    public partial class dtrDataUC : UserControl
    {
        private static int _userId;
        private static dtrModal _parent;
        private static int _employeeId;
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

        public dtrDataUC(int userId, dtrModal parent, int employeeId)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        #region Event Handlers for UI Interactions

        // Event Handler responsible or Loading the Employee DTR User Control
        private void employeeDTRUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        #endregion

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
            }
            else
            {
                day.ForeColor = Color.Black;
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
    }
}
