namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDevPullSaturday : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropIndex("dbo.Character", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.Media", new[] { "CharMedia_CharMediaID" });
            AddColumn("dbo.CharItem", "CharId", c => c.Int(nullable: false));
            AddColumn("dbo.CharItem", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.CharItem", "CharId");
            CreateIndex("dbo.CharItem", "ItemId");
            AddForeignKey("dbo.CharItem", "CharId", "dbo.Character", "CharId", cascadeDelete: true);
            AddForeignKey("dbo.CharItem", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
            DropColumn("dbo.Character", "CharMedia_CharMediaID");
            DropColumn("dbo.Media", "CharMedia_CharMediaID");
            DropTable("dbo.CharMedia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CharMedia",
                c => new
                    {
                        CharMediaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CharMediaID);
            
            AddColumn("dbo.Media", "CharMedia_CharMediaID", c => c.Int());
            AddColumn("dbo.Character", "CharMedia_CharMediaID", c => c.Int());
            DropForeignKey("dbo.CharItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.CharItem", "CharId", "dbo.Character");
            DropIndex("dbo.CharItem", new[] { "ItemId" });
            DropIndex("dbo.CharItem", new[] { "CharId" });
            DropColumn("dbo.CharItem", "ItemId");
            DropColumn("dbo.CharItem", "CharId");
            CreateIndex("dbo.Media", "CharMedia_CharMediaID");
            CreateIndex("dbo.Character", "CharMedia_CharMediaID");
            AddForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
            AddForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
        }
    }
}
