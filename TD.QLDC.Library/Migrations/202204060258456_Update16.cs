namespace TD.QLDC.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanKhaus", "NgaySinh", c => c.DateTime());
            AddColumn("dbo.NhanKhaus", "HanSuDungCCCD", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanKhaus", "HanSuDungCCCD");
            DropColumn("dbo.NhanKhaus", "NgaySinh");
        }
    }
}
