using Payroll_Project2.Classes_and_SQL_Connection.Class.Personnel;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.General_Functions;
using Payroll_Project2.Classes_and_SQL_Connection.Connections.System_Administrator;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal
{
    public partial class modifyDepartment : Form
    {
        private static int _userId;
        private static readonly generalFunctions generalFunctions = new generalFunctions();
        private static readonly departmentManagementClass departmentManagementClass = new departmentManagementClass();
        private static readonly string employeeImagePath = ConfigurationManager.AppSettings.Get("DestinationEmployeeImagePath");
        private static readonly string departmentLogoPath = ConfigurationManager.AppSettings.Get("DestinationDepartmentImagePath");

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentInitials { get; set; }
        public string DepartmentImage { get; set; }

        public modifyDepartment(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

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

        private async Task<bool> UpdateDepartmentInformation(int departmentId, string departmentName, string departmentInitials, 
            string departmentLogo)
        {
            try
            {
                bool update = await departmentManagementClass.UpdateDepartmentInformation(departmentId, departmentName,
                    departmentInitials, departmentLogo);
                return update;
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
        }

        private void ErrorMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SuccessMessages(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataBinding()
        {
            departmentName.Texts = DepartmentName;
            departmentInitials.Texts = DepartmentInitials;
            departmentLogo.ImageLocation = DepartmentImage;
            departmentImageBox.Texts = DepartmentImage;
        }

        private void modifyDepartment_Load(object sender, System.EventArgs e)
        {
            DataBinding();
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void departmentName__TextChanged(object sender, EventArgs e)
        {
            DepartmentName = departmentName.Texts;
        }

        private void departmentInitials__TextChanged(object sender, EventArgs e)
        {
            DepartmentInitials = departmentInitials.Texts;
        }

        private void departmentImageBox__TextChanged(object sender, EventArgs e)
        {
            DepartmentImage = departmentImageBox.Texts;
        }

        private void departmentImageBtn_Click(object sender, EventArgs e)
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

        private bool IsValid()
        {
            if(string.IsNullOrEmpty(departmentName.Texts))
            {
                ErrorMessages($"Please provide the department name!", "Department Name Input");
                return false;
            }
            else if (string.IsNullOrEmpty(departmentInitials.Texts))
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

        private bool UploadImage(string departmentImage)
        {
            try
            {
                string newImage = $"{departmentLogoPath}{DepartmentName.Replace(" ", "")}{Path.GetExtension(departmentImage)}";
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

        private async Task<bool> SubmitUpdateDepartment(int departmentId, string departmentName, string departmentInitials, 
            string departmentLogo)
        {
            try
            {
                bool update = await UpdateDepartmentInformation(departmentId, departmentName, departmentInitials, departmentLogo);

                if(update)
                {
                    return true;
                }
                else
                {
                    ErrorMessages("There is an error encoutered updating department's information. Please contact " +
                        "the IT department for resolution!", "Information Update Error");
                    return false;
                }
            }
            catch (SqlException sql) { throw sql; } catch (Exception ex) { throw ex; }
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
                string systemLogDescription = "Department Modification/Update: " +
                    "||Administrator Name: " + name +
                    "||Department Name: " + DepartmentName +
                    "||Date and Time Updated: " + DateTime.Now.ToString("f");

                string systemLogCaption = "Department Update";

                bool addSystemLog = await AddSystemLogs(DateTime.Now, systemLogDescription, systemLogCaption);

                if (addSystemLog)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"The department information is already modified, but there is an error in adding the transaction " +
                        $"into the system logs. Please " +
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
            try
            {
                if (!IsValid())
                    return;

                if (!UploadImage(DepartmentImage))
                    return;

                bool update = await SubmitUpdateDepartment(DepartmentId, DepartmentName, DepartmentInitials, DepartmentImage);
                if (!update)
                    return;

                string name = await GetUserName(_userId);
                if (string.IsNullOrEmpty(name))
                    return;

                bool addSystemLog = await AddNewSystemLogs(name);
                if (!addSystemLog)
                    return;

                SuccessMessages($"The modification of the department {DepartmentName} is already done. Please review the modified " +
                    $"information.", "Department Information Update Done");
                this.Close();
            }
            catch (SqlException sql)
            {
                ErrorMessages(sql.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                ErrorMessages(ex.Message, "Exception Error");
            }
        }
    }
}
