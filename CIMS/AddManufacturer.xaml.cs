using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace CIMS
{
    /// <summary>
    /// Interaction logic for Manufacturer.xaml
    /// </summary>
    public partial class AddManufacturer : Window
    {
        public AddManufacturer()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            txtName.Text = "";
            txtcNumber.Text = "";
            txtregoffice.Text = "";
        }

        private void BtnCarDetails_Click(object sender, RoutedEventArgs e)
        {
            FinalPage finalPage = new FinalPage();
            finalPage.Show();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(configManager))
            {
                SqlCommand sqcmd = new SqlCommand("INSERT INTO MANUFACTURER (Name,ContactPersonNumber,RegisteredOffice) VALUES (@Name,@ContactPersonNumber,@RegisteredOffice)", con);
                
                StringBuilder sb = new StringBuilder();
                int invalid = 0;

                if (!(Regex.IsMatch(txtName.Text, "^\\w+\\s*\\w+$")))
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "UserName cannot be blank.");
                }
                else
                {
                    sqcmd.Parameters.AddWithValue("@Name", txtName.Text);
                }

                if (!(Regex.IsMatch(txtcNumber.Text, "^[1-9]{1}[0-9]{9}$")))
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Contact Number must be unique.\nContact Number must be of numeric and of size 10.");
                }
                else
                {
                    sqcmd.Parameters.AddWithValue("@ContactPersonNumber", txtcNumber.Text);
                }

                if (!(Regex.IsMatch(txtregoffice.Text, "^\\w+\\s*\\w+$")))
                {
                    invalid = 1;
                    sb.Append(Environment.NewLine + "Registered Office cannot be blank.");
                }
                else
                {
                    sqcmd.Parameters.AddWithValue("@RegisteredOffice", txtregoffice.Text);
                }

                if (invalid == 1)
                {
                    MessageBox.Show(sb.ToString());
                }
                try
                {
                    con.Open();
                    int res = sqcmd.ExecuteNonQuery();
                    if (res == 1)
                    {
                        MessageBox.Show("Record Inserted Successfully");
                        Reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(configManager))
            {
                SqlCommand s1 = new SqlCommand("SELECT * FROM MANUFACTURER", con);
                
                SqlDataAdapter da = new SqlDataAdapter(s1);
                DataTable dt = new DataTable("MANUFACTURER");
                da.Fill(dt);
                dgshow.ItemsSource = dt.DefaultView;
            }
        }
    }
}