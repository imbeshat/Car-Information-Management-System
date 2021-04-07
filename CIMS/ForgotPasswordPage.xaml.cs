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
    /// Interaction logic for ForgotPasswordPage.xaml
    /// </summary>
    public partial class ForgotPasswordPage : Window
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        /*Logic for window loaded
        for adding item to combobox*/

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbQuest.Items.Add("");
            cmbQuest.Items.Add("In which city were you born?");
            cmbQuest.Items.Add("What is the name of your first school?");
            cmbQuest.Items.Add("Which is your favorite movie?");
        }

        /*Logic for show password
        if administrator forgets the password*/

        private void BtnShowpwd_Click(object sender, RoutedEventArgs e)
        {
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                SqlCommand sqcmd = new SqlCommand("SELECT * FROM ADMIN WHERE UserName=@UserName AND SecurityQuestion=@SecurityQuestion AND Response=@Response", sqlCon);
                StringBuilder sb = new StringBuilder();
                int invalid = 0;
                if (!(Regex.IsMatch(txtUname.Text, "\\w{5,}")))
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "UserName cannot be blank and size atleast be 5.");
                }
                else
                {
                    sqcmd.Parameters.AddWithValue("@UserName", txtUname.Text);
                }

                if (cmbQuest.Text.ToString() == "")
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Please select Security Question.");
                }
                else
                {
                    sqcmd.Parameters.AddWithValue("@SecurityQuestion", cmbQuest.SelectedValue);
                }

                if (txtResponse.Text.ToString() == "")
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Response can't be empty.");
                }
                else
                {
                    sqcmd.Parameters.AddWithValue("@Response", txtResponse.Text);
                }

                if (invalid == 1)
                {
                    MessageBox.Show(sb.ToString());
                }

                try
                {
                    sqlCon.Open();
                    SqlDataReader dr = sqcmd.ExecuteReader();
                    int login = 0;
                    while (dr.Read())
                    {
                        login = 1;
                        MessageBox.Show("Your Password is " + dr[2]);
                    }
                    if (login == 0)
                    {
                        MessageBox.Show("Incorrect credentials.");
                    }
                }
                catch
                {

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
    }
}
