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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}