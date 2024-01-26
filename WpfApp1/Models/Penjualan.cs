using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Penjualan
    {
        [Key]
        public int PenjualanId { get; set; }

        public DateTime Tanggal { get; set; } =DateTime.Now;

        public Pelanggan Pelanggan { get; set; }

        public ICollection<DetailPenjualan> DetailPenjualan { get; set; } = new List<DetailPenjualan>();

        public double TotalHarga { get; set; }


    }


    public class DetailPenjualan
    {
        [Key]
        public int DetailId { get; set; }

        public Produk Produk { get; set; }

        public int PenjualanPenjualanId { get; set; }

        public int JumlahProduk { get; set; }

        public double SubTotal => Produk == null ? 0 : Produk.Harga * JumlahProduk;

    }

}
