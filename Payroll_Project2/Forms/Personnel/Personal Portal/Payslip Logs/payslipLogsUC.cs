using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs.Payslip_logs_sub_user_control;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs
{
    public partial class payslipLogsUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;

        public payslipLogsUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DisplayLog()
        {
            payslipContentPanel.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                payslipLogDataUC payslipLog = new payslipLogDataUC(_userId, this);
                payslipContentPanel.Controls.Add(payslipLog);
            }
        }

        private void payslipLogsUC_Load(object sender, EventArgs e)
        {
            DisplayLog();
        }
    }
}
