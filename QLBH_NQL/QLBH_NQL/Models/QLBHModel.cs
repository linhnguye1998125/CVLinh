namespace QLBH_NQL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLBHModel : DbContext
    {
        public QLBHModel()
            : base("name=QLBANHOAEntities")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BINHLUAN> BINHLUANs { get; set; }
        public virtual DbSet<CTDATHANG> CTDATHANGs { get; set; }
        public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
        public virtual DbSet<DANHMUCCON> DANHMUCCONs { get; set; }
        public virtual DbSet<DANHMUCHOA> DANHMUCHOAs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<HOA> HOAs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }
        public virtual DbSet<YNGHIAHOA> YNGHIAHOAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TENDN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .HasMany(e => e.TINTUCs)
                .WithRequired(e => e.ADMIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTDATHANG>()
                .Property(e => e.DONGIA)
                .HasPrecision(20, 0);

            modelBuilder.Entity<CTDATHANG>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(20, 0);

            modelBuilder.Entity<DANHMUCCON>()
                .Property(e => e.MADMH)
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUCCON>()
                .Property(e => e.MADM)
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUCCON>()
                .HasMany(e => e.HOAs)
                .WithRequired(e => e.DANHMUCCON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DANHMUCHOA>()
                .Property(e => e.MADM)
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUCHOA>()
                .Property(e => e.HREF)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.TRIGIA)
                .HasPrecision(20, 0);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CTDATHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOA>()
                .Property(e => e.DONGIA)
                .HasPrecision(20, 0);

            modelBuilder.Entity<HOA>()
                .Property(e => e.ANHHOA)
                .IsUnicode(false);

            modelBuilder.Entity<HOA>()
                .Property(e => e.MADMH)
                .IsUnicode(false);

            modelBuilder.Entity<HOA>()
                .HasMany(e => e.CTDATHANGs)
                .WithRequired(e => e.HOA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TENDN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.ANH)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.HREF)
                .IsUnicode(false);

            modelBuilder.Entity<YNGHIAHOA>()
                .Property(e => e.ANH)
                .IsUnicode(false);
        }
    }
}
