using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенные данные
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            // Здесь может быть проверка с базой данных или файлом
            // Для примера: проверка на простые значения
            if (login == "admin" && password == "admin")
            {
                MessageBox.Show("Авторизация успешна!");

                // Открываем 3-ю страницу (главную)
                var thirdPage = new _3(); // Создаем экземпляр окна _3
                thirdPage.Show(); // Показываем окно
                this.Close(); // Закрываем текущее окно авторизации
            }
            else if (login == "user" && password == "123")
            {
                MessageBox.Show("Авторизация успешна!");

                // Открываем 3-ю страницу (главную)
                var thirdPage = new _3();
                thirdPage.Show();
                this.Close();
            }
            else
            {
                // Для демо-режима - всегда открывать 3-ю страницу
                // Если хотите тестировать без проверки пароля:
                MessageBox.Show("Авторизация успешна! (демо-режим)");

                var thirdPage = new _3();
                thirdPage.Show();
                this.Close();

                // Если хотите реальную проверку, раскомментируйте:
                // MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на окно регистрации (2-я страница)
            var registrationWindow = new _2();
            registrationWindow.Show();
            this.Close();
        }
    }
}