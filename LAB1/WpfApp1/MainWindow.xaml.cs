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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TTT.Click += Button_Click_2;
            TTT.Click -= Button_Click;
        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {

            Calc mw;
            Hide();
            mw = new Calc();
            
            mw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TicTacToe TicTacToe;
            TicTacToe = new TicTacToe();
            Hide();
            TicTacToe.Show();
        }

        private void Std_Click(object sender, RoutedEventArgs e)
        {
            Students mw;
            mw = new Students();
            Hide();
            mw.Show();
        }

        private void AUT_Click(object sender, RoutedEventArgs e)
        {
            Author Author;
            Author = new Author();
            Hide();
            Author.Show();
        }
    }
}
