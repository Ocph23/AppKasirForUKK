using Microsoft.EntityFrameworkCore;
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
    public partial class PenjualanPage : Page
    {
        AppDatabase appDatabase = new AppDatabase();
        public List<Penjualan> DataPenjualan { get; set; }
        public PenjualanPage()
        {
            InitializeComponent();

            DataContext = this;
            DataPenjualan= appDatabase.Penjualan
                .Include(x=>x.Pelanggan)
                .Include(x=>x.DetailPenjualan).ThenInclude(x=>x.Produk)
                .ToList();
        }
    }
}
