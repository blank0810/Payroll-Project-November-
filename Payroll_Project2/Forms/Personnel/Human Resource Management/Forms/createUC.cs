using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms
{
    public partial class createUC : UserControl
    {
        private static int _userId;
        private static readonly string mayorRole = "Mayor";
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formClass formClass = new formClass();

        public createUC(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        // Function that responsible for retrieving automated application number for the application for leave creation
        private async Task<int> GetApplicationNumber()
        {
            try
            {
                int applicationNumber = await generalFunctions.GetApplicationNumber();

                if (applicationNumber >= 0)
                {
                    return applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function that responsible for retrieving the automated control number for the pass slip creation
        private async Task<int> GetSlipControlNumber()
        {
            try
            {
                int applicationNumber = await formClass.GetSlipControlNumber();

                if (applicationNumber >= 0)
                {
                    return applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }
        
        // Function that responsible for retrieving the automated control number of the travel order creation
        private async Task<int> GetTravelControlNumber()
        {
            try
            {
                int applicationNumber = await formClass.GetTravelControlNumber();

                if (applicationNumber >= 0)
                {
                    return applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the user role for authorization purposes
        private async Task<string> GetUserRole(int userId)
        {
            try
            {
                string roleName = await formClass.GetUserRole(userId);

                if (roleName != null)
                {
                    return roleName;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the Mayor Name from the Database
        private async Task<string> GetMayorName()
        {
            try
            {
                string mayor = await formClass.GetMayorName(mayorRole);

                if (mayor != null)
                {
                    return mayor;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the personnel name for the creation of Forms
        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetPersonnelName(userId);

                if (name != null)
                {
                    return name;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        
        
        // Function responsible for forwarding the leave details into the leave creation user control
        public async Task LeaveDetails()
        {
            createContent.Controls.Clear();
            try
            {
                // In final need to change this for a proper authorization
                string roleName = await GetUserRole(_userId);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        // Function responsible for forwarding the pass slip details into the pass slip creation user control
        public async Task SlipDetails()
        {
            createContent.Controls.Clear();
            try
            {
                string roleName = await GetUserRole(_userId);

                // Must be changed for a proper authorization
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        // Function responsible for forwarding the travel order details into the travel order creation user control
        public async Task TravelDetails()
        {
            try
            {
                createContent.Controls.Clear();

                string roleName = await GetUserRole(_userId);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        // Event handler that handles if this user control is loaded into the system
        private void createUC_Load(object sender, EventArgs e)
        {
            createContent.Controls.Clear();
        }

        
        
        // Event handler that handles if the Application for leave is clicked
        private async void leaveBtn_Click(object sender, EventArgs e)
        {
            await LeaveDetails();
        }

        
        
        // Event handler that handles if the Pass Slip button is clicked
        private async void passBtn_Click(object sender, EventArgs e)
        {
            await SlipDetails();
            
        }

        
        
        // Event handler that handles if the Travel order button is clicked
        private async void travelBtn_Click(object sender, EventArgs e)
        {
            await TravelDetails();
        }
    }
}
