using System.Windows;
using System.Windows.Controls; // Добавьте

namespace WpfApp1
{
	public partial class _3 : Window
	{
		public _3()
		{
			InitializeComponent();
		}

		private void ProfileButton_Click(object sender, RoutedEventArgs e)
		{
			var profileWindow = new _4();
			profileWindow.Show();
			this.Close();
		}

		private void BackToLogin_Click(object sender, RoutedEventArgs e)
		{
			var mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Можно использовать этот, если он привязан к кнопке, которая должна вести на страницу 4
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{

		}

		// Этот метод ведет на страницу 4
		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			var window4 = new _4();
			window4.Show();
			this.Close();
		}

		// 🎯 Этот метод ведет на страницу 5
		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			// Создаем новый экземпляр окна _5
			var window5 = new _5();

			// Открываем его
			window5.Show();

			// Закрываем текущее окно (_3)
			this.Close();
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _6
			var window6 = new _6();

			// 2. Открываем его
			window6.Show();

			// 3. Закрываем текущее окно (_3)
			this.Close();
		}
	}
}