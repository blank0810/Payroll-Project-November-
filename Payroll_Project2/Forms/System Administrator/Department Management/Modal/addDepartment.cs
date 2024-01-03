using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal
{
    public partial class addDepartment : Form
    {
        private static int _userId;
        private static readonly string defaulDepartmentLogo = ConfigurationManager.AppSettings["DefaultLogo"];
        private static readonly string departmentImageDestination = ConfigurationManager.AppSettings["DestinationDepartmentImagePath"];
        private static readonly generalFunctions generalFunctions = new generalFunctions(); 
        private static string DepartmentImage;
        private static string DepartmentName;
        private static string DepartmentInitials;

        public addDepartment(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        // This function is responsible for checking if the department does exist on the database or not
        private async Task<bool> CheckDepartment(string departmentName)
        {
            try
            {
                bool check = await generalFunctions.CheckDepartment(departmentName);

                return check;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is responsible for leaving a record or logs for every actions done in the system
        // Purpose for this if there is necesarry review that must be done they can see it into the logs
        private async Task<bool> AddSystemLogs(DateTime date, string description, string caption)
        {
            try
            {
                bool addSystemLog = await generalFunctions.AddSystemLogs(date, description, caption);

                if (addSystemLog)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function return some details based on the userId parameter for the systme logs and employee logs
        private async Task<string> GetUserDetails(int userId)
        {
            try
            {
                personnelDashboard personnel = new personnelDashboard();
                DataTable userDetails = await generalFunctions.GetUserDetails(userId);

                if (userDetails != null)
                {
                    foreach (DataRow row in userDetails.Rows)
                    {
                        string name = row["employeefname"].ToString() + " " + row["employeelname"];
                        string formattedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());

                        return formattedName;
                    }
                }
                else
                {
                    return null;
                }

                return null;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // This function is the one responsible for adding the new department forwarding the details into the personnel class
        private async Task<bool> AddDepartment(string departmentName, string initials, string logo)
        {
            try
            {
                bool addingDepartment = await generalFunctions.AddDepartment(departmentName, initials, logo);
                return addingDepartment;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customTextBox21__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(departmentName.Texts))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                DepartmentName = capitalizedText;
            }
        }

        private void abbreviation__TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(abbreviation.Texts))
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                DepartmentInitials = textBox.Text;
            }
            else
            {
                DepartmentInitials = "Not Applicable";
            }
        }

        private void departmentImageBox__TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(departmentImageBox.Texts))
            {
                departmentImageBox.Texts = defaulDepartmentLogo;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog departmentFile = new OpenFileDialog();
            departmentFile.Filter = "Image Files (*.jpg; *jpeg; *.png;) | *.jpg; *jpeg; *.png;";
            departmentFile.Title = "Select an Image";

            if (departmentFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap originalImage = new Bitmap(departmentFile.FileName);

                float resolution = originalImage.HorizontalResolution;

                int newHeight = 500;
                int newWidth = 500;
                Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
                departmentImageBox.Texts = departmentFile.FileName;
                departmentLogo.Image = newImage;
                originalImage.Dispose();
            }
        }

        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(departmentName.Texts))
            {
                ErrorMessages($"Please provide the department name!", "Department Name Input");
                return false;
            }
            else if (string.IsNullOrEmpty(abbreviation.Texts))
            {
                ErrorMessages($"Please provide the proper initials for the department!", "Department Initials Input");
                return false;
            }
            else if (string.IsNullOrEmpty(departmentImageBox.Texts))
            {
                ErrorMessages($"Please choose a department logo!", "Department Logo Input");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Custom function responsible for uploading/storing the image into the server
        private bool UploadImage(string departmentImage)
        {
            try
            {
                string newImage = $"{departmentImageDestination}{DepartmentName.Replace(" ", "")}{Path.GetExtension(departmentImage)}";
                File.Copy(departmentImage, newImage, true);
                DepartmentImage = Path.GetFileName(newImage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading image: {ex.Message}", "Image Upload Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Custom function that return is the department does exist or not
        private async Task<bool> CheckNewDepartment(string departmentName)
        {
            try
            {
                bool checkDepartment = await CheckDepartment(departmentName);

                if (checkDepartment)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"The department {departmentName} already exists in the database.", "Department Existence",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custoom function that is responsible if the department is added into the database or not
        private async Task<bool> AddNewDepartment(string departmentImage)
        {
            try
            {
                bool addNewDepartment = await AddDepartment(DepartmentName, DepartmentInitials, departmentImage);
                if (addNewDepartment)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"There is an error in adding the new department.", "Department Addition Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function that is responsible for retrieving the user name for the system logs
        private async Task<string> GetUserName(int userId)
        {
            try
            {
                string name = await GetUserDetails(userId);

                if (name == null)
                {
                    MessageBox.Show($"There is no valid name for the user. The department is added into the database, but there is an error " +
                        $"in adding it to the system logs. Please contact system administrators for this issue.", "User Name Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    return name;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for adding a new system logs
        private async Task<bool> AddNewSystemLogs(string name)
        {
            try
            {
                string systemLogDescription = "A new department has been added: " +
                    "||Administrator Name: " + name +
                    "||Department Name: " + DepartmentName +
                    "||Date and Time Added: " + DateTime.Now.ToString("f");

                string systemLogCaption = "Department Addition";

                bool addSystemLog = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addSystemLog)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"The department is already added, but there is an error in adding the transaction into the system logs. Please " +
                        $"contact the system administrators for this issue.", "System Log Addition Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            if (!IsValidated())
                return;

            bool checkDepartment = await CheckNewDepartment(DepartmentName);
            if (!checkDepartment)
                return;

            if (!UploadImage(departmentImageBox.Texts))
                return;

            bool addDepartment = await AddNewDepartment(DepartmentImage);
            if (!addDepartment)
                return;

            string name = await GetUserName(_userId);
            if (string.IsNullOrEmpty(name))
                return;

            bool addSystemLog = await AddNewSystemLogs(name);
            if (!addSystemLog)
                return;

            MessageBox.Show($"Department {DepartmentName} is already added to the database. Please review the details in the Department List.",
                "Department Addition Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
