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
			string login = LoginBox.Text.Trim();
			// Получаем пароль из поля для пароля (PasswordBox скрывает ввод)
			string password = PasswordBox.Password;
			// Получаем введенные данные
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Введите логин и пароль");
				return;
			}

			// Вызываем метод аутентификации из сервиса базы данных
			// DbService.AuthenticateUser проверяет логин/пароль в базе данных
			var user = DbService.AuthenticateUser(login, password);

			// Проверяем результат аутентификации
			if (user != null)
			{
				// Если пользователь найден (аутентификация успешна):

				// Открываем окно, соответствующее роли пользователя
				_3 _3 = new _3();
				_3.Show();
				// скрываем, но не уничтожаем
				// Окно невидимо, но продолжает существовать в памяти
				// Можно вернуться к нему позже (например, при разлогине)
				this.Hide();
			}
			else
			{
				MessageBox.Show("Неверный логин или пароль");
			}
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			// Переход на окно регистрации (2-я страница)
			var registrationWindow = new _2();
			registrationWindow.Show();
			this.Close(); // Закрываем текущее окно
		}

		private void AdminLoginButton_Click(object sender, RoutedEventArgs e)
		{
			// Переход на окно регистрации (2-я страница)
			var registrationWindow = new _2();
			registrationWindow.Show();
			this.Close(); // Закрываем текущее окно
		}
	}
}