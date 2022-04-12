namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanKhaus", "DuocMienBHYT", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanKhaus", "DuocMienBHYT");
        }
    }
}
