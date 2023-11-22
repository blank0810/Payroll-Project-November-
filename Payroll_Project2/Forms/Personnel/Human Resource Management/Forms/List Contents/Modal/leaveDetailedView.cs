using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal
{
    public partial class leaveDetailedView : Form
    {
        private static int _userId;

        public int ApplicationNumber { get; set; }
        public string RecommendedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateLeave { get; set; }
        public string CertifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Extension { get; set; }
        public string DepartmentName { get; set; }
        public string JobDescription { get; set; }
        public string SalaryRate { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDetails { get; set; }
        public string WithPay { get; set; }
        public string Reason { get; set; }

        public leaveDetailedView(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            recommendedBy.DataBindings.Add("Text", this, "RecommendedBy");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            leaveDate.DataBindings.Add("Text", this, "DateLeave");
            certifiedBy.DataBindings.Add("Text", this, "CertifiedBy");
            approvedBy.DataBindings.Add("Text", this, "ApprovedBy");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(statusBinding_Format);
            status.DataBindings.Add(statusBinding);

            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            suffix.DataBindings.Add("Text", this, "Extension");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            leaveDetails.DataBindings.Add("Text", this, "LeaveDetails");
            numberDays.DataBindings.Add("Text", this, "WithPay");
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

        private void leaveDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
