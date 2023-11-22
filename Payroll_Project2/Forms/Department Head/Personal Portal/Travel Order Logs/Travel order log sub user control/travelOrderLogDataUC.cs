using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Travel_Order_Logs.Modals;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Travel_Order_Logs.Travel_order_log_sub_user_control
{
    public partial class travelOrderLogDataUC : UserControl
    {
        private static int _userId;
        private static travelOrderLogUC _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string DateDeparture { get; set; }
        public string Status { get; set; }

        public travelOrderLogDataUC(int userId, travelOrderLogUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetTravelDetails(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetTravelDetailedView(controlNumber);
                return details;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task TravelDetails(int controlNumber, string dateFiled, string dateDeparture, string status)
        {
            try
            {
                DataTable details = await GetTravelDetails(controlNumber);
                personalTravelOrderDetails travelOrder = new personalTravelOrderDetails();

                if (details != null)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        travelOrder.ControlNumber = controlNumber;
                        travelOrder.DateCreated = dateFiled;
                        travelOrder.DepartureDate = dateDeparture;
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
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            dateDeparture.DataBindings.Add("Text", this, "DateDeparture");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(status_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void travelOrderLogDataUC_Load(object sender, EventArgs e)
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
            await TravelDetails(ControlNumber, DateFiled, DateDeparture, Status);
        }
    }
}
