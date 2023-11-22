using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.Modal
{
    public partial class payslipDetailedView : Form
    {
        public payslipDetailedView()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
