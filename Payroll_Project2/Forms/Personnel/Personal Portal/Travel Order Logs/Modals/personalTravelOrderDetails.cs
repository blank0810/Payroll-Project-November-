using Payroll_Project2.Forms.Personnel.Personal_Portal.Travel_Order_Logs.Travel_order_log_sub_user_control;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Travel_Order_Logs.Modals
{
    public partial class personalTravelOrderDetails : Form
    {
        public int ControlNumber { get; set; }
        public string NotedBy { get; set; }
        public string DateCreated { get; set; }
        public string DepartureDate { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DepartureTime { get; set; }
        public string ReturnTime { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public string Remarks { get; set; }
        public string Reason { get; set; }

        public personalTravelOrderDetails()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            controlNo.DataBindings.Add("Text", this, "ControlNumber");
            notedBy.DataBindings.Add("Text", this, "NotedBy");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            departureDate.DataBindings.Add("Text", this, "DepartureDate");
            dateAndNameApproval.DataBindings.Add("Text", this, "ApprovedBy");
            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            departureTime.DataBindings.Add("Text", this, "DepartureTime");
            returnTime.DataBindings.Add("Text", this, "ReturnTime");
            destination.DataBindings.Add("Text", this, "Destination");
            purpose.DataBindings.Add("Text", this, "Purpose");
            remarks.DataBindings.Add("Text", this, "Remarks");
            reason.DataBindings.Add("Text", this, "Reason");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(status_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void personalTravelOrderDetails_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void status_Format(object sender, ConvertEventArgs e)
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
