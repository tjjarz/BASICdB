namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysToAllTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "CharItem_CharItemID", c => c.Int());
            AddColumn("dbo.Item", "CharItem_CharItemID", c => c.Int());
            AddColumn("dbo.Media", "CharMedia_CharMediaID", c => c.Int());
            CreateIndex("dbo.Character", "CharItem_CharItemID");
            CreateIndex("dbo.Item", "CharItem_CharItemID");
            CreateIndex("dbo.Media", "CharMedia_CharMediaID");
            AddForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
            AddForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
            AddForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem");
            DropIndex("dbo.Media", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.Item", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Character", new[] { "CharItem_CharItemID" });
            DropColumn("dbo.Media", "CharMedia_CharMediaID");
            DropColumn("dbo.Item", "CharItem_CharItemID");
            DropColumn("dbo.Character", "CharItem_CharItemID");
        }
    }
}
