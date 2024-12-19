using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF.EF
{
    public partial class ShoppingOnlineDbContext : DbContext
    {
        public ShoppingOnlineDbContext()
            : base("name=ShoppingOnlineDbContext")
        {
        }

        public virtual DbSet<BanBe> BanBes { get; set; }
        public virtual DbSet<ChiTietHD> ChiTietHDs { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<GopY> Gopies { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoiDap> HoiDaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }
        public virtual DbSet<TrangWeb> TrangWebs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<YeuThich> YeuThiches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.ChiTietHDs)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.YeuThiches)
                .WithOptional(e => e.HangHoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.RandomKey)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.YeuThiches)
                .WithOptional(e => e.KhachHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChuDes)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhanCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.PhanCongs)
                .WithRequired(e => e.PhongBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);
        }
    }
}
