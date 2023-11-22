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

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control
{
    public partial class passSlipUC : UserControl
    {
        private static employeeDetailsUserControl _parent;
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static int _userId;
        private static int _employeeId;
        public int ControlNumber { get; set; }
        public string DateSubmitted { get; set; }
        public string FormStatus { get; set; }

        public passSlipUC(employeeDetailsUserControl parent, int userId, int employeeId)
        {
            InitializeComponent();
            _parent = parent;
            _employeeId = employeeId;
            _userId = userId;
        }

        // Function responsible for Retrieving the pass slip details
        private async Task<DataTable> GetSlipDetailedView(int controlNumber)
        {
            try
            {
                formClass = new formClass();
                DataTable details = await generalFunctions.GetSlipDetailedView(controlNumber);
                return details;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for binding Values into the controls
        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateSubmitted.DataBindings.Add("Text", this, "DateSubmitted");
            Binding formStatusBinding = new Binding("Text", this, "FormStatus");
            formStatusBinding.Format += new ConvertEventHandler(FormStatusBinding_Format);
            formStatus.DataBindings.Add(formStatusBinding);
        }

        // Custom function for formating the status of pass slipp
        private void FormStatusBinding_Format(object sender, ConvertEventArgs e)
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

        // custom function responsible for forwarding the pass slip details into detailed form
        private async Task SlipDetails(int controlNumber, string status, string dateFiled)
        {
            try
            {
                slipDetailedView slip = new slipDetailedView();
                DataTable details = await GetSlipDetailedView(controlNumber);

                if (details != null && details.Rows.Count == 1)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        slip.ControlNumber = controlNumber;
                        slip.Status = status;

                        if (!string.IsNullOrEmpty(row["slipNotedBy"].ToString()) && !string.IsNullOrEmpty(row["slipNotedDate"].ToString()) &&
                            DateTime.TryParse(row["slipNotedDate"].ToString(), out DateTime notedDate))
                        {
                            slip.NotedBy = $"{row["slipNotedBy"]} - {notedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            slip.NotedBy = "---------";
                        }

                        if (DateTime.TryParse(dateFiled, out DateTime dateCreated))
                        {
                            slip.DateCreated = $"{dateCreated: MMMM dd, yyyyy}";
                        }
                        else
                        {
                            slip.DateCreated = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["slipDate"].ToString()) && DateTime.TryParse(row["slipDate"].ToString(),
                            out DateTime slipDate))
                        {
                            slip.SlipDate = $"{slipDate: MMMM dd, yyyy}";
                        }
                        else
                        {
                            slip.SlipDate = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["approvedBy"].ToString()) && !string.IsNullOrEmpty(row["approvedDate"].ToString())
                            && DateTime.TryParse(row["approvedDate"].ToString(), out DateTime approvedDate))
                        {
                            slip.ApprovedBy = $"{row["approvedBy"]} - {approvedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            slip.ApprovedBy = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            slip.FirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            slip.FirstName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            slip.LastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            slip.LastName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeMname"].ToString()))
                        {
                            slip.MiddleName = $"{row["employeeMname"]}";
                        }
                        else
                        {
                            slip.MiddleName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["slipStartingTime"].ToString()) && !string.IsNullOrEmpty(row["slipEndingTime"].ToString()))
                        {
                            slip.SlipTime = $"{row["slipStartingTime"]: hh:mm tt} - {row["slipEndingTime"]: hh:mm tt}";
                        }
                        else
                        {
                            slip.SlipTime = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["slipDestination"].ToString()))
                        {
                            slip.Destination = $"{row["slipDestination"]}";
                        }
                        else
                        {
                            slip.Destination = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["deniedReason"].ToString()))
                        {
                            slip.Reason = $"{row["deniedReason"]}";
                        }
                        else
                        {
                            slip.Reason = "Not Applicable";
                        }

                        slip.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("We apologize for the inconvenience, but there is currently an issue with viewing the complete " +
                        "details of this Form. Kindly contact the IT department for immediate assistance and resolution.",
                        "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Sql Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Event handler that handles if this user control is loaded into the system
        private void passSlipUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler when the view button is click
        private async void viewFormBtn_Click(object sender, EventArgs e)
        {
            await SlipDetails(ControlNumber, FormStatus, DateSubmitted);
        }
    }
}
