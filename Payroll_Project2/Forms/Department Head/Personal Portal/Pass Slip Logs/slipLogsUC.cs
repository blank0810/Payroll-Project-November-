using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Forms.Department_Head.Dashboard;
using Payroll_Project2.Forms.Department_Head.Personal_Portal.Pass_Slip_Logs.Pass_slip_log_sub_user_control;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Department_Head.Personal_Portal.Pass_Slip_Logs
{
    public partial class slipLogsUC : UserControl
    {
        private static int _userId;
        private static departmentHeadDashboard _parent;
        private static generalFunctions generalFunctions = new generalFunctions();

        public slipLogsUC(int userId, departmentHeadDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetSlipList(int employeeId, int year)
        {
            try
            {
                DataTable list = await generalFunctions.GetSlipList(employeeId, year);

                if (list != null)
                {
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        public async Task DisplayLogs()
        {
            try
            {
                listContentPanel.Controls.Clear();
                DataTable list = await GetSlipList(_userId, DateTime.Now.Year);

                if (list != null)
                {
                    slipLogDataUC[] slipLog = new slipLogDataUC[list.Rows.Count];

                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        slipLog[i] = new slipLogDataUC(_userId, this);
                        DataRow row = list.Rows[i];

                        if (!string.IsNullOrEmpty(row["slipControlNumber"].ToString()) && int.TryParse(row["slipControlNumber"].ToString(),
                            out int controlNumber))
                        {
                            slipLog[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            slipLog[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFile"].ToString()) && DateTime.TryParse(row["dateFile"].ToString(), out
                            DateTime dateFile))
                        {
                            slipLog[i].DateFiled = $"{dateFile: MMM dd, yyyy}";
                        }
                        else
                        {
                            slipLog[i].DateFiled = "--------";
                        }

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            slipLog[i].Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            slipLog[i].Status = "----------";
                        }

                        listContentPanel.Controls.Add(slipLog[i]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void slipLogsUC_Load(object sender, EventArgs e)
        {
            await DisplayLogs();
        }
    }
}
