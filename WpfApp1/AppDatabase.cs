using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public class AppDatabase : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Server=localhost; database=kasir; UID=root; password=Sonyalpha@77";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Produk> Produk{ get; set; }
        public DbSet<Pelanggan> Pelanggan{ get; set; }
        public DbSet<Penjualan> Penjualan { get; set; }

    }
}
