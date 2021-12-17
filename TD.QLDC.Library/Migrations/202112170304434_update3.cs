namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanKhaus", "LoaiDoiTuongChinhSach", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanKhaus", "LoaiDoiTuongChinhSach");
        }
    }
}
