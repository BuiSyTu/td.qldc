namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoKhaus", "LoaiNhaO", c => c.String());
            AddColumn("dbo.HoKhaus", "DatO", c => c.String());
            AddColumn("dbo.HoKhaus", "DatSXNN", c => c.String());
            AddColumn("dbo.HoKhaus", "DatChuyenDoi", c => c.String());
            AddColumn("dbo.HoKhaus", "HoKinhDoanh", c => c.String());
            DropColumn("dbo.NhanKhaus", "LoaiNhaO");
            DropColumn("dbo.NhanKhaus", "DatO");
            DropColumn("dbo.NhanKhaus", "DatSXNN");
            DropColumn("dbo.NhanKhaus", "DatChuyenDoi");
            DropColumn("dbo.NhanKhaus", "HoKinhDoanh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanKhaus", "HoKinhDoanh", c => c.String());
            AddColumn("dbo.NhanKhaus", "DatChuyenDoi", c => c.String());
            AddColumn("dbo.NhanKhaus", "DatSXNN", c => c.String());
            AddColumn("dbo.NhanKhaus", "DatO", c => c.String());
            AddColumn("dbo.NhanKhaus", "LoaiNhaO", c => c.String());
            DropColumn("dbo.HoKhaus", "HoKinhDoanh");
            DropColumn("dbo.HoKhaus", "DatChuyenDoi");
            DropColumn("dbo.HoKhaus", "DatSXNN");
            DropColumn("dbo.HoKhaus", "DatO");
            DropColumn("dbo.HoKhaus", "LoaiNhaO");
        }
    }
}
