namespace QLTX.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataProvider : DbContext
    {
        public DataProvider()
            : base("name=DataProvider")
        {
        }

        public virtual DbSet<CTPTHUEXE> CTPTHUEXEs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIXE> LOAIXEs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUDENBU> PHIEUDENBUs { get; set; }
        public virtual DbSet<PHIEUTHUEXE> PHIEUTHUEXEs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<XETHUE> XETHUEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTPTHUEXE>()
                .HasMany(e => e.PHIEUDENBU)
                .WithOptional(e => e.CTPTHUEXE)
                .HasForeignKey(e => new { e.SOPHIEUTHUEXE, e.MAXE });

            modelBuilder.Entity<CTPTHUEXE>()
                .HasMany(e => e.HOADON)
                .WithOptional(e => e.CTPTHUEXE)
                .HasForeignKey(e => new { e.SOPHIEUTHUEXE, e.MAXE });

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.BANGLAI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIXE>()
                .Property(e => e.TENLX)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADON)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => new { e.MANV, e.MATK });

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUDENBU)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => new { e.MANV, e.MATK });

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUTHUEXE)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => new { e.MANV, e.MATK });

            modelBuilder.Entity<PHIEUDENBU>()
                .Property(e => e.HINHTHUCDENBU)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTHUEXE>()
                .HasMany(e => e.CTPTHUEXE)
                .WithRequired(e => e.PHIEUTHUEXE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TENTAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.NHANVIEN)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XETHUE>()
                .Property(e => e.TENXE)
                .IsUnicode(false);

            modelBuilder.Entity<XETHUE>()
                .Property(e => e.KIEUXE)
                .IsUnicode(false);

            modelBuilder.Entity<XETHUE>()
                .Property(e => e.BIENSOXE)
                .IsUnicode(false);

            modelBuilder.Entity<XETHUE>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<XETHUE>()
                .HasMany(e => e.CTPTHUEXE)
                .WithRequired(e => e.XETHUE)
                .WillCascadeOnDelete(false);
        }
    }
}
