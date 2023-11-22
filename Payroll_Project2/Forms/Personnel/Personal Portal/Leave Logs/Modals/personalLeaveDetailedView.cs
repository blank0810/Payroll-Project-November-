using Payroll_Project2.Forms.Personnel.Personal_Portal.Leave_Logs.Leave_logs_sub_user_control;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Leave_Logs.Modals
{
    public partial class personalLeaveDetailedView : Form
    {
        private static int _userId;
        private static leaveLogsDataUC _parent;

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
        public string DepartmentName { get; set; }
        public string JobDescription { get; set; }
        public string SalaryRate { get; set; }
        public string LeaveType { get; set; }
        public string LeaveDetails { get; set; }
        public string WithPay { get; set; }
        public string Reason { get; set; }

        public personalLeaveDetailedView(int userId, leaveLogsDataUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            recommendedBy.DataBindings.Add("Text", this, "RecommendedBy");
            dateCreated.DataBindings.Add("Text", this, "DateCreated");
            leaveDate.DataBindings.Add("Text", this, "DateLeave");
            certifiedBy.DataBindings.Add("Text", this, "CertifiedBy");
            approvedBy.DataBindings.Add("Text", this, "ApprovedBy");
            firstName.DataBindings.Add("Text", this, "FirstName");
            lastName.DataBindings.Add("Text", this, "LastName");
            middleName.DataBindings.Add("Text", this, "MiddleName");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            jobDescription.DataBindings.Add("Text", this, "JobDescription");
            salaryRate.DataBindings.Add("Text", this, "SalaryRate");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            leaveDetails.DataBindings.Add("Text", this, "LeaveDetails");
            numberDays.DataBindings.Add("Text", this, "WithPay");
            reason.DataBindings.Add("Text", this, "Reason");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(Status_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void Status_Format (object sender, ConvertEventArgs e)
        {
            if(e.Value.ToString() == "Approved")
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

        private void personalLeaveDetailedView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
