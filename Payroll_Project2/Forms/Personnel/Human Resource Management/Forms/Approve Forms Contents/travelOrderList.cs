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
    public partial class travelOrderList : UserControl
    {
        // Function so that I can call this User Control to the Main Form
        private static travelOrderList _instance;

        public static travelOrderList Instance
        {
            get { return _instance ?? (_instance = new travelOrderList()); }
        }

        public travelOrderList()
        {
            InitializeComponent();
        }

        private void travelOrderList_Load(object sender, EventArgs e)
        {
            orderList.Controls.Clear();

            for (int i = 0; i < 5; i++) 
            {
                travelOrderData travelOrder = new travelOrderData();
                orderList.Controls.Add(travelOrder);
            }
        }
    }
}
