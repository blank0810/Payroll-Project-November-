using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile.Modals
{
    public partial class employeeSignatureModal : Form
    {
        private static int _userId;
        private static personalProfileUC _parent;
        private static employeeClass employeeClass = new employeeClass();
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmployeeFullName { get; set; }
        public int EmployeeId { get; set; }
        public string DateCaptured { get; set; }
        public string ProcessName { get; set; }
        public string ResponseText { get; set; }
        public string EmployeeSignature { get; set; }

        public employeeSignatureModal(int userId, personalProfileUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for authorizing the user
        private async Task<bool> GetAuthorization(int userId)
        {
            try
            {
                bool authorization = await generalFunctions.GetValidation(userId);

                if (authorization)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function for binding values into the UI controls
        private void DataBinding()
        {
            employeeFullName.DataBindings.Add("Text", this, "EmployeeFullName");
            employeeId.DataBindings.Add("Text", this, "EmployeeId");
            dateCaptured.DataBindings.Add("Text", this, "DateCaptured");
            empSignature.DataBindings.Add("ImageLocation", this, "EmployeeSignature");
            responseText.DataBindings.Add("Text", this, "ResponseText");
        }

        // Custom function responsible to check if user authorized or not
        private async Task<bool> IsAuthorized(int userId)
        {
            try
            {
                bool isAuthorized = await GetAuthorization(userId);

                if (isAuthorized)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Event Handler if the modal is loaded into the system
        private void employeeSignatureModal_Load(object sender, EventArgs e)
        {
            responseText.Visible = false;
            DataBinding();
        }

        // Event handler handles if the view button is clicked
        private async void viewBtn_Click(object sender, EventArgs e)
        {
            bool isAuthorized = await IsAuthorized(_userId);

            if (isAuthorized)
            {
                responseText.Visible = true;
            }
            else
            {
                responseText.Visible = true;
                responseText.ForeColor = Color.Red;
                responseText.Text = "You are not authorized to do this action.";
            }
        }

        private void employeeSignatureModal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Escape key
            if (e.KeyChar == (char)27) // 27 is the ASCII code for the Escape key
            {
                // Close the form
                this.Close();
            }
        }
    }
}
