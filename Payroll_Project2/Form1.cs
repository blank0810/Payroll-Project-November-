using Payroll_Project2.Classes_and_SQL_Connection.Class;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Employee.Dashboard;
using Payroll_Project2.Forms.Mayor.Dashboard;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.System_Administrator.Dashboard;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2
{
    public partial class loginForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80; // WS_EX_TOOLWINDOW
                return cp;
            }
        }

        public static int userId;
        public static string password;
        private static LogInConnection logInClass = new LogInConnection();

        
        public loginForm()
        {
            InitializeComponent();
        }

        private async Task<bool> GetAuthenticate(int userId, string password)
        {
            try
            {
                bool isAuthenticate = await logInClass.GetAuthenticate(userId, password);

                return isAuthenticate;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> GetStatus(int userId)
        {
            try
            {
                bool getStatus = await logInClass.GetAccountStatus(userId);
                return getStatus;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetUserRole(int userId)
        {
            try
            {
                string role = await logInClass.GetUserRole(userId);

                if (string.IsNullOrEmpty(role))
                {
                    return null;
                }
                else
                {
                    return role;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private bool IsValidate()
        {
            try
            {
                if (idBox.Texts == string.Empty || passBox.Texts == string.Empty)
                {
                    MessageBox.Show("Enter the employee id number and password");
                    return false;
                }
                else
                {
                    return true; 
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> IsAuthenticate(int userId, string password)
        {
            try
            {
                bool isAuthenticate = await GetAuthenticate(userId, password);

                if (isAuthenticate)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The account does not exist in the database", "Account does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<bool> CheckStatus(int employeeId)
        {
            try
            {
                bool status = await GetStatus(employeeId);

                if (status)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The employee's account is not active. Please contact the IT Administrators for this error if you think there " +
                        "is a mistake", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> UserRole(int userId)
        {
            try
            {
                string role = await GetUserRole(userId);
                
                if (role == null)
                {
                    MessageBox.Show("There is no designated user role for this account. This required immediated resolution please contact " +
                        "system administrators for resolution", "No User Role Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    return role;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void RedirectAccount(string role, int userId)
        {
            try
            {
                ShowInTaskbar = false;

                switch (role)
                {
                    case "Mayor":
                    case "mayor":
                        MayorDashboard mayorDashboard = new MayorDashboard(userId);
                        mayorDashboard.ShowDialog();
                        this.Hide();
                        break;

                    case "Personnel":
                    case "personnel":
                        newDashboard newDashboard = new newDashboard(userId);
                        newDashboard.ShowDialog();
                        this.Hide();
                        break;

                    case "Employee":
                    case "employee":
                        employeeDashboard employeeDashboard = new employeeDashboard();
                        employeeDashboard.ShowDialog();
                        this.Hide();
                        break;

                    case "Department Head":
                    case "department head":
                        departmentHeadDashboard departmentHeadDashboard = new departmentHeadDashboard(userId);
                        departmentHeadDashboard.ShowDialog();
                        this.Hide();
                        break;
                    case "System Administrator":
                    case "system administrator":
                        systemAdminDashboard systemAdminDashboard = new systemAdminDashboard(userId);
                        systemAdminDashboard.ShowDialog();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show($"The platform for {role} is still on development. Please contact the system administrators for " +
                            $"resolution", "User Role Platform Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private async void buttonDesign1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidate())
                    return;

                if (int.TryParse(idBox.Texts, out int userId))
                {
                    bool isAuthenticate = await IsAuthenticate(userId, passBox.Texts);
                    if (!isAuthenticate)
                        return;

                    bool checkStatus = await CheckStatus(userId);
                    if (!checkStatus)
                        return;

                    string role = await UserRole(userId);
                    if (string.IsNullOrEmpty(role))
                        return;

                    RedirectAccount(role, userId);
                }
                else
                {
                    MessageBox.Show("Please input a proper user Id number");
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

        private void idBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void passBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    errorProvider.SetError(passBox, "Space characters are not allowed in the password.");
                }
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    errorProvider.SetError(passBox, "");

                    if (!IsValidate())
                        return;

                    if (int.TryParse(idBox.Texts, out int userId))
                    {
                        bool isAuthenticate = await IsAuthenticate(userId, passBox.Texts);
                        if (!isAuthenticate)
                            return;

                        bool checkStatus = await CheckStatus(userId);
                        if (!checkStatus)
                            return;

                        string role = await UserRole(userId);
                        if (string.IsNullOrEmpty(role))
                            return;

                        RedirectAccount(role, userId);
                    }
                    else
                    {
                        MessageBox.Show("Please input a proper user Id number");
                    }
                }
                else
                {
                    errorProvider.SetError(passBox, "");
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

        private void idBox__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
