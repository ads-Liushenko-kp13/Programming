using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Success
{
    /// <summary>
    /// Interaction logic for LotWindow.xaml
    /// </summary>
    public partial class LotWindow : Window
    {
        bool isAdd = false;
        bool isEdit = false;
        public LotWindow()
        {
            InitializeComponent();
            ReadOnlyControls();
            UpdateAuctionTable();
            UpdateSalerManComboBox();
            /*InitializeComponent();
            
*/

        }

        private void UpdateSalerManComboBox()
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {


                SqlDataAdapter Data = new SqlDataAdapter("SELECT * FROM Participant", sqlConn);

                DataTable dT = new DataTable();
                /*DataGrid.ItemsSource = dT.DefaultView;*/

                Data.Fill(dT);
                SalerManComboBox.ItemsSource = dT.DefaultView;
                SalerManComboBox.DisplayMemberPath = "LastName";
                SalerManComboBox.SelectedValuePath = "Id";


            }

            sqlConn.Close();
        }

        private void ReadOnlyControls(bool isReadOnly = true)
        {
            Name.IsReadOnly = isReadOnly;
            SalesManID.IsReadOnly = isReadOnly;
            StartPice.IsReadOnly = isReadOnly;
            Desciption.IsReadOnly = isReadOnly;

            if (isReadOnly)
            {
                SaveButton.Background = Brushes.Gray;
                AddButton.Background = Brushes.Gray;
                EditButton.Background = Brushes.Gray;
            }
            else
            {
                SaveButton.Background = Brushes.LightBlue;
                AddButton.Background = Brushes.LightBlue;
                EditButton.Background = Brushes.LightBlue;
            }
        }

        private void ClearControls()
        {
            
            Desciption.Text = "";
            SalesManID.Text = "";
            Name.Text = "";
            StartPice.Text = "";
            //DatePicker.ClearValue(DependencyProperty.UnsetValue);
        }

        private void UpdateAuctionTable()
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {


                SqlDataAdapter Data = new SqlDataAdapter("SELECT * FROM Lot", sqlConn);
                DataTable dT = new DataTable();

                Data.Fill(dT);
                DataGrid.ItemsSource = dT.DefaultView;

            }

            sqlConn.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dw = DataGrid.SelectedItem as DataRowView;
            if (dw != null)
            {
                Name.Text = dw["Name"].ToString();
                StartPice.Text = dw["StartPrice"].ToString();
                Desciption.Text = dw["Description"].ToString();


            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd == true)
            {
                AddLot();
                isAdd = false;
            }
            else if (isEdit == true)
            {
                EditLot();
                isEdit = false;
            }
            ReadOnlyControls();
            UpdateAuctionTable();

            /**/
        }

        private void EditLot()
        {
            
            String name = Name.Text;
            String description = Desciption.Text;
            String startPrice = StartPice.Text;
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            MessageBox.Show(SalerManComboBox.SelectedItem.ToString());
            DataRowView view = SalerManComboBox.SelectedItem as DataRowView;
            string salesManID = view["Id"].ToString();

            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"UPDATE Lot SET Name = '{name}',Description = '{description}',StartPrice = '{startPrice}',SalesManID = '{salesManID}' ";

                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConn.Close();
        }

        private void AddLot()
        {
            String name = Name.Text;
            String description = Desciption.Text;
            String startPrice = StartPice.Text;
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

           /* MessageBox.Show(SalerManComboBox.SelectedItem.ToString());*/
            DataRowView view = SalerManComboBox.SelectedItem as DataRowView;
            string salesManID = view["Id"].ToString();

            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"INSERT INTO Lot (Name,Description,StartPrice,SalesManID) values('{name}', '{description}', '{startPrice}','{salesManID}') ";
                    MessageBox.Show(strQ);
                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConn.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            isAdd = true;
            ClearControls();
            ReadOnlyControls(false);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            isEdit = true;
            ReadOnlyControls(false);
        }
    }
}
    

