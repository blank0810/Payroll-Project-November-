using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data
{
    public partial class applicationForLeaveData : UserControl
    {
        public applicationForLeaveData()
        {
            InitializeComponent();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            viewLeaveModal leave = new viewLeaveModal();
            leave.ShowDialog();
        }
    }
}
