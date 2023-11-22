using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.DTR.Modal;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.DTR.DTR_User_Controls
{
    public partial class employeeDTRUC : UserControl
    {
        private static int _userId;
        private static dtrMainUC _parent;
        private static dtrClass dtrClass = new dtrClass();

        public string EmployeeImage { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string Departmentname { get; set; }
        public string MorningShift { get; set; }
        public string AfternoonShift { get; set; }
        public int DaysWorkedCount { get; set; }
        public int LeaveCount { get; set; }
        public int TravelOrderCount { get; set; }
        public int PassSlipCount { get; set; }
        public int LateCount { get; set; }
        public int UndertimeCount { get; set; }
        public int OvertimeCount { get; set; }
        public int AbsentCount { get; set; }

        public employeeDTRUC(int userId, dtrMainUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        // Function responsible for displaying the employee shift schedule into the DTR Modal
        private void DTRDetails(int employeeId)
        {
            try
            {
                dtrDetails dtrDetails = new dtrDetails(_userId, this);

                dtrDetails.EmployeeID = employeeId;
                dtrDetails.EmployeeName = EmployeeName;
                dtrDetails.MorningShift = $" {MorningShift}";
                dtrDetails.AfternoonShift = $" {AfternoonShift}";

                dtrDetails.ShowDialog();
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

        // Function responsible for displaying the data being forwarded from the DTR Main User Control
        private void DataBinding()
        {
            empPicture.DataBindings.Add("ImageLocation", this, "EmployeeImage");
            empName.DataBindings.Add("Text", this, "EmployeeName");
            empid.DataBindings.Add("Text", this, "EmployeeId");
            departmentName.DataBindings.Add("Text", this, "DepartmentName");
            morningShift.DataBindings.Add("Text", this, "MorningShift");
            afternoonShift.DataBindings.Add("Text", this, "AfternoonShift");
            daysWorkedCount.DataBindings.Add("Text", this, "DaysWorkedCount");
            leaveCount.DataBindings.Add("Text", this, "LeaveCount");
            travelOrderCount.DataBindings.Add("Text", this, "TravelOrderCount");
            passSlipCount.DataBindings.Add("Text", this, "PassSlipCount");
            lateCount.DataBindings.Add("Text", this, "LateCount");
            undertimeCount.DataBindings.Add("Text", this, "UndertimeCount");
            overtimeCount.DataBindings.Add("Text", this, "OvertimeCount");
            absentCount.DataBindings.Add("Text", this, "AbsentCount");

            daysWorkedCount.Location = new Point((dayWorkedPanel.Width - daysWorkedCount.Width) / 2, (dayWorkedPanel.Height - daysWorkedCount.Height) / 2);
            leaveCount.Location = new Point((leavePanel.Width - leaveCount.Width) / 2, (leavePanel.Height - leaveCount.Height) / 2);
            travelOrderCount.Location = new Point((travelOrderPanel.Width - travelOrderCount.Width) / 2, (travelOrderPanel.Height - travelOrderCount.Height) / 2);
            passSlipCount.Location = new Point((passSlipPanel.Width - passSlipCount.Width) / 2, (passSlipPanel.Height - passSlipCount.Height) / 2);
            lateCount.Location = new Point((latePanel.Width - lateCount.Width) / 2, (latePanel.Height - lateCount.Height) / 2);
            undertimeCount.Location = new Point((undertimePanel.Width - undertimeCount.Width) / 2, (undertimePanel.Height - undertimeCount.Height) / 2);
            overtimeCount.Location = new Point((overtimePanel.Width - overtimeCount.Width) / 2, (overtimePanel.Height - overtimeCount.Height) / 2);
            absentCount.Location = new Point((absentPanel.Width - absentCount.Width) / 2, (absentPanel.Height - absentCount.Height) / 2);        
        }

        // Event handler that handles if the User Control is being loaded
        private void employeeDTRUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        // Event Handler that handles if the details button is being clicked
        private void detailsBtn_Click(object sender, EventArgs e)
        {
            DTRDetails(EmployeeId);
        }
    }
}
