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
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        static List<Student> DataBase = new List<Student>();
        public Students()
        {
            InitializeComponent();
            DeleteStudent.Click += DeleteStudent_Click;
            AddStudent.Click += AddStudent_Click;
            CreateData();
            Exit.Click += Exit_Click;
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            Hide();

            mw = new MainWindow();

            mw.Show();
        
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


            Student St = new Student(int.Parse(ID.Text), FName.Text, Surname.Text, Group.Text);
            StreamWriter DataBaseWrite = new StreamWriter(@"C:\Users\lyusi\Documents\люда\wpf\WpfApp1\DataBase.txt");
            foreach (var a in lines)
                DataBaseWrite.WriteLine(a);
            DataBaseWrite.WriteLine(St.PrintStudent());
            DataBaseWrite.Close();
        }


        private void DeleteStudent_Click (object sender, RoutedEventArgs e)
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
