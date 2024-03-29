﻿using Payroll_Project2.Forms.Employee.Dashboard.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Employee.Dashboard.Dashboard_User_Control
{
    public partial class benefitInformationUC : UserControl
    {
        private static int _userId;
        private static employeeDashboard _parent;

        public string Month { get; set; }
        public int PayrollID { get; set; }
        public int TotalValue { get; set; }

        public benefitInformationUC()
        {
            InitializeComponent();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            payslipDetailedView details = new payslipDetailedView(_userId, this);
            details.ShowDialog();
        }
    }
}
