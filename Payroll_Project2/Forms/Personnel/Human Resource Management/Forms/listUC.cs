using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Forms.List_Contents;
using Payroll_Project2.Forms.Personnel.Forms.List_Contents.Modal.User_Controls_For_Modal;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms
{
    public partial class listUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static formClass formClass;

        public listUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for retrieving the employee list who have submitted complete application for leave
        private async Task<DataTable> GetCompleteLeaveList()
        {
            try
            {
                formClass = new formClass();
                DataTable employeeList = await formClass.GetCompleteLeaveList();

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the employee list who have submitted complete travel order
        private async Task<DataTable> GetCompleteTravelList()
        {
            try
            {
                formClass = new formClass();
                DataTable employeeList = await formClass.GetCompleteTravelList();

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the employee list who have submitted complete pass slip
        private async Task<DataTable> GetCompleteSlipList()
        {
            try
            {
                formClass = new formClass();
                DataTable employeeList = await formClass.GetCompleteSlipList();

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the employee list who have submitted complete application for leave but searched
        private async Task<DataTable> GetSearchCompleteLeaveList(string search)
        {
            try
            {
                formClass = new formClass();
                DataTable employeeList = await formClass.GetSearchCompleteLeaveList(search);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the employee list who have submitted complete travel order but searched
        private async Task<DataTable> GetSearchCompleteTravelList(string search)
        {
            try
            {
                formClass = new formClass();
                DataTable employeeList = await formClass.GetSearchCompleteTravelList(search);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the employee list who have submitted complete pass slip but searched
        private async Task<DataTable> GetSearchCompleteSlipList(string search)
        {
            try
            {
                formClass = new formClass();
                DataTable employeeList = await formClass.GetSearchCompleteSlipList(search);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    return employeeList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql)
            {
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Function responsible for retrieving the complete list of all application for leave
        private async Task<DataTable> GetEmployeeLeaveList(int employeeId)
        {
            try
            {
                formClass = new formClass();
                DataTable employeeLeave = await formClass.GetEmployeeLeaveList(employeeId);
                return employeeLeave;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the complete list of all pass slip
        private async Task<DataTable> GetEmployeeSlipList(int employeeId)
        {
            try
            {
                formClass = new formClass();
                DataTable list = await formClass.GetEmployeeSlipList(employeeId);

                return list;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the complete list of all travel order
        private async Task<DataTable> GetEmployeeTravelList(int employeeId)
        {
            try
            {
                formClass = new formClass();
                DataTable list = await formClass.GetEmployeeTravelList(employeeId);

                return list;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for displaying the employee's who have complete list of application for leave
        private async Task EmployeeList()
        {
            listContent.Controls.Clear();
            try
            {
                DataTable employeeList = await GetCompleteLeaveList();

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    leaveListUC[] leaveList = new leaveListUC[employeeList.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach(DataRow row in employeeList.Rows)
                        {
                            leaveList[i] = new leaveListUC(_userId, this);

                            leaveList[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            leaveList[i].EmployeeImage = row["employeePicture"].ToString();
                            leaveList[i].EmployeeID = (int)row["employeeId"];
                            leaveList[i].DepartmentName = row["departmentName"].ToString();

                            listContent.Controls.Add(leaveList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that no data is available for display at this time. " +
                        "The database does not contain any records matching your query. Thank you for your understanding.",
                        "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Function responsible for displaying the employee's who have complete list of travel order
        private async Task EmployeeTravelList()
        {
            listContent.Controls.Clear();
            try
            {
                DataTable list = await GetCompleteTravelList();

                if (list != null && list.Rows.Count > 0)
                {
                    orderList[] orderList = new orderList[list.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in list.Rows)
                        {
                            orderList[i] = new orderList(_userId, this);

                            orderList[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            orderList[i].EmployeeID = (int)row["employeeId"];
                            orderList[i].EmployeeImage = row["employeePicture"].ToString();
                            orderList[i].DepartmentName = row["departmentName"].ToString();

                            listContent.Controls.Add(orderList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that no data is available for display at this time. " +
                        "The database does not contain any records matching your query. Thank you for your understanding.",
                        "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Function responsible for displaying the employee's who have complete list of pass slip
        private async Task EmployeeSlipList()
        {
            listContent.Controls.Clear();

            try
            {
                DataTable list = await GetCompleteSlipList();

                if (list != null && list.Rows.Count > 0)
                {
                    slipList[] slipList = new slipList[list.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in list.Rows)
                        {
                            slipList[i] = new slipList(_userId, this);

                            slipList[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            slipList[i].EmployeeID = (int)row["employeeId"];
                            slipList[i].EmployeeImage = row["employeePicture"].ToString();
                            slipList[i].DepartmentName = row["departmentName"].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that no data is available for display at this time. " +
                        "The database does not contain any records matching your query. Thank you for your understanding.",
                        "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Function responsible for displaying the employee's who have complete list of application for leave but searched
        private async Task SearchEmployeeList(string search)
        {
            listContent.Controls.Clear();
            try
            {
                DataTable employeeList = await GetSearchCompleteLeaveList(search);

                if (employeeList != null && employeeList.Rows.Count > 0)
                {
                    leaveListUC[] leaveList = new leaveListUC[employeeList.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in employeeList.Rows)
                        {
                            leaveList[i] = new leaveListUC(_userId, this);

                            leaveList[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            leaveList[i].EmployeeImage = row["employeePicture"].ToString();
                            leaveList[i].EmployeeID = (int)row["employeeId"];
                            leaveList[i].DepartmentName = row["departmentName"].ToString();

                            listContent.Controls.Add(leaveList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that no data is available for display at this time. " +
                        "The database does not contain any records matching your query. Thank you for your understanding.",
                        "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Function responsible for displaying the employee's who have complete list of travel order but searched
        private async Task SearchEmployeeTravelList(string search)
        {
            listContent.Controls.Clear();
            try
            {
                DataTable list = await GetSearchCompleteTravelList(search);

                if (list != null && list.Rows.Count > 0)
                {
                    orderList[] orderList = new orderList[list.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in list.Rows)
                        {
                            orderList[i] = new orderList(_userId, this);

                            orderList[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            orderList[i].EmployeeID = (int)row["employeeId"];
                            orderList[i].EmployeeImage = row["employeePicture"].ToString();
                            orderList[i].DepartmentName = row["departmentName"].ToString();

                            listContent.Controls.Add(orderList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that no data is available for display at this time. " +
                        "The database does not contain any records matching your query. Thank you for your understanding.",
                        "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Function responsible for displaying the employee's who have complete list of pass slip but searched
        private async Task SearchEmployeeSlipList(string search)
        {
            listContent.Controls.Clear();

            try
            {
                DataTable list = await GetSearchCompleteSlipList(search);

                if (list != null && list.Rows.Count > 0)
                {
                    slipList[] slipList = new slipList[list.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in list.Rows)
                        {
                            slipList[i] = new slipList(_userId, this);

                            slipList[i].EmployeeName = row["employeeFname"].ToString() + " " + row["employeeLname"].ToString();
                            slipList[i].EmployeeID = (int)row["employeeId"];
                            slipList[i].EmployeeImage = row["employeePicture"].ToString();
                            slipList[i].DepartmentName = row["departmentName"].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that no data is available for display at this time. " +
                        "The database does not contain any records matching your query. Thank you for your understanding.",
                        "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Function responsible for displaying the list of all application for leave
        private async Task LeaveList(int employeeID)
        {
            listContent.Controls.Clear();
            try
            {
                DataTable leaveListTable = await GetEmployeeLeaveList(employeeID);

                if (leaveListTable != null && leaveListTable.Rows.Count > 0)
                {
                    leaveListDataUC[] leaveList = new leaveListDataUC[leaveListTable.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in leaveListTable.Rows)
                        {
                            leaveList[i] = new leaveListDataUC(_userId, this);

                            leaveList[i].ApplicationNumber = (int)row["applicationNumber"];

                            DateTime approvedDate = Convert.ToDateTime(row["approvedDate"]);
                            leaveList[i].DateApproved = approvedDate.ToString("MMMM d, yyyy");

                            leaveList[i].Status = row["statusDescription"].ToString();

                            listContent.Controls.Add(leaveList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that there is an issue preventing the display of the list of employee's " +
                        "Leave Requests at the moment. Our team is already working to resolve this matter. Please try again later or " +
                        "contact the IT department for further assistance.",
                        "Error: Displaying Employee's Leave Requests",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        // Function responsible for displaying the list of all pass slip
        private async Task SlipList(int employeeID)
        {
            try
            {
                DataTable slipTable = await GetEmployeeSlipList(employeeID);

                if (slipTable != null && slipTable.Rows.Count > 0)
                {
                    slipDataUC[] slipList = new slipDataUC[slipTable.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in slipTable.Rows)
                        {
                            slipList[i] = new slipDataUC(_userId, this);

                            slipList[i].ControlNumber = (int)row["applicationNumber"];

                            DateTime approvedDate = Convert.ToDateTime(row["approvedDate"]);
                            slipList[i].DateApproved = approvedDate.ToString("MMMM d, yyyy");

                            slipList[i].Status = row["statusDescription"].ToString();

                            listContent.Controls.Add(slipList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that there is an issue preventing the display of the list of employee's " +
                        "Leave Requests at the moment. Our team is already working to resolve this matter. Please try again later or " +
                        "contact the IT department for further assistance.",
                        "Error: Displaying Employee's Leave Requests", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Function responsible for displaying the list of all travel order
        private async Task TravelList(int employeeID)
        {
            try
            {
                DataTable travelTable = await GetEmployeeTravelList(employeeID);

                if (travelTable != null && travelTable.Rows.Count > 0)
                {
                    travelDataUC[] travelList = new travelDataUC[travelTable.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in travelTable.Rows)
                        {
                            travelList[i] = new travelDataUC(_userId, this);

                            travelList[i].ControlNumber = (int)row["applicationNumber"];

                            DateTime approvedDate = Convert.ToDateTime(row["approvedDate"]);
                            travelList[i].DateApproved = approvedDate.ToString("MMMM d, yyyy");

                            travelList[i].Status = row["statusDescription"].ToString();

                            listContent.Controls.Add(travelList[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We regret to inform you that there is an issue preventing the display of the list of employee's " +
                        "Leave Requests at the moment. Our team is already working to resolve this matter. Please try again later or " +
                        "contact the IT department for further assistance.",
                        "Error: Displaying Employee's Leave Requests", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Custom function it dictates the UI behaviour if the list button is clicked
        public async Task ListButtonBehaviour(int employeeId)
        {
            label6.Visible = true;
            label7.Visible = true;
            label13.Visible = true;
            label8.Location = new Point(676, 8);
            returnBtn.Visible = true;

            label11.Visible = false;
            label9.Visible = false;

            if (listContent.Controls.Count > 0)
            {
                if (listContent.Controls[0] is leaveListUC)
                {
                    await LeaveList(employeeId);
                }
                else if (listContent.Controls[0] is slipList)
                {
                    await SlipList(employeeId);
                }
                else if (listContent.Controls[0] is orderList)
                {
                    await TravelList(employeeId);
                }
                else
                {
                    MessageBox.Show("An error occurred while identifying the User Control added in the List Content Panel. " +
                    "Kindly contact the IT department for an immediate resolution.",
                    "User Control Identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred while identifying the User Control added in the List Content Panel. " +
                    "Kindly contact the IT department for an immediate resolution.",
                    "User Control Identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler that handles if this user control is loaded into the system
        private async void listUC_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label13.Visible = false;
            label8.Location = new Point(673, 8);
            returnBtn.Visible = false;

            await EmployeeList();
        }

        // Event handler that handles if the application for leave button is clicked
        private async void leaveBtn_Click(object sender, EventArgs e)
        {
            typeLabel.Text = leaveBtn.Text;
            await EmployeeList();
        }

        // Event handler that handles if the application for pass slip button is clicked
        private async void slipBtn_Click(object sender, EventArgs e)
        {
            typeLabel.Text = slipBtn.Text;
            await EmployeeSlipList();
        }

        // Event handler that handles if the application for travel order button is clicked
        private async void travelBtn_Click(object sender, EventArgs e)
        {
            typeLabel.Text = travelBtn.Text;
            await EmployeeTravelList();
        }

        // Event handler that handles if the application for return to list button is clicked
        private async void returnBtn_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label13.Visible = false;
            label8.Location = new Point(673, 8);
            returnBtn.Visible = false;

            label11.Visible = true;
            label9.Visible = true;

            if (listContent.Controls.Count > 0)
            {
                if (listContent.Controls[0] is leaveListDataUC)
                {
                    await EmployeeList();
                }
                else if (listContent.Controls[0] is slipDataUC)
                {
                    await EmployeeSlipList();
                }
                else if (listContent.Controls[0] is travelDataUC)
                {
                    await EmployeeTravelList();
                }
                else
                {
                    MessageBox.Show("An error occurred while identifying the User Control added in the List Content Panel. " +
                    "Kindly contact the IT department for an immediate resolution.",
                    "User Control Identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred while identifying the User Control added in the List Content Panel. " +
                    "Kindly contact the IT department for an immediate resolution.",
                    "User Control Identification Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // Event handler if the search button is clicked
        private async void searchBtn_Click(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(searchEmployee.Texts) && listContent.Controls.Count > 1)
            {
                if (listContent.Controls[0] is leaveListUC)
                {
                    await SearchEmployeeList(searchEmployee.Texts);
                }
                else if (listContent.Controls[0] is orderList)
                {
                    await SearchEmployeeTravelList(searchEmployee.Texts);
                }
                else if (listContent.Controls[0] is slipList)
                {
                    await SearchEmployeeSlipList(searchEmployee.Texts);
                }
                else
                {
                    MessageBox.Show("An error occurred while identifying the User Control added in the List Content Panel. " +
                    "Kindly contact the IT department for an immediate resolution.",
                    "User Control Identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred while identifying the User Control added in the List Content Panel or there is no records " +
                    "of form can be found in the database. " +
                "If you think there is an error kindly contact the IT department for an immediate resolution.",
                "User Control Identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
