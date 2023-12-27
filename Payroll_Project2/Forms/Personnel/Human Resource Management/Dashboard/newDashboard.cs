using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard.Dashboard_User_Control;
using Payroll_Project2.Forms.Personnel.Dashboard.Modal;
using Payroll_Project2.Forms.Personnel.DTR;
using Payroll_Project2.Forms.Personnel.Employee;
using Payroll_Project2.Forms.Personnel.Forms;
using Payroll_Project2.Forms.Personnel.Forms.Create_Form_Contents;
using Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Pass_Slip_Management;
using Payroll_Project2.Forms.Personnel.Human_Resource_Management.Forms.Travel_Order_Management;
using Payroll_Project2.Forms.Personnel.Municipal_Calendar;
using Payroll_Project2.Forms.Personnel.Payroll;
using Payroll_Project2.Forms.Personnel.Personal_Portal.File_Leave;
using Payroll_Project2.Forms.Personnel.Personal_Portal.File_Pass_Slip;
using Payroll_Project2.Forms.Personnel.Personal_Portal.File_Travel_Order;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Leave_Logs;
using Payroll_Project2.Forms.Personnel.Personal_Portal.My_Profile.Personnel_Profile;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Pass_Slip_Logs;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Payslip_Logs;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Personal_DTR;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Travel_Order_Logs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Dashboard
{
    public partial class newDashboard : Form
    {
        public static loginForm loginForm = new loginForm();
        private static int userId;
        public static string _password;
        private static readonly string mayorRole = "Mayor";
        private static personnelDashboard personnelClass = new personnelDashboard();
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly formClass formClass = new formClass();
        private static readonly string EmployeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string EmployeeSignaturePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeSignaturePath");
        private static readonly string defaultEmployeeImage = ConfigurationManager.AppSettings.Get("DefaultLogo");
        private static readonly string departmentLogoPath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");

        public newDashboard(int id)
        {
                
            InitializeComponent();
            userId = id;
        }

        #region Functions responsible for retrieving values from Personnel Class

        // This function is responsible for communicating with the Personnel Class
        // Specifically it retrieves the complete list of Departments and validate if its null or not
        private async Task<DataTable> GetDepartmentDetails()
        {
            try
            {
                DataTable details = await generalFunctions.GetDepartmentListDetails();

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

        // This function is responsible for communicating with the Personnel Class
        // Specifically it retrieves the complete number of Employees and validate if its null or not
        private async Task<int> GetNumberOfEmployee()
        {
            try
            {
                int numberOfEmployee = await generalFunctions.GetNumberOfEmployee();
                return numberOfEmployee;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for communicating with the Personnel Class
        // Specifically it retrieves the complete number of active Employees and validate if its null or not
        private async Task<int> GetNumberOfActive()
        {
            try
            {
                int numberOfActive = await personnelClass.GetNumberOfActive();
                return numberOfActive;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for communicating with the Personnel Class
        // Specifically it retrieves the complete number of Departments and validate if its null or not
        private async Task<int> GetNumberOfDepartment()
        {
            try
            {
                int numberOfDepartment = await personnelClass.GetNumberOfDepartment();
                return numberOfDepartment;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for communicating with the Personnel Class
        // Specifically it retrieves the complete list of searched Department and validate if its null or not
        private async Task<DataTable> GetSearchDepartment(string department)
        {
            try
            {
                DataTable SearchDepartment = await personnelClass.GetSearchDepartment(department);

                if (SearchDepartment == null && SearchDepartment.Rows.Count <= 0)
                {
                    return null;
                }
                else
                {
                    return SearchDepartment;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<DataTable> GetUserDetails(int userId)
        {
            try
            {
                DataTable details = await generalFunctions.GetEmployeeDetails(userId);

                if(details != null && details.Rows.Count > 0)
                {
                    return details;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Function responsible for retrieving the personnel name for the creation of Forms
        private async Task<string> GetPersonnelName(int userId)
        {
            try
            {
                string name = await formClass.GetPersonnelName(userId);

                if (name != null)
                {
                    return name;
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

        // This is to display the departments below
        public async Task displayDepartment()
        {
            try
            {
                DataTable DepartmentList = await GetDepartmentDetails();
                departmentList.Controls.Clear();

                int numberOfDepartment = await GetNumberOfDepartment();

                numOfDepartment.Text = numberOfDepartment.ToString();

                if (DepartmentList != null & DepartmentList.Rows.Count > 0)
                {
                    departmentCardUC[] departmentCardUC = new departmentCardUC[DepartmentList.Rows.Count];
                    for (int i = 0; i  < DepartmentList.Rows.Count; i++)
                    {
                        departmentCardUC[i] = new departmentCardUC(userId, this);
                        DataRow row = DepartmentList.Rows[i];

                        if (!string.IsNullOrEmpty(row["departmentId"].ToString()) && int.TryParse(row["departmentId"].ToString(), 
                            out int departmentId))
                        {
                            departmentCardUC[i].DepartmentId = departmentId;
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                        {
                            departmentCardUC[i].DepartmentName = $"{row["departmentName"]}";
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentName = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["departmentLogo"].ToString()))
                        {
                            departmentCardUC[i].DepartmentLogo = $"{departmentLogoPath}{row["departmentLogo"]}";
                        }
                        else
                        {
                            departmentCardUC[i].DepartmentLogo = defaultEmployeeImage;
                        }

                        if (!string.IsNullOrEmpty(row["regularCount"].ToString()) && int.TryParse(row["regularCount"].ToString(), 
                            out int regularCount))
                        {
                            departmentCardUC[i].RegularNumber = regularCount;
                        }
                        else
                        {
                            departmentCardUC[i].RegularNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["jobOrderCount"].ToString()) && int.TryParse(row["jobOrderCount"].ToString(),
                             out int jobOrderCount))
                        {
                            departmentCardUC[i].JobOrderNumber = jobOrderCount;
                        }
                        else
                        {
                            departmentCardUC[i].JobOrderNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["totalEmployees"].ToString()) && int.TryParse(row["totalEmployees"].ToString(), 
                            out int totalEmployee))
                        {
                            departmentCardUC[i].EmployeeNumber = totalEmployee;
                        }
                        else
                        {
                            departmentCardUC[i].EmployeeNumber = 0;
                        }

                        departmentList.Controls.Add(departmentCardUC[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // This function is responsible for allocating the User Details to the personal info in their personal portal
        public async Task UserDetails(int userId)
        {
            try
            {
                DataTable details = await GetUserDetails(userId);
                personalProfileUC personalInfo = new personalProfileUC(userId, this);
                contentPanel.Controls.Clear();

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

                    if (!contentPanel.Controls.Contains(personalInfo))
                    {
                        contentPanel.Controls.Add(personalInfo);
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

                if(details != null && details.Rows.Count > 0)
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

                    if (!contentPanel.Controls.Contains(personalDTR))
                    {
                        contentPanel.Controls.Add(personalDTR);
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

        //This function is responsible for displaying the filing of leave
        public async Task DisplayFileLeave()
        {
            try
            {
                titleLabel.Text = fileLeaveBtn.Text;
                personalTravelSubPanel.Hide();
                personalSlipSubPanel.Hide();
                int applicationNumber = await GetApplicationNumber();
                fileLeaveUC fileLeave = new fileLeaveUC(userId, this);
                contentPanel.Controls.Clear();

                fileLeave.ApplicationNumber = applicationNumber;

                if (!contentPanel.Controls.Contains(fileLeave))
                {
                    contentPanel.Controls.Add(fileLeave);
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
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This function is responsible for the HR Management leave filing
        public async Task LeaveDetails()
        {
            try
            {
                titleLabel.Text = "File Leave Request";
                int applicationNumber = await GetApplicationNumber();
                appForLeave fileLeave = new appForLeave(this, userId);
                string personnelName = await GetPersonnelName(userId);
                DataTable department = await GetUserDetails(userId);
                string mayor = await GetMayorName();
                contentPanel.Controls.Clear();

                if (department != null)
                {
                    foreach (DataRow row in department.Rows)
                    {
                        fileLeave.ApplicationNumber = applicationNumber;
                        fileLeave.DateFiled = DateTime.Today;
                        fileLeave.CertifiedDate = DateTime.Today;
                        fileLeave.PersonnelDepartment = $"{row["departmentName"]}";

                        if (!string.IsNullOrEmpty(mayor))
                        {
                            fileLeave.MayorName = mayor;
                        }
                        else
                        {
                            fileLeave.MayorName = "- - - - -";
                        }

                        if (!string.IsNullOrEmpty(personnelName))
                        {
                            fileLeave.PersonnelName = personnelName;
                        }
                        else
                        {
                            fileLeave.PersonnelName = "- - - - -";
                        }

                        if (!contentPanel.Controls.Contains(fileLeave))
                        {
                            contentPanel.Controls.Add(fileLeave);
                            fileLeave.Dock = DockStyle.Fill;
                            fileLeave.BringToFront();
                        }
                        else
                        {
                            fileLeave.BringToFront();
                        }
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

        // This function responsible for the HR Management for travel order filing
        public async Task TravelDetails()
        {
            try
            {
                titleLabel.Text = "File Travel Order";
                int controlNumber = await GetTravelControlNumber();
                string mayorName = await GetMayorName();
                DataTable department = await GetUserDetails(userId);
                travelOrder travelOrder = new travelOrder(this, userId);

                if (department != null)
                {
                    foreach (DataRow row in department.Rows)
                    {
                        travelOrder.ControlNumber = controlNumber;
                        travelOrder.DateFiled = DateTime.Now.Date;
                        travelOrder.PersonnelDepartment = $"{row["departmentName"]}";

                        if (mayorName != null)
                        {
                            travelOrder.Mayor = mayorName;
                        }
                        else
                        {
                            travelOrder.Mayor = "-----";
                        }

                        if (!contentPanel.Controls.Contains(travelOrder))
                        {
                            contentPanel.Controls.Add(travelOrder);
                            travelOrder.Dock = DockStyle.Fill;
                            travelOrder.BringToFront();
                        }
                        else
                        {
                            travelOrder.BringToFront();
                        }
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

        // This function is responsible for the HR management for pass slip filing
        public async Task SlipDetails()
        {
            try
            {
                personnelPassSlipUC passSlip = new personnelPassSlipUC(this, userId);
                string mayorName = await GetMayorName();
                int controlNumber = await GetSlipControlNumber();
                DataTable department = await GetUserDetails(userId);
                contentPanel.Controls.Clear();

                if (department != null)
                {
                    foreach (DataRow row in  department.Rows)
                    {
                        passSlip.ControlNumber = controlNumber;
                        passSlip.DateFiled = DateTime.Now;
                        passSlip.PersonnelDepartment = $"{row["departmentName"]}";

                        if (string.IsNullOrEmpty(mayorName))
                        {
                            passSlip.MayorName = "-----";
                        }
                        else
                        {
                            passSlip.MayorName = mayorName;
                        }

                        if (!contentPanel.Controls.Contains(passSlip))
                        {
                            contentPanel.Controls.Add(passSlip);
                            passSlip.Dock = DockStyle.Fill;
                            passSlip.BringToFront();
                        }
                        else
                        {
                            passSlip.BringToFront();
                        }
                    }
                }
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

        // This  function is responsible for personal portal pass slip filing
        public async Task FilePassSlip()
        {
            try
            {
                titleLabel.Text = fileSlipBtn.Text;
                personalLeaveSubPanel.Hide();
                personalTravelPanel.Hide();
                int controlNumber = await GetSlipControlNumber();
                filePassSlipUC filePassSlip = new filePassSlipUC(userId, this);
                filePassSlip.ControlNumber = controlNumber;
                contentPanel.Controls.Clear();

                if(!contentPanel.Controls.Contains(filePassSlip))
                {
                    contentPanel.Controls.Add(filePassSlip);
                    filePassSlip.Dock = DockStyle.Fill;
                    filePassSlip.BringToFront();
                }
                else
                {
                    filePassSlip.BringToFront();
                }
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

        // This function is responsible for filing Travel Order in personal portal
        public async Task FileTravelOrder()
        {
            try
            {
                titleLabel.Text = fileTravelBtn.Text;
                personalLeaveSubPanel.Hide();
                personalSlipSubPanel.Hide();
                int controlNumber = await GetTravelControlNumber();
                fileTravelOrderUC fileTravelOrder = new fileTravelOrderUC(userId, this);
                fileTravelOrder.ControlNumber = controlNumber;
                contentPanel.Controls.Clear();

                if(!contentPanel.Controls.Contains(fileTravelOrder))
                {
                    contentPanel.Controls.Add(fileTravelOrder);
                    fileTravelOrder.Dock = DockStyle.Fill;
                    fileTravelOrder.BringToFront();
                }
                else
                {
                    fileTravelOrder.BringToFront();
                }
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

        private void DisplayHR()
        {
            employeePanel.Visible = true;
            leaveManagementPanel.Visible = true;
            payrollPanel.Visible = true;
            dtrPanel.Visible = true;
            travelOrderManagementPanel.Visible = true;
            passSlipManagementPanel.Visible = true;
        }

        private void HideHR()
        {
            employeePanel.Visible = false;
            leaveManagementPanel.Visible = false;
            leaveManagementSubPanel.Visible = false;
            payrollPanel.Visible = false;
            dtrPanel.Visible = false;
            travelOrderManagementPanel.Visible = false;
            travelOrderSubPanel.Visible = false;
            passSlipManagementPanel.Visible = false;
            passSlipSubPanel.Visible = false;
        }

        private void ShowPersonal()
        {
            personalProfilePanel.Visible = true;
            personalDTRPanel.Visible = true;
            personalLeavePanel.Visible = true;
            personalTravelPanel.Visible = true;
            personalSlipPanel.Visible = true;
            personalPayslipPanel.Visible = true;
        }

        private void HidePersonal()
        {
            personalProfilePanel.Visible = false;
            personalDTRPanel.Visible = false;
            personalLeavePanel.Visible = false;
            personalTravelPanel.Visible = false;
            personalSlipPanel.Visible = false;
            personalPayslipPanel.Visible = false;
            personalLeaveSubPanel.Visible = false;
            personalTravelSubPanel.Visible = false;
            personalSlipSubPanel.Visible = false;
        }

        #endregion

        #region Functions below is UI Interactions and Event Handlers

        // This Function is an event handler that decides what will happen if the Dashboard is being loaded
        private async void newDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                HideHR();
                HidePersonal();
                leaveManagementSubPanel.Hide();
                payrollSubPanel.Hide();
                travelOrderSubPanel.Hide();
                passSlipSubPanel.Hide();
                await displayDepartment();
                int numberOfDepartment = await GetNumberOfDepartment();
                int numberOfEmployee = await GetNumberOfEmployee();
                int numberOfActive = await GetNumberOfActive();

                if(numberOfDepartment > 0 && numberOfEmployee > 0 && numberOfActive > 0)
                {
                    numOfDepartment.Text = numberOfDepartment.ToString();
                    employeeNum.Text = numberOfEmployee.ToString();
                    activeUser.Text = numberOfActive.ToString();
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

        private void hrBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            HidePersonal();

            if(employeePanel.Visible)
            {
                HideHR();
            }
            else
            {
                DisplayHR();
            }
        }

        // Button for adding new department
        private async void addDepartmentBtn_Click(object sender, EventArgs e)
        {
            addDepartment addDepartment = new addDepartment(userId, this);
            addDepartment.ShowDialog();

            await displayDepartment();
        }

        // Employee Button Being clicked
        private void employeeBtn_Click(object sender, EventArgs e)
        {
            employeeUserControl employeeUserControl = new employeeUserControl(userId);
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            contentPanel.Controls.Clear();
            titleLabel.Text = employeeBtn.Text;

            if (!contentPanel.Controls.Contains(employeeUserControl))
            {
                contentPanel.Controls.Add(employeeUserControl);
                employeeUserControl.Dock = DockStyle.Fill;
                employeeUserControl.BringToFront();
            }
            else
            {
                employeeUserControl.BringToFront();
            }
        }

        private void leaveManagementBtn_Click(object sender, EventArgs e)
        {
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();

            if(!leaveManagementSubPanel.Visible)
            {
                leaveManagementSubPanel.Visible = true;
            }
            else
            {
                leaveManagementSubPanel.Visible = false;
            }
        }

        private async void createLeaveBtn_Click(object sender, EventArgs e)
        {
            await LeaveDetails();
        }

        private void leaveRequestBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = leaveRequestBtn.Text;
            leaveApproveUC leaveApprove = new leaveApproveUC(userId, this);
            contentPanel.Controls.Clear();

            if(!contentPanel.Controls.Contains(leaveApprove))
            {
                contentPanel.Controls.Add(leaveApprove);
                leaveApprove.Dock = DockStyle.Fill;
                leaveApprove.BringToFront();
            }
            else
            {
                leaveApprove.BringToFront();
            }
        }

        private void travelOrderManagementBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            passSlipSubPanel.Hide();

            if (!travelOrderSubPanel.Visible)
            {
                travelOrderSubPanel.Visible = true;
            }
            else
            {
                travelOrderSubPanel.Visible = false;
            }
        }

        private async void createTravelBtn_Click(object sender, EventArgs e)
        {
            await TravelDetails();
        }

        private void travelRequestBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = travelRequestBtn.Text;
            travelApproveUC travel = new travelApproveUC(userId, this);
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(travel))
            {
                contentPanel.Controls.Add(travel);
                travel.Dock = DockStyle.Fill;
                travel.BringToFront();
            }
            else
            {
                travel.BringToFront();
            }
        }

        private void passSlipManagementBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();

            if(!passSlipSubPanel.Visible)
            {
                passSlipSubPanel.Visible = true;
            }
            else
            {
                passSlipSubPanel.Visible = false;
            }
        }

        private async void createPassSlipBtn_Click(object sender, EventArgs e)
        {
            await SlipDetails();
        }

        private void passSlipRequestBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = passSlipRequestBtn.Text;
            slipApproveUC slip = new slipApproveUC(userId, this);
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(slip))
            {
                contentPanel.Controls.Add(slip);
                slip.Dock = DockStyle.Fill;
                slip.BringToFront();
            }
            else
            {
                slip.BringToFront();
            }

        }

        // Payroll Button
        private void payrollBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            titleLabel.Text = payrollBtn.Text;

            if (payrollSubPanel.Visible)
            {
                payrollSubPanel.Hide();
            }
            else
            {
                payrollSubPanel.Show();
            }
        }

        // Button for creating Payroll
        private void createPayrollBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            leaveManagementSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            titleLabel.Text = createPayrollBtn.Text;
            contentPanel.Controls.Clear();
            payroll payrollUC = new payroll(userId, this);

            if (!contentPanel.Controls.Contains(payrollUC))
            {
                contentPanel.Controls.Add(payrollUC);
                payrollUC.Dock = DockStyle.Fill;
                payrollUC.BringToFront();
            }
            else
            {
                payrollUC.BringToFront();
            }
        }

        // Button for payroll list for every employee
        private void payrollListBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(payrollList.Instance))
            {
                contentPanel.Controls.Add(payrollList.Instance);
                payrollList.Instance.Dock = DockStyle.Fill;
                payrollList.Instance.BringToFront();
            }
            else
            {
                payrollList.Instance.BringToFront();
            }
        }

        // Button for viewing the Municipality Calendar
        private void calendarBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            contentPanel.Controls.Clear();
            //titleLabel.Text = calendarBtn.Text;
            calendarUC calendarUC = new calendarUC(userId, this);

            if (!contentPanel.Controls.Contains(calendarUC))
            {
                contentPanel.Controls.Add(calendarUC);
                calendarUC.Dock = DockStyle.Fill;
                calendarUC.BringToFront();
            }
            else
            {
                calendarUC.BringToFront();
            }
        }

        // Button for when clicking the dashboard button
        private async void dashboardBtn_Click(object sender, EventArgs e)
        {
            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            contentPanel.Controls.Clear();
            HideHR();

            if(!contentPanel.Controls.Contains(dashboardPanel))
            {
                contentPanel.Controls.Add(dashboardPanel);
                dashboardPanel.Dock = DockStyle.Fill;
                dashboardPanel.BringToFront();
            }
            else
            {
                dashboardPanel.BringToFront();
            }

            await displayDepartment();
        }

        // Button for clicking the search button for the department lists
        private async void searchBtn_Click_1(object sender, EventArgs e)
        {
            departmentList.Controls.Clear();
            personnelDashboard personnelClass = new personnelDashboard();
            DataTable SearchDepartment = new DataTable();

            try
            {
                SearchDepartment = await generalFunctions.GetSearchDepartmentListDetails(searchDepartment.Texts);

                if (SearchDepartment != null & SearchDepartment.Rows.Count > 0)
                {
                    departmentCardUC[] departmentCardUC = new departmentCardUC[SearchDepartment.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach(DataRow row in SearchDepartment.Rows)
                        {
                            departmentCardUC[i] = new departmentCardUC(userId, this);

                            if (!string.IsNullOrEmpty(row["departmentName"].ToString()))
                            {
                                departmentCardUC[i].DepartmentName = $"{row["departmentName"]}";
                            }
                            else
                            {
                                departmentCardUC[i].DepartmentName = "--------";
                            }

                            if (!string.IsNullOrEmpty(row["departmentLogo"].ToString()))
                            {
                                departmentCardUC[i].DepartmentLogo = $"{row["departmentLogo"]}";
                            }
                            else
                            {
                                departmentCardUC[i].DepartmentLogo = defaultEmployeeImage;
                            }

                            if (!string.IsNullOrEmpty(row["regularCount"].ToString()) && int.TryParse(row["regularCount"].ToString(),
                                out int regularCount))
                            {
                                departmentCardUC[i].RegularNumber = regularCount;
                            }
                            else
                            {
                                departmentCardUC[i].RegularNumber = 0;
                            }

                            if (!string.IsNullOrEmpty(row["jobOrderCount"].ToString()) && int.TryParse(row["jobOrderCount"].ToString(),
                                 out int jobOrderCount))
                            {
                                departmentCardUC[i].JobOrderNumber = jobOrderCount;
                            }
                            else
                            {
                                departmentCardUC[i].JobOrderNumber = 0;
                            }

                            if (!string.IsNullOrEmpty(row["totalEmployees"].ToString()) && int.TryParse(row["totalEmployees"].ToString(),
                                out int totalEmployee))
                            {
                                departmentCardUC[i].EmployeeNumber = totalEmployee;
                            }
                            else
                            {
                                departmentCardUC[i].EmployeeNumber = 0;
                            }

                            departmentList.Controls.Add(departmentCardUC[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(text: @"There is no department named " + searchDepartment.Texts + " stored in the database", caption: @"No Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await displayDepartment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption: @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await displayDepartment();
            }
        }

        // The text box for the search department where to input the name of the department you want to search
        private void searchDepartment__TextChanged(object sender, EventArgs e)
        {
            #region This is for the user types in the text box with 2 second interval before querying
            searchTimer.Stop();
            searchTimer.Interval = 2000;
            searchTimer.Tick += searchTimer_Tick;
            searchTimer.Start();
            #endregion
        }

        // This is a background timer that will be enabled if the user would not input new characters within
        // 2 seconds to execute searching of department
        private async void searchTimer_Tick(object sender, EventArgs e)
        {
            #region The retrieving of the result starts

            searchTimer.Stop();
            try
            {
                DataTable SearchDepartment = await GetSearchDepartment(searchDepartment.Texts);

                if (SearchDepartment != null && SearchDepartment.Rows.Count > 0)
                {
                    departmentCardUC[] departmentCardUC = new departmentCardUC[SearchDepartment.Rows.Count];
                    departmentList.Controls.Clear();

                    for (int i = 0; i < SearchDepartment.Rows.Count; i++)
                    {
                        departmentCardUC[i] = new departmentCardUC(userId, this);
                        DataRow row = SearchDepartment.Rows[i];

                        departmentCardUC[i].DepartmentName = row["departmentname"].ToString();
                        departmentCardUC[i].DepartmentLogo = row["departmentLogo"].ToString();

                        departmentList.Controls.Add(departmentCardUC[i]);
                    }
                }
                else
                {
                    MessageBox.Show(@"There is no department named " + searchDepartment.Texts + " " +
                        "stored in the database", @"No Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await displayDepartment();
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
                await displayDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(text: ex.Message, caption: @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 await displayDepartment();
            }
            #endregion
        }

        // Button when clicking the DTR button
        private void dtrBtn_Click(object sender, EventArgs e)
        {
            dtrMainUC dtr = new dtrMainUC(userId, this);

            leaveManagementSubPanel.Hide();
            payrollSubPanel.Hide();
            travelOrderSubPanel.Hide();
            passSlipSubPanel.Hide();
            contentPanel.Controls.Clear();
            titleLabel.Text = "DTR Management by Employee";

            if (!contentPanel.Controls.Contains(dtr))
            {
                contentPanel.Controls.Add(dtr);
                dtr.Dock = DockStyle.Fill;
                dtr.BringToFront();
            }
            else
            {
                dtr.BringToFront();
            }

        }

        private void portalBtn_Click(object sender, EventArgs e)
        {
            HideHR();

            if (personalProfilePanel.Visible)
            {
                HidePersonal();
            }
            else
            {
                ShowPersonal();
            }
        }

        private async void profileBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = profileBtn.Text;
            personalLeaveSubPanel.Hide();
            personalTravelSubPanel.Hide();
            personalSlipSubPanel.Hide();
            await UserDetails(userId);
        }

        private async void personalDTRBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = personalDTRBtn.Text;
            personalLeaveSubPanel.Hide();
            personalTravelSubPanel.Hide();
            personalSlipSubPanel.Hide();
            personalDTR personalDTR = new personalDTR(userId, this);
            contentPanel.Controls.Clear();
            await DisplayPersonalDTR(userId);
        }

        private void personalLeaveBtn_Click(object sender, EventArgs e)
        {
            personalTravelSubPanel.Hide();
            personalSlipSubPanel.Hide();

            if (personalLeaveSubPanel.Visible)
            {
                personalLeaveSubPanel.Hide();
            }
            else
            {
                personalLeaveSubPanel.Show();
            }
        }

        private async void fileLeaveBtn_Click(object sender, EventArgs e)
        {
            await DisplayFileLeave();
        }

        private void leaveLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = leaveLogsBtn.Text;
            personalTravelSubPanel.Hide();
            personalSlipSubPanel.Hide();
            leaveLogsUC leave = new leaveLogsUC(userId, this);
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(leave))
            {
                contentPanel.Controls.Add(leave);
                leave.Dock = DockStyle.Fill;
                leave.BringToFront();
            }
            else
            {
                leave.BringToFront();
            }

        }

        private void personalTravelBtn_Click(object sender, EventArgs e)
        {
            personalLeaveSubPanel.Hide();
            personalSlipSubPanel.Hide();

            if (personalTravelSubPanel.Visible)
            {
                personalTravelSubPanel.Hide();
            }
            else
            {
                personalTravelSubPanel.Show();
            }
        }

        private async void fileTravelBtn_Click(object sender, EventArgs e)
        {
            await FileTravelOrder();
        }

        private void travelLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = fileTravelBtn.Text;
            personalLeaveSubPanel.Hide();
            personalSlipSubPanel.Hide();
            travelOrderLogUC travelOrder = new travelOrderLogUC(userId, this);
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(travelOrder))
            {
                contentPanel.Controls.Add(travelOrder);
                travelOrder.Dock = DockStyle.Fill;
                travelOrder.BringToFront();
            }
            else
            {
                travelOrder.BringToFront();
            }
        }

        private void personalSlipBtn_Click(object sender, EventArgs e)
        {
            personalLeaveSubPanel.Hide();
            personalTravelSubPanel.Hide();

            if (personalSlipSubPanel.Visible)
            {
                personalSlipSubPanel.Hide();
            }
            else
            {
                personalSlipSubPanel.Show();
            }
        }

        private async void fileSlipBtn_Click(object sender, EventArgs e)
        {
            await FilePassSlip();
        }

        private void slipLogsBtn_Click(object sender, EventArgs e)
        {
            titleLabel.Text = slipLogsBtn.Text;
            personalLeaveSubPanel.Hide();
            personalTravelSubPanel.Hide();
            slipLogsUC slipLogs = new slipLogsUC(userId, this);
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(slipLogs))
            {
                contentPanel.Controls.Add(slipLogs);
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
            personalLeaveSubPanel.Hide();
            personalTravelSubPanel.Hide();
            personalSlipSubPanel.Hide();
            payslipLogsUC payslip = new payslipLogsUC(userId, this);
            contentPanel.Controls.Clear();

            if (!contentPanel.Controls.Contains(payslip))
            {
                contentPanel.Controls.Add(payslip);
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
