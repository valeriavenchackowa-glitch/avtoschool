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
	    /// Логика взаимодействия для _8.xaml
	    /// </summary>
	public partial class _8 : Window
	{
		public _8()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _9
			var window9 = new _9();

			// 2. Открываем его
			window9.Show();

			// 3. Закрываем текущее окно (_8)
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _10
			var window10 = new _10();

			// 2. Открываем его
			window10.Show();

			// 3. Закрываем текущее окно (_8)
			this.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _11
			var window11 = new _11();

			// 2. Открываем его
			window11.Show();

			// 3. Закрываем текущее окно (_8)
			this.Close();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _12
			var window12 = new _12();

			// 2. Открываем его
			window12.Show();

			// 3. Закрываем текущее окно (_8)
			this.Close();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _13
			var window13 = new _13();

			// 2. Открываем его
			window13.Show();

			// 3. Закрываем текущее окно (_8)
			this.Close();
		}
	}
}