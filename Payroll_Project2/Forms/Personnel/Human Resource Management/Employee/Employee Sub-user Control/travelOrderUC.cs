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
    public partial class travelOrderUC : UserControl
    {
        private static employeeDetailsUserControl _parent;
        private static formClass formClass = new formClass();
        private static generalFunctions generalFunctions = new generalFunctions();
        private static int _userId;
        private static int _employeeId;
        public int ControlNumber { get; set; }
        public string DateSubmitted { get; set; }
        public string FormStatus { get; set; }

        public travelOrderUC(employeeDetailsUserControl parent, int userId, int employeeId)
        {
            InitializeComponent();
            _parent = parent;
            _employeeId = employeeId;
            _userId = userId;
        }

        // Function responsible for retrieving the travel order details
        private async Task<DataTable> GetTravelDetailedView(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetTravelDetailedView(controlNumber);
                return details;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for forwarding the travel order details to detailed form
        private async Task TravelDetails(int controlNumber, string status, string dateFiled)
        {
            try
            {
                DataTable details = await GetTravelDetailedView(controlNumber);
                travelOrderDetailedView travelOrder = new travelOrderDetailedView();

                if (details != null && details.Rows.Count == 1)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        travelOrder.ControlNumber = controlNumber;
                        travelOrder.DateCreated = dateFiled;
                        travelOrder.Status = status;

                        if (!string.IsNullOrEmpty(row["notedBy"].ToString()) && !string.IsNullOrEmpty(row["notedDate"].ToString())
                            && DateTime.TryParse(row["notedDate"].ToString(), out DateTime notedDate))
                        {
                            travelOrder.NotedBy = $"{row["notedBy"]} - {notedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelOrder.NotedBy = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["approvedBy"].ToString()) && !string.IsNullOrEmpty(row["approvedDate"].ToString())
                            && DateTime.TryParse(row["approvedDate"].ToString(), out DateTime approvedDate))
                        {
                            travelOrder.ApprovedBy = $"{row["approvedBy"]} - {approvedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelOrder.ApprovedBy = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            travelOrder.FirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            travelOrder.FirstName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            travelOrder.LastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            travelOrder.LastName = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeMname"].ToString()))
                        {
                            travelOrder.MiddleName = $"{row["employeeMname"]}";
                        }
                        else
                        {
                            travelOrder.MiddleName = "------";
                        }

                        if (!string.IsNullOrEmpty(row["dateDeparture"].ToString()) && DateTime.TryParse(row["dateDeparture"].ToString(), 
                            out DateTime departureDate))
                        {
                            travelOrder.DepartureDate = $"{departureDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelOrder.DepartureDate = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["departureTime"].ToString()))
                        {
                            travelOrder.DepartureTime = $"{row["departureTime"]: hh:mm tt}";
                        }
                        else
                        {
                            travelOrder.DepartureTime = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["returnTime"].ToString()))
                        {
                            travelOrder.ReturnTime = $"{row["returnTime"]: hh:mm tt}";
                        }
                        else
                        {
                            travelOrder.ReturnTime = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["destination"].ToString()))
                        {
                            travelOrder.Destination = $"{row["destination"]}";
                        }
                        else
                        {
                            travelOrder.Destination = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["purpose"].ToString()))
                        {
                            travelOrder.Purpose = $"{row["purpose"]}";
                        }
                        else
                        {
                            travelOrder.Purpose = "------";
                        }

                        if (!string.IsNullOrEmpty(row["remarks"].ToString()))
                        {
                            travelOrder.Remarks = $"{row["remarks"]}";
                        }
                        else
                        {
                            travelOrder.Remarks = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["deniedReason"].ToString()))
                        {
                            travelOrder.Reason = $"{row["deniedReason"]}";
                        }
                        else
                        {
                            travelOrder.Reason = "Not Applicable";
                        }

                        travelOrder.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("We apologize for the inconvenience, but there is currently an issue with viewing the complete details of " +
                        "this Form. Kindly contact the IT department for immediate assistance and resolution.",
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

        // Custom function for binding values into UI controls
        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateSubmitted.DataBindings.Add("Text", this, "DateSubmitted");
            Binding formStatusBinding = new Binding("Text", this, "FormStatus");
            formStatusBinding.Format += new ConvertEventHandler(FormStatusBinding_Format);
            formStatus.DataBindings.Add(formStatusBinding);
        }

        // Custom function for formating the status of travel order
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

        // Event Handler that handles if this user control is loaded into the system
        private void travelOrderUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler that handles if the view button is clicked
        private async void viewFormBtn_Click(object sender, EventArgs e)
        {
            await TravelDetails(ControlNumber, FormStatus, DateSubmitted);
        }
    }
}
