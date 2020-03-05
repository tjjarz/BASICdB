namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCharItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharItem", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.CharItem", "ItemId");
            AddForeignKey("dbo.CharItem", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharItem", "ItemId", "dbo.Item");
            DropIndex("dbo.CharItem", new[] { "ItemId" });
            DropColumn("dbo.CharItem", "ItemId");
        }
    }
}
