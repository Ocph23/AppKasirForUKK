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
using WpfApp1.Admin;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AdmninPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
            this.frame.Navigate(new Home());
        }

        private void button_home_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Home());
        }

        private void button_produk_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new ProdukPage());
        }

        private void button_user_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new UserPage());
        }

        private void button_pelanggan_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new PelangganPage());
        }

        private void button_penjualan_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new PenjualanPage());
        }
    }
}
