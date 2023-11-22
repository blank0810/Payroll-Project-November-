using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Personal_DTR.DTR_sub_user_control
{
    public partial class dtrDataUC : UserControl
    {
        private static int _userId;
        private static personalDTR _parent;
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

        public dtrDataUC(int userId, personalDTR parent, int employeeID)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeID;
        }

        private void DataBinding()
        {
            day.DataBindings.Add("Text", this, "Day");
            dateLog.DataBindings.Add("Text", this, "Date");
            morningStatus.DataBindings.Add("Text", this, "MorningStatus");
            afternoonStatus.DataBindings.Add("Text", this, "AfternoonStatus");
            morningIn.DataBindings.Add("Text", this, "MorningIn");
            morningOut.DataBindings.Add("Text", this, "MorningOut");
            afternoonIn.DataBindings.Add("Text", this, "AfternoonIn");
            afternoonOut.DataBindings.Add("Text", this, "AfternoonOut");
            total.DataBindings.Add("Text", this, "TotalHours");
        }

        private void dtrDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
