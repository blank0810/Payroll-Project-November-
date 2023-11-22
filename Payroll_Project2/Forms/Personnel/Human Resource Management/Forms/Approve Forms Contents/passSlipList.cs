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
    public partial class passSlipList : UserControl
    {
        // Function so that I can call this User Control to the Main Form
        private static passSlipList _instance;

        public static passSlipList Instance
        {
            get { return _instance ?? (_instance = new passSlipList()); }
        }

        public passSlipList()
        {
            InitializeComponent();
        }

        private void passSlipList_Load(object sender, EventArgs e)
        {
            slipList.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                passSlipData passSlip = new passSlipData();
                slipList.Controls.Add(passSlip);
            }
        }
    }
}
