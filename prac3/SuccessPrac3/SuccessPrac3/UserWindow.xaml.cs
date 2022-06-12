using Microsoft.Azure.Amqp.Framing;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        int count = -1;
        DataTable dT;
        private void AutorBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string passwd = passwdField.Password;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ = $"SELECT * FROM MainTable WHERE Login='{login}' AND " +
                      $"Password = '{passwd}' ";
                
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                if (dT.Rows.Count == 0)
                    MessageBox.Show(":(");
                else
                {/*
                    bool Status = Convert.ToBoolean(dT.Rows[0][4]);
                    if (!Status)
                        MessageBox.Show("Користувач заблокований Адміністратором системи!");

                    else
                    {
                        if ((dT.Rows[0][2].ToString() == login) &&

                        (dT.Rows[0][3].ToString() == passwd))

                        {
                            NewNameField.Text = dT.Rows[0][0].ToString();
                            NewSurnameField.Text = dT.Rows[0][1].ToString();
                            NewPasswdField.Password = "";
                            NewPasswdField2.Password = "";
                            NewNameField.IsEnabled = true;
                            NewSurnameField.IsEnabled = true;
                            NewPasswdField.IsEnabled = true;
                            NewPasswdField2.IsEnabled = true;
                            bool UpdateDataBtn = true;

                        }
                        else
                        {
                            count++;

                            String s = "Невірно введений пароль! " +

                            "Помилкове введення No" + count.ToString();

                            MessageBox.Show(s);
                            if (count == 3)
                                System.Windows.Application.Current.Shutdown();
                        }*/

                   // }
                }
            }
            sqlConn.Close();
        }
        public UserWindow()
        {
            InitializeComponent();
        }
        Boolean RestrictionFunc(String Pass)
        {
            Byte Count1, Count2, Count3;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) &&

                (Convert.ToInt32(Pass[i]) <= 65 + 25))

                    Count1++;
                if ((Convert.ToInt32(Pass[i]) >= 97) &&

                (Convert.ToInt32(Pass[i]) <= 97 + 25))

                    Count2++;
                if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') ||

                (Pass[i] == '/'))

                    Count3++;
            }
            return (Count1 * Count2 * Count3 != 0);
        }
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            String nameReg = NameField.Text;
            String surnameReg = SurnameField.Text;
            String loginReg = loginRegField.Text;
            String passwdReg = passwdRegField.Password;
            String passwdReg2 = passwdRegField2.Password;
            String strQ;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    if ((passwdReg == passwdReg2) && /*(loginReg != "") &&*/

                    (passwdReg != "")/* && RestrictionFunc(loginReg)*/)

                    {
                        strQ = "INSERT INTO MainTable ";
                        strQ += "VALUES ('" + nameReg + "', '" + surnameReg +
                        "', '" + loginReg + "', '" + passwdReg + "', 1, 0 )";
                       /* MessageBox.Show(strQ);*/
                        SqlCommand Com = new SqlCommand(strQ, sqlConn);
                        Com.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Обліковий запис не створено. Спробуйте ще раз!");

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            sqlConn.Close();
        }

        private void UpdateDataBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();
            String newname = NewNameField.Text;
            String newsurname = NewSurnameField.Text;
            String newpasswd = NewPasswdField.Password;
            String newpasswd2 = NewPasswdField2.Password;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ;
                if ((newpasswd == newpasswd2) && (newpasswd != ""))
                {
                    /*Boolean flag = RestrictionFunc(newpasswd);*/
                    bool flag = true;
                    if (Convert.ToBoolean(dT.Rows[0][5]) == true)
                    {
                        if (flag == true)
                        {
                            strQ = "UPDATE MainTable SET Name='" + newname + "', ";
                            strQ += " Surname='" + newsurname + "', ";
                            strQ += " Password='" + newpasswd + "' ";
                            strQ += " WHERE Login='" + login + "';";
                            MessageBox.Show(strQ);
                            SqlCommand Com = new SqlCommand(strQ, sqlConn);
                            Com.ExecuteNonQuery();
                        }
                        else
                            MessageBox.Show("У паролі немає літер верхнього " +
                            "та нижнього регістрів, а також арифметичних операцій!" +
                            " Спробуйте знову!");

}
                    else
                    {
                        strQ = "UPDATE MainTable SET Name='" + newname + "', ";
                        strQ += "Surname='" + newsurname + "', ";
                        strQ += "Password='" + newpasswd + "' ";
                        strQ += "WHERE Login='" + login + "';";
                        SqlCommand Com = new SqlCommand(strQ, sqlConn);
                        Com.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Введено пустий пароль або новий пароль " +
                        "повторно введено некоректно!");

                }
            }
        }
    }
}

