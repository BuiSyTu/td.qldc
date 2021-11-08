namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Db_init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "Name")
                                },
                            }),
                        NhomID = c.Int(nullable: false),
                        Description = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "Description")
                                },
                            }),
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
                        SoHoKhau = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "SoHoKhau")
                                },
                            }),
                        SoNha = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "SoNha")
                                },
                            }),
                        PhuongXa = c.String(),
                        Tinh = c.String(),
                        DMLoaiHo = c.String(),
                        QuanHuyen = c.String(),
                        SuDung = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                        Thon = c.String(),
                        Xom = c.String(),
                        NguoiNhap = c.String(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NhanKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "SoHoKhau")
                                },
                            }),
                        Tinh = c.String(),
                        Huyen = c.String(),
                        Xa = c.String(),
                        Xom = c.String(),
                        DMDanTocText = c.String(),
                        DMDanTocID = c.Int(),
                        DMQuocTichText = c.String(),
                        DMQuocTichID = c.Int(),
                        DMVanHoaText = c.String(),
                        DMVanHoaID = c.Int(),
                        DMChuyenMonText = c.String(),
                        DMChuyenMonID = c.Int(),
                        DMTonGiaoText = c.String(),
                        DMTonGiaoID = c.Int(),
                        DMHonNhanText = c.String(),
                        DMHonNhanID = c.Int(),
                        DMQuanHeText = c.String(),
                        DMQuanHeID = c.Int(),
                        DMTinhTrangCuTruText = c.String(),
                        DMTinhTrangCuTruID = c.Int(),
                        DMDoiTuongText = c.String(),
                        DMDoiTuongID = c.Int(),
                        HoTen = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "HoTen")
                                },
                            }),
                        TenGoiKhac = c.String(),
                        NoiSinh = c.String(),
                        QueQuan = c.String(),
                        SoCMT = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "SoCMT")
                                },
                            }),
                        NoiCapCMT = c.String(),
                        SoCCCD = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "SoCCCD")
                                },
                            }),
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
                        SoDienThoai = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: null, newValue: "SoDienThoai")
                                },
                            }),
                        Email = c.String(),
                        AnhDaiDien = c.String(),
                        NgaySinh = c.String(),
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
            DropIndex("dbo.Categories", new[] { "NhomID" });
            DropTable("dbo.NhanKhaus",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                },
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "HoTen",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "HoTen" },
                        }
                    },
                    {
                        "SoCCCD",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "SoCCCD" },
                        }
                    },
                    {
                        "SoCMT",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "SoCMT" },
                        }
                    },
                    {
                        "SoDienThoai",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "SoDienThoai" },
                        }
                    },
                    {
                        "SoHoKhau",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "SoHoKhau" },
                        }
                    },
                });
            DropTable("dbo.HoKhaus",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                },
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "SoHoKhau",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "SoHoKhau" },
                        }
                    },
                    {
                        "SoNha",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "SoNha" },
                        }
                    },
                });
            DropTable("dbo.NhomDanhMucs");
            DropTable("dbo.Categories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "FullTextIndexedTableAnnotation", "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation" },
                },
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Description",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "Description" },
                        }
                    },
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "FullTextIndexAnnotation", "Name" },
                        }
                    },
                });
        }
    }
}
