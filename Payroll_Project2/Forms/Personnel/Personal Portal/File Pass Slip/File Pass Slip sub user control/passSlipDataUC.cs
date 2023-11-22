using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.File_Pass_Slip.File_Pass_Slip_sub_user_control
{
    public partial class passSlipDataUC : UserControl
    {
        private static int _userId;
        private static filePassSlipUC _parent;

        public string MonthYear { get; set; }
        public string NumberOfHours { get; set; }

        public passSlipDataUC(int userId, filePassSlipUC parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private void DataBinding()
        {
            monthYear.DataBindings.Add("Text", this, "MonthYear");
            numberOfHours.DataBindings.Add("Text", this, "NumberOfHours");
        }

        private void passSlipDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
