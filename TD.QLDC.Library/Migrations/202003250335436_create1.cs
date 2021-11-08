namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class create1 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "Name", newValue: "Name")
                                },
                            }),
                        NhomID = c.Int(nullable: false),
                        Description = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "Description", newValue: "Description")
                                },
                            }),
                        Active = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "new FullTextIndexedTableAnnotation(new System.ComponentModel.DataAnnotations.Schema.FullTextIndexedTableAttribute())")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.HoKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoHoKhau", newValue: "SoHoKhau")
                                },
                            }),
                        SoNha = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoNha", newValue: "SoNha")
                                },
                            }),
                        PhuongXa = c.String(),
                        Tinh = c.String(),
                        DMLoaiHo = c.String(),
                        QuanHuyen = c.String(),
                        SuDung = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "new FullTextIndexedTableAnnotation(new System.ComponentModel.DataAnnotations.Schema.FullTextIndexedTableAttribute())")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.NhanKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoHoKhau", newValue: "SoHoKhau")
                                },
                            }),
                        Tinh = c.String(),
                        Huyen = c.String(),
                        Xa = c.String(),
                        Xom = c.String(),
                        DMDanToc = c.String(),
                        DMQuocTich = c.String(),
                        DMVanHoa = c.String(),
                        DMChuyenMon = c.String(),
                        DMTonGiao = c.String(),
                        DMHonNhan = c.String(),
                        DMQuanHe = c.String(),
                        DMTinhTrangCuTru = c.String(),
                        DMDoiTuong = c.String(),
                        HoTen = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "HoTen", newValue: "HoTen")
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
                                    new AnnotationValues(oldValue: "SoCMT", newValue: "SoCMT")
                                },
                            }),
                        NoiCapCMT = c.String(),
                        SoCCCD = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoCCCD", newValue: "SoCCCD")
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
                                    new AnnotationValues(oldValue: "SoDienThoai", newValue: "SoDienThoai")
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "new FullTextIndexedTableAnnotation(new System.ComponentModel.DataAnnotations.Schema.FullTextIndexedTableAttribute())")
                    },
                });
            
            AlterColumn("dbo.HoKhaus", "SoHoKhau", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "SoHoKhau")
                    },
                }));
            AlterColumn("dbo.HoKhaus", "SoNha", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "SoNha")
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoHoKhau", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "SoHoKhau")
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "HoTen", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "HoTen")
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoCMT", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "SoCMT")
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoCCCD", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "SoCCCD")
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoDienThoai", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "SoDienThoai")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanKhaus", "SoDienThoai", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "SoDienThoai", newValue: null)
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoCCCD", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "SoCCCD", newValue: null)
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoCMT", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "SoCMT", newValue: null)
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "HoTen", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "HoTen", newValue: null)
                    },
                }));
            AlterColumn("dbo.NhanKhaus", "SoHoKhau", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "SoHoKhau", newValue: null)
                    },
                }));
            AlterColumn("dbo.HoKhaus", "SoNha", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "SoNha", newValue: null)
                    },
                }));
            AlterColumn("dbo.HoKhaus", "SoHoKhau", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexAnnotation",
                        new AnnotationValues(oldValue: "SoHoKhau", newValue: null)
                    },
                }));
            AlterTableAnnotations(
                "dbo.NhanKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoHoKhau", newValue: "SoHoKhau")
                                },
                            }),
                        Tinh = c.String(),
                        Huyen = c.String(),
                        Xa = c.String(),
                        Xom = c.String(),
                        DMDanToc = c.String(),
                        DMQuocTich = c.String(),
                        DMVanHoa = c.String(),
                        DMChuyenMon = c.String(),
                        DMTonGiao = c.String(),
                        DMHonNhan = c.String(),
                        DMQuanHe = c.String(),
                        DMTinhTrangCuTru = c.String(),
                        DMDoiTuong = c.String(),
                        HoTen = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "HoTen", newValue: "HoTen")
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
                                    new AnnotationValues(oldValue: "SoCMT", newValue: "SoCMT")
                                },
                            }),
                        NoiCapCMT = c.String(),
                        SoCCCD = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoCCCD", newValue: "SoCCCD")
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
                                    new AnnotationValues(oldValue: "SoDienThoai", newValue: "SoDienThoai")
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "new FullTextIndexedTableAnnotation(new System.ComponentModel.DataAnnotations.Schema.FullTextIndexedTableAttribute())")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.HoKhaus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoHoKhau = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoHoKhau", newValue: "SoHoKhau")
                                },
                            }),
                        SoNha = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "SoNha", newValue: "SoNha")
                                },
                            }),
                        PhuongXa = c.String(),
                        Tinh = c.String(),
                        DMLoaiHo = c.String(),
                        QuanHuyen = c.String(),
                        SuDung = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "Name", newValue: "Name")
                                },
                            }),
                        NhomID = c.Int(nullable: false),
                        Description = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FullTextIndexAnnotation",
                                    new AnnotationValues(oldValue: "Description", newValue: "Description")
                                },
                            }),
                        Active = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "new FullTextIndexedTableAnnotation(new System.ComponentModel.DataAnnotations.Schema.FullTextIndexedTableAttribute())")
                    },
                });
            
        }
    }
}
