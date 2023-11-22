using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.User_Controls
{
    public partial class detailsUC : UserControl
    {
        public detailsUC()
        {
            InitializeComponent();
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            payslipDetailedView detailedView = new payslipDetailedView();
            detailedView.ShowDialog();
        }
    }
}
