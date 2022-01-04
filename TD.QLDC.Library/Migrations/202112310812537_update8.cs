namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoKhaus", "MaTinhThanh", c => c.String());
            AddColumn("dbo.HoKhaus", "TenTinhThanh", c => c.String());
            AddColumn("dbo.HoKhaus", "MaQuanHuyen", c => c.String());
            AddColumn("dbo.HoKhaus", "TenQuanHuyen", c => c.String());
            AddColumn("dbo.HoKhaus", "MaXaPhuong", c => c.String());
            AddColumn("dbo.HoKhaus", "TenXaPhuong", c => c.String());
            AddColumn("dbo.HoKhaus", "MaThon", c => c.String());
            AddColumn("dbo.HoKhaus", "TenThon", c => c.String());
            AddColumn("dbo.HoKhaus", "MaXom", c => c.String());
            AddColumn("dbo.HoKhaus", "TenXom", c => c.String());
            AddColumn("dbo.NhanKhaus", "MaTinhThanhTamTru", c => c.String());
            AddColumn("dbo.NhanKhaus", "MaQuanHuyenTamTru", c => c.String());
            AddColumn("dbo.NhanKhaus", "MaXaPhuongTamTru", c => c.String());
            AddColumn("dbo.NhanKhaus", "DiaChiTamTru", c => c.String());
            DropColumn("dbo.HoKhaus", "Tinh");
            DropColumn("dbo.HoKhaus", "QuanHuyen");
            DropColumn("dbo.HoKhaus", "PhuongXa");
            DropColumn("dbo.HoKhaus", "Thon");
            DropColumn("dbo.HoKhaus", "Xom");
            DropColumn("dbo.NhanKhaus", "Tinh");
            DropColumn("dbo.NhanKhaus", "Huyen");
            DropColumn("dbo.NhanKhaus", "Xa");
            DropColumn("dbo.NhanKhaus", "NoiOHienTai");
            DropColumn("dbo.NhanKhaus", "NoiSinh");
            DropColumn("dbo.NhanKhaus", "NoiThuongTru");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanKhaus", "NoiThuongTru", c => c.String());
            AddColumn("dbo.NhanKhaus", "NoiSinh", c => c.String());
            AddColumn("dbo.NhanKhaus", "NoiOHienTai", c => c.String());
            AddColumn("dbo.NhanKhaus", "Xa", c => c.String());
            AddColumn("dbo.NhanKhaus", "Huyen", c => c.String());
            AddColumn("dbo.NhanKhaus", "Tinh", c => c.String());
            AddColumn("dbo.HoKhaus", "Xom", c => c.String());
            AddColumn("dbo.HoKhaus", "Thon", c => c.String());
            AddColumn("dbo.HoKhaus", "PhuongXa", c => c.String());
            AddColumn("dbo.HoKhaus", "QuanHuyen", c => c.String());
            AddColumn("dbo.HoKhaus", "Tinh", c => c.String());
            DropColumn("dbo.NhanKhaus", "DiaChiTamTru");
            DropColumn("dbo.NhanKhaus", "MaXaPhuongTamTru");
            DropColumn("dbo.NhanKhaus", "MaQuanHuyenTamTru");
            DropColumn("dbo.NhanKhaus", "MaTinhThanhTamTru");
            DropColumn("dbo.HoKhaus", "TenXom");
            DropColumn("dbo.HoKhaus", "MaXom");
            DropColumn("dbo.HoKhaus", "TenThon");
            DropColumn("dbo.HoKhaus", "MaThon");
            DropColumn("dbo.HoKhaus", "TenXaPhuong");
            DropColumn("dbo.HoKhaus", "MaXaPhuong");
            DropColumn("dbo.HoKhaus", "TenQuanHuyen");
            DropColumn("dbo.HoKhaus", "MaQuanHuyen");
            DropColumn("dbo.HoKhaus", "TenTinhThanh");
            DropColumn("dbo.HoKhaus", "MaTinhThanh");
        }
    }
}
