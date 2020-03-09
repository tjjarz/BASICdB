namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FreshMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem");
            DropIndex("dbo.Character", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Item", new[] { "CharItem_CharItemID" });
            DropColumn("dbo.Character", "CharItem_CharItemID");
            DropColumn("dbo.Item", "CharItem_CharItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "CharItem_CharItemID", c => c.Int());
            AddColumn("dbo.Character", "CharItem_CharItemID", c => c.Int());
            CreateIndex("dbo.Item", "CharItem_CharItemID");
            CreateIndex("dbo.Character", "CharItem_CharItemID");
            AddForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
            AddForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
        }
    }
}
