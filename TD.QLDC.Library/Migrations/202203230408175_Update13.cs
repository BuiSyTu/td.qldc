namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "FullTextSearch", c => c.String());
            AddColumn("dbo.NhomDanhMucs", "FullTextSearch", c => c.String());
            AddColumn("dbo.HoKhaus", "FullTextSearch", c => c.String());
            AddColumn("dbo.NhanKhaus", "FullTextSearch", c => c.String());
            AddColumn("dbo.NhanKhaus", "HanSuDungHC", c => c.DateTime());
            AddColumn("dbo.NhanKhaus", "TenTinhThanhTamTru", c => c.String());
            AddColumn("dbo.NhanKhaus", "TenQuanHuyenTamTru", c => c.String());
            AddColumn("dbo.NhanKhaus", "TenXaPhuongTamTru", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanKhaus", "TenXaPhuongTamTru");
            DropColumn("dbo.NhanKhaus", "TenQuanHuyenTamTru");
            DropColumn("dbo.NhanKhaus", "TenTinhThanhTamTru");
            DropColumn("dbo.NhanKhaus", "HanSuDungHC");
            DropColumn("dbo.NhanKhaus", "FullTextSearch");
            DropColumn("dbo.HoKhaus", "FullTextSearch");
            DropColumn("dbo.NhomDanhMucs", "FullTextSearch");
            DropColumn("dbo.Categories", "FullTextSearch");
        }
    }
}
