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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1.Admin
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public List<User>  Users { get; set; }
        public UserPage()
        {
            InitializeComponent();
            DataContext = this;
            Load();
        }

        private void Load()
        {
            using var dbconnection = new AppDatabase();
            var result = dbconnection.User.ToList();  
            Users = result;
        }

        private void tambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var dbconnection = new AppDatabase();
                dbconnection.User.AttachRange(Users);
                dbconnection.SaveChanges();
                MessageBox.Show("Sukses");
            }
            catch (Exception)
            {
                MessageBox.Show("Periksa Data ");
            }
            
        }

        private void hapus(object sender, RoutedEventArgs e)
        {
            using var dbconnection = new AppDatabase();
            var data = dataGrid.SelectedItem as User;
            dbconnection.User.Remove(data);
            dbconnection.SaveChanges();
            Users.Remove(data);
            dataGrid.Items.Refresh();

        }
    }
}
