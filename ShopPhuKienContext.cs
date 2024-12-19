using Microsoft.EntityFrameworkCore;
using Nhom_Co_Di_Hoc.Model;

namespace Nhom_Co_Di_Hoc.Data
{
    public class ShopPhuKienContext : DbContext
    {
        public ShopPhuKienContext(DbContextOptions<ShopPhuKienContext> options)
            : base(options)
        {
        }

        public DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .ToTable("SanPham");  

            modelBuilder.Entity<SanPham>()
                .HasKey(s => s.MaSanPham); 
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }

}
