using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Mayor_Functions;
using Payroll_Project2.Forms.Mayor.Leave_Requests.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Leave_Requests.Leave_Request_Sub_User_Control
{
    public partial class requestDataUC : UserControl
    {
        private static int _userId;
        private static leaveRequestsUC _parent;
        private static string _userDepartment;
        private static readonly generalFunctions generalFunctions = new generalFunctions();

        public int ApplicationNumber { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DateFiled { get; set; }
        public string LeaveType { get; set; }
        public string DateCoverage { get; set; }

        public requestDataUC(int userId, leaveRequestsUC parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }

        private async Task<DataTable> GetLeaveDetails(int applicationNumber)
        {
            try
            {
                DataTable details = await generalFunctions.GetLeaveDetailedView(applicationNumber);

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

        private async Task<DataTable> GetLeaveTypes()
        {
            try
            {
                DataTable type = await generalFunctions.GetLeaveTypes();

                if(type != null && type.Rows.Count > 0)
                { 
                    return type; 
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<decimal> GetLeaveCredits(int employeeId, string leaveType)
        {
            try
            {
                decimal credits = await generalFunctions.GetEmployeeLeaveCredits(employeeId, leaveType);
                return credits;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task<string> GetMayorName(int userId)
        {
            try
            {
                string name = await generalFunctions.GetEmployeeName(userId);
                
                if(!string.IsNullOrEmpty(name))
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

        private async Task DisplayLeaveDetails(int applicationNumber, string dateFiled, int userId, string department, int employeeId)
        {
            try
            {
                DataTable details = await GetLeaveDetails(applicationNumber);
                DataTable leaveType = await GetLeaveTypes();
                string mayorName = await GetMayorName(userId);

                if (details != null && leaveType != null)
                {
                    foreach (DataRow row in details.Rows)
                    {
                        leaveRequestDetailedView leaveDetails = CreateLeaveDetailsView(applicationNumber, dateFiled, userId, employeeId, department, mayorName);

                        AssignValueIfNotEmpty(row, "employeeFname", value => leaveDetails.FirstName = value, "--------");
                        AssignValueIfNotEmpty(row, "employeeLname", value => leaveDetails.LastName = value, "--------");
                        AssignValueIfNotEmpty(row, "employeeMname", value => leaveDetails.MiddleName = value, "---------");
                        AssignValueIfNotEmpty(row, "departmentName", value => leaveDetails.Department = value, "---------");
                        AssignValueIfNotEmpty(row, "salaryRateDescription", value => leaveDetails.SalaryRate = value, "--------");
                        AssignValueIfNotEmpty(row, "employeeJobDesc", value => leaveDetails.JobDescription = value, "-------");
                        AssignValueIfNotEmpty(row, "leaveType", value => leaveDetails.LeaveType = value, "-------");
                        AssignValueIfNotEmpty(row, "leaveDetails", value => leaveDetails.LeaveDetails = value, "-------");

                        ParseAndAssignDateTime(row, "leaveStartDate", value => leaveDetails.LeaveStartDate = value, "--------");
                        ParseAndAssignDateTime(row, "leaveEndDate", value => leaveDetails.LeaveEndDate = value, "---------");

                        bool.TryParse(row["isRecommended"]?.ToString(), out bool isRecommended);
                        if (!string.IsNullOrEmpty(row["isRecommended"]?.ToString()))
                        {
                            leaveDetails.IsRecommendedNull = false;
                            leaveDetails.IsRecommended = isRecommended ? "Recommended to be Approved" : "Recommended to be Disapproved";
                        }
                        else
                        {
                            leaveDetails.IsRecommended = "---------";
                            leaveDetails.IsRecommendedNull = true;
                        }

                        if(leaveDetails.Department == department)
                        {
                            leaveDetails.IsSameDepartment = true;
                        }
                        else
                        {
                            leaveDetails.IsSameDepartment = false;
                        }

                        AssignValueIfNotEmpty(row, "recommendedBy", value => leaveDetails.RecommendedBy = value, "---------");

                        AssignValueIfNotEmpty(row, "certifiedBy", value => leaveDetails.CertifiedBy = value, "--------");
                        ParseAndAssignDateTime(row, "certificationDate", value => leaveDetails.CertificationDate = value, "--------");

                        decimal.TryParse(row["creditsUsed"]?.ToString(), out decimal creditsUsed);
                        if (!string.IsNullOrEmpty(row["creditsUsed"]?.ToString()))
                        {
                            leaveDetails.SickLeaveCreditsUsed = leaveDetails.LeaveType == "Sick Leave" ? creditsUsed : 0;
                            leaveDetails.VacationLeaveCreditsUsed = leaveDetails.LeaveType == "Sick Leave" ? 0 : creditsUsed;
                        }
                        else
                        {
                            leaveDetails.SickLeaveCreditsUsed = 0;
                            leaveDetails.VacationLeaveCreditsUsed = 0;
                        }

                        int.TryParse(row["numberOfDays"]?.ToString(), out int numberDays);
                        if (!string.IsNullOrEmpty(row["numberOfDays"]?.ToString()))
                        {
                            leaveDetails.NumberOfDays = numberDays;
                        }
                        else
                        {
                            leaveDetails.NumberOfDays = 0;
                        }

                        foreach (DataRow typeRow in leaveType.Rows)
                        {
                            if (!string.IsNullOrEmpty(row["leaveType"]?.ToString()))
                            {
                                decimal credits = await GetLeaveCredits(employeeId, $"{row["leaveType"]}");

                                if ($"{typeRow["leaveType"]}" == "Sick Leave")
                                {
                                    leaveDetails.SickLeaveCredits = credits;
                                }
                                else
                                {
                                    leaveDetails.VacationLeaveCredits = credits;
                                }
                            }
                            else
                            {
                                ErrorMessages("Error in retrieving the leave types, results in error in retrieving the employee's Leave Credits",
                                    "Leave Credits Error");
                            }
                        }

                        leaveDetails.SickLeaveBalance = ComputeBalanceCredits(leaveDetails.SickLeaveCredits, leaveDetails.SickLeaveCreditsUsed);
                        leaveDetails.VacationLeaveBalance = ComputeBalanceCredits(leaveDetails.VacationLeaveCredits, leaveDetails.VacationLeaveCreditsUsed);

                        leaveDetails.ShowDialog();
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

        private void AssignValueIfNotEmpty(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            string value = row[columnName]?.ToString();
            assignAction(!string.IsNullOrEmpty(value) ? value : defaultValue);
        }

        private void ParseAndAssignDateTime(DataRow row, string columnName, Action<string> assignAction, string defaultValue)
        {
            if (!string.IsNullOrEmpty(row[columnName]?.ToString()) && DateTime.TryParse(row[columnName]?.ToString(), out DateTime parsedDate))
            {
                assignAction($"{parsedDate: MMM dd, yyyy}");
            }
            else
            {
                assignAction(defaultValue);
            }
        }

        private leaveRequestDetailedView CreateLeaveDetailsView(int applicationNumber, string dateFiled, int userId, int employeeId, string department, 
            string mayorName)
        {
            return new leaveRequestDetailedView(userId, this, department)
            {
                ApplicationNumber = applicationNumber,
                DateFiled = dateFiled,
                MayorName = mayorName,
                EmployeeID = employeeId,
            };
        }

        private void DataBinding()
        {
            applicationNumber.DataBindings.Add("Text", this, "ApplicationNumber");
            employeeId.DataBindings.Add("Text", this, "EmployeeId");
            employeeName.DataBindings.Add("Text", this, "EmployeeName");
            dateFiled.DataBindings.Add("Text", this, "DateFiled");
            leaveType.DataBindings.Add("Text", this, "LeaveType");
            dateCoverage.DataBindings.Add("Text", this, "DateCoverage");
        }

        private decimal ComputeBalanceCredits(decimal creditsBalance, decimal creditsUsed)
        {
            return creditsBalance - creditsUsed;
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void requestDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            await DisplayLeaveDetails(ApplicationNumber, DateFiled, _userId, _userDepartment, EmployeeId);
            await _parent.DisplayLeaveRequest(_userId, _userDepartment);
        }
    }
}
