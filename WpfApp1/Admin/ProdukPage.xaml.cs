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
    /// Interaction logic for ProdukPage.xaml
    /// </summary>
    public partial class ProdukPage : Page
    {
        AppDatabase appDatabase = new AppDatabase();
        public List<Produk> DataProduk { get; set; }
        public ProdukPage()
        {
            InitializeComponent();

            DataContext = this;
            DataProduk = appDatabase.Produk.ToList();
        }

        private void tambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                appDatabase.AttachRange(DataProduk);
                appDatabase.SaveChanges();
                datagrid.Items.Refresh();
                MessageBox.Show("Sukses");
            }
            catch (Exception)
            {
                MessageBox.Show("Periksa Kembali Data Anda");
            }
        }

        private void hapus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Produk produk = datagrid.SelectedItem as Produk;
                if (produk != null)
                {
                    appDatabase.Remove(produk);
                    appDatabase.SaveChanges();
                    DataProduk.Remove(produk);
                    datagrid.Items.Refresh();
                    MessageBox.Show("Sukses");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Periksa Kembali Data Anda");
            }
        }
    }
}
