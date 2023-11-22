using Payroll_Project2.Forms.Personnel.Payroll.Modal.User_Controls;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.Modal
{
    public partial class modifyModal : Form
    {
        public modifyModal()
        {
            InitializeComponent();
        }

        private void earningsBtn_Click(object sender, EventArgs e)
        {
            innerContent.Controls.Clear();

            earningsModify earnings = new earningsModify();

            innerContent.Controls.Add(earnings);
        }

        private void deductionBtn_Click(object sender, EventArgs e)
        {
            innerContent.Controls.Clear();

            deductionsModify deductions = new deductionsModify();

            innerContent.Controls.Add(deductions);
        }
    }
}
