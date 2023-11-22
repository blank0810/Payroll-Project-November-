using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control;
using Payroll_Project2.Forms.Employee.Dashboard.Modals;
using Payroll_Project2.Forms.Employee.File_leave;
using Payroll_Project2.Forms.Employee.File_Pass_Slip;
using Payroll_Project2.Forms.Employee.File_Travel_Order;
using Payroll_Project2.Forms.Employee.Leave_Logs;
using Payroll_Project2.Forms.Employee.Pass_Slip_Logs;
using Payroll_Project2.Forms.Employee.Personal_DTR;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Dashboard
{
    public partial class employeeDashboard : Form
    {
        private static int _userId;
        private static generalFunctions generalFunctions = new generalFunctions();  

        public employeeDashboard()
        {
            InitializeComponent();
        }

        private void employeeDashboard_Load(object sender, EventArgs e)
        {
            DataBinding();
            personalLeaveSubPanel.Visible = false;
            personalTravelSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;
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
                int applicationNumber = await generalFunctions.GetSlipControlNumber();

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
                int applicationNumber = await generalFunctions.GetTravelControlNumber();

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

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccesMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataBinding()
        {
            DisplayGeneral();
        }

        public async Task DisplayFileLeave()
        {
            try
            {
                int applicationNumber = await GetApplicationNumber();
                content.Controls.Clear();
                fileLeaveUC fileLeave = new fileLeaveUC();
                fileLeave.ApplicationNumber = applicationNumber;

                if (!content.Controls.Contains(fileLeave))
                {
                    content.Controls.Add(fileLeave);
                    fileLeave.Dock = DockStyle.Fill;
                    fileLeave.BringToFront();
                }
                else
                {
                    fileLeave.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        public async Task DisplayFilePassSlip()
        {
            try
            {
                int controlNumber = await GetSlipControlNumber();
                content.Controls.Clear();
                filePassSlipUC passSlip = new filePassSlipUC();
                passSlip.ControlNumber = controlNumber;

                if (!content.Controls.Contains(passSlip))
                {
                    content.Controls.Add(passSlip);
                    passSlip.Dock = DockStyle.Fill;
                    passSlip.BringToFront();
                }
                else
                {
                    passSlip.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        public async Task DisplayFileTravelOrder()
        {
            try
            {
                int controlNumber = await GetTravelControlNumber();
                content.Controls.Clear();
                fileTravelOrderUC fileTravel = new fileTravelOrderUC();
                fileTravel.ControlNumber = controlNumber;

                if (!content.Controls.Contains(fileTravel))
                {
                    content.Controls.Add(fileTravel);
                    fileTravel.Dock = DockStyle.Fill;
                    fileTravel.BringToFront();
                }
                else
                {
                    fileTravel.BringToFront();
                }
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }

        private void DisplayGeneral()
        {
            generalPanel.Visible = true;
            educationPanel.Visible = false;
            employmentPanel.Visible = false;

            generalBtn.BorderColor = Color.DodgerBlue;
            generalBtn.ForeColor = Color.DodgerBlue;
            educationBtn.BorderColor = Color.Transparent;
            educationBtn.ForeColor = Color.DimGray;
            employmentBtn.BorderColor = Color.Transparent;
            employmentBtn.ForeColor = Color.DimGray;
        }

        private void DisplayEducation()
        {
            generalPanel.Visible = false;
            educationPanel.Visible = true;
            employmentPanel.Visible = false;

            generalBtn.BorderColor = Color.Transparent;
            generalBtn.ForeColor = Color.DimGray;
            educationBtn.BorderColor = Color.DodgerBlue;
            educationBtn.ForeColor = Color.DodgerBlue;
            employmentBtn.BorderColor = Color.Transparent;
            employmentBtn.ForeColor = Color.DimGray;
        }

        private void DisplayEmployment()
        {
            generalPanel.Visible = false;
            educationPanel.Visible = false;
            employmentPanel.Visible = true;

            generalBtn.BorderColor = Color.Transparent;
            generalBtn.ForeColor = Color.DimGray;
            educationBtn.BorderColor = Color.Transparent;
            educationBtn.ForeColor = Color.DimGray;
            employmentBtn.BorderColor = Color.DodgerBlue;
            employmentBtn.ForeColor = Color.DodgerBlue;

            DisplayBenefits();
        }

        private void DisplayBenefits()
        {
            benefitListPanel.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                benefitDataUC benefits = new benefitDataUC(_userId, this);
                benefitListPanel.Controls.Add(benefits);
            }
        }

        private void DisplayContributions()
        {
            benefitListPanel.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                benefitInformationUC benefitInformation = new benefitInformationUC();
                benefitListPanel.Controls.Add(benefitInformation);
            }
        }

        private void ReturnBehaviour()
        {
            label22.Visible = false;
            label24.Visible = false;
            label26.Visible = false;
            returnBtn.Visible = false;

            label48.Visible = true;
            label47.Visible = true;
            label46.Visible = true;

            DisplayBenefits();
        }

        public void ContributionsBehaviour(int benefitId)
        {
            label22.Visible = true;
            label24.Visible = true;
            label26.Visible = true;
            returnBtn.Visible = true;

            label48.Visible = false;
            label47.Visible = false;
            label46.Visible = false;

            DisplayContributions();
        }

        private void personalProfileUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void generalBtn_Click(object sender, EventArgs e)
        {
            DisplayGeneral();
        }

        private void educationBtn_Click(object sender, EventArgs e)
        {
            DisplayEducation();
        }

        private void employmentBtn_Click(object sender, EventArgs e)
        {
            DisplayEmployment();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            updateModal update = new updateModal(_userId, this);
            update.ShowDialog();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            ReturnBehaviour();
        }

        private void profileBtn_Click_1(object sender, EventArgs e)
        {
            content.Controls.Clear();

            if(!content.Controls.Contains(dashboardPanel))
            {
                content.Controls.Add(dashboardPanel);
                dashboardPanel.Dock = DockStyle.Fill;
                dashboardPanel.BringToFront();
            }
            else
            {
                dashboardPanel.BringToFront();
            }
        }

        private void personalDTRBtn_Click(object sender, EventArgs e)
        {
            personalDTR dtr = new personalDTR();
            content.Controls.Clear();

            if (!content.Controls.Contains(dtr))
            {
                content.Controls.Add(dtr);
                dtr.Dock = DockStyle.Fill;
                dtr.BringToFront();
            }
            else
            {
                dtr.BringToFront();
            }
        }

        private void personalLeaveBtn_Click(object sender, EventArgs e)
        {
            personalTravelSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;

            if (personalLeaveSubPanel.Visible)
            {
                personalLeaveSubPanel.Visible = false;
            }
            else
            {
                personalLeaveSubPanel.Visible = true;
            }
        }

        private async void personalFileLeaveBtn_Click(object sender, EventArgs e)
        {
            await DisplayFileLeave();
            //fileLeaveModal fileLeave = new fileLeaveModal(_userId, this);
            //fileLeave.ShowDialog();
        }

        private void leaveLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = leaveLogsBtn.Text;
            leaveLogsUC leaveLogs = new leaveLogsUC();
            content.Controls.Clear();

            if (!content.Controls.Contains(leaveLogs))
            {
                content.Controls.Add(leaveLogs);
                leaveLogs.Dock = DockStyle.Fill;
                leaveLogs.BringToFront();
            }
            else
            {
                leaveLogs.BringToFront();
            }
        }

        private void personalTravelBtn_Click(object sender, EventArgs e)
        {
            personalLeaveSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;

            if (personalTravelSubPanel.Visible)
            {
                personalTravelSubPanel.Visible = false;
            }
            else
            {
                personalTravelSubPanel.Visible = true;
            }
        }

        private async void fileTravelBtn_Click(object sender, EventArgs e)
        {
            await DisplayFileTravelOrder();
            //fileTravelOrderModal travelOrder = new fileTravelOrderModal(_userId, this);
            //travelOrder.ShowDialog();
        }

        private void travelLogsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be soon release", "Unavailable Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*titleLabel.Text = travelLogsBtn.Text;
            travelOrderLogUC travelOrderLog = new travelOrderLogUC(_userId, this);
            content.Controls.Clear();

            if (!content.Controls.Contains(travelOrderLog))
            {
                content.Controls.Add(travelOrderLog);
                travelOrderLog.Dock = DockStyle.Fill;
                travelOrderLog.BringToFront();
            }
            else
            {
                travelOrderLog.BringToFront();
            }*/
        }

        private void personalSlipBtn_Click(object sender, EventArgs e)
        {
            personalLeaveSubPanel.Visible = false;
            personalLeaveSubPanel.Visible = false;

            if (personalSlipSubPanel.Visible)
            {
                personalSlipSubPanel.Visible = false;
            }
            else
            {
                personalSlipSubPanel.Visible = true;
            }
        }

        private async void fileSlipBtn_Click(object sender, EventArgs e)
        {
            await DisplayFilePassSlip();

            //filePassSlipModal fileSlip = new filePassSlipModal(_userId, this);
            //Slip.ShowDialog();
        }

        private void slipLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = slipLogsBtn.Text;
            slipLogsUC slipLogs = new slipLogsUC();
            content.Controls.Clear();

            if (!content.Controls.Contains(slipLogs))
            {
                content.Controls.Add(slipLogs);
                slipLogs.Dock = DockStyle.Fill;
                slipLogs.BringToFront();
            }
            else
            {
                slipLogs.BringToFront();
            }
        }

        private void personalPayslipBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be soon release", "Unavailable Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*titleLabel.Text = personalPayslipBtn.Text;
            HideDepartmentPortal();
            payslipLogsUC payslip = new payslipLogsUC(_userId, this);
            content.Controls.Clear();

            if (!content.Controls.Contains(payslip))
            {
                content.Controls.Add(payslip);
                payslip.Dock = DockStyle.Fill;
                payslip.BringToFront();
            }
            else
            {
                payslip.BringToFront();
            }*/
        }
    }
}
