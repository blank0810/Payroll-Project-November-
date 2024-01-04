using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
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

namespace Payroll_Project2.Forms.Employee.Dashboard.Modals
{
    public partial class updateModal : Form
    {
        private static int _userId;
        private static employeeDashboard _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public string EmailAddress;
        public string MobileNumber;
        public string ZipCode;
        public string Province;
        public string Municipality;
        public string Barangay;
        public string Gender;
        public string Password;

        public updateModal(int userId, employeeDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<bool> UpdateBasicInformation(int employeeId, string password, string emailAddress, string mobileNumber, string zipCode, string province,
    string municipality, string barangay, string gender)
        {
            try
            {
                bool update = await generalFunctions.UpdateBasicInformation(employeeId, password, emailAddress, mobileNumber, zipCode, province, municipality,
                    barangay, gender);

                if (update)
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

        private void DataBinding()
        {
            emailAddress.Texts = EmailAddress;
            mobileNumber.Texts = MobileNumber;
            zipCode.Texts = ZipCode;
            province.Texts = Province;
            municipality.Texts = Municipality;
            barangay.Texts = Barangay;
            password.Texts = Password;
            gender.Texts = Gender;
        }

        private async Task<bool> IsUpdate(int employeeId)
        {
            try
            {
                bool update = await UpdateBasicInformation(employeeId, password.Texts, emailAddress.Texts, mobileNumber.Texts, zipCode.Texts, province.Texts,
                    municipality.Texts, barangay.Texts, gender.Texts);

                if (update)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("There is an error in updating the basic information of the employee. Please contact system administrators " +
                        "for resolution", "Update Basic Information Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void updateModal_Load(object sender, EventArgs e)
        {
            panel9.Focus();
            DataBinding();
        }

        private void passwordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheck.Checked)
            {
                password.PasswordChar = false;
            }
            else
            {
                password.PasswordChar = true;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool update = await IsUpdate(_userId);
                if (!update)
                    return;

                MessageBox.Show("You have successfully updated your basic information please review it in your personal information sections",
                    "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
    }
}
