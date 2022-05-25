using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace WpfApp1
{

    class Students2
    {
        Window WN;
        Grid LayoutRoot;
        TextBox ID,Data,Surname,Name,Group;
        static List<Student> DataBase = new List<Student>();


        public Students2()
        {
            Create(); CreateData();
        }
        void Create ()
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
                VerticalAlignment = VerticalAlignment.Top
            };
            Exit.Click += ToMainWindow_Click;


            Button AddStudent = new Button
            {
                Content = "AddStudent",
                Width = 70,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(354, 439, 0, 0),
                Height = 70,
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Segoe UI"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            AddStudent.Click += AddStudent_Click;
            

            Button DeleteStudent = new Button
            {
                Content = "DeleteStudent",
                Width = 70,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(354, 326, 0, 0),
                Height = 70,
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Segoe UI"),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            
            DeleteStudent.Click += DeleteStudent_Click;

            WN = new Window
            {
                Width = 700,
                Height = 1000,
                ResizeMode = ResizeMode.CanResize,
                Title = " Students",
                Background = Brushes.LightSkyBlue
            };
            LayoutRoot = new Grid
            {
                Width = 700,
                Height = 1000,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                ShowGridLines = true
            };
            LayoutRoot.Children.Add(Exit);
            LayoutRoot.Children.Add(AddStudent);
            LayoutRoot.Children.Add(DeleteStudent);
            WN.Content = LayoutRoot;
            WN.Show();
          
            Data = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 161,
                Margin = new Thickness(46,114,0,0),
                Text = "Data",
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 396,
            };
            LayoutRoot.Children.Add(Data);

            ID = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 39,
                Margin = new Thickness(36, 332, 0, 0),
                Text = "ID",
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 250,
            };
            LayoutRoot.Children.Add(ID);

            Name = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 39,
                Margin = new Thickness(36, 376, 0, 0),
                Text = "Name",
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 250,
            };
            LayoutRoot.Children.Add(Name);

            Surname = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 39,
                Margin = new Thickness(36, 420, 0, 0),
                Text = "Surname",
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 250,
            };
            LayoutRoot.Children.Add(Surname);

            Group = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 39,
                Margin = new Thickness(36, 466, 0, 0),
                Text = "Group",
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 250,
            };
            LayoutRoot.Children.Add(Group);


        }
        public class Student
        {
            private int ID;
            private string FirstName;
            private string SecondName;
            private string Group;

            public Student(int ID, string FirstName, string SecondName, string Group)
            {
                this.ID = ID;
                this.FirstName = FirstName;
                this.SecondName = SecondName;
                this.Group = Group;
            }
            public int getID() => ID;

            public string PrintStudent()
            {
                return $"{ID} {SecondName} {FirstName} {Group}";
            }
        }
        public void CreateData()
        {
            Data.Text = "";
            System.IO.StreamReader DataBaseRead;

            DataBaseRead = new StreamReader(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt");
            while (!DataBaseRead.EndOfStream)
            {
                string[] Line = DataBaseRead.ReadLine().Split(' ');
                DataBase.Add(new Student(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }
            DataBaseRead.Close();
            if (DataBase.Count == 0)
                Data.Text = "NoElements";
            else
            {
                foreach (var s in DataBase)
                {
                    Data.Text += s.PrintStudent() + "\n";
                }
                DataBase.Clear();
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            StreamReader DataBaseRead;
            DataBaseRead = new StreamReader(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt");
            List<string> lines = new List<string>();
            while (!DataBaseRead.EndOfStream)
            {
                lines.Add(DataBaseRead.ReadLine());
            }
            DataBaseRead.Close();


            Student St = new Student(int.Parse(ID.Text), Name.Text, Surname.Text, Group.Text);
            StreamWriter DataBaseWrite = new StreamWriter(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt");
            foreach (var a in lines)
                DataBaseWrite.WriteLine(a);
            DataBaseWrite.WriteLine(St.PrintStudent());
            DataBaseWrite.Close();
        }


        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {


            StreamReader DataBaseRead = new StreamReader(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt");

            List<Student> DataBase = new List<Student>();
            while (!DataBaseRead.EndOfStream)
            {
                string[] Line = DataBaseRead.ReadLine().Split(' ');
                DataBase.Add(new Student(int.Parse(Line[0]), Line[1], Line[2], Line[3]));
            }

            DataBaseRead.Close();
            FileStream file = new FileStream(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt", FileMode.Create, FileAccess.Write);
            file.SetLength(0);
            file.Close();

            StreamWriter DataBaseWrite = new StreamWriter(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt");
            DataBase.Remove(DataBase.Find(a => a.getID() == long.Parse(ID.Text)));
            foreach (var s in DataBase)
                DataBaseWrite.WriteLine(s.PrintStudent());
            DataBaseWrite.Close();
        }
    }
}
