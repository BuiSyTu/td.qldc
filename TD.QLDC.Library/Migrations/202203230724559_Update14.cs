namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "Tags", c => c.String());
            AddColumn("dbo.Categories", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Tags");
            DropColumn("dbo.Areas", "Tags");
        }
    }
}
