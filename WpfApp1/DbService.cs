using WpfApp1.Models;
using MySql.Data.MySqlClient;
using System.Windows;

namespace WpfApp1
{
	internal class DbService
	{
		// Строка подключения к базе данных MySQL
		// Содержит все параметры: сервер (у вас такой же), БД (tompsons_studN - N номер по журналу - 01, 04, 13...), логин (как имя БД), пароль (ваш) и кодировку
		public static string connectionString = "server=tompsons.beget.tech;user=tompsons_stud05;database=tompsons_stud05;password=7zt85zgAqG;CharSet=utf8mb4;";

		// Метод для создания и открытия подключения к БД
		public static MySqlConnection GetConnection()
		{
			// Новый объект подключения с использованием строки подключения
			MySqlConnection connection = new MySqlConnection(connectionString);
			// Открываем соединение с базой данных
			connection.Open();
			// Возвращаем готовое подключение
			return connection;
		}

		// Универсальный метод для выполнения SQL-запросов, которые НЕ возвращают данные
		// (INSERT, UPDATE, DELETE) с использованием параметров для безопасности
		public static int ExecuteNonQueryWithParameters(string query, Dictionary<string, object> parameters)
		{
			// Количество затронутых строк
			int rowsAffected = 0;
			// using обеспечивает автоматическое закрытие соединения и команды
			using (MySqlConnection connection = GetConnection())
			using (MySqlCommand command = new MySqlCommand(query, connection))
			{
				// Добавляем параметры в команду для защиты от SQL-инъекций
				foreach (var parameter in parameters)
				{
					command.Parameters.AddWithValue(parameter.Key, parameter.Value);
				}
				// Выполняем запрос и получаем количество обработанных строк
				rowsAffected = command.ExecuteNonQuery();
			}
			return rowsAffected;
		}

		// Универсальный метод для получения данных с возможностью преобразования
		public static List<T> GetData<T>(string query, Func<MySqlDataReader, T> mapFunction)
		{
			// Список для хранения результата
			List<T> data = new List<T>();
			using (MySqlConnection connection = GetConnection())
			{
				using (MySqlCommand command = new MySqlCommand(query, connection))
				using (MySqlDataReader reader = command.ExecuteReader())
				{
					// Читаем построчно, пока есть данные
					while (reader.Read())
					{
						// Преобразуем текущую строку в объект типа T с помощью переданной функции
						data.Add(mapFunction(reader));
					}
				}
			}
			return data;
		}

		// Метод для выполнения скалярных запросов (возвращающих одно значение)
		// Например: SELECT COUNT(*) FROM table
		public static object ExecuteScalar(string query, Dictionary<string, object> parameters)
		{
			object result = null;
			using (MySqlConnection connection = GetConnection())
			using (MySqlCommand command = new MySqlCommand(query, connection))
			{
				foreach (var parameter in parameters)
				{
					command.Parameters.AddWithValue(parameter.Key, parameter.Value);
				}
				result = command.ExecuteScalar();
			}
			return result;
		}

