using System;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data.Modal
{
    public partial class viewTravelModal : Form
    {
        public viewTravelModal()
        {
            InitializeComponent();
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
