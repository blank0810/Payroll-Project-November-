using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Pass_Slip_Requests.Pass_Slip_Request_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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

        public slipRequestDetailedView()
        {
            InitializeComponent();
        }
    }
}
