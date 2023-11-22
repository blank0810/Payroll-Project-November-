using Payroll_Project2.Forms.Mayor.Travel_Order_Requests.Travel_Order_Requests_sub_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Mayor.Travel_Order_Requests.Modal
{
    public partial class travelDetailedView : Form
    {
        private static int _userId;
        private static requestDataUC _parent;
        private static string _userDepartment;
        private static bool IsApproved = true;
        private static bool IsNoted = true;

        public int ControlNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateFiled { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string ReturnTime { get; set; }
        public string Purpose { get; set; }
        public string Destination { get; set; }
        public string Remarks { get; set; }
        public string NotedBy { get; set; }
        public string NotedDate { get; set; }
        public string MayorName { get; set; }
        public bool IsNoteNull { get; set; }

        public travelDetailedView(int userId, requestDataUC parent, string userDepartment)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
            _userDepartment = userDepartment;
        }
    }
}
