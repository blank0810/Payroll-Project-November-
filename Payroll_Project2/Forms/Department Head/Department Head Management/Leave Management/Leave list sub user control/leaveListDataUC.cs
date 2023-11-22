using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Leave_Management.Modals;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Leave_Management.Leave_list_sub_user_control
{
    public partial class leaveListDataUC : UserControl
    {
        private static int _userId;
        private static leaveListsUC _parent;
        private static int _employeeId;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ApplicationNumber { get; set; }
        public string LeaveType { get; set; }
        public string DateFiled { get; set; }
        public string DateCoverage { get; set; }
        public string Status { get; set; }

        public leaveListDataUC(int userId, leaveListsUC parent, int employeeId)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        private async Task<DataTable> GetLeaveDetailedView(int applicationNumber)
        {
            try
            {
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
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DisplayLeaveDetails(int applicationNumber, string leaveType, string dateFiled, string status, string dateCoverage)
        {
            try
            {
                DataTable details = await GetLeaveDetailedView(applicationNumber);

                if(details != null)
                {
                    leaveDetailedView leave = new leaveDetailedView(_userId);
                    
                    foreach (DataRow row in details.Rows)
                    {
                        leave.ApplicationNumber = applicationNumber;
                        leave.LeaveType = leaveType;
                        leave.DateCreated = dateFiled;
                        leave.Status = status;
                        leave.DateLeave = dateCoverage;

                        if (!string.IsNullOrEmpty(row["isRecommended"].ToString()) && !string.IsNullOrEmpty(row["recommendedBy"].ToString()) &&
                            !string.IsNullOrEmpty(row["dateRecommended"].ToString()) && DateTime.TryParse(row["dateRecommended"].ToString(), 
                            out DateTime dateRecommended))
                        {
                            leave.RecommendedBy = $"{row["recommendedBy"]} - {dateRecommended: MMM dd, yyyy}";
                        }
                        else
                        {
                            leave.RecommendedBy = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["isCertified"].ToString()) && !string.IsNullOrEmpty(row["certifiedBy"].ToString()) &&
                            !string.IsNullOrEmpty(row["certificationDate"].ToString()) && DateTime.TryParse(row["certificationDate"].ToString(), 
                            out DateTime certificationDate))
                        {
                            leave.CertifiedBy = $"{row["certifiedBy"]} - {certificationDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            leave.CertifiedBy = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["isApproved"].ToString()) && !string.IsNullOrEmpty(row["approvedDate"].ToString()) &&
                            !string.IsNullOrEmpty(row["approvedBy"].ToString()) && DateTime.TryParse(row["approvedDate"].ToString(), 
                            out DateTime approvedDate))
                        {
                            leave.ApprovedBy = $"{row["approvedBy"]} - {approvedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            leave.ApprovedBy = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            leave.FirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            leave.FirstName = "------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            leave.LastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            leave.LastName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeMname"].ToString()))
                        {
                            leave.MiddleName = $"{row["employeeMname"]}";
                        }
                        else
                        {
                            leave.MiddleName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            leave.DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            leave.DepartmentName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {
                            leave.JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            leave.JobDescription = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateDescription"].ToString()))
                        {
                            leave.SalaryRate = $"{row["salaryRateDescription"]}";
                        }
                        else
                        {
                            leave.SalaryRate = "------";
                        }

                        if (!string.IsNullOrEmpty(row["leaveDetails"].ToString()))
                        {
                            leave.LeaveDetails = $"{row["leaveDetails"]}";
                        }
                        else
                        {
                            leave.LeaveDetails = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["withPay"].ToString()) && !string.IsNullOrEmpty(row["approvednumberday"].ToString()) &&
                            bool.TryParse(row["withPay"].ToString(), out bool withPay))
                        {
                            if(withPay)
                            {
                                leave.WithPay = $"With pay: {row["approvednumberday"]} days";
                            }
                            else
                            {
                                leave.WithPay = $"Without Pay {row["approvednumberday"]} days";
                            }
                        }
                        else
                        {
                            leave.WithPay = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["disapproveReason"].ToString()))
                        {
                            leave.Reason = $"{row["disapproveReason"]}";
                        }
                        else
                        {
                            leave.Reason = "----------";
                        }

                        leave.ShowDialog();
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            dateCoverage.DataBindings.Add("Text", this, "DateCoverage");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(Status_Format);
            status.DataBindings.Add(statusBinding);
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

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeaveDetails(ApplicationNumber, LeaveType, DateFiled, Status, DateCoverage);
            await _parent.DisplayLeaveList(_employeeId);
        }

        private void leaveListDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
