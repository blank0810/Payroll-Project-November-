using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.Personnel;
using Payroll_Project2.Forms.Personnel.Dashboard;
using Payroll_Project2.Forms.Personnel.Personal_Portal.Travel_Order_Logs.Travel_order_log_sub_user_control;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Personal_Portal.Travel_Order_Logs
{
    public partial class travelOrderLogUC : UserControl
    {
        private static int _userId;
        private static newDashboard _parent;
        private static generalFunctions generalFunctions = new generalFunctions();
        private static formClass formClass = new formClass();

        public travelOrderLogUC(int userId, newDashboard parent)
        {
            InitializeComponent();
            _userId = userId;
            _parent = parent;
        }

        private async Task<DataTable> GetTravelLogs(int employeeId, int year)
        {
            try
            {
                DataTable list = await generalFunctions.GetTravelList(employeeId, year);
                return list;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private async Task DisplayLogs()
        {
            try
            {
                listContentPanel.Controls.Clear();
                DataTable logs = await GetTravelLogs(_userId, DateTime.Now.Year);

                if (logs != null)
                {
                    travelOrderLogDataUC[] travelLogs = new travelOrderLogDataUC[logs.Rows.Count];

                    for (int i = 0; i <  logs.Rows.Count; i++)
                    {
                        travelLogs[i] = new travelOrderLogDataUC(_userId, this);
                        DataRow row = logs.Rows[i];

                        if (!string.IsNullOrEmpty(row["orderControlNumber"].ToString()) && int.TryParse(row["orderControlNumber"].ToString(), 
                            out int controlNumber))
                        {
                            travelLogs[i].ControlNumber = controlNumber;
                        }
                        else
                        {
                            travelLogs[i].ControlNumber = 0;
                        }

                        if (!string.IsNullOrEmpty(row["dateFiled"].ToString()) && DateTime.TryParse(row["dateFiled"].ToString(), 
                            out DateTime dateFiled))
                        {
                            travelLogs[i].DateFiled = $"{dateFiled: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelLogs[i].DateFiled = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["dateDeparture"].ToString()) && DateTime.TryParse(row["dateDeparture"].ToString(), 
                            out DateTime dateDeparture))
                        {
                            travelLogs[i].DateDeparture = $"{dateDeparture: MMM dd, yyyy}";
                        }
                        else
                        {
                            travelLogs[i].DateDeparture = "-------";
                        }

                        if (!string.IsNullOrEmpty(row["statusDescription"].ToString()))
                        {
                            travelLogs[i].Status = $"{row["statusDescription"]}";
                        }
                        else
                        {
                            travelLogs[i].Status = "-------";
                        }

                        listContentPanel.Controls.Add(travelLogs[i]);
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

        private async void travelOrderLogUC_Load(object sender, EventArgs e)
        {
            await DisplayLogs();
        }
    }
}
