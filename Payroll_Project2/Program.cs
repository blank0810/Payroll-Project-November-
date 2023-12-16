using Payroll_Project2.Forms.Employee.Dashboard;
using Payroll_Project2.Forms.Personnel.Payroll.Modal;
using System;
using System.Windows.Forms;

namespace Payroll_Project2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This is the log-in form also the personnel dashboard
            Application.Run(new loginForm());

            //Application.Run(new payslip());

            // This is the system admin form
            //Application.Run(new systemAdminDashboard());

            // This is the system admin form
            //Application.Run(new departmentHeadDashboard());

            // This is the system admin form
            //Application.Run(new MayorDashboard());

            // This is the system admin form
            //Application.Run(new employeeDashboard());
        }
    }
}
