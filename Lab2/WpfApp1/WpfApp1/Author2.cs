using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class Author2
    {
        Window WN;
        Grid LayoutRoot;

        public Author2()
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
            TextBox Name = new TextBox()
            {
                Text = "ПІБ: Люшенко Людмила Олексіївна \nНазва роботи: Лабораторна робота з ОП\nРік створення: 2022",
                //Width = 400,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(100, 100, 0, 0),
                //Height = 70,
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Segoe UI"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.Transparent
            };
            LayoutRoot.Children.Add(Exit);
            LayoutRoot.Children.Add(Name);
            WN.Content = LayoutRoot;
            WN.Show();

        }
    }
}
