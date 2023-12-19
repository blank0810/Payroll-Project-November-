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
