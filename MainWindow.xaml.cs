using Course.Services;
using System.ComponentModel;
using System;
using System.Windows;
using System.Windows.Controls;
using Course.Models;

namespace Course
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

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Здесь вы должны выполнить проверку логина и пароля на соответствие вашим данным.
            if (IsUserValid(username, password))
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
            }
        }

        private bool IsUserValid(string username, string password)
        {
            // Здесь выполните проверку логина и пароля на соответствие вашим данным,
            // например, сравните с данными в базе данных или другом источнике.
            // В этом примере, просто сравниваем с фиксированными данными.
            return username == "admin" && password == "pass";
        }

        private void Button_registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
