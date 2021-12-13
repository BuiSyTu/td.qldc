namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NhanKhaus", "MaXacThuc");
            DropColumn("dbo.NhanKhaus", "HanXacThuc");
            DropColumn("dbo.NhanKhaus", "SoCMT");
            DropColumn("dbo.NhanKhaus", "NgayCapCMT");
            DropColumn("dbo.NhanKhaus", "NoiCapCMT");
            DropColumn("dbo.NhanKhaus", "Xom");
            DropColumn("dbo.NhanKhaus", "Khu");
            DropColumn("dbo.NhanKhaus", "Ngo");
            DropColumn("dbo.NhanKhaus", "QueQuan");
            DropColumn("dbo.NhanKhaus", "NoiTTTruoc");
            DropColumn("dbo.NhanKhaus", "LyDoChuyen");
            DropColumn("dbo.NhanKhaus", "ChuyenDenNgay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanKhaus", "ChuyenDenNgay", c => c.DateTime());
            AddColumn("dbo.NhanKhaus", "LyDoChuyen", c => c.String());
            AddColumn("dbo.NhanKhaus", "NoiTTTruoc", c => c.String());
            AddColumn("dbo.NhanKhaus", "QueQuan", c => c.String());
            AddColumn("dbo.NhanKhaus", "Ngo", c => c.String());
            AddColumn("dbo.NhanKhaus", "Khu", c => c.String());
            AddColumn("dbo.NhanKhaus", "Xom", c => c.String());
            AddColumn("dbo.NhanKhaus", "NoiCapCMT", c => c.String());
            AddColumn("dbo.NhanKhaus", "NgayCapCMT", c => c.DateTime());
            AddColumn("dbo.NhanKhaus", "SoCMT", c => c.String());
            AddColumn("dbo.NhanKhaus", "HanXacThuc", c => c.DateTime());
            AddColumn("dbo.NhanKhaus", "MaXacThuc", c => c.String());
        }
    }
}
