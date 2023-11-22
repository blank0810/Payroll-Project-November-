using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll
{
    public partial class payrollList : UserControl
    {
        // Function so that I can call this User Control to the Main Form
        private static payrollList _instance;

        public static payrollList Instance
        {
            get { return _instance ?? (_instance = new payrollList()); }
        }

        public payrollList()
        {
            InitializeComponent();
        }

        // For the content
        private void payrollList_Load(object sender, EventArgs e)
        {
            listContent.Controls.Clear();

            payrollListUC list = new payrollListUC();
            listContent.Controls.Add(list);
        }

        private void listContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
