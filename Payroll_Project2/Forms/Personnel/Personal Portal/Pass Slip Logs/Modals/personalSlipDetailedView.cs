using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Pass_Slip_Logs.Modals
{
    public partial class personalSlipDetailedView : Form
    {
        public int ControlNumber { get; set; }
        public string NotedBy { get; set; }
        public string DateCreated { get; set; }
        public string SlipDate { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SlipTime { get; set; }
        public string Destination { get; set; }
        public string Reason { get; set; }

        public personalSlipDetailedView()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            controlNo.DataBindings.Add("Text", this, "ControlNumber");
            notedBy.DataBindings.Add("Text", this, "NotedBy");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            slipDate.DataBindings.Add("Text", this, "SlipDate");
            dateAndNameApproval.DataBindings.Add("Text", this, "ApprovedBy");
            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            slipTime.DataBindings.Add("Text", this, "SlipTime");
            destination.DataBindings.Add("Text", this, "Destination");
            reason.DataBindings.Add("Text", this, "Reason");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(Status_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void personalSlipDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void Status_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Approved")
            {
                status.ForeColor = Color.ForestGreen;
            }
            else if (e.Value.ToString() == "Pending")
            {
                status.ForeColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                status.ForeColor = Color.Red;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
