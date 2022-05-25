using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class TicTacToe2
    {
        Window WN;
        Grid LayoutRoot;

        public TicTacToe2()
        {
            Create();
        }
        void Create()
        {

            void ToMainWindow_Click(object sender, RoutedEventArgs e)
            {
                WN.Hide();
                MainWindow MW = new MainWindow();
                MW.Show();
            }
            Button Exit = new Button
            {
                Content = "Exit",
                Width = 70,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, 0, 0, 0),
                Height = 70,
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Segoe UI"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.LightPink
            };
            Exit.Click += ToMainWindow_Click;
            WN = new Window
            {
                Width = 500,
                Height = 600,
                ResizeMode = ResizeMode.CanResize,
                Title = "Author",
                Background = Brushes.LightSkyBlue
            };
            LayoutRoot = new Grid
            {
                Width = 500,
                Height = 600,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                ShowGridLines = true
            };
            ComboBox[,] TTT = new ComboBox[5, 5];
            for (int i = 0; i <= 4; i++)
            {
                for (int k = 0; k <= 4; k++)
                {
                    TTT[i, k] = new ComboBox
                    { Height = 55,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Width = 70,
                        Margin = new Thickness(70 + 72 * i, 219 + 60 * k, 0, 0),
                        FontSize = 20,
                    };
                    TTT[i,k].Items.Add("X");
                    TTT[i, k].Items.Add("0");
                    LayoutRoot.Children.Add(TTT[i,k]);
                }
            }
            LayoutRoot.Children.Add(Exit);
            WN.Content = LayoutRoot;
            WN.Show();

        }
    }
}
