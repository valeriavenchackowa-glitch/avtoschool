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
	    /// Логика взаимодействия для _5.xaml
	    /// </summary>
	public partial class _5 : Window
	{
		public _5()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _4
			var window4 = new _4();

			// 2. Открываем его
			window4.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _3
			var window3 = new _3();

			// 2. Открываем его
			window3.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _6
			var window6 = new _6();

			// 2. Открываем его
			window6.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _7
			var window7 = new _7();

			// 2. Открываем его
			window7.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void IntroductoryLesson_Click(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _7
			var window7 = new _7();

			// 2. Открываем его
			window7.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _4
			var window4 = new _4();

			// 2. Открываем его
			window4.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _3
			var window3 = new _3();

			// 2. Открываем его
			window3.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _6
			var window6 = new _6();

			// 2. Открываем его
			window6.Show();

			// 3. Закрываем текущее окно (_5)
			this.Close();
		}
	}
}