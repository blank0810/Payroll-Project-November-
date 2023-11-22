using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Employee.Leave_Logs.Leave_logs_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Payroll_Project2.Forms.Employee.Leave_Logs
{
    public partial class leaveLogsUC : UserControl
    {
        private static int _userId;

        public leaveLogsUC()
        {
            InitializeComponent();
        }

        private void DisplayLeave()
        {
            listContentPanel.Controls.Clear();
            month.SelectedIndex = 0;

            for (int i = 0; i < 5; i++)
            {
                leaveLogsDataUC leaveLog = new leaveLogsDataUC();
                listContentPanel.Controls.Add(leaveLog);
            }
        }

        private void leaveLogsUC_Load(object sender, EventArgs e)
        {
            DisplayLeave();
        }
    }
}
