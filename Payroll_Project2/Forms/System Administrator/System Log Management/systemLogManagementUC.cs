using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using Payroll_Project2.Forms.System_Administrator.System_Log_Management.Sub_UC;
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

namespace Payroll_Project2.Forms.System_Administrator.Log_Management
{
    public partial class systemLogManagementUC : UserControl
    {
        private static int _userId;
        private static readonly logsClass logsClass = new logsClass();

        public systemLogManagementUC(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async Task<DataTable> GetSystemLogs()
        {
            try
            {
                DataTable logs = await logsClass.GetAllSystemLogs();

                if (logs != null && logs.Rows.Count > 0)
                {
                    return logs;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DisplayAllLogs()
        {
            try
            {
                listPanel.Controls.Clear();
                DataTable logs = await GetSystemLogs();

                if (logs != null)
                {
                    systemLogDataUC[] logData = new systemLogDataUC[logs.Rows.Count];

                    for (int i = 0;  i < logs.Rows.Count; i++)
                    {
                        logData[i] = new systemLogDataUC();
                        DataRow row = logs.Rows[i];

                        if (!string.IsNullOrEmpty(row["systemLogId"]?.ToString()) && int.TryParse(row["systemLogId"]?.ToString(), 
                            out int logId))
                        {
                            logData[i].LogId = logId;
                        }
                        else
                        {
                            logData[i].LogId = 0;
                        }

                        if (!string.IsNullOrEmpty(row["logCaption"]?.ToString()))
                        {
                            logData[i].LogCaption = $"{row["logCaption"]}";
                        }
                        else
                        {
                            logData[i].LogCaption = "-----------";
                        }

                        if (!string.IsNullOrEmpty(row["systemLogDate"]?.ToString()) && DateTime.TryParse(row["systemLogDate"].ToString(), 
                            out DateTime logDate))
                        {
                            logData[i].LogDate = $"{logDate:MMM dd, yyyy}";
                        }
                        else
                        {
                            logData[i].LogDate = "-----------";
                        }

                        listPanel.Controls.Add(logData[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error");
            }
        }

        private async void systemLogManagementUC_Load(object sender, EventArgs e)
        {
            await DisplayAllLogs();
        }
    }
}
