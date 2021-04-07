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
    /// Interaction logic for FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Window
    {
        CIMSEntities2 cims;
        public FinalPage()
        {
            cims = new CIMSEntities2();
            InitializeComponent();

            //Calling function to bind the data in combobox.

            BindManufacturer(cmbManufacturer);
            BindManufacturer(cmbManufacturersearch);
            BindCarType(cmbType);
            BindCarType(cmbTypesearch);
            BindTransmissionType(cmbTransmission);
        }

        //Logic for clearing all the fields.

        public void clear()
        {
            cmbType.Text = null;

            cmbManufacturer.Text = null;

            cmbManufacturersearch.Text = null;

            cmbTypesearch.Text = null;

            cmbTransmission.Text = null;

            txtEngine.Text = null;

            txtPrice.Text = null;

            txtBHP.Text = null;

            txtAirbagDetails.Text = null;

            txtSeat.Text = null;

            txtMileage.Text = null;

            txtBootspace.Text = null;
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

        /*Logic for adding new information
        to the CAR table*/

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                int invalid = 0;
                using (cims)
                {
                    CAR car = new CAR();
                    if (!(Regex.IsMatch(txtmodel.Text, @"^\w+\s*\w*$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Model cannot be blank and must be in proper format.");
                    }
                    else
                    {
                        car.Model = txtmodel.Text;
                    }

                    if (cmbManufacturer.SelectedValue != null)
                    {
                        car.ManufacturerId = Convert.ToInt32(cmbManufacturer.SelectedValue.ToString());
                        
                    }
                    else
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Please Select Manufacturer.");
                    }

                    if (cmbType.SelectedValue != null)
                    {
                        car.TypeId = Convert.ToInt32(cmbType.SelectedValue.ToString());
                        
                    }
                    else
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Please Select Car Type.");
                    }

                    if (!(Regex.IsMatch(txtEngine.Text, @"^[0-9].[0-9]L$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Engine should be in proper format(e.g. 3.5L).");
                    }
                    else
                    {
                        car.Engine = txtEngine.Text;
                    }

                    if (!(Regex.IsMatch(txtBHP.Text, @"^\d+$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "BHP cannot be blank and must be numeric.");
                    }
                    else
                    {
                        car.BHP = Convert.ToInt32(txtBHP.Text);
                    }

                    if (cmbTransmission.SelectedValue != null)
                    {
                        car.TransmissionId = Convert.ToInt32(cmbTransmission.SelectedValue.ToString());
                        
                    }
                    else
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Please Select Car Transmission.");
                    }

                    if (!(Regex.IsMatch(txtMileage.Text, @"^\d+$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Mileage cannot be blank and must be numeric.");
                    }
                    else
                    {
                        car.Mileage = Convert.ToInt32(txtMileage.Text);
                    }

                    if (!(Regex.IsMatch(txtSeat.Text, @"^\d+$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Seat cannot be blank and must be numeric.");
                    }
                    else
                    {
                        car.Seat = Convert.ToInt32(txtSeat.Text);
                    }

                    if (!(Regex.IsMatch(txtAirbagDetails.Text, @"^\w+$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Airbag details cannot be blank.");
                    }
                    else
                    {
                        car.AirBagDetails = txtAirbagDetails.Text;
                    }

                    if (!(Regex.IsMatch(txtBootspace.Text, @"^\d+\s*\w*$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Bootspace cannot be blank.");
                    }
                    else
                    {
                        car.BootSpace = txtBootspace.Text;
                    }

                    if (!(Regex.IsMatch(txtPrice.Text, @"^\d+$")))
                    {
                        invalid = 1;
                        sb.Append(Environment.NewLine + "Price cannot be blank and must be numeric.");
                    }
                    else
                    {
                        car.Price = Convert.ToInt64(txtPrice.Text);
                    }

                    if (invalid == 1)
                    {
                        MessageBox.Show(sb.ToString());
                    }
                    else
                    {
                        cims.CARs.Add(car);

                        cims.SaveChanges();

                        MessageBox.Show("1 Record Added");
                    }
                }

                FinalPage finPage = new FinalPage();
                this.Close();
                finPage.ShowDialog();
                try { this.Show(); }
                catch
                {
                }
            }
        
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /*Logic for searching
        on the basis of Model*/
        
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(Regex.IsMatch(txtmodel.Text, @"^\w+\s*\w*$")))
                {
                    MessageBox.Show("Please enter proper car model.");
                }
                else
                {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        /*Logic for updating
        the CAR table*/

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (CIMSEntities2 entityobj = new CIMSEntities2())
                {
                    string model = txtmodel.Text;

                    CAR carObj = entityobj.CARs.FirstOrDefault(i => i.Model == model);

                    carObj.Engine = txtEngine.Text;

                    carObj.BootSpace = txtBootspace.Text;

                    carObj.AirBagDetails = txtAirbagDetails.Text;

                    carObj.BHP = Convert.ToInt32(txtBHP.Text);

                    carObj.Mileage = Convert.ToInt32(txtMileage.Text);

                    carObj.Seat = Convert.ToInt32(txtSeat.Text);

                    carObj.Price = Convert.ToDecimal(txtPrice.Text);

                    carObj.ManufacturerId = Convert.ToInt32(cmbManufacturer.SelectedValue.ToString());

                    carObj.TypeId = Convert.ToInt32(cmbType.SelectedValue.ToString());

                    carObj.TransmissionId = Convert.ToInt32(cmbTransmission.SelectedValue.ToString());

                    entityobj.SaveChanges();

                    MessageBox.Show("1 Record updated");
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("All details should be filled before updating.");
            }

        }

        //Logic for deleting the information

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string configManager = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(configManager))
            {
                SqlCommand sqlCmd = new SqlCommand("delete from CAR where Model=@Model", sqlCon);
                bool correctcredentials = true;
                if (txtmodel.Text == "")
                {
                    MessageBox.Show("Please search using car model first before delete");
                    correctcredentials = false;
                }
                else if (!(Regex.IsMatch(txtmodel.Text, @"^\w+\s*\w*$")))
                {
                    MessageBox.Show("Car model is incorrect format.");
                    correctcredentials = false;
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue("@Model", txtmodel.Text);
                }

                try
                {
                    if (correctcredentials == true)
                    {
                        string sMessageBoxText = "Do you want to continue?";
                        string sCaption = "Delete confirmation";
                        bool delete = false;
                        MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                        MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                        MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                        switch (rsltMessageBox)
                        {
                            case MessageBoxResult.Yes:
                                {
                                    delete = true;
                                    break;
                                }

                            case MessageBoxResult.No:
                                {
                                    delete = false;
                                    break;
                                }
                        }

                        if (delete == true)
                        {
                            sqlCon.Open();

                            int res = sqlCmd.ExecuteNonQuery();

                            if (res == 1)
                            {
                                MessageBox.Show("Record deleted successfully");
                                clear();
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted or Record may not be present.");
                            }
                        }
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

        //Logic for navigating to home page.

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainPage = new MainWindow();
            mainPage.Show();
            this.Close();
        }
        
        //Logic for clearing the fields

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            FinalPage finPage = new FinalPage();
            this.Close();
            finPage.ShowDialog();
            try { this.Show(); }
            catch
            {

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
                            where manName == data2.Name && typeName == data3.Type
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

        /*Logic for navigating to the
        add new manufacturer page*/

        private void BtnAddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturer addManufacturer = new AddManufacturer();
            addManufacturer.Show();
            this.Close();
        }
    }
}