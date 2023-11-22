using Payroll_Project2.Forms.Personnel.Payroll.Modal.User_Controls;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.Modal
{
    public partial class payslip : Form
    {
        public payslip()
        {
            InitializeComponent();
        }

        private void payslip_Load(object sender, EventArgs e)
        {
            deductionsContent.Controls.Clear();
            earningsContent.Controls.Clear();

            deductionsUC deduction = new deductionsUC();
            earningsUC earnings = new earningsUC();

            earningsContent.Controls.Add(earnings);
            deductionsContent.Controls.Add(deduction);
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            modifyModal modify = new modifyModal();
            modify.ShowDialog();
        }

        private void label47_Click(object sender, EventArgs e)
        {

        }
    }
}
