namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoKhaus", "DMLoaiHoID", c => c.Int());
            AddColumn("dbo.NhanKhaus", "HoKhauID", c => c.Int());
            AddColumn("dbo.NhanKhaus", "DatO", c => c.String());
            AddColumn("dbo.NhanKhaus", "DatSXNN", c => c.String());
            AddColumn("dbo.NhanKhaus", "DatChuyenDoi", c => c.String());
            AddColumn("dbo.NhanKhaus", "HoKinhDoanh", c => c.String());
            CreateIndex("dbo.HoKhaus", "DMLoaiHoID");
            CreateIndex("dbo.NhanKhaus", "HoKhauID");
            AddForeignKey("dbo.HoKhaus", "DMLoaiHoID", "dbo.Categories", "ID");
            AddForeignKey("dbo.NhanKhaus", "HoKhauID", "dbo.HoKhaus", "ID");
            DropColumn("dbo.HoKhaus", "DMLoaiHo");
            DropColumn("dbo.NhanKhaus", "SoHoKhau");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanKhaus", "SoHoKhau", c => c.String());
            AddColumn("dbo.HoKhaus", "DMLoaiHo", c => c.String());
            DropForeignKey("dbo.NhanKhaus", "HoKhauID", "dbo.HoKhaus");
            DropForeignKey("dbo.HoKhaus", "DMLoaiHoID", "dbo.Categories");
            DropIndex("dbo.NhanKhaus", new[] { "HoKhauID" });
            DropIndex("dbo.HoKhaus", new[] { "DMLoaiHoID" });
            DropColumn("dbo.NhanKhaus", "HoKinhDoanh");
            DropColumn("dbo.NhanKhaus", "DatChuyenDoi");
            DropColumn("dbo.NhanKhaus", "DatSXNN");
            DropColumn("dbo.NhanKhaus", "DatO");
            DropColumn("dbo.NhanKhaus", "HoKhauID");
            DropColumn("dbo.HoKhaus", "DMLoaiHoID");
        }
    }
}
