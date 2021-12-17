namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanKhaus", "DaMat", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanKhaus", "DaMat");
        }
    }
}
