using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Employee.Modal;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Employee.Employee_Sub_user_Control.Modal.Modal_Sub_User_Controls
{
    public partial class benefitsDetailsUC : UserControl
    {
        private static employeeDetailsUserControl _parent;
        private static int _userId;

        public int DetailsId { get; set; }
        public string BenefitName { get; set; }
        public string BenefitValue { get; set; }
        public string BenefitStatus { get; set; }


        public benefitsDetailsUC(employeeDetailsUserControl parent, int userId)
        {
            InitializeComponent();
            _parent = parent;
            _userId = userId;
        }

        // Function Responsible for updating the benefit Status
        private async Task<bool> UpdateBenefitStatus(int id, string status)
        {
            try
            {
                employeeClass employeeClass = new employeeClass();
                bool updateEmployeeBenefitStatus = await employeeClass.UpdateEmployeeBenefitStatus(id, status);

                if (updateEmployeeBenefitStatus)
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
                throw ex;
            }
        }

        // Custom function responsible for binding the values into the User Interface controls
        private void DataBinding()
        {
            benefitName.DataBindings.Add("Text", this, "BenefitName");
            benefitValue.DataBindings.Add("Text", this, "BenefitValue");

            Binding statusBinding = new Binding("Text", this, "BenefitStatus");
            statusBinding.Format += new ConvertEventHandler(StatusBinding_Format);
            benefitsStatus.DataBindings.Add(statusBinding);
        }

        // Custom Function responsible for displaying if there is an error encountered
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Custom function responsible for every sucessfull transaction
        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Custom function responsible for formatting the benefit status
        private void StatusBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value.ToString() == "Active")
            {
                benefitsStatus.ForeColor = Color.ForestGreen;
                activeBtn.Visible = false;
                inactiveBtn.Visible = true;
            }
            else if (e.Value.ToString() == "Inactive")
            {
                benefitsStatus.ForeColor = Color.Red;
                inactiveBtn.Visible = false;
                activeBtn.Visible = true;
            }
            else
            {
                benefitsStatus.ForeColor = Color.DimGray;
            }
        }

        // Event Handhler that handles if the benefits is loaded into the system
        private void benefitsDetailsUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event handler that handles if the modify button is being clicked
        private async void modifyBtn_Click(object sender, EventArgs e)
        {
            benefitsContribution benefits = new benefitsContribution(_userId, this);
            benefits.ShowDialog();
            await _parent.DisplayBenefit();
        }

        // Event handler that handles if the user will switch the benefits into an inactive status
        private async void inactiveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (inactiveBtn.Text != BenefitStatus)
                {
                    bool updateEmployeeBenefitStatus = await UpdateBenefitStatus(DetailsId, inactiveBtn.Text);

                    if (updateEmployeeBenefitStatus)
                    {
                        SuccessMessage("The benefit status has been successfully modified.", "Benefit Status Modification Successful");
                        _parent.DisplayBenefit();
                    }
                }
                else
                {
                    ErrorMessage("The selected benefit is already active. Please bring this issue to the attention of the system administrator for further assistance.",
                        "Duplicate Active Benefit");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption:@"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler that handles if the user will switch the benefits status into an active status
        private async void activeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeBtn.Text != BenefitStatus)
                {
                    bool updateEmployeeBenefitStatus = await UpdateBenefitStatus(DetailsId, activeBtn.Text);

                    if (updateEmployeeBenefitStatus)
                    {
                        SuccessMessage("The benefit status has been successfully modified.", "Benefit Status Modification Successful");
                        _parent.DisplayBenefit();
                    }
                }
                else
                {
                    ErrorMessage("The selected benefit is already active. Please bring this issue to the attention of the system administrator for further assistance.",
                        "Duplicate Active Benefit");
                }
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "Sql Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Exception Error");
            }
        }
    }
}
