using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Leave_Logs.Modals;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Leave_Logs.Leave_logs_sub_user_control
{
    public partial class leaveLogsDataUC : UserControl
    {
        private static int _userId;
        private static leaveLogsUC _parent;
        private static int _employeeId;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ApplicationNumber { get; set; }
        public string LeaveType { get; set; }
        public string DateFiled { get; set; }
        public string DateCoverage { get; set; }
        public string Status { get; set; }

        public leaveLogsDataUC(int userId, leaveLogsUC parent, int employeeId)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        private async Task<DataTable> GetLeaveDetails(int applicationNumber)
        {
            try
            {
                DataTable leaveDetails = await generalFunctions.GetLeaveDetailedView(applicationNumber);

                if (leaveDetails != null && leaveDetails.Rows.Count > 0)
                {
                    return leaveDetails;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            dateCoverage.DataBindings.Add("Text", this, "DateCoverage");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(status_Format);
            status.DataBindings.Add(statusBinding);
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

        private async Task LeaveDetails(int applicationNumber)
        {
            try
            {
                DataTable leaveDetails = await GetLeaveDetails(applicationNumber);
                personalLeaveDetailedView leave = new personalLeaveDetailedView(_userId, this);

                if (leaveDetails != null)
                {
                    foreach (DataRow row in  leaveDetails.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["applicationNumber"].ToString()) && int.TryParse(row["applicationNumber"].ToString(), 
                            out int number))
                        {
                            leave.ApplicationNumber = number;
                        }
                        else
                        {
                            leave.ApplicationNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["recommendedBy"].ToString()))
                        {
                            leave.RecommendedBy = $"{row["recommendedBy"]}";
                        }
                        else
                        {
                            leave.RecommendedBy = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), 
                            out DateTime dateFile))
                        {
                            leave.DateCreated = dateFile.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            leave.DateCreated = "-----";
                        }

                        if ((!string.IsNullOrEmpty(row["leaveStartDate"].ToString()) && !string.IsNullOrEmpty(row["leaveEndDate"].ToString())) 
                            && (DateTime.TryParse(row["leaveStartDate"].ToString(), out DateTime startDate) &&
                            DateTime.TryParse(row["leaveEndDate"].ToString(), out DateTime endDate)))
                        {
                            leave.DateLeave = $"{startDate: MMM dd, yyyy} - {endDate: MMM dd, yyyyy}";
                        }
                        else
                        {
                            leave.DateLeave = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["certifiedBy"].ToString()) && !string.IsNullOrEmpty(row["certificationDate"].ToString()) 
                            && DateTime.TryParse(row["certificationDate"].ToString(), out DateTime certifyDate))
                        {
                            leave.CertifiedBy = $"{row["certifiedBy"]} : {certifyDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            leave.CertifiedBy = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["approvedBy"].ToString()) && !string.IsNullOrEmpty(row["approvedDate"].ToString()) 
                            && DateTime.TryParse(row["approvedDate"].ToString(), out DateTime approvedDate))
                        {
                            leave.ApprovedBy = $"{row["approvedBy"]} : {approvedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            leave.ApprovedBy = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            leave.Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            leave.Status = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            leave.FirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            leave.FirstName = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            leave.LastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            leave.LastName = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["employeeMname"].ToString()))
                        {
                            leave.MiddleName = $"{row["employeeMname"]}";
                        }
                        else
                        {
                            leave.MiddleName = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            leave.DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            leave.DepartmentName = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {
                            leave.JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            leave.JobDescription = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["salaryRateDescription"].ToString()))
                        {
                            leave.SalaryRate = $"{row["salaryRateDescription"]}";
                        }
                        else
                        {
                            leave.SalaryRate = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["leaveType"].ToString()))
                        {
                            leave.LeaveType = $"{row["leaveType"]}";
                        }
                        else
                        {
                            leave.LeaveType = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["leaveDetails"].ToString()))
                        {
                            leave.LeaveDetails = $"{row["leaveDetails"]}";
                        }
                        else
                        {
                            leave.LeaveDetails = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["withPay"].ToString()) && bool.TryParse(row["withPay"].ToString(), 
                            out bool withPay))
                        {
                            if(withPay && !string.IsNullOrEmpty(row["approvednumberday"].ToString()))
                            {
                                leave.WithPay = $"{row["approvednumberday"]} days with pay";
                            }
                            else
                            {
                                leave.WithPay = $"{row["approvednumberday"]} days without pay";
                            }
                        }
                        else
                        {
                            leave.WithPay = "-----";
                        }

                        if (!string.IsNullOrEmpty(row["disapproveReason"].ToString()))
                        {
                            leave.Reason = $"{row["disapproveReason"]}";
                        }
                        else
                        {
                            leave.Reason = "-----";
                        }
                    }
                    leave.ShowDialog();
                }
                
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void leaveLogsDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await LeaveDetails(ApplicationNumber);
            await _parent.DisplayLeave(_employeeId);
        }
    }
}
