namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NhanKhaus", "NgaySinh");
            DropColumn("dbo.NhanKhaus", "HanSuDungCCCD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanKhaus", "HanSuDungCCCD", c => c.String());
            AddColumn("dbo.NhanKhaus", "NgaySinh", c => c.String());
        }
    }
}
