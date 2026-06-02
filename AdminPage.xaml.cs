using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public ObservableCollection<User> ObservableUsers { get; set; }
        public AdminPage()
        {
            InitializeComponent();
            ObservableUsers = new ObservableCollection<User>(MainWindow.User);
            UsersDataGrid.ItemsSource = ObservableUsers;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                AdminLoginBox.Text = selectedUser.Login;
                AdminPasswordBox.Text = selectedUser.Password;
                AdminIsAdminCheck.IsChecked = selectedUser.IsAdmin;
            }
        }

        private void UnlockButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                selectedUser.IsBlocked = false;
                selectedUser.FailedAttempts = 0;
                MessageBox.Show($"Пользователь {selectedUser.Login} разблокирован.");
                UsersDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите пользователя из таблицы для разблокировки.");
            }
        }

    }
}
