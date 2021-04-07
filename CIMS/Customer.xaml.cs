using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace CIMS
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();

            //Calling function to bind the data in combobox.

            BindManufacturer(cmbManufacturer);
            BindManufacturer(cmbManufacturersearch);
            BindCarType(cmbType);
            BindCarType(cmbTypesearch);
            BindTransmissionType(cmbTransmission);
        }


        //Logic for navigating to home page.

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        //Logic for window loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CIMSEntities2 entityobj = new CIMSEntities2();
            var result = from mname in entityobj.Manufacturers
                         select mname.Name;
        }

        /*BindManufacturer is a user defined function.
        It is used for binding the data in the combobox from Manufacturer table*/

        public void BindManufacturer(ComboBox comboBoxName)
        {
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                SqlDataAdapter da = new SqlDataAdapter("select ID, Name from Manufacturer", sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "Manufacturer");
                comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
                comboBoxName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
            }

        }

        /*BindCarType is a user defined function.
        It is used for binding the data in the combobox from CarType table*/

        public void BindCarType(ComboBox comboBoxName)
        {
            
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                SqlDataAdapter da = new SqlDataAdapter("select ID, Type from CarType", sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "CarType");
                comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["Type"].ToString();
                comboBoxName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
            }

        }

        /*BindTransmissionType is a user defined function.
        It is used for binding the data in the combobox from CarTransmissionType table*/

        public void BindTransmissionType(ComboBox comboBoxName)
        {
            
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                SqlDataAdapter da = new SqlDataAdapter("select ID, Name from CarTransmissionType", sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "CarTransmissionType");
                comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
                comboBoxName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
            }

        }

        //Logic for searching on the basis of Model.

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(Regex.IsMatch(txtmodel.Text, @"^\w+\s*\w*$")))
                {
                    MessageBox.Show("Please Enter Car Model Properly.");
                }
                else {
                    string modName = txtmodel.Text;
                    using (CIMSEntities2 entityobj = new CIMSEntities2())
                    {
                        CAR carObj = entityobj.CARs.FirstOrDefault(i => i.Model == modName);

                        txtEngine.Text = carObj.Engine;

                        txtPrice.Text = carObj.Price.ToString();

                        txtBHP.Text = carObj.BHP.ToString();

                        cmbManufacturer.SelectedValue = carObj.ManufacturerId;

                        txtAirbagDetails.Text = carObj.AirBagDetails;

                        txtSeat.Text = carObj.Seat.ToString();

                        txtMileage.Text = carObj.Mileage.ToString();

                        txtBootspace.Text = carObj.BootSpace.ToString();

                        cmbType.SelectedValue = carObj.TypeId;

                        cmbTransmission.SelectedValue = carObj.TransmissionId;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Model not Present");
            }
        }

        /*Logic for searching on basis
        of Manufacturer Type and Cartype*/

        private void btnManufacturer_Click(object sender, RoutedEventArgs e)
        {
            CIMSEntities2 entityobj = new CIMSEntities2();

            string manName = cmbManufacturersearch.Text.ToString();
            string typeName = cmbTypesearch.Text.ToString();

            var modelname = from data in entityobj.CARs
                            join data2 in entityobj.Manufacturers on data.ManufacturerId equals data2.ID
                            join data3 in entityobj.CarTypes on data.TypeId equals data3.ID
                            where manName == data2.Name && typeName==data3.Type
                            select new
                            {
                                data.Model,
                                data.Engine,
                                data.Seat,
                                data.Mileage,
                                data.BHP,
                                data.BootSpace,
                                data.AirBagDetails,
                                data.Price
                            };

            dgManType.ItemsSource = modelname.ToList();
        }

        //Logic for clearing all the fields.

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtmodel.Text = null;

            cmbType.Text = null;

            cmbManufacturer.Text = null;

            cmbTransmission.Text = null;

            cmbManufacturersearch.Text = null;

            cmbTypesearch.Text = null;

            txtEngine.Text = null;

            txtPrice.Text = null;

            txtBHP.Text = null;

            txtAirbagDetails.Text = null;

            txtSeat.Text = null;

            txtMileage.Text = null;

            txtBootspace.Text = null;
                        
        }
    }
}
 