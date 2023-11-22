using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Human_Resource_Management.Employee.Modal;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal_Sub_User_Controls
{
    public partial class leaveUC : UserControl
    {
        private static employeeDetailsUserControl _parent;
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static int _userId;
        private static int _employeeId;
        public int ApplicationNumber { get; set; }
        public string DateSubmitted  { get; set; }
        public string FormStatus { get; set; }

        public leaveUC(employeeDetailsUserControl parent, int userId, int employeeId)
        {
            InitializeComponent();
            _parent = parent;
            _userId = userId;
            _employeeId = employeeId;
        }

        // Function that retrieves the Complete details of an application for leave
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

        // Custom Function that responsible for binding the value into the UI controls
        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            dateSubmitted.DataBindings.Add("Text", this, "DateSubmitted");
            Binding FormStatusFormat = new Binding("Text", this, "FormStatus");
            FormStatusFormat.Format += new ConvertEventHandler(FormStatusFormat_Format);
            formStatus.DataBindings.Add(FormStatusFormat);
        }

        // Custom function responsible for forwarding the leave details into the detailed view form
        private async Task LeaveDetailedView(int applicationNumber)
        {
            try
            {
                DataTable details = await GetLeaveDetailedView(applicationNumber);
                leaveDetailedView leave = new leaveDetailedView();

                if (details != null && details.Rows.Count == 1)
                {
                    foreach (DataRow row in details.Rows)
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
                            if (withPay && !string.IsNullOrEmpty(row["approvednumberday"].ToString()))
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

        // Custom function for formatting the form status
        private void FormStatusFormat_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Approved")
            {
                formStatus.ForeColor = Color.ForestGreen;
            }
            else if (e.Value.ToString() == "Pending")
            {
                formStatus.ForeColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                formStatus.ForeColor = Color.Red;
            }
        }

        // Event Handler that handles if this user control is laoded into the system
        private void formUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler that handles if the view button is clicked
        private async void viewFormBtn_Click(object sender, EventArgs e)
        {
            await LeaveDetailedView(ApplicationNumber);
        }
    }
}
