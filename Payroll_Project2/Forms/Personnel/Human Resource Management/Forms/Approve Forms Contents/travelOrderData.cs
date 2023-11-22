using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data
{
    public partial class travelOrderData : UserControl
    {
        public travelOrderData()
        {
            InitializeComponent();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            viewTravelModal travelOrder = new viewTravelModal();
            travelOrder.ShowDialog();
        }
    }
}
