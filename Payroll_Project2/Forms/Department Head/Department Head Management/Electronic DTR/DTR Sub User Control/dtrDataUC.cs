using Payroll_Project2.Forms.Department_Head.Electronic_DTR.Modals;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Electronic_DTR.DTR_Sub_User_Control
{
    public partial class dtrDataUC : UserControl
    {
        private static int _userId;
        private static dtrModal _parent;
        private static int _employeeId;

        public int LogID { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public string MorningIn { get; set; }
        public string MorningOut { get; set; }
        public string MorningStatus { get; set; }
        public string AfternoonIn { get; set; }
        public string AfternoonOut { get; set; }
        public string AfternoonStatus { get; set; }
        public int TotalHours { get; set; }

        private DateTime UpdateMorningIn { get; set; }
        private DateTime? UpdateMorningOut { get; set; }
        private DateTime? UpdateAfternoonIn { get; set; }
        private DateTime? UpdateAfternoonOut { get; set; }

        public dtrDataUC(int userId, dtrModal parent, int employeeId)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        private void DataBinding()
        {
            day.DataBindings.Add("Text", this, "Day");
            dateLog.DataBindings.Add("Text", this, "Date");
            morningStatus.DataBindings.Add("Text", this, "MorningStatus");
            afternoonStatus.DataBindings.Add("Text", this, "AfternoonStatus");
        }

        private void dtrDataUC_Load(object sender, EventArgs e)
        {
            morningInUpdate.Visible = false;
            morningOutUpdate.Visible = false;
            afternoonInUpdate.Visible = false;
            afternoonOutUpdate.Visible = false;
            submitBtn.Visible = true;
            cancelBtn.Visible = true;
            DataBinding();
        }
    }
}
