namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class fixaddnhankhau : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation")
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation")
                    },
                });
            
            AlterColumn("dbo.NhanKhaus", "GioiTinh", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanKhaus", "GioiTinh", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation")
                    },
                });
            
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "FullTextIndexedTableAnnotation",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation", newValue: "System.Data.Entity.Infrastructure.Annotations.FullTextIndexedTableAnnotation")
                    },
                });
            
        }
    }
}
