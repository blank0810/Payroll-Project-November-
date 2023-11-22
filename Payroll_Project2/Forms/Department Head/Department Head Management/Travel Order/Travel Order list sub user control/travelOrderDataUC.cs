using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Travel_Order.Modals;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Travel_Order.Travel_Order_list_sub_user_control
{
    public partial class travelOrderDataUC : UserControl
    {
        private static int _userId;
        private static travelOrderListsUC _parent;
        private static int _employeeId;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int ControlNumber { get; set; }
        public string DateFiled { get; set; }
        public string DateDeparture { get; set; }
        public string Status { get; set; }

        public travelOrderDataUC(int userId, travelOrderListsUC parent, int employeeId)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _employeeId = employeeId;
        }

        private async Task<DataTable> GetTravelDetails(int controlNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetTravelDetailedView(controlNumber);

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

        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            dateDeparture.DataBindings.Add("Text", this, "DateDeparture");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(Status_Format);
            status.DataBindings.Add(statusBinding);
        }

        private async Task DisplayTravelDetails(int controlNumber, string dateFiled, string dateDeparture, string status)
        {
            try
            {
                DataTable details = await GetTravelDetails(controlNumber);
                travelOrderDetailedView travel = new travelOrderDetailedView(_userId, this);

                if (details != null)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        travel.ControlNumber = controlNumber;
                        travel.DateCreated = dateFiled;
                        travel.DepartureDate = dateDeparture;
                        travel.Status = status;

                        if (!string.IsNullOrEmpty(row["isNoted"].ToString()) && !string.IsNullOrEmpty(row["notedBy"].ToString()) &&
                            !string.IsNullOrEmpty(row["notedDate"].ToString()) && DateTime.TryParse(row["notedDate"].ToString(),
                            out DateTime notedDate))
                        {
                            travel.NotedBy = $"{row["notedBy"]} - {notedDate: MMM dd, yyyy}";
                        }
                        else
                        {
                            travel.NotedBy = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["isApproved"].ToString()) && !string.IsNullOrEmpty(row["approvedBy"].ToString()) &&
                            !string.IsNullOrEmpty(row["approvedDate"].ToString()) && DateTime.TryParse(row["approvedDate"].ToString(),
                            out DateTime approvedDate))
                        {
                            travel.ApprovedBy = $"{row["approvedBy"]} - {approvedDate: MMM dd, yyy}";
                        }
                        else
                        {
                            travel.ApprovedBy = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()))
                        {
                            travel.FirstName = $"{row["employeeFname"]}";
                        }
                        else
                        {
                            travel.FirstName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            travel.LastName = $"{row["employeeLname"]}";
                        }
                        else
                        {
                            travel.LastName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeMname"].ToString()))
                        {
                            travel.MiddleName = $"{row["employeeMname"]}";
                        }
                        else
                        {
                            travel.MiddleName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["departureTime"].ToString()) && DateTime.TryParse(row["departureTime"].ToString(),
                            out DateTime departureTime))
                        {
                            travel.DepartureTime = $"{departureTime: hh:mm tt}";
                        }
                        else
                        {
                            travel.DepartureTime = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["returnTime"].ToString()) && DateTime.TryParse(row["returnTime"].ToString(),
                            out DateTime returnTime))
                        {
                            travel.ReturnTime = $"{returnTime: hh:mm tt}";
                        }
                        else
                        {
                            travel.ReturnTime = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["destination"].ToString()))
                        {
                            travel.Destination = $"{row["destination"]}";
                        }
                        else
                        {
                            travel.Destination = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["purpose"].ToString()))
                        {
                            travel.Purpose = $"{row["purpose"]}";
                        }
                        else
                        {
                            travel.Purpose = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["remarks"].ToString()))
                        {
                            travel.Remarks = $"{row["remarks"]}";
                        }
                        else
                        {
                            travel.Remarks = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["deniedReason"].ToString()))
                        {
                            travel.Reason = $"{row["deniedReason"]}";
                        }
                        else
                        {
                            travel.Reason = "---------";
                        }

                        travel.ShowDialog();
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

        private void travelOrderDataUC_Load(object sender, EventArgs e)
        {
            DataBinding(); 
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayTravelDetails(ControlNumber, DateFiled, DateDeparture, Status);
            await _parent.DisplayTravelLogs(_employeeId);
        }
    }
}
