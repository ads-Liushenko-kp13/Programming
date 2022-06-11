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
    /// Interaction logic for ParticipantWindow.xaml
    /// </summary>
    public partial class ParticipantWindow : Window
    {
        bool isAdd = false;
        bool isEdit = false;
        public ParticipantWindow()
        {

            InitializeComponent();
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            ReadOnlyControls();
            UpdateAuctionTable();

/*
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {


                SqlDataAdapter Data = new SqlDataAdapter("SELECT * FROM Participant", sqlConn);
                DataTable dT = new DataTable();

                Data.Fill(dT);
                DataGrid.ItemsSource = dT.DefaultView;

            }

            sqlConn.Close();*/


        }

        private void UpdateAuctionTable()
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {


                SqlDataAdapter Data = new SqlDataAdapter("SELECT * FROM Participant", sqlConn);
                DataTable dT = new DataTable();

                Data.Fill(dT);
                DataGrid.ItemsSource = dT.DefaultView;

            }

            sqlConn.Close();
        }

        private void ReadOnlyControls(bool isReadOnly = true)
        {
            FirstName.IsReadOnly = isReadOnly;
            LastName.IsReadOnly = isReadOnly;
            MiddleName.IsReadOnly = isReadOnly;
            Adress.IsReadOnly = isReadOnly;
            Adress.IsReadOnly = isReadOnly;
            Phone.IsReadOnly = isReadOnly;
            DOBDatePicker.IsEnabled = !isReadOnly;
            EMail.IsReadOnly = isReadOnly;

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
            IDLabel.Content = "";
            FirstName.Text = "";
            Adress.Text = "";
            MiddleName.Text = "";
            EMail.Text = "";
            LastName.Text = "";
            Phone.Text = "";

            //DatePicker.ClearValue(DependencyProperty.UnsetValue);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd == true)
            {
                AddParticipant();
                isAdd = false;
            }
            else if (isEdit == true)
            {
                EditParticipant();
                isEdit = false;
            }
            ReadOnlyControls();
            UpdateAuctionTable();
/*
            String email = EMail.Text;
            String phone  = Phone.Text;
            String adress = Adress.Text;
            String firstName = FirstName.Text;
            String middleName = MiddleName.Text;
            String lastName = LastName.Text;
            DateTime DOB = DOBDatePicker.DisplayDate;
            string DOBString = DOB.ToString("MM-dd-yyyy");
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"INSERT INTO Participant (FirstName, MiddleName, LastName,DOB,EMail,Phone,Address) values('{firstName}', '{middleName}', '{lastName}','{DOBString}','{email}','{phone}','{adress}') ";
                   
                   SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            sqlConn.Close();*/
        }

        private void AddParticipant()
        {
            String email = EMail.Text;
            String phone = Phone.Text;
            String adress = Adress.Text;
            String firstName = FirstName.Text;
            String middleName = MiddleName.Text;
            String lastName = LastName.Text;
            DateTime DOB = DOBDatePicker.DisplayDate;
            string DOBString = DOB.ToString("MM-dd-yyyy");
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();


            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"INSERT INTO Participant (FirstName, MiddleName, LastName,DOB,EMail,Phone,Address) values('{firstName}', '{middleName}', '{lastName}','{DOBString}','{email}','{phone}','{adress}') ";

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

        private void EditParticipant()
        {
            string id = IDLabel.Content.ToString();
            String email = EMail.Text;
            String phone = Phone.Text;
            String adress = Adress.Text;
            String firstName = FirstName.Text;
            String middleName = MiddleName.Text;
            String lastName = LastName.Text;
            DateTime DOB = DOBDatePicker.DisplayDate;
            string DOBString = DOB.ToString("MM-dd-yyyy");
            String strQ;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();


            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"UPDATE Participant SET FirstName = '{firstName}', MiddleName = '{middleName}', LastName = '{lastName}', "+
                        $"DOB = '{DOBString}',EMail = '{email}',Phone = '{phone}',Address = '{adress}' "+
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dw = DataGrid.SelectedItem as DataRowView;
            if (dw != null)
            {
                IDLabel.Content = dw["ID"].ToString();
                FirstName.Text = dw["FirstName"].ToString();
                MiddleName.Text = dw["MiddleName"].ToString();
                LastName.Text = dw["LastName"].ToString();
                DOBDatePicker.Text = dw["DOB"].ToString();
                EMail.Text = dw["EMail"].ToString();
                Phone.Text = dw["Phone"].ToString();
                Adress.Text = dw["Address"].ToString();
            }


        }

        private void YesPoint_Checked(object sender, RoutedEventArgs e)
        {

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
