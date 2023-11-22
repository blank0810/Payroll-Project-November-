using Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_Modal;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Employee_Management.Employee_Management_User_Controls
{
    public partial class employeeDetailsUserControl : UserControl
    {
        public employeeDetailsUserControl()
        {
            InitializeComponent();
        }

        // Custom Function responsbile for displaying the Leave List
        public async Task DisplayLeaveList()
        {
            try
            {
                formContent.Controls.Clear();
                leaveBtn.TextColor = Color.Gray;
                travelBtn.TextColor = Color.DarkGray;
                passBtn.TextColor = Color.DarkGray;
                indicatorPanel.Location = new Point(leaveBtn.Location.X, indicatorPanel.Location.Y);

                leavePanel.Visible = true;
                slipPanel.Visible = false;
                travelPanel.Visible = false;

                formContent.Controls.Add(leavePanel);

                leaveContent.Controls.Clear();
                leaveUC leaveUC = new leaveUC();
                leaveContent.Controls.Add(leaveUC);
            }
            catch (SqlException sql)
            {
                ErrorMessage(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Error");
            }
        }

        // Custom function responsible for displaying the Travel Order list
        public async Task DisplayTravelList()
        {
            try
            {
                formContent.Controls.Clear();
                leaveBtn.TextColor = Color.DarkGray;
                travelBtn.TextColor = Color.Gray;
                passBtn.TextColor = Color.DarkGray;
                indicatorPanel.Location = new Point(travelBtn.Location.X, indicatorPanel.Location.Y);

                leavePanel.Visible = false;
                slipPanel.Visible = false;
                travelPanel.Visible = true;

                formContent.Controls.Add(travelPanel);

                travelContent.Controls.Clear();
                travelOrderUC travelOrderUC = new travelOrderUC();
                travelContent.Controls.Add(travelOrderUC);
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

        // Custom function responsible for displaying the Pass Slip list
        public async Task DisplaySlipList()
        {
            try
            {
                formContent.Controls.Clear();
                leaveBtn.TextColor = Color.DarkGray;
                travelBtn.TextColor = Color.DarkGray;
                passBtn.TextColor = Color.Gray;
                indicatorPanel.Location = new Point(passBtn.Location.X, indicatorPanel.Location.Y);

                leavePanel.Visible = false;
                slipPanel.Visible = true;
                travelPanel.Visible = false;

                formContent.Controls.Add(slipPanel);
                slipContent.Controls.Clear();
                passSlipUC passSlipUC = new passSlipUC();
                slipContent.Controls.Add(passSlipUC);
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

        // Custom function responsible for displaying the General Information
        private void DisplayGeneralInformation()
        {
            content.Controls.Clear();
            generalBtn.BackColor = Color.DodgerBlue;
            generalBtn.TextColor = Color.White;
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            formsBtn.BackColor = Color.White;
            formsBtn.TextColor = Color.DodgerBlue;

            generalPanel.Visible = true;
            employmentPanel.Visible = false;
            formPanel.Visible = false;

            content.Controls.Add(generalPanel);
        }

        // Custom function responsible for displaying the Employment Information
        private void DisplayEmploymentInformation()
        {
            content.Controls.Clear();

            generalBtn.BackColor = Color.White;
            generalBtn.TextColor = Color.DodgerBlue;
            employmentBtn.BackColor = Color.DodgerBlue;
            employmentBtn.TextColor = Color.White;
            formsBtn.BackColor = Color.White;
            formsBtn.TextColor = Color.DodgerBlue;

            generalPanel.Visible = false;
            employmentPanel.Visible = true;
            formPanel.Visible = false;

            content.Controls.Add(employmentPanel);
        }

        // Custom function responsible for displaying the Form Logs
        private void DisplayFormLogs()
        {
            content.Controls.Clear();

            generalBtn.BackColor = Color.White;
            generalBtn.TextColor = Color.DodgerBlue;
            employmentBtn.BackColor = Color.White;
            employmentBtn.TextColor = Color.DodgerBlue;
            formsBtn.BackColor = Color.DodgerBlue;
            formsBtn.TextColor = Color.White;

            generalPanel.Visible = false;
            employmentPanel.Visible = false;
            formPanel.Visible = true;

            content.Controls.Add(formPanel);
            DisplayLeaveList();
        }

        // Custom function responsible for displaying the Employee Benefits
        public async Task DisplayBenefit()
        {
            try
            {
                benefitsContent.Controls.Clear();
                benefitsDetailsUC benefits = new benefitsDetailsUC();
                benefitsContent.Controls.Add(benefits);
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

        // Custom function responsible for showing employee signature
        public void DisplaySignature()
        {
            try
            {
                employeeSignatureModal signatureModal = new employeeSignatureModal();
                signatureModal.ShowDialog();
            }
            catch (SqlException sql) { ErrorMessage(sql.Message, "Sql Error"); }
            catch (Exception ex) { ErrorMessage(ex.Message, "Error"); }
        }

        // Custom function responsible for displaying an errorr messages when an exception/error is encountered
        private void ErrorMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Custom function responsible for displaying a success message after every sucessfull transaction
        private void SuccessMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void employeeDetailsUserControl_Load(object sender, EventArgs e)
        {
            DisplayGeneralInformation();
        }

        private void generalBtn_Click(object sender, EventArgs e)
        {
            DisplayGeneralInformation();
        }

        private void employmentBtn_Click(object sender, EventArgs e)
        {
            DisplayEmploymentInformation();
            DisplayBenefit();
        }

        private void formsBtn_Click(object sender, EventArgs e)
        {
            DisplayFormLogs();
        }

        private async void leaveBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeaveList();
        }

        private async void travelBtn_Click(object sender, EventArgs e)
        {
            await DisplayTravelList();
        }

        private async void passBtn_Click(object sender, EventArgs e)
        {
            await DisplaySlipList();
        }

        private void employeeSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplaySignature();
        }
    }
}
