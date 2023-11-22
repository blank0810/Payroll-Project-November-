using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Employee.Pass_Slip_Logs.Pass_slip_log_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Pass_Slip_Logs
{
    public partial class slipLogsUC : UserControl
    {
        private static int _userId;

        public slipLogsUC()
        {
            InitializeComponent();
        }

        private void DisplayLogs()
        {
            listContentPanel.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                slipLogDataUC slipLogs = new slipLogDataUC();
                listContentPanel.Controls.Add(slipLogs);
            }
        }

        private void slipLogsUC_Load(object sender, EventArgs e)
        {
            DisplayLogs();
        }
    }
}
