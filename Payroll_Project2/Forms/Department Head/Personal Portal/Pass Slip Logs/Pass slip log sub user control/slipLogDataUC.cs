using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Pass_Slip_Logs.Modals;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Pass_Slip_Logs.Pass_slip_log_sub_user_control
{
    public partial class slipLogDataUC : UserControl
    {
        private static int _userId;
        private static slipLogsUC _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string Status { get; set; }

        public slipLogDataUC(int userId, slipLogsUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetSlipDetails(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetSlipDetailedView(controlNumber);

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

        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(status_Format);
            status.DataBindings.Add(statusBinding);
        }

        private async Task SlipDetailedView(int controlNumber, string status)
        {
            try
            {
                DataTable details = await GetSlipDetails(controlNumber);
                personalSlipDetailedView slip = new personalSlipDetailedView();

                if (details != null)
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

                        if (DateTime.TryParse(DateFiled, out DateTime dateCreated))
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

        private void slipLogDataUC_Load(object sender, EventArgs e)
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

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await SlipDetailedView(ControlNumber, Status);
            await _parent.DisplayLogs();
        }
    }
}
