namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoKhaus", "CCCDCHuHo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoKhaus", "CCCDCHuHo");
        }
    }
}
