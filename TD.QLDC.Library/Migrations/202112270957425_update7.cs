namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update7 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Areas", "ParentId");
            AddForeignKey("dbo.Areas", "ParentId", "dbo.Areas", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "ParentId", "dbo.Areas");
            DropIndex("dbo.Areas", new[] { "ParentId" });
        }
    }
}
