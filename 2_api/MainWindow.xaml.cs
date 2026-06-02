using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace _2_api
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string snils = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:4444/TransferSimulator/snils";
                    string jsonAnswer = await client.GetStringAsync(url);

                    jsonAnswer = jsonAnswer.Replace("{", "");
                    jsonAnswer = jsonAnswer.Replace("}", "");
                    jsonAnswer = jsonAnswer.Replace("\"", "");
                    jsonAnswer = jsonAnswer.Replace("value :", "");

                    snils = jsonAnswer.Trim();
                    GetApi.Text = snils;
                    SendApi.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message,
                    "Ошибка API",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }


        private void CheckData_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(snils))
            {
                SendApi.Text = "Получите данные";
                return;
            }

            string Forbidden = "!@#$%^&*():;_+=[]{}<>?/|\\&";

            if (snils.Intersect(Forbidden).Count() > 0)
            {
                SendApi.Text = "Запрещённые символы";
                return;
            }

            SendApi.Text = "Снилс корректный";
        }
    }
}
