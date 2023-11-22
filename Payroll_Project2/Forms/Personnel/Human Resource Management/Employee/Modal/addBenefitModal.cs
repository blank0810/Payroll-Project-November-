using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal
{
    public partial class addBenefitModal : Form
    {
        private static int _userId;
        private static employeeDetailsUserControl _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public int EmployeeID { get; set; }
        private readonly string Status = "Active";

        public addBenefitModal( int userID, employeeDetailsUserControl parent)
        {
            _userId = userID;
            _parent = parent;
            InitializeComponent();
        }
        #region This Functions Below is Used for the functionality of the modal

        private async Task<string> GetEmploymentStatus(int employeeId)
        {
            try
            {
                DataTable details = await generalFunctions.GetEmployeeDetails(employeeId);

                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        return row["employmentStatus"].ToString();
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<bool> AddBenefitToList(string benefitName)
        {
            #region This function is used so that if the user will input a new benefit into employee's appointment form it will first add into the database

            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addBenefit = await employeeClass.AddBenefit(benefitName);
                if (addBenefit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion 
        }

        private async Task<bool> CheckBenefit(string BenefitName)
        {
            #region This function will check if the benefit being added to the employee's appointment form does exist on the database or not

            try
            {
                employeeClass employeeClass = new employeeClass();
                string employmentStatus = await GetEmploymentStatus(EmployeeID);
                DataTable benefitTable = await employeeClass.GetBenefitList(employmentStatus);

                foreach (DataRow row in benefitTable.Rows)
                {
                    if (row["benefits"].ToString().ToUpper() == BenefitName)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

        private async Task<bool> CheckEmployeeBenefitExist(int id, string benefitName)
        {
            #region This function when called is use to check if the benefit that will be addded does exist on the employee appointment form or not
            // If the benefit exist then the function will notify the personnel that this benefit is already exist on employee appointment form

            try
            {
                employeeClass employeeClass = new employeeClass();
                DataTable employeeBenefitList = await generalFunctions.GetEmployeeBenefits(id);

                foreach (DataRow row in employeeBenefitList.Rows)
                {
                    if (row["benefits"].ToString().ToUpper() == benefitName)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            #endregion
        }

        private async Task<bool> AddExistingBenefit(int id, string benefitName, int benefitValue, string benefitStatus)
        {
            #region This function is used so that the benefit that is being added into the database will be added into the employee appointment form

            try
            {
                employeeClass employeeClass = new employeeClass();
                bool addValidation = await employeeClass.AddEmployeeBenefit(id, benefitName, benefitValue, benefitStatus);

                if (addValidation == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            #endregion
        }

        private async void DataBinding()
        {
            #region This function is used that the value of the labels is being databind to the variables so that it will be updated in the real time

            employeeClass employeeClass = new employeeClass();
            string employmentStatus = await GetEmploymentStatus(EmployeeID);
            DataTable benefitTable = await employeeClass.GetBenefitList(employmentStatus);

            try
            {
                benefitName.AutoCompleteMode = AutoCompleteMode.Suggest;
                benefitName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection autoCompleteValues = new AutoCompleteStringCollection();

                foreach (DataRow row in benefitTable.Rows)
                {
                    autoCompleteValues.Add(row["benefits"].ToString().ToUpper());
                }

                benefitName.DataSource = autoCompleteValues;
                benefitName.AutoCompleteCustomSource = autoCompleteValues;
                benefitName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption:@"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        #endregion

        #region The functions below is used for User Interfaces Behaviours

        private void customTextBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region This function is an event handler that restricts the text box of the benefit value that it only accepts number

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(benefitValue, "Only Numbers are allowed");
            }
            else
            {
                errorProvider1.SetError(benefitValue, "");
            }

            #endregion
        }

        private void addBenefitModal_Load(object sender, EventArgs e)
        {
            #region An event handler that when the modal will be run or called the values that is databind to the variables will be displayed

            DataBinding();

            #endregion
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            #region Event handler that will close the modal when clicked

            this.Close();

            #endregion
        }

        #region This is for submit button when adding the new benefit
        private async void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string formattedBenefitName = benefitName.Text.ToUpper();
                bool isBenefitValueValid = int.TryParse(benefitValue.Texts, out int benefitValueInt);

                bool benefitExists = await CheckBenefit(formattedBenefitName);

                if (benefitExists)
                {
                    if (isBenefitValueValid)
                    {
                        bool employeeBenefitExists = await CheckEmployeeBenefitExist(EmployeeID, formattedBenefitName);

                        if (employeeBenefitExists)
                        {
                            MessageBox.Show($"The benefit named '{benefitName.Text}' already exists on the employee's appointment form. " +
                                            "Please review the form and ensure that duplicate benefits are not added.",
                                            "Benefit Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            bool addExistingBenefit = await AddExistingBenefit(EmployeeID, formattedBenefitName, benefitValueInt, Status);

                            if (addExistingBenefit)
                            {
                                MessageBox.Show($"The benefit '{benefitName.Text}' has been successfully added to the Appointment form.",
                                                "Benefit Addition Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("An error occurred while adding the benefit. " +
                                                "Please review the provided details and try again.",
                                                "Benefit Addition Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please provide a valid benefit value.", "Invalid Benefit Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    bool addBenefitToList = await AddBenefitToList(formattedBenefitName);
                    if (addBenefitToList)
                    {
                        bool addExistingBenefit = await AddExistingBenefit(EmployeeID, formattedBenefitName, benefitValueInt, Status);

                        if (addExistingBenefit)
                        {
                            MessageBox.Show($"The benefit '{benefitName.Text}' has been successfully added to the Appointment form.",
                                            "Benefit Addition Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while adding the benefit. " +
                                            "Please review the provided details and try again.",
                                            "Benefit Addition Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while adding the benefit into the Database List. " +
                                    "Please contact System Administrator for Resolution.",
                                    "Benefit Addition Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, caption: "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption: "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

#endregion
    }
}
