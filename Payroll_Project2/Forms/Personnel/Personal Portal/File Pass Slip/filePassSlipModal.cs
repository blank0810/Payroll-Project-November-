using Payroll_Project2.Forms.Personnel.Dashboard;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Pass_Slip
{
    public partial class filePassSlipModal : Form
    {
        private static int _userId;
        private static newDashboard _parent;

        public string EmployeeName { get; set; }
        private DateTime PassSlipDate { get; set; }
        private DateTime PassSlipTime { get; set; }
        private string Destination { get; set; }

        public filePassSlipModal(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }
    }
}
