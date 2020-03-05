namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCharMedia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharItem", "ItemId", "dbo.Item");
            DropIndex("dbo.CharItem", new[] { "ItemId" });
            CreateTable(
                "dbo.CharMedia",
                c => new
                    {
                        CharMediaID = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharMediaID)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
            AddColumn("dbo.Item", "CharItem_CharItemID", c => c.Int());
            AddColumn("dbo.Media", "CharMedia_CharMediaID", c => c.Int());
            CreateIndex("dbo.Item", "CharItem_CharItemID");
            CreateIndex("dbo.Media", "CharMedia_CharMediaID");
            AddForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
            AddForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
            DropColumn("dbo.CharItem", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharItem", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.CharMedia", "CharacterId", "dbo.Character");
            DropIndex("dbo.Media", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.CharMedia", new[] { "CharacterId" });
            DropIndex("dbo.Item", new[] { "CharItem_CharItemID" });
            DropColumn("dbo.Media", "CharMedia_CharMediaID");
            DropColumn("dbo.Item", "CharItem_CharItemID");
            DropTable("dbo.CharMedia");
            CreateIndex("dbo.CharItem", "ItemId");
            AddForeignKey("dbo.CharItem", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
        }
    }
}
