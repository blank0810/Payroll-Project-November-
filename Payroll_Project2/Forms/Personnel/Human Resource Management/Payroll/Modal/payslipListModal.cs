using Payroll_Project2.Forms.Personnel.Payroll.User_Controls;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Payroll.Modal
{
    public partial class payslipListModal : Form
    {
        static payslipListModal _obj;

        public static payslipListModal Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new payslipListModal();
                }
                return _obj;
            }
        }

        public Panel panelContent
        {
            get { return modalContent; }
            set { modalContent = value; }
        }

        public payslipListModal()
        {
            InitializeComponent();
        }

        private void payslipListModal_Load(object sender, EventArgs e)
        {
            detailsUC details = new detailsUC();
            listContent.Controls.Add(details);
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
