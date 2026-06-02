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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<User> User { get; set; } = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            if (User.Count == 0)
            {
                User.Add(new User { Login = "admin", Password = "admin", IsAdmin = true });
                User.Add(new User { Login = "user", Password = "user", IsAdmin = false });
            }

            MainFrame.Navigate(new AuthPage());
        }
    }
}
