using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using TD.Core.Api.Mvc;

namespace TD.QLDC.Library.Models
{
    public class QLDCDbContext : TDCoreDbContext
    {
        public QLDCDbContext() : base("name=QLDCContext")
        {
        }

        #region Dbset
        public DbSet<Category> Categories { get; set; }
        public DbSet<HoKhau> HoKhaus { get; set; }
        public DbSet<NhanKhau> NhanKhaus { get; set; }
        public DbSet<NhomDanhMuc> NhomDanhMucs { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Categories");

            modelBuilder.Entity<HoKhau>()
                .ToTable("HoKhaus");

            modelBuilder.Entity<NhomDanhMuc>()
                 .ToTable("NhomDanhMucs");

            modelBuilder.Entity<NhanKhau>()
                .ToTable("NhanKhaus");

            modelBuilder.Entity<Category>()
                .HasRequired(x => x.Nhom)
                .WithMany(y => y.DanhMuc)
                .HasForeignKey(x => x.NhomID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
