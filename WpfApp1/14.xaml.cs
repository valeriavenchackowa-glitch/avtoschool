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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для _14.xaml
    /// </summary>
    public partial class _14 : Window
    {
        public _14()
        {
            InitializeComponent();
        }

        private void SearchBox_Копировать2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchBox_Копировать1_TextChanged(object sender, TextChangedEventArgs e)
        {

		}

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
			if (string.IsNullOrEmpty(LastnameBox.Text) ||
				string.IsNullOrEmpty(FirstnameBox.Text) ||
				string.IsNullOrEmpty(PatronymicBox.Text) ||
				string.IsNullOrEmpty(LoginBox.Text) ||
				string.IsNullOrEmpty(PasswordBox.Text))
			{
				MessageBox.Show("Заполните все обязательные поля");
				return;
			}

			// Создание нового пользователя
			var newUser = new users
			{
				role = "Student",
				lastname = LastnameBox.Text,
				FirstName = FirstnameBox.Text,
				patronymic = PatronymicBox.Text,
				phone = PhoneBox.Text,
				login = LoginBox.Text,
				password = PasswordBox.Text,
				id_group = 2,
				id_category = 2
			};

			// Регистрация в БД
			bool success = DbService.AddUsers(newUser);

			if (success)
			{
				MessageBox.Show("Добавление прошло успешно!");

			}
		}
	}
}
