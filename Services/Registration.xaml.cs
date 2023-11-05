using Course.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Course.Services
{
    public partial class Registration : Window
    {
        ApplicationContext db;

        public Registration()
        {
            InitializeComponent();
            db = new ApplicationContext();


        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Данные введены не правильно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }

            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Данные введены не правильно!";
                passBox.Background = Brushes.DarkRed;
            }

            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Данные введены не правильно!";
                passBox_2.Background = Brushes.DarkRed;
            }

            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Данные введены не правильно!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Все хорошо");

                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void textBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
