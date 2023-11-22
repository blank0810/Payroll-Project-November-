using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal.User_Controls_For_Modal
{
    public partial class slipDataUC : UserControl
    {
        private static int _userId;
        private static listUC _parent;
        private static formClass formClass;

        public int ControlNumber { get; set; }
        public string Status { get; set; }
        public string DateApproved { get; set; }

        public slipDataUC(int userId, listUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetSlipDetailedView(int controlNumber)
        {
            try
            {
                formClass = new formClass();
                DataTable details = await formClass.GetSlipDetailedView(controlNumber);
                return details;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void SlipDetails(int controlNumber)
        {
            try
            {
                slipDetailedView slipView = new slipDetailedView(_userId);
                DataTable details = await GetSlipDetailedView(controlNumber);

                if (details != null && details.Rows.Count == 1)
                {
                    foreach(DataRow row in details.Rows)
                    {
                        slipView.ControlNumber = (int)row["slipControlNumber"];

                        DateTime slipNotedDate = Convert.ToDateTime(row["slipNotedDate"]);
                        slipView.NotedBy = row["slipNotedBy"].ToString() + " / " + slipNotedDate.ToString("MMMM dd, yyyy");

                        DateTime dateCreated = Convert.ToDateTime(row["dateFile"]);
                        slipView.DateCreated = dateCreated.ToString("MMMM dd, yyyy");

                        DateTime slipDate = Convert.ToDateTime(row["slipDate"]);
                        slipView.SlipDate = slipDate.ToString("MMMM dd, yyyy");

                        DateTime approvedDate = Convert.ToDateTime(row["approvedDate"]);
                        slipView.ApprovedBy = row["approvedBy"].ToString() + " / " + approvedDate.ToString("MMMM dd, yyyy");

                        slipView.Status = row["status"].ToString();
                        slipView.FirstName = row["employeeFname"].ToString();
                        slipView.LastName = row["employeeLname"].ToString();
                        slipView.MiddleName = row["employeeMname"].ToString();
                        
                        if (string.IsNullOrEmpty(row["employeeExtension"].ToString()))
                        {
                            slipView.Extension = "N/A";
                        }
                        else
                        {
                            slipView.Extension = row["employeeExtension"].ToString();
                        }

                        DateTime slipTime = Convert.ToDateTime(row["slipTime"]);
                        slipView.SlipTime = slipTime.ToString("hh:mm tt");

                        slipView.Destination = row["slipDestination"].ToString();
                        
                        if (string.IsNullOrEmpty(row["deniedReason"].ToString()))
                        {
                            slipView.Reason = "N/A";
                        }
                        else
                        {
                            slipView.Reason = row["deniedReason"].ToString();
                        }

                        slipView.ShowDialog();
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

        private void slipDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            SlipDetails(ControlNumber);
        }
    }
}
