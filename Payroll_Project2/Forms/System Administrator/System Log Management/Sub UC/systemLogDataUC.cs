using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.System_Log_Management.Sub_UC
{
    public partial class systemLogDataUC : UserControl
    {
        private static int _userId;
        private static readonly logsClass logsClass = new logsClass();

        public int LogId { get; set; }
        public string LogDate { get; set; }
        public string LogCaption { get; set; }

        public systemLogDataUC()
        {
            InitializeComponent();
        }

        private async Task<string> GetLogDescription(int logId)
        {
            try
            {
                string description = await logsClass.GetSystemLogDescription(logId);
                return description;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void DataBinding()
        {
            logId.DataBindings.Add("Text", this, "LogId");
            logDate.DataBindings.Add("Text", this, "LogDate");
            logCaption.DataBindings.Add("Text", this, "LogCaption");
        }

        private void systemLogDataUC_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private async void viewBtn_Click(object sender, EventArgs e)
        {
            string description = await GetLogDescription(LogId);

            MessageBox.Show(description, LogCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