		// Метод для аутентификации пользователя по логину и паролю
		public static users AuthenticateUser(string login, string password)
		{
			try
			{
				string query = "SELECT * FROM users WHERE login = @login AND password = @password";

				using (MySqlConnection connection = GetConnection())
				using (MySqlCommand command = new MySqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@login", login);
					command.Parameters.AddWithValue("@password", password);

					using (MySqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return new users
							{
								id_users = reader.GetInt32("id_users"),
								login = reader.GetString("login"),
								password= reader.GetString("password"),
								role = reader.GetString("role"),
								lastname = reader.GetString("LastName"),
								FirstName = reader.GetString("FirstName"),
								patronymic = reader.GetString("patronymic"),
								phone = reader.GetString("phone"),
								id_group = reader.GetInt32("id_group"),
								id_category = reader.GetInt32("id_category")
							};
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка аутентификации: {ex.Message}");
			}

			return null;
		}

		// Метод для получения всех пользователей из БД
		public static List<users> GetAllUsers()
		{
			string query = "SELECT * FROM users ORDER BY id_users";

			// Используем универсальный метод GetData с лямбда-выражением для создания объектов User
			return GetData(query, reader => new users
			{
				id_users = reader.GetInt32("id_users"),
				login = reader.GetString("login"),
				password = reader.GetString("password"),
				role = reader.GetString("role"),
				lastname = reader.GetString("LastName"),
				FirstName = reader.GetString("FirstName"),
				patronymic = reader.GetString("patronymic"),
				phone = reader.GetString("phone"),
				id_group = reader.GetInt32("id_group"),
				id_category = reader.GetInt32("id_category")
			});
		}

		//// Метод для обновления данных пользователя
		//public static bool UpdateUser(User user)
		//{
		//	try
		//	{
		//		string query = @"UPDATE users 
		//                          SET surname = @surname, 
		//                              name = @name, 
		//                              patronymic = @patronymic, 
		//                              role = @role, 
		//                              login = @login, 
		//                              password = @password 
		//                          WHERE id = @id";

		//		var parameters = new Dictionary<string, object>
		//		{
		//			["@id"] = user.Id,
		//			["@surname"] = user.Surname,
		//			["@name"] = user.Name,
		//			["@patronymic"] = user.Patronymic,
		//			["@role"] = user.Role,
		//			["@login"] = user.Login,
		//			["@password"] = user.Password
		//		};

		//		ExecuteNonQueryWithParameters(query, parameters);
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"Ошибка обновления пользователя: {ex.Message}");
		//		return false;
		//	}
		//}

		// Метод для удаления пользователя по ID
		public static bool DeleteUser(int userId)
		{
			try
			{
				string query = "DELETE FROM users WHERE id_users = @id";
				var parameters = new Dictionary<string, object>
				{
					["@id"] = userId
				};

				ExecuteNonQueryWithParameters(query, parameters);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}");
				return false;
			}
		}

		//public static List<News> GetAllNews()
		//{
		//	string query = "SELECT * FROM news ORDER BY id DESC";
		//	return GetData(query, reader => new News
		//	{
		//		Id = reader.GetInt32("id"),
		//		Title = reader.GetString("title"),
		//		Description = reader.GetString("description"),
		//		ImagePath = reader.GetString("image_path")
		//	});
		//}

		public static bool AddUsers(users user)
		{
			try
			{
				string query = @"INSERT INTO users (login, password, role, LastName, FirstName, patronymic, phone, id_group, id_category) 
		                          VALUES (@login, @password, @role, @lastname, @firstname, @patronymic, @phone, @id_group, @id_category)";

				var parameters = new Dictionary<string, object>
				{
					["@login"] = user.login,
					["@password"] = user.password,
					["@role"] = user.role,
					["@lastname"] = user.lastname,
					["@firstname"] = user.FirstName,
					["@patronymic"] = user.patronymic,
					["@phone"] = user.phone,
					["@id_group"] = user.id_group,
					["@id_category"] = user.id_category

				};

				ExecuteNonQueryWithParameters(query, parameters);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка добавления новости: {ex.Message}");
				return false;
			}
		}

		//public static bool UpdateNews(News news)
		//{
		//	try
		//	{
		//		string query = @"UPDATE news 
		//                          SET title = @title, 
		//                              description = @description, 
		//                              image_path = @image_path 
		//                          WHERE id = @id";

		//		var parameters = new Dictionary<string, object>
		//		{
		//			["@id"] = news.Id,
		//			["@title"] = news.Title,
		//			["@description"] = news.Description,
		//			["@image_path"] = news.ImagePath
		//		};

		//		ExecuteNonQueryWithParameters(query, parameters);
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"Ошибка обновления новости: {ex.Message}");
		//		return false;
		//	}
		//}

		//public static bool DeleteNews(int newsId)
		//{
		//	try
		//	{
		//		string query = "DELETE FROM news WHERE id = @id";
		//		var parameters = new Dictionary<string, object>
		//		{
		//			["@id"] = newsId
		//		};

		//		ExecuteNonQueryWithParameters(query, parameters);
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"Ошибка удаления новости: {ex.Message}");
		//		return false;
		//	}
		//}
	}
}
