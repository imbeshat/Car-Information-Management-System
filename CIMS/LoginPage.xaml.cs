using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CIMS
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /*Logic for loggimg into
        Admin Section*/

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                String query = "select count(1) from Admin where UserName=@UserName AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                StringBuilder sb = new StringBuilder();
                
                sqlCmd.Parameters.AddWithValue("@UserName", txtName.Text);
                
                sqlCmd.Parameters.AddWithValue("@Password", pwdPassword.Password);
                
                try
                {
                    sqlCon.Open();
                    sqlCmd.CommandType = CommandType.Text;
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        FinalPage finalPage = new FinalPage();
                        finalPage.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password incorrect.");
                    }
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

        //Logic for navigating to Register Page.

        private void Btnregtd_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }

        //Logic for navigating to Main Page

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainPage = new MainWindow();
            mainPage.Show();
            this.Close();
        }

        //Logic for navigating to Forgot Password Page.

        private void Btnfgpwd_Click(object sender, RoutedEventArgs e)
        {
            ForgotPasswordPage forgotPasswordPage = new ForgotPasswordPage();
            forgotPasswordPage.Show();
            this.Close();
        }
    }
}
