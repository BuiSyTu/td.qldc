using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using TD.Core.Api.Mvc;

namespace TD.QLDC.Library.Models
{
    public class QLDCDbContext : TDCoreDbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
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
            //modelBuilder.Entity<NhanKhau>()
            //    .HasRequired(x => x.HoKhau)
            //    .WithMany(y => y.NhanKhau)
            //    .HasForeignKey(x => x.HoKhauID);
            modelBuilder.Entity<Category>()
                .HasRequired(x => x.Nhom)
                .WithMany(y => y.DanhMuc)
                .HasForeignKey(x => x.NhomID);


            base.OnModelCreating(modelBuilder);
            

        }
    }
}
