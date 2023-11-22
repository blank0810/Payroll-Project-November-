using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Travel_Order.File_Travel_Order_sub_user_control
{
    public partial class travelOrderDataUC : UserControl
    {
        public int ControlNumber { get; set; }
        public string DepartureDate { get; set; }
        public string Purpose { get; set; }
        public string Destination {  get; set; }

        public travelOrderDataUC()
        {
            InitializeComponent();
        }

        private void DataBinding()
        {
            controlNumber.DataBindings.Add("Text", this, "ControlNumber");
            departureDate.DataBindings.Add("Text", this, "DepartureDate");
            purpose.DataBindings.Add("Text", this, "Purpose");
            destination.DataBindings.Add("Text", this, "Destination");
        }

        private void travelOrderDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
