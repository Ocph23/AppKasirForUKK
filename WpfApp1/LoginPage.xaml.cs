using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var appDatabase = new AppDatabase();
                var user = appDatabase.User.Where(x => x.UserName == this.userName.Text).FirstOrDefault();
                if (user != null && user.Status && user.Password == this.password.Password)
                {
                    if (user.Privilage == Privilage.Administrator)
                    {
                        var adminPage = new AdminPage();
                        adminPage.Show();
                    }
                    else
                    {
                        var kasirPage = new KasirPage();
                        kasirPage.Show();
                    }
                    this.Close();
                }
                else
                {
                    throw new SystemException();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Anda Tidak Memiliki AKses !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}