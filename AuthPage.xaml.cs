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

namespace _2_exam
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {

            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            var user = MainWindow.User.FirstOrDefault(u => u.Login == login);

            if (user == null)
            {
                ErrorTextBlock.Text = "Пользователь не найден";
                return;
            }

            if (user.IsBlocked)
            {
                ErrorTextBlock.Text = "Вы заблокированы. Обратитесь к администратору.";
                return;
            }

            if (user.Password == password)
            {

                user.FailedAttempts = 0;

                if (user.IsAdmin)
                    NavigationService.Navigate(new AdminPage());
                else
                    NavigationService.Navigate(new UserPage());
            }
            else
            {
                user.FailedAttempts++;
                if (user.FailedAttempts >= 3)
                {
                    user.IsBlocked = true;
                    ErrorTextBlock.Text = "Аккаунт заблокирован за 3 неверных ввода пароля.";
                }
                else
                {
                    ErrorTextBlock.Text = $"Неверный пароль. Осталось попыток: {3 - user.FailedAttempts}";
                }

            }
        }

    }

}
            



           