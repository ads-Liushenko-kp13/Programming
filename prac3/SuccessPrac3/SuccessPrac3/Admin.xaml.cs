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

namespace SuccessPrac3
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        int index = -1;
        bool isAuthorization = false;
       DataTable dT;

        public Admin()
        {
            InitializeComponent();
            UpdateDataTable();
        }
        void UpdateDataTable()
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter Data = new SqlDataAdapter("SELECT Name, Surname, Login, Status,"+
                " Restriction FROM MainTable", sqlConn);


                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
                /*LenTable = dT.Rows.Count;*/

            }
            sqlConn.Close();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < dT.Rows.Count - 1)
            {
                index++;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
        
        }

        private void UpdatePasswd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            String strQ;
            String RealPass = RealAdminPasswd.Password.ToString();
            String NewPass = NewAdminPasswd.Password.ToString();
            String NewPass2 = NewAdminPasswd2.Password.ToString();
            if ((RealPass == AdminPasswd.Password.ToString()) && (NewPass != "")
            && (NewPass == NewPass2))

            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = $"UPDATE MainTable SET Password =  '{NewPass}' " + 
                    $" WHERE Login = 'ADMIN' ";
                    MessageBox.Show(strQ);
                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
            }
            sqlConn.Close();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            String strQ;
            String UserLogin = AddingUserLogin.Text;
            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO MainTable (Name, Surname, Login, Status,"+
                $" Restriction) values('', '', '" + UserLogin + "', 1, 0); ";

                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
                UpdateDataTable();
            }
            catch
            {
                MessageBox.Show("Користувача не додано! Можливо такий в базі вже є!");
            }
            sqlConn.Close();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string passwd = AdminPasswd.Password;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT Password FROM MainTable WHERE Login= 'ADMIN' " ;
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                if (dT.Rows.Count == 0)
                    MessageBox.Show(":(");
                else
                {
                    string originalPassword = dT.Rows[0][0].ToString();
                    if (passwd != originalPassword)
                    {
                        MessageBox.Show(":(");
                        isAuthorization = false;
                    }
                    else
                    {
                        isAuthorization = true;
                       
                       

                    }
                }
            }
            sqlConn.Close();
        }
    }
}
