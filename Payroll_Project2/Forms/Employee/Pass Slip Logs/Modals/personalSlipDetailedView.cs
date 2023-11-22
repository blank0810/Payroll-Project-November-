using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Pass_Slip_Logs.Modals
{
    public partial class personalSlipDetailedView : Form
    {
        public int ControlNumber { get; set; }
        public string NotedBy { get; set; }
        public string DateCreated { get; set; }
        public string SlipDate { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Extension { get; set; }
        public string SlipTime { get; set; }
        public string Destination { get; set; }
        public string Reason { get; set; }

        public personalSlipDetailedView()
        {
            InitializeComponent();
        }

        private void personalSlipDetailedView_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
