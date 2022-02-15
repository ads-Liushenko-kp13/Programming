using Microsoft.Win32;
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
using System.Data;

namespace WpfApp1
{
    public partial class Calc : Window
    {
        public Calc()
        {
            InitializeComponent();

            foreach (UIElement el in BaseGrid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
            {
                Summary.Text = " ";
            }
            else if (str == "=")
            {
                string result = new DataTable().Compute(Summary.Text,null).ToString();
                Summary.Text = result;
            }
            else if (str == "Exit")
            {
                MainWindow mw;
                Hide();

                mw = new MainWindow();
               
                mw.Show();
            }
            else
            {
                Summary.Text += str;
            }
        }
    }
}
