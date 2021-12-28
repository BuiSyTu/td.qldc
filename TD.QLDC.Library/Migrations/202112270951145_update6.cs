namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        Name = c.String(),
                        Code = c.String(),
                        Note = c.String(),
                        Active = c.Boolean(),
                        ParentId = c.Int(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Areas");
        }
    }
}
