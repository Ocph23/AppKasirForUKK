using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KasirPage.xaml
    /// </summary>
    public partial class KasirPage : Window
    {

        AppDatabase database = new AppDatabase();
        public KasirPage()
        {
            InitializeComponent();
            DataContext = this;
            combobox_pelanggan.ItemsSource = database.Pelanggan.ToList();
            combobox_pelanggan.SelectedItem = database.Pelanggan.FirstOrDefault();

            combo_product.ItemsSource = database.Produk.ToList();
            datagrid.ItemsSource = Model.DetailPenjualan;
        }

        public List<Pelanggan> DataPelanggan { get; set; }
        public List<Produk> DataProduk { get; set; }

        public Penjualan Model { get; set; } = new Penjualan();

        private void keluar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((ComboBox)sender).SelectedItem as Produk;
            if (selectedItem != null)
            {
                var existrProduct = Model.DetailPenjualan.FirstOrDefault(x => x.Produk.ProdukId == selectedItem.ProdukId);
                if (existrProduct == null)
                {
                    Model.DetailPenjualan.Add(new DetailPenjualan { JumlahProduk = 1, Produk = selectedItem });
                }
            }
            combo_product.SelectedItem = null;
            UpdateTotal();
        }

        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(combo_product.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(combo_product.Text)) return true;
                else
                {
                    var data = o as Produk;
                    if (data != null && data.NamaProduk.ToLower().Contains(combo_product.Text.ToLower()))
                        return true;
                    else return false;
                }
            });
            itemsViewOriginal.Refresh();
        }

        private void simpan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Model.TotalHarga <= 0)
                {
                    throw new SystemException("Anda Belum Menambahkan Item Produk !");
                }

                var bayar = Convert.ToInt32(textbox_bayar.Text);
                if (bayar - Model.TotalHarga < 0)
                {
                    throw new SystemException("Jumlah Bayar Belum Cukup !");
                }

                Model.Pelanggan = combobox_pelanggan.SelectedItem as Pelanggan;
                database.Penjualan.Attach(Model);
                database.SaveChanges();
                MessageBox.Show("Berhasil !");
                BuatPenjualanBaru();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuatPenjualanBaru()
        {
            Model = new Penjualan();
            datagrid.ItemsSource = Model.DetailPenjualan;
            textbox_bayar.Text = "0";
            textBox_kembali.Text = "0";
            total1.Text = "0";
            total2.Text = "0";
            combo_product.SelectedItem = null;
            combobox_pelanggan.SelectedItem = database.Pelanggan.FirstOrDefault();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotal();
        }

        private void bayar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double nilaiBayar = Convert.ToDouble(textbox_bayar.Text);
                if (Model.TotalHarga > 0 && nilaiBayar > 0)
                {
                    this.textBox_kembali.Text = (nilaiBayar - Model.TotalHarga).ToString("N2");
                }
            }
            catch (Exception)
            {

            }
        }


        public void UpdateTotal()
        {
            Model.TotalHarga = Model.DetailPenjualan.Sum(x => x.SubTotal);
            this.total1.Text = this.total2.Text = Model.TotalHarga.ToString("N2");
            datagrid.Items.Refresh();
        }

        private void batal_Click(object sender, RoutedEventArgs e)
        {
            BuatPenjualanBaru();
        }
    }
}
