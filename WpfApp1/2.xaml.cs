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
	    /// Логика взаимодействия для _2.xaml
	    /// </summary>
	public partial class _2 : Window
	{
		public _2()
		{
			InitializeComponent();
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			// Здесь должна быть логика регистрации
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _9
			var window8 = new _8();

			// 2. Открываем его
			window8.Show();

			// 3. Закрываем текущее окно (_2)
			this.Close();
		}
	}
}