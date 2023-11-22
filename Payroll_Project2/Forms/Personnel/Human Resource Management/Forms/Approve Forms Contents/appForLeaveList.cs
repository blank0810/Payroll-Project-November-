using Payroll_Project2.Custom_Design;
using Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents.Forms_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Forms.Approve_Forms_Contents
{
    public partial class appForLeaveList : UserControl
    {
        // Function so that I can call this User Control to the Main Form
        private static appForLeaveList _instance;

        public static appForLeaveList Instance
        {
            get { return _instance ?? (_instance = new appForLeaveList()); }
        }

        public appForLeaveList()
        {
            InitializeComponent();
        }

        private void applicationForLeave_Load(object sender, EventArgs e)
        {
            applicationList.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                applicationForLeaveData leave = new applicationForLeaveData();
                applicationList.Controls.Add(leave);
            }
        }
    }
}
