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

            Calc2 mw;
            mw = new Calc2();
            Hide();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TicTacToe2 mw;
            mw = new TicTacToe2();
            Hide();
            
        }

        private void Std_Click(object sender, RoutedEventArgs e)
        {
            Students2 mw;
            mw = new Students2();
            Hide();
        }

        private void AUT_Click(object sender, RoutedEventArgs e)
        {
            Author2 mw;
            mw = new Author2();
            Hide();
        }
    }
}
