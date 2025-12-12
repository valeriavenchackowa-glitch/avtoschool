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
	    /// Логика взаимодействия для _11.xaml
	    /// </summary>
	public partial class _11 : Window
	{
		public _11()
		{
			InitializeComponent();
			var usersList = DbService.GetAllUsers();
			List<users> students = new List<users> { };
			foreach (var user in usersList)
			{
				if (user.role == "Student")
				{ students.Add(user); }
			}
			StudentsDataGrid.ItemsSource = students;

		}


		private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var user = button?.DataContext as users;

			if (user != null)
			{
				// Нельзя удалять самого себя
				if (user.role == "admin" && user.id_users == 1)
				{
					MessageBox.Show("Нельзя удалить главного администратора");
					return;
				}

				var result = MessageBox.Show($"Удалить пользователя '{user.lastname} {user.FirstName} {user.patronymic}'?",
					"Подтверждение удаления",
					MessageBoxButton.YesNo,
					MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					if (DbService.DeleteUser(user.id_users))
					{
						MessageBox.Show("Пользователь удален");

						// Обновление списка
						RefreshStudentsDataGrid();
					}
				}
			}
		}

		// *** ВНИМАНИЕ: Этот метод (Button_Click_1) теперь не используется, так как
		// *** кнопка в XAML привязана к AddStudentButton_Click. 
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// Этот код был логикой добавления, но теперь он не привязан к кнопке "Добавить" в XAML.
			// Я его оставляю, но он не будет вызываться.

			// ... (Код добавления-заглушки)
			var newStudent = new users
			{
				id_users = 0,
				FirstName = "Иван",
				lastname = "Петров",
				patronymic = "Сергеевич",
				login = "ivan.petrov",
				password = "newuserpass",
				role = "Student"
			};

			var result = MessageBox.Show($"Добавить нового студента '{newStudent.lastname} {newStudent.FirstName}'?",
				"Подтверждение добавления",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.Yes)
			{
				// if (DbService.AddUser(newStudent)) 
				{
					MessageBox.Show("Студент успешно добавлен!");
					RefreshStudentsDataGrid();
				}
			}
		}

		// Вспомогательный метод для обновления DataGrid
		private void RefreshStudentsDataGrid()
		{
			var usersList = DbService.GetAllUsers();
			List<users> students = new List<users> { };
			foreach (var item in usersList)
			{
				if (item.role == "Student")
				{ students.Add(item); }
			}
			StudentsDataGrid.ItemsSource = students;
		}

		private void AddStudentButton_Click(object sender, RoutedEventArgs e)
		{
			// 1. Создаем новый экземпляр окна _14
			var window14 = new _14();

			// 2. Открываем его
			window14.Show();

			// 3. Закрываем текущее окно (_11)
			this.Close();
		}
	}
}