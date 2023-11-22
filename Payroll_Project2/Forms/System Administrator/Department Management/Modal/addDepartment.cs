using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Payroll_Project2.Forms.System_Administrator.Department_Management.Modal
{
    public partial class addDepartment : Form
    {
        private static readonly string defaulDepartmentLogo = ConfigurationManager.AppSettings["DefaultLogo"];
        private static string DepartmentImage;
        private static string DepartmentName;
        private static string DepartmentInitials;

        public addDepartment()
        {
            InitializeComponent();
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
    }
}
