namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttemptFixForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropIndex("dbo.Character", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Character", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.Item", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Media", new[] { "CharMedia_CharMediaID" });
            AddColumn("dbo.CharItem", "Character_CharID", c => c.Int());
            AddColumn("dbo.CharItem", "Item_ItemId", c => c.Int());
            AddColumn("dbo.CharMedia", "Character_CharID", c => c.Int());
            AddColumn("dbo.CharMedia", "Media_MediaId", c => c.Int());
            CreateIndex("dbo.CharItem", "Character_CharID");
            CreateIndex("dbo.CharItem", "Item_ItemId");
            CreateIndex("dbo.CharMedia", "Character_CharID");
            CreateIndex("dbo.CharMedia", "Media_MediaId");
            AddForeignKey("dbo.CharItem", "Character_CharID", "dbo.Character", "CharID");
            AddForeignKey("dbo.CharMedia", "Character_CharID", "dbo.Character", "CharID");
            AddForeignKey("dbo.CharItem", "Item_ItemId", "dbo.Item", "ItemId");
            AddForeignKey("dbo.CharMedia", "Media_MediaId", "dbo.Media", "MediaId");
            DropColumn("dbo.Character", "CharItem_CharItemID");
            DropColumn("dbo.Character", "CharMedia_CharMediaID");
            DropColumn("dbo.Item", "CharItem_CharItemID");
            DropColumn("dbo.Media", "CharMedia_CharMediaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "CharMedia_CharMediaID", c => c.Int());
            AddColumn("dbo.Item", "CharItem_CharItemID", c => c.Int());
            AddColumn("dbo.Character", "CharMedia_CharMediaID", c => c.Int());
            AddColumn("dbo.Character", "CharItem_CharItemID", c => c.Int());
            DropForeignKey("dbo.CharMedia", "Media_MediaId", "dbo.Media");
            DropForeignKey("dbo.CharItem", "Item_ItemId", "dbo.Item");
            DropForeignKey("dbo.CharMedia", "Character_CharID", "dbo.Character");
            DropForeignKey("dbo.CharItem", "Character_CharID", "dbo.Character");
            DropIndex("dbo.CharMedia", new[] { "Media_MediaId" });
            DropIndex("dbo.CharMedia", new[] { "Character_CharID" });
            DropIndex("dbo.CharItem", new[] { "Item_ItemId" });
            DropIndex("dbo.CharItem", new[] { "Character_CharID" });
            DropColumn("dbo.CharMedia", "Media_MediaId");
            DropColumn("dbo.CharMedia", "Character_CharID");
            DropColumn("dbo.CharItem", "Item_ItemId");
            DropColumn("dbo.CharItem", "Character_CharID");
            CreateIndex("dbo.Media", "CharMedia_CharMediaID");
            CreateIndex("dbo.Item", "CharItem_CharItemID");
            CreateIndex("dbo.Character", "CharMedia_CharMediaID");
            CreateIndex("dbo.Character", "CharItem_CharItemID");
            AddForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
            AddForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
            AddForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
            AddForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
        }
    }
}
