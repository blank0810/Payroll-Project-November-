using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Personal_DTR.DTR_sub_user_control
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

        public dtrDataUC()
        {
            InitializeComponent();
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
            //DataBinding();
        }
    }
}
