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
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	    /// Логика взаимодействия для _4.xaml
	    /// </summary>
	public partial class _4 : Window
	{
		public _4()
		{
			InitializeComponent();
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{

		}

		private void PayButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр главного окна
			MainWindow mainWindow = new MainWindow();

			// 2. Открываем его
			mainWindow.Show();

			// 3. Закрываем текущее окно (_4)
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _5
			var window5 = new _5();

			// 2. Открываем его
			window5.Show();

			// 3. Закрываем текущее окно (_4)
			this.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _3
			var window3 = new _3();

			// 2. Открываем его
			window3.Show();

			// 3. Закрываем текущее окно (_4)
			this.Close();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _6
			var window6 = new _6();

			// 2. Открываем его
			window6.Show();

			// 3. Закрываем текущее окно (_4)
			this.Close();
		}
	}
}