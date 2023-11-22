using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll
{
    public partial class payroll : UserControl
    {

        // Function so that I can call this User Control to the Main Form
        private static payroll _instance;

        public static payroll Instance
        {
            get { return _instance ?? (_instance = new payroll()); }
        }

        public payroll()
        {
            InitializeComponent();
        }

        private void payroll_Load(object sender, EventArgs e)
        {
            generateAllBtn.Visible = false;
            contentList.Controls.Clear();
            employeeList payslipList = new employeeList();

            contentList.Controls.Add(payslipList);
        }

        private void thirtyBtn_Click(object sender, EventArgs e)
        {
            if (thirtyBtn.BackColor == Color.DodgerBlue)
            {
                thirtyBtn.BackColor = Color.Black;
                generateAllBtn.Visible = true;
            }
            else
            {
                thirtyBtn.BackColor = Color.DodgerBlue;
                generateAllBtn.Visible = false;
            }
        }

        private void fifteenBtn_Click(object sender, EventArgs e)
        {
            if (fifteenBtn.BackColor == Color.DodgerBlue)
            {
                fifteenBtn.BackColor = Color.Black;
                generateAllBtn.Visible = true;
            }
            else
            {
                fifteenBtn.BackColor = Color.DodgerBlue;
                generateAllBtn.Visible = false;
            }
        }

        private void todayBtn_Click(object sender, EventArgs e)
        {
            if (todayBtn.BackColor == Color.DodgerBlue)
            {
                todayBtn.BackColor = Color.Black;
                generateAllBtn.Visible = true;
            }
            else
            {
                todayBtn.BackColor = Color.DodgerBlue;
                generateAllBtn.Visible = false;
            }
        }
    }
}
