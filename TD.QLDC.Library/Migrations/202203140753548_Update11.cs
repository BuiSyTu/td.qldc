namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        MD5Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Account");
        }
    }
}
