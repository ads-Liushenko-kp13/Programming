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

namespace SuccessPrac3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            Admin administration = new Admin();
            Hide();
            administration.ShowDialog();
        }

        private void UserMode_Click(object sender, RoutedEventArgs e)
        {
            UserWindow window = new UserWindow();
            window.Show();
        }

        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void UserMode_Copy_Click(object sender, RoutedEventArgs e)
        {
            Admin window = new Admin();
            window.Show();
        }
    }
}
