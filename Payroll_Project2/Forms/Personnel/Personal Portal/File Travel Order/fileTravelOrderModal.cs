using Payroll_Project2.Forms.Personnel.Dashboard;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Travel_Order
{
    public partial class fileTravelOrderModal : Form
    {
        private static int _userId;
        private static newDashboard _parent;

        public string EmployeeName { get; set; }
        private DateTime DateDeparture { get; set; }
        private DateTime DepartureTime { get; set; }
        private DateTime ReturnTime { get; set; }
        private string Destination { get; set; }
        private string Reason { get; set; }
        private string Remarks { get; set; }

        public fileTravelOrderModal(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
