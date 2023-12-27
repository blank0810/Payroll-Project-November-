using Payroll_Project2.Classes_and_SQL_Connection.Connections.Department_Head_Function;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard.User_Control;
using Payroll_Project2.Forms.Department_Head.Electronic_DTR;
using Payroll_Project2.Forms.Department_Head.Leave_Management;
using Payroll_Project2.Forms.Department_Head.Pass_Slip;
using Payroll_Project2.Forms.Department_Head.Payroll_Requests;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Department_Head_Profile;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.File_leave;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.File_Pass_Slip;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.File_Travel_Order;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Leave_Logs;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Pass_Slip_Logs;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Payslip_Logs;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Personal_DTR;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Travel_Order_Logs;
using Payroll_Project2.Forms.Department_Head.Subordinate_Management;
using Payroll_Project2.Forms.Department_Head.Travel_Order;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Dashboard
{
    public partial class departmentHeadDashboard : Form
    {
        private static int _userId;
        private static string _department;
        private static readonly string present = "On Time";
        private static readonly string late = "Late";
        private static readonly string defaultEmployeeImage = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string EmployeeSignaturePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeSignaturePath");
        private static generalFunctions generalFunctions = new generalFunctions();
        private static dashboardClass dashboardClass = new dashboardClass();

        public int EmployeeCount { get; set; }
        public int PresentCount { get; set; }
        public int LateCount { get; set; }
        public int AbsentCount { get; set; }
        public int LeaveRequestCount { get; set; }
        public int TravelRequestCount { get; set; }
        public int SlipRequestCount { get; set; }

        public departmentHeadDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        #region Getter Functions

        private async Task<DataTable> GetEmployeeTimeLogs(string department, DateTime date)
        {
            try
            {
                DataTable logs = await dashboardClass.GetEmployeeTimeLogs(department, date);
                
                if(logs != null)
                {
                    return logs;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetDepartment(int employeeId)
        {
            try
            {
                string department = await generalFunctions.GetPersonnelDepartment(employeeId);

                if (department != null)
                {
                    return department;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetEmployeeCount(string department)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfEmployee(department);
                return count;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetPresentCount(string department, string present, DateTime date)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfPresent(department, present, date);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetLateCount(string department, string late, DateTime date)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfLate(department, late, date);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetAbsentCount(string department, DateTime date)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfAbsent(department, date);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetLeaveRequestCount(string department)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfLeaveRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetTravelRequestCount(string department)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfTravelRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<int> GetSlipRequestCount(string department)
        {
            try
            {
                int count = await dashboardClass.GetNumberOfSlipRequest(department);
                return count;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function that responsible for retrieving automated application number for the application for leave creation
        private async Task<int> GetApplicationNumber()
        {
            try
            {
                int applicationNumber = await generalFunctions.GetApplicationNumber();

                if (applicationNumber >= 0)
                {
                    return ++applicationNumber;
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
                    return ++applicationNumber;
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
                    return ++applicationNumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetUserDetails(int userId)
        {
            try
            {
                DataTable details = await generalFunctions.GetEmployeeDetails(userId);

                if (details != null && details.Rows.Count > 0)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Personal Functions

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccesMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task DataBinding(int userId, string present, string late, DateTime date)
        {
            try
            {
                HideDepartmentPortal();
                HidePersonalPortal();
                _department = await GetDepartment(userId);

                if (_department != null)
                {
                    // Clear existing data bindings
                    employeeCount.DataBindings.Clear();
                    presentCount.DataBindings.Clear();
                    lateCount.DataBindings.Clear();
                    absentCount.DataBindings.Clear();
                    leaveRequestCount.DataBindings.Clear();
                    travelRequestCount.DataBindings.Clear();
                    slipRequestCount.DataBindings.Clear();

                    EmployeeCount = await GetEmployeeCount(_department);
                    PresentCount = await GetPresentCount(_department, present, date);
                    LateCount = await GetLateCount(_department, late, date);
                    AbsentCount = await GetAbsentCount(_department, date);
                    LeaveRequestCount = await GetLeaveRequestCount(_department);
                    TravelRequestCount = await GetTravelRequestCount(_department);
                    SlipRequestCount = await GetSlipRequestCount(_department);

                    // Add new data bindings
                    employeeCount.DataBindings.Add("Text", this, "EmployeeCount");
                    presentCount.DataBindings.Add("Text", this, "PresentCount");
                    lateCount.DataBindings.Add("Text", this, "LateCount");
                    absentCount.DataBindings.Add("Text", this, "AbsentCount");
                    leaveRequestCount.DataBindings.Add("Text", this, "LeaveRequestCount");
                    travelRequestCount.DataBindings.Add("Text", this, "TravelRequestCount");
                    slipRequestCount.DataBindings.Add("Text", this, "SlipRequestCount");
                }
                else
                {
                    ErrorMessages("There is an error in retrieving the Department Name", "Department Retrieval Error");
                }

                await DisplayTimeLogs(_department, DateTime.Now);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DisplayTimeLogs(string department, DateTime date)
        {
            try
            {
                attendanceList.Controls.Clear();
                DataTable logs = await GetEmployeeTimeLogs(department, date);

                if (logs != null)
                {
                    dashboardUC[] dashboardUC = new dashboardUC[logs.Rows.Count];

                    for (int i = 0; i < logs.Rows.Count; i++)
                    {
                        dashboardUC[i] = new dashboardUC();
                        DataRow row = logs.Rows[i];

                        if (!string.IsNullOrEmpty(row["employeeName"].ToString()))
                        {
                            dashboardUC[i].EmployeeName = $"{row["employeeName"]}";
                        }
                        else
                        {
                            dashboardUC[i].EmployeeName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            dashboardUC[i].EmployeeImage = $"{EmployeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            dashboardUC[i].EmployeeImage = defaultEmployeeImage;
                        }

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {
                            dashboardUC[i].JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            dashboardUC[i].JobDescription = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["morningIn"].ToString()) && DateTime.TryParse(row["morningIn"].ToString(), 
                            out DateTime morningIn))
                        {
                            dashboardUC[i].MorningIn = $"{morningIn: t}";
                        }
                        else
                        {
                            dashboardUC[i].MorningIn = "--:--:--";
                        }

                        if (!string.IsNullOrEmpty(row["morningOut"].ToString()) && DateTime.TryParse(row["morningOut"].ToString(), 
                            out DateTime morningOut))
                        {
                            dashboardUC[i].MorningOut = $"{morningOut: t}";
                        }
                        else
                        {
                            dashboardUC[i].MorningOut = "--:--:--";
                        }

                        if (!string.IsNullOrEmpty(row["morningStatus"].ToString()))
                        {
                            dashboardUC[i].MorningStatus = $"{row["morningStatus"]}";
                        }
                        else
                        {
                            dashboardUC[i].MorningStatus = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["afternoonIn"].ToString()) && DateTime.TryParse(row["afternoonIn"].ToString(), 
                            out DateTime afternoonIn))
                        {
                            dashboardUC[i].AfternoonIn = $"{afternoonIn: t}";
                        }
                        else
                        {
                            dashboardUC[i].AfternoonIn = "--:--:--";
                        }

                        if (!string.IsNullOrEmpty(row["afternoonOut"].ToString()) && DateTime.TryParse(row["afternoonOut"].ToString(), 
                            out DateTime afternoonOut))
                        {
                            dashboardUC[i].AfternoonOut = $"{afternoonOut: t}";
                        }
                        else
                        {
                            dashboardUC[i].AfternoonOut = "--:--:--";
                        }

                        if (!string.IsNullOrEmpty(row["afternoonStatus"].ToString()))
                        {
                            dashboardUC[i].AfternoonStatus = $"{row["afternoonStatus"]}";
                        }
                        else
                        {
                            dashboardUC[i].AfternoonStatus = "-------";
                        }

                        attendanceList.Controls.Add(dashboardUC[i]);
                    }
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

        public async Task DisplayFileLeave()
        {
            try
            {
                int applicationNumber = await GetApplicationNumber();
                content.Controls.Clear();
                fileLeaveUC fileLeave = new fileLeaveUC(_userId, this, _department);
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
                filePassSlipUC passSlip = new filePassSlipUC(_userId, this, _department);
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
                fileTravelOrderUC fileTravel = new fileTravelOrderUC(_userId, this, _department);
                fileTravel.ControlNumber = controlNumber;

                if(!content.Controls.Contains(fileTravel))
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

        // This function is responsible for allocating the User Details to the personal info in their personal portal
        public async Task UserDetails(int userId)
        {
            try
            {
                DataTable details = await GetUserDetails(userId);
                personalProfileUC personalInfo = new personalProfileUC(userId, this);
                content.Controls.Clear();

                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            personalInfo.EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                        }
                        else
                        {
                            personalInfo.EmployeeName = "----------";
                        }

                        personalInfo.EmployeeID = userId;

                        if (!string.IsNullOrEmpty(row["employeeJobDesc"].ToString()))
                        {

                            personalInfo.JobDescription = $"{row["employeeJobDesc"]}";
                        }
                        else
                        {
                            personalInfo.JobDescription = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeEmailAddress"].ToString()))
                        {
                            personalInfo.EmailAddress = $"{row["employeeEmailAddress"]}";
                        }
                        else
                        {
                            personalInfo.EmailAddress = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["barangay"].ToString()))
                        {
                            personalInfo.Barangay = $"{row["barangay"]}";
                        }
                        else
                        {
                            personalInfo.Barangay = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["municipality"].ToString()))
                        {
                            personalInfo.Municipality = $"{row["municipality"]}";
                        }
                        else
                        {
                            personalInfo.Municipality = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["province"].ToString()))
                        {
                            personalInfo.Province = $"{row["province"]}";
                        }
                        else
                        {
                            personalInfo.Province = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["zipCode"].ToString()))
                        {
                            personalInfo.ZipCode = $"{row["zipCode"]}";
                        }
                        else
                        {
                            personalInfo.ZipCode = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeContactNumber"].ToString()))
                        {
                            personalInfo.MobileNumber = $"{row["employeeContactNumber"]}";
                        }
                        else
                        {
                            personalInfo.MobileNumber = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            personalInfo.DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            personalInfo.DepartmentName = "----------";
                        }

                        if (!(bool)row["isActive"])
                        {
                            personalInfo.AccountStatus = "Inactive";
                        }
                        else
                        {
                            personalInfo.AccountStatus = "Active";
                        }

                        if (!string.IsNullOrEmpty(row["roleName"].ToString()))
                        {
                            personalInfo.AccessLevel = $"{row["roleName"]}";
                        }
                        else
                        {
                            personalInfo.AccessLevel = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeBirth"].ToString()))
                        {
                            DateTime birthday = DateTime.Parse(row["employeeBirth"].ToString());

                            personalInfo.Birthday = birthday.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            personalInfo.Birthday = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeSex"].ToString()))
                        {
                            personalInfo.Gender = $"{row["employeeSex"]}";
                        }
                        else
                        {
                            personalInfo.Gender = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeCivilStatus"].ToString()))
                        {
                            personalInfo.CivilStatus = $"{row["employeeCivilStatus"]}";
                        }
                        else
                        {
                            personalInfo.CivilStatus = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["educationalAttainment"].ToString()))
                        {
                            personalInfo.EducationalAttainment = $"{row["educationalAttainment"]}";
                        }
                        else
                        {
                            personalInfo.EducationalAttainment = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["nameOfSchool"].ToString()))
                        {
                            personalInfo.SchoolName = $"{row["nameOfSchool"]}";
                        }
                        else
                        {
                            personalInfo.SchoolName = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["schoolAddress"].ToString()))
                        {
                            personalInfo.SchoolAddress = $"{row["schoolAddress"]}";
                        }
                        else
                        {
                            personalInfo.SchoolAddress = "-----------";
                        }

                        if (!string.IsNullOrEmpty(row["course"].ToString()))
                        {
                            personalInfo.Course = $"{row["course"]}";
                        }
                        else
                        {
                            personalInfo.Course = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["salaryrateDescription"].ToString()))
                        {
                            personalInfo.SalaryRate = $"{row["salaryrateDescription"]}";
                        }
                        else
                        {
                            personalInfo.SalaryRate = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["amount"].ToString()))
                        {
                            decimal value = decimal.Parse(row["amount"].ToString());
                            personalInfo.SalaryValue = $"{value:C2}";
                        }
                        else
                        {
                            personalInfo.SalaryValue = $"{0:C2}";
                        }

                        if (!string.IsNullOrEmpty(row["payrollScheduleDescription"].ToString()))
                        {
                            personalInfo.PayrollSchedule = $"{row["payrollScheduleDescription"]}";
                        }
                        else
                        {
                            personalInfo.PayrollSchedule = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["employmentStatus"].ToString()))
                        {
                            personalInfo.EmploymentStatus = $"{row["employmentStatus"]}";
                        }
                        else
                        {
                            personalInfo.EmploymentStatus = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["dateHired"].ToString()))
                        {
                            DateTime dateHired = DateTime.Parse(row["dateHired"].ToString());

                            personalInfo.DateHired = dateHired.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            personalInfo.DateHired = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["dateRetired"].ToString()))
                        {
                            DateTime dateRetired = DateTime.Parse(row["dateRetired"].ToString());

                            personalInfo.DateResigned = dateRetired.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            personalInfo.DateResigned = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["employeeSignature"].ToString()))
                        {
                            personalInfo.EmployeeSignature = $"{EmployeeSignaturePath}{row["employeeSignature"]}";
                        }
                        else
                        {
                            personalInfo.EmployeeSignature = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(row["employeePicture"].ToString()))
                        {
                            personalInfo.EmployeeImage = $"{EmployeeImagePath}{row["employeePicture"]}";
                        }
                        else
                        {
                            personalInfo.EmployeeImage = defaultEmployeeImage;
                        }

                        if (!string.IsNullOrEmpty(row["employeePassword"].ToString()))
                        {
                            personalInfo.Password = $"{row["employeePassword"]}";
                        }
                        else
                        {
                            personalInfo.Password = "---------";
                        }
                    }

                    if (!content.Controls.Contains(personalInfo))
                    {
                        content.Controls.Add(personalInfo);
                        personalInfo.Dock = DockStyle.Fill;
                        personalInfo.BringToFront();
                    }
                    else
                    {
                        personalInfo.BringToFront();
                    }
                }
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

        // This function is responsible for displaying the Personal DTR as well as allocating the information
        public async Task DisplayPersonalDTR(int userId)
        {
            try
            {
                DataTable details = await GetUserDetails(userId);
                personalDTR personalDTR = new personalDTR(userId, this);

                if (details != null && details.Rows.Count > 0)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        personalDTR.EmployeeID = userId;

                        if (!string.IsNullOrEmpty(row["employeeFname"].ToString()) && !string.IsNullOrEmpty(row["employeeLname"].ToString()))
                        {
                            personalDTR.EmployeeName = $"{row["employeeFname"]} {row["employeeLname"]}";
                        }
                        else
                        {
                            personalDTR.EmployeeName = "---------";
                        }

                        if (!string.IsNullOrEmpty(row["morningShiftTime"].ToString()))
                        {
                            personalDTR.MorningShift = $"Morning: {row["morningShiftTime"]}";
                        }
                        else
                        {
                            personalDTR.MorningShift = "----------";
                        }

                        if (!string.IsNullOrEmpty(row["afternoonShiftTime"].ToString()))
                        {
                            personalDTR.AfternoonShift = $"Afternoon: {row["afternoonShiftTime"]}";
                        }
                        else
                        {
                            personalDTR.AfternoonShift = "----------";
                        }
                    }

                    if (!content.Controls.Contains(personalDTR))
                    {
                        content.Controls.Add(personalDTR);
                        personalDTR.Dock = DockStyle.Fill;
                        personalDTR.BringToFront();
                    }
                    else
                    {
                        personalDTR.BringToFront();
                    }
                }
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

        private void HideDepartmentPortal()
        {
            subordinatePanel.Visible = false;
            dtrPanel.Visible = false;
            leavePanel.Visible = false;
            leaveSubPanel.Visible = false;
            travelPanel.Visible = false;
            travelSubPanel.Visible = false;
            slipPanel.Visible = false;
            slipSubPanel.Visible = false;
            payrollPanel.Visible = false;
        }

        private void HidePersonalPortal()
        {
            profilePanel.Visible = false;
            personalDTRPanel.Visible = false;
            personalLeavePanel.Visible = false;
            personalLeaveSubPanel.Visible = false;
            personalTravelPanel.Visible = false;
            personalTravelSubPanel.Visible = false;
            personalSlipPanel.Visible = false;
            personalSlipSubPanel.Visible = false;
            personalPayslipPanel.Visible = false;
        }

        #endregion

        #region Event Handlers

        private async void departmentHeadDashboard_Load(object sender, EventArgs e)
        {
            await DataBinding(_userId, present, late, DateTime.Now);
        }

        private async void dashboardBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = dashboardBtn.Text;
            HideDepartmentPortal();
            HidePersonalPortal();
            content.Controls.Clear();

            if (!content.Controls.Contains(dashboardPanel))
            {
                content.Controls.Add(dashboardPanel);
                dashboardPanel.Dock = DockStyle.Fill;
                dashboardPanel.BringToFront();
                await DataBinding(_userId, present, late, DateTime.Now);
            }
            else
            {
                dashboardPanel.BringToFront();
                await DataBinding(_userId, present, late, DateTime.Now);
            }
        }

        private void departmentHeadBtn_Click(object sender, EventArgs e)
        {
            leaveSubPanel.Visible = false;
            travelSubPanel.Visible = false;
            slipSubPanel.Visible = false;
            HidePersonalPortal();

            if (!subordinatePanel.Visible && !dtrPanel.Visible && !leavePanel.Visible && !travelPanel.Visible && !slipPanel.Visible 
                && !payrollPanel.Visible)
            {
                subordinatePanel.Visible = true;
                dtrPanel.Visible = true;
                leavePanel.Visible = true;
                travelPanel.Visible = true;
                slipPanel.Visible = true;
                payrollPanel.Visible = true;
            }
            else
            {
                subordinatePanel.Visible = false;
                dtrPanel.Visible = false;
                leavePanel.Visible = false;
                travelPanel.Visible = false;
                slipPanel.Visible = false;
                payrollPanel.Visible = false;
            }
        }

        private void subordinateBtn_Click(object sender, EventArgs e)
        {
            subodinateManagementUC subordinate = new subodinateManagementUC(_userId, this, _department);
            titleLabel.Text = subordinateBtn.Text;
            leaveSubPanel.Visible = false;
            travelSubPanel.Visible = false;
            slipSubPanel.Visible = false;
            HidePersonalPortal();
            content.Controls.Clear();

            if (!content.Controls.Contains(subordinate))
            {
                content.Controls.Add(subordinate);
                subordinate.Dock = DockStyle.Fill;
                subordinate.BringToFront();
            }
            else
            {
                subordinate.BringToFront();
            }
        }

        private void dtrBtn_Click(object sender, EventArgs e)
        {
            dtrUC dtr = new dtrUC(_userId, this, _department);
            titleLabel.Text = dtrBtn.Text;
            leaveSubPanel.Visible = false;
            travelSubPanel.Visible = false;
            slipSubPanel.Visible = false;
            HidePersonalPortal();
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

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = leaveBtn.Text;
            travelSubPanel.Visible = false;
            slipSubPanel.Visible = false;
            HidePersonalPortal();

            if (leaveSubPanel.Visible)
            {
                leaveSubPanel.Visible = false;
            }
            else
            {
                leaveSubPanel.Visible = true;
            }
        }

        private void leaveRequestsBtn_Click(object sender, EventArgs e)
        {
            leaveRequestsUC leaveRequestsUC = new leaveRequestsUC(_userId, this, _department);
            HidePersonalPortal();
            content.Controls.Clear();

            if (!content.Controls.Contains(leaveRequestsUC))
            {
                content.Controls.Add(leaveRequestsUC);
                leaveRequestsUC.Dock = DockStyle.Fill;
                leaveRequestsUC.BringToFront();
            }
            else
            {
                leaveRequestsUC.BringToFront();
            }
        }

        private void leaveListBtn_Click(object sender, EventArgs e)
        {
            leaveListsUC leaveListsUC = new leaveListsUC(_userId, this, _department);
            HidePersonalPortal();
            content.Controls.Clear();

            if (!content.Controls.Contains(leaveListsUC))
            {
                content.Controls.Add(leaveListsUC);
                leaveListsUC.Dock = DockStyle.Fill;
                leaveListsUC.BringToFront();
            }
            else
            {
                leaveListsUC.BringToFront();
            }
        }

        private void travelBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = travelBtn.Text;
            leaveSubPanel.Visible = false;
            slipSubPanel.Visible = false;
            HidePersonalPortal();

            if (travelSubPanel.Visible == false)
            {
                travelSubPanel.Visible = true;
            }
            else
            {
                travelSubPanel.Visible = false;
            }
        }

        private void travelRequestBtn_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();
            travelOrderRequestUC travelRequest = new travelOrderRequestUC(_userId, this, _department);
            HidePersonalPortal();

            if (!content.Controls.Contains(travelRequest))
            {
                content.Controls.Add(travelRequest);
                travelRequest.Dock = DockStyle.Fill;
                travelRequest.BringToFront();
            }
            else
            {
                travelRequest.BringToFront();
            }
        }

        private void travelListsBtn_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();
            travelOrderListsUC travelOrderList = new travelOrderListsUC(_userId, this, _department);
            HidePersonalPortal();

            if (!content.Controls.Contains(travelOrderList))
            {
                content.Controls.Add(travelOrderList);
                travelOrderList.Dock = DockStyle.Fill;
                travelOrderList.BringToFront();
            }
            else
            {
                travelOrderList.BringToFront();
            }
        }

        private void passSlipBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = passSlipBtn.Text;
            leaveSubPanel.Visible = false;
            travelSubPanel.Visible = false;
            HidePersonalPortal();

            if (slipSubPanel.Visible)
            {
                slipSubPanel.Visible = false;
            }
            else
            {
                slipSubPanel.Visible = true;
            }
        }

        private void slipRequestBtn_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();
            passSlipRequestUC slipRequest = new passSlipRequestUC(_userId, this, _department);
            HidePersonalPortal();

            if (!content.Controls.Contains(slipRequest))
            {
                content.Controls.Add(slipRequest);
                slipRequest.Dock = DockStyle.Fill;
                slipRequest.BringToFront();
            }
            else
            {
                slipRequest.BringToFront();
            }
        }

        private void slipListBtn_Click(object sender, EventArgs e)
        {
            content.Controls.Clear();
            HidePersonalPortal();
            slipListUC slipList = new slipListUC(_userId, this, _department);

            if (!content.Controls.Contains(slipList))
            {
                content.Controls.Add(slipList);
                slipList.Dock = DockStyle.Fill;
                slipList.BringToFront();
            }
            else
            {
                slipList.BringToFront();
            }
        }

        private void payrollBtn_Click(object sender, EventArgs e)
        {
            payslipUC payslip = new payslipUC(_userId, this, _department);
            titleLabel.Text = payrollBtn.Text;
            leaveSubPanel.Visible = false;
            travelSubPanel.Visible = false;
            slipSubPanel.Visible = false;
            HidePersonalPortal();
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
            }
        }

        private void personalPortalBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();

            if(!personalPayslipPanel.Visible && !personalSlipPanel.Visible && !personalTravelPanel.Visible && !personalLeavePanel.Visible 
                && !personalDTRPanel.Visible && !profilePanel.Visible)
            {
                personalPayslipPanel.Visible = true;
                personalSlipPanel.Visible = true;
                personalTravelPanel.Visible = true;
                personalLeavePanel.Visible = true;
                personalDTRPanel.Visible = true;
                profilePanel.Visible = true;
            }
            else
            {
                personalPayslipPanel.Visible = false;
                personalSlipPanel.Visible = false;
                personalSlipSubPanel.Visible = false;
                personalTravelPanel.Visible = false;
                personalTravelSubPanel.Visible = false;
                personalLeavePanel.Visible = false;
                personalLeaveSubPanel.Visible = false;
                personalDTRPanel.Visible = false;
                profilePanel.Visible = false;
            }
        }

        private async void profileBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
            titleLabel.Text = profileBtn.Text;
            await UserDetails(_userId);
        }

        private async void personalDTRBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
            await DisplayPersonalDTR(_userId);
        }

        private void personalLeaveBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
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
            HideDepartmentPortal();
            await DisplayFileLeave();
            //fileLeaveModal fileLeave = new fileLeaveModal(_userId, this);
            //fileLeave.ShowDialog();
        }

        private void leaveLogsBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
            titleLabel.Text = leaveLogsBtn.Text;
            leaveLogsUC leaveLogs = new leaveLogsUC(_userId, this);
            content.Controls.Clear();

            if(!content.Controls.Contains(leaveLogs))
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
            HideDepartmentPortal();
            personalLeaveSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;

            if(personalTravelSubPanel.Visible)
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
            HideDepartmentPortal();
            await DisplayFileTravelOrder();
        }

        private void travelLogsBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
            titleLabel.Text = travelLogsBtn.Text;
            travelOrderLogUC travelOrderLog = new travelOrderLogUC(_userId, this);
            content.Controls.Clear();

            if(!content.Controls.Contains(travelOrderLog))
            {
                content.Controls.Add(travelOrderLog);
                travelOrderLog.Dock = DockStyle.Fill;
                travelOrderLog.BringToFront();
            }
            else
            {
                travelOrderLog.BringToFront();
            }
        }

        private void personalSlipBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
            personalTravelSubPanel.Visible = false;
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
            HideDepartmentPortal();
            await DisplayFilePassSlip();

            //filePassSlipModal fileSlip = new filePassSlipModal(_userId, this);
            //Slip.ShowDialog();
        }

        private void slipLogsBtn_Click(object sender, EventArgs e)
        {
            HideDepartmentPortal();
            titleLabel.Text = slipLogsBtn.Text;
            slipLogsUC slipLogs = new slipLogsUC(_userId, this);
            content.Controls.Clear();

            if(!content.Controls.Contains(slipLogs))
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
            titleLabel.Text = personalPayslipBtn.Text;
            HideDepartmentPortal();
            payslipLogsUC payslip = new payslipLogsUC(_userId, this);
            content.Controls.Clear();

            if(!content.Controls.Contains(payslip))
            {
                content.Controls.Add(payslip);
                payslip.Dock = DockStyle.Fill;
                payslip.BringToFront();
            }
            else
            {
                payslip.BringToFront();
            }
        }

        #endregion

        private void signoutBtn_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.ShowDialog();
        }
    }
}
