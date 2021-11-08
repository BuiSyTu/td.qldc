namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        NhomID = c.Int(nullable: false),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NhomDanhMucs", t => t.NhomID, cascadeDelete: true)
                .Index(t => t.NhomID);
            
            CreateTable(
                "dbo.NhomDanhMucs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HoKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(),
                        SoNha = c.String(),
                        Xom = c.String(),
                        DMLoaiHoID = c.Int(),
                        Thon = c.String(),
                        SuDung = c.Boolean(nullable: false),
                        NguoiNhap = c.String(),
                        GhiChu = c.String(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.DMLoaiHoID)
                .Index(t => t.DMLoaiHoID);
            
            CreateTable(
                "dbo.NhanKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(),
                        DMDanTocID = c.Int(),
                        DMQuocTichID = c.Int(),
                        DMVanHoaID = c.Int(),
                        DMChuyenMonID = c.Int(),
                        DMTonGiaoID = c.Int(),
                        DMHonNhanID = c.Int(),
                        DMQuanHeID = c.Int(),
                        DMTinhTrangCuTruID = c.Int(),
                        DMDoiTuongID = c.Int(),
                        HoTen = c.String(),
                        TenGoiKhac = c.String(),
                        NoiSinh = c.String(),
                        QueQuan = c.String(),
                        SoCMT = c.String(),
                        NoiCapCMT = c.String(),
                        SoCCCD = c.String(),
                        NoiCapCCCD = c.String(),
                        TrinhDoVanHoa = c.String(),
                        TrinhDoChuyenMon = c.String(),
                        NgheNghiep = c.String(),
                        NoiLamViec = c.String(),
                        NoiThuongTru = c.String(),
                        NoiOHienTai = c.String(),
                        SoHC = c.String(),
                        NoiCapHC = c.String(),
                        SoBHYT = c.String(),
                        NoiCapBHYT = c.String(),
                        MaSoThue = c.String(),
                        TenCha = c.String(),
                        TenMe = c.String(),
                        ThanNhan = c.String(),
                        NoiTTTruoc = c.String(),
                        GhiChu = c.String(),
                        LyDoChuyuen = c.String(),
                        GioiTinh = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        AnhDaiDien = c.String(),
                        NgaySinh = c.DateTime(),
                        NgayCapCMT = c.DateTime(),
                        NgayCapCCCD = c.DateTime(),
                        NgayCapHC = c.DateTime(),
                        NgayCapBHYT = c.DateTime(),
                        ChuyenDenNgay = c.DateTime(),
                        MaXacThuc = c.String(),
                        HanXacThuc = c.DateTime(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.DMChuyenMonID)
                .ForeignKey("dbo.Categories", t => t.DMDanTocID)
                .ForeignKey("dbo.Categories", t => t.DMDoiTuongID)
                .ForeignKey("dbo.Categories", t => t.DMHonNhanID)
                .ForeignKey("dbo.Categories", t => t.DMQuanHeID)
                .ForeignKey("dbo.Categories", t => t.DMQuocTichID)
                .ForeignKey("dbo.Categories", t => t.DMTinhTrangCuTruID)
                .ForeignKey("dbo.Categories", t => t.DMTonGiaoID)
                .ForeignKey("dbo.Categories", t => t.DMVanHoaID)
                .Index(t => t.DMDanTocID)
                .Index(t => t.DMQuocTichID)
                .Index(t => t.DMVanHoaID)
                .Index(t => t.DMChuyenMonID)
                .Index(t => t.DMTonGiaoID)
                .Index(t => t.DMHonNhanID)
                .Index(t => t.DMQuanHeID)
                .Index(t => t.DMTinhTrangCuTruID)
                .Index(t => t.DMDoiTuongID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanKhaus", "DMVanHoaID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMTonGiaoID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMTinhTrangCuTruID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMQuocTichID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMQuanHeID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMHonNhanID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMDoiTuongID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMDanTocID", "dbo.Categories");
            DropForeignKey("dbo.NhanKhaus", "DMChuyenMonID", "dbo.Categories");
            DropForeignKey("dbo.HoKhaus", "DMLoaiHoID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "NhomID", "dbo.NhomDanhMucs");
            DropIndex("dbo.NhanKhaus", new[] { "DMDoiTuongID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMTinhTrangCuTruID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMQuanHeID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMHonNhanID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMTonGiaoID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMChuyenMonID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMVanHoaID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMQuocTichID" });
            DropIndex("dbo.NhanKhaus", new[] { "DMDanTocID" });
            DropIndex("dbo.HoKhaus", new[] { "DMLoaiHoID" });
            DropIndex("dbo.Categories", new[] { "NhomID" });
            DropTable("dbo.NhanKhaus",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                });
            DropTable("dbo.HoKhaus");
            DropTable("dbo.NhomDanhMucs");
            DropTable("dbo.Categories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                });
        }
    }
}
