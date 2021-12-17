namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoKhaus", "TenChuHo", c => c.String());
            AddColumn("dbo.NhanKhaus", "HanSuDungCCCD", c => c.String());
            DropColumn("dbo.HoKhaus", "NguoiNhap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoKhaus", "NguoiNhap", c => c.String());
            DropColumn("dbo.NhanKhaus", "HanSuDungCCCD");
            DropColumn("dbo.HoKhaus", "TenChuHo");
        }
    }
}
