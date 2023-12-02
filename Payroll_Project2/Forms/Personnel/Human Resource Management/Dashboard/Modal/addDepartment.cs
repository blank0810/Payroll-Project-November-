using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.Personnel.Dashboard.Modal
{
    public partial class addDepartment : Form
    {
        public int userId;
        private static newDashboard _parent;
        private static readonly string departmentImageDestination = ConfigurationManager.AppSettings["DestinationDepartmentImagePath"];
        private static readonly string defaulDepartmentLogo = ConfigurationManager.AppSettings["DefaultLogo"];
        private static personnelDashboard personnel = new personnelDashboard();
        private static generalFunctions generalFunctions = new generalFunctions();

        private static string DepartmentImage;
        private static string DepartmentName;
        private static string DepartmentInitials;

        public addDepartment(int id, newDashboard parent)
        {
            InitializeComponent();
            userId = id;
            _parent = parent;
        }

        #region Functions below is for communicating with the personnel class
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
        private async Task<bool> AddDepartment (string departmentName, string initials, string logo)
        {
            try
            {
                bool addingDepartment = await personnel.AddDepartment(departmentName, initials, logo);
                return addingDepartment;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function gets if the user is authorized to an action
        private async Task<bool> GetAuthorization (int userId)
        {
            try
            {
                bool authorized = await generalFunctions.GetValidation(userId);
                return authorized;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        // This function is responsible for checking if the department does exist on the database or not
        private async Task<bool> CheckDepartment(string departmentName)
        {
            try
            {
                personnelDashboard personnel = new personnelDashboard();
                bool check = await personnel.CheckDepartment(departmentName);

                return check;
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region All event handlers that handles user interaction with the UI

        private void addDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is the Escape key
            if (e.KeyChar == (char)27) // 27 is the ASCII code for the Escape key
            {
                // Close the form
                this.Close();
            }
        }

        // This is an event handler that handles if the department name box value / text changes
        private void departmentName__TextChanged(object sender, EventArgs e)
        {
           if (!string.IsNullOrWhiteSpace(departmentName.Text))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string capitalizedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                textBox.Text = capitalizedText;
                textBox.SelectionStart = textBox.Text.Length; // Place cursor at the end

                DepartmentName = capitalizedText;
            }
        }

        // This is an event handler that handles if the departmente initials text box changes
        private void abbreviation__TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(abbreviation.Texts))
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

        // This is the picture box that stores the department image/logo
        private void departmentImageBox__TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(departmentImageBox.Texts))
            {
                departmentImageBox.Texts = defaulDepartmentLogo;
            }
        }

        // This is the upload button where specifically its event handler that handles if the upload button is being clicked
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

        #endregion

        #region Custom functions that is responsible for every logic conditions

        // Custom functions that check if the user input is valid or not
        private bool IsValidated()
        {
            if (string.IsNullOrEmpty(departmentName.Text))
            {
                MessageBox.Show("Please provide the department name and its corresponding initials.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        // Custom functions that the one returns the value if user is authorized or not
        private async Task<bool> IsAuthorized(int userId)
        {
            try
            {
                bool authorized = await GetAuthorization(userId);

                if (authorized)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("You are not authorized to perform this action.", "Authorization Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; }
            catch (Exception ex) { throw ex; }
        }

        // Custom function responsible for uploading/storing the image into the server
        private bool UploadImage(string departmentImage)
        {
            try
            {
                File.Copy(departmentImage, Path.Combine(departmentImageDestination, DepartmentName + Path.GetExtension(departmentImage)), true);
                DepartmentImage = DepartmentName + Path.GetExtension(departmentImage);
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
                    "||Personnel Name: " + name +
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

        #endregion

        // Event handlers that handles if the submit button is being clicked
        private async void submitBtn_Click(object sender, EventArgs e)
        {
            
            if (!IsValidated())
                return;

            bool authorized = await IsAuthorized(userId);
            if (!authorized)
                return;

            bool checkDepartment = await CheckNewDepartment(DepartmentName);
            if (!checkDepartment)
                return;

            if (!UploadImage(departmentImageBox.Texts))
                return;

            bool addDepartment = await AddNewDepartment(DepartmentImage);
            if (!addDepartment)
                return;

            string name = await GetUserName(userId);
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

        // Event handler that handles if the discard button clicked
        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
