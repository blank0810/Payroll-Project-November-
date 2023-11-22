using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Dashboard.Modals
{
    public partial class updateModal : Form
    {
        private static int _userId;
        private static employeeDashboard _parent;

        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Birthday { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string Gender { get; set; }

        public updateModal(int userId, employeeDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheck.Checked)
            {
                password.PasswordChar = false;
            }
            else
            {
                password.PasswordChar = true;
            }
        }
    }
}
