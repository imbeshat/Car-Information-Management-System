using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace CIMS
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        //Logic for clearing all the fields

        public void Reset()
        {
            txtName.Text = "";
            pwdPassword.Password = "";
            pwdcnfPassword.Password = "";
            txtResponse.Text = "";
            cmbQues.Text = "";
        }

        /*Logic for submitting the details
        of new Administrator to the database*/

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                SqlCommand cmd = new SqlCommand("Insert into Admin(UserName,Password,SecurityQuestion,Response) values(@UserName,@Password,@SecurityQuestion,@Response)", sqlCon);
                StringBuilder sb = new StringBuilder();
                int invalid = 0;
                if (!(Regex.IsMatch(txtName.Text, "\\w{5,}")))
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "UserName cannot be blank and size atleast be 5.");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UserName", txtName.Text);
                }

                if (!(Regex.IsMatch(pwdPassword.Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")))
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Password size be atleast 8.\nPassword must contain one Uppercase,lower case , numbers and special character.");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Password", pwdPassword.Password);
                }

                if (cmbQues.Text.ToString() == "")
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Please select Security Question.");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SecurityQuestion", cmbQues.Text.ToString());
                }

                if (txtResponse.Text.Length == 0)
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Response can't be empty.");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Response", txtResponse.Text);
                }

                if (pwdPassword.Password != pwdcnfPassword.Password)
                {
                    if (pwdcnfPassword.Password.Length == 0)
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Confirm password can't be empty.");
                    }
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Confirm password must be same as password.");
                }

                if (invalid == 1)
                {
                    MessageBox.Show(sb.ToString());
                }

                try
                {
                    sqlCon.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You have Registered successfully.");
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    sqlCon.Close();
                }
            }
           
        }

        //Logic for navigating to Login Page

        private void BtnSwitchToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        /*Logic of window loaded for
        binding value to combobox*/

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbQues.Items.Add("");
            cmbQues.Items.Add("In which city were you born?");
            cmbQues.Items.Add("What is the name of your first school?");
            cmbQues.Items.Add("Which is your favorite movie?");
        }
    }
}