namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCharacter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharMedia", "Character_CharID", "dbo.Character");
            DropForeignKey("dbo.CharItem", "Item_ItemId", "dbo.Item");
            DropForeignKey("dbo.CharItem", "Character_CharID", "dbo.Character");
            DropIndex("dbo.CharItem", new[] { "Character_CharID" });
            DropIndex("dbo.CharItem", new[] { "Item_ItemId" });
            DropIndex("dbo.CharMedia", new[] { "Character_CharID" });
            RenameColumn(table: "dbo.CharItem", name: "Item_ItemId", newName: "ItemId");
            RenameColumn(table: "dbo.CharItem", name: "Character_CharID", newName: "CharId");
            AddColumn("dbo.Item", "Character_CharId", c => c.Int());
            AddColumn("dbo.Media", "Character_CharId", c => c.Int());
            AlterColumn("dbo.CharItem", "CharId", c => c.Int(nullable: false));
            AlterColumn("dbo.CharItem", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "Character_CharId");
            CreateIndex("dbo.CharItem", "CharId");
            CreateIndex("dbo.CharItem", "ItemId");
            CreateIndex("dbo.Media", "Character_CharId");
            AddForeignKey("dbo.Item", "Character_CharId", "dbo.Character", "CharId");
            AddForeignKey("dbo.Media", "Character_CharId", "dbo.Character", "CharId");
            AddForeignKey("dbo.CharItem", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
            AddForeignKey("dbo.CharItem", "CharId", "dbo.Character", "CharId", cascadeDelete: true);
            DropColumn("dbo.CharMedia", "Character_CharID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharMedia", "Character_CharID", c => c.Int());
            DropForeignKey("dbo.CharItem", "CharId", "dbo.Character");
            DropForeignKey("dbo.CharItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Media", "Character_CharId", "dbo.Character");
            DropForeignKey("dbo.Item", "Character_CharId", "dbo.Character");
            DropIndex("dbo.Media", new[] { "Character_CharId" });
            DropIndex("dbo.CharItem", new[] { "ItemId" });
            DropIndex("dbo.CharItem", new[] { "CharId" });
            DropIndex("dbo.Item", new[] { "Character_CharId" });
            AlterColumn("dbo.CharItem", "ItemId", c => c.Int());
            AlterColumn("dbo.CharItem", "CharId", c => c.Int());
            DropColumn("dbo.Media", "Character_CharId");
            DropColumn("dbo.Item", "Character_CharId");
            RenameColumn(table: "dbo.CharItem", name: "CharId", newName: "Character_CharID");
            RenameColumn(table: "dbo.CharItem", name: "ItemId", newName: "Item_ItemId");
            CreateIndex("dbo.CharMedia", "Character_CharID");
            CreateIndex("dbo.CharItem", "Item_ItemId");
            CreateIndex("dbo.CharItem", "Character_CharID");
            AddForeignKey("dbo.CharItem", "Character_CharID", "dbo.Character", "CharID");
            AddForeignKey("dbo.CharItem", "Item_ItemId", "dbo.Item", "ItemId");
            AddForeignKey("dbo.CharMedia", "Character_CharID", "dbo.Character", "CharID");
        }
    }
}
