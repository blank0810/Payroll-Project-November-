using Payroll_Project2.Forms.Employee.Pass_Slip_Logs.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Pass_Slip_Logs.Pass_slip_log_sub_user_control
{
    public partial class slipLogDataUC : UserControl
    {
        private static int _userId;
        private static slipLogsUC _parent;

        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string Status { get; set; }

        public slipLogDataUC()
        {
            InitializeComponent();
        }

        private void slipLogDataUC_Load(object sender, EventArgs e)
        {

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            personalSlipDetailedView slip = new personalSlipDetailedView();
            slip.ShowDialog();
        }
    }
}
