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
    /// Interaction logic for AuctionWindow.xaml
    /// </summary>
    public partial class AuctionWindow : Window
    {
        bool isAdd = false;
        bool isEdit = false;
        public AuctionWindow()
        {
            InitializeComponent();
            ReadOnlyControls();
            UpdateAuctionTable();
        }

        private void UpdateAuctionTable()
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {


                SqlDataAdapter Data = new SqlDataAdapter("SELECT * FROM Auction", sqlConn);
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
                IDLabel.Content = dw["ID"].ToString();
                Name.Text = dw["Name"].ToString();
                Description.Text = dw["Description"].ToString();
               
                DatePicker.Text = dw["Date"].ToString();
                BoxTime.Text = dw["Time"].ToString();
               
                Adress.Text = dw["Address"].ToString();
            }

            if (isAdd)
            {
                isAdd = false;
                ReadOnlyControls();
            }
            if (isEdit)
            {
                ReadOnlyControls();
                isEdit = false;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd == true)
            {
                addAuction();
                isAdd = false;
            }
            else if (isEdit == true)
            {
                editAuction();
                isEdit = false;
            }
            ReadOnlyControls();
            UpdateAuctionTable();
        }

        private void editAuction()
        {
            string id = IDLabel.Content.ToString();
            String description = Description.Text;
            String adress = Adress.Text;
            String name = Name.Text;
            String time = BoxTime.Text;
            DateTime date = DatePicker.DisplayDate;
            string dateString = date.ToString("MM-dd-yyyy");
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"UPDATE Auction SET Name = '{name}', Description = '{description}',Date = '{dateString}',Time = '{time}',Address = '{adress}'"+
                        $"WHERE ID = '{id}' ";
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

        private void addAuction()
        {
            String description = Description.Text;
            String adress = Adress.Text;
            String name = Name.Text;
            String time = BoxTime.Text;
            DateTime date = DatePicker.DisplayDate;
            string dateString = date.ToString("MM-dd-yyyy");
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"INSERT INTO Auction (Name, Description,Date,Time,Address) values('{name}', '{description}', '{dateString}','{time}','{adress}') ";
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

        private void ClearControls()
        {
            IDLabel.Content = "";
            Description.Text = "";
            Adress.Text = "";
            Name.Text = "";
            BoxTime.Text = "";
            //DatePicker.ClearValue(DependencyProperty.UnsetValue);
        }

        private void ReadOnlyControls(bool isReadOnly = true)
        {
            
            Name.IsReadOnly = isReadOnly;
            Description.IsReadOnly = isReadOnly;
            Adress.IsReadOnly = isReadOnly;
            DatePicker.IsEnabled =!isReadOnly;
            BoxTime.IsReadOnly = isReadOnly;

            if (isReadOnly)
            {
                Save.Background = Brushes.Gray;
                AddButton.Background = Brushes.Gray;
                EditButton.Background = Brushes.Gray;
            }
            else
            {
                Save.Background = Brushes.LightBlue;
                AddButton.Background = Brushes.LightBlue;
                EditButton.Background = Brushes.LightBlue;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            isEdit = true;
            ReadOnlyControls(false);
        }
    }
}
