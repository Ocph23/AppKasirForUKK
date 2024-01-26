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
    /// Interaction logic for PelangganPage.xaml
    /// </summary>
    public partial class PelangganPage : Page
    {
        AppDatabase appDatabase = new AppDatabase();
        public List<Pelanggan> DataPelanggan { get; set; }
        public PelangganPage()
        {
            InitializeComponent();

            DataContext = this;
            DataPelanggan = appDatabase.Pelanggan.ToList();
        }

        private void tambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                appDatabase.AttachRange(DataPelanggan);
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
                Pelanggan produk = datagrid.SelectedItem as Pelanggan;
                if (produk != null)
                {
                    appDatabase.Remove(produk);
                    appDatabase.SaveChanges();
                    DataPelanggan.Remove(produk);
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
