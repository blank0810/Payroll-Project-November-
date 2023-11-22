using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management
{
    public partial class appointmentUC : UserControl
    {
        public appointmentUC()
        {
            InitializeComponent();
        }

        private void appointmentUC_Load(object sender, EventArgs e)
        {
            viceMayorPanel.Visible = false;
        }

        private void mayorBtn_Click(object sender, EventArgs e)
        {
            viceMayorPanel.Visible = false;
            mayorPanel.Visible = true;
        }

        private void viceMayorBtn_Click(object sender, EventArgs e)
        {
            viceMayorPanel.Visible = true;
            mayorPanel.Visible = false;
        }
    }
}
