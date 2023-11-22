using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal
{
    public partial class travelOrderDetailedView : Form
    {
        private static int _userId;

        public int ControlNumber { get; set; }
        public string NotedBy { get; set; }
        public string DateCreated { get; set; }
        public string DepartureDate { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Extension { get; set; }
        public string DepartureTime { get; set; }
        public string ReturnTime { get; set; }
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public string Remarks { get; set; }
        public string Reason { get; set; }

        public travelOrderDetailedView(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void DataBinding()
        {
            controlNo.DataBindings.Add("Text", this, "ControlNumber");
            notedBy.DataBindings.Add("Text", this, "NotedBy");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            departureDate.DataBindings.Add("Text", this, "DepartureDate");
            dateAndNameApproval.DataBindings.Add("Text", this, "ApprovedBy");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(statusBinding_Format);
            status.DataBindings.Add(statusBinding);

            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            suffix.DataBindings.Add("Text", this, "Extension");
            departureTime.DataBindings.Add("Text", this, "DepartureTime");
            returnTime.DataBindings.Add("Text", this, "ReturnTime");
            destination.DataBindings.Add("Text", this, "Destination");
            purpose.DataBindings.Add("Text", this, "Purpose");
            reason.DataBindings.Add("Text", this, "Reason");
        }

        private void statusBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() != "Approved")
            {
                status.ForeColor = Color.Red;
            }
            else
            {
                status.ForeColor = Color.Green;
            }
        }

        private void travelOrderDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
