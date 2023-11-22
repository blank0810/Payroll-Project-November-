using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal.User_Controls_For_Modal
{
    public partial class leaveListDataUC : UserControl
    {
        private static formClass formClass;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static int _userId;
        private static listUC _parent;

        public int ApplicationNumber { get; set; }
        public string Status { get; set; }
        public string DateApproved { get; set; }

        public leaveListDataUC(int userId, listUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetLeaveDetailedView(int applicationNumber)
        {
            try
            {
                formClass = new formClass();
                DataTable details = await generalFunctions.GetLeaveDetailedView(applicationNumber);

                if (details != null)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void LeaveDetailedView(int applicationNumber)
        {
            try
            {
                DataTable details = await GetLeaveDetailedView(applicationNumber);

                if (details != null && details.Rows.Count == 1)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        leaveDetailedView leaveDetailedView = new leaveDetailedView(_userId);

                        leaveDetailedView.ApplicationNumber = (int)row["applicationNumber"];

                        DateTime dateRecommended = Convert.ToDateTime(row["dateRecommended"]);
                        leaveDetailedView.RecommendedBy = row["recommendedBy"].ToString() + " / " + dateRecommended.ToString("MMMM dd, yyyy");

                        DateTime dateCreated = Convert.ToDateTime(row["dateFile"]);
                        leaveDetailedView.DateCreated = dateCreated.ToString("MMMM dd, yyyy");

                        DateTime leaveDate = Convert.ToDateTime(row["leaveDate"]);
                        leaveDetailedView.DateLeave = leaveDate.ToString("MMMM dd, yyyy");

                        DateTime certifiedDate = Convert.ToDateTime(row["certificationDate"]);
                        leaveDetailedView.CertifiedBy = row["certifiedBy"].ToString() + " / " + certifiedDate.ToString("MMMM dd, yyyy");

                        DateTime approvedDate = Convert.ToDateTime(row["approvedDate"]);
                        leaveDetailedView.ApprovedBy = row["approvedBy"].ToString() + " / " + approvedDate.ToString("MMMM dd, yyyy");

                        leaveDetailedView.Status = row["statusDescription"].ToString();
                        leaveDetailedView.FirstName = row["employeeFname"].ToString();
                        leaveDetailedView.LastName = row["employeeLname"].ToString();
                        leaveDetailedView.MiddleName = row["employeeMname"].ToString();

                        if (string.IsNullOrEmpty(row["employeeExtension"].ToString()))
                        {
                            leaveDetailedView.Extension = "N/A";
                        }
                        else
                        {
                            leaveDetailedView.Extension = row["employeeExtension"].ToString();
                        }

                        leaveDetailedView.DepartmentName = row["departmentName"].ToString();
                        leaveDetailedView.JobDescription = row["employeeJobDesc"].ToString();
                        leaveDetailedView.SalaryRate = row["salaryRateDescription"].ToString();
                        leaveDetailedView.LeaveType = row["leaveType"].ToString();
                        leaveDetailedView.LeaveDetails = row["leaveDetails"].ToString();

                        if ((bool)row["withPay"])
                        {
                            leaveDetailedView.WithPay = row["approvedNumberDay"].ToString() + " Day/s";
                        }
                        else
                        {
                            leaveDetailedView.WithPay = "Not Applicable";
                        }

                        leaveDetailedView.Reason = row["disapproveReason"].ToString();

                        leaveDetailedView.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("We apologize for the inconvenience, but there is currently an issue with viewing the " +
                        "complete details of this Form. Kindly contact the IT department for immediate assistance and resolution.", 
                        "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            dateApproved.DataBindings.Add("Text", this, "DateApproved");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(statusBinding_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void leaveList_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void statusBinding_Format(object sender, ConvertEventArgs e)
        {
            if(e.Value.ToString() != "Approved")
            {
                status.ForeColor = Color.Red;
            }
            else
            {
                status.ForeColor = Color.Green;
            }
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            LeaveDetailedView(ApplicationNumber);
        }
    }
}
