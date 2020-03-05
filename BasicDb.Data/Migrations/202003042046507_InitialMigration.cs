namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharItem",
                c => new
                    {
                        CharItemID = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharItemID)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharItem", "CharacterId", "dbo.Character");
            DropIndex("dbo.CharItem", new[] { "CharacterId" });
            DropTable("dbo.CharItem");
        }
    }
}
