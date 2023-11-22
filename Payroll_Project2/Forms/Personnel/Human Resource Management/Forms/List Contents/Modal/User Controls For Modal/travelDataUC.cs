using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal.User_Controls_For_Modal
{
    public partial class travelDataUC : UserControl
    {
        private static int _userId;
        private static listUC _parent;
        private static formClass formClass;

        public int ControlNumber { get; set; }
        public string Status { get; set; }
        public string DateApproved { get; set; }

        public travelDataUC(int userId, listUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetTravelDetailedView(int controlNumber)
        {
            try
            {
                formClass = new formClass();
                DataTable details = await formClass.GetTravelDetailedView(controlNumber);
                return details;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void TravelDetails(int controlNumber)
        {
            try
            {
                DataTable details = await GetTravelDetailedView(controlNumber);
                travelOrderDetailedView travelView = new travelOrderDetailedView(_userId);

                if (details != null && details.Rows.Count == 1)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        travelView.ControlNumber = (int)row["orderControlNumber"];

                        DateTime notedDate = Convert.ToDateTime(row["notedDate"]);
                        travelView.NotedBy = row["notedBy"].ToString() + " / " + notedDate.ToString("MMMM dd, yyyy");

                        DateTime dateCreated = Convert.ToDateTime(row["dateFiled"]);
                        travelView.DateCreated = dateCreated.ToString("MMMM dd, yyyy");

                        DateTime departureDate = Convert.ToDateTime(row["dateDeparture"]);
                        travelView.DepartureDate = departureDate.ToString("MMMM dd, yyyy");

                        DateTime approvedDate = Convert.ToDateTime(row["approvedDate"]);
                        travelView.ApprovedBy = row["approvedBy"].ToString() + " / " + approvedDate.ToString("MMMM dd, yyyy");

                        travelView.Status = row["statusDescription"].ToString();
                        travelView.FirstName = row["employeeFname"].ToString();
                        travelView.LastName = row["employeeLname"].ToString();
                        travelView.MiddleName = row["employeeMname"].ToString();

                        if (string.IsNullOrEmpty(row["employeeExtension"].ToString()))
                        {
                            travelView.Extension = "N/A";
                        }
                        else
                        {
                            travelView.Extension = row["employeeExtension"].ToString();
                        }

                        DateTime departureTime = Convert.ToDateTime(row["departureTime"]);
                        travelView.DepartureTime = departureTime.ToString("t");

                        DateTime returnTime = Convert.ToDateTime(row["returnTime"]);
                        travelView.ReturnTime = returnTime.ToString("t");

                        travelView.Destination = row["destination"].ToString();
                        travelView.Purpose = row["purpose"].ToString();
                        travelView.Remarks = row["remarks"].ToString();

                        if (string.IsNullOrEmpty(row["deniedReason"].ToString()))
                        {
                            travelView.Reason = "N/A";
                        }
                        else
                        {
                            travelView.Reason = row["deniedReason"].ToString();
                        }

                        travelView.ShowDialog();
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

        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            dateApproved.DataBindings.Add("Text", this, "DateApproved");

            Binding statusBinding = new Binding("Text", this, "Status");
            statusBinding.Format += new ConvertEventHandler(statusBinding_Format);
            status.DataBindings.Add(statusBinding);
        }

        private void statusBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() != "Approved")
            {
                status.ForeColor = Color.Red;
            }
            else
            {
                status.ForeColor = Color.Green;
            }
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void travelDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            TravelDetails(ControlNumber);
        }
    }
}