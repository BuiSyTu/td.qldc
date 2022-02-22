namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanKhaus", "HoTenBo", c => c.String());
            AddColumn("dbo.NhanKhaus", "HoTenMe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanKhaus", "HoTenMe");
            DropColumn("dbo.NhanKhaus", "HoTenBo");
        }
    }
}
