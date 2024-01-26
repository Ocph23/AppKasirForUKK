using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Produk
    {
        [Key]
        public int ProdukId { get; set; }

        public string NamaProduk { get; set; }

        public double Harga { get; set; }

        public int Stok { get; set; }

        public string Satuan { get; set; }

    }
}
